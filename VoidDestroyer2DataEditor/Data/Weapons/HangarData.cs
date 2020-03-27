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
    class HangarData : VD2Data
    {
        string _weaponType;
        string _hangarID;
        string _fighterShipID;
        string _name;

        int _maxFighters;
        int _launchRange;

        float _launchSpeedMultiplier;

        bool _bPrimary;
        bool _bRepairHangar;
        bool _bForceSearchAndDestroy;
        bool _bIndependent;
        bool _bSecondaryFire;

        List<launchTubeDataStructure> _launchTube;

        [Description("weaponType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponType
        {
            get
            {
                return _weaponType;
            }
            set
            {
                _weaponType = value;
                SetPropertyEdited("weaponType", true);
            }
        }

        [Description("hangarID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string hangarID
        {
            get
            {
                return _hangarID;
            }
            set
            {
                _hangarID = value;
                SetPropertyEdited("hangarID", true);
            }
        }

        [Description("fighterShipID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string fighterShipID
        {
            get
            {
                return _fighterShipID;
            }
            set
            {
                _fighterShipID = value;
                SetPropertyEdited("fighterShipID", true);
            }
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                SetPropertyEdited("name", true);
            }
        }


        [Description("maxFighters is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int maxFighters
        {
            get
            {
                return _maxFighters;
            }
            set
            {
                _maxFighters = value;
                SetPropertyEdited("maxFighters", true);
            }
        }

        [Description("launchRange is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int launchRange
        {
            get
            {
                return _launchRange;
            }
            set
            {
                _launchRange = value;
                SetPropertyEdited("launchRange", true);
            }
        }


        [Description("launchSpeedMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float launchSpeedMultiplier
        {
            get
            {
                return _launchSpeedMultiplier;
            }
            set
            {
                _launchSpeedMultiplier = value;
                SetPropertyEdited("launchSpeedMultiplier", true);
            }
        }


        [Description("bPrimary is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPrimary
        {
            get
            {
                return _bPrimary;
            }
            set
            {
                _bPrimary = value;
                SetPropertyEdited("bPrimary", true);
            }
        }

        [Description("bRepairHangar is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bRepairHangar
        {
            get
            {
                return _bRepairHangar;
            }
            set
            {
                _bRepairHangar = value;
                SetPropertyEdited("bRepairHangar", true);
            }
        }

        [Description("bForceSearchAndDestroy is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bForceSearchAndDestroy
        {
            get
            {
                return _bForceSearchAndDestroy;
            }
            set
            {
                _bForceSearchAndDestroy = value;
                SetPropertyEdited("bForceSearchAndDestroy", true);
            }
        }

        [Description("bIndependent is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bIndependent
        {
            get
            {
                return _bIndependent;
            }
            set
            {
                _bIndependent = value;
                SetPropertyEdited("bIndependent", true);
            }
        }

        [Description("bSecondaryFire is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bSecondaryFire
        {
            get
            {
                return _bSecondaryFire;
            }
            set
            {
                _bSecondaryFire = value;
                SetPropertyEdited("bSecondaryFire", true);
            }
        }


        [Description("launchTube is a collection of datastructures"), Category("Data Structure Collections")]
        public List<launchTubeDataStructure> launchTube
        {
            get
            {
                return _launchTube;
            }
            set
            {
                _launchTube = value;
                SetPropertyEdited("launchTube", true);
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("weaponType");
            InitProperty("hangarID");
            InitProperty("fighterShipID");
            InitProperty("name");

            InitProperty("maxFighters");
            InitProperty("launchRange");

            InitProperty("launchSpeedMultiplier");

            InitProperty("bPrimary");
            InitProperty("bRepairHangar");
            InitProperty("bForceSearchAndDestroy");
            InitProperty("bIndependent");
            InitProperty("bSecondaryFire");

            InitProperty("launchTube");
        }

        public HangarData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _weaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponType", out exists);
                SetPropertyExistsInBaseData("weaponType", exists);
                SetPropertyExists("weaponType", exists);
                _hangarID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hangarID", out exists);
                SetPropertyExistsInBaseData("hangarID", exists);
                SetPropertyExists("hangarID", exists);
                _fighterShipID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "fighterShipID", out exists);
                SetPropertyExistsInBaseData("fighterShipID", exists);
                SetPropertyExists("fighterShipID", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                SetPropertyExistsInBaseData("name", exists);
                SetPropertyExists("name", exists);

                _maxFighters = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxFighters", out exists);
                SetPropertyExistsInBaseData("maxFighters", exists);
                SetPropertyExists("maxFighters", exists);
                _launchRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "launchRange", out exists);
                SetPropertyExistsInBaseData("launchRange", exists);
                SetPropertyExists("launchRange", exists);

                _launchSpeedMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "launchSpeedMultiplier", out exists);
                SetPropertyExistsInBaseData("launchSpeedMultiplier", exists);
                SetPropertyExists("launchSpeedMultiplier", exists);

                _bPrimary = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPrimary", out exists);
                SetPropertyExistsInBaseData("bPrimary", exists);
                SetPropertyExists("bPrimary", exists);
                _bRepairHangar = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRepairHangar", out exists);
                SetPropertyExistsInBaseData("bRepairHangar", exists);
                SetPropertyExists("bRepairHangar", exists);
                _bForceSearchAndDestroy = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bForceSearchAndDestroy", out exists);
                SetPropertyExistsInBaseData("bForceSearchAndDestroy", exists);
                SetPropertyExists("bForceSearchAndDestroy", exists);
                _bIndependent = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIndependent", out exists);
                SetPropertyExistsInBaseData("bIndependent", exists);
                SetPropertyExists("bIndependent", exists);
                _bSecondaryFire = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSecondaryFire", out exists);
                SetPropertyExistsInBaseData("bSecondaryFire", exists);
                SetPropertyExists("bSecondaryFire", exists);

                _launchTube = DataStructureParseHelpers.GetlaunchTubeDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("launchTube", exists);
                SetPropertyExists("launchTube", exists);
            }
        }
    }
}
