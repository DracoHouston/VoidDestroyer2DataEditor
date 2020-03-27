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

        [Description("missileType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string missileType
        {
            get
            {
                return _missileType;
            }
            set
            {
                _missileType = value;
                SetPropertyEdited("missileType", true);
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

        [Description("trailParticleName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string trailParticleName
        {
            get
            {
                return _trailParticleName;
            }
            set
            {
                _trailParticleName = value;
                SetPropertyEdited("trailParticleName", true);
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

        [Description("missileParticleName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string missileParticleName
        {
            get
            {
                return _missileParticleName;
            }
            set
            {
                _missileParticleName = value;
                SetPropertyEdited("missileParticleName", true);
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

        [Description("bSelfTarget is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bSelfTarget
        {
            get
            {
                return _bSelfTarget;
            }
            set
            {
                _bSelfTarget = value;
                SetPropertyEdited("bSelfTarget", true);
            }
        }

        [Description("bReAcquireTarget is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bReAcquireTarget
        {
            get
            {
                return _bReAcquireTarget;
            }
            set
            {
                _bReAcquireTarget = value;
                SetPropertyEdited("bReAcquireTarget", true);
            }
        }


        [Description("missileSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D missileSize
        {
            get
            {
                return _missileSize;
            }
            set
            {
                _missileSize = value;
                SetPropertyEdited("missileSize", true);
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
            InitProperty("objectID");
            InitProperty("name");
            InitProperty("missileType");
            InitProperty("meshName");
            InitProperty("ribbonID");
            InitProperty("trailParticleName");
            InitProperty("explosionID");
            InitProperty("missileParticleName");

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

            InitProperty("bAntiCapital");
            InitProperty("bSelfTarget");
            InitProperty("bReAcquireTarget");

            InitProperty("missileSize");

            InitProperty("mirv");

        }

        public MissileData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType", out exists);
                SetPropertyExistsInBaseData("objectType", exists);
                SetPropertyExists("objectType", exists);
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                SetPropertyExistsInBaseData("name", exists);
                SetPropertyExists("name", exists);
                _missileType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "missileType", out exists);
                SetPropertyExistsInBaseData("missileType", exists);
                SetPropertyExists("missileType", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                SetPropertyExistsInBaseData("meshName", exists);
                SetPropertyExists("meshName", exists);
                _ribbonID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ribbonID", out exists);
                SetPropertyExistsInBaseData("ribbonID", exists);
                SetPropertyExists("ribbonID", exists);
                _trailParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "trailParticleName", out exists);
                SetPropertyExistsInBaseData("trailParticleName", exists);
                SetPropertyExists("trailParticleName", exists);
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                SetPropertyExistsInBaseData("explosionID", exists);
                SetPropertyExists("explosionID", exists);
                _missileParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "missileParticleName", out exists);
                SetPropertyExistsInBaseData("missileParticleName", exists);
                SetPropertyExists("missileParticleName", exists);

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

                _bAntiCapital = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAntiCapital", out exists);
                SetPropertyExistsInBaseData("bAntiCapital", exists);
                SetPropertyExists("bAntiCapital", exists);
                _bSelfTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSelfTarget", out exists);
                SetPropertyExistsInBaseData("bSelfTarget", exists);
                SetPropertyExists("bSelfTarget", exists);
                _bReAcquireTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bReAcquireTarget", out exists);
                SetPropertyExistsInBaseData("bReAcquireTarget", exists);
                SetPropertyExists("bReAcquireTarget", exists);

                _missileSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "missileSize", out exists);
                SetPropertyExistsInBaseData("missileSize", exists);
                SetPropertyExists("missileSize", exists);

                _mirv = DataStructureParseHelpers.GetmirvDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("mirv", exists);
                SetPropertyExists("mirv", exists);

            }
        }
    }
}
