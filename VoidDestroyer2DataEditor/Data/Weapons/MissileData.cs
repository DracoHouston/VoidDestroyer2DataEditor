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
    class MissileData : VD2Data
    {
        string _objectType;
        string _objectID;
        string _name;
        string _missileType;
        string _meshName;
        string _ribbonID;
        string _trailParticleName;
        string _explosionID;
        string _missileParticleName;

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

        bool _bAntiCapital;
        bool _bSelfTarget;
        bool _bReAcquireTarget;

        Vector3D _missileSize;

        mirvDataStructure _mirv;

        [Description("objectType is a plaintext string"), Category("Plaintext Strings")]
        public string objectType
        {
            get => _objectType;
            set => _objectType = value;
        }

        [Description("objectID is a plaintext string"), Category("Plaintext Strings")]
        public string objectID
        {
            get => _objectID;
            set => _objectID = value;
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings")]
        public string name
        {
            get => _name;
            set => _name = value;
        }

        [Description("missileType is a plaintext string"), Category("Plaintext Strings")]
        public string missileType
        {
            get => _missileType;
            set => _missileType = value;
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings")]
        public string meshName
        {
            get => _meshName;
            set => _meshName = value;
        }

        [Description("ribbonID is a plaintext string"), Category("Plaintext Strings")]
        public string ribbonID
        {
            get => _ribbonID;
            set => _ribbonID = value;
        }

        [Description("trailParticleName is a plaintext string"), Category("Plaintext Strings")]
        public string trailParticleName
        {
            get => _trailParticleName;
            set => _trailParticleName = value;
        }

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings")]
        public string explosionID
        {
            get => _explosionID;
            set => _explosionID = value;
        }

        [Description("missileParticleName is a plaintext string"), Category("Plaintext Strings")]
        public string missileParticleName
        {
            get => _missileParticleName;
            set => _missileParticleName = value;
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


        [Description("bAntiCapital is a boolean value"), Category("Booleans")]
        public bool bAntiCapital
        {
            get => _bAntiCapital;
            set => _bAntiCapital = value;
        }

        [Description("bSelfTarget is a boolean value"), Category("Booleans")]
        public bool bSelfTarget
        {
            get => _bSelfTarget;
            set => _bSelfTarget = value;
        }

        [Description("bReAcquireTarget is a boolean value"), Category("Booleans")]
        public bool bReAcquireTarget
        {
            get => _bReAcquireTarget;
            set => _bReAcquireTarget = value;
        }


        [Description("missileSize is a 3D vector"), Category("3D Vectors")]
        public Vector3D missileSize
        {
            get => _missileSize;
            set => _missileSize = value;
        }


        [Description("mirv is a datastructure"), Category("Data Structures")]
        public mirvDataStructure mirv
        {
            get => _mirv;
            set => _mirv = value;
        }



        public MissileData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _missileType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "missileType");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _ribbonID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ribbonID");
                _trailParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "trailParticleName");
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID");
                _missileParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "missileParticleName");

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

                _bAntiCapital = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAntiCapital");
                _bSelfTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSelfTarget");
                _bReAcquireTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bReAcquireTarget");

                _missileSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "missileSize");

                _mirv = DataStructureParseHelpers.GetmirvDataStructureFromVD2Data(DataXMLDoc);

            }
        }
    }
}
