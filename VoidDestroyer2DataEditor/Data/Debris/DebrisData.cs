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

        int _isMassInfinite;

        float _health;
        float _timeToLive;
        float _minimumMomentum;
        float _minimumRotation;

        bool _bCanAddViaBattleEditorSlider;

        List<turretDataStructure> _turret;

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

        [Description("descriptionText is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string descriptionText
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

        [Description("debrisSizeAsShipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string debrisSizeAsShipClass
        {
            get
            {
                return _debrisSizeAsShipClass;
            }
            set
            {
                _debrisSizeAsShipClass = value;
                SetPropertyEdited("debrisSizeAsShipClass", true);
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

        [Description("timeToLive is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float timeToLive
        {
            get
            {
                return _timeToLive;
            }
            set
            {
                _timeToLive = value;
                SetPropertyEdited("timeToLive", true);
            }
        }

        [Description("minimumMomentum is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float minimumMomentum
        {
            get
            {
                return _minimumMomentum;
            }
            set
            {
                _minimumMomentum = value;
                SetPropertyEdited("minimumMomentum", true);
            }
        }

        [Description("minimumRotation is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float minimumRotation
        {
            get
            {
                return _minimumRotation;
            }
            set
            {
                _minimumRotation = value;
                SetPropertyEdited("minimumRotation", true);
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


        [Description("turret is a collection of datastructures"), Category("Data Structure Collections")]
        public List<turretDataStructure> turret
        {
            get
            {
                return _turret;
            }
            set
            {
                _turret = value;
                SetPropertyEdited("turret", true);
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            InitProperty("meshName");
            InitProperty("faction");
            InitProperty("descriptionText");
            InitProperty("collisionShape");
            InitProperty("explosionID");
            InitProperty("debrisSizeAsShipClass");

            InitProperty("isMassInfinite");

            InitProperty("health");
            InitProperty("timeToLive");
            InitProperty("minimumMomentum");
            InitProperty("minimumRotation");

            InitProperty("bCanAddViaBattleEditorSlider");

            InitProperty("turret");
        }

        public DebrisData(string inPath) : base(inPath)
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
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction", out exists);
                SetPropertyExistsInBaseData("faction", exists);
                SetPropertyExists("faction", exists);
                _descriptionText = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "descriptionText", out exists);
                SetPropertyExistsInBaseData("descriptionText", exists);
                SetPropertyExists("descriptionText", exists);
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape", out exists);
                SetPropertyExistsInBaseData("collisionShape", exists);
                SetPropertyExists("collisionShape", exists);
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                SetPropertyExistsInBaseData("explosionID", exists);
                SetPropertyExists("explosionID", exists);
                _debrisSizeAsShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "debrisSizeAsShipClass", out exists);
                SetPropertyExistsInBaseData("debrisSizeAsShipClass", exists);
                SetPropertyExists("debrisSizeAsShipClass", exists);

                _isMassInfinite = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "isMassInfinite", out exists);
                SetPropertyExistsInBaseData("isMassInfinite", exists);
                SetPropertyExists("isMassInfinite", exists);

                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health", out exists);
                SetPropertyExistsInBaseData("health", exists);
                SetPropertyExists("health", exists);
                _timeToLive = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeToLive", out exists);
                SetPropertyExistsInBaseData("timeToLive", exists);
                SetPropertyExists("timeToLive", exists);
                _minimumMomentum = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "minimumMomentum", out exists);
                SetPropertyExistsInBaseData("minimumMomentum", exists);
                SetPropertyExists("minimumMomentum", exists);
                _minimumRotation = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "minimumRotation", out exists);
                SetPropertyExistsInBaseData("minimumRotation", exists);
                SetPropertyExists("minimumRotation", exists);

                _bCanAddViaBattleEditorSlider = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanAddViaBattleEditorSlider", out exists);
                SetPropertyExistsInBaseData("bCanAddViaBattleEditorSlider", exists);
                SetPropertyExists("bCanAddViaBattleEditorSlider", exists);

                _turret = DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("turret", exists);
                SetPropertyExists("turret", exists);
            }
        }
    }
}
