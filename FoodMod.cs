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

    
    bool HasEaten = false;

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
                this.foodMenu();
            }
            else
            {
                View.CloseAllMenus();
            }
        }
    }

    private void OnTick(object sender, EventArgs e)
    {

        if (player.IsDead)
            View.CloseAllMenus();

        if(!HasEaten)
        {
            Starving();
        }
        else
        {
            Full();
        }

        if(player.IsAlive)
        {
            GTA.UI.ShowSubtitle(Game.Player.Character.Position.ToString(), 3000);
        }

        Interval = 1000;
    }


    //MENUS
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
    void foodMenu()
    {
        List<IMenuItem> mainMenuList = new List<IMenuItem>();

        var FoodEatButton = new GTA.MenuButton("Eat Food", "Eat some food!");
        FoodEatButton.Activated += (sender, args) =>
        {
            HasEaten = true;
            UI.Notify("You've eaten food!");
        };
        mainMenuList.Add(FoodEatButton);

        var ExitButton = new GTA.MenuButton("Exit", "Return to the game!");
        ExitButton.Activated += (sender, args) => Exit();
        mainMenuList.Add(ExitButton);

        var MainMenu = new GTA.Menu("Main Menu", mainMenuList.ToArray());

        DrawMenu(MainMenu);
    }
    //MENUS

    void Starving()
    {       
        Function.Call(Hash._SET_PLAYER_HEALTH_REGENERATION_RATE, Game.Player, -1.5);
    }
    void Full()
    {
        Function.Call(Hash._SET_PLAYER_HEALTH_REGENERATION_RATE, Game.Player, 0.5);
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
