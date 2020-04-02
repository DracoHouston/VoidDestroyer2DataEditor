using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    class EditorUI
    {
        private static EditorUI Instance = null;

        public MainEditorForm EditorForm;

        public EditorModes CurrentEditorMode;

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
            ReloadData();
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
        }

        public DialogResult GetVD2PathUsingDialog(out string outPath)
        {
            DialogResult result = EditorForm.VD2PathFinderDialog.ShowDialog();
            string pathonly = "";
            if (result == DialogResult.OK)
            {
                pathonly = EditorForm.VD2PathFinderDialog.FileName.Substring(0, EditorForm.VD2PathFinderDialog.FileName.Length - "Void Destroyer 2.exe".Length);                
            }
            outPath = pathonly;
            return result;
        }
    }
}
