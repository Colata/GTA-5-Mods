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

public class Main : Script
{
    public static Ped player = Game.Player.Character;

    public Main()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;

        Blip MazeBankBlip = World.CreateBlip(mazeBankElevatorBOTTOM, 2);
        {
            MazeBankBlip.Sprite = BlipSprite.Helicopter;
            MazeBankBlip.Scale = 75f;
        }
        Blip UnionBlip = World.CreateBlip(unionElevatorBOTTOM, 2);
        {
            UnionBlip.Sprite = BlipSprite.Helicopter;
            UnionBlip.Scale = 75f;
        }
        Blip IAABlip = World.CreateBlip(iaaElevatorBOTTOM, 2);
        {
            IAABlip.Sprite = BlipSprite.Helicopter;
            IAABlip.Scale = 75f;
        }
        Blip FIBBlip = World.CreateBlip(fibElevatorBOTTOM, 2);
        {
            FIBBlip.Sprite = BlipSprite.Helicopter;
            FIBBlip.Scale = 75f;
        }
        Blip HalfConstructedBuildingBlip = World.CreateBlip(halfConstructedBuildingElevatorBOTTOM, 2);
        {
            HalfConstructedBuildingBlip.Sprite = BlipSprite.Helicopter;
            HalfConstructedBuildingBlip.Scale = 75f;
        }
        Blip Hospital1Blip = World.CreateBlip(hospital1ElevatorBOTTOM, 2);
        {
            Hospital1Blip.Sprite = BlipSprite.Helicopter;
            Hospital1Blip.Scale = 75f;
        }
    }

    //BOTTOM Radius
    bool mazeBankRadiusBOTTOM = false;
    bool unionRadiusBOTTOM = false;
    bool iaaRadiusBOTTOM = false;
    bool fibRadiusBOTTOM = false;
    bool halfConstructedBuildingRadiusBOTTOM = false;
    bool hospital1RadiusBOTTOM = false;
    //TOP Radius
    bool mazeBankRadiusTOP = false;
    bool unionRadiusTOP = false;
    bool iaaRadiusTOP = false;
    bool fibRadiusTOP = false;
    bool halfConstructedBuildingRadiusTOP = false;
    bool hospital1RadiusTOP = false;

    //BOTTOM CORDS
    GTA.Math.Vector3 mazeBankElevatorBOTTOM = new GTA.Math.Vector3(-59.82701f, -790.3538f, 44.22732f);
    GTA.Math.Vector3 unionElevatorBOTTOM = new GTA.Math.Vector3(6.295846f, -709.3442f, 45.97305f);
    GTA.Math.Vector3 iaaElevatorBOTTOM = new GTA.Math.Vector3(105.3145f, -625.6478f, 44.22019f);
    GTA.Math.Vector3 fibElevatorBOTTOM = new GTA.Math.Vector3(99.49534f, -743.5652f, 45.75476f);
    GTA.Math.Vector3 halfConstructedBuildingElevatorBOTTOM = new GTA.Math.Vector3(-184.1684f, -1016.074f, 30.07096f);
    GTA.Math.Vector3 hospital1ElevatorBOTTOM = new GTA.Math.Vector3(360.2171f, -584.9374f, 28.8215f);
    //TOP CORDS
    GTA.Math.Vector3 mazeBankElevatorTOP = new GTA.Math.Vector3(-66.43941f, -822.1783f, 321.2873f);
    GTA.Math.Vector3 unionElevatorTOP = new GTA.Math.Vector3(-2.279792f, -690.0576f, 250.4136f);
    GTA.Math.Vector3 iaaElevatorTOP = new GTA.Math.Vector3(108.269f, -640.4637f, 258.1489f);
    GTA.Math.Vector3 fibElevatorTOP = new GTA.Math.Vector3(132.4646f, -726.3422f, 258.1525f);
    GTA.Math.Vector3 halfConstructedBuildingElevatorTOP = new GTA.Math.Vector3(-159.6062f, -944.0149f, 269.218f);
    GTA.Math.Vector3 hospital1ElevatorTOP = new GTA.Math.Vector3(340.2888f, -584.173f, 74.1657f);

    private void OnTick(object sender, EventArgs e)
    {
        //BOTTOM
        float MazeBankElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, mazeBankElevatorBOTTOM);
        float unionElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, unionElevatorBOTTOM);
        float iaaElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, iaaElevatorBOTTOM);
        float fibElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, fibElevatorBOTTOM);
        float halfConstructedBuildingElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, halfConstructedBuildingElevatorBOTTOM);
        float hospital1ElevatorDistanceBOTTOM = GTA.World.GetDistance(player.Position, hospital1ElevatorBOTTOM);
        //TOP
        float MazeBankElevatorDistanceTOP = GTA.World.GetDistance(player.Position, mazeBankElevatorTOP);
        float unionElevatorDistanceTOP = GTA.World.GetDistance(player.Position, unionElevatorTOP);
        float iaaElevatorDistanceTOP = GTA.World.GetDistance(player.Position, iaaElevatorTOP);
        float fibElevatorDistanceTOP = GTA.World.GetDistance(player.Position, fibElevatorTOP);
        float halfConstructedBuildingElevatorDistanceTOP = GTA.World.GetDistance(player.Position, halfConstructedBuildingElevatorTOP);
        float hospital1ElevatorDistanceTOP = GTA.World.GetDistance(player.Position, hospital1ElevatorTOP);

        //MAZE BANK BOTTOM
        if (MazeBankElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Maze Bank");
            mazeBankRadiusBOTTOM = true;
        }
        else
        {
            mazeBankRadiusBOTTOM = false;
        }
        //MAZE BANK TOP
        if (MazeBankElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the Maze Bank");
            mazeBankRadiusTOP = true;
        }
        else
        {
            mazeBankRadiusTOP = false;
        }


        //UNION DEPOSITORY BOTTOM
        if (unionElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Union Depository");
            unionRadiusBOTTOM = true;
        }
        else
        {
            unionRadiusBOTTOM = false;
        }
        //UNION DEPOSITORY TOP
        if (unionElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the Union Depository");
            unionRadiusTOP = true;
        }
        else
        {
            unionRadiusTOP = false;
        }


        //IAA BUILDING BOTTOM
        if (iaaElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the IAA Building");
            iaaRadiusBOTTOM = true;
        }
        else
        {
            iaaRadiusBOTTOM = false;
        }
        //IAA BUILDING TOP
        if (iaaElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the IAA Building");
            iaaRadiusTOP = true;
        }
        else
        {
            iaaRadiusTOP = false;
        }


        //FIB Building BOTTOM
        if (fibElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the FIB Building");
            fibRadiusBOTTOM = true;
        }
        else
        {
            fibRadiusBOTTOM = false;
        }
        //FIB Building TOP
        if (fibElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the FIB Building");
            fibRadiusTOP = true;
        }
        else
        {
            fibRadiusTOP = false;
        }


        //HALF CONSTRUCTED BUILDING TOP
        if (halfConstructedBuildingElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Building");
            halfConstructedBuildingRadiusBOTTOM = true;
        }
        else
        {
            halfConstructedBuildingRadiusBOTTOM = false;
        }
        //HALF CONSTRUCTED BUILDING BOTTOM
        if (halfConstructedBuildingElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Building");
            halfConstructedBuildingRadiusTOP = true;
        }
        else
        {
            halfConstructedBuildingRadiusTOP = false;
        }


        //HOSPITAL1 TOP
        if (hospital1ElevatorDistanceBOTTOM < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the top of the Hospital");
            hospital1RadiusTOP = true;
        }
        else
        {
            hospital1RadiusTOP = false;
        }
        //HOSPITAL1 BOTTOM
        if (hospital1ElevatorDistanceTOP < 2f && !player.IsInVehicle())
        {
            UI.ShowSubtitle("Press F to travel to the bottom of the Hospital");
            hospital1RadiusBOTTOM = true;
        }
        else
        {
            hospital1RadiusBOTTOM = false;
        }

        Interval = 10;
    }

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F10)
        {
            float x = Game.Player.Character.Position.X;
            float y = Game.Player.Character.Position.Y;
            float z = Game.Player.Character.Position.Z;          
            string GetZoneName = Function.Call<string>(Hash.GET_NAME_OF_ZONE, x, y, z);
            Logger.Log(string.Format("Zone: {0}\t{1}", GetZoneName, Game.Player.Character.Position.ToString()));
            UI.Notify("Log Updated");
        }
        if (e.KeyCode == Keys.F11)
        {
            float x = Game.Player.Character.Position.X;
            float y = Game.Player.Character.Position.Y;
            float z = Game.Player.Character.Position.Z;
            string GetZoneName = Function.Call<string>(Hash.GET_NAME_OF_ZONE, x, y, z);
            UI.ShowSubtitle(Game.Player.Character.Position.ToString(), 5000);
        }

        if (e.KeyCode == Keys.NumPad8)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X, player.Position.Y + 5, player.Position.Z);
        }
        if (e.KeyCode == Keys.NumPad2)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X, player.Position.Y - 5, player.Position.Z);
        }
        if (e.KeyCode == Keys.NumPad6)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X + 5, player.Position.Y, player.Position.Z);
        }
        if (e.KeyCode == Keys.NumPad4)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X - 5, player.Position.Y, player.Position.Z);
        }
        if (e.KeyCode == Keys.PageUp)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X, player.Position.Y, player.Position.Z + 5);
        }
        if (e.KeyCode == Keys.PageDown)
        {
            Game.Player.Character.Position = new Vector3(player.Position.X, player.Position.Y, player.Position.Z - 5);
        }

        //MAZE BANK BOTTOM
        if (mazeBankRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && mazeBankRadiusBOTTOM)
            {
                Game.Player.Character.Position = new Vector3(-66.43941f, -822.1783f, 321.2873f); //TOP CORDS
            }
            if (e.KeyCode == Keys.F && mazeBankRadiusBOTTOM && player.IsInVehicle())
            {
                UI.ShowSubtitle("You can't fit your vehicle in the elevator!");
            }
            if (e.KeyCode == Keys.F && !mazeBankRadiusBOTTOM && !player.IsInVehicle())
            {
                UI.ShowSubtitle("Are you lost? There's no elevator around!");
            }
        }
        //MAZE BANK TOP
        if (mazeBankRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && mazeBankRadiusTOP)
            {
                Game.Player.Character.Position = new Vector3(-59.82701f, -790.3538f, 44.22732f); //BOTTOM CORDS
            }
            if (e.KeyCode == Keys.F && mazeBankRadiusTOP && player.IsInVehicle())
            {
                UI.ShowSubtitle("You can't fit your vehicle in the elevator!");
            }
            if (e.KeyCode == Keys.F && !mazeBankRadiusTOP && !player.IsInVehicle())
            {
                UI.ShowSubtitle("Are you lost? There's no elevator around!");
            }
        }


        //UNION DEPOSITORY BOTTOM
        if (unionRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && unionRadiusBOTTOM)
            {
                Game.Player.Character.Position = new Vector3(-2.279792f, -690.0576f, 250.4136f); //TOP CORDS
            }
            if (e.KeyCode == Keys.F && unionRadiusBOTTOM && player.IsInVehicle()) 
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !unionRadiusBOTTOM && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }
        //UNION DEPOSITORY TOP
        if (unionRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && unionRadiusTOP)
            {
                Game.Player.Character.Position = new Vector3(6.295846f, -709.3442f, 45.97305f); //BOTTOM CORDS
            }
            if (e.KeyCode == Keys.F && unionRadiusTOP && player.IsInVehicle())
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !unionRadiusTOP && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }


        //IAA BUILDING BOTTOM
        if (iaaRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && iaaRadiusBOTTOM)
            {
                Game.Player.Character.Position = new Vector3(108.269f, -640.4637f, 258.1489f); //TOP CORDS
            }
            if (e.KeyCode == Keys.F && iaaRadiusBOTTOM && player.IsInVehicle())
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !iaaRadiusBOTTOM && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }
        //IAA BUILDING TOP
        if (iaaRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && iaaRadiusTOP)
            {
                Game.Player.Character.Position = new Vector3(105.3145f, -625.6478f, 44.22019f); //BOTTOM CORDS
            }
            if (e.KeyCode == Keys.F && iaaRadiusTOP && player.IsInVehicle())
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !iaaRadiusTOP && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }


        //FIB BUILDING BOTTOM
        if (fibRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && fibRadiusBOTTOM)
            {
                Game.Player.Character.Position = new Vector3(132.4646f, -726.3422f, 258.1525f); //TOP CORDS
            }
            if (e.KeyCode == Keys.F && fibRadiusBOTTOM && player.IsInVehicle())
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !fibRadiusBOTTOM && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }
        //FIB BUILDING TOP
        if (fibRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && fibRadiusTOP)
            {
                Game.Player.Character.Position = new Vector3(99.49534f, -743.5652f, 45.75476f); //BOTTOM CORDS
            }
            if (e.KeyCode == Keys.F && fibRadiusTOP && player.IsInVehicle())
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !fibRadiusTOP && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }


        //HALF CONSTRUCTED BUILDING BOTTOM
        if (halfConstructedBuildingRadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && halfConstructedBuildingRadiusBOTTOM)
            {
                Game.Player.Character.Position = new Vector3(-159.6062f, -944.0149f, 269.218f); //TOP CORDS
            }
            if (e.KeyCode == Keys.F && halfConstructedBuildingRadiusBOTTOM && player.IsInVehicle())
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !halfConstructedBuildingRadiusBOTTOM && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }
        //HALF CONSTRUCTED BUILDING TOP
        if (halfConstructedBuildingRadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && halfConstructedBuildingRadiusTOP)
            {
                Game.Player.Character.Position = new Vector3(-184.1684f, -1016.074f, 30.07096f); //BOTTOM CORDS
            }
            if (e.KeyCode == Keys.F && halfConstructedBuildingRadiusTOP && player.IsInVehicle())
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !halfConstructedBuildingRadiusTOP && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }


        //HOSPITAL1 TOP
        if (hospital1RadiusBOTTOM && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && hospital1RadiusBOTTOM)
            {
                Game.Player.Character.Position = new Vector3(360.2171f, -584.9374f, 28.8215f); //TOP CORDS           
            }
            if (e.KeyCode == Keys.F && hospital1RadiusBOTTOM && player.IsInVehicle())
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !hospital1RadiusBOTTOM && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }
        //HOSPITAL1 BOTTOM
        if (hospital1RadiusTOP && !player.IsInVehicle())
        {
            if (e.KeyCode == Keys.F && hospital1RadiusTOP)
            {
                Game.Player.Character.Position = new Vector3(340.2888f, -584.173f, 74.1657f); //BOTTOM CORDS
            }
            if (e.KeyCode == Keys.F && hospital1RadiusTOP && player.IsInVehicle())
            {
                UI.Notify("You must be on foot to use the Elevator!");
            }
            if (e.KeyCode == Keys.F && !hospital1RadiusTOP && !player.IsInVehicle())
            {
                UI.Notify("There is no Elevator around!");
            }
        }
    }   
}
