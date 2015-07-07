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

public class Main : Script
{
    Ped player = Game.Player.Character;
    Player playerplayer = Game.Player;
    GTA.Math.Vector3 playerLoc = Function.Call<GTA.Math.Vector3>(Hash.GET_ENTITY_COORDS, Game.Player, 1);
    GTA.Math.Vector3 Elevator1 = new GTA.Math.Vector3(-346.4626f, -822.6212f, 31.53736f);

    public Main()
    {
        KeyUp += OnKeyUp;
    }

    bool ElevatorRange = false;

    private void OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F10)
        {
            float x = Game.Player.Character.Position.X;
            float y = Game.Player.Character.Position.Y;
            float z = Game.Player.Character.Position.Z;
            string GetZoneName = Function.Call<string>(Hash.GET_NAME_OF_ZONE, x, y, z);
            Logger.Log(string.Format("Zone: {0}\t{1}", GetZoneName, Game.Player.Character.Position.ToString()));
            UI.Notify("Log Updated");
        }
    }

    private void OnTick(object sender, EventArgs e)
    {

        if (player.IsDead)
            View.CloseAllMenus();

        Blip ElevatorBlip = World.CreateBlip(Elevator1, 3);
        World.DrawMarker(MarkerType.VerticalCylinder, Elevator1, Vector3.WorldNorth, Vector3.WorldNorth, Vector3.RelativeFront, Color.Yellow);
    }

    //MENUS
    private void DrawMenu(GTA.Menu MainMenu)
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
    void foodMenu()
    {
        List<IMenuItem> mainMenuList = new List<IMenuItem>();

        var cruiseControl = new GTA.MenuButton("Cruise Control", "Take your foot of the pedal!");
        cruiseControl.Activated += (sender, args) =>
        {
            if(player.IsInVehicle() && player.IsAlive)
            {
                float vehSpeed = Function.Call<float>(Hash.GET_ENTITY_SPEED, player);
                player.CurrentVehicle.Speed = vehSpeed;
            }
            else
            {
                UI.ShowSubtitle("You must be in a vehicle to enable Cruise Control", 5000);
            }
        };
        mainMenuList.Add(cruiseControl);        

        var ExitButton = new GTA.MenuButton("Exit", "Return to the game!");
        ExitButton.Activated += (sender, args) => Exit();
        mainMenuList.Add(ExitButton);

        var MainMenu = new GTA.Menu("Main Menu", mainMenuList.ToArray());

        DrawMenu(MainMenu);
    }
    //MENUS

    void Starving()
    {
    }
    void Full()
    {
        Function.Call(Hash._SET_PLAYER_HEALTH_REGENERATION_RATE, Game.Player.Character, 10);
    }

    void PreviousMenu()
    {
        View.HandleBack();
    }
    void Exit()
    {
        View.CloseAllMenus();
    }
}
