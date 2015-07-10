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
using System.IO;

partial class AirDropMod : Script
{
    Ped player = Game.Player.Character;

    List<Ped> group_members = new List<Ped>();

    GTA.Math.Vector3 LOSSANTOSSQUARE = new Vector3(194.9678f, -933.614f, 30.68681f);
    
    public AirDropMod()
    {
        Tick += OnTick;

        Blip AirDrop1Blip = World.CreateBlip(LOSSANTOSSQUARE, 2);
        {
            AirDrop1Blip.Sprite = BlipSprite.CrateDrop;
            AirDrop1Blip.Scale = 100f;
        }

        int objectHash = Function.Call<int>(Hash.GET_HASH_KEY, "prop_crashed_heli");
        GTA.Model objectModel = new GTA.Model(objectHash);
        if (!objectModel.IsLoaded)
        {
            objectModel.Request(500);
            while (!objectModel.IsLoaded)
            {
                Wait(0);
            }
        }
        Function.Call(Hash.CREATE_OBJECT, objectModel, 194.9678f, -933.614f, 30.68681f, false, true, false);
        objectModel.MarkAsNoLongerNeeded();
    }

    public void OnTick(object sender, EventArgs e)
    {
        float AirDropEnemyRadius = World.GetDistance(player.Position, LOSSANTOSSQUARE);

        if (AirDropEnemyRadius < 75f && group_members.Count < 5f)
        {
            List<Vector3> AirDropAIspawns = new List<Vector3>();
            AirDropAIspawns.Add(new Vector3(190.33f, -930.9129f, 30.68681f));
            AirDropAIspawns.Add(new Vector3(189.0866f, -933.7166f, 30.68681f));
            AirDropAIspawns.Add(new Vector3(190.7581f, -938.2358f, 30.69109f));
            AirDropAIspawns.Add(new Vector3(196.5814f, -939.5245f, 30.6868f));
            AirDropAIspawns.Add(new Vector3(201.2327f, -936.3722f, 30.6868f));

            List<string> model_names = new List<string>();
            model_names.Add("S_M_Y_MARINE_01");
            model_names.Add("S_M_Y_MARINE_02");
            model_names.Add("S_M_Y_MARINE_03");
            model_names.Add("S_M_M_MARINE_01");
            model_names.Add("S_M_Y_ArmyMech_01");
            model_names.Add("S_M_M_Marine_02");

            Random RND = new Random();
            Ped Enemy = World.CreatePed(model_names[RND.Next(0, 6)], AirDropAIspawns[RND.Next(0, 4)]);
            group_members.Add(Enemy);

            int Enemies = Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Enemy.Handle);
            Function.Call<int>(Hash.SET_PED_AS_GROUP_MEMBER, Enemy.Handle, Enemies);

            Enemy.Task.ShootAt(player);
            Enemy.Weapons.Give(WeaponHash.CombatPDW, 120, true, true);
            Enemy.Accuracy = 0;
            if(player.IsDead)
            {
                Enemy.MarkAsNoLongerNeeded();
            }
            if(Enemy.IsDead)
            {
                Enemy.MarkAsNoLongerNeeded();
            }
        }
        if(AirDropEnemyRadius < 5f && group_members.Count < 1)
        {
            SupplyMenu();
        }
        else
        {
            View.CloseAllMenus();
        }
    }

    private void DrawMenu(GTA.Menu mainMenu)
    {
        //ALPHA , RED , GREEN , BLUE

        // Header Layout
        MainMenu.HeaderCentered = true;
        MainMenu.HeaderHeight += 5;
        MainMenu.HeaderTextScale = 0.64f;
        MainMenu.HeaderFont = GTA.Font.ChaletComprimeCologne;
        MainMenu.HeaderColor = System.Drawing.Color.FromArgb(175, 51, 153, 255);

        // Items Layout
        MainMenu.ItemTextCentered = true;
        MainMenu.ItemHeight -= 7;
        MainMenu.ItemTextScale = 0.32f;
        MainMenu.SelectedItemColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
        MainMenu.UnselectedItemColor = System.Drawing.Color.FromArgb(80, 230, 230, 230);
        MainMenu.SelectedTextColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
        MainMenu.UnselectedTextColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);

        // Footer Layout
        MainMenu.HasFooter = true;
        MainMenu.FooterColor = System.Drawing.Color.FromArgb(175, 51, 153, 255);
        MainMenu.FooterHeight += -17;
        MainMenu.FooterTextScale = 0.50f;
        MainMenu.FooterTextColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
        MainMenu.FooterFont = GTA.Font.ChaletComprimeCologne;
        MainMenu.FooterCentered = true;

        View.MenuPosition = new System.Drawing.Point(35, 20);
        View.AddMenu(MainMenu);
    }

    void SupplyMenu()
    {
        List<IMenuItem> WeaponMenuList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Weapons");
        button.Activated += (sender, args) => Exit();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("Health & Armour");
        button.Activated += (sender, args) => Exit();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("Food & Supplies");
        button.Activated += (sender, args) => Exit();
        WeaponMenuList.Add(button);

        button = new GTA.MenuButton("Return");
        button.Activated += (sender, args) => Exit();
        WeaponMenuList.Add(button);

        var mainMenu = new Menu("Weapon Menu", WeaponMenuList.ToArray());
        DrawMenu(mainMenu);
    }

    public void Return()
    {
        View.HandleBack();
    }

    public void Exit()
    {
        View.CloseAllMenus();
    }
}
