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

        [Description("weaponType is a plaintext string"), Category("Plaintext Strings")]
        public string weaponType
        {
            get => _weaponType;
            set => _weaponType = value;
        }

        [Description("hangarID is a plaintext string"), Category("Plaintext Strings")]
        public string hangarID
        {
            get => _hangarID;
            set => _hangarID = value;
        }

        [Description("fighterShipID is a plaintext string"), Category("Plaintext Strings")]
        public string fighterShipID
        {
            get => _fighterShipID;
            set => _fighterShipID = value;
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings")]
        public string name
        {
            get => _name;
            set => _name = value;
        }


        [Description("maxFighters is an integer"), Category("Integers")]
        public int maxFighters
        {
            get => _maxFighters;
            set => _maxFighters = value;
        }

        [Description("launchRange is an integer"), Category("Integers")]
        public int launchRange
        {
            get => _launchRange;
            set => _launchRange = value;
        }


        [Description("launchSpeedMultiplier is a real number"), Category("Real Numbers")]
        public float launchSpeedMultiplier
        {
            get => _launchSpeedMultiplier;
            set => _launchSpeedMultiplier = value;
        }


        [Description("bPrimary is a boolean value"), Category("Booleans")]
        public bool bPrimary
        {
            get => _bPrimary;
            set => _bPrimary = value;
        }

        [Description("bRepairHangar is a boolean value"), Category("Booleans")]
        public bool bRepairHangar
        {
            get => _bRepairHangar;
            set => _bRepairHangar = value;
        }

        [Description("bForceSearchAndDestroy is a boolean value"), Category("Booleans")]
        public bool bForceSearchAndDestroy
        {
            get => _bForceSearchAndDestroy;
            set => _bForceSearchAndDestroy = value;
        }

        [Description("bIndependent is a boolean value"), Category("Booleans")]
        public bool bIndependent
        {
            get => _bIndependent;
            set => _bIndependent = value;
        }

        [Description("bSecondaryFire is a boolean value"), Category("Booleans")]
        public bool bSecondaryFire
        {
            get => _bSecondaryFire;
            set => _bSecondaryFire = value;
        }


        [Description("launchTube is a collection of datastructures"), Category("Data Structure Collections")]
        public List<launchTubeDataStructure> launchTube
        {
            get => _launchTube;
            set => _launchTube = value;
        }


        public HangarData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _weaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponType");
                _hangarID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hangarID");
                _fighterShipID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "fighterShipID");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");

                _maxFighters = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxFighters");
                _launchRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "launchRange");

                _launchSpeedMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "launchSpeedMultiplier");

                _bPrimary = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPrimary");
                _bRepairHangar = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRepairHangar");
                _bForceSearchAndDestroy = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bForceSearchAndDestroy");
                _bIndependent = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIndependent");
                _bSecondaryFire = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSecondaryFire");

                _launchTube = DataStructureParseHelpers.GetlaunchTubeDataStructureListFromVD2Data(DataXMLDoc);
            }
        }
    }
}
