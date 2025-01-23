using System;
using System.Drawing;
using System.Runtime.InteropServices;

using SharpShell.Attributes;
using SharpShell.SharpIconHandler;

using Tomat.TMOD.ShellExtension.Util;

namespace Tomat.TMOD.ShellExtension;

[Guid("a0479a35-52a2-4b8f-aa40-bbadd0a2ca7b")]
[ComVisible(true)]
[COMServerAssociation(AssociationType.ClassOfExtension, ".tmod")]
public sealed class TmodIconHandler : SharpIconHandler
{
    protected override Icon GetIcon(bool smallIcon, uint iconSize)
    {
        var file    = SimpleTmodReader.ReadFromFile(SelectedItemPath);
        var iconSet = IconSet.FromTmod(file);

        var preferred = (smallIcon || iconSize < 32) ? (iconSet.SmallIcon, iconSet.LargeIcon) : (iconSet.LargeIcon, iconSet.SmallIcon);
        return preferred.Item1 ?? preferred.Item2 ?? null!;
    }
}