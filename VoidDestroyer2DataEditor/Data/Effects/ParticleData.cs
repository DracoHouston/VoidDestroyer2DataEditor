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

        [Description("objectID is a plaintext string"), Category("Plaintext Strings")]
        public string objectID
        {
            get => _objectID;
            set => _objectID = value;
        }

        [Description("systemName is a plaintext string"), Category("Plaintext Strings")]
        public string systemName
        {
            get => _systemName;
            set => _systemName = value;
        }


        [Description("renderDistance is an integer"), Category("Integers")]
        public int renderDistance
        {
            get => _renderDistance;
            set => _renderDistance = value;
        }



        public ParticleData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _systemName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "systemName");

                _renderDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "renderDistance");

            }
        }
    }
}
