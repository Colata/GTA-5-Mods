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

public class MazeBank : Script
{
    Ped player = Game.Player.Character;

    public MazeBank()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Interval = 10;

        Blip MazeBankBlip = World.CreateBlip(mazeBankElevatorBOTTOM, 2);
        {
            MazeBankBlip.Sprite = BlipSprite.Helicopter;
            MazeBankBlip.Scale = 75f;
        }
    }

    //BOTTOM Radius
    bool mazeBankRadiusBOTTOM = false;

    //TOP Radius
    bool mazeBankRadiusTOP = false;

    //TOP
    GTA.Math.Vector3 mazeBankElevatorBOTTOM = new GTA.Math.Vector3(-59.82701f, -790.3538f, 44.22732f);

    //BOTTOM
    GTA.Math.Vector3 mazeBankElevatorTOP = new GTA.Math.Vector3(-66.43941f, -822.1783f, 321.2873f);


    void OnTick(object sender, EventArgs e)
    {
        //DISTANCE BOTTOM
        float MazeBankElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, mazeBankElevatorBOTTOM);
        //DISTANCE TOP
        float MazeBankElevatorDistanceTOP = GTA.World.GetDistance(player.Position, mazeBankElevatorTOP);

        //ACTIVATE BOTTOM
        if (MazeBankElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Maze Bank");
            mazeBankRadiusBOTTOM = true;
        }
        else
        {
            mazeBankRadiusBOTTOM = false;
        }
        //ACTIVATE TOP
        if (MazeBankElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the Maze Bank");
            mazeBankRadiusTOP = true;
        }
        else
        {
            mazeBankRadiusTOP = false;
        }
    }  

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        //TOP TELEPORT
        if (mazeBankRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = mazeBankElevatorTOP; //TOP CORDS
            }
        }
        //BOTTOM TELEPORT
        if (mazeBankRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = mazeBankElevatorBOTTOM; //BOTTOM CORDS
            }
        }
    }
}
