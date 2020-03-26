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

        int _rockSubPosition;

        float _health;
        float _cruiseSpeed;
        float _timeTillCruise;
        float _yaw;
        float _pitch;
        float _roll;

        bool _bNoShow;
        bool _bShowInTactical;
        bool _isMassInfinite;

        cargoBayDataStructure _cargoBay;
        gateCollisionDataStructure _gateCollision;

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

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings")]
        public string explosionID
        {
            get => _explosionID;
            set => _explosionID = value;
        }

        [Description("collisionShape is a plaintext string"), Category("Plaintext Strings")]
        public string collisionShape
        {
            get => _collisionShape;
            set => _collisionShape = value;
        }

        [Description("gateInParticleSystem is a plaintext string"), Category("Plaintext Strings")]
        public string gateInParticleSystem
        {
            get => _gateInParticleSystem;
            set => _gateInParticleSystem = value;
        }

        [Description("gateOutParticleSystem is a plaintext string"), Category("Plaintext Strings")]
        public string gateOutParticleSystem
        {
            get => _gateOutParticleSystem;
            set => _gateOutParticleSystem = value;
        }


        [Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> descriptionText
        {
            get => _descriptionText;
            set => _descriptionText = value;
        }


        [Description("rockSubPosition is an integer"), Category("Integers")]
        public int rockSubPosition
        {
            get => _rockSubPosition;
            set => _rockSubPosition = value;
        }


        [Description("health is a real number"), Category("Real Numbers")]
        public float health
        {
            get => _health;
            set => _health = value;
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


        [Description("bNoShow is a boolean value"), Category("Booleans")]
        public bool bNoShow
        {
            get => _bNoShow;
            set => _bNoShow = value;
        }

        [Description("bShowInTactical is a boolean value"), Category("Booleans")]
        public bool bShowInTactical
        {
            get => _bShowInTactical;
            set => _bShowInTactical = value;
        }

        [Description("isMassInfinite is a boolean value"), Category("Booleans")]
        public bool isMassInfinite
        {
            get => _isMassInfinite;
            set => _isMassInfinite = value;
        }


        [Description("cargoBay is a datastructure"), Category("Data Structures")]
        public cargoBayDataStructure cargoBay
        {
            get => _cargoBay;
            set => _cargoBay = value;
        }

        [Description("gateCollision is a datastructure"), Category("Data Structures")]
        public gateCollisionDataStructure gateCollision
        {
            get => _gateCollision;
            set => _gateCollision = value;
        }



        public OtherObjectData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial");
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID");
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape");
                _gateInParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gateInParticleSystem");
                _gateOutParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gateOutParticleSystem");

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText");

                _rockSubPosition = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rockSubPosition");

                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health");
                _cruiseSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "cruiseSpeed");
                _timeTillCruise = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillCruise");
                _yaw = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "yaw");
                _pitch = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pitch");
                _roll = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "roll");

                _bNoShow = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoShow");
                _bShowInTactical = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInTactical");
                _isMassInfinite = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "isMassInfinite");

                _cargoBay = DataStructureParseHelpers.GetcargoBayDataStructureFromVD2Data(DataXMLDoc);
                _gateCollision = DataStructureParseHelpers.GetgateCollisionDataStructureFromVD2Data(DataXMLDoc);

            }
        }
    }
}
