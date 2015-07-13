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

public class FIB : Script
{
    Ped player = Game.Player.Character;

    public FIB()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Interval = 10;
  
        Blip FIBBlip = World.CreateBlip(fibElevatorBOTTOM, 2);
        {
            FIBBlip.Sprite = BlipSprite.Helicopter;
            FIBBlip.Scale = 75f;
        }
    }

    //BOTTOM Radius
    bool fibRadiusBOTTOM = false;

    //TOP Radius
    bool fibRadiusTOP = false;

    //TOP
    GTA.Math.Vector3 fibElevatorBOTTOM = new GTA.Math.Vector3(99.49534f, -743.5652f, 45.75476f);

    //BOTTOM
    GTA.Math.Vector3 fibElevatorTOP = new GTA.Math.Vector3(132.4646f, -726.3422f, 258.1525f);


    void OnTick(object sender, EventArgs e)
    {
        //DISTANCE BOTTOM
        float fibElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, fibElevatorBOTTOM);
        //DISTANCE TOP
        float fibElevatorDistanceTOP = GTA.World.GetDistance(player.Position, fibElevatorTOP);

        //ACTIVATE BOTTOM
        if (fibElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the FIB Building");
            fibRadiusBOTTOM = true;
        }
        //ACTIVATE TOP
        if (fibElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the FIB Building");
            fibRadiusTOP = true;
        }
    }

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        //TOP TELEPORT
        if (fibRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = fibElevatorTOP; //TOP CORDS
            }
        }
        //BOTTOM TELEPORT
        if (fibRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = fibElevatorBOTTOM; //BOTTOM CORDS
            }
        }
    }
}