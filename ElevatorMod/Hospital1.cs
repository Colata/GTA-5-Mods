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

public class Hospital1 : Script
{
    Ped player = Game.Player.Character;

    public Hospital1()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Interval = 10;

        Blip Hospital1Blip = World.CreateBlip(hospital1ElevatorBOTTOM, 2);
        {
            Hospital1Blip.Sprite = BlipSprite.Helicopter;
            Hospital1Blip.Scale = 75f;
        }
    }

    //BOTTOM Radius
    bool hospital1RadiusBOTTOM = false;

    //TOP Radius
    bool hospital1RadiusTOP = false;

    //TOP
    GTA.Math.Vector3 hospital1ElevatorBOTTOM = new GTA.Math.Vector3(360.2171f, -584.9374f, 28.8215f);

    //BOTTOM
    GTA.Math.Vector3 hospital1ElevatorTOP = new GTA.Math.Vector3(340.2888f, -584.173f, 74.1657f);


    void OnTick(object sender, EventArgs e)
    {
        //DISTANCE BOTTOM
        float hospital1ElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, hospital1ElevatorBOTTOM);
        //DISTANCE TOP
        float hospital1ElevatorDistanceTOP = GTA.World.GetDistance(player.Position, hospital1ElevatorTOP);

        //ACTIVATE BOTTOM
        if (hospital1ElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Hospital");
            hospital1RadiusTOP = true;
        }
        else
        {
            hospital1RadiusTOP = false;
        }
        //ACTIVATE TOP
        if (hospital1ElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the Hospital");
            hospital1RadiusBOTTOM = true;
        }
        else
        {
            hospital1RadiusBOTTOM = false;
        }
    }

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        //TOP TELEPORT
        if (hospital1RadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = hospital1ElevatorBOTTOM; //BOTTOM CORDS           
            }
        }
        //BOTTOM TELEPORT
        if (hospital1RadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = hospital1ElevatorTOP; //TOP CORDS
            }
        }
    }
}