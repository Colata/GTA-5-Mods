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

public class ElevatorMod : Script
{
    public static Ped player = Game.Player.Character;

    public ElevatorMod()
    {
        Tick += OnTick;
        KeyUp += OnKeyUp;
    }

    private void OnTick(object sender, EventArgs e)
    {
        Interval = 10;
    }

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        Vector3 playerPos = Game.Player.Character.Position;

        float x = Game.Player.Character.Position.X;
        float y = Game.Player.Character.Position.Y;
        float z = Game.Player.Character.Position.Z;
        string GetZoneName = Function.Call<string>(Hash.GET_NAME_OF_ZONE, x, y, z);
        
        if (e.KeyCode == Keys.F10)
        {
            Logger.Log(string.Format("Zone: {0}\t{1}", GetZoneName, Game.Player.Character.Position.ToString()));
            UI.Notify("Log Updated");
        }
        if (e.KeyCode == Keys.F11)
        {          
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
    }   
}
