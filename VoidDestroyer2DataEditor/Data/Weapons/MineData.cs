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
    class MineData : VD2Data
    {
        string _objectType;
        string _mineType;
        string _objectID;
        string _meshName;
        string _explosionID;
        string _minimumShipClass;

        int _detectionProximity;
        int _weaponPush;
        int _renderingDistance;

        float _cruiseSpeed;
        float _timeTillCruise;
        float _initialVelocity;
        float _initialLife;
        float _timeTillActive;
        float _damage;
        float _health;
        float _yaw;
        float _pitch;
        float _roll;

        bool _bUseParentTarget;
        bool _bSpinner;
        bool _bKeepTarget;
        bool _bCheckFriendOrFoe;
        bool _bCanAddViaBattleEditorSlider;
        bool _bIgnoresShields;
        bool _bHeatMine;

        mirvDataStructure _mirv;

        [Description("objectType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string objectType
        {
            get
            {
                return _objectType;
            }
            set
            {
                _objectType = value;
                SetPropertyEdited("objectType", true);
            }
        }

        [Description("mineType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string mineType
        {
            get
            {
                return _mineType;
            }
            set
            {
                _mineType = value;
                SetPropertyEdited("mineType", true);
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

        [Description("meshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string meshName
        {
            get
            {
                return _meshName;
            }
            set
            {
                _meshName = value;
                SetPropertyEdited("meshName", true);
            }
        }

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string explosionID
        {
            get
            {
                return _explosionID;
            }
            set
            {
                _explosionID = value;
                SetPropertyEdited("explosionID", true);
            }
        }

        [Description("minimumShipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string minimumShipClass
        {
            get
            {
                return _minimumShipClass;
            }
            set
            {
                _minimumShipClass = value;
                SetPropertyEdited("minimumShipClass", true);
            }
        }


        [Description("detectionProximity is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int detectionProximity
        {
            get
            {
                return _detectionProximity;
            }
            set
            {
                _detectionProximity = value;
                SetPropertyEdited("detectionProximity", true);
            }
        }

        [Description("weaponPush is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int weaponPush
        {
            get
            {
                return _weaponPush;
            }
            set
            {
                _weaponPush = value;
                SetPropertyEdited("weaponPush", true);
            }
        }

        [Description("renderingDistance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int renderingDistance
        {
            get
            {
                return _renderingDistance;
            }
            set
            {
                _renderingDistance = value;
                SetPropertyEdited("renderingDistance", true);
            }
        }


        [Description("cruiseSpeed is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float cruiseSpeed
        {
            get
            {
                return _cruiseSpeed;
            }
            set
            {
                _cruiseSpeed = value;
                SetPropertyEdited("cruiseSpeed", true);
            }
        }

        [Description("timeTillCruise is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float timeTillCruise
        {
            get
            {
                return _timeTillCruise;
            }
            set
            {
                _timeTillCruise = value;
                SetPropertyEdited("timeTillCruise", true);
            }
        }

        [Description("initialVelocity is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float initialVelocity
        {
            get
            {
                return _initialVelocity;
            }
            set
            {
                _initialVelocity = value;
                SetPropertyEdited("initialVelocity", true);
            }
        }

        [Description("initialLife is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float initialLife
        {
            get
            {
                return _initialLife;
            }
            set
            {
                _initialLife = value;
                SetPropertyEdited("initialLife", true);
            }
        }

        [Description("timeTillActive is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float timeTillActive
        {
            get
            {
                return _timeTillActive;
            }
            set
            {
                _timeTillActive = value;
                SetPropertyEdited("timeTillActive", true);
            }
        }

        [Description("damage is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
                SetPropertyEdited("damage", true);
            }
        }

        [Description("health is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
                SetPropertyEdited("health", true);
            }
        }

        [Description("yaw is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float yaw
        {
            get
            {
                return _yaw;
            }
            set
            {
                _yaw = value;
                SetPropertyEdited("yaw", true);
            }
        }

        [Description("pitch is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float pitch
        {
            get
            {
                return _pitch;
            }
            set
            {
                _pitch = value;
                SetPropertyEdited("pitch", true);
            }
        }

        [Description("roll is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float roll
        {
            get
            {
                return _roll;
            }
            set
            {
                _roll = value;
                SetPropertyEdited("roll", true);
            }
        }


        [Description("bUseParentTarget is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bUseParentTarget
        {
            get
            {
                return _bUseParentTarget;
            }
            set
            {
                _bUseParentTarget = value;
                SetPropertyEdited("bUseParentTarget", true);
            }
        }

        [Description("bSpinner is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bSpinner
        {
            get
            {
                return _bSpinner;
            }
            set
            {
                _bSpinner = value;
                SetPropertyEdited("bSpinner", true);
            }
        }

        [Description("bKeepTarget is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bKeepTarget
        {
            get
            {
                return _bKeepTarget;
            }
            set
            {
                _bKeepTarget = value;
                SetPropertyEdited("bKeepTarget", true);
            }
        }

        [Description("bCheckFriendOrFoe is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCheckFriendOrFoe
        {
            get
            {
                return _bCheckFriendOrFoe;
            }
            set
            {
                _bCheckFriendOrFoe = value;
                SetPropertyEdited("bCheckFriendOrFoe", true);
            }
        }

        [Description("bCanAddViaBattleEditorSlider is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCanAddViaBattleEditorSlider
        {
            get
            {
                return _bCanAddViaBattleEditorSlider;
            }
            set
            {
                _bCanAddViaBattleEditorSlider = value;
                SetPropertyEdited("bCanAddViaBattleEditorSlider", true);
            }
        }

        [Description("bIgnoresShields is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bIgnoresShields
        {
            get
            {
                return _bIgnoresShields;
            }
            set
            {
                _bIgnoresShields = value;
                SetPropertyEdited("bIgnoresShields", true);
            }
        }

        [Description("bHeatMine is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bHeatMine
        {
            get
            {
                return _bHeatMine;
            }
            set
            {
                _bHeatMine = value;
                SetPropertyEdited("bHeatMine", true);
            }
        }


        [Description("mirv is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public mirvDataStructure mirv
        {
            get
            {
                return _mirv;
            }
            set
            {
                _mirv = value;
                SetPropertyEdited("mirv", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("mineType");
            InitProperty("objectID");
            InitProperty("meshName");
            InitProperty("explosionID");
            InitProperty("minimumShipClass");

            InitProperty("detectionProximity");
            InitProperty("weaponPush");
            InitProperty("renderingDistance");

            InitProperty("cruiseSpeed");
            InitProperty("timeTillCruise");
            InitProperty("initialVelocity");
            InitProperty("initialLife");
            InitProperty("timeTillActive");
            InitProperty("damage");
            InitProperty("health");
            InitProperty("yaw");
            InitProperty("pitch");
            InitProperty("roll");

            InitProperty("bUseParentTarget");
            InitProperty("bSpinner");
            InitProperty("bKeepTarget");
            InitProperty("bCheckFriendOrFoe");
            InitProperty("bCanAddViaBattleEditorSlider");
            InitProperty("bIgnoresShields");
            InitProperty("bHeatMine");

            InitProperty("mirv");

        }

        public MineData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType", out exists);
                SetPropertyExistsInBaseData("objectType", exists);
                SetPropertyExists("objectType", exists);
                _mineType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "mineType", out exists);
                SetPropertyExistsInBaseData("mineType", exists);
                SetPropertyExists("mineType", exists);
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                SetPropertyExistsInBaseData("meshName", exists);
                SetPropertyExists("meshName", exists);
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                SetPropertyExistsInBaseData("explosionID", exists);
                SetPropertyExists("explosionID", exists);
                _minimumShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "minimumShipClass", out exists);
                SetPropertyExistsInBaseData("minimumShipClass", exists);
                SetPropertyExists("minimumShipClass", exists);

                _detectionProximity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "detectionProximity", out exists);
                SetPropertyExistsInBaseData("detectionProximity", exists);
                SetPropertyExists("detectionProximity", exists);
                _weaponPush = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "weaponPush", out exists);
                SetPropertyExistsInBaseData("weaponPush", exists);
                SetPropertyExists("weaponPush", exists);
                _renderingDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "renderingDistance", out exists);
                SetPropertyExistsInBaseData("renderingDistance", exists);
                SetPropertyExists("renderingDistance", exists);

                _cruiseSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "cruiseSpeed", out exists);
                SetPropertyExistsInBaseData("cruiseSpeed", exists);
                SetPropertyExists("cruiseSpeed", exists);
                _timeTillCruise = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillCruise", out exists);
                SetPropertyExistsInBaseData("timeTillCruise", exists);
                SetPropertyExists("timeTillCruise", exists);
                _initialVelocity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialVelocity", out exists);
                SetPropertyExistsInBaseData("initialVelocity", exists);
                SetPropertyExists("initialVelocity", exists);
                _initialLife = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialLife", out exists);
                SetPropertyExistsInBaseData("initialLife", exists);
                SetPropertyExists("initialLife", exists);
                _timeTillActive = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillActive", out exists);
                SetPropertyExistsInBaseData("timeTillActive", exists);
                SetPropertyExists("timeTillActive", exists);
                _damage = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "damage", out exists);
                SetPropertyExistsInBaseData("damage", exists);
                SetPropertyExists("damage", exists);
                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health", out exists);
                SetPropertyExistsInBaseData("health", exists);
                SetPropertyExists("health", exists);
                _yaw = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "yaw", out exists);
                SetPropertyExistsInBaseData("yaw", exists);
                SetPropertyExists("yaw", exists);
                _pitch = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pitch", out exists);
                SetPropertyExistsInBaseData("pitch", exists);
                SetPropertyExists("pitch", exists);
                _roll = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "roll", out exists);
                SetPropertyExistsInBaseData("roll", exists);
                SetPropertyExists("roll", exists);

                _bUseParentTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bUseParentTarget", out exists);
                SetPropertyExistsInBaseData("bUseParentTarget", exists);
                SetPropertyExists("bUseParentTarget", exists);
                _bSpinner = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSpinner", out exists);
                SetPropertyExistsInBaseData("bSpinner", exists);
                SetPropertyExists("bSpinner", exists);
                _bKeepTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bKeepTarget", out exists);
                SetPropertyExistsInBaseData("bKeepTarget", exists);
                SetPropertyExists("bKeepTarget", exists);
                _bCheckFriendOrFoe = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCheckFriendOrFoe", out exists);
                SetPropertyExistsInBaseData("bCheckFriendOrFoe", exists);
                SetPropertyExists("bCheckFriendOrFoe", exists);
                _bCanAddViaBattleEditorSlider = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanAddViaBattleEditorSlider", out exists);
                SetPropertyExistsInBaseData("bCanAddViaBattleEditorSlider", exists);
                SetPropertyExists("bCanAddViaBattleEditorSlider", exists);
                _bIgnoresShields = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIgnoresShields", out exists);
                SetPropertyExistsInBaseData("bIgnoresShields", exists);
                SetPropertyExists("bIgnoresShields", exists);
                _bHeatMine = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bHeatMine", out exists);
                SetPropertyExistsInBaseData("bHeatMine", exists);
                SetPropertyExists("bHeatMine", exists);

                _mirv = DataStructureParseHelpers.GetmirvDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("mirv", exists);
                SetPropertyExists("mirv", exists);

            }
        }
    }
}
