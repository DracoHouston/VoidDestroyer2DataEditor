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

        [Description("projectileID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string projectileID
        {
            get
            {
                return _projectileID;
            }
            set
            {
                _projectileID = value;
                SetPropertyEdited("projectileID", true);
            }
        }

        [Description("projectileType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string projectileType
        {
            get
            {
                return _projectileType;
            }
            set
            {
                _projectileType = value;
                SetPropertyEdited("projectileType", true);
            }
        }

        [Description("projectileParticleName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string projectileParticleName
        {
            get
            {
                return _projectileParticleName;
            }
            set
            {
                _projectileParticleName = value;
                SetPropertyEdited("projectileParticleName", true);
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

        [Description("projectileExpireExplosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string projectileExpireExplosionID
        {
            get
            {
                return _projectileExpireExplosionID;
            }
            set
            {
                _projectileExpireExplosionID = value;
                SetPropertyEdited("projectileExpireExplosionID", true);
            }
        }

        [Description("areaOfEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string areaOfEffectID
        {
            get
            {
                return _areaOfEffectID;
            }
            set
            {
                _areaOfEffectID = value;
                SetPropertyEdited("areaOfEffectID", true);
            }
        }

        [Description("instantKillShipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string instantKillShipClass
        {
            get
            {
                return _instantKillShipClass;
            }
            set
            {
                _instantKillShipClass = value;
                SetPropertyEdited("instantKillShipClass", true);
            }
        }

        [Description("materialNameHead is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string materialNameHead
        {
            get
            {
                return _materialNameHead;
            }
            set
            {
                _materialNameHead = value;
                SetPropertyEdited("materialNameHead", true);
            }
        }

        [Description("materialNameTail is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string materialNameTail
        {
            get
            {
                return _materialNameTail;
            }
            set
            {
                _materialNameTail = value;
                SetPropertyEdited("materialNameTail", true);
            }
        }

        [Description("ribbonID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ribbonID
        {
            get
            {
                return _ribbonID;
            }
            set
            {
                _ribbonID = value;
                SetPropertyEdited("ribbonID", true);
            }
        }

        [Description("dPExpire is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string dPExpire
        {
            get
            {
                return _dPExpire;
            }
            set
            {
                _dPExpire = value;
                SetPropertyEdited("dPExpire", true);
            }
        }


        [Description("damageOverTime is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int damageOverTime
        {
            get
            {
                return _damageOverTime;
            }
            set
            {
                _damageOverTime = value;
                SetPropertyEdited("damageOverTime", true);
            }
        }

        [Description("damageOverTimeMax is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int damageOverTimeMax
        {
            get
            {
                return _damageOverTimeMax;
            }
            set
            {
                _damageOverTimeMax = value;
                SetPropertyEdited("damageOverTimeMax", true);
            }
        }

        [Description("duration is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                SetPropertyEdited("duration", true);
            }
        }

        [Description("maxDuration is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int maxDuration
        {
            get
            {
                return _maxDuration;
            }
            set
            {
                _maxDuration = value;
                SetPropertyEdited("maxDuration", true);
            }
        }

        [Description("projectileHeadSize is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int projectileHeadSize
        {
            get
            {
                return _projectileHeadSize;
            }
            set
            {
                _projectileHeadSize = value;
                SetPropertyEdited("projectileHeadSize", true);
            }
        }

        [Description("projectileTailSize is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int projectileTailSize
        {
            get
            {
                return _projectileTailSize;
            }
            set
            {
                _projectileTailSize = value;
                SetPropertyEdited("projectileTailSize", true);
            }
        }


        [Description("projectileVelocity is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float projectileVelocity
        {
            get
            {
                return _projectileVelocity;
            }
            set
            {
                _projectileVelocity = value;
                SetPropertyEdited("projectileVelocity", true);
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

        [Description("weaponPush is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float weaponPush
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

        [Description("range is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float range
        {
            get
            {
                return _range;
            }
            set
            {
                _range = value;
                SetPropertyEdited("range", true);
            }
        }


        [Description("bShowProjectileExpire is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bShowProjectileExpire
        {
            get
            {
                return _bShowProjectileExpire;
            }
            set
            {
                _bShowProjectileExpire = value;
                SetPropertyEdited("bShowProjectileExpire", true);
            }
        }

        [Description("bPersistsOnHit is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPersistsOnHit
        {
            get
            {
                return _bPersistsOnHit;
            }
            set
            {
                _bPersistsOnHit = value;
                SetPropertyEdited("bPersistsOnHit", true);
            }
        }

        [Description("bAntiCapital is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAntiCapital
        {
            get
            {
                return _bAntiCapital;
            }
            set
            {
                _bAntiCapital = value;
                SetPropertyEdited("bAntiCapital", true);
            }
        }

        [Description("bCrewKiller is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCrewKiller
        {
            get
            {
                return _bCrewKiller;
            }
            set
            {
                _bCrewKiller = value;
                SetPropertyEdited("bCrewKiller", true);
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

        [Description("bMining is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bMining
        {
            get
            {
                return _bMining;
            }
            set
            {
                _bMining = value;
                SetPropertyEdited("bMining", true);
            }
        }


        [Description("projectileSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D projectileSize
        {
            get
            {
                return _projectileSize;
            }
            set
            {
                _projectileSize = value;
                SetPropertyEdited("projectileSize", true);
            }
        }


        [Description("canister is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public canisterDataStructure canister
        {
            get
            {
                return _canister;
            }
            set
            {
                _canister = value;
                SetPropertyEdited("canister", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("projectileID");
            InitProperty("projectileType");
            InitProperty("projectileParticleName");
            InitProperty("meshName");
            InitProperty("explosionID");
            InitProperty("projectileExpireExplosionID");
            InitProperty("areaOfEffectID");
            InitProperty("instantKillShipClass");
            InitProperty("materialNameHead");
            InitProperty("materialNameTail");
            InitProperty("ribbonID");
            InitProperty("dPExpire");

            InitProperty("damageOverTime");
            InitProperty("damageOverTimeMax");
            InitProperty("duration");
            InitProperty("maxDuration");
            InitProperty("projectileHeadSize");
            InitProperty("projectileTailSize");

            InitProperty("projectileVelocity");
            InitProperty("initialLife");
            InitProperty("damage");
            InitProperty("weaponPush");
            InitProperty("range");

            InitProperty("bShowProjectileExpire");
            InitProperty("bPersistsOnHit");
            InitProperty("bAntiCapital");
            InitProperty("bCrewKiller");
            InitProperty("bIgnoresShields");
            InitProperty("bMining");

            InitProperty("projectileSize");

            InitProperty("canister");

        }

        public AmmoData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType", out exists);
                SetPropertyExistsInBaseData("objectType", exists);
                SetPropertyExists("objectType", exists);
                _projectileID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileID", out exists);
                SetPropertyExistsInBaseData("projectileID", exists);
                SetPropertyExists("projectileID", exists);
                _projectileType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileType", out exists);
                SetPropertyExistsInBaseData("projectileType", exists);
                SetPropertyExists("projectileType", exists);
                _projectileParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileParticleName", out exists);
                SetPropertyExistsInBaseData("projectileParticleName", exists);
                SetPropertyExists("projectileParticleName", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                SetPropertyExistsInBaseData("meshName", exists);
                SetPropertyExists("meshName", exists);
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                SetPropertyExistsInBaseData("explosionID", exists);
                SetPropertyExists("explosionID", exists);
                _projectileExpireExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileExpireExplosionID", out exists);
                SetPropertyExistsInBaseData("projectileExpireExplosionID", exists);
                SetPropertyExists("projectileExpireExplosionID", exists);
                _areaOfEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "areaOfEffectID", out exists);
                SetPropertyExistsInBaseData("areaOfEffectID", exists);
                SetPropertyExists("areaOfEffectID", exists);
                _instantKillShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "instantKillShipClass", out exists);
                SetPropertyExistsInBaseData("instantKillShipClass", exists);
                SetPropertyExists("instantKillShipClass", exists);
                _materialNameHead = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialNameHead", out exists);
                SetPropertyExistsInBaseData("materialNameHead", exists);
                SetPropertyExists("materialNameHead", exists);
                _materialNameTail = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialNameTail", out exists);
                SetPropertyExistsInBaseData("materialNameTail", exists);
                SetPropertyExists("materialNameTail", exists);
                _ribbonID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ribbonID", out exists);
                SetPropertyExistsInBaseData("ribbonID", exists);
                SetPropertyExists("ribbonID", exists);
                _dPExpire = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dPExpire", out exists);
                SetPropertyExistsInBaseData("dPExpire", exists);
                SetPropertyExists("dPExpire", exists);

                _damageOverTime = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "damageOverTime", out exists);
                SetPropertyExistsInBaseData("damageOverTime", exists);
                SetPropertyExists("damageOverTime", exists);
                _damageOverTimeMax = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "damageOverTimeMax", out exists);
                SetPropertyExistsInBaseData("damageOverTimeMax", exists);
                SetPropertyExists("damageOverTimeMax", exists);
                _duration = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "duration", out exists);
                SetPropertyExistsInBaseData("duration", exists);
                SetPropertyExists("duration", exists);
                _maxDuration = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxDuration", out exists);
                SetPropertyExistsInBaseData("maxDuration", exists);
                SetPropertyExists("maxDuration", exists);
                _projectileHeadSize = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "projectileHeadSize", out exists);
                SetPropertyExistsInBaseData("projectileHeadSize", exists);
                SetPropertyExists("projectileHeadSize", exists);
                _projectileTailSize = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "projectileTailSize", out exists);
                SetPropertyExistsInBaseData("projectileTailSize", exists);
                SetPropertyExists("projectileTailSize", exists);

                _projectileVelocity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "projectileVelocity", out exists);
                SetPropertyExistsInBaseData("projectileVelocity", exists);
                SetPropertyExists("projectileVelocity", exists);
                _initialLife = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialLife", out exists);
                SetPropertyExistsInBaseData("initialLife", exists);
                SetPropertyExists("initialLife", exists);
                _damage = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "damage", out exists);
                SetPropertyExistsInBaseData("damage", exists);
                SetPropertyExists("damage", exists);
                _weaponPush = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "weaponPush", out exists);
                SetPropertyExistsInBaseData("weaponPush", exists);
                SetPropertyExists("weaponPush", exists);
                _range = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "range", out exists);
                SetPropertyExistsInBaseData("range", exists);
                SetPropertyExists("range", exists);

                _bShowProjectileExpire = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowProjectileExpire", out exists);
                SetPropertyExistsInBaseData("bShowProjectileExpire", exists);
                SetPropertyExists("bShowProjectileExpire", exists);
                _bPersistsOnHit = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPersistsOnHit", out exists);
                SetPropertyExistsInBaseData("bPersistsOnHit", exists);
                SetPropertyExists("bPersistsOnHit", exists);
                _bAntiCapital = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAntiCapital", out exists);
                SetPropertyExistsInBaseData("bAntiCapital", exists);
                SetPropertyExists("bAntiCapital", exists);
                _bCrewKiller = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCrewKiller", out exists);
                SetPropertyExistsInBaseData("bCrewKiller", exists);
                SetPropertyExists("bCrewKiller", exists);
                _bIgnoresShields = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIgnoresShields", out exists);
                SetPropertyExistsInBaseData("bIgnoresShields", exists);
                SetPropertyExists("bIgnoresShields", exists);
                _bMining = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bMining", out exists);
                SetPropertyExistsInBaseData("bMining", exists);
                SetPropertyExists("bMining", exists);

                _projectileSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "projectileSize", out exists);
                SetPropertyExistsInBaseData("projectileSize", exists);
                SetPropertyExists("projectileSize", exists);

                _canister = DataStructureParseHelpers.GetcanisterDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("canister", exists);
                SetPropertyExists("canister", exists);

            }
        }
    }
}
