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

        int _initialColor;
        int _count;
        int _numberOfChains;
        int _maxChainElements;
        int _trailLength;
        int _colorChange;
        int _maxRangeZ;
        int _defaultDimensions;

        float _widthChange;
        float _initialWidth;

        [Description("effectType is a plaintext string"), Category("Plaintext Strings")]
        public string effectType
        {
            get => _effectType;
            set => _effectType = value;
        }

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


        [Description("initialColor is an integer"), Category("Integers")]
        public int initialColor
        {
            get => _initialColor;
            set => _initialColor = value;
        }

        [Description("count is an integer"), Category("Integers")]
        public int count
        {
            get => _count;
            set => _count = value;
        }

        [Description("numberOfChains is an integer"), Category("Integers")]
        public int numberOfChains
        {
            get => _numberOfChains;
            set => _numberOfChains = value;
        }

        [Description("maxChainElements is an integer"), Category("Integers")]
        public int maxChainElements
        {
            get => _maxChainElements;
            set => _maxChainElements = value;
        }

        [Description("trailLength is an integer"), Category("Integers")]
        public int trailLength
        {
            get => _trailLength;
            set => _trailLength = value;
        }

        [Description("colorChange is an integer"), Category("Integers")]
        public int colorChange
        {
            get => _colorChange;
            set => _colorChange = value;
        }

        [Description("maxRangeZ is an integer"), Category("Integers")]
        public int maxRangeZ
        {
            get => _maxRangeZ;
            set => _maxRangeZ = value;
        }

        [Description("defaultDimensions is an integer"), Category("Integers")]
        public int defaultDimensions
        {
            get => _defaultDimensions;
            set => _defaultDimensions = value;
        }


        [Description("widthChange is a real number"), Category("Real Numbers")]
        public float widthChange
        {
            get => _widthChange;
            set => _widthChange = value;
        }

        [Description("initialWidth is a real number"), Category("Real Numbers")]
        public float initialWidth
        {
            get => _initialWidth;
            set => _initialWidth = value;
        }



        public EffectData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _effectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "effectType");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName");

                _initialColor = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "initialColor");
                _count = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "count");
                _numberOfChains = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "numberOfChains");
                _maxChainElements = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxChainElements");
                _trailLength = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "trailLength");
                _colorChange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "colorChange");
                _maxRangeZ = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxRangeZ");
                _defaultDimensions = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "defaultDimensions");

                _widthChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "widthChange");
                _initialWidth = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialWidth");

            }
        }
    }
}
