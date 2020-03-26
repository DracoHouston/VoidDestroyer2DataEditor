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
    class ShieldData : VD2Data
    {
        string _objectType;
        string _name;
        string _shieldID;
        string _collisionMeshName;
        string _shieldType;
        string _materialName;

        bool _bInvisible;

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

        [Description("shieldID is a plaintext string"), Category("Plaintext Strings")]
        public string shieldID
        {
            get => _shieldID;
            set => _shieldID = value;
        }

        [Description("collisionMeshName is a plaintext string"), Category("Plaintext Strings")]
        public string collisionMeshName
        {
            get => _collisionMeshName;
            set => _collisionMeshName = value;
        }

        [Description("shieldType is a plaintext string"), Category("Plaintext Strings")]
        public string shieldType
        {
            get => _shieldType;
            set => _shieldType = value;
        }

        [Description("materialName is a plaintext string"), Category("Plaintext Strings")]
        public string materialName
        {
            get => _materialName;
            set => _materialName = value;
        }


        [Description("bInvisible is a boolean value"), Category("Booleans")]
        public bool bInvisible
        {
            get => _bInvisible;
            set => _bInvisible = value;
        }



        public ShieldData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _shieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldID");
                _collisionMeshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionMeshName");
                _shieldType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldType");
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName");

                _bInvisible = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bInvisible");

            }
        }
    }
}
