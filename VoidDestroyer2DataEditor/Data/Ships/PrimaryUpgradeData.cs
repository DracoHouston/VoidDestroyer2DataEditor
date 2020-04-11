using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ComponentModel;

namespace VoidDestroyer2DataEditor
{
    public class PrimaryUpgradeData : VD2Data
    {
        string _displayName;
        string _objectID;
        string _upgradeCategory;
        string _upgradeType;
        string _projectileAmmoID;
        string _requiredMissionID;

        ObservableCollection<string> _description;
        ObservableCollection<string> _skybox;

        int _activeUpgradeSlotChange;
        int _primaryUpgradeSlotChange;
        int _cost;
        int _shieldHealthChange;
        int _afterburnerCapacity;
        int _afterburnerRechargeRate;

        float _addCostAsPercentOfShip;
        float _afterBurnerCapacityMultiplier;
        float _ammoCapacityMultiplier;
        float _armorChange;
        float _maneuveringMultiplier;
        float _speedChangePercent;
        float _timeTillCruiseMultiplier;
        float _afterburnerMultiplier;
        float _fuelChangePercent;
        float _projectileSpeedChange;
        float _fireRateMultiplier;
        float _secondaryFireReloadMultiplier;
        float _sensorRangeChange;
        float _detectedRangeChange;

        bool _bCommonUpgrade;
        bool _bAlwaysAvailableUpgrade;
        bool _bIllegalUpgrade;
        bool _bRemoveCapturedFlag;
        bool _bTurretedDebris;
        bool _bPersistsOnShipChange;
        bool _bPermitShipCameraLight;
        bool _bOwnedBaseUpgrade;
        bool _bNoOverworldIndicatorInShipMode;
        bool _bGateTravelRefuel;
        bool _bRadiationRefuel;

        ObservableCollection<turretDataStructure> _turret;

