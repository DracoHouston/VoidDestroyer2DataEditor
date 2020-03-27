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
    class DoorData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _meshName;
        string _doorSoundID;

        float _openTimeMultiplier;

        bool _bPhysicalDoor;
        bool _bOpenOnProximity;

        Vector3D _translateMax;

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

        [Description("doorSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string doorSoundID
        {
            get
            {
                return _doorSoundID;
            }
            set
            {
                _doorSoundID = value;
                SetPropertyEdited("doorSoundID", true);
            }
        }


        [Description("openTimeMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float openTimeMultiplier
        {
            get
            {
                return _openTimeMultiplier;
            }
            set
            {
                _openTimeMultiplier = value;
                SetPropertyEdited("openTimeMultiplier", true);
            }
        }


        [Description("bPhysicalDoor is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPhysicalDoor
        {
            get
            {
                return _bPhysicalDoor;
            }
            set
            {
                _bPhysicalDoor = value;
                SetPropertyEdited("bPhysicalDoor", true);
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


        [Description("translateMax is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D translateMax
        {
            get
            {
                return _translateMax;
            }
            set
            {
                _translateMax = value;
                SetPropertyEdited("translateMax", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            InitProperty("meshName");
            InitProperty("doorSoundID");

            InitProperty("openTimeMultiplier");

            InitProperty("bPhysicalDoor");
            InitProperty("bOpenOnProximity");

            InitProperty("translateMax");

        }

        public DoorData(string inPath) : base(inPath)
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
                _doorSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "doorSoundID", out exists);
                SetPropertyExistsInBaseData("doorSoundID", exists);
                SetPropertyExists("doorSoundID", exists);

                _openTimeMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "openTimeMultiplier", out exists);
                SetPropertyExistsInBaseData("openTimeMultiplier", exists);
                SetPropertyExists("openTimeMultiplier", exists);

                _bPhysicalDoor = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPhysicalDoor", out exists);
                SetPropertyExistsInBaseData("bPhysicalDoor", exists);
                SetPropertyExists("bPhysicalDoor", exists);
                _bOpenOnProximity = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOpenOnProximity", out exists);
                SetPropertyExistsInBaseData("bOpenOnProximity", exists);
                SetPropertyExists("bOpenOnProximity", exists);

                _translateMax = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "translateMax", out exists);
                SetPropertyExistsInBaseData("translateMax", exists);
                SetPropertyExists("translateMax", exists);

            }
        }
    }
}
