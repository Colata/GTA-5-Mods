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
    private void WeaponMenu()
    {
        List<IMenuItem> WeaponMenuList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Melee List");
        button.Activated += (sender, args) => Melee();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("Pistol List");
        button.Activated += (sender, args) => Pistol();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("SMG List");
        button.Activated += (sender, args) => SMG();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("Shotgun List");
        button.Activated += (sender, args) => Shotgun();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("Rifle List");
        button.Activated += (sender, args) => Rifle();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("MG List");
        button.Activated += (sender, args) => MG();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("Sniper List");
        button.Activated += (sender, args) => Sniper();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("Heavy List");
        button.Activated += (sender, args) => Heavy();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("Thrown List");
        button.Activated += (sender, args) => Thrown();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("Return");
        button.Activated += (sender, args) => PreviousMenu();
        WeaponMenuList.Add(button);

        var mainMenu = new Menu("Weapon Menu", WeaponMenuList.ToArray());
        DrawMenu(mainMenu);
    }
    
    void Melee()
    {
        List<MenuButton> meleeMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in melee)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => GiveWeapon(button, weapon);
            meleeMenuItems.Add(button);
        }

        var button1 = new GTA.MenuButton("Return");
        button1.Activated += (sender, args) => PreviousMenu();
        meleeMenuItems.Add(button1);

        ListMenu MainMenu = new ListMenu("Melee Weapons", meleeMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    } 
    void Pistol()
    {
        List<MenuButton> pistolMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in pistols)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => GiveWeapon(button, weapon);
            pistolMenuItems.Add(button);
        }

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        pistolMenuItems.Add(returnButton);

        ListMenu MainMenu = new ListMenu("Pistols", pistolMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void SMG()
    {
        List<MenuButton> smgMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in smg)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => GiveWeapon(button, weapon);
            smgMenuItems.Add(button);
        }

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        smgMenuItems.Add(returnButton);

        ListMenu MainMenu = new ListMenu("SMGs", smgMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void Shotgun()
    {
        List<MenuButton> shotgunMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in shotgun)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => GiveWeapon(button, weapon);
            shotgunMenuItems.Add(button);
        }

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        shotgunMenuItems.Add(returnButton);

        ListMenu MainMenu = new ListMenu("Shotguns", shotgunMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void Rifle()
    {
        List<MenuButton> rifleMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in rifle)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => GiveWeapon(button, weapon);
            rifleMenuItems.Add(button);
        }

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        rifleMenuItems.Add(returnButton);

        ListMenu MainMenu = new ListMenu("Rifles", rifleMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void Heavy()
    {
        List<MenuButton> heavyMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in heavy)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => GiveWeapon(button, weapon);
            heavyMenuItems.Add(button);
        }

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        heavyMenuItems.Add(returnButton);

        ListMenu MainMenu = new ListMenu("Heavy", heavyMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void MG()
    {
        List<MenuButton> mgMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in machineGun)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => GiveWeapon(button, weapon);
            mgMenuItems.Add(button);
        }

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        mgMenuItems.Add(returnButton);

        ListMenu MainMenu = new ListMenu("Machine Guns", mgMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void Sniper()
    {
        List<MenuButton> sniperMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in sniper)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => GiveWeapon(button, weapon);
            sniperMenuItems.Add(button);
        }

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        sniperMenuItems.Add(returnButton);

        ListMenu MainMenu = new ListMenu("Snipers", sniperMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void Thrown()
    {
        List<MenuButton> thrownMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<WeaponHash, int> weapon in thrown)
        {
            var button = new GTA.MenuButton(weapon.Key.ToString());
            button.Activated += (sender, args) => GiveWeapon(button, weapon);
            thrownMenuItems.Add(button);
        }

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        thrownMenuItems.Add(returnButton);

        ListMenu MainMenu = new ListMenu("Thrown", thrownMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    
    void GiveWeapon(MenuButton sender, KeyValuePair<WeaponHash, int> weapon)
    {        
        {
            Game.Player.Character.Weapons.Give(weapon.Key, 120, true, true);
            UI.Notify("Weapon Given!", true);
        }
    }

    Dictionary<WeaponHash, int> melee = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.Bat, 1}, {WeaponHash.Knife, 1}, {WeaponHash.Nightstick, 1}, {WeaponHash.Crowbar, 1}, {WeaponHash.GolfClub, 1}, {WeaponHash.Hammer, 1}, {WeaponHash.Dagger, 1}, {WeaponHash.Hatchet, 1},
        
    };

    Dictionary<WeaponHash, int> pistols = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.Pistol, 1}, {WeaponHash.CombatPistol, 1}, {WeaponHash.APPistol, 1}, {WeaponHash.Pistol50, 1}, {WeaponHash.StunGun, 1}, {WeaponHash.HeavyPistol, 1}, {WeaponHash.SNSPistol, 1}, {WeaponHash.VintagePistol, 1}, {WeaponHash.Firework, 1}, 
        
    };

    Dictionary<WeaponHash, int> smg = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.MicroSMG, 1}, {WeaponHash.SMG, 1}, {WeaponHash.AssaultSMG, 1}, {WeaponHash.CombatPDW, 1}, 
        
    };

    Dictionary<WeaponHash, int> shotgun = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.PumpShotgun, 1}, {WeaponHash.SawnOffShotgun, 1}, {WeaponHash.AssaultShotgun, 1}, {WeaponHash.BullpupShotgun, 1}, {WeaponHash.HeavyShotgun, 1}, {WeaponHash.Musket, 1},
        
    };

    Dictionary<WeaponHash, int> rifle = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.AssaultRifle, 1}, {WeaponHash.CarbineRifle, 1}, {WeaponHash.AdvancedRifle, 1}, {WeaponHash.SpecialCarbine, 1}, {WeaponHash.BullpupRifle, 1},
        
    };

    Dictionary<WeaponHash, int> machineGun = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.Gusenberg, 1}, {WeaponHash.CombatMG, 1}, {WeaponHash.MG, 1},
        
    };

    Dictionary<WeaponHash, int> sniper = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.SniperRifle, 1}, {WeaponHash.HeavySniper, 1},  {WeaponHash.MarksmanRifle, 1},
        
    };

    Dictionary<WeaponHash, int> heavy = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.RPG, 1}, {WeaponHash.GrenadeLauncher, 1}, {WeaponHash.Minigun, 1}, {WeaponHash.Firework, 1}, {WeaponHash.Railgun, 1}, {WeaponHash.HomingLauncher, 1},
        
    };

    Dictionary<WeaponHash, int> thrown = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.StickyBomb, 1}, {WeaponHash.Grenade, 1}, {WeaponHash.SmokeGrenade, 1}, {WeaponHash.Molotov, 1}, {WeaponHash.ProximityMine, 1}, {WeaponHash.Snowball, 1}, {WeaponHash.PetrolCan, 1},
        
    };
}
