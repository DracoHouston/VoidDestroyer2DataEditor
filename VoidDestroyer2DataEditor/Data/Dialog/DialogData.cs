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

        [Description("dialogID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string dialogID
        {
            get
            {
                return _dialogID;
            }
            set
            {
                _dialogID = value;
                SetPropertyEdited("dialogID", true);
            }
        }

        [Description("dialogType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string dialogType
        {
            get
            {
                return _dialogType;
            }
            set
            {
                _dialogType = value;
                SetPropertyEdited("dialogType", true);
            }
        }


        [Description("factionID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> factionID
        {
            get
            {
                return _factionID;
            }
            set
            {
                _factionID = value;
                SetPropertyEdited("factionID", true);
            }
        }

        [Description("dialog is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> dialog
        {
            get
            {
                return _dialog;
            }
            set
            {
                _dialog = value;
                SetPropertyEdited("dialog", true);
            }
        }


        [Description("bGeneric is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bGeneric
        {
            get
            {
                return _bGeneric;
            }
            set
            {
                _bGeneric = value;
                SetPropertyEdited("bGeneric", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("dialogID");
            InitProperty("dialogType");

            InitProperty("factionID");
            InitProperty("dialog");

            InitProperty("bGeneric");

        }

        public DialogData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _dialogID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dialogID", out exists);
                SetPropertyExistsInBaseData("dialogID", exists);
                SetPropertyExists("dialogID", exists);
                _dialogType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dialogType", out exists);
                SetPropertyExistsInBaseData("dialogType", exists);
                SetPropertyExists("dialogType", exists);

                _factionID = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionID", out exists);
                SetPropertyExistsInBaseData("factionID", exists);
                SetPropertyExists("factionID", exists);
                _dialog = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "dialog", out exists);
                SetPropertyExistsInBaseData("dialog", exists);
                SetPropertyExists("dialog", exists);

                _bGeneric = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGeneric", out exists);
                SetPropertyExistsInBaseData("bGeneric", exists);
                SetPropertyExists("bGeneric", exists);

            }
        }
    }
}
