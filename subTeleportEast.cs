using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using GTA;
using GTA.Math;
using GTA.Native;
using Menu = GTA.Menu;

public partial class Mod : Script
{
    public void subTeleportEast()
    {
        //Chianski Mountain Range, Grapeseed

        List<IMenuItem> RegionsEast = new List<IMenuItem>();

        var button = new GTA.MenuButton("Chianski Mountain Range");
        button.Activated += (sender, args) =>
        {
            this.chianskiMountainRange();
        };
        RegionsEast.Add(button);

        button = new GTA.MenuButton("Grapeseed");
        button.Activated += (sender, args) =>
        {
            this.grapeseed();
        };
        RegionsEast.Add(button);

        var main = new GTA.Menu("East San Andreas", RegionsEast.ToArray());
        DrawMenu(main);
    }

    private void grapeseed()
    {
        throw new System.NotImplementedException();
    }

    private void chianskiMountainRange()
    {
        throw new System.NotImplementedException();
    }
}

