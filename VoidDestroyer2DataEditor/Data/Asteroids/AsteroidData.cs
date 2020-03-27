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
    class AsteroidData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _meshName;
        string _wireframeMaterial;
        string _tacticalExplosionID;
        string _babyExplosionID;
        string _explosionID;
        string _asteroidSize;
        string _displayName;
        string _asteroidType;

        List<string> _descriptionText;
        List<string> _collisionShape;

        int _babySpawnDamage;
        int _isMassInfinite;

        float _health;

        bool _bShowInTactical;
        bool _bCanAddViaBattleEditorSlider;

        Vector3D _deathLinearVelocity;

        deathSpawnDataStructure _deathSpawn;

        List<babyDataStructure> _baby;

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

        [Description("tacticalExplosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string tacticalExplosionID
        {
            get
            {
                return _tacticalExplosionID;
            }
            set
            {
                _tacticalExplosionID = value;
                SetPropertyEdited("tacticalExplosionID", true);
            }
        }

        [Description("babyExplosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string babyExplosionID
        {
            get
            {
                return _babyExplosionID;
            }
            set
            {
                _babyExplosionID = value;
                SetPropertyEdited("babyExplosionID", true);
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

        [Description("asteroidSize is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string asteroidSize
        {
            get
            {
                return _asteroidSize;
            }
            set
            {
                _asteroidSize = value;
                SetPropertyEdited("asteroidSize", true);
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

        [Description("asteroidType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string asteroidType
        {
            get
            {
                return _asteroidType;
            }
            set
            {
                _asteroidType = value;
                SetPropertyEdited("asteroidType", true);
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

        [Description("collisionShape is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> collisionShape
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


        [Description("babySpawnDamage is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int babySpawnDamage
        {
            get
            {
                return _babySpawnDamage;
            }
            set
            {
                _babySpawnDamage = value;
                SetPropertyEdited("babySpawnDamage", true);
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


        [Description("deathLinearVelocity is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D deathLinearVelocity
        {
            get
            {
                return _deathLinearVelocity;
            }
            set
            {
                _deathLinearVelocity = value;
                SetPropertyEdited("deathLinearVelocity", true);
            }
        }


        [Description("deathSpawn is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public deathSpawnDataStructure deathSpawn
        {
            get
            {
                return _deathSpawn;
            }
            set
            {
                _deathSpawn = value;
                SetPropertyEdited("deathSpawn", true);
            }
        }


        [Description("baby is a collection of datastructures"), Category("Data Structure Collections")]
        public List<babyDataStructure> baby
        {
            get
            {
                return _baby;
            }
            set
            {
                _baby = value;
                SetPropertyEdited("baby", true);
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            InitProperty("meshName");
            InitProperty("wireframeMaterial");
            InitProperty("tacticalExplosionID");
            InitProperty("babyExplosionID");
            InitProperty("explosionID");
            InitProperty("asteroidSize");
            InitProperty("displayName");
            InitProperty("asteroidType");

            InitProperty("descriptionText");
            InitProperty("collisionShape");

            InitProperty("babySpawnDamage");
            InitProperty("isMassInfinite");

            InitProperty("health");

            InitProperty("bShowInTactical");
            InitProperty("bCanAddViaBattleEditorSlider");

            InitProperty("deathLinearVelocity");

            InitProperty("deathSpawn");

            InitProperty("baby");
        }

        public AsteroidData(string inPath) : base(inPath)
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
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                SetPropertyExistsInBaseData("meshName", exists);
                SetPropertyExists("meshName", exists);
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial", out exists);
                SetPropertyExistsInBaseData("wireframeMaterial", exists);
                SetPropertyExists("wireframeMaterial", exists);
                _tacticalExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tacticalExplosionID", out exists);
                SetPropertyExistsInBaseData("tacticalExplosionID", exists);
                SetPropertyExists("tacticalExplosionID", exists);
                _babyExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "babyExplosionID", out exists);
                SetPropertyExistsInBaseData("babyExplosionID", exists);
                SetPropertyExists("babyExplosionID", exists);
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                SetPropertyExistsInBaseData("explosionID", exists);
                SetPropertyExists("explosionID", exists);
                _asteroidSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "asteroidSize", out exists);
                SetPropertyExistsInBaseData("asteroidSize", exists);
                SetPropertyExists("asteroidSize", exists);
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName", out exists);
                SetPropertyExistsInBaseData("displayName", exists);
                SetPropertyExists("displayName", exists);
                _asteroidType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "asteroidType", out exists);
                SetPropertyExistsInBaseData("asteroidType", exists);
                SetPropertyExists("asteroidType", exists);

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText", out exists);
                SetPropertyExistsInBaseData("descriptionText", exists);
                SetPropertyExists("descriptionText", exists);
                _collisionShape = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "collisionShape", out exists);
                SetPropertyExistsInBaseData("collisionShape", exists);
                SetPropertyExists("collisionShape", exists);

                _babySpawnDamage = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "babySpawnDamage", out exists);
                SetPropertyExistsInBaseData("babySpawnDamage", exists);
                SetPropertyExists("babySpawnDamage", exists);
                _isMassInfinite = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "isMassInfinite", out exists);
                SetPropertyExistsInBaseData("isMassInfinite", exists);
                SetPropertyExists("isMassInfinite", exists);

                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health", out exists);
                SetPropertyExistsInBaseData("health", exists);
                SetPropertyExists("health", exists);

                _bShowInTactical = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInTactical", out exists);
                SetPropertyExistsInBaseData("bShowInTactical", exists);
                SetPropertyExists("bShowInTactical", exists);
                _bCanAddViaBattleEditorSlider = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanAddViaBattleEditorSlider", out exists);
                SetPropertyExistsInBaseData("bCanAddViaBattleEditorSlider", exists);
                SetPropertyExists("bCanAddViaBattleEditorSlider", exists);

                _deathLinearVelocity = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "deathLinearVelocity", out exists);
                SetPropertyExistsInBaseData("deathLinearVelocity", exists);
                SetPropertyExists("deathLinearVelocity", exists);

                _deathSpawn = DataStructureParseHelpers.GetdeathSpawnDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("deathSpawn", exists);
                SetPropertyExists("deathSpawn", exists);

                _baby = DataStructureParseHelpers.GetbabyDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("baby", exists);
                SetPropertyExists("baby", exists);
            }
        }
    }
}
