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

public partial class Mod : Script
{
    void superList()
    {
        List<MenuButton> superMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in SuperVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            superMenuItems.Add(button);
        }

   
        ListMenu MainMenu = new ListMenu("Super Cars", superMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void motorcycleList()
    {
        List<MenuButton> motorcycleMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in motorCycleVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            motorcycleMenuItems.Add(button);
        }


        ListMenu MainMenu = new ListMenu("MotorCycles", motorcycleMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void compactList()
    {
        List<MenuButton> compactMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in compactVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            compactMenuItems.Add(button);
        }



        ListMenu MainMenu = new ListMenu("Compact Cars", compactMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void coupeList()
    {
        List<MenuButton> coupeMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in coupeVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            coupeMenuItems.Add(button);
        }



        ListMenu MainMenu = new ListMenu("Coupe Cars", coupeMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void sedanList()
    {
        List<MenuButton> sedanMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in sedanVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            sedanMenuItems.Add(button);
        }



        ListMenu MainMenu = new ListMenu("Sedan Cars", sedanMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void sportList()
    {
        List<MenuButton> sportMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in sportsVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            sportMenuItems.Add(button);
        }


        ListMenu MainMenu = new ListMenu("Sport Cars", sportMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void sportclassicList()
    {
        List<MenuButton> sportClassicMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in sportClassicVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            sportClassicMenuItems.Add(button);
        }



        ListMenu MainMenu = new ListMenu("Sport Classic Cars", sportClassicMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void muscleList()
    {
        List<MenuButton> muscleMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in muscleVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            muscleMenuItems.Add(button);
        }

  

        ListMenu MainMenu = new ListMenu("Muscle Cars", muscleMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void offroadList()
    {
        List<MenuButton> offRoadMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in offroadVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            offRoadMenuItems.Add(button);
        }



        ListMenu MainMenu = new ListMenu("Off-Road Cars", offRoadMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void suvList()
    {
        List<MenuButton> suvMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in suvVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            suvMenuItems.Add(button);
        }



        ListMenu MainMenu = new ListMenu("SUVs", suvMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void vanList()
    {
        List<MenuButton> vanMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in vanVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            vanMenuItems.Add(button);
        }


        ListMenu MainMenu = new ListMenu("Vans", vanMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void industrialList()
    {
        List<MenuButton> industriaMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in industrialVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            industriaMenuItems.Add(button);
        }



        ListMenu MainMenu = new ListMenu("Industrial Vehicles", industriaMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void commercialList()
    {
        List<MenuButton> commercialMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in commercialVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            commercialMenuItems.Add(button);
        }



        ListMenu MainMenu = new ListMenu("Commercial Vehicles", commercialMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    /*
    void utilityList()
    {
        List<MenuButton> utilityMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in utilityVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            utilityMenuItems.Add(button);
        }



        ListMenu MainMenu = new ListMenu("Utility Vehicles", utilityMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    */
    void militaryList()
    {
        List<MenuButton> militaryMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in militaryVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            militaryMenuItems.Add(button);
        }



        ListMenu MainMenu = new ListMenu("Military Vehicles", militaryMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void serviceList()
    {
        List<MenuButton> serviceMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in serviceVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            serviceMenuItems.Add(button);
        }


        ListMenu MainMenu = new ListMenu("Service Vehicles", serviceMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void cycleList()
    {
        List<MenuButton> cycleMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in cycleVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            cycleMenuItems.Add(button);
        }


        ListMenu MainMenu = new ListMenu("Cycles", cycleMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void helicopterList()
    {
        List<MenuButton> helicopterMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in helicopterVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            helicopterMenuItems.Add(button);
        }

        ListMenu MainMenu = new ListMenu("Helicopters", helicopterMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }
    void planeList()
    {
        List<MenuButton> planeMenuItems = new List<MenuButton>();

        foreach (KeyValuePair<VehicleHash, int> vehicles in planeVeh)
        {
            var button = new GTA.MenuButton(vehicles.Key.ToString());
            button.Activated += (sender, args) => spawnVehicle(button, vehicles);
            planeMenuItems.Add(button);
        }

        ListMenu MainMenu = new ListMenu("Planes", planeMenuItems.ToArray(), 10);
        DrawMenu(MainMenu);
    }

    void spawnVehicle(MenuButton sender, KeyValuePair<VehicleHash, int> vehicles)
    {
        {
            GTA.Math.Vector3 spawn_vehicle = player.Position + (player.ForwardVector * 10);

            World.CreateVehicle(vehicles.Key, spawn_vehicle);
            UI.Notify("Vehicle action", true);
        }
    }

}