        [Description("displayName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string displayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _displayName = value;
                        SetPropertyEdited("displayName", true);
                    }
                }
            }
        }

        [Description("objectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string objectID
        {
            get
            {
                return _objectID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _objectID = value;
                        SetPropertyEdited("objectID", true);
                    }
                }
            }
        }

        [Description("upgradeCategory is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string upgradeCategory
        {
            get
            {
                return _upgradeCategory;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _upgradeCategory = value;
                        SetPropertyEdited("upgradeCategory", true);
                    }
                }
            }
        }

        [Description("upgradeType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string upgradeType
        {
            get
            {
                return _upgradeType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _upgradeType = value;
                        SetPropertyEdited("upgradeType", true);
                    }
                }
            }
        }

        [Description("projectileAmmoID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string projectileAmmoID
        {
            get
            {
                return _projectileAmmoID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _projectileAmmoID = value;
                        SetPropertyEdited("projectileAmmoID", true);
                    }
                }
            }
        }

        [Description("requiredMissionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string requiredMissionID
        {
            get
            {
                return _requiredMissionID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _requiredMissionID = value;
                        SetPropertyEdited("requiredMissionID", true);
                    }
                }
            }
        }


        [Description("description is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        private void OndescriptionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("description", true);
                }
                else
                {
                    bool exists = false;
                    _description = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "description", out exists));
                    _description.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OndescriptionChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("description", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("description", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "description"));
                    }
                    SetPropertyExists("description", exists);
                }
            }
        }

        [Description("skybox is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> skybox
        {
            get
            {
                return _skybox;
            }
            set
            {
                _skybox = value;
            }
        }

        private void OnskyboxChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("skybox", true);
                }
                else
                {
                    bool exists = false;
                    _skybox = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "skybox", out exists));
                    _skybox.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnskyboxChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("skybox", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("skybox", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "skybox"));
                    }
                    SetPropertyExists("skybox", exists);
                }
            }
        }


        [Description("activeUpgradeSlotChange is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int activeUpgradeSlotChange
        {
            get
            {
                return _activeUpgradeSlotChange;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _activeUpgradeSlotChange = value;
                        SetPropertyEdited("activeUpgradeSlotChange", true);
                    }
                }
            }
        }

        [Description("primaryUpgradeSlotChange is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int primaryUpgradeSlotChange
        {
            get
            {
                return _primaryUpgradeSlotChange;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _primaryUpgradeSlotChange = value;
                        SetPropertyEdited("primaryUpgradeSlotChange", true);
                    }
                }
            }
        }

        [Description("cost is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _cost = value;
                        SetPropertyEdited("cost", true);
                    }
                }
            }
        }

        [Description("shieldHealthChange is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int shieldHealthChange
        {
            get
            {
                return _shieldHealthChange;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shieldHealthChange = value;
                        SetPropertyEdited("shieldHealthChange", true);
                    }
                }
            }
        }

        [Description("afterburnerCapacity is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int afterburnerCapacity
        {
            get
            {
                return _afterburnerCapacity;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _afterburnerCapacity = value;
                        SetPropertyEdited("afterburnerCapacity", true);
                    }
                }
            }
        }

        [Description("afterburnerRechargeRate is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int afterburnerRechargeRate
        {
            get
            {
                return _afterburnerRechargeRate;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _afterburnerRechargeRate = value;
                        SetPropertyEdited("afterburnerRechargeRate", true);
                    }
                }
            }
        }


        [Description("addCostAsPercentOfShip is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float addCostAsPercentOfShip
        {
            get
            {
                return _addCostAsPercentOfShip;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _addCostAsPercentOfShip = value;
                        SetPropertyEdited("addCostAsPercentOfShip", true);
                    }
                }
            }
        }

        [Description("afterBurnerCapacityMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float afterBurnerCapacityMultiplier
        {
            get
            {
                return _afterBurnerCapacityMultiplier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _afterBurnerCapacityMultiplier = value;
                        SetPropertyEdited("afterBurnerCapacityMultiplier", true);
                    }
                }
            }
        }

        [Description("ammoCapacityMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float ammoCapacityMultiplier
        {
            get
            {
                return _ammoCapacityMultiplier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _ammoCapacityMultiplier = value;
                        SetPropertyEdited("ammoCapacityMultiplier", true);
                    }
                }
            }
        }

        [Description("armorChange is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float armorChange
        {
            get
            {
                return _armorChange;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _armorChange = value;
                        SetPropertyEdited("armorChange", true);
                    }
                }
            }
        }

        [Description("maneuveringMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float maneuveringMultiplier
        {
            get
            {
                return _maneuveringMultiplier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _maneuveringMultiplier = value;
                        SetPropertyEdited("maneuveringMultiplier", true);
                    }
                }
            }
        }

        [Description("speedChangePercent is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float speedChangePercent
        {
            get
            {
                return _speedChangePercent;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _speedChangePercent = value;
                        SetPropertyEdited("speedChangePercent", true);
                    }
                }
            }
        }

        [Description("timeTillCruiseMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float timeTillCruiseMultiplier
        {
            get
            {
                return _timeTillCruiseMultiplier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _timeTillCruiseMultiplier = value;
                        SetPropertyEdited("timeTillCruiseMultiplier", true);
                    }
                }
            }
        }

        [Description("afterburnerMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float afterburnerMultiplier
        {
            get
            {
                return _afterburnerMultiplier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _afterburnerMultiplier = value;
                        SetPropertyEdited("afterburnerMultiplier", true);
                    }
                }
            }
        }

        [Description("fuelChangePercent is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float fuelChangePercent
        {
            get
            {
                return _fuelChangePercent;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _fuelChangePercent = value;
                        SetPropertyEdited("fuelChangePercent", true);
                    }
                }
            }
        }

        [Description("projectileSpeedChange is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float projectileSpeedChange
        {
            get
            {
                return _projectileSpeedChange;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _projectileSpeedChange = value;
                        SetPropertyEdited("projectileSpeedChange", true);
                    }
                }
            }
        }

        [Description("fireRateMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float fireRateMultiplier
        {
            get
            {
                return _fireRateMultiplier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _fireRateMultiplier = value;
                        SetPropertyEdited("fireRateMultiplier", true);
                    }
                }
            }
        }

        [Description("secondaryFireReloadMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float secondaryFireReloadMultiplier
        {
            get
            {
                return _secondaryFireReloadMultiplier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _secondaryFireReloadMultiplier = value;
                        SetPropertyEdited("secondaryFireReloadMultiplier", true);
                    }
                }
            }
        }

        [Description("sensorRangeChange is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float sensorRangeChange
        {
            get
            {
                return _sensorRangeChange;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _sensorRangeChange = value;
                        SetPropertyEdited("sensorRangeChange", true);
                    }
                }
            }
        }

        [Description("detectedRangeChange is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float detectedRangeChange
        {
            get
            {
                return _detectedRangeChange;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _detectedRangeChange = value;
                        SetPropertyEdited("detectedRangeChange", true);
                    }
                }
            }
        }


        [Description("bCommonUpgrade is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCommonUpgrade
        {
            get
            {
                return _bCommonUpgrade;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCommonUpgrade = value;
                        SetPropertyEdited("bCommonUpgrade", true);
                    }
                }
            }
        }

        [Description("bAlwaysAvailableUpgrade is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAlwaysAvailableUpgrade
        {
            get
            {
                return _bAlwaysAvailableUpgrade;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bAlwaysAvailableUpgrade = value;
                        SetPropertyEdited("bAlwaysAvailableUpgrade", true);
                    }
                }
            }
        }

        [Description("bIllegalUpgrade is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bIllegalUpgrade
        {
            get
            {
                return _bIllegalUpgrade;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bIllegalUpgrade = value;
                        SetPropertyEdited("bIllegalUpgrade", true);
                    }
                }
            }
        }

        [Description("bRemoveCapturedFlag is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bRemoveCapturedFlag
        {
            get
            {
                return _bRemoveCapturedFlag;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bRemoveCapturedFlag = value;
                        SetPropertyEdited("bRemoveCapturedFlag", true);
                    }
                }
            }
        }

        [Description("bTurretedDebris is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bTurretedDebris
        {
            get
            {
                return _bTurretedDebris;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bTurretedDebris = value;
                        SetPropertyEdited("bTurretedDebris", true);
                    }
                }
            }
        }

        [Description("bPersistsOnShipChange is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPersistsOnShipChange
        {
            get
            {
                return _bPersistsOnShipChange;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bPersistsOnShipChange = value;
                        SetPropertyEdited("bPersistsOnShipChange", true);
                    }
                }
            }
        }

        [Description("bPermitShipCameraLight is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPermitShipCameraLight
        {
            get
            {
                return _bPermitShipCameraLight;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bPermitShipCameraLight = value;
                        SetPropertyEdited("bPermitShipCameraLight", true);
                    }
                }
            }
        }

        [Description("bOwnedBaseUpgrade is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bOwnedBaseUpgrade
        {
            get
            {
                return _bOwnedBaseUpgrade;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bOwnedBaseUpgrade = value;
                        SetPropertyEdited("bOwnedBaseUpgrade", true);
                    }
                }
            }
        }

        [Description("bNoOverworldIndicatorInShipMode is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoOverworldIndicatorInShipMode
        {
            get
            {
                return _bNoOverworldIndicatorInShipMode;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bNoOverworldIndicatorInShipMode = value;
                        SetPropertyEdited("bNoOverworldIndicatorInShipMode", true);
                    }
                }
            }
        }

        [Description("bGateTravelRefuel is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bGateTravelRefuel
        {
            get
            {
                return _bGateTravelRefuel;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bGateTravelRefuel = value;
                        SetPropertyEdited("bGateTravelRefuel", true);
                    }
                }
            }
        }

        [Description("bRadiationRefuel is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bRadiationRefuel
        {
            get
            {
                return _bRadiationRefuel;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bRadiationRefuel = value;
                        SetPropertyEdited("bRadiationRefuel", true);
                    }
                }
            }
        }


        [Description("turret is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<turretDataStructure> turret
        {
            get
            {
                return _turret;
            }
            set
            {
                _turret = value;
            }
        }

        private void OnturretChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("turret", true);
                }
                else
                {
                    bool exists = false;
                    _turret = new ObservableCollection<turretDataStructure>(DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _turret.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnturretChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("turret", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("turret", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "turret"));
                    }
                    SetPropertyExists("turret", exists);
                }
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("displayName");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("upgradeCategory");
            InitProperty("upgradeType");
            InitProperty("projectileAmmoID");
            InitProperty("requiredMissionID");

            InitProperty("description");
            InitProperty("skybox");

            InitProperty("activeUpgradeSlotChange");
            InitProperty("primaryUpgradeSlotChange");
            InitProperty("cost");
            InitProperty("shieldHealthChange");
            InitProperty("afterburnerCapacity");
            InitProperty("afterburnerRechargeRate");

            InitProperty("addCostAsPercentOfShip");
            InitProperty("afterBurnerCapacityMultiplier");
            InitProperty("ammoCapacityMultiplier");
            InitProperty("armorChange");
            InitProperty("maneuveringMultiplier");
            InitProperty("speedChangePercent");
            InitProperty("timeTillCruiseMultiplier");
            InitProperty("afterburnerMultiplier");
            InitProperty("fuelChangePercent");
            InitProperty("projectileSpeedChange");
            InitProperty("fireRateMultiplier");
            InitProperty("secondaryFireReloadMultiplier");
            InitProperty("sensorRangeChange");
            InitProperty("detectedRangeChange");

            InitProperty("bCommonUpgrade");
            InitProperty("bAlwaysAvailableUpgrade");
            InitProperty("bIllegalUpgrade");
            InitProperty("bRemoveCapturedFlag");
            InitProperty("bTurretedDebris");
            InitProperty("bPersistsOnShipChange");
            InitProperty("bPermitShipCameraLight");
            InitProperty("bOwnedBaseUpgrade");
            InitProperty("bNoOverworldIndicatorInShipMode");
            InitProperty("bGateTravelRefuel");
            InitProperty("bRadiationRefuel");

            InitProperty("turret");
        }

        public PrimaryUpgradeData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("objectID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("objectID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(objectID, "objectID"));
                }
                SetPropertyExists("objectID", exists);

                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("displayName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("displayName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "displayName"));
                }
                SetPropertyExists("displayName", exists);
                _upgradeCategory = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "upgradeCategory", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("upgradeCategory", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("upgradeCategory", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "upgradeCategory"));
                }
                SetPropertyExists("upgradeCategory", exists);
                _upgradeType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "upgradeType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("upgradeType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("upgradeType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "upgradeType"));
                }
                SetPropertyExists("upgradeType", exists);
                _projectileAmmoID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileAmmoID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("projectileAmmoID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("projectileAmmoID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "projectileAmmoID"));
                }
                SetPropertyExists("projectileAmmoID", exists);
                _requiredMissionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "requiredMissionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("requiredMissionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("requiredMissionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "requiredMissionID"));
                }
                SetPropertyExists("requiredMissionID", exists);

                _description = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "description", out exists));
                _description.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OndescriptionChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("description", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("description", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "description"));
                }
                SetPropertyExists("description", exists);
                _skybox = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "skybox", out exists));
                _skybox.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnskyboxChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("skybox", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("skybox", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "skybox"));
                }
                SetPropertyExists("skybox", exists);

                _activeUpgradeSlotChange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "activeUpgradeSlotChange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("activeUpgradeSlotChange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("activeUpgradeSlotChange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "activeUpgradeSlotChange"));
                }
                SetPropertyExists("activeUpgradeSlotChange", exists);
                _primaryUpgradeSlotChange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "primaryUpgradeSlotChange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("primaryUpgradeSlotChange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("primaryUpgradeSlotChange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "primaryUpgradeSlotChange"));
                }
                SetPropertyExists("primaryUpgradeSlotChange", exists);
                _cost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "cost", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("cost", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("cost", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "cost"));
                }
                SetPropertyExists("cost", exists);
                _shieldHealthChange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shieldHealthChange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shieldHealthChange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shieldHealthChange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shieldHealthChange"));
                }
                SetPropertyExists("shieldHealthChange", exists);
                _afterburnerCapacity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "afterburnerCapacity", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("afterburnerCapacity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("afterburnerCapacity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "afterburnerCapacity"));
                }
                SetPropertyExists("afterburnerCapacity", exists);
                _afterburnerRechargeRate = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "afterburnerRechargeRate", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("afterburnerRechargeRate", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("afterburnerRechargeRate", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "afterburnerRechargeRate"));
                }
                SetPropertyExists("afterburnerRechargeRate", exists);

                _addCostAsPercentOfShip = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "addCostAsPercentOfShip", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("addCostAsPercentOfShip", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("addCostAsPercentOfShip", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "addCostAsPercentOfShip"));
                }
                SetPropertyExists("addCostAsPercentOfShip", exists);
                _afterBurnerCapacityMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "afterBurnerCapacityMultiplier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("afterBurnerCapacityMultiplier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("afterBurnerCapacityMultiplier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "afterBurnerCapacityMultiplier"));
                }
                SetPropertyExists("afterBurnerCapacityMultiplier", exists);
                _ammoCapacityMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "ammoCapacityMultiplier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("ammoCapacityMultiplier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("ammoCapacityMultiplier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "ammoCapacityMultiplier"));
                }
                SetPropertyExists("ammoCapacityMultiplier", exists);
                _armorChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "armorChange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("armorChange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("armorChange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "armorChange"));
                }
                SetPropertyExists("armorChange", exists);
                _maneuveringMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "maneuveringMultiplier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("maneuveringMultiplier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("maneuveringMultiplier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "maneuveringMultiplier"));
                }
                SetPropertyExists("maneuveringMultiplier", exists);
                _speedChangePercent = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "speedChangePercent", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("speedChangePercent", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("speedChangePercent", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "speedChangePercent"));
                }
                SetPropertyExists("speedChangePercent", exists);
                _timeTillCruiseMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillCruiseMultiplier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("timeTillCruiseMultiplier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("timeTillCruiseMultiplier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "timeTillCruiseMultiplier"));
                }
                SetPropertyExists("timeTillCruiseMultiplier", exists);
                _afterburnerMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "afterburnerMultiplier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("afterburnerMultiplier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("afterburnerMultiplier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "afterburnerMultiplier"));
                }
                SetPropertyExists("afterburnerMultiplier", exists);
                _fuelChangePercent = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "fuelChangePercent", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("fuelChangePercent", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("fuelChangePercent", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "fuelChangePercent"));
                }
                SetPropertyExists("fuelChangePercent", exists);
                _projectileSpeedChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "projectileSpeedChange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("projectileSpeedChange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("projectileSpeedChange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "projectileSpeedChange"));
                }
                SetPropertyExists("projectileSpeedChange", exists);
                _fireRateMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "fireRateMultiplier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("fireRateMultiplier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("fireRateMultiplier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "fireRateMultiplier"));
                }
                SetPropertyExists("fireRateMultiplier", exists);
                _secondaryFireReloadMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "secondaryFireReloadMultiplier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("secondaryFireReloadMultiplier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("secondaryFireReloadMultiplier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "secondaryFireReloadMultiplier"));
                }
                SetPropertyExists("secondaryFireReloadMultiplier", exists);
                _sensorRangeChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "sensorRangeChange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("sensorRangeChange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("sensorRangeChange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "sensorRangeChange"));
                }
                SetPropertyExists("sensorRangeChange", exists);
                _detectedRangeChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "detectedRangeChange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("detectedRangeChange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("detectedRangeChange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "detectedRangeChange"));
                }
                SetPropertyExists("detectedRangeChange", exists);

                _bCommonUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommonUpgrade", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCommonUpgrade", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCommonUpgrade", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCommonUpgrade"));
                }
                SetPropertyExists("bCommonUpgrade", exists);
                _bAlwaysAvailableUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysAvailableUpgrade", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bAlwaysAvailableUpgrade", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bAlwaysAvailableUpgrade", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bAlwaysAvailableUpgrade"));
                }
                SetPropertyExists("bAlwaysAvailableUpgrade", exists);
                _bIllegalUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIllegalUpgrade", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bIllegalUpgrade", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bIllegalUpgrade", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bIllegalUpgrade"));
                }
                SetPropertyExists("bIllegalUpgrade", exists);
                _bRemoveCapturedFlag = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRemoveCapturedFlag", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bRemoveCapturedFlag", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bRemoveCapturedFlag", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bRemoveCapturedFlag"));
                }
                SetPropertyExists("bRemoveCapturedFlag", exists);
                _bTurretedDebris = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bTurretedDebris", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bTurretedDebris", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bTurretedDebris", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bTurretedDebris"));
                }
                SetPropertyExists("bTurretedDebris", exists);
                _bPersistsOnShipChange = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPersistsOnShipChange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bPersistsOnShipChange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bPersistsOnShipChange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bPersistsOnShipChange"));
                }
                SetPropertyExists("bPersistsOnShipChange", exists);
                _bPermitShipCameraLight = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPermitShipCameraLight", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bPermitShipCameraLight", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bPermitShipCameraLight", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bPermitShipCameraLight"));
                }
                SetPropertyExists("bPermitShipCameraLight", exists);
                _bOwnedBaseUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOwnedBaseUpgrade", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bOwnedBaseUpgrade", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bOwnedBaseUpgrade", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bOwnedBaseUpgrade"));
                }
                SetPropertyExists("bOwnedBaseUpgrade", exists);
                _bNoOverworldIndicatorInShipMode = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoOverworldIndicatorInShipMode", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bNoOverworldIndicatorInShipMode", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bNoOverworldIndicatorInShipMode", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bNoOverworldIndicatorInShipMode"));
                }
                SetPropertyExists("bNoOverworldIndicatorInShipMode", exists);
                _bGateTravelRefuel = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGateTravelRefuel", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bGateTravelRefuel", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bGateTravelRefuel", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bGateTravelRefuel"));
                }
                SetPropertyExists("bGateTravelRefuel", exists);
                _bRadiationRefuel = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRadiationRefuel", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bRadiationRefuel", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bRadiationRefuel", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bRadiationRefuel"));
                }
                SetPropertyExists("bRadiationRefuel", exists);

                _turret =  new ObservableCollection<turretDataStructure>(DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _turret.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnturretChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("turret", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("turret", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "turret"));
                }
                SetPropertyExists("turret", exists);
            }
        }

        public override void SaveData()
        {
            List<string> xmltextlines = new List<string>();
            xmltextlines.Add("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xmltextlines.Add("<note_to_self attr1=\"Generated by Void Destroyer 2 Data Editor\"/>");
            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Strings...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("displayName"))
            {
                xmltextlines.Add("<displayName attr1=\"" + _displayName + "\"/>");
            }
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("upgradeCategory"))
            {
                xmltextlines.Add("<upgradeCategory attr1=\"" + _upgradeCategory + "\"/>");
            }
            if (PropertyExists("upgradeType"))
            {
                xmltextlines.Add("<upgradeType attr1=\"" + _upgradeType + "\"/>");
            }
            if (PropertyExists("projectileAmmoID"))
            {
                xmltextlines.Add("<projectileAmmoID attr1=\"" + _projectileAmmoID + "\"/>");
            }
            if (PropertyExists("requiredMissionID"))
            {
                xmltextlines.Add("<requiredMissionID attr1=\"" + _requiredMissionID + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"String Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("description"))
            {
                foreach (string result in _description)
                {
                    xmltextlines.Add("<description attr1=\"" + result + "\"/>");
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("skybox"))
            {
                foreach (string result in _skybox)
                {
                    xmltextlines.Add("<skybox attr1=\"" + result + "\"/>");
                }
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("activeUpgradeSlotChange"))
            {
                xmltextlines.Add("<activeUpgradeSlotChange attr1=\"" + _activeUpgradeSlotChange.ToString() + "\"/>");
            }
            if (PropertyExists("primaryUpgradeSlotChange"))
            {
                xmltextlines.Add("<primaryUpgradeSlotChange attr1=\"" + _primaryUpgradeSlotChange.ToString() + "\"/>");
            }
            if (PropertyExists("cost"))
            {
                xmltextlines.Add("<cost attr1=\"" + _cost.ToString() + "\"/>");
            }
            if (PropertyExists("shieldHealthChange"))
            {
                xmltextlines.Add("<shieldHealthChange attr1=\"" + _shieldHealthChange.ToString() + "\"/>");
            }
            if (PropertyExists("afterburnerCapacity"))
            {
                xmltextlines.Add("<afterburnerCapacity attr1=\"" + _afterburnerCapacity.ToString() + "\"/>");
            }
            if (PropertyExists("afterburnerRechargeRate"))
            {
                xmltextlines.Add("<afterburnerRechargeRate attr1=\"" + _afterburnerRechargeRate.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("addCostAsPercentOfShip"))
            {
                xmltextlines.Add("<addCostAsPercentOfShip attr1=\"" + _addCostAsPercentOfShip.ToString() + "\"/>");
            }
            if (PropertyExists("afterBurnerCapacityMultiplier"))
            {
                xmltextlines.Add("<afterBurnerCapacityMultiplier attr1=\"" + _afterBurnerCapacityMultiplier.ToString() + "\"/>");
            }
            if (PropertyExists("ammoCapacityMultiplier"))
            {
                xmltextlines.Add("<ammoCapacityMultiplier attr1=\"" + _ammoCapacityMultiplier.ToString() + "\"/>");
            }
            if (PropertyExists("armorChange"))
            {
                xmltextlines.Add("<armorChange attr1=\"" + _armorChange.ToString() + "\"/>");
            }
            if (PropertyExists("maneuveringMultiplier"))
            {
                xmltextlines.Add("<maneuveringMultiplier attr1=\"" + _maneuveringMultiplier.ToString() + "\"/>");
            }
            if (PropertyExists("speedChangePercent"))
            {
                xmltextlines.Add("<speedChangePercent attr1=\"" + _speedChangePercent.ToString() + "\"/>");
            }
            if (PropertyExists("timeTillCruiseMultiplier"))
            {
                xmltextlines.Add("<timeTillCruiseMultiplier attr1=\"" + _timeTillCruiseMultiplier.ToString() + "\"/>");
            }
            if (PropertyExists("afterburnerMultiplier"))
            {
                xmltextlines.Add("<afterburnerMultiplier attr1=\"" + _afterburnerMultiplier.ToString() + "\"/>");
            }
            if (PropertyExists("fuelChangePercent"))
            {
                xmltextlines.Add("<fuelChangePercent attr1=\"" + _fuelChangePercent.ToString() + "\"/>");
            }
            if (PropertyExists("projectileSpeedChange"))
            {
                xmltextlines.Add("<projectileSpeedChange attr1=\"" + _projectileSpeedChange.ToString() + "\"/>");
            }
            if (PropertyExists("fireRateMultiplier"))
            {
                xmltextlines.Add("<fireRateMultiplier attr1=\"" + _fireRateMultiplier.ToString() + "\"/>");
            }
            if (PropertyExists("secondaryFireReloadMultiplier"))
            {
                xmltextlines.Add("<secondaryFireReloadMultiplier attr1=\"" + _secondaryFireReloadMultiplier.ToString() + "\"/>");
            }
            if (PropertyExists("sensorRangeChange"))
            {
                xmltextlines.Add("<sensorRangeChange attr1=\"" + _sensorRangeChange.ToString() + "\"/>");
            }
            if (PropertyExists("detectedRangeChange"))
            {
                xmltextlines.Add("<detectedRangeChange attr1=\"" + _detectedRangeChange.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bCommonUpgrade"))
            {
                xmltextlines.Add("<bCommonUpgrade attr1=\"" + ((_bCommonUpgrade) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bAlwaysAvailableUpgrade"))
            {
                xmltextlines.Add("<bAlwaysAvailableUpgrade attr1=\"" + ((_bAlwaysAvailableUpgrade) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bIllegalUpgrade"))
            {
                xmltextlines.Add("<bIllegalUpgrade attr1=\"" + ((_bIllegalUpgrade) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bRemoveCapturedFlag"))
            {
                xmltextlines.Add("<bRemoveCapturedFlag attr1=\"" + ((_bRemoveCapturedFlag) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bTurretedDebris"))
            {
                xmltextlines.Add("<bTurretedDebris attr1=\"" + ((_bTurretedDebris) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bPersistsOnShipChange"))
            {
                xmltextlines.Add("<bPersistsOnShipChange attr1=\"" + ((_bPersistsOnShipChange) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bPermitShipCameraLight"))
            {
                xmltextlines.Add("<bPermitShipCameraLight attr1=\"" + ((_bPermitShipCameraLight) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bOwnedBaseUpgrade"))
            {
                xmltextlines.Add("<bOwnedBaseUpgrade attr1=\"" + ((_bOwnedBaseUpgrade) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bNoOverworldIndicatorInShipMode"))
            {
                xmltextlines.Add("<bNoOverworldIndicatorInShipMode attr1=\"" + ((_bNoOverworldIndicatorInShipMode) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bGateTravelRefuel"))
            {
                xmltextlines.Add("<bGateTravelRefuel attr1=\"" + ((_bGateTravelRefuel) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bRadiationRefuel"))
            {
                xmltextlines.Add("<bRadiationRefuel attr1=\"" + ((_bRadiationRefuel) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structure Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("turret"))
            {
                foreach (turretDataStructure result in _turret)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }

            File.WriteAllLines("testsavedship.xml", xmltextlines);
        }
    }
}
