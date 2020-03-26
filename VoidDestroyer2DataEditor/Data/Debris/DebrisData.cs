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
    class DebrisData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _meshName;
        string _faction;
        string _descriptionText;
        string _collisionShape;
        string _explosionID;
        string _debrisSizeAsShipClass;

        float _health;
        float _timeToLive;
        float _minimumMomentum;
        float _minimumRotation;

        bool _isMassInfinite;
        bool _bCanAddViaBattleEditorSlider;

        List<turretDataStructure> _turret;

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

        [Description("faction is a plaintext string"), Category("Plaintext Strings")]
        public string faction
        {
            get => _faction;
            set => _faction = value;
        }

        [Description("descriptionText is a plaintext string"), Category("Plaintext Strings")]
        public string descriptionText
        {
            get => _descriptionText;
            set => _descriptionText = value;
        }

        [Description("collisionShape is a plaintext string"), Category("Plaintext Strings")]
        public string collisionShape
        {
            get => _collisionShape;
            set => _collisionShape = value;
        }

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings")]
        public string explosionID
        {
            get => _explosionID;
            set => _explosionID = value;
        }

        [Description("debrisSizeAsShipClass is a plaintext string"), Category("Plaintext Strings")]
        public string debrisSizeAsShipClass
        {
            get => _debrisSizeAsShipClass;
            set => _debrisSizeAsShipClass = value;
        }


        [Description("health is a real number"), Category("Real Numbers")]
        public float health
        {
            get => _health;
            set => _health = value;
        }

        [Description("timeToLive is a real number"), Category("Real Numbers")]
        public float timeToLive
        {
            get => _timeToLive;
            set => _timeToLive = value;
        }

        [Description("minimumMomentum is a real number"), Category("Real Numbers")]
        public float minimumMomentum
        {
            get => _minimumMomentum;
            set => _minimumMomentum = value;
        }

        [Description("minimumRotation is a real number"), Category("Real Numbers")]
        public float minimumRotation
        {
            get => _minimumRotation;
            set => _minimumRotation = value;
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


        [Description("turret is a collection of datastructures"), Category("Data Structure Collections")]
        public List<turretDataStructure> turret
        {
            get => _turret;
            set => _turret = value;
        }


        public DebrisData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction");
                _descriptionText = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "descriptionText");
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape");
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID");
                _debrisSizeAsShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "debrisSizeAsShipClass");

                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health");
                _timeToLive = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeToLive");
                _minimumMomentum = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "minimumMomentum");
                _minimumRotation = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "minimumRotation");

                _isMassInfinite = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "isMassInfinite");
                _bCanAddViaBattleEditorSlider = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanAddViaBattleEditorSlider");

                _turret = DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(DataXMLDoc);
            }
        }
    }
}
