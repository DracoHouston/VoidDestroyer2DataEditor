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
    class EffectData : VD2Data
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
                _effectType = value;
                SetPropertyEdited("effectType", true);
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
                _objectID = value;
                SetPropertyEdited("objectID", true);
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
                _materialName = value;
                SetPropertyEdited("materialName", true);
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
                _count = value;
                SetPropertyEdited("count", true);
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
                _numberOfChains = value;
                SetPropertyEdited("numberOfChains", true);
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
                _maxChainElements = value;
                SetPropertyEdited("maxChainElements", true);
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
                _trailLength = value;
                SetPropertyEdited("trailLength", true);
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
                _maxRangeZ = value;
                SetPropertyEdited("maxRangeZ", true);
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
                _defaultDimensions = value;
                SetPropertyEdited("defaultDimensions", true);
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
                _widthChange = value;
                SetPropertyEdited("widthChange", true);
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
                _initialWidth = value;
                SetPropertyEdited("initialWidth", true);
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
                _initialColor = value;
                SetPropertyEdited("initialColor", true);
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
                _colorChange = value;
                SetPropertyEdited("colorChange", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("effectType");
            InitProperty("objectID");
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

        public EffectData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _effectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "effectType", out exists);
                SetPropertyExistsInBaseData("effectType", exists);
                SetPropertyExists("effectType", exists);
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName", out exists);
                SetPropertyExistsInBaseData("materialName", exists);
                SetPropertyExists("materialName", exists);

                _count = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "count", out exists);
                SetPropertyExistsInBaseData("count", exists);
                SetPropertyExists("count", exists);
                _numberOfChains = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "numberOfChains", out exists);
                SetPropertyExistsInBaseData("numberOfChains", exists);
                SetPropertyExists("numberOfChains", exists);
                _maxChainElements = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxChainElements", out exists);
                SetPropertyExistsInBaseData("maxChainElements", exists);
                SetPropertyExists("maxChainElements", exists);
                _trailLength = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "trailLength", out exists);
                SetPropertyExistsInBaseData("trailLength", exists);
                SetPropertyExists("trailLength", exists);
                _maxRangeZ = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxRangeZ", out exists);
                SetPropertyExistsInBaseData("maxRangeZ", exists);
                SetPropertyExists("maxRangeZ", exists);
                _defaultDimensions = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "defaultDimensions", out exists);
                SetPropertyExistsInBaseData("defaultDimensions", exists);
                SetPropertyExists("defaultDimensions", exists);

                _widthChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "widthChange", out exists);
                SetPropertyExistsInBaseData("widthChange", exists);
                SetPropertyExists("widthChange", exists);
                _initialWidth = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialWidth", out exists);
                SetPropertyExistsInBaseData("initialWidth", exists);
                SetPropertyExists("initialWidth", exists);

                _initialColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "initialColor", out exists);
                SetPropertyExistsInBaseData("initialColor", exists);
                SetPropertyExists("initialColor", exists);
                _colorChange = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "colorChange", out exists);
                SetPropertyExistsInBaseData("colorChange", exists);
                SetPropertyExists("colorChange", exists);

            }
        }
    }
}
