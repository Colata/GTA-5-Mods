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
       private void mainMenu()
       {

       List<IMenuItem> mainMenu = new List<IMenuItem>();

       var button = new GTA.MenuButton("Weapons", "Spawn weapons");
       button.Activated += (sender, args) =>
       {
           this.subWeapons();
       };
       mainMenu.Add(button);

       button = new GTA.MenuButton("Vehicles", "Spawn vehicles");
       button.Activated += (sender, args) =>
       {
           this.subVehicles();
       };
       mainMenu.Add(button);

       button = new GTA.MenuButton("Weather", "Change the weather");
       button.Activated += (sender, args) =>
       {
           this.subWeather();
       };
       mainMenu.Add(button);

       button = new GTA.MenuButton("Teleports", "view the teleport list");
       button.Activated += (sender, args) =>
       {
           this.teleportLocations();
       };
       mainMenu.Add(button);

       button = new GTA.MenuButton("Teleport Regions", "view the teleport Regions");
       button.Activated += (sender, args) =>
       {
           this.teleportRegions();           
       };
       mainMenu.Add(button);

       button = new GTA.MenuButton("Exit", "Close the menu");
       button.Activated += (sender, args) =>
       {
           this.View.CloseAllMenus();
       };
       mainMenu.Add(button);

       var main = new GTA.Menu("menu", mainMenu.ToArray());
       DrawMenu(main);
       }

       private void DrawMenu(GTA.Menu menuLayout)
       {
           //FROZETS MENU LAYOUT

           // Header Layout
           menuLayout.HeaderCentered = true;
           menuLayout.HeaderHeight += 5;
           menuLayout.HeaderTextScale = 0.64f;
           menuLayout.HeaderFont = GTA.Font.ChaletComprimeCologne;
           menuLayout.HeaderColor = System.Drawing.Color.FromArgb(175, 51, 153, 255);

           // Items Layout
           menuLayout.ItemTextCentered = true;
           menuLayout.ItemHeight -= 7;
           menuLayout.ItemTextScale = 0.32f;
           menuLayout.SelectedItemColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
           menuLayout.UnselectedItemColor = System.Drawing.Color.FromArgb(80, 230, 230, 230);
           menuLayout.SelectedTextColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
           menuLayout.UnselectedTextColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);

           // Footer Layout
           menuLayout.HasFooter = true;
           menuLayout.FooterColor = System.Drawing.Color.FromArgb(175, 51, 153, 255);
           menuLayout.FooterHeight += -17;
           menuLayout.FooterTextScale = 0.50f;
           menuLayout.FooterTextColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
           menuLayout.FooterFont = GTA.Font.ChaletComprimeCologne;
           menuLayout.FooterCentered = true;

           View.MenuPosition = new System.Drawing.Point(35, 20);
           View.AddMenu(menuLayout);
       }
}
