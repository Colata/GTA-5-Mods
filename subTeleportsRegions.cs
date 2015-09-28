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
    public void teleportRegions()
    {
        List<IMenuItem> teleportRegionsSubMenu = new List<IMenuItem>();

        var button = new GTA.MenuButton("Central San Andreas", "Alamo Sea, Grand Senora Desert, Tongva hills");
        button.Activated += (sender, args) =>
        {
            this.subTeleportCentral();
        };
        teleportRegionsSubMenu.Add(button);

        button = new GTA.MenuButton("North San Andreas", "Paleto Bay, Chilliad, Mount Gordo");
        button.Activated += (sender, args) =>
        {
            this.subTeleportNorth();
        };
        teleportRegionsSubMenu.Add(button);

        button = new GTA.MenuButton("South San Andreas", "Los Santos, Vinewood, Tatavium Mountains,");
        button.Activated += (sender, args) =>
        {
            this.subTeleportSouth();
        };
        teleportRegionsSubMenu.Add(button);

        button = new GTA.MenuButton("East San Andreas", "Chianski Mountain Range, Grapeseed");
        button.Activated += (sender, args) =>
        {
            this.subTeleportEast();
        };
        teleportRegionsSubMenu.Add(button);

        button = new GTA.MenuButton("West San Andreas", "Chumash, ");
        button.Activated += (sender, args) =>
        {
            this.subTeleportWest();
        };
        teleportRegionsSubMenu.Add(button);

        var main = new GTA.Menu("Teleport Regions", teleportRegionsSubMenu.ToArray());
        DrawMenu(main);
    }
}