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
    class SunData : VD2Data
    {
        string _objectType;
        string _sunType;
        string _name;
        string _objectID;
        string _materialName;
        string _billboardFlareMaterial;
        string _faction;
        string _meshName;
        string _wireframeMaterial;
        string _sunFlareParticleSystem;
        string _collisionShape;
        string _additionalObjectMesh;

        int _flareSize;
        int _scale;
        int _overworldScale;
        int _rotateSpeed;
        int _isMassInfinite;
        int _collisionShapeScale;

        ColorF _specularColor;
        ColorF _diffuseColor;

        List<damageCollisionFieldDataStructure> _damageCollisionField;

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

        [Description("sunType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string sunType
        {
            get
            {
                return _sunType;
            }
            set
            {
                _sunType = value;
                SetPropertyEdited("sunType", true);
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

        [Description("materialName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string materialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                _materialName = value;
                SetPropertyEdited("materialName", true);
            }
        }

        [Description("billboardFlareMaterial is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string billboardFlareMaterial
        {
            get
            {
                return _billboardFlareMaterial;
            }
            set
            {
                _billboardFlareMaterial = value;
                SetPropertyEdited("billboardFlareMaterial", true);
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

        [Description("sunFlareParticleSystem is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string sunFlareParticleSystem
        {
            get
            {
                return _sunFlareParticleSystem;
            }
            set
            {
                _sunFlareParticleSystem = value;
                SetPropertyEdited("sunFlareParticleSystem", true);
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

        [Description("additionalObjectMesh is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string additionalObjectMesh
        {
            get
            {
                return _additionalObjectMesh;
            }
            set
            {
                _additionalObjectMesh = value;
                SetPropertyEdited("additionalObjectMesh", true);
            }
        }


        [Description("flareSize is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int flareSize
        {
            get
            {
                return _flareSize;
            }
            set
            {
                _flareSize = value;
                SetPropertyEdited("flareSize", true);
            }
        }

        [Description("scale is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                SetPropertyEdited("scale", true);
            }
        }

        [Description("overworldScale is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int overworldScale
        {
            get
            {
                return _overworldScale;
            }
            set
            {
                _overworldScale = value;
                SetPropertyEdited("overworldScale", true);
            }
        }

        [Description("rotateSpeed is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rotateSpeed
        {
            get
            {
                return _rotateSpeed;
            }
            set
            {
                _rotateSpeed = value;
                SetPropertyEdited("rotateSpeed", true);
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

        [Description("collisionShapeScale is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int collisionShapeScale
        {
            get
            {
                return _collisionShapeScale;
            }
            set
            {
                _collisionShapeScale = value;
                SetPropertyEdited("collisionShapeScale", true);
            }
        }


        [Description("specularColor is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF specularColor
        {
            get
            {
                return _specularColor;
            }
            set
            {
                _specularColor = value;
                SetPropertyEdited("specularColor", true);
            }
        }

        [Description("diffuseColor is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF diffuseColor
        {
            get
            {
                return _diffuseColor;
            }
            set
            {
                _diffuseColor = value;
                SetPropertyEdited("diffuseColor", true);
            }
        }


        [Description("damageCollisionField is a collection of datastructures"), Category("Data Structure Collections")]
        public List<damageCollisionFieldDataStructure> damageCollisionField
        {
            get
            {
                return _damageCollisionField;
            }
            set
            {
                _damageCollisionField = value;
                SetPropertyEdited("damageCollisionField", true);
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("sunType");
            InitProperty("name");
            InitProperty("objectID");
            InitProperty("materialName");
            InitProperty("billboardFlareMaterial");
            InitProperty("faction");
            InitProperty("meshName");
            InitProperty("wireframeMaterial");
            InitProperty("sunFlareParticleSystem");
            InitProperty("collisionShape");
            InitProperty("additionalObjectMesh");

            InitProperty("flareSize");
            InitProperty("scale");
            InitProperty("overworldScale");
            InitProperty("rotateSpeed");
            InitProperty("isMassInfinite");
            InitProperty("collisionShapeScale");

            InitProperty("specularColor");
            InitProperty("diffuseColor");

            InitProperty("damageCollisionField");
        }

        public SunData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType", out exists);
                SetPropertyExistsInBaseData("objectType", exists);
                SetPropertyExists("objectType", exists);
                _sunType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sunType", out exists);
                SetPropertyExistsInBaseData("sunType", exists);
                SetPropertyExists("sunType", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                SetPropertyExistsInBaseData("name", exists);
                SetPropertyExists("name", exists);
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName", out exists);
                SetPropertyExistsInBaseData("materialName", exists);
                SetPropertyExists("materialName", exists);
                _billboardFlareMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "billboardFlareMaterial", out exists);
                SetPropertyExistsInBaseData("billboardFlareMaterial", exists);
                SetPropertyExists("billboardFlareMaterial", exists);
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction", out exists);
                SetPropertyExistsInBaseData("faction", exists);
                SetPropertyExists("faction", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                SetPropertyExistsInBaseData("meshName", exists);
                SetPropertyExists("meshName", exists);
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial", out exists);
                SetPropertyExistsInBaseData("wireframeMaterial", exists);
                SetPropertyExists("wireframeMaterial", exists);
                _sunFlareParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sunFlareParticleSystem", out exists);
                SetPropertyExistsInBaseData("sunFlareParticleSystem", exists);
                SetPropertyExists("sunFlareParticleSystem", exists);
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape", out exists);
                SetPropertyExistsInBaseData("collisionShape", exists);
                SetPropertyExists("collisionShape", exists);
                _additionalObjectMesh = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "additionalObjectMesh", out exists);
                SetPropertyExistsInBaseData("additionalObjectMesh", exists);
                SetPropertyExists("additionalObjectMesh", exists);

                _flareSize = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "flareSize", out exists);
                SetPropertyExistsInBaseData("flareSize", exists);
                SetPropertyExists("flareSize", exists);
                _scale = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "scale", out exists);
                SetPropertyExistsInBaseData("scale", exists);
                SetPropertyExists("scale", exists);
                _overworldScale = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "overworldScale", out exists);
                SetPropertyExistsInBaseData("overworldScale", exists);
                SetPropertyExists("overworldScale", exists);
                _rotateSpeed = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rotateSpeed", out exists);
                SetPropertyExistsInBaseData("rotateSpeed", exists);
                SetPropertyExists("rotateSpeed", exists);
                _isMassInfinite = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "isMassInfinite", out exists);
                SetPropertyExistsInBaseData("isMassInfinite", exists);
                SetPropertyExists("isMassInfinite", exists);
                _collisionShapeScale = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "collisionShapeScale", out exists);
                SetPropertyExistsInBaseData("collisionShapeScale", exists);
                SetPropertyExists("collisionShapeScale", exists);

                _specularColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "specularColor", out exists);
                SetPropertyExistsInBaseData("specularColor", exists);
                SetPropertyExists("specularColor", exists);
                _diffuseColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "diffuseColor", out exists);
                SetPropertyExistsInBaseData("diffuseColor", exists);
                SetPropertyExists("diffuseColor", exists);

                _damageCollisionField = DataStructureParseHelpers.GetdamageCollisionFieldDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("damageCollisionField", exists);
                SetPropertyExists("damageCollisionField", exists);
            }
        }
    }
}
