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
    void PlayerOptionsMenu()
    {
        List<IMenuItem> PlayerOptionsMenuList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Model Changer");
        button.Activated += (sender, args) => Exit();
        PlayerOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Wanted Level");
        button.Activated += (sender, args) => WantedLevel();
        PlayerOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Health/Armour");
        button.Activated += (sender, args) => Exit();
        PlayerOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Teleport");
        button.Activated += (sender, args) => Exit();
        PlayerOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Abilities");
        button.Activated += (sender, args) => Exit();
        PlayerOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Show Cords");
        button.Activated += (sender, args) => ShowCords();
        PlayerOptionsMenuList.Add(button);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        PlayerOptionsMenuList.Add(returnButton);

        var mainMenu = new Menu("Player Options Menu", PlayerOptionsMenuList.ToArray());
        DrawMenu(mainMenu);
    }

    void ShowCords()
    {
        UI.ShowSubtitle(player.Position.ToString(), 3000);
    }

    void WantedLevel()
    {
        List<IMenuItem> WantedLevelOptionsMenuList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Remove Wanted Level");
        button.Activated += (sender, args) => Exit();
        WantedLevelOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Wanted Level Raise");
        button.Activated += (sender, args) => WantedLevel();
        WantedLevelOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Wanted Level Lower");
        button.Activated += (sender, args) => Exit();
        WantedLevelOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Never Wanted");
        button.Activated += (sender, args) => Exit();
        WantedLevelOptionsMenuList.Add(button);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        WantedLevelOptionsMenuList.Add(returnButton);

        var mainMenu = new Menu("Wanted Level Options", WantedLevelOptionsMenuList.ToArray());
        DrawMenu(mainMenu);
    }

    void RaiseWantedLevel()
    {

    }

}
