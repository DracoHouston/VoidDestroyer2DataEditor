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
    class DockedMovingElementData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _meshName;
        string _soundID;

        int _proximityDistance;

        float _moveAwayTimeDuration;

        bool _bOpenOnProximity;

        Vector3D _translateVector;

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

        [Description("soundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string soundID
        {
            get
            {
                return _soundID;
            }
            set
            {
                _soundID = value;
                SetPropertyEdited("soundID", true);
            }
        }


        [Description("proximityDistance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int proximityDistance
        {
            get
            {
                return _proximityDistance;
            }
            set
            {
                _proximityDistance = value;
                SetPropertyEdited("proximityDistance", true);
            }
        }


        [Description("moveAwayTimeDuration is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float moveAwayTimeDuration
        {
            get
            {
                return _moveAwayTimeDuration;
            }
            set
            {
                _moveAwayTimeDuration = value;
                SetPropertyEdited("moveAwayTimeDuration", true);
            }
        }


        [Description("bOpenOnProximity is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bOpenOnProximity
        {
            get
            {
                return _bOpenOnProximity;
            }
            set
            {
                _bOpenOnProximity = value;
                SetPropertyEdited("bOpenOnProximity", true);
            }
        }


        [Description("translateVector is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D translateVector
        {
            get
            {
                return _translateVector;
            }
            set
            {
                _translateVector = value;
                SetPropertyEdited("translateVector", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            InitProperty("meshName");
            InitProperty("soundID");

            InitProperty("proximityDistance");

            InitProperty("moveAwayTimeDuration");

            InitProperty("bOpenOnProximity");

            InitProperty("translateVector");

        }

        public DockedMovingElementData(string inPath) : base(inPath)
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
                _soundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soundID", out exists);
                SetPropertyExistsInBaseData("soundID", exists);
                SetPropertyExists("soundID", exists);

                _proximityDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "proximityDistance", out exists);
                SetPropertyExistsInBaseData("proximityDistance", exists);
                SetPropertyExists("proximityDistance", exists);

                _moveAwayTimeDuration = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "moveAwayTimeDuration", out exists);
                SetPropertyExistsInBaseData("moveAwayTimeDuration", exists);
                SetPropertyExists("moveAwayTimeDuration", exists);

                _bOpenOnProximity = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOpenOnProximity", out exists);
                SetPropertyExistsInBaseData("bOpenOnProximity", exists);
                SetPropertyExists("bOpenOnProximity", exists);

                _translateVector = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "translateVector", out exists);
                SetPropertyExistsInBaseData("translateVector", exists);
                SetPropertyExists("translateVector", exists);

            }
        }
    }
}
