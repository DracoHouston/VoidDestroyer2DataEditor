using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ComponentModel;

namespace VoidDestroyer2DataEditor
{
    public class DialogData : VD2Data
    {
        string _dialogID;
        string _dialogType;

        ObservableCollection<string> _factionID;
        ObservableCollection<string> _dialog;

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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _dialogID = value;
                        SetPropertyEdited("dialogID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _dialogType = value;
                        SetPropertyEdited("dialogType", true);
                    }
                }
            }
        }


        [Description("factionID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> factionID
        {
            get
            {
                return _factionID;
            }
            set
            {
                _factionID = value;
            }
        }

        private void OnfactionIDChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("factionID", true);
                }
                else
                {
                    bool exists = false;
                    _factionID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionID", out exists));
                    _factionID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnfactionIDChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("factionID", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("factionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionID"));
                    }
                    SetPropertyExists("factionID", exists);
                }
            }
        }

        [Description("dialog is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> dialog
        {
            get
            {
                return _dialog;
            }
            set
            {
                _dialog = value;
            }
        }

        private void OndialogChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("dialog", true);
                }
                else
                {
                    bool exists = false;
                    _dialog = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "dialog", out exists));
                    _dialog.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OndialogChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("dialog", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("dialog", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dialog"));
                    }
                    SetPropertyExists("dialog", exists);
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bGeneric = value;
                        SetPropertyEdited("bGeneric", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("dialogID");
            SetPropertyIsObjectID("dialogID", true);
            InitProperty("dialogType");

            InitProperty("factionID");
            InitProperty("dialog");

            InitProperty("bGeneric");

        }

        public DialogData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _dialogID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dialogID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dialogID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dialogID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(dialogID, "dialogID"));
                }
                SetPropertyExists("dialogID", exists);

                _dialogType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dialogType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dialogType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dialogType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dialogType"));
                }
                SetPropertyExists("dialogType", exists);

                _factionID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionID", out exists));
                _factionID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnfactionIDChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("factionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("factionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionID"));
                }
                SetPropertyExists("factionID", exists);
                _dialog = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "dialog", out exists));
                _dialog.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OndialogChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dialog", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dialog", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dialog"));
                }
                SetPropertyExists("dialog", exists);

                _bGeneric = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGeneric", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bGeneric", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bGeneric", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bGeneric"));
                }
                SetPropertyExists("bGeneric", exists);

            }
        }
    }
}
