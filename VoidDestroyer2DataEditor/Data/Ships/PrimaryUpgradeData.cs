using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ComponentModel;

namespace VoidDestroyer2DataEditor
{
    class PrimaryUpgradeData : VD2Data
    {
        string _displayName;
        string _objectID;
        string _upgradeCategory;
        string _upgradeType;
        string _projectileAmmoID;
        string _requiredMissionID;

        List<string> _description;
        List<string> _skybox;

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

        List<turretDataStructure> _turret;

        [Description("displayName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string displayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
                SetPropertyEdited("displayName", true);
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
                _objectID = value;
                SetPropertyEdited("objectID", true);
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
                _upgradeCategory = value;
                SetPropertyEdited("upgradeCategory", true);
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
                _upgradeType = value;
                SetPropertyEdited("upgradeType", true);
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
                _projectileAmmoID = value;
                SetPropertyEdited("projectileAmmoID", true);
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
                _requiredMissionID = value;
                SetPropertyEdited("requiredMissionID", true);
            }
        }


        [Description("description is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                SetPropertyEdited("description", true);
            }
        }

        [Description("skybox is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> skybox
        {
            get
            {
                return _skybox;
            }
            set
            {
                _skybox = value;
                SetPropertyEdited("skybox", true);
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
                _activeUpgradeSlotChange = value;
                SetPropertyEdited("activeUpgradeSlotChange", true);
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
                _primaryUpgradeSlotChange = value;
                SetPropertyEdited("primaryUpgradeSlotChange", true);
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
                _cost = value;
                SetPropertyEdited("cost", true);
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
                _shieldHealthChange = value;
                SetPropertyEdited("shieldHealthChange", true);
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
                _afterburnerCapacity = value;
                SetPropertyEdited("afterburnerCapacity", true);
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
                _afterburnerRechargeRate = value;
                SetPropertyEdited("afterburnerRechargeRate", true);
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
                _addCostAsPercentOfShip = value;
                SetPropertyEdited("addCostAsPercentOfShip", true);
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
                _afterBurnerCapacityMultiplier = value;
                SetPropertyEdited("afterBurnerCapacityMultiplier", true);
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
                _ammoCapacityMultiplier = value;
                SetPropertyEdited("ammoCapacityMultiplier", true);
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
                _armorChange = value;
                SetPropertyEdited("armorChange", true);
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
                _maneuveringMultiplier = value;
                SetPropertyEdited("maneuveringMultiplier", true);
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
                _speedChangePercent = value;
                SetPropertyEdited("speedChangePercent", true);
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
                _timeTillCruiseMultiplier = value;
                SetPropertyEdited("timeTillCruiseMultiplier", true);
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
                _afterburnerMultiplier = value;
                SetPropertyEdited("afterburnerMultiplier", true);
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
                _fuelChangePercent = value;
                SetPropertyEdited("fuelChangePercent", true);
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
                _projectileSpeedChange = value;
                SetPropertyEdited("projectileSpeedChange", true);
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
                _fireRateMultiplier = value;
                SetPropertyEdited("fireRateMultiplier", true);
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
                _secondaryFireReloadMultiplier = value;
                SetPropertyEdited("secondaryFireReloadMultiplier", true);
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
                _sensorRangeChange = value;
                SetPropertyEdited("sensorRangeChange", true);
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
                _detectedRangeChange = value;
                SetPropertyEdited("detectedRangeChange", true);
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
                _bCommonUpgrade = value;
                SetPropertyEdited("bCommonUpgrade", true);
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
                _bAlwaysAvailableUpgrade = value;
                SetPropertyEdited("bAlwaysAvailableUpgrade", true);
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
                _bIllegalUpgrade = value;
                SetPropertyEdited("bIllegalUpgrade", true);
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
                _bRemoveCapturedFlag = value;
                SetPropertyEdited("bRemoveCapturedFlag", true);
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
                _bTurretedDebris = value;
                SetPropertyEdited("bTurretedDebris", true);
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
                _bPersistsOnShipChange = value;
                SetPropertyEdited("bPersistsOnShipChange", true);
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
                _bPermitShipCameraLight = value;
                SetPropertyEdited("bPermitShipCameraLight", true);
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
                _bOwnedBaseUpgrade = value;
                SetPropertyEdited("bOwnedBaseUpgrade", true);
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
                _bNoOverworldIndicatorInShipMode = value;
                SetPropertyEdited("bNoOverworldIndicatorInShipMode", true);
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
                _bGateTravelRefuel = value;
                SetPropertyEdited("bGateTravelRefuel", true);
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
                _bRadiationRefuel = value;
                SetPropertyEdited("bRadiationRefuel", true);
            }
        }


        [Description("turret is a collection of datastructures"), Category("Data Structure Collections")]
        public List<turretDataStructure> turret
        {
            get
            {
                return _turret;
            }
            set
            {
                _turret = value;
                SetPropertyEdited("turret", true);
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("displayName");
            InitProperty("objectID");
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

        public PrimaryUpgradeData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName", out exists);
                SetPropertyExistsInBaseData("displayName", exists);
                SetPropertyExists("displayName", exists);
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _upgradeCategory = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "upgradeCategory", out exists);
                SetPropertyExistsInBaseData("upgradeCategory", exists);
                SetPropertyExists("upgradeCategory", exists);
                _upgradeType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "upgradeType", out exists);
                SetPropertyExistsInBaseData("upgradeType", exists);
                SetPropertyExists("upgradeType", exists);
                _projectileAmmoID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileAmmoID", out exists);
                SetPropertyExistsInBaseData("projectileAmmoID", exists);
                SetPropertyExists("projectileAmmoID", exists);
                _requiredMissionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "requiredMissionID", out exists);
                SetPropertyExistsInBaseData("requiredMissionID", exists);
                SetPropertyExists("requiredMissionID", exists);

                _description = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "description", out exists);
                SetPropertyExistsInBaseData("description", exists);
                SetPropertyExists("description", exists);
                _skybox = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "skybox", out exists);
                SetPropertyExistsInBaseData("skybox", exists);
                SetPropertyExists("skybox", exists);

