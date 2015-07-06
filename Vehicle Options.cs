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
     private void VehOptionsMenu()
    {
        List<IMenuItem> VehOptionsMenuList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Vehicle Options");
        button.Activated += (sender, args) => VehOptions();
        VehOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Maintainance");
        button.Activated += (sender, args) => Maintainance();
        VehOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Customization");
        button.Activated += (sender, args) => Sport();
        VehOptionsMenuList.Add(button);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        VehOptionsMenuList.Add(returnButton);

        var mainMenu = new Menu("Vehicle Options Menu", VehOptionsMenuList.ToArray());
        DrawMenu(mainMenu);
    }

    void VehOptions()
    {
        List<IMenuItem> VehOptionsMenuList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Windows");
        button.Activated += (sender, args) => WindowOptions();
        VehOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Doors");
        button.Activated += (sender, args) => DoorOptions();
        VehOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Lights");
        button.Activated += (sender, args) => LightOptions();
        VehOptionsMenuList.Add(button);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        VehOptionsMenuList.Add(returnButton);

        var mainMenu = new Menu("Vehicle Options Menu", VehOptionsMenuList.ToArray());
        DrawMenu(mainMenu);
    }

    void WindowOptions()
    {
        List<IMenuItem> VehWindowOptionsMenuList = new List<IMenuItem>();

        var toggle = new MenuToggle("Front Left Window", "Up/Down");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.FrontLeftWindowUP();
            }
            else
            {
                this.FrontLeftWindowDOWN();
            }
        };
        VehWindowOptionsMenuList.Add(toggle);

        toggle = new MenuToggle("Front Right Window", "Up/Down");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.FrontRightWindowUP();
            }
            else
            {
                this.FrontRightWindowDOWN();
            }
        };
        VehWindowOptionsMenuList.Add(toggle);

        toggle = new MenuToggle("Back Left Window", "Up/Down");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.BackLeftWindowUP();
            }
            else
            {
                this.BackLeftWindowDOWN();
            }
        };
        VehWindowOptionsMenuList.Add(toggle);

        toggle = new MenuToggle("Back Right Window", "Up/Down");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.BackRightWindowUP();
            }
            else
            {
                this.BackRightWindowDOWN();
            }
        };
        VehWindowOptionsMenuList.Add(toggle);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        VehWindowOptionsMenuList.Add(returnButton);

        var mainMenu = new Menu("Window Options List", VehWindowOptionsMenuList.ToArray());
        DrawMenu(mainMenu);
    }

    void FrontLeftWindowUP()
    {
        player.CurrentVehicle.RollUpWindow(VehicleWindow.FrontLeftWindow);
    }
    void FrontLeftWindowDOWN()
    {
        player.CurrentVehicle.RollDownWindow(VehicleWindow.FrontLeftWindow);
    }
    void FrontRightWindowUP()
    {
        player.CurrentVehicle.RollUpWindow(VehicleWindow.FrontRightWindow);
    }
    void FrontRightWindowDOWN()
    {
        player.CurrentVehicle.RollDownWindow(VehicleWindow.FrontRightWindow);
    }
    void BackLeftWindowUP()
    {
        player.CurrentVehicle.RollUpWindow(VehicleWindow.BackLeftWindow);
    }
    void BackLeftWindowDOWN()
    {
        player.CurrentVehicle.RollDownWindow(VehicleWindow.BackLeftWindow);
    }
    void BackRightWindowUP()
    {
        player.CurrentVehicle.RollUpWindow(VehicleWindow.BackRightWindow);
    }
    void BackRightWindowDOWN()
    {
        player.CurrentVehicle.RollDownWindow(VehicleWindow.BackRightWindow);
    }

    void DoorOptions()
    {
        List<IMenuItem> VehDoorOptionsMenuList = new List<IMenuItem>();

        var toggle = new MenuToggle("Front Left Door", "Open/Close");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.FrontLeftDoorOpen();
            }
            else
            {
                this.FrontLeftDoorClose();
            }
        };
        VehDoorOptionsMenuList.Add(toggle);

        toggle = new MenuToggle("Front Right Door", "Open/Close");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.FrontRightDoorOpen();
            }
            else
            {
                this.FrontRightDoorClose();
            }
        };
        VehDoorOptionsMenuList.Add(toggle);

        toggle = new MenuToggle("Back Left Door", "Open/Close");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.BackLeftDoorOpen();
            }
            else
            {
                this.BackLeftDoorClose();
            }
        };
        VehDoorOptionsMenuList.Add(toggle);

        toggle = new MenuToggle("Back Right Door", "Open/Close");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.BackRightDoorOpen();
            }
            else
            {
                this.BackRightDoorClose();
            }
        };
        VehDoorOptionsMenuList.Add(toggle);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        VehDoorOptionsMenuList.Add(returnButton);

        var mainMenu = new Menu("Door Options List", VehDoorOptionsMenuList.ToArray());
        DrawMenu(mainMenu);
    }

    void FrontLeftDoorOpen()
    {
        player.CurrentVehicle.OpenDoor(VehicleDoor.FrontLeftDoor, false, true);
    }
    void FrontLeftDoorClose()
    {
        player.CurrentVehicle.CloseDoor(VehicleDoor.FrontLeftDoor, false);
    }
    void FrontRightDoorOpen()
    {
        player.CurrentVehicle.OpenDoor(VehicleDoor.FrontRightDoor, false, true);
    }
    void FrontRightDoorClose()
    {
        player.CurrentVehicle.CloseDoor(VehicleDoor.FrontRightDoor, false);
    }
    void BackLeftDoorOpen()
    {
        player.CurrentVehicle.OpenDoor(VehicleDoor.BackLeftDoor, false, true);
    }
    void BackLeftDoorClose()
    {
        player.CurrentVehicle.CloseDoor(VehicleDoor.BackLeftDoor, false);
    }
    void BackRightDoorOpen()
    {
        player.CurrentVehicle.OpenDoor(VehicleDoor.BackRightDoor, false, true);
    }
    void BackRightDoorClose()
    {
        player.CurrentVehicle.CloseDoor(VehicleDoor.BackRightDoor,false);
    }

    void LightOptions()
    {
        List<IMenuItem> VehLightOptionsMenuList = new List<IMenuItem>();

        var toggle = new MenuToggle("Break Lights", "On/Off");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.BreakLightOn();
            }
            else
            {
                this.BreakLightOff();
            }
        };
        VehLightOptionsMenuList.Add(toggle);

        toggle = new MenuToggle("Left Indicator", "On/Off");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.LeftIndicatorOn();
            }
            else
            {
                this.LeftIndicatorOff();
            }
        };
        VehLightOptionsMenuList.Add(toggle);

        toggle = new MenuToggle("Right Indicator", "On/Off");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.RightIndicatorOn();
            }
            else
            {
                this.RightIndicatorOff();
            }
        };
        VehLightOptionsMenuList.Add(toggle);

        toggle = new MenuToggle("Headlights", "On/Off");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.LightsOn();
            }
            else
            {
                this.LightsOff();
            }
        };
        VehLightOptionsMenuList.Add(toggle);

        toggle = new MenuToggle("Interior Lights", "On/Off");
        toggle.Changed += (sender, args) =>
        {
            var tg = sender as MenuToggle;
            if (tg == null)
            {
                return;
            }
            if (tg.Value)
            {
                this.InteriorLightsOn();
            }
            else
            {
                this.InteriorLightsOff();
            }
        };
        VehLightOptionsMenuList.Add(toggle);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        VehLightOptionsMenuList.Add(returnButton);

        var mainMenu = new Menu("Lights Option List", VehLightOptionsMenuList.ToArray());
        DrawMenu(mainMenu);
    }

    void BreakLightOn()
    {
        player.CurrentVehicle.BrakeLightsOn = true;
    }
    void BreakLightOff()
    {
        player.CurrentVehicle.BrakeLightsOn = false;
    }
    void LeftIndicatorOn()
    {
        player.CurrentVehicle.LeftIndicatorLightOn = true;
    }
    void LeftIndicatorOff()
    {
        player.CurrentVehicle.LeftIndicatorLightOn = false;
    }
    void RightIndicatorOn()
    {
        player.CurrentVehicle.RightIndicatorLightOn = true;
    }
    void RightIndicatorOff()
    {
        player.CurrentVehicle.RightIndicatorLightOn = false;
    }
    void LightsOn()
    {
        player.CurrentVehicle.LightsOn = true;
    }
    void LightsOff()
    {
        player.CurrentVehicle.LightsOn = false;
    }
    void InteriorLightsOn()
    {
        player.CurrentVehicle.InteriorLightOn = true;
    }
    void InteriorLightsOff()
    {
        player.CurrentVehicle.InteriorLightOn = false;
    }

    void Maintainance()
    {
        List<IMenuItem> VehOptionsMenuList = new List<IMenuItem>();

        var button = new GTA.MenuButton("Repair Vehicle");
        button.Activated += (sender, args) => RepVeh();
        VehOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Repair Wheels");
        button.Activated += (sender, args) => RepWheel();
        VehOptionsMenuList.Add(button);

        button = new GTA.MenuButton("Repair Windows");
        button.Activated += (sender, args) => RepWindow();
        VehOptionsMenuList.Add(button);

        var returnButton = new GTA.MenuButton("Return");
        returnButton.Activated += (sender, args) => PreviousMenu();
        VehOptionsMenuList.Add(returnButton);

        var mainMenu = new Menu("Vehicle Options Menu", VehOptionsMenuList.ToArray());
        DrawMenu(mainMenu);
    }

    void RepVeh()
    {
        player.CurrentVehicle.Repair();            
    }
    void RepWheel()
    {
        player.CurrentVehicle.FixTire(0);
        player.CurrentVehicle.FixTire(1);
        player.CurrentVehicle.FixTire(2);
        player.CurrentVehicle.FixTire(3);
    }
    void RepWindow()
    {
        player.CurrentVehicle.FixWindow(VehicleWindow.BackLeftWindow);
        player.CurrentVehicle.FixWindow(VehicleWindow.BackRightWindow);
        player.CurrentVehicle.FixWindow(VehicleWindow.FrontLeftWindow);
        player.CurrentVehicle.FixWindow(VehicleWindow.FrontRightWindow);
    }
}
