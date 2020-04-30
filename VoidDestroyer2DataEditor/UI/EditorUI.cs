using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Drawing;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    class EditorUI
    {
        private static EditorUI Instance = null;

        public MainEditorForm EditorForm;

        public EditorModes CurrentEditorMode;

        public SoundPlayer WavPlayer;

        public OpenFileDialog VD2PathFinderDialog;

        public VD2DB<ShipData> Ships;
        public VD2DB<PrimaryUpgradeData> PrimaryUpgrades;
        public VD2DB<ActiveUpgradeData> ActiveUpgrades;
        public VD2DB<WeaponData> Weapons;
        public VD2DB<AmmoData> Ammo;
        public VD2DB<HangarData> Hangars;
        public VD2DB<LauncherData> Launchers;
        public VD2DB<MineData> Mines;
        public VD2DB<MissileData> Missiles;
        public VD2DB<TurretData> Turrets;
        public VD2DB<AreaOfEffectData> AreaOfEffect;
        public VD2DB<AsteroidData> Asteroids;
        public VD2DB<BaseData> Bases;
        public VD2DB<CharacterData> Characters;
        public VD2DB<CockpitData> Cockpits;
        public VD2DB<DebrisData> Debris;
        public VD2DB<DialogData> Dialog;
        public VD2DB<DockedMovingElementData> DockedMovingElements;
        public VD2DB<DoorData> Doors;
        public VD2DB<EffectData> Effects;
        public VD2DB<ParticleData> Particles;
        public VD2DB<ExplosionData> Explosions;
        public VD2DB<FactionData> Factions;
        public VD2DB<MusicData> Music;
        public VD2DB<OtherObjectData> OtherObjects;
        public VD2DB<ShieldData> Shields;
        public VD2DB<SkyboxData> Skyboxes;
        public VD2DB<SoundData> Sounds;
        public VD2DB<StationData> Stations;
        public VD2DB<SunData> Suns;
        public MeshDB Models;
        public ImageSetDB ImageSets;

        public static EditorUI UI
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new EditorUI();
                }
                return Instance;
            }
        }

        private EditorUI()
        {
            WavPlayer = new SoundPlayer();
            VD2PathFinderDialog = new OpenFileDialog();
            VD2PathFinderDialog.DefaultExt = "exe";
            VD2PathFinderDialog.FileName = "Void Destroyer 2.exe";
            VD2PathFinderDialog.Filter = "Void Destroyer 2.exe|Void Destroyer 2.exe";
            VD2PathFinderDialog.InitialDirectory = "MyComputer";
            VD2PathFinderDialog.Title = "Please find your \'Void Destroyer 2.exe\'";
        }

        public static bool ExploreFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return false;
            }
            //Clean up file path so it can be navigated OK
            filePath = System.IO.Path.GetFullPath(filePath);
            System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));
            return true;
        }

        public static Point GetEditorFormLocationFromNestedLocation(Control inControl)
        {
            Point result = new Point();
            if (inControl != null)
            {
                Control currentcontrol = inControl;
                while (currentcontrol.Parent != null)
                {
                    result.X += currentcontrol.Location.X;
                    result.Y += currentcontrol.Location.Y;
                    currentcontrol = currentcontrol.Parent;
                }
            }

            return result;
        }

        public void InitUI(MainEditorForm inEditorForm)
        {
            EditorForm = inEditorForm;
            CurrentEditorMode = EditorModes.BaseReadOnly;
            //ReloadData();
        }

        public void ReloadData()
        {
            List<string> ShipsSubFolders = new List<string>();
            ShipsSubFolders.Add("Drones");
            ShipsSubFolders.Add("Fighters");
            ShipsSubFolders.Add("GunShips");
            ShipsSubFolders.Add("Corvettes");
            ShipsSubFolders.Add("Frigates");
            ShipsSubFolders.Add("Destroyers");
            ShipsSubFolders.Add("Cruisers");
            ShipsSubFolders.Add("Carriers");
            ShipsSubFolders.Add("Dread");
            Ships = new VD2DB<ShipData>("Ships", ShipsSubFolders);
            Ships.LoadData();
            PrimaryUpgrades = new VD2DB<PrimaryUpgradeData>("Ships\\Upgrades");
            PrimaryUpgrades.LoadData();
            ActiveUpgrades = new VD2DB<ActiveUpgradeData>("Ships\\Upgrades\\Active");
            ActiveUpgrades.LoadData();
            Weapons = new VD2DB<WeaponData>("Weapons");
            Weapons.LoadData();
            Turrets = new VD2DB<TurretData>("Weapons\\Turrets");
            Turrets.LoadData();
            Launchers = new VD2DB<LauncherData>("Weapons\\Launchers");
            Launchers.LoadData();
            Hangars = new VD2DB<HangarData>("Weapons\\Hangars");
            Hangars.LoadData();
            Ammo = new VD2DB<AmmoData>("Weapons\\Ammo");
            Ammo.LoadData();
            Missiles = new VD2DB<MissileData>("Weapons\\Missiles");
            Missiles.LoadData();
            Mines = new VD2DB<MineData>("Weapons\\Mines");
            Mines.LoadData();
            AreaOfEffect = new VD2DB<AreaOfEffectData>("AreaOfEffect");
            AreaOfEffect.LoadData();
            Asteroids = new VD2DB<AsteroidData>("Asteroids");
            Asteroids.LoadData();
            Bases = new VD2DB<BaseData>("Bases");
            Bases.LoadData();
            Characters = new VD2DB<CharacterData>("Characters");
            Characters.LoadData();
            Cockpits = new VD2DB<CockpitData>("Cockpits");
            Cockpits.LoadData();
            Debris = new VD2DB<DebrisData>("Debris");
            Debris.LoadData();
            Dialog = new VD2DB<DialogData>("Dialog");
            Dialog.LoadData();
            DockedMovingElements = new VD2DB<DockedMovingElementData>("DockedMovingElements");
            DockedMovingElements.LoadData();
            Doors = new VD2DB<DoorData>("Doors");
            Doors.LoadData();
            Effects = new VD2DB<EffectData>("Effects");
            Effects.LoadData();
            Particles = new VD2DB<ParticleData>("Effects\\Particles");
            Particles.LoadData();
            Explosions = new VD2DB<ExplosionData>("Explosions");
            Explosions.LoadData();
            Factions = new VD2DB<FactionData>("Factions");
            Factions.LoadData();
            Music = new VD2DB<MusicData>("Music");
            Music.LoadData();
            OtherObjects = new VD2DB<OtherObjectData>("Other");
            OtherObjects.LoadData();
            Shields = new VD2DB<ShieldData>("Shields");
            Shields.LoadData();
            Skyboxes = new VD2DB<SkyboxData>("Skyboxes");
            Skyboxes.LoadData();
            List<string> SoundsSubFolders = new List<string>();
            SoundsSubFolders.Add("Dialog");
            SoundsSubFolders.Add("Interior");
            SoundsSubFolders.Add("UI");
            Sounds = new VD2DB<SoundData>("Sounds", SoundsSubFolders);
            Sounds.LoadData();
            Stations = new VD2DB<StationData>("Stations");
            Stations.LoadData();
            Suns = new VD2DB<SunData>("Suns");
            Suns.LoadData();
            Models = new MeshDB();
            Models.LoadData();
            ImageSets = new ImageSetDB();
            ImageSets.LoadData();
        }

        public DialogResult GetVD2PathUsingDialog(out string outPath)
        {
            DialogResult result = VD2PathFinderDialog.ShowDialog();
            string pathonly = "";
            if (result == DialogResult.OK)
            {
                pathonly = VD2PathFinderDialog.FileName.Substring(0, VD2PathFinderDialog.FileName.Length - "Void Destroyer 2.exe".Length);                
            }
            outPath = pathonly;
            return result;
        }

        public List<string> GetObjectIDListForType(string inTypeName)
        {
            List<string> result = new List<string>();
            switch (inTypeName)
            {
                case "Ship":
                    foreach (VD2Data datafile in Ships.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "PrimaryUpgrade":
                    foreach (VD2Data datafile in PrimaryUpgrades.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "ActiveUpgrade":
                    foreach (VD2Data datafile in ActiveUpgrades.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Weapon":
                    foreach (VD2Data datafile in Weapons.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Turret":
                    foreach (VD2Data datafile in Turrets.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Launcher":
                    foreach (VD2Data datafile in Launchers.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Hangar":
                    foreach (VD2Data datafile in Hangars.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Ammo":
                    foreach (VD2Data datafile in Ammo.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Missile":
                    foreach (VD2Data datafile in Missiles.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Mine":
                    foreach (VD2Data datafile in Mines.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "AreaOfEffect":
                    foreach (VD2Data datafile in AreaOfEffect.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Asteroid":
                    foreach (VD2Data datafile in Asteroids.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Base":
                    foreach (VD2Data datafile in Bases.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Character":
                    foreach (VD2Data datafile in Characters.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Cockpit":
                    foreach (VD2Data datafile in Cockpits.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Debris":
                    foreach (VD2Data datafile in Debris.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Dialog":
                    foreach (VD2Data datafile in Dialog.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "DockedMovingElement":
                    foreach (VD2Data datafile in DockedMovingElements.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Door":
                    foreach (VD2Data datafile in Doors.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Effect":
                    foreach (VD2Data datafile in Effects.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Particle":
                    foreach (VD2Data datafile in Particles.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Explosion":
                    foreach (VD2Data datafile in Explosions.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Faction":
                    foreach (VD2Data datafile in Factions.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Music":
                    foreach (VD2Data datafile in Music.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Other":
                    foreach (VD2Data datafile in OtherObjects.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Shield":
                    foreach (VD2Data datafile in Shields.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Skybox":
                    foreach (VD2Data datafile in Skyboxes.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Sound":
                    foreach (VD2Data datafile in Sounds.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Station":
                    foreach (VD2Data datafile in Stations.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Sun":
                    foreach (VD2Data datafile in Suns.Data.Values)
                    {
                        result.Add(datafile.GetObjectID());
                    }
                    break;
                case "Mesh":
                    foreach (MeshDocument datafile in Models.Data.Values)
                    {
                        result.Add(datafile.MeshName);
                    }
                    break;
                case "ImageSet":
                    foreach (ImageSetDocument datafile in ImageSets.Data.Values)
                    {
                        result.Add(datafile.ImageSetName);
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        public static bool GetParentVD2DataIsReadOnly(Control inControl)
        {
            Control c = inControl;
            while (c.Parent != null)
            {
                if (c.Parent is DataDocumentControl)
                {
                    DataDocumentControl datadocparent = (DataDocumentControl)c.Parent;
                    if (datadocparent.DataFile != null)
                    {
                        if (datadocparent.DataFile.Source != null)
                        {
                            return !datadocparent.DataFile.Source.WriteAccess;
                        }
                    }
                    break;
                }
                c = c.Parent;
            }
            return true;
        }

        public static string GetParentVD2DataFileSourceShortName(Control inControl)
        {
            Control c = inControl;
            while (c.Parent != null)
            {
                if (c.Parent is DataDocumentControl)
                {
                    DataDocumentControl datadocparent = (DataDocumentControl)c.Parent;
                    if (datadocparent.DataFile != null)
                    {
                        if (datadocparent.DataFile.Source != null)
                        {
                            return datadocparent.DataFile.Source.ShortName;
                        }
                    }
                    break;
                }
                c = c.Parent;
            }
            return "";
        }
    }
}
