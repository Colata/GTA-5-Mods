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

public class HalfConstructedBuilding : Script
{
    Ped player = Game.Player.Character;

    public HalfConstructedBuilding()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Interval = 10;

        Blip HalfConstructedBuildingBlip = World.CreateBlip(halfConstructedBuildingElevatorBOTTOM, 2);
        {
            HalfConstructedBuildingBlip.Sprite = BlipSprite.Helicopter;
            HalfConstructedBuildingBlip.Scale = 75f;
        }
    }

    //BOTTOM Radius
    bool halfConstructedBuildingRadiusBOTTOM = false;

    //TOP Radius
    bool halfConstructedBuildingRadiusTOP = false;

    //TOP
    GTA.Math.Vector3 halfConstructedBuildingElevatorBOTTOM = new GTA.Math.Vector3(-184.1684f, -1016.074f, 30.07096f);

    //BOTTOM
    GTA.Math.Vector3 halfConstructedBuildingElevatorTOP = new GTA.Math.Vector3(-159.6062f, -944.0149f, 269.218f);


    void OnTick(object sender, EventArgs e)
    {
        //DISTANCE BOTTOM
        float halfConstructedBuildingElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, halfConstructedBuildingElevatorBOTTOM);
        //DISTANCE TOP
        float halfConstructedBuildingElevatorDistanceTOP = GTA.World.GetDistance(player.Position, halfConstructedBuildingElevatorTOP);

        //ACTIVATE BOTTOM
        if (halfConstructedBuildingElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Building");
            halfConstructedBuildingRadiusBOTTOM = true;
        }
        else
        {
            halfConstructedBuildingRadiusBOTTOM = false;
        }
        //ACTIVATE TOP
        if (halfConstructedBuildingElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Building");
            halfConstructedBuildingRadiusTOP = true;
        }
        else
        {
            halfConstructedBuildingRadiusTOP = false;
        }
    }

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        //TOP TELEPORT
        if (halfConstructedBuildingRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = halfConstructedBuildingElevatorTOP; //TOP CORDS
            }
        }
        //BOTTOM TELEPORT
        if (halfConstructedBuildingRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = halfConstructedBuildingElevatorBOTTOM; //BOTTOM CORDS
            }
        }
    }
}