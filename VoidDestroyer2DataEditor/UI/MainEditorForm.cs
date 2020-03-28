using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    //the order of this enum and the base nodes hard coded below must match!
    enum ShipClassIndex
    {
        fighter,
        gunship,
        corvette,
        frigate,
        destroyer,
        cruiser,
        carrier,
        dreadnaught,
        fighter_drone
    };
    enum ShipClassSizeIndex
    {
        light,
        medium,
        heavy
    };
    
    enum WeaponTypeIndex
    {
        projectile,
        instant,
        beam,
        collision,
        shield,
        tractor_beam,
        speed,
        ecm,
        ship_shooter,
        release_attached_ship
    };

    public partial class MainEditorForm : Form
    {
        private VD2DB<ShipData> Ships;
        private VD2DB<PrimaryUpgradeData> PrimaryUpgrades;
        private VD2DB<ActiveUpgradeData> ActiveUpgrades;
        private VD2DB<WeaponData> Weapons;
        private VD2DB<AmmoData> Ammo;
        private VD2DB<HangarData> Hangars;
        private VD2DB<LauncherData> Launchers;
        private VD2DB<MineData> Mines;
        private VD2DB<MissileData> Missiles;
        private VD2DB<TurretData> Turrets;
        private VD2DB<AreaOfEffectData> AreaOfEffect;
        private VD2DB<AsteroidData> Asteroids;
        private VD2DB<BaseData> Bases;
        private VD2DB<CharacterData> Characters;
        private VD2DB<CockpitData> Cockpits;
        private VD2DB<DebrisData> Debris;
        private VD2DB<DialogData> Dialog;
        private VD2DB<DockedMovingElementData> DockedMovingElements;
        private VD2DB<DoorData> Doors;
        private VD2DB<EffectData> Effects;
        private VD2DB<ParticleData> Particles;
        private VD2DB<ExplosionData> Explosions;
        private VD2DB<FactionData> Factions;
        private VD2DB<MusicData> Music;
        private VD2DB<OtherObjectData> OtherObjects;
        private VD2DB<ShieldData> Shields;
        private VD2DB<SkyboxData> Skyboxes;
        private VD2DB<SoundData> Sounds;
        private VD2DB<StationData> Stations;
        private VD2DB<SunData> Suns;
        public MainEditorForm()
        {
            InitializeComponent();
        }

        public void PopulateShipsTree()
        {
            ShipsTree.Nodes.Clear();
            ShipsTree.Nodes.Add("Combat Ships");
            ShipsTree.Nodes[0].Nodes.Add("Fighters");
            ShipsTree.Nodes[0].Nodes[0].Nodes.Add("Light");
            ShipsTree.Nodes[0].Nodes[0].Nodes.Add("Medium");
            ShipsTree.Nodes[0].Nodes[0].Nodes.Add("Heavy");
            ShipsTree.Nodes[0].Nodes.Add("GunShips");
            ShipsTree.Nodes[0].Nodes[1].Nodes.Add("Light");
            ShipsTree.Nodes[0].Nodes[1].Nodes.Add("Medium");
            ShipsTree.Nodes[0].Nodes[1].Nodes.Add("Heavy");
            ShipsTree.Nodes[0].Nodes.Add("Corvettes");
            ShipsTree.Nodes[0].Nodes[2].Nodes.Add("Light");
            ShipsTree.Nodes[0].Nodes[2].Nodes.Add("Medium");
            ShipsTree.Nodes[0].Nodes[2].Nodes.Add("Heavy");
            ShipsTree.Nodes[0].Nodes.Add("Frigates");
            ShipsTree.Nodes[0].Nodes[3].Nodes.Add("Light");
            ShipsTree.Nodes[0].Nodes[3].Nodes.Add("Medium");
            ShipsTree.Nodes[0].Nodes[3].Nodes.Add("Heavy");
            ShipsTree.Nodes[0].Nodes.Add("Destroyers");
            ShipsTree.Nodes[0].Nodes[4].Nodes.Add("Light");
            ShipsTree.Nodes[0].Nodes[4].Nodes.Add("Medium");
            ShipsTree.Nodes[0].Nodes[4].Nodes.Add("Heavy");
            ShipsTree.Nodes[0].Nodes.Add("Cruisers");
            ShipsTree.Nodes[0].Nodes[5].Nodes.Add("Light");
            ShipsTree.Nodes[0].Nodes[5].Nodes.Add("Medium");
            ShipsTree.Nodes[0].Nodes[5].Nodes.Add("Heavy");
            ShipsTree.Nodes[0].Nodes.Add("Carriers");
            ShipsTree.Nodes[0].Nodes[6].Nodes.Add("Light");
            ShipsTree.Nodes[0].Nodes[6].Nodes.Add("Medium");
            ShipsTree.Nodes[0].Nodes[6].Nodes.Add("Heavy");
            ShipsTree.Nodes[0].Nodes.Add("Dread");
            ShipsTree.Nodes[0].Nodes[7].Nodes.Add("Light");
            ShipsTree.Nodes[0].Nodes[7].Nodes.Add("Medium");
            ShipsTree.Nodes[0].Nodes[7].Nodes.Add("Heavy");
            ShipsTree.Nodes[0].Nodes.Add("Drones");
            ShipsTree.Nodes.Add("Non Combat Ships");
            ShipsTree.Nodes[1].Nodes.Add("Transport"); 
            ShipsTree.Nodes[1].Nodes.Add("Mining");
            ShipsTree.Nodes[1].Nodes.Add("Shuttle");
            ShipsTree.Nodes[1].Nodes.Add("Repair");
            ShipsTree.Nodes[1].Nodes.Add("Base Capture");
            ShipsTree.Nodes[1].Nodes.Add("Ship Capture");
            ShipsTree.Nodes[1].Nodes.Add("Builder");
            ShipsTree.Nodes.Add("Upgrades");
            ShipsTree.Nodes[2].Nodes.Add("Primary Upgrades");
            ShipsTree.Nodes[2].Nodes.Add("Active Upgrades");
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
            //Ships.OutputShipNameClassSizeSizeclassReport(false);
            //Ships.OutputShipNameClassSizeSizeclassReport(true);
            int i = 0;
            for (i = 0; i < Ships.Data.Keys.Count; i++)
            {
                ShipData currentship;
                if (Ships.Data.TryGetValue(Ships.Data.Keys.ElementAt(i), out currentship))
                {
                    if (currentship.shipClass == "fighter")
                    {
                        if (currentship.shipClassSize == "light")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.fighter].Nodes[(int)ShipClassSizeIndex.light].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.fighter].Nodes[(int)ShipClassSizeIndex.medium].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.fighter].Nodes[(int)ShipClassSizeIndex.heavy].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                    }
                    else if (currentship.shipClass == "fighter_drone")
                    {
                        ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.fighter_drone].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                    }
                    else if (currentship.shipClass == "gunship")
                    {
                        if (currentship.shipClassSize == "light")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.gunship].Nodes[(int)ShipClassSizeIndex.light].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.gunship].Nodes[(int)ShipClassSizeIndex.medium].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.gunship].Nodes[(int)ShipClassSizeIndex.heavy].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                    }
                    else if (currentship.shipClass == "corvette")
                    {
                        if (currentship.shipClassSize == "light")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.corvette].Nodes[(int)ShipClassSizeIndex.light].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.corvette].Nodes[(int)ShipClassSizeIndex.medium].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.corvette].Nodes[(int)ShipClassSizeIndex.heavy].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                    }
                    else if (currentship.shipClass == "frigate")
                    {
                        if (currentship.shipClassSize == "light")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.frigate].Nodes[(int)ShipClassSizeIndex.light].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.frigate].Nodes[(int)ShipClassSizeIndex.medium].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.frigate].Nodes[(int)ShipClassSizeIndex.heavy].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                    }
                    else if (currentship.shipClass == "destroyer")
                    {
                        if (currentship.shipClassSize == "light")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.destroyer].Nodes[(int)ShipClassSizeIndex.light].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.destroyer].Nodes[(int)ShipClassSizeIndex.medium].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.destroyer].Nodes[(int)ShipClassSizeIndex.heavy].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                    }
                    else if (currentship.shipClass == "cruiser")
                    {
                        if (currentship.shipClassSize == "light")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.cruiser].Nodes[(int)ShipClassSizeIndex.light].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.cruiser].Nodes[(int)ShipClassSizeIndex.medium].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.cruiser].Nodes[(int)ShipClassSizeIndex.heavy].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                    }
                    else if (currentship.shipClass == "carrier")
                    {
                        if (currentship.shipClassSize == "light")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.carrier].Nodes[(int)ShipClassSizeIndex.light].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.carrier].Nodes[(int)ShipClassSizeIndex.medium].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.carrier].Nodes[(int)ShipClassSizeIndex.heavy].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                    }
                    else if (currentship.shipClass == "dreadnaught")
                    {
                        if (currentship.shipClassSize == "light")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.dreadnaught].Nodes[(int)ShipClassSizeIndex.light].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.dreadnaught].Nodes[(int)ShipClassSizeIndex.medium].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            ShipsTree.Nodes[0].Nodes[(int)ShipClassIndex.dreadnaught].Nodes[(int)ShipClassSizeIndex.heavy].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                        }
                    }
                    else if (currentship.shipClass == "transport")
                    {
                        ShipsTree.Nodes[1].Nodes[0].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                    }
                    else if (currentship.shipClass == "mining")
                    {
                        ShipsTree.Nodes[1].Nodes[1].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                    }
                    else if (currentship.shipClass == "shuttle")
                    {
                        ShipsTree.Nodes[1].Nodes[2].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                    }
                    else if (currentship.shipClass == "repair")
                    {
                        ShipsTree.Nodes[1].Nodes[3].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                    }
                    else if (currentship.shipClass == "capture")
                    {
                        ShipsTree.Nodes[1].Nodes[4].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                    }
                    else if (currentship.shipClass == "ship_capture")
                    {
                        ShipsTree.Nodes[1].Nodes[5].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                    }
                    else if (currentship.shipClass == "builder")
                    {
                        ShipsTree.Nodes[1].Nodes[6].Nodes.Add(Ships.Data.Keys.ElementAt(i));
                    }
                }
            }
            PrimaryUpgrades = new VD2DB<PrimaryUpgradeData>("Ships\\Upgrades");
            for (i = 0; i < PrimaryUpgrades.Data.Keys.Count; i++)
            {
                PrimaryUpgradeData currentprimary;
                if (PrimaryUpgrades.Data.TryGetValue(PrimaryUpgrades.Data.Keys.ElementAt(i), out currentprimary))
                {
                    ShipsTree.Nodes[2].Nodes[0].Nodes.Add(PrimaryUpgrades.Data.Keys.ElementAt(i));
                }
            }

            ActiveUpgrades = new VD2DB<ActiveUpgradeData>("Ships\\Upgrades\\Active");
            for (i = 0; i < ActiveUpgrades.Data.Keys.Count; i++)
            {
                ActiveUpgradeData currentactive;
                if (ActiveUpgrades.Data.TryGetValue(ActiveUpgrades.Data.Keys.ElementAt(i), out currentactive))
                {
                    ShipsTree.Nodes[2].Nodes[1].Nodes.Add(ActiveUpgrades.Data.Keys.ElementAt(i));
                }
            }
        }

        public void PopulateWeaponsTree()
        {
            WeaponsTree.Nodes.Clear();
            WeaponsTree.Nodes.Add("Weapons");
            WeaponsTree.Nodes[0].Nodes.Add("Projectile");
            WeaponsTree.Nodes[0].Nodes.Add("Instant");
            WeaponsTree.Nodes[0].Nodes.Add("Beam");
            WeaponsTree.Nodes[0].Nodes.Add("Collision");
            WeaponsTree.Nodes[0].Nodes.Add("Shield");
            WeaponsTree.Nodes[0].Nodes.Add("Tractor Beam");            
            WeaponsTree.Nodes[0].Nodes.Add("Speed");
            WeaponsTree.Nodes[0].Nodes.Add("ECM");
            WeaponsTree.Nodes[0].Nodes.Add("Ship Shooter");
            WeaponsTree.Nodes[0].Nodes.Add("Release Attached Ship");
            WeaponsTree.Nodes.Add("Ammo");
            WeaponsTree.Nodes.Add("Hangars");
            WeaponsTree.Nodes.Add("Launchers");
            WeaponsTree.Nodes.Add("Mines");
            WeaponsTree.Nodes.Add("Missiles");
            WeaponsTree.Nodes.Add("Turrets");
            Weapons = new VD2DB<WeaponData>("Weapons");
            int i = 0;
            for (i = 0; i < Weapons.Data.Keys.Count; i++)
            {
                WeaponData currentdata;
                if (Weapons.Data.TryGetValue(Weapons.Data.Keys.ElementAt(i), out currentdata))
                {
                    if (currentdata.weaponType == "projectile")
                    {
                        WeaponsTree.Nodes[0].Nodes[(int)WeaponTypeIndex.projectile].Nodes.Add(Weapons.Data.Keys.ElementAt(i));
                    }
                    else if (currentdata.weaponType == "instant")
                    {
                        WeaponsTree.Nodes[0].Nodes[(int)WeaponTypeIndex.instant].Nodes.Add(Weapons.Data.Keys.ElementAt(i));
                    }
                    else if (currentdata.weaponType == "beam")
                    {
                        WeaponsTree.Nodes[0].Nodes[(int)WeaponTypeIndex.beam].Nodes.Add(Weapons.Data.Keys.ElementAt(i));
                    }
                    else if (currentdata.weaponType == "collision")
                    {
                        WeaponsTree.Nodes[0].Nodes[(int)WeaponTypeIndex.collision].Nodes.Add(Weapons.Data.Keys.ElementAt(i));
                    }
                    else if (currentdata.weaponType == "shield")
                    {
                        WeaponsTree.Nodes[0].Nodes[(int)WeaponTypeIndex.shield].Nodes.Add(Weapons.Data.Keys.ElementAt(i));
                    }
                    else if (currentdata.weaponType == "tractor_beam")
                    {
                        WeaponsTree.Nodes[0].Nodes[(int)WeaponTypeIndex.tractor_beam].Nodes.Add(Weapons.Data.Keys.ElementAt(i));
                    }
                    else if (currentdata.weaponType == "speed")
                    {
                        WeaponsTree.Nodes[0].Nodes[(int)WeaponTypeIndex.speed].Nodes.Add(Weapons.Data.Keys.ElementAt(i));
                    }
                    else if (currentdata.weaponType == "ecm")
                    {
                        WeaponsTree.Nodes[0].Nodes[(int)WeaponTypeIndex.ecm].Nodes.Add(Weapons.Data.Keys.ElementAt(i));
                    }
                    else if (currentdata.weaponType == "ship_shooter")
                    {
                        WeaponsTree.Nodes[0].Nodes[(int)WeaponTypeIndex.ship_shooter].Nodes.Add(Weapons.Data.Keys.ElementAt(i));
                    }
                    else if (currentdata.weaponType == "release_attached_ship")
                    {
                        WeaponsTree.Nodes[0].Nodes[(int)WeaponTypeIndex.release_attached_ship].Nodes.Add(Weapons.Data.Keys.ElementAt(i));
                    }


                }
            }
            Ammo = new VD2DB<AmmoData>("Weapons\\Ammo");
            for (i = 0; i < Ammo.Data.Keys.Count; i++)
            {
                AmmoData currentdata;
                if (Ammo.Data.TryGetValue(Ammo.Data.Keys.ElementAt(i), out currentdata))
                {
                    WeaponsTree.Nodes[1].Nodes.Add(Ammo.Data.Keys.ElementAt(i));
                }
            }
            Hangars = new VD2DB<HangarData>("Weapons\\Hangars");
            for (i = 0; i < Hangars.Data.Keys.Count; i++)
            {
                HangarData currentdata;
                if (Hangars.Data.TryGetValue(Hangars.Data.Keys.ElementAt(i), out currentdata))
                {
                    WeaponsTree.Nodes[2].Nodes.Add(Hangars.Data.Keys.ElementAt(i));
                }
            }
            Launchers = new VD2DB<LauncherData>("Weapons\\Launchers");
            for (i = 0; i < Launchers.Data.Keys.Count; i++)
            {
                LauncherData currentdata;
                if (Launchers.Data.TryGetValue(Launchers.Data.Keys.ElementAt(i), out currentdata))
                {
                    WeaponsTree.Nodes[3].Nodes.Add(Launchers.Data.Keys.ElementAt(i));
                }
            }
            Mines = new VD2DB<MineData>("Weapons\\Mines");
            for (i = 0; i < Mines.Data.Keys.Count; i++)
            {
                MineData currentdata;
                if (Mines.Data.TryGetValue(Mines.Data.Keys.ElementAt(i), out currentdata))
                {
                    WeaponsTree.Nodes[4].Nodes.Add(Mines.Data.Keys.ElementAt(i));
                }
            }
            Missiles = new VD2DB<MissileData>("Weapons\\Missiles");
            for (i = 0; i < Missiles.Data.Keys.Count; i++)
            {
                MissileData currentdata;
                if (Missiles.Data.TryGetValue(Missiles.Data.Keys.ElementAt(i), out currentdata))
                {
                    WeaponsTree.Nodes[5].Nodes.Add(Missiles.Data.Keys.ElementAt(i));
                }
            }
            Turrets = new VD2DB<TurretData>("Weapons\\Turrets");
            for (i = 0; i < Turrets.Data.Keys.Count; i++)
            {
                TurretData currentdata;
                if (Turrets.Data.TryGetValue(Turrets.Data.Keys.ElementAt(i), out currentdata))
                {
                    WeaponsTree.Nodes[6].Nodes.Add(Turrets.Data.Keys.ElementAt(i));
                }
            }
        }

        public void PopulateAreaOfEffectTree()
        {
            AreaOfEffectTree.Nodes.Clear();
            AreaOfEffect = new VD2DB<AreaOfEffectData>("AreaOfEffect");
            int i = 0;
            for (i = 0; i < AreaOfEffect.Data.Keys.Count; i++)
            {
                AreaOfEffectTree.Nodes.Add(AreaOfEffect.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateAsteroidsTree()
        {
            AsteroidsTree.Nodes.Clear();
            Asteroids = new VD2DB<AsteroidData>("Asteroids");
            int i = 0;
            for (i = 0; i < Asteroids.Data.Keys.Count; i++)
            {
                AsteroidsTree.Nodes.Add(Asteroids.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateBasesTree()
        {
            BasesTree.Nodes.Clear();
            Bases = new VD2DB<BaseData>("Bases");
            int i = 0;
            for (i = 0; i < Bases.Data.Keys.Count; i++)
            {
                BasesTree.Nodes.Add(Bases.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateCharactersTree()
        {
            CharactersTree.Nodes.Clear();
            Characters = new VD2DB<CharacterData>("Characters");
            int i = 0;
            for (i = 0; i < Characters.Data.Keys.Count; i++)
            {
                CharactersTree.Nodes.Add(Characters.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateCockpitsTree()
        {
            CockpitsTree.Nodes.Clear();
            Cockpits = new VD2DB<CockpitData>("Cockpits");
            int i = 0;
            for (i = 0; i < Cockpits.Data.Keys.Count; i++)
            {
                CockpitsTree.Nodes.Add(Cockpits.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateDebrisTree()
        {
            DebrisTree.Nodes.Clear();
            Debris = new VD2DB<DebrisData>("Debris");
            int i = 0;
            for (i = 0; i < Debris.Data.Keys.Count; i++)
            {
                DebrisTree.Nodes.Add(Debris.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateDialogTree()
        {
            DialogTree.Nodes.Clear();
            Dialog = new VD2DB<DialogData>("Dialog");
            int i = 0;
            for (i = 0; i < Dialog.Data.Keys.Count; i++)
            {
                DialogTree.Nodes.Add(Dialog.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateDockedMovingElementsTree()
        {
            DockedMovingElementsTree.Nodes.Clear();
            DockedMovingElements = new VD2DB<DockedMovingElementData>("DockedMovingElements");
            int i = 0;
            for (i = 0; i < DockedMovingElements.Data.Keys.Count; i++)
            {
                DockedMovingElementsTree.Nodes.Add(DockedMovingElements.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateDoorsTree()
        {
            DoorsTree.Nodes.Clear();
            Doors = new VD2DB<DoorData>("Doors");
            int i = 0;
            for (i = 0; i < Doors.Data.Keys.Count; i++)
            {
                DoorsTree.Nodes.Add(Doors.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateEffectsTree()
        {
            EffectsTree.Nodes.Clear();
            EffectsTree.Nodes.Add("Effects");
            EffectsTree.Nodes.Add("Particles");
            Effects = new VD2DB<EffectData>("Effects");
            int i = 0;
            for (i = 0; i < Effects.Data.Keys.Count; i++)
            {
                EffectsTree.Nodes[0].Nodes.Add(Effects.Data.Keys.ElementAt(i));
            }
            Particles = new VD2DB<ParticleData>("Effects\\Particles");

            for (i = 0; i < Particles.Data.Keys.Count; i++)
            {
                EffectsTree.Nodes[1].Nodes.Add(Particles.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateExplosionsTree()
        {
            ExplosionsTree.Nodes.Clear();
            Explosions = new VD2DB<ExplosionData>("Explosions");
            int i = 0;
            for (i = 0; i < Explosions.Data.Keys.Count; i++)
            {
                ExplosionsTree.Nodes.Add(Explosions.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateFactionsTree()
        {
            FactionsTree.Nodes.Clear();
            Factions = new VD2DB<FactionData>("Factions");
            int i = 0;
            for (i = 0; i < Factions.Data.Keys.Count; i++)
            {
                FactionsTree.Nodes.Add(Factions.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateMusicTree()
        {
            MusicTree.Nodes.Clear();
            Music = new VD2DB<MusicData>("Music");
            int i = 0;
            for (i = 0; i < Music.Data.Keys.Count; i++)
            {
                MusicTree.Nodes.Add(Music.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateOtherTree()
        {
            OtherTree.Nodes.Clear();
            OtherObjects = new VD2DB<OtherObjectData>("Other");
            int i = 0;
            for (i = 0; i < OtherObjects.Data.Keys.Count; i++)
            {
                OtherTree.Nodes.Add(OtherObjects.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateShieldsTree()
        {
            ShieldsTree.Nodes.Clear();
            Shields = new VD2DB<ShieldData>("Shields");
            int i = 0;
            for (i = 0; i < Shields.Data.Keys.Count; i++)
            {
                ShieldsTree.Nodes.Add(Shields.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateSkyboxesTree()
        {
            SkyboxesTree.Nodes.Clear();
            Skyboxes = new VD2DB<SkyboxData>("Skyboxes");
            int i = 0;
            for (i = 0; i < Skyboxes.Data.Keys.Count; i++)
            {
                SkyboxesTree.Nodes.Add(Skyboxes.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateSoundsTree()
        {
            SoundsTree.Nodes.Clear();
            List<string> SoundsSubFolders = new List<string>();
            SoundsSubFolders.Add("Dialog");
            SoundsSubFolders.Add("Interior");
            SoundsSubFolders.Add("UI");
            Sounds = new VD2DB<SoundData>("Sounds", SoundsSubFolders);
            int i = 0;
            for (i = 0; i < Sounds.Data.Keys.Count; i++)
            {
                SoundsTree.Nodes.Add(Sounds.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateStationsTree()
        {
            StationsTree.Nodes.Clear();
            Stations = new VD2DB<StationData>("Stations");
            int i = 0;
            for (i = 0; i < Stations.Data.Keys.Count; i++)
            {
                StationsTree.Nodes.Add(Stations.Data.Keys.ElementAt(i));
            }
        }

        public void PopulateSunsTree()
        {
            SunsTree.Nodes.Clear();
            Suns = new VD2DB<SunData>("Suns");
            int i = 0;
            for (i = 0; i < Suns.Data.Keys.Count; i++)
            {
                SunsTree.Nodes.Add(Suns.Data.Keys.ElementAt(i));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EditorUI.UI.InitUI(this);
            EditorUserSettings.UserSettings.InitUserSettings();
            if (EditorUserSettings.UserSettings.VD2Path != "")
            {
                RepopulateAllTrees();
            }
        }

        public void RepopulateAllTrees()
        {
            PopulateShipsTree();
            PopulateWeaponsTree();
            PopulateAreaOfEffectTree();
            PopulateAsteroidsTree();
            PopulateBasesTree();
            PopulateCharactersTree();
            PopulateCockpitsTree();
            PopulateDebrisTree();
            PopulateDialogTree();
            PopulateDockedMovingElementsTree();
            PopulateDoorsTree();
            PopulateEffectsTree();
            PopulateExplosionsTree();
            PopulateFactionsTree();
            PopulateMusicTree();
            PopulateOtherTree();
            PopulateShieldsTree();
            PopulateSkyboxesTree();
            PopulateSoundsTree();
            PopulateStationsTree();
            PopulateSunsTree();
            DataFileProperties.SelectedObject = null;
        }

        private void ShipsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                if (e.Node.Parent.Text == "Active Upgrades")
                {
                    ActiveUpgradeData selectedupgrade;
                    if (ActiveUpgrades.Data.TryGetValue(e.Node.Text, out selectedupgrade))
                    {
                        DataFileProperties.SelectedObject = selectedupgrade;
                    }
                }
                else if (e.Node.Parent.Text == "Primary Upgrades")
                {
                    PrimaryUpgradeData selectedupgrade;
                    if (PrimaryUpgrades.Data.TryGetValue(e.Node.Text, out selectedupgrade))
                    {
                        DataFileProperties.SelectedObject = selectedupgrade;
                    }
                }
                else if ((e.Node.Parent.Text == "Light") || (e.Node.Parent.Text == "Medium") || (e.Node.Parent.Text == "Heavy") || (e.Node.Parent.Text == "Transport") || (e.Node.Parent.Text == "Mining") || (e.Node.Parent.Text == "Shuttle") || (e.Node.Parent.Text == "Repair") || (e.Node.Parent.Text == "Base Capture") || (e.Node.Parent.Text == "Ship Capture") || (e.Node.Parent.Text == "Builder") || (e.Node.Parent.Text == "Drones")) 
                {
                    ShipData selectedship;
                    if (Ships.Data.TryGetValue(e.Node.Text, out selectedship))
                    {
                        DataFileProperties.SelectedObject = selectedship;
                    }
                }
            }
        }

        private void WeaponsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                if (e.Node.Parent.Text == "Ammo")
                {
                    AmmoData selectedammo;
                    if (Ammo.Data.TryGetValue(e.Node.Text, out selectedammo))
                    {
                        DataFileProperties.SelectedObject = selectedammo;
                    }
                }
                else if (e.Node.Parent.Text == "Hangars")
                {
                    HangarData selectedhangar;
                    if (Hangars.Data.TryGetValue(e.Node.Text, out selectedhangar))
                    {
                        DataFileProperties.SelectedObject = selectedhangar;
                    }
                }
                else if (e.Node.Parent.Text == "Launchers")
                {
                    LauncherData selectedlauncher;
                    if (Launchers.Data.TryGetValue(e.Node.Text, out selectedlauncher))
                    {
                        DataFileProperties.SelectedObject = selectedlauncher;
                    }
                }
                else if (e.Node.Parent.Text == "Mines")
                {
                    MineData selectedmine;
                    if (Mines.Data.TryGetValue(e.Node.Text, out selectedmine))
                    {
                        DataFileProperties.SelectedObject = selectedmine;
                    }
                }
                else if (e.Node.Parent.Text == "Missiles")
                {
                    MissileData selectedmissile;
                    if (Missiles.Data.TryGetValue(e.Node.Text, out selectedmissile))
                    {
                        DataFileProperties.SelectedObject = selectedmissile;
                    }
                }
                else if (e.Node.Parent.Text == "Turrets")
                {
                    TurretData selectedturret;
                    if (Turrets.Data.TryGetValue(e.Node.Text, out selectedturret))
                    {
                        DataFileProperties.SelectedObject = selectedturret;
                    }
                }
                else
                {
                    WeaponData selectedweapon;
                    if (Weapons.Data.TryGetValue(e.Node.Text, out selectedweapon))
                    {
                        DataFileProperties.SelectedObject = selectedweapon;
                    }
                }
            }
        }

        private void AreaOfEffectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AreaOfEffectData selectedobject;
            if (AreaOfEffect.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void AsteroidsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AsteroidData selectedobject;
            if (Asteroids.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void BasesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BaseData selectedobject;
            if (Bases.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void CharactersTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CharacterData selectedobject;
            if (Characters.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void CockpitsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CockpitData selectedobject;
            if (Cockpits.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void DebrisTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DebrisData selectedobject;
            if (Debris.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void DialogTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DialogData selectedobject;
            if (Dialog.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void DockedMovingElementsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DockedMovingElementData selectedobject;
            if (DockedMovingElements.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void DoorsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DoorData selectedobject;
            if (Doors.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void EffectsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                if (e.Node.Parent.Text == "Effects")
                {
                    EffectData selectedeffect;
                    if (Effects.Data.TryGetValue(e.Node.Text, out selectedeffect))
                    {
                        DataFileProperties.SelectedObject = selectedeffect;
                    }
                }
                else if (e.Node.Parent.Text == "Particles")
                {
                    ParticleData selectedparticle;
                    if (Particles.Data.TryGetValue(e.Node.Text, out selectedparticle))
                    {
                        DataFileProperties.SelectedObject = selectedparticle;
                    }
                }
            }
        }

        private void ExplosionsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ExplosionData selectedobject;
            if (Explosions.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void FactionsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FactionData selectedobject;
            if (Factions.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void MusicTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MusicData selectedobject;
            if (Music.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void OtherTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OtherObjectData selectedobject;
            if (OtherObjects.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void ShieldsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShieldData selectedobject;
            if (Shields.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void SkyboxesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SkyboxData selectedobject;
            if (Skyboxes.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void SoundsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SoundData selectedobject;
            if (Sounds.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void StationsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            StationData selectedobject;
            if (Stations.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void SunsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SunData selectedobject;
            if (Suns.Data.TryGetValue(e.Node.Text, out selectedobject))
            {
                DataFileProperties.SelectedObject = selectedobject;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorAboutBox about = new EditorAboutBox();
            about.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditorSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show();
        }       
    }
}
