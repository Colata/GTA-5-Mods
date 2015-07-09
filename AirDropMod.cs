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

    //ACTIVATION BOOL
    bool Airdrop1Active = true;

    //AIDROP TITAN SPAWN
    GTA.Math.Vector3 TitanSpawn1 = new Vector3(400.5117f, -400.2867f, 180.6868f);

    //AIRDROP TITAN DESTINATION
    GTA.Math.Vector3 Titan1Destination1 = new Vector3(196.5117f, -932.2867f, 120.6868f);
    GTA.Math.Vector3 Titan1Destination2 = new Vector3(-0.5117f, -1332.2867f, 180.6868f);

    //AIRDROP LOCATIONS
    GTA.Math.Vector3 Airdrop1 = new Vector3(196.5117f, -932.2867f, 30.6868f);

    public AirDropMod()
    {
        Tick += AirDropTick;

        Blip AirDrop1Blip = World.CreateBlip(Airdrop1, 2);
        {
            AirDrop1Blip.Sprite = BlipSprite.CrateDrop;
            AirDrop1Blip.Scale = 125f;
        }
    }

    public void AirDropTick(object sender, EventArgs e)
    {
        //Airdrop - to - player calculation
        float playerToAirdropDISTANCE = World.GetDistance(player.Position, Airdrop1);

        //Airdrop Trigger
        if(playerToAirdropDISTANCE < 75f)
        {
            Airdrop1Active = true;
        }

        //AIRDROP SENQUENCE
        if(Airdrop1Active)
        {
            Vehicle Titan1 = World.CreateVehicle(VehicleHash.Titan, TitanSpawn1);
            Ped TitanDriver = World.CreateRandomPed(new Vector3()); TitanDriver.SetIntoVehicle(Titan1, VehicleSeat.Driver);
            TitanDriver.Task.DriveTo(Titan1, Titan1Destination1, 5f, 120f);
            TitanDriver.Task.DriveTo(Titan1, Titan1Destination2, 5f, 120f);
            TitanDriver.MarkAsNoLongerNeeded();
            Airdrop1Active = false;
        }

        //AIRDROP MARKERS
        Function.Call(Hash.DRAW_MARKER, 1, 196.5117f, -932.2867f, 90.6868f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 75f, 75f, 75f, 204, 204, 1, 150, false, true, 2, false, false, false, false);
    }
}
