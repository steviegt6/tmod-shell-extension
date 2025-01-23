using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using SharpShell.Attributes;
using SharpShell.SharpPropertySheet;

namespace Tomat.TMOD.ShellExtension;

[Guid("cb413e02-43a2-4714-8cb3-100a93f0db0a")]
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