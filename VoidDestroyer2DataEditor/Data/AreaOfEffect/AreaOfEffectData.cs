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
    class AreaOfEffectData : VD2Data
    {
        string _objectID;
        string _particleSystemName;
        string _affectedObjects;

        int _damage;
        int _lifeTimer;

        bool _bRefuel;
        bool _bDebrisFieldRadiation;

        Vector3D _fieldSize;

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

        [Description("particleSystemName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string particleSystemName
        {
            get
            {
                return _particleSystemName;
            }
            set
            {
                _particleSystemName = value;
                SetPropertyEdited("particleSystemName", true);
            }
        }

        [Description("affectedObjects is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string affectedObjects
        {
            get
            {
                return _affectedObjects;
            }
            set
            {
                _affectedObjects = value;
                SetPropertyEdited("affectedObjects", true);
            }
        }


        [Description("damage is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int damage
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

        [Description("lifeTimer is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int lifeTimer
        {
            get
            {
                return _lifeTimer;
            }
            set
            {
                _lifeTimer = value;
                SetPropertyEdited("lifeTimer", true);
            }
        }


        [Description("bRefuel is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bRefuel
        {
            get
            {
                return _bRefuel;
            }
            set
            {
                _bRefuel = value;
                SetPropertyEdited("bRefuel", true);
            }
        }

        [Description("bDebrisFieldRadiation is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bDebrisFieldRadiation
        {
            get
            {
                return _bDebrisFieldRadiation;
            }
            set
            {
                _bDebrisFieldRadiation = value;
                SetPropertyEdited("bDebrisFieldRadiation", true);
            }
        }


        [Description("fieldSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D fieldSize
        {
            get
            {
                return _fieldSize;
            }
            set
            {
                _fieldSize = value;
                SetPropertyEdited("fieldSize", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectID");
            InitProperty("particleSystemName");
            InitProperty("affectedObjects");

            InitProperty("damage");
            InitProperty("lifeTimer");

            InitProperty("bRefuel");
            InitProperty("bDebrisFieldRadiation");

            InitProperty("fieldSize");

        }

        public AreaOfEffectData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _particleSystemName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "particleSystemName", out exists);
                SetPropertyExistsInBaseData("particleSystemName", exists);
                SetPropertyExists("particleSystemName", exists);
                _affectedObjects = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "affectedObjects", out exists);
                SetPropertyExistsInBaseData("affectedObjects", exists);
                SetPropertyExists("affectedObjects", exists);

                _damage = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "damage", out exists);
                SetPropertyExistsInBaseData("damage", exists);
                SetPropertyExists("damage", exists);
                _lifeTimer = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "lifeTimer", out exists);
                SetPropertyExistsInBaseData("lifeTimer", exists);
                SetPropertyExists("lifeTimer", exists);

                _bRefuel = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRefuel", out exists);
                SetPropertyExistsInBaseData("bRefuel", exists);
                SetPropertyExists("bRefuel", exists);
                _bDebrisFieldRadiation = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bDebrisFieldRadiation", out exists);
                SetPropertyExistsInBaseData("bDebrisFieldRadiation", exists);
                SetPropertyExists("bDebrisFieldRadiation", exists);

                _fieldSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "fieldSize", out exists);
                SetPropertyExistsInBaseData("fieldSize", exists);
                SetPropertyExists("fieldSize", exists);

            }
        }
    }
}
