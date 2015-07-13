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

public class WorldMarkers : Script
{
    public WorldMarkers()
    {
        Tick += OnTick;
        Interval = 1;
    }

    public void OnTick(object sender, EventArgs e)
    {
        //Markers
        //LOS SANTOS SQUARE Marker
        Function.Call(Hash.DRAW_MARKER, 11, 196.5117f, -932.2867f, 40.6868f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 20f, 20f, 20f, 204, 204, 1, 150, false, true, 2, false, false, false, false);
        
        //Maze Bank Markers
        Function.Call(Hash.DRAW_MARKER, 1, -59.82701f, -790.3538f, 44.22732f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, -66.7541f, -821.9783f, 321.2873f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, -71.11931f, -813.9098f, 326.1752f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        //Union Depository Markers
        Function.Call(Hash.DRAW_MARKER, 1, 6.295846f, -709.3442f, 45.97305f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, -2.279792f, -690.0576f, 250.4136f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        //IAA Building Markers
        Function.Call(Hash.DRAW_MARKER, 1, 105.3145f, -625.6478f, 44.22019f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, 108.269f, -640.4637f, 258.1489f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        //FIB Building Markers
        Function.Call(Hash.DRAW_MARKER, 1, 99.49534f, -743.5652f, 45.75476f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, 132.4646f, -726.3422f, 258.1525f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        //Half Constructed Building Markers
        Function.Call(Hash.DRAW_MARKER, 1, -159.6062f, -944.0149f, 269.218f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, -184.1684f, -1016.074f, 30.07096f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        //Hopsital1 Markers
        Function.Call(Hash.DRAW_MARKER, 1, 360.2171f, -584.9374f, 28.8215f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, 340.2888f, -584.173f, 74.1657f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        //Badger Center Markers
        Function.Call(Hash.DRAW_MARKER, 1, 478.8547f, -107.6386f, 63.1579f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, 469.7626f, -107.6571f, 117.6346f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false); 
        //ARCADIUS Business Center
        Function.Call(Hash.DRAW_MARKER, 1, -147.3193f, -578.701f, 48.23539f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, -156.0835f, -603.023f, 201.7354f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, -133.4699f, -584.0259f, 201.7353f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, -140.8396f, -588.3941f, 211.7753f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        //Richards Majestic
        Function.Call(Hash.DRAW_MARKER, 1, -903.6141f, -370.357f, 136.2822f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, -908.4594f, -375.7424f, 137.9059f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
        Function.Call(Hash.DRAW_MARKER, 1, -933.8727f, -384.1257f, 38.96134f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 2.0f, 2.0f, 2.0f, 204, 204, 1, 50, false, true, 2, false, false, false, false);
    }
}
