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
    public void subVehicles()
    {
        List<IMenuItem> vehicleCategoriesList = new List<IMenuItem>();

        var Button = new GTA.MenuButton("Super");
        Button .Activated += (sender, args) => superList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Sport");
        Button .Activated += (sender, args) => sportList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("MotorCycles ");
        Button .Activated += (sender, args) => motorcycleList();
        vehicleCategoriesList.Add(Button);
        /*
        Button = new GTA.MenuButton("Utility");
        Button .Activated += (sender, args) => utilityList();
        vehicleCategoriesList.Add(Button);
        */
        Button = new GTA.MenuButton("Helicopters ");
        Button .Activated += (sender, args) => helicopterList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Planes");
        Button .Activated += (sender, args) => planeList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Sport Classic ");
        Button .Activated += (sender, args) => sportclassicList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Sedan ");
        Button .Activated += (sender, args) => sedanList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Muscle ");
        Button .Activated += (sender, args) => muscleList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Off-Road ");
        Button .Activated += (sender, args) => offroadList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("SUV ");
        Button .Activated += (sender, args) => suvList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Van ");
        Button .Activated += (sender, args) => vanList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Industrial ");
        Button .Activated += (sender, args) => industrialList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Commercial");
        Button .Activated += (sender, args) => commercialList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Military ");
        Button .Activated += (sender, args) => militaryList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Service ");
        Button .Activated += (sender, args) => serviceList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Cycles");
        Button .Activated += (sender, args) => cycleList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Compacts");
        Button .Activated += (sender, args) => compactList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Coupes");
        Button .Activated += (sender, args) => coupeList();
        vehicleCategoriesList.Add(Button);

        Button = new GTA.MenuButton("Back", "Return to the previous page");
        Button.Activated += (sender, args) => View.HandleBack();
        vehicleCategoriesList.Add(Button);

        var mainMenu = new Menu("Vehicle Categories", vehicleCategoriesList .ToArray());
        DrawMenu(mainMenu);
    }
}
