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

        float _health;

        bool _bShowInTactical;
        bool _babySpawnDamage;
        bool _isMassInfinite;
        bool _bCanAddViaBattleEditorSlider;

        Vector3D _deathLinearVelocity;

        deathSpawnDataStructure _deathSpawn;

        List<babyDataStructure> _baby;

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

        [Description("wireframeMaterial is a plaintext string"), Category("Plaintext Strings")]
        public string wireframeMaterial
        {
            get => _wireframeMaterial;
            set => _wireframeMaterial = value;
        }

        [Description("tacticalExplosionID is a plaintext string"), Category("Plaintext Strings")]
        public string tacticalExplosionID
        {
            get => _tacticalExplosionID;
            set => _tacticalExplosionID = value;
        }

        [Description("babyExplosionID is a plaintext string"), Category("Plaintext Strings")]
        public string babyExplosionID
        {
            get => _babyExplosionID;
            set => _babyExplosionID = value;
        }

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings")]
        public string explosionID
        {
            get => _explosionID;
            set => _explosionID = value;
        }

        [Description("asteroidSize is a plaintext string"), Category("Plaintext Strings")]
        public string asteroidSize
        {
            get => _asteroidSize;
            set => _asteroidSize = value;
        }

        [Description("displayName is a plaintext string"), Category("Plaintext Strings")]
        public string displayName
        {
            get => _displayName;
            set => _displayName = value;
        }

        [Description("asteroidType is a plaintext string"), Category("Plaintext Strings")]
        public string asteroidType
        {
            get => _asteroidType;
            set => _asteroidType = value;
        }


        [Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> descriptionText
        {
            get => _descriptionText;
            set => _descriptionText = value;
        }

        [Description("collisionShape is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> collisionShape
        {
            get => _collisionShape;
            set => _collisionShape = value;
        }


        [Description("health is a real number"), Category("Real Numbers")]
        public float health
        {
            get => _health;
            set => _health = value;
        }


        [Description("bShowInTactical is a boolean value"), Category("Booleans")]
        public bool bShowInTactical
        {
            get => _bShowInTactical;
            set => _bShowInTactical = value;
        }

        [Description("babySpawnDamage is a boolean value"), Category("Booleans")]
        public bool babySpawnDamage
        {
            get => _babySpawnDamage;
            set => _babySpawnDamage = value;
        }

        [Description("isMassInfinite is a boolean value"), Category("Booleans")]
        public bool isMassInfinite
        {
            get => _isMassInfinite;
            set => _isMassInfinite = value;
        }

        [Description("bCanAddViaBattleEditorSlider is a boolean value"), Category("Booleans")]
        public bool bCanAddViaBattleEditorSlider
        {
            get => _bCanAddViaBattleEditorSlider;
            set => _bCanAddViaBattleEditorSlider = value;
        }


        [Description("deathLinearVelocity is a 3D vector"), Category("3D Vectors")]
        public Vector3D deathLinearVelocity
        {
            get => _deathLinearVelocity;
            set => _deathLinearVelocity = value;
        }


        [Description("deathSpawn is a datastructure"), Category("Data Structures")]
        public deathSpawnDataStructure deathSpawn
        {
            get => _deathSpawn;
            set => _deathSpawn = value;
        }


        [Description("baby is a collection of datastructures"), Category("Data Structure Collections")]
        public List<babyDataStructure> baby
        {
            get => _baby;
            set => _baby = value;
        }


        public AsteroidData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial");
                _tacticalExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tacticalExplosionID");
                _babyExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "babyExplosionID");
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID");
                _asteroidSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "asteroidSize");
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName");
                _asteroidType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "asteroidType");

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText");
                _collisionShape = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "collisionShape");

                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health");

                _bShowInTactical = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInTactical");
                _babySpawnDamage = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "babySpawnDamage");
                _isMassInfinite = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "isMassInfinite");
                _bCanAddViaBattleEditorSlider = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanAddViaBattleEditorSlider");

                _deathLinearVelocity = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "deathLinearVelocity");

                _deathSpawn = DataStructureParseHelpers.GetdeathSpawnDataStructureFromVD2Data(DataXMLDoc);

                _baby = DataStructureParseHelpers.GetbabyDataStructureListFromVD2Data(DataXMLDoc);
            }
        }
    }
}
