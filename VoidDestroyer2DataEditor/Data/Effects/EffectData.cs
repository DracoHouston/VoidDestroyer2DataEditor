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
    public class EffectData : VD2Data
    {
        string _effectType;
        string _objectID;
        string _materialName;

        int _count;
        int _numberOfChains;
        int _maxChainElements;
        int _trailLength;
        int _maxRangeZ;
        int _defaultDimensions;

        float _widthChange;
        float _initialWidth;

        ColorF _initialColor;
        ColorF _colorChange;

        [Description("effectType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string effectType
        {
            get
            {
                return _effectType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _effectType = value;
                        SetPropertyEdited("effectType", true);
                    }
                }
            }
        }

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

        [Description("materialName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string materialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _materialName = value;
                        SetPropertyEdited("materialName", true);
                    }
                }
            }
        }


        [Description("count is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int count
        {
            get
            {
                return _count;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _count = value;
                        SetPropertyEdited("count", true);
                    }
                }
            }
        }

        [Description("numberOfChains is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int numberOfChains
        {
            get
            {
                return _numberOfChains;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _numberOfChains = value;
                        SetPropertyEdited("numberOfChains", true);
                    }
                }
            }
        }

        [Description("maxChainElements is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int maxChainElements
        {
            get
            {
                return _maxChainElements;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _maxChainElements = value;
                        SetPropertyEdited("maxChainElements", true);
                    }
                }
            }
        }

        [Description("trailLength is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int trailLength
        {
            get
            {
                return _trailLength;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _trailLength = value;
                        SetPropertyEdited("trailLength", true);
                    }
                }
            }
        }

        [Description("maxRangeZ is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int maxRangeZ
        {
            get
            {
                return _maxRangeZ;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _maxRangeZ = value;
                        SetPropertyEdited("maxRangeZ", true);
                    }
                }
            }
        }

        [Description("defaultDimensions is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int defaultDimensions
        {
            get
            {
                return _defaultDimensions;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _defaultDimensions = value;
                        SetPropertyEdited("defaultDimensions", true);
                    }
                }
            }
        }


        [Description("widthChange is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float widthChange
        {
            get
            {
                return _widthChange;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _widthChange = value;
                        SetPropertyEdited("widthChange", true);
                    }
                }
            }
        }

        [Description("initialWidth is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float initialWidth
        {
            get
            {
                return _initialWidth;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _initialWidth = value;
                        SetPropertyEdited("initialWidth", true);
                    }
                }
            }
        }


        [Description("initialColor is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF initialColor
        {
            get
            {
                return _initialColor;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _initialColor.OnElementChanged -= initialColor_OnElementChanged;
                        _initialColor = value;
                        _initialColor.OnElementChanged += initialColor_OnElementChanged;
                        SetPropertyEdited("initialColor", true);
                    }
                }
            }
        }

        private void initialColor_OnElementChanged(object sender, ColorFElementChangedEventArgs e)
        {
            if (sender is ColorF)
            {
                ColorF colorsender = (ColorF)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("initialColor", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case ColorFElements.r:
                                colorsender.OnElementChanged -= initialColor_OnElementChanged;
                                colorsender.r = e.OldValue;
                                colorsender.OnElementChanged += initialColor_OnElementChanged;
                                break;
                            case ColorFElements.g:
                                colorsender.OnElementChanged -= initialColor_OnElementChanged;
                                colorsender.g = e.OldValue;
                                colorsender.OnElementChanged += initialColor_OnElementChanged;
                                break;
                            case ColorFElements.b:
                                colorsender.OnElementChanged -= initialColor_OnElementChanged;
                                colorsender.b = e.OldValue;
                                colorsender.OnElementChanged += initialColor_OnElementChanged;
                                break;
                            case ColorFElements.a:
                                colorsender.OnElementChanged -= initialColor_OnElementChanged;
                                colorsender.a = e.OldValue;
                                colorsender.OnElementChanged += initialColor_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }

        [Description("colorChange is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF colorChange
        {
            get
            {
                return _colorChange;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _colorChange.OnElementChanged -= colorChange_OnElementChanged;
                        _colorChange = value;
                        _colorChange.OnElementChanged += colorChange_OnElementChanged;
                        SetPropertyEdited("colorChange", true);
                    }
                }
            }
        }

        private void colorChange_OnElementChanged(object sender, ColorFElementChangedEventArgs e)
        {
            if (sender is ColorF)
            {
                ColorF colorsender = (ColorF)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("colorChange", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case ColorFElements.r:
                                colorsender.OnElementChanged -= colorChange_OnElementChanged;
                                colorsender.r = e.OldValue;
                                colorsender.OnElementChanged += colorChange_OnElementChanged;
                                break;
                            case ColorFElements.g:
                                colorsender.OnElementChanged -= colorChange_OnElementChanged;
                                colorsender.g = e.OldValue;
                                colorsender.OnElementChanged += colorChange_OnElementChanged;
                                break;
                            case ColorFElements.b:
                                colorsender.OnElementChanged -= colorChange_OnElementChanged;
                                colorsender.b = e.OldValue;
                                colorsender.OnElementChanged += colorChange_OnElementChanged;
                                break;
                            case ColorFElements.a:
                                colorsender.OnElementChanged -= colorChange_OnElementChanged;
                                colorsender.a = e.OldValue;
                                colorsender.OnElementChanged += colorChange_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("effectType");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("materialName");

            InitProperty("count");
            InitProperty("numberOfChains");
            InitProperty("maxChainElements");
            InitProperty("trailLength");
            InitProperty("maxRangeZ");
            InitProperty("defaultDimensions");

            InitProperty("widthChange");
            InitProperty("initialWidth");

            InitProperty("initialColor");
            InitProperty("colorChange");

        }

        public EffectData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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

                _effectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "effectType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("effectType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("effectType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "effectType"));
                }
                SetPropertyExists("effectType", exists);
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("materialName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("materialName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "materialName"));
                }
                SetPropertyExists("materialName", exists);

                _count = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "count", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("count", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("count", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "count"));
                }
                SetPropertyExists("count", exists);
                _numberOfChains = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "numberOfChains", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("numberOfChains", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("numberOfChains", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "numberOfChains"));
                }
                SetPropertyExists("numberOfChains", exists);
                _maxChainElements = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxChainElements", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("maxChainElements", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("maxChainElements", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "maxChainElements"));
                }
                SetPropertyExists("maxChainElements", exists);
                _trailLength = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "trailLength", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("trailLength", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("trailLength", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "trailLength"));
                }
                SetPropertyExists("trailLength", exists);
                _maxRangeZ = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxRangeZ", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("maxRangeZ", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("maxRangeZ", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "maxRangeZ"));
                }
                SetPropertyExists("maxRangeZ", exists);
                _defaultDimensions = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "defaultDimensions", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("defaultDimensions", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("defaultDimensions", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "defaultDimensions"));
                }
                SetPropertyExists("defaultDimensions", exists);

                _widthChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "widthChange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("widthChange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("widthChange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "widthChange"));
                }
                SetPropertyExists("widthChange", exists);
                _initialWidth = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialWidth", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("initialWidth", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("initialWidth", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "initialWidth"));
                }
                SetPropertyExists("initialWidth", exists);

                _initialColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "initialColor", out exists);
                _initialColor.OnElementChanged += initialColor_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("initialColor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("initialColor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "initialColor"));
                }
                SetPropertyExists("initialColor", exists);
                _colorChange = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "colorChange", out exists);
                _colorChange.OnElementChanged += colorChange_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("colorChange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("colorChange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "colorChange"));
                }
                SetPropertyExists("colorChange", exists);

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
            if (PropertyExists("effectType"))
            {
                xmltextlines.Add("<effectType attr1=\"" + _effectType + "\"/>");
            }
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("materialName"))
            {
                xmltextlines.Add("<materialName attr1=\"" + _materialName + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("count"))
            {
                xmltextlines.Add("<count attr1=\"" + _count.ToString() + "\"/>");
            }
            if (PropertyExists("numberOfChains"))
            {
                xmltextlines.Add("<numberOfChains attr1=\"" + _numberOfChains.ToString() + "\"/>");
            }
            if (PropertyExists("maxChainElements"))
            {
                xmltextlines.Add("<maxChainElements attr1=\"" + _maxChainElements.ToString() + "\"/>");
            }
            if (PropertyExists("trailLength"))
            {
                xmltextlines.Add("<trailLength attr1=\"" + _trailLength.ToString() + "\"/>");
            }
            if (PropertyExists("maxRangeZ"))
            {
                xmltextlines.Add("<maxRangeZ attr1=\"" + _maxRangeZ.ToString() + "\"/>");
            }
            if (PropertyExists("defaultDimensions"))
            {
                xmltextlines.Add("<defaultDimensions attr1=\"" + _defaultDimensions.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("widthChange"))
            {
                xmltextlines.Add("<widthChange attr1=\"" + _widthChange.ToString() + "\"/>");
            }
            if (PropertyExists("initialWidth"))
            {
                xmltextlines.Add("<initialWidth attr1=\"" + _initialWidth.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Colors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("initialColor"))
            {
                xmltextlines.Add("<initialColor r=\"" + _initialColor.r.ToString() + "\" g=\"" + _initialColor.g.ToString() + "\" b=\"" + _initialColor.b.ToString() + "\" a=\"" + _initialColor.a.ToString() + "\"/>");
            }
            if (PropertyExists("colorChange"))
            {
                xmltextlines.Add("<colorChange r=\"" + _colorChange.r.ToString() + "\" g=\"" + _colorChange.g.ToString() + "\" b=\"" + _colorChange.b.ToString() + "\" a=\"" + _colorChange.a.ToString() + "\"/>");
            }

            SafeWriteAllLines(_FilePath, xmltextlines);
        }
    }
}
