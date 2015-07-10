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

public class IAA : Script
{
    Ped player = Game.Player.Character;

    public IAA()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Interval = 10;

        Blip IAABlip = World.CreateBlip(iaaElevatorBOTTOM, 2);
        {
            IAABlip.Sprite = BlipSprite.Helicopter;
            IAABlip.Scale = 75f;
        }
    }

    //BOTTOM Radius
    bool iaaRadiusBOTTOM = false;

    //TOP Radius
    bool iaaRadiusTOP = false;

    //TOP
    GTA.Math.Vector3 iaaElevatorBOTTOM = new GTA.Math.Vector3(105.3145f, -625.6478f, 44.22019f);

    //BOTTOM
    GTA.Math.Vector3 iaaElevatorTOP = new GTA.Math.Vector3(108.269f, -640.4637f, 258.1489f);


    void OnTick(object sender, EventArgs e)
    {
        //DISTANCE BOTTOM
        float iaaElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, iaaElevatorBOTTOM);
        //DISTANCE TOP
        float iaaElevatorDistanceTOP = GTA.World.GetDistance(player.Position, iaaElevatorTOP);

        //ACTIVATE BOTTOM
        if (iaaElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the IAA Building");
            iaaRadiusBOTTOM = true;
        }
        //ACTIVATE TOP
        if (iaaElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the IAA Building");
            iaaRadiusTOP = true;
        }
    }

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        //TOP TELEPORT
        if (iaaRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = iaaElevatorTOP; //TOP CORDS
            }
        }
        //BOTTOM TELEPORT
        if (iaaRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = iaaElevatorBOTTOM; //BOTTOM CORDS
            }
        }
    }
}