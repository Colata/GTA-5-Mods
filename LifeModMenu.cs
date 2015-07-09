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

partial class LifeMod : Script
{
    public void LifeModTick()
    {
        Tick += OnTick;
    }

    public void OnTick(object sender, EventArgs e)
    {
        //If you die, this just resets your food as if you've eaten.
        if (player.IsDead)
        {
            HasEaten = true;
            Wait(5000);
            HasNotEaten = true;
        }

        //If (has eaten) then you arent starving
        if (HasEaten)
        {
            UI.Notify("You're all full after a big meal!", true);
            StarvingBool = false;
        }
        //If (hasnoteaten) then you are starving 
        if (HasNotEaten)
        {
            UI.Notify("You're beginning to starve and need to find food!");
            StarvingBool = true;
        }

        //What do to if starving or not.

        //If you are starving, the starving void will activate
        if (StarvingBool)
        {
            Starving();
        }
        //If you are not starving, the notstarving void will activate
        if (NotStarvingBool)
        {
            NotStarving();
        }

        Interval = 5000;
    }
    public void Starving() //Takes 7.30 minutes to die from Starvation (if starving is activated every 5 seconds)
    {
        int CurrentHealth = Game.Player.Character.Health;
        player.Health = CurrentHealth - 1;
        Function.Call(Hash._SET_PLAYER_HEALTH_REGENERATION_RATE, 0);
    }
    public void NotStarving() //Regenerates health and/or stops starvation
    {
        Function.Call(Hash._SET_PLAYER_HEALTH_REGENERATION_RATE, 1);
    }

}
