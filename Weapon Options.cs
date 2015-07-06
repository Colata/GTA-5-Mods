using System;
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

public class Main : Script
{
    private void WeaponOptionMenu()
    {
        List<IMenuItem> WeaponOptionsMenuList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Weapon Customization");
        button.Activated += (sender, args) => Super();
        WeaponOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Ammunition");
        button.Activated += (sender, args) => Ammo();
        WeaponOptionsMenuList.Add(button);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        WeaponOptionsMenuList.Add(returnButton);

        var mainMenu = new Menu("Weapon Options Menu", WeaponOptionsMenuList.ToArray());
        DrawMenu(mainMenu);

    }

    void Ammo()
    {
        List<IMenuItem> GiveAmmoList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Give Ammo", "Add some ammo!");
        button.Activated += (sender, args) => GiveAmmo();
        GiveAmmoList.Add(button);

        button = new GTA.MenuButton("Set Normal Ammo!", "The standard Ammo!");
        button.Activated += (sender, args) => GiveAmmo();
        GiveAmmoList.Add(button);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        GiveAmmoList.Add(returnButton);

        var mainMenu = new Menu("Ammunition List", GiveAmmoList.ToArray());
        DrawMenu(mainMenu);
    }
    void GiveAmmo()
    {
        player.Weapons.Current.Ammo += 60;
    }
    void TelekenisisAmmoVoid()
    {
    }
    
}
