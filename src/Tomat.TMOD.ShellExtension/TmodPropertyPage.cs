using System;
using System.Linq;

using SharpShell.SharpPropertySheet;

using Tomat.TMOD.ShellExtension.Util;

namespace Tomat.TMOD.ShellExtension;

public partial class TmodPropertyPage : SharpPropertyPage
{
    private string? filePath;

    public TmodPropertyPage()
    {
        InitializeComponent();

        PageTitle = "TMOD Properties";
    }

    protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
    {
        base.OnPropertyPageInitialised(parent);

        filePath = parent.SelectedItemPaths.First();

        LoadTmodInfo();
    }

    private void LoadTmodInfo()
    {
        if (filePath is null)
        {
            return;
        }

        var tModFile = SimpleTmodReader.ReadFromFile(filePath);

        tmlVersion.Text = tModFile.Version;
        modName.Text    = tModFile.ModName;
        modVersion.Text = tModFile.ModVersion;
    }
}