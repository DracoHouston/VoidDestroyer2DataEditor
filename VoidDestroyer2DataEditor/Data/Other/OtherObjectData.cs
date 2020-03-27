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
    class OtherObjectData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _faction;
        string _meshName;
        string _wireframeMaterial;
        string _explosionID;
        string _collisionShape;
        string _gateInParticleSystem;
        string _gateOutParticleSystem;

        List<string> _descriptionText;

        int _isMassInfinite;
        int _rockSubPosition;

        float _health;
        float _cruiseSpeed;
        float _timeTillCruise;
        float _yaw;
        float _pitch;
        float _roll;

        bool _bNoShow;
        bool _bShowInTactical;

        cargoBayDataStructure _cargoBay;
        gateCollisionDataStructure _gateCollision;

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

        [Description("gateInParticleSystem is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string gateInParticleSystem
        {
            get
            {
                return _gateInParticleSystem;
            }
            set
            {
                _gateInParticleSystem = value;
                SetPropertyEdited("gateInParticleSystem", true);
            }
        }

        [Description("gateOutParticleSystem is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string gateOutParticleSystem
        {
            get
            {
                return _gateOutParticleSystem;
            }
            set
            {
                _gateOutParticleSystem = value;
                SetPropertyEdited("gateOutParticleSystem", true);
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


        [Description("bNoShow is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoShow
        {
            get
            {
                return _bNoShow;
            }
            set
            {
                _bNoShow = value;
                SetPropertyEdited("bNoShow", true);
            }
        }

        [Description("bShowInTactical is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bShowInTactical
        {
            get
            {
                return _bShowInTactical;
            }
            set
            {
                _bShowInTactical = value;
                SetPropertyEdited("bShowInTactical", true);
            }
        }


        [Description("cargoBay is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public cargoBayDataStructure cargoBay
        {
            get
            {
                return _cargoBay;
            }
            set
            {
                _cargoBay = value;
                SetPropertyEdited("cargoBay", true);
            }
        }

        [Description("gateCollision is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public gateCollisionDataStructure gateCollision
        {
            get
            {
                return _gateCollision;
            }
            set
            {
                _gateCollision = value;
                SetPropertyEdited("gateCollision", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            InitProperty("faction");
            InitProperty("meshName");
            InitProperty("wireframeMaterial");
            InitProperty("explosionID");
            InitProperty("collisionShape");
            InitProperty("gateInParticleSystem");
            InitProperty("gateOutParticleSystem");

            InitProperty("descriptionText");

            InitProperty("isMassInfinite");
            InitProperty("rockSubPosition");

            InitProperty("health");
            InitProperty("cruiseSpeed");
            InitProperty("timeTillCruise");
            InitProperty("yaw");
            InitProperty("pitch");
            InitProperty("roll");

            InitProperty("bNoShow");
            InitProperty("bShowInTactical");

            InitProperty("cargoBay");
            InitProperty("gateCollision");

        }

        public OtherObjectData(string inPath) : base(inPath)
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
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                SetPropertyExistsInBaseData("explosionID", exists);
                SetPropertyExists("explosionID", exists);
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape", out exists);
                SetPropertyExistsInBaseData("collisionShape", exists);
                SetPropertyExists("collisionShape", exists);
                _gateInParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gateInParticleSystem", out exists);
                SetPropertyExistsInBaseData("gateInParticleSystem", exists);
                SetPropertyExists("gateInParticleSystem", exists);
                _gateOutParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gateOutParticleSystem", out exists);
                SetPropertyExistsInBaseData("gateOutParticleSystem", exists);
                SetPropertyExists("gateOutParticleSystem", exists);

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText", out exists);
                SetPropertyExistsInBaseData("descriptionText", exists);
                SetPropertyExists("descriptionText", exists);

                _isMassInfinite = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "isMassInfinite", out exists);
                SetPropertyExistsInBaseData("isMassInfinite", exists);
                SetPropertyExists("isMassInfinite", exists);
                _rockSubPosition = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rockSubPosition", out exists);
                SetPropertyExistsInBaseData("rockSubPosition", exists);
                SetPropertyExists("rockSubPosition", exists);

                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health", out exists);
                SetPropertyExistsInBaseData("health", exists);
                SetPropertyExists("health", exists);
                _cruiseSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "cruiseSpeed", out exists);
                SetPropertyExistsInBaseData("cruiseSpeed", exists);
                SetPropertyExists("cruiseSpeed", exists);
                _timeTillCruise = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillCruise", out exists);
                SetPropertyExistsInBaseData("timeTillCruise", exists);
                SetPropertyExists("timeTillCruise", exists);
                _yaw = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "yaw", out exists);
                SetPropertyExistsInBaseData("yaw", exists);
                SetPropertyExists("yaw", exists);
                _pitch = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pitch", out exists);
                SetPropertyExistsInBaseData("pitch", exists);
                SetPropertyExists("pitch", exists);
                _roll = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "roll", out exists);
                SetPropertyExistsInBaseData("roll", exists);
                SetPropertyExists("roll", exists);

                _bNoShow = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoShow", out exists);
                SetPropertyExistsInBaseData("bNoShow", exists);
                SetPropertyExists("bNoShow", exists);
                _bShowInTactical = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInTactical", out exists);
                SetPropertyExistsInBaseData("bShowInTactical", exists);
                SetPropertyExists("bShowInTactical", exists);

                _cargoBay = DataStructureParseHelpers.GetcargoBayDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("cargoBay", exists);
                SetPropertyExists("cargoBay", exists);
                _gateCollision = DataStructureParseHelpers.GetgateCollisionDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("gateCollision", exists);
                SetPropertyExists("gateCollision", exists);

            }
        }
    }
}
