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
    public static Entity GetEntity
    {
        get
        {
            Ped playerPed = Game.Player.Character;
            Entity entity = playerPed;
            if (playerPed.IsInVehicle())
                entity = playerPed.CurrentVehicle;

            return entity;
        }
    }

    public static void DisplayMessage(string msg, bool state)
    {
        string stateMsg;
        if (state)
            stateMsg = " ~g~Activated";
        else
            stateMsg = " ~r~Deactivated";

        UI.Notify(msg + ":" + stateMsg);
    }
    public static void DisplayMessage(string msg)
    {
        UI.Notify(msg);
    }


    internal static void TeleportToLocation(KeyValuePair<string, Vector3> location)
    {
        Mod.GetEntity.Position = location.Value;
        Mod.DisplayMessage(string.Format("Teleport to {0} succeeded", location.Key));
    }

    private void teleportLocations()
    {
        List<IMenuItem> teleportMenuItems = new List<IMenuItem>();

        Dictionary<string, Vector3> teleportDict = new Dictionary<string, Vector3>()
        {
            //Character Houses
            {"Michael's House", new Vector3(-852.4f, 160.0f, 65.6f)},
            {"Franklin's House", new Vector3(7.9f, 548.1f, 175.5f)},
            {"Franklin's Aunt", new Vector3(-14.8f, -1454.5f, 30.5f)},
            {"Trevor's Trailer", new Vector3(1985.7f, 3812.2f, 32.2f)},

            //Los Santos P.O.I
            {"Airport Entrance", new Vector3(-1034.6f, -2733.6f, 13.8f)},
            {"Elysian Island", new Vector3(338.2f, -2715.9f, 38.5f)},
            {"Jetsam", new Vector3(760.4f, -2943.2f, 5.8f)},
            {"Strip Club", new Vector3(127.4f, -1307.7f, 29.2f)},
            {"Elburro Heights", new Vector3(1384.0f, -2057.1f, 52.0f)},
            {"Ferris Wheel", new Vector3(-1670.7f, -1125.0f, 13.0f)},
            {"IAA Roof", new Vector3(134.085f, -637.859f, 262.851f)},
            {"FIB Roof", new Vector3(150.126f, -754.591f, 262.865f)},
            {"MAZE Roof", new Vector3(75.015f, -818.215f, 326.176f)},
            {"Galileo Observatory", new Vector3(-438.804f, 1076.097f, 352.411f)},              
            {"Cockadoos Night Club", new Vector3(-421.8919f, -32.53123f, 45.64127f)},

            //North Los Santos P.O.I
            {"Windfarm", new Vector3(2354.0f, 1830.3f, 101.1f)},

            //Blaine County P.O.I
            {"Mount Chilliad", new Vector3(425.4f, 5614.3f, 766.5f)},
            {"McKenzie Airfield", new Vector3(2121.7f, 4796.3f, 41.1f)},
            {"Desert Airfield", new Vector3(1747.0f, 3273.7f, 41.1f)},

            //Chumash P.O.I
            {"Fort Zancudo Airstrip", new Vector3(-2047.4f, 3132.1f, 32.8f)},          
            {"Calidia Train Bridge", new Vector3(-517.869f, 4425.284f, 89.795f)},
            {"Hookies Restaraunt", new Vector3(-2210.377f, 4275.864f, 47.53487f)},
            {"Chumash Pier", new Vector3(-3418.627f, 967.6582f, 11.93614f)},
            {"Chumash Plaza", new Vector3(-3146.236f, 1090.189f, 20.63804f)},
            {"Chumash 24/7 Store", new Vector3(-3235.094f, 1004.239f, 11.5827f)},
            {"North Chumash 24/7 Store", new Vector3(-2552.484f, 2323.294f, 32.63923f)},
            {"Fort Zancudo Bridge", new Vector3(-1303.894f, 2523.199f, 19.74479f)},
            {"Approach Road Strip", new Vector3(-1101.957f, 2687.922f, 18.95326f)},
            {"Chumash Church", new Vector3(-313.4966f, 2736.5f, 67.58243f)},
            {"Two Hoots Falls", new Vector3(-1580.765f, 2103.904f, 67.19774f)},
            {"Marlowe Vineyard", new Vector3(-1896.157f, 2020.771f, 140.378f)},
            {"Raton Canyon Beach", new Vector3(-2326.882f, 4388.063f, 5.476571f)},
            {"Pacific Bluffs Resort", new Vector3(-3013.264f, 92.67957f, 11.14737f)},

            //Paleto P.O.I
            {"Mount Chilliad Tourist Trail", new Vector3(-791.8028f, 5431.17f,  34.94675f)},
            {"Pala Springs Arial Tram", new Vector3(-774.632f,  5583.521f, 33.48571f)},
            {"Bay View Lodge", new Vector3(-699.967f,  5804.444f, 17.33097f)},
            {"Paleto Pier", new Vector3(-275.522f, 6635.835f, 7.425f)},
            {"Paleto Bay Police", new Vector3(-439.0632f, 6029.661f, 30.64762f)},
            {"Paleto Bay Fire Station", new Vector3(-394.6006f, 6112.041f, 30.57901f)},
            {"Blaine County Depot", new Vector3(-423.7233f, 6128.319f, 30.74381f)},      
            {"Paleto Beach", new Vector3(176.2322f, 7044.014f, 1.563711f)}, 
            {"Zancudo Grain Growers", new Vector3(422.4891f, 6510.034f, 27.44678f)}, 
            {"Don's County Store", new Vector3(154.2453f, 6627.404f, 31.44249f)}, 
            {"Cluckin' Bell Farms", new Vector3(-44.81462f, 6300.761f, 31.62272f)}, 
            {"Paleto Ammunation", new Vector3(-313.1521f, 6080.361f, 30.53053f)}, 
            {"Paleto Jetsam", new Vector3(-250.9207f, 6142.291f, 30.54244f)},
            {"Paleto Tatoo", new Vector3(-286.2726f, 6202.761f, 30.63803f)},
            {"Paleto Church", new Vector3(-334.7715f, 6146.429f, 30.73213f)},
            {"Hen House", new Vector3(-285.5729f, 6263.744f, 30.69096f)},
            {"Paleto Medical", new Vector3(-238.2572f, 6333.238f, 31.66936f)},
            {"Machine Supply", new Vector3(-202.2181f, 6310.578f, 30.73189f)},
            {"Dream View Hotel", new Vector3(-104.8418f, 6303.446f, 30.6078f)},
            {"South Sea Appartments", new Vector3(-142.4194f, 6439.872f, 30.59953f)},
            {"Blaine County Bank", new Vector3(-117.9427f, 6454.82f, 30.64681f)},
            {"Willies Superstore", new Vector3(-52.24037f, 6528.842f,  30.73396f)},
            {"Paleto Construction", new Vector3(26.92797f, 6537.122f, 30.71028f)},
            
            //Chumash
            {"1, Barbareno Rd", new Vector3(-3211.849f, 910.8498f, 13.4006f)},
            {"2, Barbareno Rd", new Vector3(-3224.321f, 924.4307f, 13.34095f)},
            {"3, Barbareno Rd", new Vector3(-3231.247f, 939.6669f, 13.11186f)},
            {"4, Barbareno Rd", new Vector3(-3234.242f, 948.2815f,  12.637f)},
            {"5, Barbareno Rd", new Vector3(-3237.597f, 1037.95f,  11.04516f)},
            {"6, Barbareno Rd", new Vector3(-3234.786f, 1048.164f, 10.59685f)},
            {"7, Barbareno Rd", new Vector3(-3220.452f, 1105.461f, 9.868454f)},
            {"8, Barbareno Rd", new Vector3(-3207.273f, 1145.073f, 9.274668f)},
            {"9, Barbareno Rd", new Vector3(-3200.611f, 1154.071f, 9.033388f)},
            {"10, Barbareno Rd", new Vector3(-3197.703f, 1160.322f, 9.175791f)},
            {"11, Barbareno Rd", new Vector3(-3192.209f, 1231.254f, 9.427773f)},
            {"12, Barbareno Rd", new Vector3(-3185.028f, 1268.382f, 11.8384f)},
            {"13, Barbareno Rd", new Vector3(-3181.019f, 1276.593f, 12.11902f)},
            {"14, Barbareno Rd", new Vector3(-3180.106f, 1291.094f, 13.75161f)},

            {"1, Banhan Canyon Drive", new Vector3(-2553.082f, 1910.833f, 168.5262f)},
            {"2, Banhan Canyon Drive", new Vector3(-2715.649f, 1503.586f, 106.105f)},
            
            //Paleto Bay
            {"1, Cascabel Ave", new Vector3(-437.1996f, 6205.438f, 29.1012f)},
            {"2, Cascabel Ave", new Vector3(-432.1314f, 6260.438f, 29.84059f)},
            {"3, Cascabel Ave", new Vector3(-395.4925f, 6311.301f, 28.5273f)},
            {"4, Cascabel Ave", new Vector3(-360.447f, 6328.029f, 29.35445f)},
            {"5, Cascabel Ave", new Vector3(-264.2781f, 6404.894f, 30.47615f)},
            {"6, Cascabel Ave", new Vector3(-251.0345f, 6408.37f, 30.68022f)},
            {"7, Cascabel Ave", new Vector3(-233.4752f, 6442.413f, 30.71827f)},
            {"8, Cascabel Ave", new Vector3(-205.4888f, 6453.938f, 30.69845f)},
            {"9, Cascabel Ave", new Vector3(-114.1223f, 6567.726f, 29.03829f)},
            {"10, Cascabel Ave", new Vector3(-54.84253f, 6620.829f, 29.4078f)},
            {"11, Cascabel Ave", new Vector3(-16.48298f, 6644.723f, 30.62761f)},
            {"12, Cascabel Ave", new Vector3(20.66886f, 6661.849f, 31.04355f)},
            {"13, Cascabel Ave", new Vector3(47.85926f, 6654.813f, 31.19673f)},
            {"14, Cascabel Ave", new Vector3(-5.198745f, 6618.464f, 30.97839f)},
            {"15, Cascabel Ave", new Vector3(-9.520984f, 6599.613f, 30.99115f)},
            {"16, Cascabel Ave", new Vector3(-37.4807f, 6588.921f, 30.32194f)},
            {"17, Cascabel Ave", new Vector3(-106.5001f, 6536.43f, 29.32896f)},
            {"18, Cascabel Ave", new Vector3(-188.084f, 6418.685f, 31.38438f)},
            {"19, Cascabel Ave", new Vector3(-202.066f, 6402.208f, 31.38381f)},
            {"20, Cascabel Ave", new Vector3(-222.3919f, 6386.497f, 31.13121f)},
            {"21, Cascabel Ave", new Vector3(-255.3375f, 6360.006f, 30.99852f)},
            {"22, Cascabel Ave", new Vector3(-268.6179f, 6356.134f, 32.01083f)},
            {"23, Cascabel Ave", new Vector3(-295.6166f, 6339.602f, 31.65967f)},
            {"24, Cascabel Ave", new Vector3(-316.6695f, 6316.825f, 31.55431f)},
            {"25, Cascabel Ave", new Vector3(-358.0006f, 6271.684f, 30.56602f)},
            {"26, Cascabel Ave", new Vector3(-387.8622f, 6273.429f, 29.65719f)},
            {"27, Cascabel Ave", new Vector3(-479.6858f, 6259.572f, 12.80877f)},
            {"28, Cascabel Ave", new Vector3(-440.8952f, 6341.271f, 12.42345f)},
            {"29, Cascabel Ave", new Vector3(-412.3551f, 6368.135f, 13.28723f)},
            {"30, Cascabel Ave", new Vector3(286.5044f, 6789.307f, 15.39496f)},

            {"1, Paleto Ave", new Vector3(-381.8387f, 6187.443f, 30.92131f)},
            {"2, Paleto Ave", new Vector3(-365.2847f, 6196.111f, 30.92459f)},
            {"3, Paleto Ave", new Vector3(-345.8088f, 6213.335f, 30.91991f)},
            {"4, Paleto Ave", new Vector3(-7.55228f, 6560.165f, 31.40331f)},
            {"5, Paleto Ave", new Vector3(13.8656f, 6583.648f, 31.89132f)},
            {"6, Paleto Ave", new Vector3(35.98609f, 6606.544f, 31.89842f)},
        };

        foreach (KeyValuePair<string, Vector3> location in teleportDict)
        {
            var buttonTeleportToLocation = new MenuButton(location.Key);
            buttonTeleportToLocation.Activated += (sender, args) => TeleportToLocation(location);
            teleportMenuItems.Add(buttonTeleportToLocation);
        }

        var mainMenu = new ListMenu("Locations", teleportMenuItems.ToArray(), 15);
        DrawMenu(mainMenu);
    }
}
   
