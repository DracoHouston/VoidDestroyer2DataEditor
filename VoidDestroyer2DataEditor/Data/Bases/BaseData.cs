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
    class BaseData : VD2Data
    {
        string _objectType;
        string _name;
        string _displayName;
        string _objectID;
        string _faction;
        string _meshName;
        string _wireframeMaterial;
        string _collisionShape;
        string _maxBuildShipClass;
        string _hangarID;
        string _interiorMesh;
        string _dockOrientation;

        List<string> _descriptionText;

        int _isMassInfinite;
        int _rockSubPosition;
        int _miningUnitMax;
        int _tugUnitMax;

        float _oreProductionModifier;
        float _maxCrew;
        float _energyProductionModifier;
        float _foodProductionModifier;
        float _weaponsProductionModifier;
        float _narcoticsProductionModifier;

        bool _bCanResearch;
        bool _bMobile;
        bool _bNoLargeHangarInterior;
        bool _bNoRemoteControlInterior;

        Vector3D _dockingArms;
        Vector3D _dockingArmsEnd;
        Vector3D _dockPosition;
        Vector3D _dockSize;
        Vector3D _miningPlatformPosition;

        largeDockDataStructure _largeDock;

        List<propulsionDataStructure> _propulsion;
        List<physicalRotatingElementDataStructure> _physicalRotatingElement;
        List<alwaysOnEffectDataStructure> _alwaysOnEffect;

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

        [Description("faction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string faction
        {
            get
            {
                return _faction;
            }
            set
            {
                _faction = value;
                SetPropertyEdited("faction", true);
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

        [Description("wireframeMaterial is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string wireframeMaterial
        {
            get
            {
                return _wireframeMaterial;
            }
            set
            {
                _wireframeMaterial = value;
                SetPropertyEdited("wireframeMaterial", true);
            }
        }

        [Description("collisionShape is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string collisionShape
        {
            get
            {
                return _collisionShape;
            }
            set
            {
                _collisionShape = value;
                SetPropertyEdited("collisionShape", true);
            }
        }

        [Description("maxBuildShipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string maxBuildShipClass
        {
            get
            {
                return _maxBuildShipClass;
            }
            set
            {
                _maxBuildShipClass = value;
                SetPropertyEdited("maxBuildShipClass", true);
            }
        }

        [Description("hangarID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string hangarID
        {
            get
            {
                return _hangarID;
            }
            set
            {
                _hangarID = value;
                SetPropertyEdited("hangarID", true);
            }
        }

        [Description("interiorMesh is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string interiorMesh
        {
            get
            {
                return _interiorMesh;
            }
            set
            {
                _interiorMesh = value;
                SetPropertyEdited("interiorMesh", true);
            }
        }

        [Description("dockOrientation is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string dockOrientation
        {
            get
            {
                return _dockOrientation;
            }
            set
            {
                _dockOrientation = value;
                SetPropertyEdited("dockOrientation", true);
            }
        }


        [Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> descriptionText
        {
            get
            {
                return _descriptionText;
            }
            set
            {
                _descriptionText = value;
                SetPropertyEdited("descriptionText", true);
            }
        }


        [Description("isMassInfinite is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int isMassInfinite
        {
            get
            {
                return _isMassInfinite;
            }
            set
            {
                _isMassInfinite = value;
                SetPropertyEdited("isMassInfinite", true);
            }
        }

        [Description("rockSubPosition is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rockSubPosition
        {
            get
            {
                return _rockSubPosition;
            }
            set
            {
                _rockSubPosition = value;
                SetPropertyEdited("rockSubPosition", true);
            }
        }

        [Description("miningUnitMax is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int miningUnitMax
        {
            get
            {
                return _miningUnitMax;
            }
            set
            {
                _miningUnitMax = value;
                SetPropertyEdited("miningUnitMax", true);
            }
        }

        [Description("tugUnitMax is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int tugUnitMax
        {
            get
            {
                return _tugUnitMax;
            }
            set
            {
                _tugUnitMax = value;
                SetPropertyEdited("tugUnitMax", true);
            }
        }


        [Description("oreProductionModifier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float oreProductionModifier
        {
            get
            {
                return _oreProductionModifier;
            }
            set
            {
                _oreProductionModifier = value;
                SetPropertyEdited("oreProductionModifier", true);
            }
        }

        [Description("maxCrew is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float maxCrew
        {
            get
            {
                return _maxCrew;
            }
            set
            {
                _maxCrew = value;
                SetPropertyEdited("maxCrew", true);
            }
        }

        [Description("energyProductionModifier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float energyProductionModifier
        {
            get
            {
                return _energyProductionModifier;
            }
            set
            {
                _energyProductionModifier = value;
                SetPropertyEdited("energyProductionModifier", true);
            }
        }

        [Description("foodProductionModifier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float foodProductionModifier
        {
            get
            {
                return _foodProductionModifier;
            }
            set
            {
                _foodProductionModifier = value;
                SetPropertyEdited("foodProductionModifier", true);
            }
        }

        [Description("weaponsProductionModifier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float weaponsProductionModifier
        {
            get
            {
                return _weaponsProductionModifier;
            }
            set
            {
                _weaponsProductionModifier = value;
                SetPropertyEdited("weaponsProductionModifier", true);
            }
        }

        [Description("narcoticsProductionModifier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float narcoticsProductionModifier
        {
            get
            {
                return _narcoticsProductionModifier;
            }
            set
            {
                _narcoticsProductionModifier = value;
                SetPropertyEdited("narcoticsProductionModifier", true);
            }
        }


        [Description("bCanResearch is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCanResearch
        {
            get
            {
                return _bCanResearch;
            }
            set
            {
                _bCanResearch = value;
                SetPropertyEdited("bCanResearch", true);
            }
        }

        [Description("bMobile is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bMobile
        {
            get
            {
                return _bMobile;
            }
            set
            {
                _bMobile = value;
                SetPropertyEdited("bMobile", true);
            }
        }

        [Description("bNoLargeHangarInterior is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoLargeHangarInterior
        {
            get
            {
                return _bNoLargeHangarInterior;
            }
            set
            {
                _bNoLargeHangarInterior = value;
                SetPropertyEdited("bNoLargeHangarInterior", true);
            }
        }

        [Description("bNoRemoteControlInterior is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoRemoteControlInterior
        {
            get
            {
                return _bNoRemoteControlInterior;
            }
            set
            {
                _bNoRemoteControlInterior = value;
                SetPropertyEdited("bNoRemoteControlInterior", true);
            }
        }


        [Description("dockingArms is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D dockingArms
        {
            get
            {
                return _dockingArms;
            }
            set
            {
                _dockingArms = value;
                SetPropertyEdited("dockingArms", true);
            }
        }

        [Description("dockingArmsEnd is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D dockingArmsEnd
        {
            get
            {
                return _dockingArmsEnd;
            }
            set
            {
                _dockingArmsEnd = value;
                SetPropertyEdited("dockingArmsEnd", true);
            }
        }

        [Description("dockPosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D dockPosition
        {
            get
            {
                return _dockPosition;
            }
            set
            {
                _dockPosition = value;
                SetPropertyEdited("dockPosition", true);
            }
        }

        [Description("dockSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D dockSize
        {
            get
            {
                return _dockSize;
            }
            set
            {
                _dockSize = value;
                SetPropertyEdited("dockSize", true);
            }
        }

        [Description("miningPlatformPosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D miningPlatformPosition
        {
            get
            {
                return _miningPlatformPosition;
            }
            set
            {
                _miningPlatformPosition = value;
                SetPropertyEdited("miningPlatformPosition", true);
            }
        }


        [Description("largeDock is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public largeDockDataStructure largeDock
        {
            get
            {
                return _largeDock;
            }
            set
            {
                _largeDock = value;
                SetPropertyEdited("largeDock", true);
            }
        }


        [Description("propulsion is a collection of datastructures"), Category("Data Structure Collections")]
        public List<propulsionDataStructure> propulsion
        {
            get
            {
                return _propulsion;
            }
            set
            {
                _propulsion = value;
                SetPropertyEdited("propulsion", true);
            }
        }

        [Description("physicalRotatingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public List<physicalRotatingElementDataStructure> physicalRotatingElement
        {
            get
            {
                return _physicalRotatingElement;
            }
            set
            {
                _physicalRotatingElement = value;
                SetPropertyEdited("physicalRotatingElement", true);
            }
        }

        [Description("alwaysOnEffect is a collection of datastructures"), Category("Data Structure Collections")]
        public List<alwaysOnEffectDataStructure> alwaysOnEffect
        {
            get
            {
                return _alwaysOnEffect;
            }
            set
            {
                _alwaysOnEffect = value;
                SetPropertyEdited("alwaysOnEffect", true);
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("displayName");
            InitProperty("objectID");
            InitProperty("faction");
            InitProperty("meshName");
            InitProperty("wireframeMaterial");
            InitProperty("collisionShape");
            InitProperty("maxBuildShipClass");
            InitProperty("hangarID");
            InitProperty("interiorMesh");
            InitProperty("dockOrientation");

            InitProperty("descriptionText");

            InitProperty("isMassInfinite");
            InitProperty("rockSubPosition");
            InitProperty("miningUnitMax");
            InitProperty("tugUnitMax");

            InitProperty("oreProductionModifier");
            InitProperty("maxCrew");
            InitProperty("energyProductionModifier");
            InitProperty("foodProductionModifier");
            InitProperty("weaponsProductionModifier");
            InitProperty("narcoticsProductionModifier");

            InitProperty("bCanResearch");
            InitProperty("bMobile");
            InitProperty("bNoLargeHangarInterior");
            InitProperty("bNoRemoteControlInterior");

            InitProperty("dockingArms");
            InitProperty("dockingArmsEnd");
            InitProperty("dockPosition");
            InitProperty("dockSize");
            InitProperty("miningPlatformPosition");

            InitProperty("largeDock");

            InitProperty("propulsion");
            InitProperty("physicalRotatingElement");
            InitProperty("alwaysOnEffect");
        }

        public BaseData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType", out exists);
                SetPropertyExistsInBaseData("objectType", exists);
                SetPropertyExists("objectType", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                SetPropertyExistsInBaseData("name", exists);
                SetPropertyExists("name", exists);
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName", out exists);
                SetPropertyExistsInBaseData("displayName", exists);
                SetPropertyExists("displayName", exists);
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction", out exists);
                SetPropertyExistsInBaseData("faction", exists);
                SetPropertyExists("faction", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                SetPropertyExistsInBaseData("meshName", exists);
                SetPropertyExists("meshName", exists);
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial", out exists);
                SetPropertyExistsInBaseData("wireframeMaterial", exists);
                SetPropertyExists("wireframeMaterial", exists);
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape", out exists);
                SetPropertyExistsInBaseData("collisionShape", exists);
                SetPropertyExists("collisionShape", exists);
                _maxBuildShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "maxBuildShipClass", out exists);
                SetPropertyExistsInBaseData("maxBuildShipClass", exists);
                SetPropertyExists("maxBuildShipClass", exists);
                _hangarID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hangarID", out exists);
                SetPropertyExistsInBaseData("hangarID", exists);
                SetPropertyExists("hangarID", exists);
                _interiorMesh = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "interiorMesh", out exists);
                SetPropertyExistsInBaseData("interiorMesh", exists);
                SetPropertyExists("interiorMesh", exists);
                _dockOrientation = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dockOrientation", out exists);
                SetPropertyExistsInBaseData("dockOrientation", exists);
                SetPropertyExists("dockOrientation", exists);

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText", out exists);
                SetPropertyExistsInBaseData("descriptionText", exists);
                SetPropertyExists("descriptionText", exists);

                _isMassInfinite = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "isMassInfinite", out exists);
                SetPropertyExistsInBaseData("isMassInfinite", exists);
                SetPropertyExists("isMassInfinite", exists);
                _rockSubPosition = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rockSubPosition", out exists);
                SetPropertyExistsInBaseData("rockSubPosition", exists);
                SetPropertyExists("rockSubPosition", exists);
                _miningUnitMax = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "miningUnitMax", out exists);
                SetPropertyExistsInBaseData("miningUnitMax", exists);
                SetPropertyExists("miningUnitMax", exists);
                _tugUnitMax = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "tugUnitMax", out exists);
                SetPropertyExistsInBaseData("tugUnitMax", exists);
                SetPropertyExists("tugUnitMax", exists);

                _oreProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "oreProductionModifier", out exists);
                SetPropertyExistsInBaseData("oreProductionModifier", exists);
                SetPropertyExists("oreProductionModifier", exists);
                _maxCrew = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "maxCrew", out exists);
                SetPropertyExistsInBaseData("maxCrew", exists);
                SetPropertyExists("maxCrew", exists);
                _energyProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "energyProductionModifier", out exists);
                SetPropertyExistsInBaseData("energyProductionModifier", exists);
                SetPropertyExists("energyProductionModifier", exists);
                _foodProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "foodProductionModifier", out exists);
                SetPropertyExistsInBaseData("foodProductionModifier", exists);
                SetPropertyExists("foodProductionModifier", exists);
                _weaponsProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "weaponsProductionModifier", out exists);
                SetPropertyExistsInBaseData("weaponsProductionModifier", exists);
                SetPropertyExists("weaponsProductionModifier", exists);
                _narcoticsProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "narcoticsProductionModifier", out exists);
                SetPropertyExistsInBaseData("narcoticsProductionModifier", exists);
                SetPropertyExists("narcoticsProductionModifier", exists);

                _bCanResearch = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanResearch", out exists);
                SetPropertyExistsInBaseData("bCanResearch", exists);
                SetPropertyExists("bCanResearch", exists);
                _bMobile = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bMobile", out exists);
                SetPropertyExistsInBaseData("bMobile", exists);
                SetPropertyExists("bMobile", exists);
                _bNoLargeHangarInterior = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoLargeHangarInterior", out exists);
                SetPropertyExistsInBaseData("bNoLargeHangarInterior", exists);
                SetPropertyExists("bNoLargeHangarInterior", exists);
                _bNoRemoteControlInterior = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoRemoteControlInterior", out exists);
                SetPropertyExistsInBaseData("bNoRemoteControlInterior", exists);
                SetPropertyExists("bNoRemoteControlInterior", exists);

                _dockingArms = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArms", out exists);
                SetPropertyExistsInBaseData("dockingArms", exists);
                SetPropertyExists("dockingArms", exists);
                _dockingArmsEnd = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArmsEnd", out exists);
                SetPropertyExistsInBaseData("dockingArmsEnd", exists);
                SetPropertyExists("dockingArmsEnd", exists);
                _dockPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockPosition", out exists);
                SetPropertyExistsInBaseData("dockPosition", exists);
                SetPropertyExists("dockPosition", exists);
                _dockSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockSize", out exists);
                SetPropertyExistsInBaseData("dockSize", exists);
                SetPropertyExists("dockSize", exists);
                _miningPlatformPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "miningPlatformPosition", out exists);
                SetPropertyExistsInBaseData("miningPlatformPosition", exists);
                SetPropertyExists("miningPlatformPosition", exists);

                _largeDock = DataStructureParseHelpers.GetlargeDockDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("largeDock", exists);
                SetPropertyExists("largeDock", exists);

                _propulsion = DataStructureParseHelpers.GetpropulsionDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("propulsion", exists);
                SetPropertyExists("propulsion", exists);
                _physicalRotatingElement = DataStructureParseHelpers.GetphysicalRotatingElementDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("physicalRotatingElement", exists);
                SetPropertyExists("physicalRotatingElement", exists);
                _alwaysOnEffect = DataStructureParseHelpers.GetalwaysOnEffectDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("alwaysOnEffect", exists);
                SetPropertyExists("alwaysOnEffect", exists);
            }
        }
    }
}
