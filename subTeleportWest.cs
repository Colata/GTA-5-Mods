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
    public void subTeleportWest()
    {
        //Zancudo, Chilliad state Wilderness

        List<IMenuItem> RegionsWest = new List<IMenuItem>();

        var button = new GTA.MenuButton("Chumash");
        button.Activated += (sender, args) =>
        {
            this.chumash();
        };
        RegionsWest.Add(button);

        button = new GTA.MenuButton("Chilliad State Wilderness");
        button.Activated += (sender, args) =>
        {
            this.chilliadStateWilderness();
        };
        RegionsWest.Add(button);

        var main = new GTA.Menu("West San Andreas", RegionsWest.ToArray());
        DrawMenu(main);
    }

    private void chumash()
    {
        throw new System.NotImplementedException();
    }

    private void chilliadStateWilderness()
    {
        throw new System.NotImplementedException();
    }

}