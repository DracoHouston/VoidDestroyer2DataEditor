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

        [Description("objectType is a plaintext string"), Category("Plaintext Strings")]
        public string objectType
        {
            get => _objectType;
            set => _objectType = value;
        }

        [Description("mineType is a plaintext string"), Category("Plaintext Strings")]
        public string mineType
        {
            get => _mineType;
            set => _mineType = value;
        }

        [Description("objectID is a plaintext string"), Category("Plaintext Strings")]
        public string objectID
        {
            get => _objectID;
            set => _objectID = value;
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings")]
        public string meshName
        {
            get => _meshName;
            set => _meshName = value;
        }

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings")]
        public string explosionID
        {
            get => _explosionID;
            set => _explosionID = value;
        }

        [Description("minimumShipClass is a plaintext string"), Category("Plaintext Strings")]
        public string minimumShipClass
        {
            get => _minimumShipClass;
            set => _minimumShipClass = value;
        }


        [Description("detectionProximity is an integer"), Category("Integers")]
        public int detectionProximity
        {
            get => _detectionProximity;
            set => _detectionProximity = value;
        }

        [Description("weaponPush is an integer"), Category("Integers")]
        public int weaponPush
        {
            get => _weaponPush;
            set => _weaponPush = value;
        }

        [Description("renderingDistance is an integer"), Category("Integers")]
        public int renderingDistance
        {
            get => _renderingDistance;
            set => _renderingDistance = value;
        }


        [Description("cruiseSpeed is a real number"), Category("Real Numbers")]
        public float cruiseSpeed
        {
            get => _cruiseSpeed;
            set => _cruiseSpeed = value;
        }

        [Description("timeTillCruise is a real number"), Category("Real Numbers")]
        public float timeTillCruise
        {
            get => _timeTillCruise;
            set => _timeTillCruise = value;
        }

        [Description("initialVelocity is a real number"), Category("Real Numbers")]
        public float initialVelocity
        {
            get => _initialVelocity;
            set => _initialVelocity = value;
        }

        [Description("initialLife is a real number"), Category("Real Numbers")]
        public float initialLife
        {
            get => _initialLife;
            set => _initialLife = value;
        }

        [Description("timeTillActive is a real number"), Category("Real Numbers")]
        public float timeTillActive
        {
            get => _timeTillActive;
            set => _timeTillActive = value;
        }

        [Description("damage is a real number"), Category("Real Numbers")]
        public float damage
        {
            get => _damage;
            set => _damage = value;
        }

        [Description("health is a real number"), Category("Real Numbers")]
        public float health
        {
            get => _health;
            set => _health = value;
        }

        [Description("yaw is a real number"), Category("Real Numbers")]
        public float yaw
        {
            get => _yaw;
            set => _yaw = value;
        }

        [Description("pitch is a real number"), Category("Real Numbers")]
        public float pitch
        {
            get => _pitch;
            set => _pitch = value;
        }

        [Description("roll is a real number"), Category("Real Numbers")]
        public float roll
        {
            get => _roll;
            set => _roll = value;
        }


        [Description("bUseParentTarget is a boolean value"), Category("Booleans")]
        public bool bUseParentTarget
        {
            get => _bUseParentTarget;
            set => _bUseParentTarget = value;
        }

        [Description("bSpinner is a boolean value"), Category("Booleans")]
        public bool bSpinner
        {
            get => _bSpinner;
            set => _bSpinner = value;
        }

        [Description("bKeepTarget is a boolean value"), Category("Booleans")]
        public bool bKeepTarget
        {
            get => _bKeepTarget;
            set => _bKeepTarget = value;
        }

        [Description("bCheckFriendOrFoe is a boolean value"), Category("Booleans")]
        public bool bCheckFriendOrFoe
        {
            get => _bCheckFriendOrFoe;
            set => _bCheckFriendOrFoe = value;
        }

        [Description("bCanAddViaBattleEditorSlider is a boolean value"), Category("Booleans")]
        public bool bCanAddViaBattleEditorSlider
        {
            get => _bCanAddViaBattleEditorSlider;
            set => _bCanAddViaBattleEditorSlider = value;
        }

        [Description("bIgnoresShields is a boolean value"), Category("Booleans")]
        public bool bIgnoresShields
        {
            get => _bIgnoresShields;
            set => _bIgnoresShields = value;
        }

        [Description("bHeatMine is a boolean value"), Category("Booleans")]
        public bool bHeatMine
        {
            get => _bHeatMine;
            set => _bHeatMine = value;
        }


        [Description("mirv is a datastructure"), Category("Data Structures")]
        public mirvDataStructure mirv
        {
            get => _mirv;
            set => _mirv = value;
        }



        public MineData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _mineType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "mineType");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID");
                _minimumShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "minimumShipClass");

                _detectionProximity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "detectionProximity");
                _weaponPush = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "weaponPush");
                _renderingDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "renderingDistance");

                _cruiseSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "cruiseSpeed");
                _timeTillCruise = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillCruise");
                _initialVelocity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialVelocity");
                _initialLife = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialLife");
                _timeTillActive = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillActive");
                _damage = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "damage");
                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health");
                _yaw = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "yaw");
                _pitch = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pitch");
                _roll = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "roll");

                _bUseParentTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bUseParentTarget");
                _bSpinner = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSpinner");
                _bKeepTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bKeepTarget");
                _bCheckFriendOrFoe = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCheckFriendOrFoe");
                _bCanAddViaBattleEditorSlider = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanAddViaBattleEditorSlider");
                _bIgnoresShields = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIgnoresShields");
                _bHeatMine = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bHeatMine");

                _mirv = DataStructureParseHelpers.GetmirvDataStructureFromVD2Data(DataXMLDoc);

            }
        }
    }
}
