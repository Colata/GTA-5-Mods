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
    public void subTeleportCentral()
    {
        //Alamo Sea, Grand Senora Desert, South Chilliad, Tongva hills

        List<IMenuItem> RegionsCentral = new List<IMenuItem>();

        var button = new GTA.MenuButton("Alamo Sea");
        button.Activated += (sender, args) =>
        {
            this.alamoSea();
        };
        RegionsCentral.Add(button);

        button = new GTA.MenuButton("Grand Senora Desert");
        button.Activated += (sender, args) =>
        {
            this.grandSenoraDesert();
        };
        RegionsCentral.Add(button);

        button = new GTA.MenuButton("South Chilliad");
        button.Activated += (sender, args) =>
        {
            this.southChilliad();
        };
        RegionsCentral.Add(button);

        button = new GTA.MenuButton("Tongva Hills");
        button.Activated += (sender, args) =>
        {
            this.tongvaHils();
        };
        RegionsCentral.Add(button);

        var main = new GTA.Menu("Central San Andreas", RegionsCentral.ToArray());
        DrawMenu(main);
    }

    private void tongvaHils()
    {
        throw new System.NotImplementedException();
    }

    private void southChilliad()
    {
        throw new System.NotImplementedException();
    }

    private void grandSenoraDesert()
    {
        throw new System.NotImplementedException();
    }

    private void alamoSea()
    {
        throw new System.NotImplementedException();
    }
}
