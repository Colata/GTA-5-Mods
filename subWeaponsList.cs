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
    void meleeList()
    {
        List<MenuButton> listItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in melee)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => giveWeapon(button, weapon);
            listItems.Add(button);
        }
        ListMenu list1 = new ListMenu("Weapon List", listItems.ToArray(), 10);
        DrawMenu(list1);
    }

    void pistolList()
    {
        List<MenuButton> listItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in pistols)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => giveWeapon(button, weapon);
            listItems.Add(button);
        }
        ListMenu list1 = new ListMenu("Weapon List", listItems.ToArray(), 10);
        DrawMenu(list1);
    }
    void SMGList()
    {
        List<MenuButton> listItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in smg)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => giveWeapon(button, weapon);
            listItems.Add(button);
        }
        ListMenu list1 = new ListMenu("Weapon List", listItems.ToArray(), 10);
        DrawMenu(list1);
    }

    void heavyList()
    {
        List<MenuButton> listItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in heavy)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => giveWeapon(button, weapon);
            listItems.Add(button);
        }
        ListMenu list1 = new ListMenu("Weapon List", listItems.ToArray(), 10);
        DrawMenu(list1);
    }

    void shotgunList()
    {
        List<MenuButton> listItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in shotgun)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => giveWeapon(button, weapon);
            listItems.Add(button);
        }
        ListMenu list1 = new ListMenu("Weapon List", listItems.ToArray(), 10);
        DrawMenu(list1);
    }

    void rifleList()
    {
        List<MenuButton> listItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in rifle)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => giveWeapon(button, weapon);
            listItems.Add(button);
        }
        ListMenu list1 = new ListMenu("Weapon List", listItems.ToArray(), 10);
        DrawMenu(list1);
    }

    void mgList()
    {
        List<MenuButton> listItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in machineGun)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => giveWeapon(button, weapon);
            listItems.Add(button);
        }
        ListMenu list1 = new ListMenu("Weapon List", listItems.ToArray(), 10);
        DrawMenu(list1);
    }

    void sniperList()
    {
        List<MenuButton> listItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in sniper)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => giveWeapon(button, weapon);
            listItems.Add(button);
        }
        ListMenu list1 = new ListMenu("Weapon List", listItems.ToArray(), 10);
        DrawMenu(list1);
    }

    void thrownList()
    {
        List<MenuButton> listItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in thrown)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => giveWeapon(button, weapon);
            listItems.Add(button);
        }
        ListMenu list1 = new ListMenu("Weapon List", listItems.ToArray(), 10);
        DrawMenu(list1);
    }

    void giveWeapon(MenuButton sender, KeyValuePair<WeaponHash, int> weapon)
    {
        {
            Game.Player.Character.Weapons.Give(weapon.Key, 9999, true, true);
            UI.Notify("Item Action", true);
        }
    }
}
