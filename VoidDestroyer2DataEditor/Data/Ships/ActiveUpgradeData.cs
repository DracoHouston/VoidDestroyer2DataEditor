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
    class ActiveUpgradeData : VD2Data
    {
        string _displayName;
        string _objectID;
        string _upgradeCategory;
        string _upgradeType;
        string _shipActiveUpgradeType;
        string _imageSet;
        string _image;
        string _particleSystemName;
        string _shieldObjectID;
        string _activeSoundID;
        string _missileID;
        string _platformObjectID;
        string _shipID;

        List<string> _description;

        int _cost;
        int _rechargeTime;

        float _addCostAsPercentOfShip;
        float _durationTime;
        float _healthShieldRechargePercent;
        float _maneuveringMultiplier;

        bool _bIllegalUpgrade;
        bool _bOneAtATimeUpgrade;
        bool _bAlwaysAvailableUpgrade;

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

        [Description("shipActiveUpgradeType is a plaintext string"), Category("Plaintext Strings")]
        public string shipActiveUpgradeType
        {
            get => _shipActiveUpgradeType;
            set => _shipActiveUpgradeType = value;
        }

        [Description("imageSet is a plaintext string"), Category("Plaintext Strings")]
        public string imageSet
        {
            get => _imageSet;
            set => _imageSet = value;
        }

        [Description("image is a plaintext string"), Category("Plaintext Strings")]
        public string image
        {
            get => _image;
            set => _image = value;
        }

        [Description("particleSystemName is a plaintext string"), Category("Plaintext Strings")]
        public string particleSystemName
        {
            get => _particleSystemName;
            set => _particleSystemName = value;
        }

        [Description("shieldObjectID is a plaintext string"), Category("Plaintext Strings")]
        public string shieldObjectID
        {
            get => _shieldObjectID;
            set => _shieldObjectID = value;
        }

        [Description("activeSoundID is a plaintext string"), Category("Plaintext Strings")]
        public string activeSoundID
        {
            get => _activeSoundID;
            set => _activeSoundID = value;
        }

        [Description("missileID is a plaintext string"), Category("Plaintext Strings")]
        public string missileID
        {
            get => _missileID;
            set => _missileID = value;
        }

        [Description("platformObjectID is a plaintext string"), Category("Plaintext Strings")]
        public string platformObjectID
        {
            get => _platformObjectID;
            set => _platformObjectID = value;
        }

        [Description("shipID is a plaintext string"), Category("Plaintext Strings")]
        public string shipID
        {
            get => _shipID;
            set => _shipID = value;
        }


        [Description("description is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> description
        {
            get => _description;
            set => _description = value;
        }


        [Description("cost is an integer"), Category("Integers")]
        public int cost
        {
            get => _cost;
            set => _cost = value;
        }

        [Description("rechargeTime is an integer"), Category("Integers")]
        public int rechargeTime
        {
            get => _rechargeTime;
            set => _rechargeTime = value;
        }


        [Description("addCostAsPercentOfShip is a real number"), Category("Real Numbers")]
        public float addCostAsPercentOfShip
        {
            get => _addCostAsPercentOfShip;
            set => _addCostAsPercentOfShip = value;
        }

        [Description("durationTime is a real number"), Category("Real Numbers")]
        public float durationTime
        {
            get => _durationTime;
            set => _durationTime = value;
        }

        [Description("healthShieldRechargePercent is a real number"), Category("Real Numbers")]
        public float healthShieldRechargePercent
        {
            get => _healthShieldRechargePercent;
            set => _healthShieldRechargePercent = value;
        }

        [Description("maneuveringMultiplier is a real number"), Category("Real Numbers")]
        public float maneuveringMultiplier
        {
            get => _maneuveringMultiplier;
            set => _maneuveringMultiplier = value;
        }


        [Description("bIllegalUpgrade is a boolean value"), Category("Booleans")]
        public bool bIllegalUpgrade
        {
            get => _bIllegalUpgrade;
            set => _bIllegalUpgrade = value;
        }

        [Description("bOneAtATimeUpgrade is a boolean value"), Category("Booleans")]
        public bool bOneAtATimeUpgrade
        {
            get => _bOneAtATimeUpgrade;
            set => _bOneAtATimeUpgrade = value;
        }

        [Description("bAlwaysAvailableUpgrade is a boolean value"), Category("Booleans")]
        public bool bAlwaysAvailableUpgrade
        {
            get => _bAlwaysAvailableUpgrade;
            set => _bAlwaysAvailableUpgrade = value;
        }



        public ActiveUpgradeData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _upgradeCategory = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "upgradeCategory");
                _upgradeType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "upgradeType");
                _shipActiveUpgradeType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipActiveUpgradeType");
                _imageSet = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "imageSet");
                _image = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "image");
                _particleSystemName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "particleSystemName");
                _shieldObjectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldObjectID");
                _activeSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "activeSoundID");
                _missileID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "missileID");
                _platformObjectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "platformObjectID");
                _shipID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipID");

                _description = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "description");

                _cost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "cost");
                _rechargeTime = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rechargeTime");

                _addCostAsPercentOfShip = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "addCostAsPercentOfShip");
                _durationTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "durationTime");
                _healthShieldRechargePercent = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "healthShieldRechargePercent");
                _maneuveringMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "maneuveringMultiplier");

                _bIllegalUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIllegalUpgrade");
                _bOneAtATimeUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOneAtATimeUpgrade");
                _bAlwaysAvailableUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysAvailableUpgrade");

            }
        }
    }
}
