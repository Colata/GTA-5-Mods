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
    Ped player = Game.Player.Character;
    Player playerplayer = Game.Player;

    bool playerRadius = false;

    public Main()
    {
        KeyUp += OnKeyUp;       
    }

    private void OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F10)
        {
            if (this.View.ActiveMenus == 0)
            {
                this.MainMenu();
            }
            else
            {
                View.CloseAllMenus();
            }
        }
        if(e.KeyCode == Keys.Back)
        {
            this.PreviousMenu();
        }
    }

    private void OnTick(object sender, EventArgs e)
    {
        if (player.IsDead)
            View.CloseAllMenus();

        Interval = 10;
    }   

    private void DrawMenu(GTA.Menu MainMenu)
    {
        //ALPHA , RED , GREEN , BLUE

        // Header Layout
        MainMenu.HeaderCentered = true;
        MainMenu.HeaderHeight += 5;
        MainMenu.HeaderTextScale = 0.64f;
        MainMenu.HeaderFont = GTA.Font.ChaletComprimeCologne;
        MainMenu.HeaderColor = System.Drawing.Color.FromArgb(175, 51, 153, 255);

        // Items Layout
        MainMenu.ItemTextCentered = true;
        MainMenu.ItemHeight -= 7;
        MainMenu.ItemTextScale = 0.32f;
        MainMenu.SelectedItemColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
        MainMenu.UnselectedItemColor = System.Drawing.Color.FromArgb(80, 230, 230, 230);
        MainMenu.SelectedTextColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
        MainMenu.UnselectedTextColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);

        // Footer Layout
        MainMenu.HasFooter = true;
        MainMenu.FooterColor = System.Drawing.Color.FromArgb(175, 51, 153, 255);
        MainMenu.FooterHeight += -17;
        MainMenu.FooterTextScale = 0.50f;
        MainMenu.FooterTextColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
        MainMenu.FooterFont = GTA.Font.ChaletComprimeCologne;
        MainMenu.FooterCentered = true;

        View.MenuPosition = new System.Drawing.Point(35, 20);
        View.AddMenu(MainMenu);
    }


    void MainMenu()
    {
        List<IMenuItem> mainMenuList = new List<IMenuItem>();

        var WeaponMenuButton = new GTA.MenuButton("Weapon Menu", "Pick from all the game's weapons!");
        WeaponMenuButton.Activated += (sender, args) => WeaponMenu();
        mainMenuList.Add(WeaponMenuButton);

        var WehMenuButton = new GTA.MenuButton("Vehicle Menu", "Spawn any vehicle you like!");
        WehMenuButton.Activated += (sender, args) => SpawnMenu();
        mainMenuList.Add(WehMenuButton);

        var WeaponOptionsMenuButton = new GTA.MenuButton("Weapon Options", "Customize your weapons!");
        WeaponOptionsMenuButton.Activated += (sender, args) => WeaponOptionMenu();
        mainMenuList.Add(WeaponOptionsMenuButton);

        var VehOptionsMenuButton = new GTA.MenuButton("Vehicle Options", "Customize and repair your vehicles!");
        VehOptionsMenuButton.Activated += (sender, args) => VehOptionsMenu();
        mainMenuList.Add(VehOptionsMenuButton);

        var PlayerptionsMenuButton = new GTA.MenuButton("Player Options", "Change and edit player options!");
        PlayerptionsMenuButton.Activated += (sender, args) => PlayerOptionsMenu();
        mainMenuList.Add(PlayerptionsMenuButton);

        var WorldptionsMenuButton = new GTA.MenuButton("World Options", "Change and edit World options!");
        WorldptionsMenuButton.Activated += (sender, args) => WorldOptionsMenu();
        mainMenuList.Add(WorldptionsMenuButton);


        var ExitButton = new GTA.MenuButton("Exit", "Return to the game!");
        ExitButton.Activated += (sender, args) => Exit();
        mainMenuList.Add(ExitButton);

        var MainMenu = new GTA.Menu("Main Menu", mainMenuList.ToArray());

        DrawMenu(MainMenu);
    }

    void PreviousMenu()
    {
        View.HandleBack();
    }
    void Exit()
    {
        View.CloseAllMenus();
    }
}
