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
    private void subWeapons()
    {
        List<IMenuItem> WeaponCategoriesList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Melee");
        button.Activated += (sender, args) => meleeList();
        WeaponCategoriesList.Add(button);

        button = new GTA.MenuButton("Pistol");
        button.Activated += (sender, args) => pistolList();
        WeaponCategoriesList.Add(button);

        button = new GTA.MenuButton("SMG");
        button.Activated += (sender, args) => SMGList();
        WeaponCategoriesList.Add(button);

        button = new GTA.MenuButton("Shotgun");
        button.Activated += (sender, args) => shotgunList();
        WeaponCategoriesList.Add(button);

        button = new GTA.MenuButton("Rifle");
        button.Activated += (sender, args) => rifleList();
        WeaponCategoriesList.Add(button);

        button = new GTA.MenuButton("MG");
        button.Activated += (sender, args) => mgList();
        WeaponCategoriesList.Add(button);

        button = new GTA.MenuButton("Sniper");
        button.Activated += (sender, args) => sniperList();
        WeaponCategoriesList.Add(button);

        button = new GTA.MenuButton("Heavy");
        button.Activated += (sender, args) => heavyList();
        WeaponCategoriesList.Add(button);

        button = new GTA.MenuButton("Thrown");
        button.Activated += (sender, args) => thrownList();
        WeaponCategoriesList.Add(button);

        button = new GTA.MenuButton("Back", "Return to the previous page");
        button.Activated += (sender, args) => View.HandleBack();
        WeaponCategoriesList.Add(button);

        var mainMenu = new Menu("Weapon Categories", WeaponCategoriesList.ToArray());
        DrawMenu(mainMenu);
    }
}
