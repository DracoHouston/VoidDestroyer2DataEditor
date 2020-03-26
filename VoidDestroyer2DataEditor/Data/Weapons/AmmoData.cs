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
    class AmmoData : VD2Data
    {
        string _objectType;
        string _projectileID;
        string _projectileType;
        string _projectileParticleName;
        string _meshName;
        string _explosionID;
        string _projectileExpireExplosionID;
        string _areaOfEffectID;
        string _instantKillShipClass;
        string _materialNameHead;
        string _materialNameTail;
        string _ribbonID;
        string _dPExpire;

        int _damageOverTime;
        int _damageOverTimeMax;
        int _duration;
        int _maxDuration;
        int _projectileHeadSize;
        int _projectileTailSize;

        float _projectileVelocity;
        float _initialLife;
        float _damage;
        float _weaponPush;
        float _range;

        bool _bShowProjectileExpire;
        bool _bPersistsOnHit;
        bool _bAntiCapital;
        bool _bCrewKiller;
        bool _bIgnoresShields;
        bool _bMining;

        Vector3D _projectileSize;

        canisterDataStructure _canister;

        [Description("objectType is a plaintext string"), Category("Plaintext Strings")]
        public string objectType
        {
            get => _objectType;
            set => _objectType = value;
        }

        [Description("projectileID is a plaintext string"), Category("Plaintext Strings")]
        public string projectileID
        {
            get => _projectileID;
            set => _projectileID = value;
        }

        [Description("projectileType is a plaintext string"), Category("Plaintext Strings")]
        public string projectileType
        {
            get => _projectileType;
            set => _projectileType = value;
        }

        [Description("projectileParticleName is a plaintext string"), Category("Plaintext Strings")]
        public string projectileParticleName
        {
            get => _projectileParticleName;
            set => _projectileParticleName = value;
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

        [Description("projectileExpireExplosionID is a plaintext string"), Category("Plaintext Strings")]
        public string projectileExpireExplosionID
        {
            get => _projectileExpireExplosionID;
            set => _projectileExpireExplosionID = value;
        }

        [Description("areaOfEffectID is a plaintext string"), Category("Plaintext Strings")]
        public string areaOfEffectID
        {
            get => _areaOfEffectID;
            set => _areaOfEffectID = value;
        }

        [Description("instantKillShipClass is a plaintext string"), Category("Plaintext Strings")]
        public string instantKillShipClass
        {
            get => _instantKillShipClass;
            set => _instantKillShipClass = value;
        }

        [Description("materialNameHead is a plaintext string"), Category("Plaintext Strings")]
        public string materialNameHead
        {
            get => _materialNameHead;
            set => _materialNameHead = value;
        }

        [Description("materialNameTail is a plaintext string"), Category("Plaintext Strings")]
        public string materialNameTail
        {
            get => _materialNameTail;
            set => _materialNameTail = value;
        }

        [Description("ribbonID is a plaintext string"), Category("Plaintext Strings")]
        public string ribbonID
        {
            get => _ribbonID;
            set => _ribbonID = value;
        }

        [Description("dPExpire is a plaintext string"), Category("Plaintext Strings")]
        public string dPExpire
        {
            get => _dPExpire;
            set => _dPExpire = value;
        }


        [Description("damageOverTime is an integer"), Category("Integers")]
        public int damageOverTime
        {
            get => _damageOverTime;
            set => _damageOverTime = value;
        }

        [Description("damageOverTimeMax is an integer"), Category("Integers")]
        public int damageOverTimeMax
        {
            get => _damageOverTimeMax;
            set => _damageOverTimeMax = value;
        }

        [Description("duration is an integer"), Category("Integers")]
        public int duration
        {
            get => _duration;
            set => _duration = value;
        }

        [Description("maxDuration is an integer"), Category("Integers")]
        public int maxDuration
        {
            get => _maxDuration;
            set => _maxDuration = value;
        }

        [Description("projectileHeadSize is an integer"), Category("Integers")]
        public int projectileHeadSize
        {
            get => _projectileHeadSize;
            set => _projectileHeadSize = value;
        }

        [Description("projectileTailSize is an integer"), Category("Integers")]
        public int projectileTailSize
        {
            get => _projectileTailSize;
            set => _projectileTailSize = value;
        }


        [Description("projectileVelocity is a real number"), Category("Real Numbers")]
        public float projectileVelocity
        {
            get => _projectileVelocity;
            set => _projectileVelocity = value;
        }

        [Description("initialLife is a real number"), Category("Real Numbers")]
        public float initialLife
        {
            get => _initialLife;
            set => _initialLife = value;
        }

        [Description("damage is a real number"), Category("Real Numbers")]
        public float damage
        {
            get => _damage;
            set => _damage = value;
        }

        [Description("weaponPush is a real number"), Category("Real Numbers")]
        public float weaponPush
        {
            get => _weaponPush;
            set => _weaponPush = value;
        }

        [Description("range is a real number"), Category("Real Numbers")]
        public float range
        {
            get => _range;
            set => _range = value;
        }


        [Description("bShowProjectileExpire is a boolean value"), Category("Booleans")]
        public bool bShowProjectileExpire
        {
            get => _bShowProjectileExpire;
            set => _bShowProjectileExpire = value;
        }

        [Description("bPersistsOnHit is a boolean value"), Category("Booleans")]
        public bool bPersistsOnHit
        {
            get => _bPersistsOnHit;
            set => _bPersistsOnHit = value;
        }

        [Description("bAntiCapital is a boolean value"), Category("Booleans")]
        public bool bAntiCapital
        {
            get => _bAntiCapital;
            set => _bAntiCapital = value;
        }

        [Description("bCrewKiller is a boolean value"), Category("Booleans")]
        public bool bCrewKiller
        {
            get => _bCrewKiller;
            set => _bCrewKiller = value;
        }

        [Description("bIgnoresShields is a boolean value"), Category("Booleans")]
        public bool bIgnoresShields
        {
            get => _bIgnoresShields;
            set => _bIgnoresShields = value;
        }

        [Description("bMining is a boolean value"), Category("Booleans")]
        public bool bMining
        {
            get => _bMining;
            set => _bMining = value;
        }


        [Description("projectileSize is a 3D vector"), Category("3D Vectors")]
        public Vector3D projectileSize
        {
            get => _projectileSize;
            set => _projectileSize = value;
        }


        [Description("canister is a datastructure"), Category("Data Structures")]
        public canisterDataStructure canister
        {
            get => _canister;
            set => _canister = value;
        }



        public AmmoData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _projectileID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileID");
                _projectileType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileType");
                _projectileParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileParticleName");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID");
                _projectileExpireExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileExpireExplosionID");
                _areaOfEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "areaOfEffectID");
                _instantKillShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "instantKillShipClass");
                _materialNameHead = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialNameHead");
                _materialNameTail = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialNameTail");
                _ribbonID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ribbonID");
                _dPExpire = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dPExpire");

                _damageOverTime = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "damageOverTime");
                _damageOverTimeMax = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "damageOverTimeMax");
                _duration = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "duration");
                _maxDuration = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxDuration");
                _projectileHeadSize = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "projectileHeadSize");
                _projectileTailSize = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "projectileTailSize");

                _projectileVelocity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "projectileVelocity");
                _initialLife = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialLife");
                _damage = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "damage");
                _weaponPush = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "weaponPush");
                _range = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "range");

                _bShowProjectileExpire = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowProjectileExpire");
                _bPersistsOnHit = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPersistsOnHit");
                _bAntiCapital = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAntiCapital");
                _bCrewKiller = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCrewKiller");
                _bIgnoresShields = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIgnoresShields");
                _bMining = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bMining");

                _projectileSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "projectileSize");

                _canister = DataStructureParseHelpers.GetcanisterDataStructureFromVD2Data(DataXMLDoc);

            }
        }
    }
}
