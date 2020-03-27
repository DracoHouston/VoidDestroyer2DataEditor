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
    class TurretData : VD2Data
    {
        string _weaponType;
        string _weaponID;
        string _name;
        string _turretWeapon;
        string _hardpointID;
        string _linkedMovingElement;
        string _meshName;
        string _turnSoundID;

        int _mineQuota;

        float _barrelDelay;
        float _pitchMax;
        float _dMoveSpeed;

        bool _bAlwaysShowInTactical;
        bool _bPhysicalBody;
        bool _bInvisibleTurret;
        bool _bOssilateTargetAimNodeOffset;

        Vector3D _turretViewPos;

        weaponDirectionDataStructure _weaponDirection;
        targetPriorityListDataStructure _targetPriorityList;

        List<turretBarrelDataStructure> _turretBarrel;

        [Description("weaponType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponType
        {
            get
            {
                return _weaponType;
            }
            set
            {
                _weaponType = value;
                SetPropertyEdited("weaponType", true);
            }
        }

        [Description("weaponID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponID
        {
            get
            {
                return _weaponID;
            }
            set
            {
                _weaponID = value;
                SetPropertyEdited("weaponID", true);
            }
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                SetPropertyEdited("name", true);
            }
        }

        [Description("turretWeapon is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string turretWeapon
        {
            get
            {
                return _turretWeapon;
            }
            set
            {
                _turretWeapon = value;
                SetPropertyEdited("turretWeapon", true);
            }
        }

        [Description("hardpointID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string hardpointID
        {
            get
            {
                return _hardpointID;
            }
            set
            {
                _hardpointID = value;
                SetPropertyEdited("hardpointID", true);
            }
        }

        [Description("linkedMovingElement is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string linkedMovingElement
        {
            get
            {
                return _linkedMovingElement;
            }
            set
            {
                _linkedMovingElement = value;
                SetPropertyEdited("linkedMovingElement", true);
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

        [Description("turnSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string turnSoundID
        {
            get
            {
                return _turnSoundID;
            }
            set
            {
                _turnSoundID = value;
                SetPropertyEdited("turnSoundID", true);
            }
        }


        [Description("mineQuota is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int mineQuota
        {
            get
            {
                return _mineQuota;
            }
            set
            {
                _mineQuota = value;
                SetPropertyEdited("mineQuota", true);
            }
        }


        [Description("barrelDelay is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float barrelDelay
        {
            get
            {
                return _barrelDelay;
            }
            set
            {
                _barrelDelay = value;
                SetPropertyEdited("barrelDelay", true);
            }
        }

        [Description("pitchMax is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float pitchMax
        {
            get
            {
                return _pitchMax;
            }
            set
            {
                _pitchMax = value;
                SetPropertyEdited("pitchMax", true);
            }
        }

        [Description("dMoveSpeed is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float dMoveSpeed
        {
            get
            {
                return _dMoveSpeed;
            }
            set
            {
                _dMoveSpeed = value;
                SetPropertyEdited("dMoveSpeed", true);
            }
        }


        [Description("bAlwaysShowInTactical is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAlwaysShowInTactical
        {
            get
            {
                return _bAlwaysShowInTactical;
            }
            set
            {
                _bAlwaysShowInTactical = value;
                SetPropertyEdited("bAlwaysShowInTactical", true);
            }
        }

        [Description("bPhysicalBody is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPhysicalBody
        {
            get
            {
                return _bPhysicalBody;
            }
            set
            {
                _bPhysicalBody = value;
                SetPropertyEdited("bPhysicalBody", true);
            }
        }

        [Description("bInvisibleTurret is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bInvisibleTurret
        {
            get
            {
                return _bInvisibleTurret;
            }
            set
            {
                _bInvisibleTurret = value;
                SetPropertyEdited("bInvisibleTurret", true);
            }
        }

        [Description("bOssilateTargetAimNodeOffset is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bOssilateTargetAimNodeOffset
        {
            get
            {
                return _bOssilateTargetAimNodeOffset;
            }
            set
            {
                _bOssilateTargetAimNodeOffset = value;
                SetPropertyEdited("bOssilateTargetAimNodeOffset", true);
            }
        }


        [Description("turretViewPos is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D turretViewPos
        {
            get
            {
                return _turretViewPos;
            }
            set
            {
                _turretViewPos = value;
                SetPropertyEdited("turretViewPos", true);
            }
        }


        [Description("weaponDirection is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public weaponDirectionDataStructure weaponDirection
        {
            get
            {
                return _weaponDirection;
            }
            set
            {
                _weaponDirection = value;
                SetPropertyEdited("weaponDirection", true);
            }
        }

        [Description("targetPriorityList is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public targetPriorityListDataStructure targetPriorityList
        {
            get
            {
                return _targetPriorityList;
            }
            set
            {
                _targetPriorityList = value;
                SetPropertyEdited("targetPriorityList", true);
            }
        }


        [Description("turretBarrel is a collection of datastructures"), Category("Data Structure Collections")]
        public List<turretBarrelDataStructure> turretBarrel
        {
            get
            {
                return _turretBarrel;
            }
            set
            {
                _turretBarrel = value;
                SetPropertyEdited("turretBarrel", true);
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("weaponType");
            InitProperty("weaponID");
            InitProperty("name");
            InitProperty("turretWeapon");
            InitProperty("hardpointID");
            InitProperty("linkedMovingElement");
            InitProperty("meshName");
            InitProperty("turnSoundID");

            InitProperty("mineQuota");

            InitProperty("barrelDelay");
            InitProperty("pitchMax");
            InitProperty("dMoveSpeed");

            InitProperty("bAlwaysShowInTactical");
            InitProperty("bPhysicalBody");
            InitProperty("bInvisibleTurret");
            InitProperty("bOssilateTargetAimNodeOffset");

            InitProperty("turretViewPos");

            InitProperty("weaponDirection");
            InitProperty("targetPriorityList");

            InitProperty("turretBarrel");
        }

        public TurretData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _weaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponType", out exists);
                SetPropertyExistsInBaseData("weaponType", exists);
                SetPropertyExists("weaponType", exists);
                _weaponID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponID", out exists);
                SetPropertyExistsInBaseData("weaponID", exists);
                SetPropertyExists("weaponID", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                SetPropertyExistsInBaseData("name", exists);
                SetPropertyExists("name", exists);
                _turretWeapon = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "turretWeapon", out exists);
                SetPropertyExistsInBaseData("turretWeapon", exists);
                SetPropertyExists("turretWeapon", exists);
                _hardpointID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hardpointID", out exists);
                SetPropertyExistsInBaseData("hardpointID", exists);
                SetPropertyExists("hardpointID", exists);
                _linkedMovingElement = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "linkedMovingElement", out exists);
                SetPropertyExistsInBaseData("linkedMovingElement", exists);
                SetPropertyExists("linkedMovingElement", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                SetPropertyExistsInBaseData("meshName", exists);
                SetPropertyExists("meshName", exists);
                _turnSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "turnSoundID", out exists);
                SetPropertyExistsInBaseData("turnSoundID", exists);
                SetPropertyExists("turnSoundID", exists);

                _mineQuota = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "mineQuota", out exists);
                SetPropertyExistsInBaseData("mineQuota", exists);
                SetPropertyExists("mineQuota", exists);

                _barrelDelay = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "barrelDelay", out exists);
                SetPropertyExistsInBaseData("barrelDelay", exists);
                SetPropertyExists("barrelDelay", exists);
                _pitchMax = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pitchMax", out exists);
                SetPropertyExistsInBaseData("pitchMax", exists);
                SetPropertyExists("pitchMax", exists);
                _dMoveSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "dMoveSpeed", out exists);
                SetPropertyExistsInBaseData("dMoveSpeed", exists);
                SetPropertyExists("dMoveSpeed", exists);

                _bAlwaysShowInTactical = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysShowInTactical", out exists);
                SetPropertyExistsInBaseData("bAlwaysShowInTactical", exists);
                SetPropertyExists("bAlwaysShowInTactical", exists);
                _bPhysicalBody = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPhysicalBody", out exists);
                SetPropertyExistsInBaseData("bPhysicalBody", exists);
                SetPropertyExists("bPhysicalBody", exists);
                _bInvisibleTurret = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bInvisibleTurret", out exists);
                SetPropertyExistsInBaseData("bInvisibleTurret", exists);
                SetPropertyExists("bInvisibleTurret", exists);
                _bOssilateTargetAimNodeOffset = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOssilateTargetAimNodeOffset", out exists);
                SetPropertyExistsInBaseData("bOssilateTargetAimNodeOffset", exists);
                SetPropertyExists("bOssilateTargetAimNodeOffset", exists);

                _turretViewPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "turretViewPos", out exists);
                SetPropertyExistsInBaseData("turretViewPos", exists);
                SetPropertyExists("turretViewPos", exists);

                _weaponDirection = DataStructureParseHelpers.GetweaponDirectionDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("weaponDirection", exists);
                SetPropertyExists("weaponDirection", exists);
                _targetPriorityList = DataStructureParseHelpers.GettargetPriorityListDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("targetPriorityList", exists);
                SetPropertyExists("targetPriorityList", exists);

                _turretBarrel = DataStructureParseHelpers.GetturretBarrelDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("turretBarrel", exists);
                SetPropertyExists("turretBarrel", exists);
            }
        }
    }
}
