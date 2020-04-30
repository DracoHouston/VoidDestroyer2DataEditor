using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    public class CockpitData : VD2Data
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _objectID = value;
                        SetPropertyEdited("objectID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _meshName = value;
                        SetPropertyEdited("meshName", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _offsetPosition.OnElementChanged -= offsetPosition_OnElementChanged;
                        _offsetPosition = value;
                        _offsetPosition.OnElementChanged += offsetPosition_OnElementChanged;
                        SetPropertyEdited("offsetPosition", true);
                    }
                }
            }
        }

        private void offsetPosition_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("offsetPosition", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= offsetPosition_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += offsetPosition_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= offsetPosition_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += offsetPosition_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= offsetPosition_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += offsetPosition_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("meshName");

            InitProperty("offsetPosition");

        }

        public CockpitData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
        }

        public override void LoadDataFromXML()
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("objectID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("objectID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(objectID, "objectID"));
                }
                SetPropertyExists("objectID", exists);

                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("meshName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("meshName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "meshName"));
                }
                SetPropertyExists("meshName", exists);

                _offsetPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "offsetPosition", out exists);
                _offsetPosition.OnElementChanged += offsetPosition_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("offsetPosition", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("offsetPosition", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "offsetPosition"));
                }
                SetPropertyExists("offsetPosition", exists);

                base.LoadDataFromXML();
            }
        }

        protected override void SaveData()
        {
            List<string> xmltextlines = new List<string>();
            xmltextlines.Add("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xmltextlines.Add("<note_to_self attr1=\"Generated by Void Destroyer 2 Data Editor\"/>");
            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Strings...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("offsetPosition"))
            {
                xmltextlines.Add("<offsetPosition x=\"" + _offsetPosition.x.ToString() + "\" y=\"" + _offsetPosition.y.ToString() + "\" z=\"" + _offsetPosition.z.ToString() + "\"/>");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
        }
    }
}
