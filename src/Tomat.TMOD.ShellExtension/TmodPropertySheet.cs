using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using SharpShell.Attributes;
using SharpShell.SharpPropertySheet;

namespace Tomat.TMOD.ShellExtension;

[ComVisible(true)]
[COMServerAssociation(AssociationType.ClassOfExtension, ".tmod")]
public sealed partial class TmodPropertySheet : SharpPropertySheet
{
    protected override bool CanShowSheet()
    {
        return SelectedItemPaths.Count() == 1;
    }

    protected override IEnumerable<SharpPropertyPage> CreatePages()
    {
        yield return new TmodPropertyPage();
    }
}