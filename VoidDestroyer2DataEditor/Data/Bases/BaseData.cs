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

        int _rockSubPosition;
        int _miningUnitMax;
        int _tugUnitMax;

        float _oreProductionModifier;
        float _maxCrew;
        float _energyProductionModifier;
        float _foodProductionModifier;
        float _weaponsProductionModifier;
        float _narcoticsProductionModifier;

        bool _isMassInfinite;
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

        [Description("objectType is a plaintext string"), Category("Plaintext Strings")]
        public string objectType
        {
            get => _objectType;
            set => _objectType = value;
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings")]
        public string name
        {
            get => _name;
            set => _name = value;
        }

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

        [Description("faction is a plaintext string"), Category("Plaintext Strings")]
        public string faction
        {
            get => _faction;
            set => _faction = value;
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings")]
        public string meshName
        {
            get => _meshName;
            set => _meshName = value;
        }

        [Description("wireframeMaterial is a plaintext string"), Category("Plaintext Strings")]
        public string wireframeMaterial
        {
            get => _wireframeMaterial;
            set => _wireframeMaterial = value;
        }

        [Description("collisionShape is a plaintext string"), Category("Plaintext Strings")]
        public string collisionShape
        {
            get => _collisionShape;
            set => _collisionShape = value;
        }

        [Description("maxBuildShipClass is a plaintext string"), Category("Plaintext Strings")]
        public string maxBuildShipClass
        {
            get => _maxBuildShipClass;
            set => _maxBuildShipClass = value;
        }

        [Description("hangarID is a plaintext string"), Category("Plaintext Strings")]
        public string hangarID
        {
            get => _hangarID;
            set => _hangarID = value;
        }

        [Description("interiorMesh is a plaintext string"), Category("Plaintext Strings")]
        public string interiorMesh
        {
            get => _interiorMesh;
            set => _interiorMesh = value;
        }

        [Description("dockOrientation is a plaintext string"), Category("Plaintext Strings")]
        public string dockOrientation
        {
            get => _dockOrientation;
            set => _dockOrientation = value;
        }


        [Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> descriptionText
        {
            get => _descriptionText;
            set => _descriptionText = value;
        }


        [Description("rockSubPosition is an integer"), Category("Integers")]
        public int rockSubPosition
        {
            get => _rockSubPosition;
            set => _rockSubPosition = value;
        }

        [Description("miningUnitMax is an integer"), Category("Integers")]
        public int miningUnitMax
        {
            get => _miningUnitMax;
            set => _miningUnitMax = value;
        }

        [Description("tugUnitMax is an integer"), Category("Integers")]
        public int tugUnitMax
        {
            get => _tugUnitMax;
            set => _tugUnitMax = value;
        }


        [Description("oreProductionModifier is a real number"), Category("Real Numbers")]
        public float oreProductionModifier
        {
            get => _oreProductionModifier;
            set => _oreProductionModifier = value;
        }

        [Description("maxCrew is a real number"), Category("Real Numbers")]
        public float maxCrew
        {
            get => _maxCrew;
            set => _maxCrew = value;
        }

        [Description("energyProductionModifier is a real number"), Category("Real Numbers")]
        public float energyProductionModifier
        {
            get => _energyProductionModifier;
            set => _energyProductionModifier = value;
        }

        [Description("foodProductionModifier is a real number"), Category("Real Numbers")]
        public float foodProductionModifier
        {
            get => _foodProductionModifier;
            set => _foodProductionModifier = value;
        }

        [Description("weaponsProductionModifier is a real number"), Category("Real Numbers")]
        public float weaponsProductionModifier
        {
            get => _weaponsProductionModifier;
            set => _weaponsProductionModifier = value;
        }

        [Description("narcoticsProductionModifier is a real number"), Category("Real Numbers")]
        public float narcoticsProductionModifier
        {
            get => _narcoticsProductionModifier;
            set => _narcoticsProductionModifier = value;
        }


        [Description("isMassInfinite is a boolean value"), Category("Booleans")]
        public bool isMassInfinite
        {
            get => _isMassInfinite;
            set => _isMassInfinite = value;
        }

        [Description("bCanResearch is a boolean value"), Category("Booleans")]
        public bool bCanResearch
        {
            get => _bCanResearch;
            set => _bCanResearch = value;
        }

        [Description("bMobile is a boolean value"), Category("Booleans")]
        public bool bMobile
        {
            get => _bMobile;
            set => _bMobile = value;
        }

        [Description("bNoLargeHangarInterior is a boolean value"), Category("Booleans")]
        public bool bNoLargeHangarInterior
        {
            get => _bNoLargeHangarInterior;
            set => _bNoLargeHangarInterior = value;
        }

        [Description("bNoRemoteControlInterior is a boolean value"), Category("Booleans")]
        public bool bNoRemoteControlInterior
        {
            get => _bNoRemoteControlInterior;
            set => _bNoRemoteControlInterior = value;
        }


        [Description("dockingArms is a 3D vector"), Category("3D Vectors")]
        public Vector3D dockingArms
        {
            get => _dockingArms;
            set => _dockingArms = value;
        }

        [Description("dockingArmsEnd is a 3D vector"), Category("3D Vectors")]
        public Vector3D dockingArmsEnd
        {
            get => _dockingArmsEnd;
            set => _dockingArmsEnd = value;
        }

        [Description("dockPosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D dockPosition
        {
            get => _dockPosition;
            set => _dockPosition = value;
        }

        [Description("dockSize is a 3D vector"), Category("3D Vectors")]
        public Vector3D dockSize
        {
            get => _dockSize;
            set => _dockSize = value;
        }

        [Description("miningPlatformPosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D miningPlatformPosition
        {
            get => _miningPlatformPosition;
            set => _miningPlatformPosition = value;
        }


        [Description("largeDock is a datastructure"), Category("Data Structures")]
        public largeDockDataStructure largeDock
        {
            get => _largeDock;
            set => _largeDock = value;
        }


        [Description("propulsion is a collection of datastructures"), Category("Data Structure Collections")]
        public List<propulsionDataStructure> propulsion
        {
            get => _propulsion;
            set => _propulsion = value;
        }

        [Description("physicalRotatingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public List<physicalRotatingElementDataStructure> physicalRotatingElement
        {
            get => _physicalRotatingElement;
            set => _physicalRotatingElement = value;
        }

        [Description("alwaysOnEffect is a collection of datastructures"), Category("Data Structure Collections")]
        public List<alwaysOnEffectDataStructure> alwaysOnEffect
        {
            get => _alwaysOnEffect;
            set => _alwaysOnEffect = value;
        }


        public BaseData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial");
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape");
                _maxBuildShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "maxBuildShipClass");
                _hangarID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hangarID");
                _interiorMesh = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "interiorMesh");
                _dockOrientation = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dockOrientation");

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText");

                _rockSubPosition = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rockSubPosition");
                _miningUnitMax = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "miningUnitMax");
                _tugUnitMax = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "tugUnitMax");

                _oreProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "oreProductionModifier");
                _maxCrew = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "maxCrew");
                _energyProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "energyProductionModifier");
                _foodProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "foodProductionModifier");
                _weaponsProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "weaponsProductionModifier");
                _narcoticsProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "narcoticsProductionModifier");

                _isMassInfinite = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "isMassInfinite");
                _bCanResearch = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanResearch");
                _bMobile = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bMobile");
                _bNoLargeHangarInterior = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoLargeHangarInterior");
                _bNoRemoteControlInterior = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoRemoteControlInterior");

                _dockingArms = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArms");
                _dockingArmsEnd = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArmsEnd");
                _dockPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockPosition");
                _dockSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockSize");
                _miningPlatformPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "miningPlatformPosition");

                _largeDock = DataStructureParseHelpers.GetlargeDockDataStructureFromVD2Data(DataXMLDoc);

                _propulsion = DataStructureParseHelpers.GetpropulsionDataStructureListFromVD2Data(DataXMLDoc);
                _physicalRotatingElement = DataStructureParseHelpers.GetphysicalRotatingElementDataStructureListFromVD2Data(DataXMLDoc);
                _alwaysOnEffect = DataStructureParseHelpers.GetalwaysOnEffectDataStructureListFromVD2Data(DataXMLDoc);
            }
        }
    }
}
