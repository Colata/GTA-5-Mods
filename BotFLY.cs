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

class BotFLY : Script
{
    Ped player = Game.Player.Character;

    public BotFLY()
    {
        KeyUp += OnKeyUp;
        Tick += OnTick;
    }

    void OnTick(object sender, EventArgs e)
    {
        Function.Call(Hash.SET_VEHICLE_DOORS_LOCKED_FOR_ALL_PLAYERS, player.CurrentVehicle);
    }

    void OnKeyUp(object sender, KeyEventArgs e)
    {
        if(e.KeyCode == Keys.F5 && player.IsInVehicle())
        {           
            player.Task.LeaveVehicle();
            Vehicle[] LastVeh = World.GetNearbyVehicles(player, 5f);
            player.Task.EnterVehicle(LastVeh.First<Vehicle>(), VehicleSeat.LeftRear);

            Wait(5000);
            
            Ped driver = World.CreateRandomPed(new Vector3());
            driver.SetIntoVehicle(LastVeh.First<Vehicle>(), VehicleSeat.Driver);
            driver.AlwaysKeepTask = true;

            Blip[] activeBlips = World.GetActiveBlips();
            Blip blip = activeBlips.FirstOrDefault(b => b.Type == 4);

            if(blip.Exists() && player.IsInVehicle(driver.CurrentVehicle))
            {
                driver.Task.DriveTo(Game.Player.Character.CurrentVehicle, new Vector3(blip.Position.X, blip.Position.Y, Game.Player.Character.Position.Z), 100.0f, 60.0f);
            }
        }
    }
}
