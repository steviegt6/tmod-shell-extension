using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Tomat.TMOD.ShellExtension.Util;

/// <summary>
///     Simple representation of a TMOD file.
/// </summary>
public class TmodFile
{
    public readonly struct FileEntry
    {
        public string Path { get; init; }

        public int UncompressedLength { get; init; }

        public int CompressedLength { get; init; }
    }

    public required uint Header { get; init; }

    public required string Version { get; init; }

    public required byte[] Hash { get; init; }

    public required byte[] Signature { get; init; }

    public required uint FileDataLength { get; init; }

    public required string ModName { get; init; }

    public required string ModVersion { get; init; }

    public required FileEntry[] Entries { get; init; }

    public required Dictionary<string, byte[]> RawData { get; init; }

    private readonly Dictionary<string, byte[]> dataCache = new();

    public byte[]? GetData(FileEntry entry)
    {
        if (dataCache.TryGetValue(entry.Path, out var data))
        {
            return data;
        }

        if (!RawData.TryGetValue(entry.Path, out data))
        {
            return null;
        }

        return dataCache[entry.Path] = Decompress(entry);
    }

    private byte[] Decompress(FileEntry entry)
    {
        if (entry.CompressedLength == entry.UncompressedLength)
        {
            return RawData[entry.Path];
        }

        using var compressedStream   = new MemoryStream(RawData[entry.Path]);
        using var decompressedStream = new MemoryStream();
        using var deflateStream      = new DeflateStream(compressedStream, CompressionMode.Decompress);
        deflateStream.CopyTo(decompressedStream);
        return decompressedStream.ToArray();
    }
}