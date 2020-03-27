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

        [Description("shipActiveUpgradeType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shipActiveUpgradeType
        {
            get
            {
                return _shipActiveUpgradeType;
            }
            set
            {
                _shipActiveUpgradeType = value;
                SetPropertyEdited("shipActiveUpgradeType", true);
            }
        }

        [Description("imageSet is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string imageSet
        {
            get
            {
                return _imageSet;
            }
            set
            {
                _imageSet = value;
                SetPropertyEdited("imageSet", true);
            }
        }

        [Description("image is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                SetPropertyEdited("image", true);
            }
        }

        [Description("particleSystemName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string particleSystemName
        {
            get
            {
                return _particleSystemName;
            }
            set
            {
                _particleSystemName = value;
                SetPropertyEdited("particleSystemName", true);
            }
        }

        [Description("shieldObjectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shieldObjectID
        {
            get
            {
                return _shieldObjectID;
            }
            set
            {
                _shieldObjectID = value;
                SetPropertyEdited("shieldObjectID", true);
            }
        }

        [Description("activeSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string activeSoundID
        {
            get
            {
                return _activeSoundID;
            }
            set
            {
                _activeSoundID = value;
                SetPropertyEdited("activeSoundID", true);
            }
        }

        [Description("missileID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string missileID
        {
            get
            {
                return _missileID;
            }
            set
            {
                _missileID = value;
                SetPropertyEdited("missileID", true);
            }
        }

        [Description("platformObjectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string platformObjectID
        {
            get
            {
                return _platformObjectID;
            }
            set
            {
                _platformObjectID = value;
                SetPropertyEdited("platformObjectID", true);
            }
        }

        [Description("shipID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shipID
        {
            get
            {
                return _shipID;
            }
            set
            {
                _shipID = value;
                SetPropertyEdited("shipID", true);
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

        [Description("rechargeTime is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rechargeTime
        {
            get
            {
                return _rechargeTime;
            }
            set
            {
                _rechargeTime = value;
                SetPropertyEdited("rechargeTime", true);
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

        [Description("durationTime is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float durationTime
        {
            get
            {
                return _durationTime;
            }
            set
            {
                _durationTime = value;
                SetPropertyEdited("durationTime", true);
            }
        }

        [Description("healthShieldRechargePercent is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float healthShieldRechargePercent
        {
            get
            {
                return _healthShieldRechargePercent;
            }
            set
            {
                _healthShieldRechargePercent = value;
                SetPropertyEdited("healthShieldRechargePercent", true);
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

        [Description("bOneAtATimeUpgrade is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bOneAtATimeUpgrade
        {
            get
            {
                return _bOneAtATimeUpgrade;
            }
            set
            {
                _bOneAtATimeUpgrade = value;
                SetPropertyEdited("bOneAtATimeUpgrade", true);
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


        public override void InitAllProperties()
        {
            InitProperty("displayName");
            InitProperty("objectID");
            InitProperty("upgradeCategory");
            InitProperty("upgradeType");
            InitProperty("shipActiveUpgradeType");
            InitProperty("imageSet");
            InitProperty("image");
            InitProperty("particleSystemName");
            InitProperty("shieldObjectID");
            InitProperty("activeSoundID");
            InitProperty("missileID");
            InitProperty("platformObjectID");
            InitProperty("shipID");

            InitProperty("description");

            InitProperty("cost");
            InitProperty("rechargeTime");

            InitProperty("addCostAsPercentOfShip");
            InitProperty("durationTime");
            InitProperty("healthShieldRechargePercent");
            InitProperty("maneuveringMultiplier");

            InitProperty("bIllegalUpgrade");
            InitProperty("bOneAtATimeUpgrade");
            InitProperty("bAlwaysAvailableUpgrade");

        }

        public ActiveUpgradeData(string inPath) : base(inPath)
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
                _shipActiveUpgradeType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipActiveUpgradeType", out exists);
                SetPropertyExistsInBaseData("shipActiveUpgradeType", exists);
                SetPropertyExists("shipActiveUpgradeType", exists);
                _imageSet = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "imageSet", out exists);
                SetPropertyExistsInBaseData("imageSet", exists);
                SetPropertyExists("imageSet", exists);
                _image = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "image", out exists);
                SetPropertyExistsInBaseData("image", exists);
                SetPropertyExists("image", exists);
                _particleSystemName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "particleSystemName", out exists);
                SetPropertyExistsInBaseData("particleSystemName", exists);
                SetPropertyExists("particleSystemName", exists);
                _shieldObjectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldObjectID", out exists);
                SetPropertyExistsInBaseData("shieldObjectID", exists);
                SetPropertyExists("shieldObjectID", exists);
                _activeSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "activeSoundID", out exists);
                SetPropertyExistsInBaseData("activeSoundID", exists);
                SetPropertyExists("activeSoundID", exists);
                _missileID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "missileID", out exists);
                SetPropertyExistsInBaseData("missileID", exists);
                SetPropertyExists("missileID", exists);
                _platformObjectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "platformObjectID", out exists);
                SetPropertyExistsInBaseData("platformObjectID", exists);
                SetPropertyExists("platformObjectID", exists);
                _shipID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipID", out exists);
                SetPropertyExistsInBaseData("shipID", exists);
                SetPropertyExists("shipID", exists);

                _description = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "description", out exists);
                SetPropertyExistsInBaseData("description", exists);
                SetPropertyExists("description", exists);

                _cost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "cost", out exists);
                SetPropertyExistsInBaseData("cost", exists);
                SetPropertyExists("cost", exists);
                _rechargeTime = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rechargeTime", out exists);
                SetPropertyExistsInBaseData("rechargeTime", exists);
                SetPropertyExists("rechargeTime", exists);

                _addCostAsPercentOfShip = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "addCostAsPercentOfShip", out exists);
                SetPropertyExistsInBaseData("addCostAsPercentOfShip", exists);
                SetPropertyExists("addCostAsPercentOfShip", exists);
                _durationTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "durationTime", out exists);
                SetPropertyExistsInBaseData("durationTime", exists);
                SetPropertyExists("durationTime", exists);
                _healthShieldRechargePercent = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "healthShieldRechargePercent", out exists);
                SetPropertyExistsInBaseData("healthShieldRechargePercent", exists);
                SetPropertyExists("healthShieldRechargePercent", exists);
                _maneuveringMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "maneuveringMultiplier", out exists);
                SetPropertyExistsInBaseData("maneuveringMultiplier", exists);
                SetPropertyExists("maneuveringMultiplier", exists);

                _bIllegalUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIllegalUpgrade", out exists);
                SetPropertyExistsInBaseData("bIllegalUpgrade", exists);
                SetPropertyExists("bIllegalUpgrade", exists);
                _bOneAtATimeUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOneAtATimeUpgrade", out exists);
                SetPropertyExistsInBaseData("bOneAtATimeUpgrade", exists);
                SetPropertyExists("bOneAtATimeUpgrade", exists);
                _bAlwaysAvailableUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysAvailableUpgrade", out exists);
                SetPropertyExistsInBaseData("bAlwaysAvailableUpgrade", exists);
                SetPropertyExists("bAlwaysAvailableUpgrade", exists);

            }
        }
    }
}
