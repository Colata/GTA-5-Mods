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


public class ArcadiusBusinessCentreHeliPad : Script
{
    Ped player = Game.Player.Character;

    GTA.Math.Vector3 arcadiusBusinessCentreHeli = new Vector3(-144.9154f, -593.8792f, 211.7753f);
    GTA.Math.Vector3 arcadiusBusinessCentreHeliTrigger = new Vector3(-140.8396f, -588.3941f, 211.7753f);

    bool arcadiusBusinessCentreHeliBool = false;

    public ArcadiusBusinessCentreHeliPad()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Interval = 1;

    }

    void OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.E && arcadiusBusinessCentreHeliBool)
        {
            HeliMenu();
        }
    }

    void OnTick(object sender, EventArgs e)
    {
        float mazeBankHeliRadius = GTA.World.GetDistance(player.Position, arcadiusBusinessCentreHeliTrigger);

        if (mazeBankHeliRadius < 1.5f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press E to open the helicopter menu");
            arcadiusBusinessCentreHeliBool = true;
        }
        else
        {
            arcadiusBusinessCentreHeliBool = false;
            Exit();
        }
    }

    void HeliMenu()
    {
        List<IMenuItem> helicopterMenuItems = new List<IMenuItem>();

        var annihilator = new MenuButton("Annihilator");
        annihilator.Activated += (sender, args) =>
        {
            Vehicle[] nearbyVeh = World.GetNearbyVehicles(Game.Player.Character, 20.0f);
            foreach (Vehicle vehicle in nearbyVeh)
            {
                vehicle.Delete();
            }
            World.CreateVehicle(VehicleHash.Annihilator, arcadiusBusinessCentreHeli);
        };
        helicopterMenuItems.Add(annihilator);

        var buzzard = new MenuButton("Buzzard");
        buzzard.Activated += (sender, args) =>
        {
            Vehicle[] nearbyVeh = World.GetNearbyVehicles(Game.Player.Character, 20.0f);
            foreach (Vehicle vehicle in nearbyVeh)
            {
                vehicle.Delete();
            }
            World.CreateVehicle(VehicleHash.Buzzard, arcadiusBusinessCentreHeli);
        };
        helicopterMenuItems.Add(buzzard);

        var buzzard2 = new MenuButton("Buzzard 2");
        buzzard2.Activated += (sender, args) =>
        {
            Vehicle[] nearbyVeh = World.GetNearbyVehicles(Game.Player.Character, 20.0f);
            foreach (Vehicle vehicle in nearbyVeh)
            {
                vehicle.Delete();
            }
            World.CreateVehicle(VehicleHash.Buzzard2, arcadiusBusinessCentreHeli);
        };
        helicopterMenuItems.Add(buzzard2);

        var carboBob = new MenuButton("CargoBob");
        carboBob.Activated += (sender, args) =>
        {
            Vehicle[] nearbyVeh = World.GetNearbyVehicles(Game.Player.Character, 20.0f);
            foreach (Vehicle vehicle in nearbyVeh)
            {
                vehicle.Delete();
            }
            World.CreateVehicle(VehicleHash.Cargobob, arcadiusBusinessCentreHeli);
        };
        helicopterMenuItems.Add(carboBob);

        var frogger = new MenuButton("Frogger");
        frogger.Activated += (sender, args) =>
        {
            Vehicle[] nearbyVeh = World.GetNearbyVehicles(Game.Player.Character, 20.0f);
            foreach (Vehicle vehicle in nearbyVeh)
            {
                vehicle.Delete();
            }
            World.CreateVehicle(VehicleHash.Frogger, arcadiusBusinessCentreHeli);
        };
        helicopterMenuItems.Add(frogger);

        var maverick = new MenuButton("Maverick");
        maverick.Activated += (sender, args) =>
        {
            Vehicle[] nearbyVeh = World.GetNearbyVehicles(Game.Player.Character, 20.0f);
            foreach (Vehicle vehicle in nearbyVeh)
            {
                vehicle.Delete();
            }
            World.CreateVehicle(VehicleHash.Maverick, arcadiusBusinessCentreHeli);
        };
        helicopterMenuItems.Add(maverick);

        var savage = new MenuButton("Savage");
        savage.Activated += (sender, args) =>
        {
            Vehicle[] nearbyVeh = World.GetNearbyVehicles(Game.Player.Character, 20.0f);
            foreach (Vehicle vehicle in nearbyVeh)
            {
                vehicle.Delete();
            }
            World.CreateVehicle(VehicleHash.Savage, arcadiusBusinessCentreHeli);
        };
        helicopterMenuItems.Add(savage);

        var skylift = new MenuButton("Skylift");
        skylift.Activated += (sender, args) =>
        {
            Vehicle[] nearbyVeh = World.GetNearbyVehicles(Game.Player.Character, 20.0f);
            foreach (Vehicle vehicle in nearbyVeh)
            {
                vehicle.Delete();
            }
            World.CreateVehicle(VehicleHash.Skylift, arcadiusBusinessCentreHeli);
        };
        helicopterMenuItems.Add(skylift);

        var swift = new MenuButton("Swift");
        swift.Activated += (sender, args) =>
        {
            Vehicle[] nearbyVeh = World.GetNearbyVehicles(Game.Player.Character, 20.0f);
            foreach (Vehicle vehicle in nearbyVeh)
            {
                vehicle.Delete();
            }
            World.CreateVehicle(VehicleHash.Swift, arcadiusBusinessCentreHeli);
        };
        helicopterMenuItems.Add(swift);

        var swift2 = new MenuButton("Swift");
        swift2.Activated += (sender, args) =>
        {
            Vehicle[] nearbyVeh = World.GetNearbyVehicles(Game.Player.Character, 20.0f);
            foreach (Vehicle vehicle in nearbyVeh)
            {
                vehicle.Delete();
            }
            World.CreateVehicle(VehicleHash.Swift2, arcadiusBusinessCentreHeli);
        };
        helicopterMenuItems.Add(swift2);

        var valkyrie = new MenuButton("Valkyrie");
        valkyrie.Activated += (sender, args) =>
        {
            Vehicle[] nearbyVeh = World.GetNearbyVehicles(Game.Player.Character, 20.0f);
            foreach (Vehicle vehicle in nearbyVeh)
            {
                vehicle.Delete();
            }
            World.CreateVehicle(VehicleHash.Valkyrie, arcadiusBusinessCentreHeli);
        };
        helicopterMenuItems.Add(valkyrie);

        var menuLayout = new GTA.Menu("Helicopter Menu", helicopterMenuItems.ToArray());
        DrawMenu(menuLayout);
    }

    private void DrawMenu(GTA.Menu menuLayout)
    {
        //ALPHA , RED , GREEN , BLUE

        // Header Layout
        menuLayout.HeaderCentered = true;
        menuLayout.HeaderHeight += 5;
        menuLayout.HeaderTextScale = 0.64f;
        menuLayout.HeaderFont = GTA.Font.ChaletComprimeCologne;
        menuLayout.HeaderColor = System.Drawing.Color.FromArgb(175, 51, 153, 255);

        // Items Layout
        menuLayout.ItemTextCentered = true;
        menuLayout.ItemHeight -= 7;
        menuLayout.ItemTextScale = 0.32f;
        menuLayout.SelectedItemColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
        menuLayout.UnselectedItemColor = System.Drawing.Color.FromArgb(80, 230, 230, 230);
        menuLayout.SelectedTextColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
        menuLayout.UnselectedTextColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);

        // Footer Layout
        menuLayout.HasFooter = true;
        menuLayout.FooterColor = System.Drawing.Color.FromArgb(175, 51, 153, 255);
        menuLayout.FooterHeight += -17;
        menuLayout.FooterTextScale = 0.50f;
        menuLayout.FooterTextColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
        menuLayout.FooterFont = GTA.Font.ChaletComprimeCologne;
        menuLayout.FooterCentered = true;

        View.MenuPosition = new System.Drawing.Point(35, 20);
        View.AddMenu(menuLayout);
    }

    Dictionary<VehicleHash, int> helicopterVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Annihilator, 1}, {VehicleHash.Buzzard, 1}, {VehicleHash.Buzzard2, 1}, {VehicleHash.Cargobob, 1}, {VehicleHash.Frogger, 1}, {VehicleHash.Maverick, 1}, {VehicleHash.Savage, 1}, {VehicleHash.Skylift, 1}, {VehicleHash.Swift, 1}, {VehicleHash.Swift2, 1}, {VehicleHash.Valkyrie, 1},
    };

    void testvoid()
    {

    }

    public void Exit()
    {
        View.CloseAllMenus();
    }
}
