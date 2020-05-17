using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace VoidDestroyer2DataEditor
{
    public enum Vector3DElements
    {
        x,
        y,
        z
    }

    public class Vector3DElementChangedEventArgs : EventArgs
    {
        public Vector3DElements ChangedElement;
        public float OldValue;
        public float NewValue;
    }

    public enum ColorFElements
    {
        r,
        g,
        b,
        a
    }

    public class ColorFElementChangedEventArgs : EventArgs
    {
        public ColorFElements ChangedElement;
        public float OldValue;
        public float NewValue;
    }

    [TypeConverter(typeof(Vector3DConverter))]
    public class Vector3D
    {
        public event EventHandler<Vector3DElementChangedEventArgs> OnElementChanged;

        float _x;
        public float x
        {
            get
            {
                return _x;
            }
            set
            {                
                Vector3DElementChangedEventArgs e = new Vector3DElementChangedEventArgs();
                e.ChangedElement = Vector3DElements.x;
                e.OldValue = _x;
                e.NewValue = value;
                _x = value;
                OnElementChanged?.Invoke(this, e);                
            }
        }
        float _y;
        public float y
        {
            get
            {
                return _y;
            }
            set
            {
                Vector3DElementChangedEventArgs e = new Vector3DElementChangedEventArgs();
                e.ChangedElement = Vector3DElements.y;
                e.OldValue = _y;
                e.NewValue = value;
                _y = value;
                OnElementChanged?.Invoke(this, e);
            }
        }
        float _z;
        public float z
        {
            get
            {
                return _z;
            }
            set
            {
                Vector3DElementChangedEventArgs e = new Vector3DElementChangedEventArgs();
                e.ChangedElement = Vector3DElements.z;
                e.OldValue = _z;
                e.NewValue = value;
                _z = value;
                OnElementChanged?.Invoke(this, e);
            }
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
    public class ColorF
    {
        public event EventHandler<ColorFElementChangedEventArgs> OnElementChanged;

        float _r;
        public float r
        {
            get
            {
                return _r;
            }
            set
            {
                ColorFElementChangedEventArgs e = new ColorFElementChangedEventArgs();
                e.ChangedElement = ColorFElements.r;
                e.OldValue = _r;
                e.NewValue = value;
                _r = value;
                OnElementChanged?.Invoke(this, e);
            }
        }
        float _g;
        public float g
        {
            get
            {
                return _g;
            }
            set
            {
                ColorFElementChangedEventArgs e = new ColorFElementChangedEventArgs();
                e.ChangedElement = ColorFElements.g;
                e.OldValue = _g;
                e.NewValue = value;
                _g = value;
                OnElementChanged?.Invoke(this, e);
            }
        }
        float _b;
        public float b
        {
            get
            {
                return _b;
            }
            set
            {
                ColorFElementChangedEventArgs e = new ColorFElementChangedEventArgs();
                e.ChangedElement = ColorFElements.b;
                e.OldValue = _b;
                e.NewValue = value;
                _b = value;
                OnElementChanged?.Invoke(this, e);
            }
        }
        float _a;
        public float a
        {
            get
            {
                return _a;
            }
            set
            {
                ColorFElementChangedEventArgs e = new ColorFElementChangedEventArgs();
                e.ChangedElement = ColorFElements.a;
                e.OldValue = _a;
                e.NewValue = value;
                _a = value;
                OnElementChanged?.Invoke(this, e);
            }
        }

        public ColorF()
        {
            _r = 0;
            _g = 0;
            _b = 0;
            _a = 0;
        }

        public ColorF(float intensity, float alpha = 1)
        {
            _r = intensity;
            _g = intensity;
            _b = intensity;
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


            //UNCOMMENT TO RUN THE LOAD CODE GENERATOR (most of the source files in /Data/) you can find the results alongside the exe
            //VD2LoadCodeGenerator.GenerateCodeFilesFromXMLFiles();


            //UNCOMMENT TO RUN TAG NAME REPORTS ON THE BASE DATA, creates human readable versions of the information the code generator goes off.
            //results can be found as extensionless text files alongside the exe
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
            //Application.Run(new MainEditorForm());
            if (!EditorUserSettings.UserSettings.InitUserSettings())
            {
                return;
            }

            if  (!OgreRenderer.Renderer.InitEditorRendererSubsystem())
            {
                return;
            }
            /*OgreRenderer.Renderer.InitOgre();

            if (OgreRenderer.Renderer.OgreRoot == null)
            {
                return;
            }*/

            SplashScreenForm splash = new SplashScreenForm();
            splash.ShowDialog();

            
            MainEditorForm mainform = new MainEditorForm();
            //Application.Run(mainform);
            mainform.Show();

            
            while (OgreRenderer.Renderer.EditorRS.IsActive() && OgreRenderer.Renderer.EditorRS.Render())
            {
                Application.DoEvents();
            }
        }
    }
}
