using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Tomat.TMOD.ShellExtension.Util;

/// <summary>
///     Bare-bones TMOD file reader.
/// </summary>
public sealed class SimpleTmodReader
{
    public static TmodFile ReadFromFile(string path)
    {
        return ReadFromStream(File.OpenRead(path));
    }

    public static TmodFile ReadFromStream(Stream stream)
    {
        using var r = new BinaryReader(stream);

        var header = r.ReadUInt32();
        if (header != 0x444F4D54)
        {
            throw new InvalidDataException("Invalid TMOD header.");
        }

        var version        = r.ReadString();
        var hash           = r.ReadBytes(20);
        var signature      = r.ReadBytes(256);
        var fileDataLength = r.ReadUInt32();
        var modName        = r.ReadString();
        var modVersion     = r.ReadString();

        var entryCount = r.ReadInt32();
        var entries    = new TmodFile.FileEntry[entryCount];
        for (var i = 0; i < entryCount; i++)
        {
            entries[i] = new TmodFile.FileEntry
            {
                Path               = r.ReadString(),
                UncompressedLength = r.ReadInt32(),
                CompressedLength   = r.ReadInt32(),
            };
        }

        var rawData = new Dictionary<string, byte[]>();
        foreach (var entry in entries)
        {
            rawData[entry.Path] = r.ReadBytes(entry.CompressedLength);
        }

        return new TmodFile
        {
            Header         = header,
            Version        = version,
            Hash           = hash,
            Signature      = signature,
            FileDataLength = fileDataLength,
            ModName        = modName,
            ModVersion     = modVersion,
            Entries        = entries,
            RawData        = rawData,
        };
    }

    public static Icon? ConvertToIcon(byte[] rawImg)
    {
        using var ms = new MemoryStream(rawImg);
        using var r  = new BinaryReader(ms);

        var version = r.ReadInt32();
        if (version != 1)
        {
            return null;
        }

        var width  = r.ReadInt32();
        var height = r.ReadInt32();
        var data   = r.ReadBytes(width * height * 4);

        using var bmp     = new Bitmap(width, height);
        var       bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bmp.PixelFormat);
        Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
        bmp.UnlockBits(bmpData);

        return Icon.FromHandle(bmp.GetHicon());
    }
}