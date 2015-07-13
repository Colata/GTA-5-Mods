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

public class RichardsMajestic : Script
{
    Ped player = Game.Player.Character;

    public RichardsMajestic()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Interval = 10;

        Blip richardsMajesticBlip = World.CreateBlip(richardsMajesticElevatorBOTTOM, 2);
        {
            richardsMajesticBlip.Sprite = BlipSprite.Helicopter;
            richardsMajesticBlip.Scale = 75f;
        }
    }

    //BOTTOM Radius
    bool richardsMajesticRadiusBOTTOM = false;

    //TOP Radius
    bool richardsMajesticCentreRadiusTOP = false;

    //TOP
    GTA.Math.Vector3 richardsMajesticElevatorBOTTOM = new GTA.Math.Vector3(-933.8727f, -384.1257f, 38.96134f);

    //BOTTOM
    GTA.Math.Vector3 richardsMajesticElevatorTOP = new GTA.Math.Vector3(-903.6141f, -370.357f, 136.2822f);


    void OnTick(object sender, EventArgs e)
    {
        //DISTANCE BOTTOM
        float richardsMajesticElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, richardsMajesticElevatorBOTTOM);
        //DISTANCE TOP
        float richardsMajesticCentreElevatorDistanceTOP = GTA.World.GetDistance(player.Position, richardsMajesticElevatorTOP);

        //ACTIVATE BOTTOM
        if (richardsMajesticElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of Richards Majestic");
            richardsMajesticCentreRadiusTOP = true;
        }
        else
        {
            richardsMajesticCentreRadiusTOP = false;
        }
        //ACTIVATE TOP
        if (richardsMajesticCentreElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of Richards Majestic");
            richardsMajesticRadiusBOTTOM = true;
        }
        else
        {
            richardsMajesticRadiusBOTTOM = false;
        }
    }

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        //TOP TELEPORT
        if (richardsMajesticRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = richardsMajesticElevatorBOTTOM; //BOTTOM CORDS           
            }
        }
        //BOTTOM TELEPORT
        if (richardsMajesticCentreRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = richardsMajesticElevatorTOP; //TOP CORDS
            }
        }
    }
}