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
    public static Ped player = Game.Player.Character;

    bool StarvingBool = false;
    bool NotStarvingBool = false;

    bool HasNotEaten = false;
    bool HasEaten = false;

    public LifeMod()
    {
        KeyUp += OnKeyUp;
    }

    public void OnKeyUp(object sender, KeyEventArgs k)
    {
        if (k.KeyCode == Keys.F9 && View.ActiveMenus == 0)
        {
            foodMenu();
        }
        else
        {
            View.CloseAllMenus();
        }
    }
    public void foodMenu()
    {
        List<IMenuItem> FoodMenuButtons = new List<IMenuItem>();

        var button = new GTA.MenuButton("Eat Food", "Re-store your energy and eat some food!");
        button.Activated += (sender, args) =>
        {
            HasEaten = true;
            Wait(10000);
            HasNotEaten = true;
        };
        FoodMenuButtons.Add(button);

        button = new GTA.MenuButton("Exit", "Return to the game!");
        button.Activated += (sender, args) =>
        {
            Exit();
        };
        FoodMenuButtons.Add(button);

        var MenuLayout = new Menu("Food Menu", FoodMenuButtons.ToArray());
        DrawMenu(MenuLayout);
    }
    public void DrawMenu(GTA.Menu MenuLayout)
    {
        //ALPHA , RED , GREEN , BLUE

        // Header Layout
        MenuLayout.HeaderCentered = true;
        MenuLayout.HeaderHeight += 5;
        MenuLayout.HeaderTextScale = 0.64f;
        MenuLayout.HeaderFont = GTA.Font.ChaletComprimeCologne;
        MenuLayout.HeaderColor = System.Drawing.Color.FromArgb(175, 51, 153, 255);

        // Items Layout
        MenuLayout.ItemTextCentered = true;
        MenuLayout.ItemHeight -= 7;
        MenuLayout.ItemTextScale = 0.32f;
        MenuLayout.SelectedItemColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
        MenuLayout.UnselectedItemColor = System.Drawing.Color.FromArgb(80, 230, 230, 230);
        MenuLayout.SelectedTextColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
        MenuLayout.UnselectedTextColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);

        // Footer Layout
        MenuLayout.HasFooter = true;
        MenuLayout.FooterColor = System.Drawing.Color.FromArgb(175, 51, 153, 255);
        MenuLayout.FooterHeight += -17;
        MenuLayout.FooterTextScale = 0.50f;
        MenuLayout.FooterTextColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
        MenuLayout.FooterFont = GTA.Font.ChaletComprimeCologne;
        MenuLayout.FooterCentered = true;

        View.MenuPosition = new System.Drawing.Point(35, 20);
        View.AddMenu(MenuLayout);
    }

    public void Exit()
    {
        View.CloseAllMenus();
    }
    public void Return()
    {
        View.HandleBack();
    }
}
