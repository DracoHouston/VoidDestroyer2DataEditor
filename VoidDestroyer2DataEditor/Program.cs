using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace VoidDestroyer2DataEditor
{

    [TypeConverter(typeof(Vector3DConverter))]
    class Vector3D
    {
        float _x;
        public float x
        {
            get => _x;
            set => _x = value;
        }
        float _y;
        public float y
        {
            get => _y;
            set => _y = value;
        }
        float _z;
        public float z
        {
            get => _z;
            set => _z = value;
        }

        public Vector3D()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }

        public Vector3D(float magnitude)
        {
            _x = magnitude;
            _y = magnitude;
            _z = magnitude;
        }

        public Vector3D(float inX, float inY, float inZ)
        {
            _x = inX;
            _y = inY;
            _z = inZ;
        }

        public Vector3D(Vector3D inCopyFrom)
        {
            _x = inCopyFrom.x;
            _y = inCopyFrom.y;
            _z = inCopyFrom.z;
        }

        public override string ToString()
        {
            return x.ToString() + "," + y.ToString() + "," + z.ToString();
        }
    }

    [TypeConverter(typeof(Vector3DConverter))]
    class ColorF
    {
        float _r;
        public float r
        {
            get => _r;
            set => _r = value;
        }
        float _g;
        public float g
        {
            get => _g;
            set => _g = value;
        }
        float _b;
        public float b
        {
            get => _b;
            set => _b = value;
        }
        float _a;
        public float a
        {
            get => _a;
            set => _a = value;
        }

        public ColorF()
        {
            _r = 0;
            _g = 0;
            _b = 0;
            _a = 0;
        }

        public ColorF(float magnitude, float alpha = 1)
        {
            _r = magnitude;
            _g = magnitude;
            _b = magnitude;
            _a = alpha;
        }

        public ColorF(float inR, float inG, float inB, float inA)
        {
            _r = inR;
            _g = inG;
            _b = inB;
            _a = inA;
        }

        public ColorF(ColorF inCopyFrom)
        {
            _r = inCopyFrom.r;
            _g = inCopyFrom.g;
            _b = inCopyFrom.b;
            _a = inCopyFrom.a;
        }

        public override string ToString()
        {
            return r.ToString() + "," + g.ToString() + "," + b.ToString() + "," + a.ToString();
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //VD2LoadCodeGenerator.GenerateCodeFilesFromXMLFiles();
            
            //C:\Steam\steamapps\common\Void Destroyer 2\Data\Ships\Destroyers
            //ShipData mendozadata = new ShipData("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Destroyers\\Mendoza.xml");
            /*List<Dictionary<string, TagNameReportEntry>> rootreports = new List<Dictionary<string, TagNameReportEntry>>();
            List<Dictionary<string, Dictionary<string, TagNameReportEntry>>> childreports = new List<Dictionary<string, Dictionary<string, TagNameReportEntry>>>();
            Dictionary<string, TagNameReportEntry> fighterroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> fighterchildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Fighters", "FightersReport", out fighterroottagresults, out fighterchildtagresults);
            rootreports.Add(fighterroottagresults);
            childreports.Add(fighterchildtagresults);
            Dictionary<string, TagNameReportEntry> droneroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> dronechildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Drones", "DronesReport", out droneroottagresults, out dronechildtagresults);
            rootreports.Add(droneroottagresults);
            childreports.Add(dronechildtagresults);
            Dictionary<string, TagNameReportEntry> gunshiproottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> gunshipchildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\GunShips", "GunshipsReport", out gunshiproottagresults, out gunshipchildtagresults);
            rootreports.Add(gunshiproottagresults);
            childreports.Add(gunshipchildtagresults);
            Dictionary<string, TagNameReportEntry> corvetteroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> corvettechildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Corvettes", "CorvettesReport", out corvetteroottagresults, out corvettechildtagresults);
            rootreports.Add(corvetteroottagresults);
            childreports.Add(corvettechildtagresults);
            Dictionary<string, TagNameReportEntry> frigateroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> frigatechildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Frigates", "FrigatesReport", out frigateroottagresults, out frigatechildtagresults);
            rootreports.Add(frigateroottagresults);
            childreports.Add(frigatechildtagresults);
            Dictionary<string, TagNameReportEntry> destroyerroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> destroyerchildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Destroyers", "DestroyersReport", out destroyerroottagresults, out destroyerchildtagresults);
            rootreports.Add(destroyerroottagresults);
            childreports.Add(destroyerchildtagresults);
            Dictionary<string, TagNameReportEntry> cruiserroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> cruiserchildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Cruisers", "CruisersReport", out cruiserroottagresults, out cruiserchildtagresults);
            rootreports.Add(cruiserroottagresults);
            childreports.Add(cruiserchildtagresults);
            Dictionary<string, TagNameReportEntry> carrierroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> carrierchildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Carriers", "CarriersReport", out carrierroottagresults, out carrierchildtagresults);
            rootreports.Add(carrierroottagresults);
            childreports.Add(carrierchildtagresults);
            Dictionary<string, TagNameReportEntry> dreadroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> dreadchildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Dread", "DreadnaughtsReport", out dreadroottagresults, out dreadchildtagresults);
            rootreports.Add(dreadroottagresults);
            childreports.Add(dreadchildtagresults);
            ParseHelpers.CombinedTagReport(rootreports, childreports, "ShipsTotalReport");
            rootreports.Clear();
            childreports.Clear();
            Dictionary<string, TagNameReportEntry> primaryupgraderoottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> primaryupgradechildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Upgrades", "PrimaryUpgradesReport", out primaryupgraderoottagresults, out primaryupgradechildtagresults);
            rootreports.Add(primaryupgraderoottagresults);
            childreports.Add(primaryupgradechildtagresults);
            Dictionary<string, TagNameReportEntry> activeupgraderoottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> activeupgradechildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Upgrades\\Active", "ActiveUpgradesReport", out activeupgraderoottagresults, out activeupgradechildtagresults);
            rootreports.Add(activeupgraderoottagresults);
            childreports.Add(activeupgradechildtagresults);
            ParseHelpers.CombinedTagReport(rootreports, childreports, "UpgradesTotalReport");
            rootreports.Clear();
            childreports.Clear();
            Dictionary<string, TagNameReportEntry> weaponsroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> weaponschildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons", "WeaponsReport", out weaponsroottagresults, out weaponschildtagresults);
            rootreports.Add(weaponsroottagresults);
            childreports.Add(weaponschildtagresults);
            Dictionary<string, TagNameReportEntry> ammoroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> ammochildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Ammo", "AmmoReport", out ammoroottagresults, out ammochildtagresults);
            rootreports.Add(ammoroottagresults);
            childreports.Add(ammochildtagresults);
            Dictionary<string, TagNameReportEntry> hangarsroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> hangarschildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Hangars", "HangarsReport", out hangarsroottagresults, out hangarschildtagresults);
            rootreports.Add(hangarsroottagresults);
            childreports.Add(hangarschildtagresults);
            Dictionary<string, TagNameReportEntry> launchersroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> launcherschildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Launchers", "LaunchersReport", out launchersroottagresults, out launcherschildtagresults);
            rootreports.Add(launchersroottagresults);
            childreports.Add(launcherschildtagresults);
            Dictionary<string, TagNameReportEntry> Minesroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> Mineschildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Mines", "MinesReport", out Minesroottagresults, out Mineschildtagresults);
            rootreports.Add(Minesroottagresults);
            childreports.Add(Mineschildtagresults);
            Dictionary<string, TagNameReportEntry> Missilesroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> Missileschildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Missiles", "MissilesReport", out Missilesroottagresults, out Missileschildtagresults);
            rootreports.Add(Missilesroottagresults);
            childreports.Add(Missileschildtagresults);
            Dictionary<string, TagNameReportEntry> Turretsroottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> Turretschildtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            ParseHelpers.GetTagNameListWithUseNumberReportFromXMLFiles("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Turrets", "TurretsReport", out Turretsroottagresults, out Turretschildtagresults);
            rootreports.Add(Turretsroottagresults);
            childreports.Add(Turretschildtagresults);
            ParseHelpers.CombinedTagReport(rootreports, childreports, "WeaponsTotalReport");*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainEditorForm());
        }
    }
}
