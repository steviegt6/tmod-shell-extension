using System.Drawing;
using System.Runtime.InteropServices;

using SharpShell.Attributes;
using SharpShell.SharpIconHandler;

using Tomat.TMOD.ShellExtension.Util;

namespace Tomat.TMOD.ShellExtension;

[ComVisible(true)]
[COMServerAssociation(AssociationType.ClassOfExtension, ".tmod")]
public sealed class TmodIconHandler : SharpIconHandler
{
    protected override Icon GetIcon(bool smallIcon, uint iconSize)
    {
        var file    = SimpleTmodReader.ReadFromFile(SelectedItemPath);
        var iconSet = IconSet.FromTmod(file);

        var preferred = smallIcon ? (iconSet.SmallIcon, iconSet.LargeIcon) : (iconSet.LargeIcon, iconSet.SmallIcon);
        return preferred.Item1 ?? preferred.Item2 ?? null!;
    }
}