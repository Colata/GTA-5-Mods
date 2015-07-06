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

public class Main : Script
{
    void WorldOptionsMenu()
    {
        List<IMenuItem> WorldOptionsMenuList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Weather");
        button.Activated += (sender, args) => ChangeWeatherList();
        WorldOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Pedestrians");
        button.Activated += (sender, args) => PedestrianMenu();
        WorldOptionsMenuList.Add(button);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        WorldOptionsMenuList.Add(returnButton);

        var mainMenu = new Menu("World Options Menu", WorldOptionsMenuList.ToArray());
        DrawMenu(mainMenu);
    }

    void ChangeWeatherList()
    {
        var WeatherMenu = (new GTA.Menu("Change Weather",
        Enum.GetNames(typeof(Weather)).Take(14).Select(WeatherName => new MenuButton(WeatherName)).ToArray()));
        DrawMenu(WeatherMenu);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
    }

    void PedestrianMenu()
    {
        List<IMenuItem> PedestrianOptionsMenuList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Peds attack you");
        button.Activated += (sender, args) => PedAttackYou();
        PedestrianOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Peds riot");
        button.Activated += (sender, args) => PedestrianMenu();
        PedestrianOptionsMenuList.Add(button);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        PedestrianOptionsMenuList.Add(returnButton);

        var mainMenu = new Menu("Pedestrian Options Menu", PedestrianOptionsMenuList.ToArray());
        DrawMenu(mainMenu);
    }

    void PedAttackYou()
    {
    }
}
