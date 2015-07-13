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

public class ArcadiusBusinessCenter : Script
{
    Ped player = Game.Player.Character;

    public ArcadiusBusinessCenter()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Interval = 10;

        Blip arcadiusBusinessCentreBlip = World.CreateBlip(arcadiusBusinessCentreElevatorBOTTOM, 2);
        {
            arcadiusBusinessCentreBlip.Sprite = BlipSprite.Helicopter;
            arcadiusBusinessCentreBlip.Scale = 75f;
        }
    }

    //BOTTOM Radius
    bool arcadiusBusinessCentreRadiusBOTTOM = false;

    //TOP Radius
    bool arcadiusBusinessCentreRadiusTOP = false;

    //TOP
    GTA.Math.Vector3 arcadiusBusinessCentreElevatorBOTTOM = new GTA.Math.Vector3(-147.3193f, -578.701f, 48.23539f);

    //BOTTOM
    GTA.Math.Vector3 arcadiusBusinessCentreElevatorTOP = new GTA.Math.Vector3(-133.4699f, -584.0259f, 201.7353f);


    void OnTick(object sender, EventArgs e)
    {
        //DISTANCE BOTTOM
        float arcadiusBusinessCentreElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, arcadiusBusinessCentreElevatorBOTTOM);
        //DISTANCE TOP
        float arcadiusBusinessCentreElevatorDistanceTOP = GTA.World.GetDistance(player.Position, arcadiusBusinessCentreElevatorTOP);

        //ACTIVATE BOTTOM
        if (arcadiusBusinessCentreElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Arcadius Business Centre");
            arcadiusBusinessCentreRadiusTOP = true;
        }
        else
        {
            arcadiusBusinessCentreRadiusTOP = false;
        }
        //ACTIVATE TOP
        if (arcadiusBusinessCentreElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the Arcadius Business Centre");
            arcadiusBusinessCentreRadiusBOTTOM = true;
        }
        else
        {
            arcadiusBusinessCentreRadiusBOTTOM = false;
        }
    }

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        //TOP TELEPORT
        if (arcadiusBusinessCentreRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = arcadiusBusinessCentreElevatorBOTTOM; //BOTTOM CORDS           
            }
        }
        //BOTTOM TELEPORT
        if (arcadiusBusinessCentreRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = arcadiusBusinessCentreElevatorTOP; //TOP CORDS
            }
        }
    }
}