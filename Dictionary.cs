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
    //WEAPONS
    Dictionary<WeaponHash, int> melee = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.Bat, 1}, {WeaponHash.Knife, 1}, {WeaponHash.Nightstick, 1}, {WeaponHash.Crowbar, 1}, {WeaponHash.GolfClub, 1}, {WeaponHash.Hammer, 1}, {WeaponHash.Dagger, 1}, {WeaponHash.Hatchet, 1},
        
    };

    Dictionary<WeaponHash, int> pistols = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.Pistol, 1}, {WeaponHash.CombatPistol, 1}, {WeaponHash.APPistol, 1}, {WeaponHash.Pistol50, 1}, {WeaponHash.StunGun, 1}, {WeaponHash.HeavyPistol, 1}, {WeaponHash.SNSPistol, 1}, {WeaponHash.VintagePistol, 1}, {WeaponHash.Firework, 1}, 
        
    };

    Dictionary<WeaponHash, int> smg = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.MicroSMG, 1}, {WeaponHash.SMG, 1}, {WeaponHash.AssaultSMG, 1}, {WeaponHash.CombatPDW, 1}, 
        
    };

    Dictionary<WeaponHash, int> shotgun = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.PumpShotgun, 1}, {WeaponHash.SawnOffShotgun, 1}, {WeaponHash.AssaultShotgun, 1}, {WeaponHash.BullpupShotgun, 1}, {WeaponHash.HeavyShotgun, 1}, {WeaponHash.Musket, 1},
        
    };

    Dictionary<WeaponHash, int> rifle = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.AssaultRifle, 1}, {WeaponHash.CarbineRifle, 1}, {WeaponHash.AdvancedRifle, 1}, {WeaponHash.SpecialCarbine, 1}, {WeaponHash.BullpupRifle, 1},
        
    };

    Dictionary<WeaponHash, int> machineGun = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.Gusenberg, 1}, {WeaponHash.CombatMG, 1}, {WeaponHash.MG, 1},
        
    };

    Dictionary<WeaponHash, int> sniper = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.SniperRifle, 1}, {WeaponHash.HeavySniper, 1},  {WeaponHash.MarksmanRifle, 1},
        
    };

    Dictionary<WeaponHash, int> heavy = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.RPG, 1}, {WeaponHash.GrenadeLauncher, 1}, {WeaponHash.Minigun, 1}, {WeaponHash.Firework, 1}, {WeaponHash.Railgun, 1}, {WeaponHash.HomingLauncher, 1},
        
    };

    Dictionary<WeaponHash, int> thrown = new Dictionary<WeaponHash, int>() 
    {
        {WeaponHash.StickyBomb, 1}, {WeaponHash.Grenade, 1}, {WeaponHash.SmokeGrenade, 1}, {WeaponHash.Molotov, 1}, {WeaponHash.ProximityMine, 1}, {WeaponHash.Snowball, 1}, {WeaponHash.PetrolCan, 1},
        
    };

    //VEHICLES
    Dictionary<VehicleHash, int> SuperVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Adder, 1}, {VehicleHash.Bullet, 1}, {VehicleHash.Cheetah, 1}, {VehicleHash.EntityXF, 1}, {VehicleHash.Infernus, 1}, {VehicleHash.Osiris, 1}, {VehicleHash.Turismor, 1}, {VehicleHash.Vacca, 1}, {VehicleHash.Voltic, 1}, {VehicleHash.Zentorno, 1},
    };

    Dictionary<VehicleHash, int> motorCycleVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Akuma, 1}, {VehicleHash.Bagger, 1}, {VehicleHash.Bati, 1}, {VehicleHash.Bati2, 1}, {VehicleHash.CarbonRS, 1}, {VehicleHash.Daemon, 1}, {VehicleHash.Double, 1}, {VehicleHash.Enduro, 1}, {VehicleHash.Faggio2, 1}, {VehicleHash.Hakuchou, 1}, {VehicleHash.Hexer, 1}, {VehicleHash.Innovation, 1}, {VehicleHash.Lectro, 1}, {VehicleHash.Nemesis, 1}, {VehicleHash.PCJ, 1}, {VehicleHash.Ruffian, 1}, {VehicleHash.Sanchez, 1}, {VehicleHash.Sovereign, 1}, {VehicleHash.Thrust, 1}, {VehicleHash.Vader, 1},
    };

    Dictionary<VehicleHash, int> coupeVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.CogCabrio, 1}, {VehicleHash.Exemplar, 1}, {VehicleHash.F620, 1}, {VehicleHash.Felon, 1}, {VehicleHash.Felon2, 1}, {VehicleHash.Jackal, 1}, {VehicleHash.Oracle, 1}, {VehicleHash.Sentinel, 1}, {VehicleHash.Sentinel2, 1}, {VehicleHash.Windsor, 1}, {VehicleHash.Zion, 1}, {VehicleHash.Zion2, 1},
    };

    Dictionary<VehicleHash, int> compactVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Blista, 1}, {VehicleHash.Dilettante, 1}, {VehicleHash.Issi2, 1}, {VehicleHash.Panto, 1}, {VehicleHash.Prairie, 1}, {VehicleHash.Rhapsody, 1},
    };

    Dictionary<VehicleHash, int> sedanVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Asea, 1}, {VehicleHash.Asterope, 1}, {VehicleHash.Emperor, 1}, {VehicleHash.Fugitive, 1}, {VehicleHash.Glendale, 1}, {VehicleHash.Ingot, 1}, {VehicleHash.Intruder, 1}, {VehicleHash.Premier, 1}, {VehicleHash.Primo, 1}, {VehicleHash.Regina, 1}, {VehicleHash.Romero, 1}, {VehicleHash.Schafter2, 1}, {VehicleHash.Stanier, 1}, {VehicleHash.Stratum, 1}, {VehicleHash.Stretch, 1}, {VehicleHash.Superd, 1}, {VehicleHash.Surge, 1}, {VehicleHash.Tailgater, 1}, {VehicleHash.Warrener, 1}, {VehicleHash.Washington, 1},
    };

    Dictionary<VehicleHash, int> sportsVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Ninef, 1}, {VehicleHash.Ninef2, 1}, {VehicleHash.Alpha, 1}, {VehicleHash.Banshee, 1}, {VehicleHash.Blista, 1}, {VehicleHash.Buffalo, 1}, {VehicleHash.Buffalo2, 1}, {VehicleHash.Carbonizzare, 1}, {VehicleHash.Comet2, 1}, {VehicleHash.Coquette, 1}, {VehicleHash.Elegy2, 1}, {VehicleHash.Feltzer2, 1}, {VehicleHash.Furoregt, 1}, {VehicleHash.Fusilade, 1}, {VehicleHash.Futo, 1}, {VehicleHash.Blista2, 1}, {VehicleHash.Jester, 1}, {VehicleHash.Jester2, 1}, {VehicleHash.Khamelion, 1}, {VehicleHash.Kuruma, 1}, {VehicleHash.Massacro, 1}, {VehicleHash.Massacro2, 1}, {VehicleHash.Penumbra, 1}, {VehicleHash.RapidGT, 1}, {VehicleHash.RapidGT2, 1}, {VehicleHash.Schwarzer, 1}, {VehicleHash.Sultan, 1}, {VehicleHash.Surano, 1},
    };

    Dictionary<VehicleHash, int> sportClassicVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Casco, 1}, {VehicleHash.Coquette2, 1}, {VehicleHash.JB700, 1}, {VehicleHash.Manana, 1}, {VehicleHash.Monroe, 1}, {VehicleHash.Peyote, 1}, {VehicleHash.Pigalle, 1}, {VehicleHash.Ztype, 1}, {VehicleHash.Stinger, 1}, {VehicleHash.StingerGT, 1}, {VehicleHash.Tornado, 1}, 
    };

    Dictionary<VehicleHash, int> muscleVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Blade, 1}, {VehicleHash.Stalion2, 1}, {VehicleHash.Buccaneer, 1}, {VehicleHash.Dominator, 1}, {VehicleHash.Dukes2, 1}, {VehicleHash.Dukes, 1}, {VehicleHash.Gauntlet, 1}, {VehicleHash.Hotknife, 1}, {VehicleHash.Phoenix, 1}, {VehicleHash.Picador, 1}, {VehicleHash.Dominator2, 1}, {VehicleHash.RatLoader, 1}, {VehicleHash.RatLoader2, 1}, {VehicleHash.Gauntlet2, 1}, {VehicleHash.Ruiner, 1}, {VehicleHash.SabreGT, 1}, {VehicleHash.SlamVan, 1}, {VehicleHash.Buffalo3, 1}, {VehicleHash.Stalion, 1}, {VehicleHash.Vigero, 1}, {VehicleHash.Voodoo2, 1}, 
    };

    Dictionary<VehicleHash, int> offroadVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Bifta, 1}, {VehicleHash.Blazer, 1}, {VehicleHash.Blazer2, 1}, {VehicleHash.Bodhi2, 1}, {VehicleHash.Dubsta3, 1}, {VehicleHash.Dune, 1}, {VehicleHash.Dune2, 1}, {VehicleHash.Blazer3, 1}, {VehicleHash.BfInjection, 1}, {VehicleHash.Insurgent, 1}, {VehicleHash.Kalahari, 1}, {VehicleHash.Marshall, 1}, {VehicleHash.Mesa, 1}, {VehicleHash.RancherXL, 1}, {VehicleHash.Rebel, 1}, {VehicleHash.Sandking2, 1}, {VehicleHash.Technical, 1}, {VehicleHash.Monster, 1}, 
    };

    Dictionary<VehicleHash, int> suvVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Baller, 1}, {VehicleHash.BJXL, 1}, {VehicleHash.Cavalcade, 1}, {VehicleHash.Dubsta2, 1}, {VehicleHash.Fq2, 1}, {VehicleHash.Granger, 1}, {VehicleHash.Gresley, 1}, {VehicleHash.Habanero, 1}, {VehicleHash.Huntley, 1}, {VehicleHash.Landstalker, 1}, {VehicleHash.Mesa2, 1}, {VehicleHash.Patriot, 1}, {VehicleHash.Radi, 1}, {VehicleHash.Rocoto, 1}, {VehicleHash.Seminole, 1}, {VehicleHash.Serrano, 1}, 
    };

    Dictionary<VehicleHash, int> vanVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Bison, 1}, {VehicleHash.BobcatXL, 1}, {VehicleHash.Boxville, 1}, {VehicleHash.Burrito, 1}, {VehicleHash.Camper, 1}, {VehicleHash.GBurrito, 1}, {VehicleHash.Journey, 1}, {VehicleHash.Minivan, 1}, {VehicleHash.Paradise, 1}, {VehicleHash.Pony, 1}, {VehicleHash.Rumpo, 1}, {VehicleHash.Speedo, 1}, {VehicleHash.Surfer, 1}, {VehicleHash.Taco, 1}, {VehicleHash.Youga, 1},
    };

    Dictionary<VehicleHash, int> industrialVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Cutter, 1}, {VehicleHash.DockTrailer, 1}, {VehicleHash.Bulldozer, 1}, {VehicleHash.Dump, 1}, {VehicleHash.Flatbed, 1}, {VehicleHash.Guardian, 1}, {VehicleHash.Mixer, 1}, {VehicleHash.Rubble, 1}, {VehicleHash.TipTruck, 1}, 
    };

    Dictionary<VehicleHash, int> commercialVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Benson, 1}, {VehicleHash.Biff, 1}, {VehicleHash.Hauler, 1}, {VehicleHash.Mule, 1}, {VehicleHash.Packer, 1}, {VehicleHash.Phantom, 1}, {VehicleHash.Stockade, 1}, 
    };
    /*
    Dictionary<VehicleHash, int> utilityVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Airtug, 1}, {VehicleHash.Caddy, 1}, {VehicleHash.Docktug, 1}, {VehicleHash.Tractor, 1}, {VehicleHash.Mower, 1}, {VehicleHash.Ripley, 1}, {VehicleHash.Sadler, 1}, {VehicleHash.Scrap, 1}, {VehicleHash.TowTruck, 1}, {VehicleHash.TowTruck2, 1}, {VehicleHash.Tractor2, 1}, {VehicleHash.UtilityTruck, 1}, {VehicleHash.UtilliTruck, 1},
    };
    */
    Dictionary<VehicleHash, int> militaryVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Barracks, 1}, {VehicleHash.Barracks2, 1}, {VehicleHash.Crusader, 1}, {VehicleHash.Rhino, 1}, 
    };

    Dictionary<VehicleHash, int> emergencyVeh = new Dictionary<VehicleHash, int>() //bother with it later
    {
        {VehicleHash.Alpha, 1}, 
    };

    Dictionary<VehicleHash, int> planeVeh = new Dictionary<VehicleHash, int>()
    {
        {VehicleHash.Blimp, 1}, {VehicleHash.CargoPlane, 1}, {VehicleHash.Cuban800, 1}, {VehicleHash.Dodo, 1}, {VehicleHash.Duster, 1}, {VehicleHash.Hydra, 1}, {VehicleHash.Jet, 1}, {VehicleHash.Luxor, 1}, {VehicleHash.Luxor2, 1}, {VehicleHash.Mammatus, 1}, {VehicleHash.Miljet, 1}, {VehicleHash.Lazer, 1}, {VehicleHash.Shamal, 1}, {VehicleHash.Titan, 1}, {VehicleHash.Velum, 1}, {VehicleHash.Vestra, 1}, {VehicleHash.Blimp2, 1}, 
    };

    Dictionary<VehicleHash, int> helicopterVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Annihilator, 1}, {VehicleHash.Buzzard, 1}, {VehicleHash.Buzzard2, 1}, {VehicleHash.Cargobob, 1}, {VehicleHash.Frogger, 1}, {VehicleHash.Maverick, 1}, {VehicleHash.Savage, 1}, {VehicleHash.Skylift, 1}, {VehicleHash.Swift, 1}, {VehicleHash.Swift2, 1}, {VehicleHash.Valkyrie, 1},
    };

    Dictionary<VehicleHash, int> boatVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Dinghy, 1}, {VehicleHash.Jetmax, 1}, {VehicleHash.Submersible2, 1}, {VehicleHash.Marquis, 1}, {VehicleHash.Seashark, 1}, {VehicleHash.Speeder, 1}, {VehicleHash.Squalo, 1}, {VehicleHash.Submersible, 1}, {VehicleHash.Suntrap, 1}, {VehicleHash.Tropic, 1}, 
    };

    Dictionary<VehicleHash, int> serviceVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Airbus, 1}, {VehicleHash.Bus, 1}, {VehicleHash.PBus, 1}, {VehicleHash.RentalBus, 1}, {VehicleHash.Taxi, 1}, {VehicleHash.Tourbus, 1}, {VehicleHash.Trash, 1},
    };

    Dictionary<VehicleHash, int> cycleVeh = new Dictionary<VehicleHash, int>() 
    {
        {VehicleHash.Bmx, 1}, {VehicleHash.Cruiser, 1}, {VehicleHash.TriBike, 1}, {VehicleHash.Scorcher, 1}, {VehicleHash.TriBike2, 1}, {VehicleHash.TriBike3, 1}, 
    };
}
