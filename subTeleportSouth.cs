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
    public void subTeleportSouth()
    {
        //Los Santos, Vinewood, Tatavium Mountains, Banham Canyon

        List<IMenuItem> RegionsSouth = new List<IMenuItem>();

        var button = new GTA.MenuButton("Los Santos");
        button.Activated += (sender, args) =>
        {
            this.losSantos();
        };
        RegionsSouth.Add(button);

        button = new GTA.MenuButton("Vinewood");
        button.Activated += (sender, args) =>
        {
            this.vinewood();
        };
        RegionsSouth.Add(button);

        button = new GTA.MenuButton("Tatavium Mountains");
        button.Activated += (sender, args) =>
        {
            this.tataviumMountains();
        };
        RegionsSouth.Add(button);

        button = new GTA.MenuButton("Banham Canyon");
        button.Activated += (sender, args) =>
        {
            this.banhamCanyon();
        };
        RegionsSouth.Add(button);

        var main = new GTA.Menu("South San Andreas", RegionsSouth.ToArray());
        DrawMenu(main);
    }

    private void banhamCanyon()
    {
        throw new System.NotImplementedException();
    }

    private void tataviumMountains()
    {
        throw new System.NotImplementedException();
    }

    private void vinewood()
    {
        throw new System.NotImplementedException();
    }

    private void losSantos()
    {
        throw new System.NotImplementedException();
    }
}
