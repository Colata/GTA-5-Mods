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

public partial class Mod : Script
{
    Ped player = Game.Player.Character;

    public Mod()
    {   
        KeyUp += OnKeyUp;
        Tick += OnTick;
        Interval = 1;
    }
    
    private void OnTick(object sender, EventArgs f)
    {
        if(player.IsDead)
        {
            View.CloseAllMenus();
        }        
    }

    public void OnKeyUp(object sender, KeyEventArgs e)
    {
        //Location Logger
        if (e.KeyCode == Keys.L)
        {
           float x = Game.Player.Character.Position.X;
           float y = Game.Player.Character.Position.Y;
           float z = Game.Player.Character.Position.Z;
           string GetZoneName = Function.Call<string>(Hash.GET_NAME_OF_ZONE, x, y, z);
           Logger.Log(string.Format("Zone: {0}\t{1}", GetZoneName, Game.Player.Character.Position.ToString()));
           UI.Notify("Log Updated");
        }
        //Location Logger 

        if (e.KeyCode == Keys.F10)
        {
            this.mainMenu();
        }

        if (e.KeyCode == Keys.Insert)
        {
            UI.Notify("Refreshed Script");
        }

        if(e.KeyCode == Keys.Back)
        {
            View.HandleBack();
        }
    }
}
