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
    public void subWeather()
    {
        List<IMenuItem> weatherList = new List<IMenuItem>();

        var Button = new GTA.MenuButton("Blizzard");
        Button.Activated += (sender, args) => World.Weather = Weather.Blizzard;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Christmas");
        Button.Activated += (sender, args) => World.Weather = Weather.Christmas;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Clear");
        Button.Activated += (sender, args) => World.Weather = Weather.Clear;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Clearing");
        Button.Activated += (sender, args) => World.Weather = Weather.Clearing;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Clouds");
        Button.Activated += (sender, args) => World.Weather = Weather.Clouds;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Extra Sunny");
        Button.Activated += (sender, args) => World.Weather = Weather.ExtraSunny;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Foggy");
        Button.Activated += (sender, args) => World.Weather = Weather.Foggy;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Neutral");
        Button.Activated += (sender, args) => World.Weather = Weather.Neutral;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Overcast");
        Button.Activated += (sender, args) => World.Weather = Weather.Overcast;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Raining");
        Button.Activated += (sender, args) => World.Weather = Weather.Raining;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Smog");
        Button.Activated += (sender, args) => World.Weather = Weather.Smog;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Snowing");
        Button.Activated += (sender, args) => World.Weather = Weather.Snowing;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Snowlight");
        Button.Activated += (sender, args) => World.Weather = Weather.Snowlight;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Thunderstorm");
        Button.Activated += (sender, args) => World.Weather = Weather.ThunderStorm;
        weatherList.Add(Button);

        Button = new GTA.MenuButton("Back", "Return to the previous page");
        Button.Activated += (sender, args) => View.HandleBack();
        weatherList.Add(Button);

        var mainMenu = new Menu("Change Weather", weatherList.ToArray());
        DrawMenu(mainMenu);
    }
}
