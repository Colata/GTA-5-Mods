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

public class AirDropAttackers : Script
{
    public AirDropAttackers()
    {
        Tick += OnTick;
        
        Interval = 10;
    }

    void OnTick (object sender, EventArgs e)
    {
    }
}
