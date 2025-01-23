using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Tomat.TMOD.ShellExtension.Util;

public readonly record struct IconSet(Icon? SmallIcon, Icon? LargeIcon)
{
    public static IconSet FromTmod(TmodFile file)
    {
        var smallIcon = default(Icon);
        var largeIcon = default(Icon);

        if (file.RawData.TryGetValue("icon_small.rawimg", out var smallIconData))
        {
            smallIcon = SimpleTmodReader.ConvertToIcon(smallIconData);
        }
        else if (file.RawData.TryGetValue("icon_small.png", out smallIconData))
        {
            smallIcon = IconFromImage(ImageFromPng(smallIconData));
        }

        if (file.RawData.TryGetValue("icon.png", out var iconData))
        {
            largeIcon = IconFromImage(ImageFromPng(iconData));
        }

        return new IconSet(smallIcon, largeIcon);
    }

    private static Image ImageFromPng(byte[] data)
    {
        using var ms = new MemoryStream(data);
        return Image.FromStream(ms);
    }

    // https://stackoverflow.com/a/21389253
    private static Icon IconFromImage(Image i)
    {
        var ms = new MemoryStream();
        var bw = new BinaryWriter(ms);

        long sizeHere;
        int  start;

        // Header
        {
            bw.Write((short)0); // 0 : reserved
            bw.Write((short)1); // 2 : 1=ico, 2=cur
            bw.Write((short)1); // 4 : number of images
        }

        // Image directory
        {
            var width = i.Width;
            if (width >= 256)
            {
                width = 0;
            }
            bw.Write((byte)width); // 0 : width of image

            var height = i.Height;
            if (height >= 256)
            {
                height = 0;
            }

            bw.Write((byte)height); // 1 : height of image
            bw.Write((byte)0);      // 2 : number of colors in palette
            bw.Write((byte)0);      // 3 : reserved
            bw.Write((short)0);     // 4 : number of color planes
            bw.Write((short)0);     // 6 : bits per pixel
            sizeHere = ms.Position;
            bw.Write((int)0); // 8 : image size
            start = (int)ms.Position + 4;
            bw.Write(start); // 12: offset of image data
        }

        // Image data
        {
            i.Save(ms, ImageFormat.Png);
            var imageSize = (int)ms.Position - start;
            ms.Seek(sizeHere, SeekOrigin.Begin);
            bw.Write(imageSize);
            ms.Seek(0, SeekOrigin.Begin);
        }

        return new Icon(ms);
    }
}