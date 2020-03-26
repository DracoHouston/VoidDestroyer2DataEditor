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


        [Description("offsetPosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D offsetPosition
        {
            get => _offsetPosition;
            set => _offsetPosition = value;
        }



        public CockpitData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");

                _offsetPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "offsetPosition");

            }
        }
    }
}
