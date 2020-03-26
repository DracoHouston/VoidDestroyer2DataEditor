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
    class DialogData : VD2Data
    {
        string _dialogID;
        string _dialogType;

        List<string> _factionID;
        List<string> _dialog;

        bool _bGeneric;

        [Description("dialogID is a plaintext string"), Category("Plaintext Strings")]
        public string dialogID
        {
            get => _dialogID;
            set => _dialogID = value;
        }

        [Description("dialogType is a plaintext string"), Category("Plaintext Strings")]
        public string dialogType
        {
            get => _dialogType;
            set => _dialogType = value;
        }


        [Description("factionID is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> factionID
        {
            get => _factionID;
            set => _factionID = value;
        }

        [Description("dialog is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> dialog
        {
            get => _dialog;
            set => _dialog = value;
        }


        [Description("bGeneric is a boolean value"), Category("Booleans")]
        public bool bGeneric
        {
            get => _bGeneric;
            set => _bGeneric = value;
        }



        public DialogData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _dialogID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dialogID");
                _dialogType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dialogType");

                _factionID = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionID");
                _dialog = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "dialog");

                _bGeneric = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGeneric");

            }
        }
    }
}
