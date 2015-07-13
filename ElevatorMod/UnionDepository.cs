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

public class UnionDepository : Script
{
    Ped player = Game.Player.Character;

    public UnionDepository()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Interval = 10;

        Blip UnionBlip = World.CreateBlip(unionElevatorBOTTOM, 2);
        {
            UnionBlip.Sprite = BlipSprite.Helicopter;
            UnionBlip.Scale = 75f;
        }
    }

    //BOTTOM Radius
    bool unionRadiusBOTTOM = false;

    //TOP Radius
    bool unionRadiusTOP = false;

    //TOP
    GTA.Math.Vector3 unionElevatorBOTTOM = new GTA.Math.Vector3(6.295846f, -709.3442f, 45.97305f);

    //BOTTOM
    GTA.Math.Vector3 unionElevatorTOP = new GTA.Math.Vector3(-2.279792f, -690.0576f, 250.4136f);


    void OnTick(object sender, EventArgs e)
    {
        //DISTANCE BOTTOM
        float unionElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, unionElevatorBOTTOM);
        //DISTANCE TOP
        float unionElevatorDistanceTOP = GTA.World.GetDistance(player.Position, unionElevatorTOP);

        //ACTIVATE BOTTOM
        if (unionElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Union Depository");
            unionRadiusBOTTOM = true;
        }
        else
        {
            unionRadiusBOTTOM = false;
        }
        //ACTIVATE TOP
        if (unionElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the Union Depository");
            unionRadiusTOP = true;
        }
        else
        {
            unionRadiusTOP = false;
        }
    }

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        //TOP TELEPORT
        if (unionRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = unionElevatorTOP; //TOP CORDS
            }
        }
        //BOTTOM TELEPORT
        if (unionRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F)
            {
                Game.Player.Character.Position = unionElevatorBOTTOM; //BOTTOM CORDS
            }
        }
    }
}