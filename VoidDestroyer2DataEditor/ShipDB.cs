using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace VoidDestroyer2DataEditor
{
    class ShipDB
    {
        /*public Dictionary<string, ShipData> Ships;

        


        public ShipDB()
        {
            Ships = new Dictionary<string, ShipData>();
            //STEAM LETS PEOPLE INSTALL SHIT TO OTHER DRIVES ETC
            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 369530
            //reg key for uninstalling the game, contains install path
            string SteamPath = (string) Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "C:\\Program Files (x86)\\Steam");
            string VD2Path = SteamPath + "\\steamapps\\common\\Void Destroyer 2";
            string VD2DataPath = VD2Path + "\\Data";

            string VD2FightersDataPath = VD2DataPath + "\\Ships\\Fighters";
            List<string> fighters = Directory.EnumerateFiles(VD2FightersDataPath).ToList();
            for (int i = 0; i < fighters.Count; i++)
            {
                if (fighters[i].EndsWith(".xml"))
                {
                    string shipname = fighters[i].Substring(VD2FightersDataPath.Length + 1, (fighters[i].Length - VD2FightersDataPath.Length) - 5);
                    Ships.Add(shipname, new ShipData(fighters[i]));
                }
            }

            string VD2DronesDataPath = VD2DataPath + "\\Ships\\Drones";
            List<string> drones = Directory.EnumerateFiles(VD2DronesDataPath).ToList();
            for (int i = 0; i < drones.Count; i++)
            {
                if (drones[i].EndsWith(".xml"))
                {
                    string shipname = drones[i].Substring(VD2DronesDataPath.Length + 1, (drones[i].Length - VD2DronesDataPath.Length) - 5);
                    Ships.Add(shipname, new ShipData(drones[i]));
                }
            }

            string VD2GunshipsDataPath = VD2DataPath + "\\Ships\\GunShips";
            List<string> gunships = Directory.EnumerateFiles(VD2GunshipsDataPath).ToList();
            for (int i = 0; i < gunships.Count; i++)
            {
                if (gunships[i].EndsWith(".xml"))
                {
                    string shipname = gunships[i].Substring(VD2GunshipsDataPath.Length + 1, (gunships[i].Length - VD2GunshipsDataPath.Length) - 5);
                    Ships.Add(shipname, new ShipData(gunships[i]));
                }
            }

            string VD2CorvettesDataPath = VD2DataPath + "\\Ships\\Corvettes";
            List<string> corvettes = Directory.EnumerateFiles(VD2CorvettesDataPath).ToList();
            for (int i = 0; i < corvettes.Count; i++)
            {
                if (corvettes[i].EndsWith(".xml"))
                {
                    string shipname = corvettes[i].Substring(VD2CorvettesDataPath.Length + 1, (corvettes[i].Length - VD2CorvettesDataPath.Length) - 5);
                    Ships.Add(shipname, new ShipData(corvettes[i]));
                }
            }

            string VD2FrigatesDataPath = VD2DataPath + "\\Ships\\Frigates";
            List<string> frigates = Directory.EnumerateFiles(VD2FrigatesDataPath).ToList();
            for (int i = 0; i < frigates.Count; i++)
            {
                if (frigates[i].EndsWith(".xml"))
                {
                    string shipname = frigates[i].Substring(VD2FrigatesDataPath.Length + 1, (frigates[i].Length - VD2FrigatesDataPath.Length) - 5);
                    Ships.Add(shipname, new ShipData(frigates[i]));
                }
            }

            string VD2DestroyersDataPath = VD2DataPath + "\\Ships\\Destroyers";
            List<string> destroyers = Directory.EnumerateFiles(VD2DestroyersDataPath).ToList();
            for (int i = 0; i < destroyers.Count; i++)
            {
                if (destroyers[i].EndsWith(".xml"))
                {
                    string shipname = destroyers[i].Substring(VD2DestroyersDataPath.Length + 1, (destroyers[i].Length - VD2DestroyersDataPath.Length) - 5);
                    Ships.Add(shipname, new ShipData(destroyers[i]));
                }
            }

            string VD2CruisersDataPath = VD2DataPath + "\\Ships\\Cruisers";
            List<string> cruisers = Directory.EnumerateFiles(VD2CruisersDataPath).ToList();
            for (int i = 0; i < cruisers.Count; i++)
            {
                if (cruisers[i].EndsWith(".xml"))
                {
                    string shipname = cruisers[i].Substring(VD2CruisersDataPath.Length + 1, (cruisers[i].Length - VD2CruisersDataPath.Length) - 5);
                    Ships.Add(shipname, new ShipData(cruisers[i]));
                }
            }

            string VD2CarriersDataPath = VD2DataPath + "\\Ships\\Carriers";
            List<string> carriers = Directory.EnumerateFiles(VD2CarriersDataPath).ToList();
            for (int i = 0; i < carriers.Count; i++)
            {
                if (carriers[i].EndsWith(".xml"))
                {
                    string shipname = carriers[i].Substring(VD2CarriersDataPath.Length + 1, (carriers[i].Length - VD2CarriersDataPath.Length) - 5);
                    Ships.Add(shipname, new ShipData(carriers[i]));
                }
            }

            string VD2DreadDataPath = VD2DataPath + "\\Ships\\Dread";
            List<string> dread = Directory.EnumerateFiles(VD2DreadDataPath).ToList();
            for (int i = 0; i < dread.Count; i++)
            {
                if (dread[i].EndsWith(".xml"))
                {
                    string shipname = dread[i].Substring(VD2DreadDataPath.Length + 1, (dread[i].Length - VD2DreadDataPath.Length) - 5);
                    Ships.Add(shipname, new ShipData(dread[i]));
                }
            }
        }*/
        /*
        public void OutputShipNameClassSizeSizeclassReport(bool ascsv)
        {
            List<ShipData> drones = new List<ShipData>();
            List<ShipData> lightfighters = new List<ShipData>();
            List<ShipData> lightgunships = new List<ShipData>();
            List<ShipData> lightcorvettes = new List<ShipData>();
            List<ShipData> lightfrigates = new List<ShipData>();
            List<ShipData> lightdestroyers = new List<ShipData>();
            List<ShipData> lightcruisers = new List<ShipData>();
            List<ShipData> lightcarriers = new List<ShipData>();
            List<ShipData> lightdreads = new List<ShipData>();
            List<ShipData> mediumfighters = new List<ShipData>();
            List<ShipData> mediumgunships = new List<ShipData>();
            List<ShipData> mediumcorvettes = new List<ShipData>();
            List<ShipData> mediumfrigates = new List<ShipData>();
            List<ShipData> mediumdestroyers = new List<ShipData>();
            List<ShipData> mediumcruisers = new List<ShipData>();
            List<ShipData> mediumcarriers = new List<ShipData>();
            List<ShipData> mediumdreads = new List<ShipData>();
            List<ShipData> heavyfighters = new List<ShipData>();
            List<ShipData> heavygunships = new List<ShipData>();
            List<ShipData> heavycorvettes = new List<ShipData>();
            List<ShipData> heavyfrigates = new List<ShipData>();
            List<ShipData> heavydestroyers = new List<ShipData>();
            List<ShipData> heavycruisers = new List<ShipData>();
            List<ShipData> heavycarriers = new List<ShipData>();
            List<ShipData> heavydreads = new List<ShipData>();
            List<ShipData> transports = new List<ShipData>();
            List<ShipData> miners = new List<ShipData>();
            List<ShipData> shuttles = new List<ShipData>();
            List<ShipData> repairs = new List<ShipData>();
            List<ShipData> shipcaptures = new List<ShipData>();
            List<ShipData> basecaptures = new List<ShipData>();
            List<ShipData> builders = new List<ShipData>();
            int i = 0;
            for (i = 0; i < Ships.Count; i++)
            {
                ShipData currentship = Ships.ElementAt(i).Value;
                if (currentship.shipClass == "fighter")
                {
                    if (currentship.shipClassSize == "light")
                    {
                        lightfighters.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "medium")
                    {
                        mediumfighters.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "heavy")
                    {
                        heavyfighters.Add(currentship);
                    }
                }
                else if (currentship.shipClass == "fighter_drone")
                {
                    drones.Add(currentship);
                }
                else if (currentship.shipClass == "gunship")
                {
                    if (currentship.shipClassSize == "light")
                    {
                        lightgunships.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "medium")
                    {
                        mediumgunships.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "heavy")
                    {
                        heavygunships.Add(currentship);
                    }
                }
                else if (currentship.shipClass == "corvette")
                {
                    if (currentship.shipClassSize == "light")
                    {
                        lightcorvettes.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "medium")
                    {
                        mediumcorvettes.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "heavy")
                    {
                        heavycorvettes.Add(currentship);
                    }
                }
                else if (currentship.shipClass == "frigate")
                {
                    if (currentship.shipClassSize == "light")
                    {
                        lightfrigates.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "medium")
                    {
                        mediumfrigates.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "heavy")
                    {
                        heavyfrigates.Add(currentship);
                    }
                }
                else if (currentship.shipClass == "destroyer")
                {
                    if (currentship.shipClassSize == "light")
                    {
                        lightdestroyers.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "medium")
                    {
                        mediumdestroyers.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "heavy")
                    {
                        heavydestroyers.Add(currentship);
                    }
                }
                else if (currentship.shipClass == "cruiser")
                {
                    if (currentship.shipClassSize == "light")
                    {
                        lightcruisers.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "medium")
                    {
                        mediumcruisers.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "heavy")
                    {
                        heavycruisers.Add(currentship);
                    }
                }
                else if (currentship.shipClass == "carrier")
                {
                    if (currentship.shipClassSize == "light")
                    {
                        lightcarriers.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "medium")
                    {
                        mediumcarriers.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "heavy")
                    {
                        heavycarriers.Add(currentship);
                    }
                }
                else if (currentship.shipClass == "dreadnaught")
                {
                    if (currentship.shipClassSize == "light")
                    {
                        lightdreads.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "medium")
                    {
                        mediumdreads.Add(currentship);
                    }
                    else if (currentship.shipClassSize == "heavy")
                    {
                        heavydreads.Add(currentship);
                    }
                }
                else if (currentship.shipClass == "transport")
                {
                    transports.Add(currentship);
                }
                else if (currentship.shipClass == "mining")
                {
                    miners.Add(currentship);
                }
                else if (currentship.shipClass == "shuttle")
                {
                    shuttles.Add(currentship);
                }
                else if (currentship.shipClass == "repair")
                {
                    repairs.Add(currentship);
                }
                else if (currentship.shipClass == "capture")
                {
                    basecaptures.Add(currentship);
                }
                else if (currentship.shipClass == "ship_capture")
                {
                    shipcaptures.Add(currentship);
                }
                else if (currentship.shipClass == "builder")
                {
                    builders.Add(currentship);
                }
            }
            List<string> reporttextlines = new List<string>();
            reporttextlines.Add("Ship List");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");

            reporttextlines.Add("Combat Ships");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");

            reporttextlines.Add("Drones");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < drones.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(drones[i].name + "," + drones[i].objectID + "," + drones[i].faction);
                }
                else
                {
                    reporttextlines.Add(drones[i].name + ", objectID: " + drones[i].objectID + " Faction: " + drones[i].faction);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Fighters");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Light Fighters");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < lightfighters.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(lightfighters[i].name + "," + lightfighters[i].objectID + "," + lightfighters[i].faction);
                }
                else
                {
                    reporttextlines.Add(lightfighters[i].name + ", objectID: " + lightfighters[i].objectID + " Faction: " + lightfighters[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Medium Fighters");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < mediumfighters.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(mediumfighters[i].name + "," + mediumfighters[i].objectID + "," + mediumfighters[i].faction);
                }
                else
                {
                    reporttextlines.Add(mediumfighters[i].name + ", objectID: " + mediumfighters[i].objectID + " Faction: " + mediumfighters[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Heavy Fighters");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < heavyfighters.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(heavyfighters[i].name + "," + heavyfighters[i].objectID + "," + heavyfighters[i].faction);
                }
                else
                {
                    reporttextlines.Add(heavyfighters[i].name + ", objectID: " + heavyfighters[i].objectID + " Faction: " + heavyfighters[i].faction);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Gun Ships");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Light Gun Ships");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < lightgunships.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(lightgunships[i].name + "," + lightgunships[i].objectID + "," + lightgunships[i].faction);
                }
                else
                {
                    reporttextlines.Add(lightgunships[i].name + ", objectID: " + lightgunships[i].objectID + " Faction: " + lightgunships[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Medium Gun Ships");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < mediumgunships.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(mediumgunships[i].name + "," + mediumgunships[i].objectID + "," + mediumgunships[i].faction);
                }
                else
                {
                    reporttextlines.Add(mediumgunships[i].name + ", objectID: " + mediumgunships[i].objectID + " Faction: " + mediumgunships[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Heavy Gun Ships");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < heavygunships.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(heavygunships[i].name + "," + heavygunships[i].objectID + "," + heavygunships[i].faction);
                }
                else
                {
                    reporttextlines.Add(heavygunships[i].name + ", objectID: " + heavygunships[i].objectID + " Faction: " + heavygunships[i].faction);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Corvettes");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Light Corvettes");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < lightcorvettes.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(lightcorvettes[i].name + "," + lightcorvettes[i].objectID + "," + lightcorvettes[i].faction);
                }
                else
                {
                    reporttextlines.Add(lightcorvettes[i].name + ", objectID: " + lightcorvettes[i].objectID + " Faction: " + lightcorvettes[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Medium Corvettes");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < mediumcorvettes.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(mediumcorvettes[i].name + "," + mediumcorvettes[i].objectID + "," + mediumcorvettes[i].faction);
                }
                else
                {
                    reporttextlines.Add(mediumcorvettes[i].name + ", objectID: " + mediumcorvettes[i].objectID + " Faction: " + mediumcorvettes[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Heavy Corvettes");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < heavycorvettes.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(heavycorvettes[i].name + "," + heavycorvettes[i].objectID + "," + heavycorvettes[i].faction);
                }
                else
                {
                    reporttextlines.Add(heavycorvettes[i].name + ", objectID: " + heavycorvettes[i].objectID + " Faction: " + heavycorvettes[i].faction);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Frigates");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Light Frigates");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < lightfrigates.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(lightfrigates[i].name + "," + lightfrigates[i].objectID + "," + lightfrigates[i].faction);
                }
                else
                {
                    reporttextlines.Add(lightfrigates[i].name + ", objectID: " + lightfrigates[i].objectID + " Faction: " + lightfrigates[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Medium Frigates");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < mediumfrigates.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(mediumfrigates[i].name + "," + mediumfrigates[i].objectID + "," + mediumfrigates[i].faction);
                }
                else
                {
                    reporttextlines.Add(mediumfrigates[i].name + ", objectID: " + mediumfrigates[i].objectID + " Faction: " + mediumfrigates[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Heavy Frigates");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < heavyfrigates.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(heavyfrigates[i].name + "," + heavyfrigates[i].objectID + "," + heavyfrigates[i].faction);
                }
                else
                {
                    reporttextlines.Add(heavyfrigates[i].name + ", objectID: " + heavyfrigates[i].objectID + " Faction: " + heavyfrigates[i].faction);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Destroyers");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Light Destroyers");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < lightdestroyers.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(lightdestroyers[i].name + "," + lightdestroyers[i].objectID + "," + lightdestroyers[i].faction);
                }
                else
                {
                    reporttextlines.Add(lightdestroyers[i].name + ", objectID: " + lightdestroyers[i].objectID + " Faction: " + lightdestroyers[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Medium Destroyers");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < mediumdestroyers.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(mediumdestroyers[i].name + "," + mediumdestroyers[i].objectID + "," + mediumdestroyers[i].faction);
                }
                else
                {
                    reporttextlines.Add(mediumdestroyers[i].name + ", objectID: " + mediumdestroyers[i].objectID + " Faction: " + mediumdestroyers[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Heavy Destroyers");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < heavydestroyers.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(heavydestroyers[i].name + "," + heavydestroyers[i].objectID + "," + heavydestroyers[i].faction);
                }
                else
                {
                    reporttextlines.Add(heavydestroyers[i].name + ", objectID: " + heavydestroyers[i].objectID + " Faction: " + heavydestroyers[i].faction);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Cruisers");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Light Cruisers");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < lightcruisers.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(lightcruisers[i].name + "," + lightcruisers[i].objectID + "," + lightcruisers[i].faction);
                }
                else
                {
                    reporttextlines.Add(lightcruisers[i].name + ", objectID: " + lightcruisers[i].objectID + " Faction: " + lightcruisers[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Medium Cruisers");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < mediumcruisers.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(mediumcruisers[i].name + "," + mediumcruisers[i].objectID + "," + mediumcruisers[i].faction);
                }
                else
                {
                    reporttextlines.Add(mediumcruisers[i].name + ", objectID: " + mediumcruisers[i].objectID + " Faction: " + mediumcruisers[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Heavy Cruisers");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < heavycruisers.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(heavycruisers[i].name + "," + heavycruisers[i].objectID + "," + heavycruisers[i].faction);
                }
                else
                {
                    reporttextlines.Add(heavycruisers[i].name + ", objectID: " + heavycruisers[i].objectID + " Faction: " + heavycruisers[i].faction);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Carriers");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Light Carriers");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < lightcarriers.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(lightcarriers[i].name + "," + lightcarriers[i].objectID + "," + lightcarriers[i].faction);
                }
                else
                {
                    reporttextlines.Add(lightcarriers[i].name + ", objectID: " + lightcarriers[i].objectID + " Faction: " + lightcarriers[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Medium Carriers");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < mediumcarriers.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(mediumcarriers[i].name + "," + mediumcarriers[i].objectID + "," + mediumcarriers[i].faction);
                }
                else
                {
                    reporttextlines.Add(mediumcarriers[i].name + ", objectID: " + mediumcarriers[i].objectID + " Faction: " + mediumcarriers[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Heavy Carriers");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < heavycarriers.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(heavycarriers[i].name + "," + heavycarriers[i].objectID + "," + heavycarriers[i].faction);
                }
                else
                {
                    reporttextlines.Add(heavycarriers[i].name + ", objectID: " + heavycarriers[i].objectID + " Faction: " + heavycarriers[i].faction);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Dreadnaughts");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Light Dreadnaughts");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < lightdreads.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(lightdreads[i].name + "," + lightdreads[i].objectID + "," + lightdreads[i].faction);
                }
                else
                {
                    reporttextlines.Add(lightdreads[i].name + ", objectID: " + lightdreads[i].objectID + " Faction: " + lightdreads[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Medium Dreadnaughts");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < mediumdreads.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(mediumdreads[i].name + "," + mediumdreads[i].objectID + "," + mediumdreads[i].faction);
                }
                else
                {
                    reporttextlines.Add(mediumdreads[i].name + ", objectID: " + mediumdreads[i].objectID + " Faction: " + mediumdreads[i].faction);
                }
            }
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Heavy Dreadnaughts");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction");
            }
            for (i = 0; i < heavydreads.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(heavydreads[i].name + "," + heavydreads[i].objectID + "," + heavydreads[i].faction);
                }
                else
                {
                    reporttextlines.Add(heavydreads[i].name + ", objectID: " + heavydreads[i].objectID + " Faction: " + heavydreads[i].faction);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Non Combat Ships");

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Transports");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction,sizeShipClass,shipClassSize");
            }
            for (i = 0; i < transports.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(transports[i].name + "," + transports[i].objectID + "," + transports[i].faction + "," + transports[i].sizeShipClass + "," + transports[i].shipClassSize);
                }
                else
                {
                    reporttextlines.Add(transports[i].name + ", objectID: " + transports[i].objectID + " Faction: " + transports[i].faction + " Class: " + transports[i].shipClassSize + " " + transports[i].sizeShipClass);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Miners");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction,sizeShipClass,shipClassSize");
            }
            for (i = 0; i < miners.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(miners[i].name + "," + miners[i].objectID + "," + miners[i].faction + "," + miners[i].sizeShipClass + "," + miners[i].shipClassSize);
                }
                else
                {
                    reporttextlines.Add(miners[i].name + ", objectID: " + miners[i].objectID + " Faction: " + miners[i].faction + " Class: " + miners[i].shipClassSize + " " + miners[i].sizeShipClass);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Shuttles");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction,sizeShipClass,shipClassSize");
            }
            for (i = 0; i < shuttles.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(shuttles[i].name + "," + shuttles[i].objectID + "," + shuttles[i].faction + "," + shuttles[i].sizeShipClass + "," + shuttles[i].shipClassSize);
                }
                else
                {
                    reporttextlines.Add(shuttles[i].name + ", objectID: " + shuttles[i].objectID + " Faction: " + shuttles[i].faction + " Class: " + shuttles[i].shipClassSize + " " + shuttles[i].sizeShipClass);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Repair");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction,sizeShipClass,shipClassSize");
            }
            for (i = 0; i < repairs.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(repairs[i].name + "," + repairs[i].objectID + "," + repairs[i].faction + "," + repairs[i].sizeShipClass + "," + repairs[i].shipClassSize);
                }
                else
                {
                    reporttextlines.Add(repairs[i].name + ", objectID: " + repairs[i].objectID + " Faction: " + repairs[i].faction + " Class: " + repairs[i].shipClassSize + " " + repairs[i].sizeShipClass);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Base Capture");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction,sizeShipClass,shipClassSize");
            }
            for (i = 0; i < basecaptures.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(basecaptures[i].name + "," + basecaptures[i].objectID + "," + basecaptures[i].faction + "," + basecaptures[i].sizeShipClass + "," + basecaptures[i].shipClassSize);
                }
                else
                {
                    reporttextlines.Add(basecaptures[i].name + ", objectID: " + basecaptures[i].objectID + " Faction: " + basecaptures[i].faction + " Class: " + basecaptures[i].shipClassSize + " " + basecaptures[i].sizeShipClass);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Ship Capture");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction,sizeShipClass,shipClassSize");
            }
            for (i = 0; i < shipcaptures.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(shipcaptures[i].name + "," + shipcaptures[i].objectID + "," + shipcaptures[i].faction + "," + shipcaptures[i].sizeShipClass + "," + shipcaptures[i].shipClassSize);
                }
                else
                {
                    reporttextlines.Add(shipcaptures[i].name + ", objectID: " + shipcaptures[i].objectID + " Faction: " + shipcaptures[i].faction + " Class: " + shipcaptures[i].shipClassSize + " " + shipcaptures[i].sizeShipClass);
                }
            }

            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("");
            reporttextlines.Add("Builders");
            reporttextlines.Add("");
            if (ascsv)
            {
                reporttextlines.Add("name,objectID,faction,sizeShipClass,shipClassSize");
            }
            for (i = 0; i < builders.Count; i++)
            {
                if (ascsv)
                {
                    reporttextlines.Add(builders[i].name + "," + builders[i].objectID + "," + builders[i].faction + "," + builders[i].sizeShipClass + "," + builders[i].shipClassSize);
                }
                else
                {
                    reporttextlines.Add(builders[i].name + ", objectID: " + builders[i].objectID + " Faction: " + builders[i].faction + " Class: " + builders[i].shipClassSize + " " + builders[i].sizeShipClass);
                }
            }
            if (ascsv)
            {
                File.WriteAllLines("ShipsListReportCSV", reporttextlines);
            }
            else
            {
                File.WriteAllLines("ShipsListReport", reporttextlines);
            }            
        }
        */
    }
}
