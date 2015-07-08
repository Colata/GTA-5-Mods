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
    public static Ped player = Game.Player.Character;
    bool mazeBankRadius = false;
    bool unionRadius = false;
    bool iaaRadius = false;
    bool fibRadius = false;
    
    GTA.Math.Vector3 mazeBankElevator = new GTA.Math.Vector3(-59.82701f, -790.3538f, 44.22732f);
    GTA.Math.Vector3 unionElevator = new GTA.Math.Vector3(6.295846f, -709.3442f, 45.97305f);
    GTA.Math.Vector3 iaaElevator = new GTA.Math.Vector3(105.3145f, -625.6478f, 44.22019f);
    GTA.Math.Vector3 fibElevator = new GTA.Math.Vector3(99.49534f, -743.5652f, 45.75476f);

    public Main()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Blip MazeBankBlip = World.CreateBlip(mazeBankElevator, 2);
        {
            MazeBankBlip.Sprite = BlipSprite.Helicopter;
            MazeBankBlip.Scale = 75f;
        }
        Blip UnionBlip = World.CreateBlip(unionElevator, 2);
        {
            UnionBlip.Sprite = BlipSprite.Helicopter;
            UnionBlip.Scale = 75f;
        }
        Blip IAABlip = World.CreateBlip(iaaElevator, 2);
        {
            IAABlip.Sprite = BlipSprite.Helicopter;
            IAABlip.Scale = 75f;
        }
        Blip FIBBlip = World.CreateBlip(fibElevator, 2);
        {
            FIBBlip.Sprite = BlipSprite.Helicopter;
            FIBBlip.Scale = 75f;
        }
    }

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
        if (e.KeyCode == Keys.F11)
        {
            float x = Game.Player.Character.Position.X;
            float y = Game.Player.Character.Position.Y;
            float z = Game.Player.Character.Position.Z;
            string GetZoneName = Function.Call<string>(Hash.GET_NAME_OF_ZONE, x, y, z);
            UI.ShowSubtitle(Game.Player.Character.Position.ToString(), 5000);
        }

        if (e.KeyCode == Keys.NumPad8)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X, player.Position.Y + 5, player.Position.Z);
        }
        if (e.KeyCode == Keys.NumPad2)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X, player.Position.Y - 5, player.Position.Z);
        }
        if (e.KeyCode == Keys.NumPad6)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X + 5, player.Position.Y, player.Position.Z);
        }
        if (e.KeyCode == Keys.NumPad4)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X - 5, player.Position.Y, player.Position.Z);
        }
        if (e.KeyCode == Keys.PageUp)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X, player.Position.Y, player.Position.Z + 5);
        }
        if (e.KeyCode == Keys.PageDown)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X, player.Position.Y, player.Position.Z - 5);
        }

        //MAZE BANK
        if (mazeBankRadius && !player.IsInVehicle()) 
        {
            if (e.KeyCode == Keys.F && mazeBankRadius)
            {
                Game.Player.Character.Position = new Vector3(-66.43941f, -822.1783f, 321.2873f);
            }
            if (e.KeyCode == Keys.F && mazeBankRadius && player.IsInVehicle())
            {
                UI.ShowSubtitle("You can't fit your vehicle in the elevator!");
            }
            if (e.KeyCode == Keys.F && !mazeBankRadius && !player.IsInVehicle())
            {
                UI.ShowSubtitle("Are you lost? There's no elevator around!");
            }
        }       
        //UNION DEPOSITORY
        if (unionRadius && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && unionRadius)
            {
                Game.Player.Character.Position = new Vector3(-2.279792f, -690.0576f, 250.4136f);
            }
            if (e.KeyCode == Keys.F && unionRadius && player.IsInVehicle()) 
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !unionRadius && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }
        //IAA BUILDING
        if (iaaRadius && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && iaaRadius)
            {
                Game.Player.Character.Position = new Vector3(108.269f, -640.4637f, 258.1489f);
            }
            if (e.KeyCode == Keys.F && iaaRadius && player.IsInVehicle())
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !iaaRadius && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }
        //FIB BUILDING
        if (fibRadius && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && fibRadius)
            {
                Game.Player.Character.Position = new Vector3(132.4646f, -726.3422f, 258.1525f);
            }
            if (e.KeyCode == Keys.F && fibRadius && player.IsInVehicle())
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !fibRadius && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }
    }   

    private void OnTick(object sender, EventArgs e)
    {  
        float MazeBankElevatorDistance = GTA.World.GetDistance(player.Position, mazeBankElevator);
        float unionElevatorDistance = GTA.World.GetDistance(player.Position, unionElevator);
        float iaaElevatorDistance = GTA.World.GetDistance(player.Position, iaaElevator);
        float fibElevatorDistance = GTA.World.GetDistance(player.Position, fibElevator);

        //MAZE BANK

        if (MazeBankElevatorDistance < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Maze Bank");
            mazeBankRadius = true;
        }
        else
        {
            mazeBankRadius = false;
        }

        //UNION DEPOSITORY

        if (unionElevatorDistance < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Union Depository");
            unionRadius = true;
        }
        else
        {
            unionRadius = false;
        }

        //IAA BUILDING

        if (iaaElevatorDistance < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the IAA Building");
            iaaRadius = true;
        }
        else
        {
            iaaRadius = false;
        }

        //FIB Building

        if (fibElevatorDistance < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the FIB Building");
            fibRadius = true;
        }
        else
        {
            fibRadius = false;
        }

        Interval = 10;
    }
    /*
    public static int wantedLevel
    {
        get { return Game.Player.WantedLevel; }
        set { Game.Player.WantedLevel = value; }
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
    void Menu()
    {
        List<IMenuItem> mainMenuList = new List<IMenuItem>();

        var toggle = new MenuToggle("Toggle", "This is a toggle");
        toggle.Changed += (sender, args) =>
        {
        };
        mainMenuList.Add(toggle);

        var button = new MenuButton("Button", "This is a button");
        button.Activated += (sender, args) =>
        {
            World.CreateVehicle(VehicleHash.Maverick, player.Position + (player.ForwardVector * 5));
        };
        mainMenuList.Add(button);

        var ExitButton = new GTA.MenuButton("Exit", "Return to the game!");
        ExitButton.Activated += (sender, args) => Exit();
        mainMenuList.Add(ExitButton);

        var Menu = new GTA.Menu("Main Menu", mainMenuList.ToArray());
        DrawMenu(Menu);
    }
    
    void PreviousMenu()
    {
        View.HandleBack();
    }
    void Exit()
    {
        View.CloseAllMenus();
    }
    */    
    //MENUS
}
