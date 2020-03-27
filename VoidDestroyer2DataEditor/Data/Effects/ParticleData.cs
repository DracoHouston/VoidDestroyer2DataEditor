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
    class ParticleData : VD2Data
    {
        string _objectID;
        string _systemName;

        int _renderDistance;

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

        [Description("systemName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string systemName
        {
            get
            {
                return _systemName;
            }
            set
            {
                _systemName = value;
                SetPropertyEdited("systemName", true);
            }
        }


        [Description("renderDistance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int renderDistance
        {
            get
            {
                return _renderDistance;
            }
            set
            {
                _renderDistance = value;
                SetPropertyEdited("renderDistance", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectID");
            InitProperty("systemName");

            InitProperty("renderDistance");

        }

        public ParticleData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _systemName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "systemName", out exists);
                SetPropertyExistsInBaseData("systemName", exists);
                SetPropertyExists("systemName", exists);

                _renderDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "renderDistance", out exists);
                SetPropertyExistsInBaseData("renderDistance", exists);
                SetPropertyExists("renderDistance", exists);

            }
        }
    }
}