                _activeUpgradeSlotChange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "activeUpgradeSlotChange", out exists);
                SetPropertyExistsInBaseData("activeUpgradeSlotChange", exists);
                SetPropertyExists("activeUpgradeSlotChange", exists);
                _primaryUpgradeSlotChange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "primaryUpgradeSlotChange", out exists);
                SetPropertyExistsInBaseData("primaryUpgradeSlotChange", exists);
                SetPropertyExists("primaryUpgradeSlotChange", exists);
                _cost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "cost", out exists);
                SetPropertyExistsInBaseData("cost", exists);
                SetPropertyExists("cost", exists);
                _shieldHealthChange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shieldHealthChange", out exists);
                SetPropertyExistsInBaseData("shieldHealthChange", exists);
                SetPropertyExists("shieldHealthChange", exists);
                _afterburnerCapacity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "afterburnerCapacity", out exists);
                SetPropertyExistsInBaseData("afterburnerCapacity", exists);
                SetPropertyExists("afterburnerCapacity", exists);
                _afterburnerRechargeRate = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "afterburnerRechargeRate", out exists);
                SetPropertyExistsInBaseData("afterburnerRechargeRate", exists);
                SetPropertyExists("afterburnerRechargeRate", exists);

                _addCostAsPercentOfShip = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "addCostAsPercentOfShip", out exists);
                SetPropertyExistsInBaseData("addCostAsPercentOfShip", exists);
                SetPropertyExists("addCostAsPercentOfShip", exists);
                _afterBurnerCapacityMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "afterBurnerCapacityMultiplier", out exists);
                SetPropertyExistsInBaseData("afterBurnerCapacityMultiplier", exists);
                SetPropertyExists("afterBurnerCapacityMultiplier", exists);
                _ammoCapacityMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "ammoCapacityMultiplier", out exists);
                SetPropertyExistsInBaseData("ammoCapacityMultiplier", exists);
                SetPropertyExists("ammoCapacityMultiplier", exists);
                _armorChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "armorChange", out exists);
                SetPropertyExistsInBaseData("armorChange", exists);
                SetPropertyExists("armorChange", exists);
                _maneuveringMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "maneuveringMultiplier", out exists);
                SetPropertyExistsInBaseData("maneuveringMultiplier", exists);
                SetPropertyExists("maneuveringMultiplier", exists);
                _speedChangePercent = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "speedChangePercent", out exists);
                SetPropertyExistsInBaseData("speedChangePercent", exists);
                SetPropertyExists("speedChangePercent", exists);
                _timeTillCruiseMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillCruiseMultiplier", out exists);
                SetPropertyExistsInBaseData("timeTillCruiseMultiplier", exists);
                SetPropertyExists("timeTillCruiseMultiplier", exists);
                _afterburnerMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "afterburnerMultiplier", out exists);
                SetPropertyExistsInBaseData("afterburnerMultiplier", exists);
                SetPropertyExists("afterburnerMultiplier", exists);
                _fuelChangePercent = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "fuelChangePercent", out exists);
                SetPropertyExistsInBaseData("fuelChangePercent", exists);
                SetPropertyExists("fuelChangePercent", exists);
                _projectileSpeedChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "projectileSpeedChange", out exists);
                SetPropertyExistsInBaseData("projectileSpeedChange", exists);
                SetPropertyExists("projectileSpeedChange", exists);
                _fireRateMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "fireRateMultiplier", out exists);
                SetPropertyExistsInBaseData("fireRateMultiplier", exists);
                SetPropertyExists("fireRateMultiplier", exists);
                _secondaryFireReloadMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "secondaryFireReloadMultiplier", out exists);
                SetPropertyExistsInBaseData("secondaryFireReloadMultiplier", exists);
                SetPropertyExists("secondaryFireReloadMultiplier", exists);
                _sensorRangeChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "sensorRangeChange", out exists);
                SetPropertyExistsInBaseData("sensorRangeChange", exists);
                SetPropertyExists("sensorRangeChange", exists);
                _detectedRangeChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "detectedRangeChange", out exists);
                SetPropertyExistsInBaseData("detectedRangeChange", exists);
                SetPropertyExists("detectedRangeChange", exists);

                _bCommonUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommonUpgrade", out exists);
                SetPropertyExistsInBaseData("bCommonUpgrade", exists);
                SetPropertyExists("bCommonUpgrade", exists);
                _bAlwaysAvailableUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysAvailableUpgrade", out exists);
                SetPropertyExistsInBaseData("bAlwaysAvailableUpgrade", exists);
                SetPropertyExists("bAlwaysAvailableUpgrade", exists);
                _bIllegalUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIllegalUpgrade", out exists);
                SetPropertyExistsInBaseData("bIllegalUpgrade", exists);
                SetPropertyExists("bIllegalUpgrade", exists);
                _bRemoveCapturedFlag = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRemoveCapturedFlag", out exists);
                SetPropertyExistsInBaseData("bRemoveCapturedFlag", exists);
                SetPropertyExists("bRemoveCapturedFlag", exists);
                _bTurretedDebris = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bTurretedDebris", out exists);
                SetPropertyExistsInBaseData("bTurretedDebris", exists);
                SetPropertyExists("bTurretedDebris", exists);
                _bPersistsOnShipChange = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPersistsOnShipChange", out exists);
                SetPropertyExistsInBaseData("bPersistsOnShipChange", exists);
                SetPropertyExists("bPersistsOnShipChange", exists);
                _bPermitShipCameraLight = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPermitShipCameraLight", out exists);
                SetPropertyExistsInBaseData("bPermitShipCameraLight", exists);
                SetPropertyExists("bPermitShipCameraLight", exists);
                _bOwnedBaseUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOwnedBaseUpgrade", out exists);
                SetPropertyExistsInBaseData("bOwnedBaseUpgrade", exists);
                SetPropertyExists("bOwnedBaseUpgrade", exists);
                _bNoOverworldIndicatorInShipMode = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoOverworldIndicatorInShipMode", out exists);
                SetPropertyExistsInBaseData("bNoOverworldIndicatorInShipMode", exists);
                SetPropertyExists("bNoOverworldIndicatorInShipMode", exists);
                _bGateTravelRefuel = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGateTravelRefuel", out exists);
                SetPropertyExistsInBaseData("bGateTravelRefuel", exists);
                SetPropertyExists("bGateTravelRefuel", exists);
                _bRadiationRefuel = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRadiationRefuel", out exists);
                SetPropertyExistsInBaseData("bRadiationRefuel", exists);
                SetPropertyExists("bRadiationRefuel", exists);

                _turret = DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("turret", exists);
                SetPropertyExists("turret", exists);
            }
        }
    }
}
