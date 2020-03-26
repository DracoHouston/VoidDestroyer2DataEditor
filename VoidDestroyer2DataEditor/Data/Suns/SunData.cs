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
        int _specularColor;
        int _diffuseColor;
        int _scale;
        int _overworldScale;
        int _rotateSpeed;
        int _collisionShapeScale;

        bool _isMassInfinite;

        List<damageCollisionFieldDataStructure> _damageCollisionField;

        [Description("objectType is a plaintext string"), Category("Plaintext Strings")]
        public string objectType
        {
            get => _objectType;
            set => _objectType = value;
        }

        [Description("sunType is a plaintext string"), Category("Plaintext Strings")]
        public string sunType
        {
            get => _sunType;
            set => _sunType = value;
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings")]
        public string name
        {
            get => _name;
            set => _name = value;
        }

        [Description("objectID is a plaintext string"), Category("Plaintext Strings")]
        public string objectID
        {
            get => _objectID;
            set => _objectID = value;
        }

        [Description("materialName is a plaintext string"), Category("Plaintext Strings")]
        public string materialName
        {
            get => _materialName;
            set => _materialName = value;
        }

        [Description("billboardFlareMaterial is a plaintext string"), Category("Plaintext Strings")]
        public string billboardFlareMaterial
        {
            get => _billboardFlareMaterial;
            set => _billboardFlareMaterial = value;
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

        [Description("sunFlareParticleSystem is a plaintext string"), Category("Plaintext Strings")]
        public string sunFlareParticleSystem
        {
            get => _sunFlareParticleSystem;
            set => _sunFlareParticleSystem = value;
        }

        [Description("collisionShape is a plaintext string"), Category("Plaintext Strings")]
        public string collisionShape
        {
            get => _collisionShape;
            set => _collisionShape = value;
        }

        [Description("additionalObjectMesh is a plaintext string"), Category("Plaintext Strings")]
        public string additionalObjectMesh
        {
            get => _additionalObjectMesh;
            set => _additionalObjectMesh = value;
        }


        [Description("flareSize is an integer"), Category("Integers")]
        public int flareSize
        {
            get => _flareSize;
            set => _flareSize = value;
        }

        [Description("specularColor is an integer"), Category("Integers")]
        public int specularColor
        {
            get => _specularColor;
            set => _specularColor = value;
        }

        [Description("diffuseColor is an integer"), Category("Integers")]
        public int diffuseColor
        {
            get => _diffuseColor;
            set => _diffuseColor = value;
        }

        [Description("scale is an integer"), Category("Integers")]
        public int scale
        {
            get => _scale;
            set => _scale = value;
        }

        [Description("overworldScale is an integer"), Category("Integers")]
        public int overworldScale
        {
            get => _overworldScale;
            set => _overworldScale = value;
        }

        [Description("rotateSpeed is an integer"), Category("Integers")]
        public int rotateSpeed
        {
            get => _rotateSpeed;
            set => _rotateSpeed = value;
        }

        [Description("collisionShapeScale is an integer"), Category("Integers")]
        public int collisionShapeScale
        {
            get => _collisionShapeScale;
            set => _collisionShapeScale = value;
        }


        [Description("isMassInfinite is a boolean value"), Category("Booleans")]
        public bool isMassInfinite
        {
            get => _isMassInfinite;
            set => _isMassInfinite = value;
        }


        [Description("damageCollisionField is a collection of datastructures"), Category("Data Structure Collections")]
        public List<damageCollisionFieldDataStructure> damageCollisionField
        {
            get => _damageCollisionField;
            set => _damageCollisionField = value;
        }


        public SunData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _sunType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sunType");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName");
                _billboardFlareMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "billboardFlareMaterial");
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial");
                _sunFlareParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sunFlareParticleSystem");
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape");
                _additionalObjectMesh = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "additionalObjectMesh");

                _flareSize = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "flareSize");
                _specularColor = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "specularColor");
                _diffuseColor = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "diffuseColor");
                _scale = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "scale");
                _overworldScale = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "overworldScale");
                _rotateSpeed = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rotateSpeed");
                _collisionShapeScale = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "collisionShapeScale");

                _isMassInfinite = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "isMassInfinite");

                _damageCollisionField = DataStructureParseHelpers.GetdamageCollisionFieldDataStructureListFromVD2Data(DataXMLDoc);
            }
        }
    }
}
