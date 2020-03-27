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
    class CockpitData : VD2Data
    {
        string _objectID;
        string _meshName;

        Vector3D _offsetPosition;

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


        [Description("offsetPosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D offsetPosition
        {
            get
            {
                return _offsetPosition;
            }
            set
            {
                _offsetPosition = value;
                SetPropertyEdited("offsetPosition", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectID");
            InitProperty("meshName");

            InitProperty("offsetPosition");

        }

        public CockpitData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                SetPropertyExistsInBaseData("meshName", exists);
                SetPropertyExists("meshName", exists);

                _offsetPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "offsetPosition", out exists);
                SetPropertyExistsInBaseData("offsetPosition", exists);
                SetPropertyExists("offsetPosition", exists);

            }
        }
    }
}
