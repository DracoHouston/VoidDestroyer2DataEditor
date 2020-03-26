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

        [Description("displayName is a plaintext string"), Category("Plaintext Strings")]
        public string displayName
        {
            get => _displayName;
            set => _displayName = value;
        }

        [Description("objectID is a plaintext string"), Category("Plaintext Strings")]
        public string objectID
        {
            get => _objectID;
            set => _objectID = value;
        }

        [Description("upgradeCategory is a plaintext string"), Category("Plaintext Strings")]
        public string upgradeCategory
        {
            get => _upgradeCategory;
            set => _upgradeCategory = value;
        }

        [Description("upgradeType is a plaintext string"), Category("Plaintext Strings")]
        public string upgradeType
        {
            get => _upgradeType;
            set => _upgradeType = value;
        }

        [Description("projectileAmmoID is a plaintext string"), Category("Plaintext Strings")]
        public string projectileAmmoID
        {
            get => _projectileAmmoID;
            set => _projectileAmmoID = value;
        }

        [Description("requiredMissionID is a plaintext string"), Category("Plaintext Strings")]
        public string requiredMissionID
        {
            get => _requiredMissionID;
            set => _requiredMissionID = value;
        }


        [Description("description is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> description
        {
            get => _description;
            set => _description = value;
        }

        [Description("skybox is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> skybox
        {
            get => _skybox;
            set => _skybox = value;
        }


        [Description("activeUpgradeSlotChange is an integer"), Category("Integers")]
        public int activeUpgradeSlotChange
        {
            get => _activeUpgradeSlotChange;
            set => _activeUpgradeSlotChange = value;
        }

        [Description("primaryUpgradeSlotChange is an integer"), Category("Integers")]
        public int primaryUpgradeSlotChange
        {
            get => _primaryUpgradeSlotChange;
            set => _primaryUpgradeSlotChange = value;
        }

        [Description("cost is an integer"), Category("Integers")]
        public int cost
        {
            get => _cost;
            set => _cost = value;
        }

        [Description("shieldHealthChange is an integer"), Category("Integers")]
        public int shieldHealthChange
        {
            get => _shieldHealthChange;
            set => _shieldHealthChange = value;
        }

        [Description("afterburnerCapacity is an integer"), Category("Integers")]
        public int afterburnerCapacity
        {
            get => _afterburnerCapacity;
            set => _afterburnerCapacity = value;
        }

        [Description("afterburnerRechargeRate is an integer"), Category("Integers")]
        public int afterburnerRechargeRate
        {
            get => _afterburnerRechargeRate;
            set => _afterburnerRechargeRate = value;
        }


        [Description("addCostAsPercentOfShip is a real number"), Category("Real Numbers")]
        public float addCostAsPercentOfShip
        {
            get => _addCostAsPercentOfShip;
            set => _addCostAsPercentOfShip = value;
        }

        [Description("afterBurnerCapacityMultiplier is a real number"), Category("Real Numbers")]
        public float afterBurnerCapacityMultiplier
        {
            get => _afterBurnerCapacityMultiplier;
            set => _afterBurnerCapacityMultiplier = value;
        }

        [Description("ammoCapacityMultiplier is a real number"), Category("Real Numbers")]
        public float ammoCapacityMultiplier
        {
            get => _ammoCapacityMultiplier;
            set => _ammoCapacityMultiplier = value;
        }

        [Description("armorChange is a real number"), Category("Real Numbers")]
        public float armorChange
        {
            get => _armorChange;
            set => _armorChange = value;
        }

        [Description("maneuveringMultiplier is a real number"), Category("Real Numbers")]
        public float maneuveringMultiplier
        {
            get => _maneuveringMultiplier;
            set => _maneuveringMultiplier = value;
        }

        [Description("speedChangePercent is a real number"), Category("Real Numbers")]
        public float speedChangePercent
        {
            get => _speedChangePercent;
            set => _speedChangePercent = value;
        }

        [Description("timeTillCruiseMultiplier is a real number"), Category("Real Numbers")]
        public float timeTillCruiseMultiplier
        {
            get => _timeTillCruiseMultiplier;
            set => _timeTillCruiseMultiplier = value;
        }

        [Description("afterburnerMultiplier is a real number"), Category("Real Numbers")]
        public float afterburnerMultiplier
        {
            get => _afterburnerMultiplier;
            set => _afterburnerMultiplier = value;
        }

        [Description("fuelChangePercent is a real number"), Category("Real Numbers")]
        public float fuelChangePercent
        {
            get => _fuelChangePercent;
            set => _fuelChangePercent = value;
        }

        [Description("projectileSpeedChange is a real number"), Category("Real Numbers")]
        public float projectileSpeedChange
        {
            get => _projectileSpeedChange;
            set => _projectileSpeedChange = value;
        }

        [Description("fireRateMultiplier is a real number"), Category("Real Numbers")]
        public float fireRateMultiplier
        {
            get => _fireRateMultiplier;
            set => _fireRateMultiplier = value;
        }

        [Description("secondaryFireReloadMultiplier is a real number"), Category("Real Numbers")]
        public float secondaryFireReloadMultiplier
        {
            get => _secondaryFireReloadMultiplier;
            set => _secondaryFireReloadMultiplier = value;
        }

        [Description("sensorRangeChange is a real number"), Category("Real Numbers")]
        public float sensorRangeChange
        {
            get => _sensorRangeChange;
            set => _sensorRangeChange = value;
        }

        [Description("detectedRangeChange is a real number"), Category("Real Numbers")]
        public float detectedRangeChange
        {
            get => _detectedRangeChange;
            set => _detectedRangeChange = value;
        }


        [Description("bCommonUpgrade is a boolean value"), Category("Booleans")]
        public bool bCommonUpgrade
        {
            get => _bCommonUpgrade;
            set => _bCommonUpgrade = value;
        }

        [Description("bAlwaysAvailableUpgrade is a boolean value"), Category("Booleans")]
        public bool bAlwaysAvailableUpgrade
        {
            get => _bAlwaysAvailableUpgrade;
            set => _bAlwaysAvailableUpgrade = value;
        }

        [Description("bIllegalUpgrade is a boolean value"), Category("Booleans")]
        public bool bIllegalUpgrade
        {
            get => _bIllegalUpgrade;
            set => _bIllegalUpgrade = value;
        }

        [Description("bRemoveCapturedFlag is a boolean value"), Category("Booleans")]
        public bool bRemoveCapturedFlag
        {
            get => _bRemoveCapturedFlag;
            set => _bRemoveCapturedFlag = value;
        }

        [Description("bTurretedDebris is a boolean value"), Category("Booleans")]
        public bool bTurretedDebris
        {
            get => _bTurretedDebris;
            set => _bTurretedDebris = value;
        }

        [Description("bPersistsOnShipChange is a boolean value"), Category("Booleans")]
        public bool bPersistsOnShipChange
        {
            get => _bPersistsOnShipChange;
            set => _bPersistsOnShipChange = value;
        }

        [Description("bPermitShipCameraLight is a boolean value"), Category("Booleans")]
        public bool bPermitShipCameraLight
        {
            get => _bPermitShipCameraLight;
            set => _bPermitShipCameraLight = value;
        }

        [Description("bOwnedBaseUpgrade is a boolean value"), Category("Booleans")]
        public bool bOwnedBaseUpgrade
        {
            get => _bOwnedBaseUpgrade;
            set => _bOwnedBaseUpgrade = value;
        }

        [Description("bNoOverworldIndicatorInShipMode is a boolean value"), Category("Booleans")]
        public bool bNoOverworldIndicatorInShipMode
        {
            get => _bNoOverworldIndicatorInShipMode;
            set => _bNoOverworldIndicatorInShipMode = value;
        }

        [Description("bGateTravelRefuel is a boolean value"), Category("Booleans")]
        public bool bGateTravelRefuel
        {
            get => _bGateTravelRefuel;
            set => _bGateTravelRefuel = value;
        }

        [Description("bRadiationRefuel is a boolean value"), Category("Booleans")]
        public bool bRadiationRefuel
        {
            get => _bRadiationRefuel;
            set => _bRadiationRefuel = value;
        }


        [Description("turret is a collection of datastructures"), Category("Data Structure Collections")]
        public List<turretDataStructure> turret
        {
            get => _turret;
            set => _turret = value;
        }


        public PrimaryUpgradeData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _upgradeCategory = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "upgradeCategory");
                _upgradeType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "upgradeType");
                _projectileAmmoID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileAmmoID");
                _requiredMissionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "requiredMissionID");

                _description = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "description");
                _skybox = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "skybox");

                _activeUpgradeSlotChange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "activeUpgradeSlotChange");
                _primaryUpgradeSlotChange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "primaryUpgradeSlotChange");
                _cost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "cost");
                _shieldHealthChange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shieldHealthChange");
                _afterburnerCapacity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "afterburnerCapacity");
                _afterburnerRechargeRate = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "afterburnerRechargeRate");

                _addCostAsPercentOfShip = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "addCostAsPercentOfShip");
                _afterBurnerCapacityMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "afterBurnerCapacityMultiplier");
                _ammoCapacityMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "ammoCapacityMultiplier");
                _armorChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "armorChange");
                _maneuveringMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "maneuveringMultiplier");
                _speedChangePercent = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "speedChangePercent");
                _timeTillCruiseMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillCruiseMultiplier");
                _afterburnerMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "afterburnerMultiplier");
                _fuelChangePercent = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "fuelChangePercent");
                _projectileSpeedChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "projectileSpeedChange");
                _fireRateMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "fireRateMultiplier");
                _secondaryFireReloadMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "secondaryFireReloadMultiplier");
                _sensorRangeChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "sensorRangeChange");
                _detectedRangeChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "detectedRangeChange");

                _bCommonUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommonUpgrade");
                _bAlwaysAvailableUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysAvailableUpgrade");
                _bIllegalUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIllegalUpgrade");
                _bRemoveCapturedFlag = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRemoveCapturedFlag");
                _bTurretedDebris = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bTurretedDebris");
                _bPersistsOnShipChange = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPersistsOnShipChange");
                _bPermitShipCameraLight = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPermitShipCameraLight");
                _bOwnedBaseUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOwnedBaseUpgrade");
                _bNoOverworldIndicatorInShipMode = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoOverworldIndicatorInShipMode");
                _bGateTravelRefuel = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGateTravelRefuel");
                _bRadiationRefuel = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRadiationRefuel");

                _turret = DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(DataXMLDoc);
            }
        }
    }
}
