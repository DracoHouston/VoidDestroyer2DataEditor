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
    class CharacterData : VD2Data
    {
        string _displayName;
        string _characterID;
        string _imageSetName;
        string _textColor;
        string _title;
        string _physicalObjectType;

        List<string> _factionID;

        bool _bGeneric;

        [Description("displayName is a plaintext string"), Category("Plaintext Strings")]
        public string displayName
        {
            get => _displayName;
            set => _displayName = value;
        }

        [Description("characterID is a plaintext string"), Category("Plaintext Strings")]
        public string characterID
        {
            get => _characterID;
            set => _characterID = value;
        }

        [Description("imageSetName is a plaintext string"), Category("Plaintext Strings")]
        public string imageSetName
        {
            get => _imageSetName;
            set => _imageSetName = value;
        }

        [Description("textColor is a plaintext string"), Category("Plaintext Strings")]
        public string textColor
        {
            get => _textColor;
            set => _textColor = value;
        }

        [Description("title is a plaintext string"), Category("Plaintext Strings")]
        public string title
        {
            get => _title;
            set => _title = value;
        }

        [Description("physicalObjectType is a plaintext string"), Category("Plaintext Strings")]
        public string physicalObjectType
        {
            get => _physicalObjectType;
            set => _physicalObjectType = value;
        }


        [Description("factionID is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> factionID
        {
            get => _factionID;
            set => _factionID = value;
        }


        [Description("bGeneric is a boolean value"), Category("Booleans")]
        public bool bGeneric
        {
            get => _bGeneric;
            set => _bGeneric = value;
        }



        public CharacterData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName");
                _characterID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "characterID");
                _imageSetName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "imageSetName");
                _textColor = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "textColor");
                _title = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "title");
                _physicalObjectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "physicalObjectType");

                _factionID = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionID");

                _bGeneric = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGeneric");

            }
        }
    }
}
