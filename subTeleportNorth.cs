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
    public void subTeleportNorth()
    {
        //Paleto Bay, Chilliad, Mount Gordo

        List<IMenuItem> RegionsNorth = new List<IMenuItem>();

        var button = new GTA.MenuButton("Paleto Bay");
        button.Activated += (sender, args) =>
        {
            this.paletoBay();
        };
        RegionsNorth.Add(button);

        button = new GTA.MenuButton("Chilliad");
        button.Activated += (sender, args) =>
        {
            this.chilliad();
        };
        RegionsNorth.Add(button);

        button = new GTA.MenuButton("Mount Gordo");
        button.Activated += (sender, args) =>
        {
            this.mountGordo();
        };
        RegionsNorth.Add(button);

        var main = new GTA.Menu("North San Andreas", RegionsNorth.ToArray());
        DrawMenu(main);
    }

    private void mountGordo()
    {
        throw new System.NotImplementedException();
    }

    private void chilliad()
    {
        throw new System.NotImplementedException();
    }

    private void paletoBay()
    {
        throw new System.NotImplementedException();
    }
}
