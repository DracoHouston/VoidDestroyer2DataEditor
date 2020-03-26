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
    class SkyboxData : VD2Data
    {
        string _objectID;
        string _materialName;

        List<string> _factionType;

        bool _bGeneric;

        [Description("objectID is a plaintext string"), Category("Plaintext Strings")]
        public string objectID
        {
            get => _objectID;
            set => _objectID = value;
        }

        [Description("materialName is a plaintext string"), Category("Plaintext Strings")]
        public string materialName
        {
            get => _materialName;
            set => _materialName = value;
        }


        [Description("factionType is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> factionType
        {
            get => _factionType;
            set => _factionType = value;
        }


        [Description("bGeneric is a boolean value"), Category("Booleans")]
        public bool bGeneric
        {
            get => _bGeneric;
            set => _bGeneric = value;
        }



        public SkyboxData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName");

                _factionType = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionType");

                _bGeneric = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGeneric");

            }
        }
    }
}
