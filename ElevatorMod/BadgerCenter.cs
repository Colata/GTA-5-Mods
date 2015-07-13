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

public class BadgerCenter : Script
{
    Ped player = Game.Player.Character;

    public BadgerCenter()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Interval = 10;

        Blip BadgerCenterBlip = World.CreateBlip(badgerCenterElevatorBOTTOM, 2);
        {
            BadgerCenterBlip.Sprite = BlipSprite.Helicopter;
            BadgerCenterBlip.Scale = 75f;
        }
    }

    //BOTTOM Radius
    bool badgerCenterRadiusBOTTOM = false;

    //TOP Radius
    bool badgerCenterRadiusTOP = false;

    //TOP
    GTA.Math.Vector3 badgerCenterElevatorBOTTOM = new GTA.Math.Vector3(478.8547f, -107.6386f, 63.1579f);

    //BOTTOM
    GTA.Math.Vector3 badgerCenterElevatorTOP = new GTA.Math.Vector3(469.7626f, -107.6571f, 117.6346f);


    void OnTick(object sender, EventArgs e)
    {
        //DISTANCE BOTTOM
        float badgerCenterDistanceBOTTOM = GTA.World.GetDistance(player.Position, badgerCenterElevatorBOTTOM);
        //DISTANCE TOP
        float badgerCenterDistanceTOP = GTA.World.GetDistance(player.Position, badgerCenterElevatorTOP);

        //ACTIVATE BOTTOM
        if (badgerCenterDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Hospital");
            badgerCenterRadiusBOTTOM = true;
        }
        else
        {
            badgerCenterRadiusBOTTOM = false;
        }
        //ACTIVATE TOP
        if (badgerCenterDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the Hospital");
            badgerCenterRadiusTOP = true;
        }
        else
        {
            badgerCenterRadiusTOP = false;
        }
    }

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        //TOP TELEPORT
        if (badgerCenterRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = badgerCenterElevatorTOP; //TOP CORDS
            }
        }
        //BOTTOM TELEPORT
        if (badgerCenterRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = badgerCenterElevatorBOTTOM; //BOTTOM CORDS
            }
        }
    }
}