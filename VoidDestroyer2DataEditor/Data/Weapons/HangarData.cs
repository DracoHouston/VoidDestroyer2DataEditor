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
    public class HangarData : VD2Data
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

        ObservableCollection<launchTubeDataStructure> _launchTube;

        [Description("weaponType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponType
        {
            get
            {
                return _weaponType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _weaponType = value;
                        SetPropertyEdited("weaponType", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _hangarID = value;
                        SetPropertyEdited("hangarID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _fighterShipID = value;
                        SetPropertyEdited("fighterShipID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _name = value;
                        SetPropertyEdited("name", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _maxFighters = value;
                        SetPropertyEdited("maxFighters", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _launchRange = value;
                        SetPropertyEdited("launchRange", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _launchSpeedMultiplier = value;
                        SetPropertyEdited("launchSpeedMultiplier", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bPrimary = value;
                        SetPropertyEdited("bPrimary", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bRepairHangar = value;
                        SetPropertyEdited("bRepairHangar", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bForceSearchAndDestroy = value;
                        SetPropertyEdited("bForceSearchAndDestroy", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bIndependent = value;
                        SetPropertyEdited("bIndependent", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bSecondaryFire = value;
                        SetPropertyEdited("bSecondaryFire", true);
                    }
                }
            }
        }


        [Description("launchTube is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<launchTubeDataStructure> launchTube
        {
            get
            {
                return _launchTube;
            }
            set
            {
                _launchTube = value;
            }
        }

        private void OnlaunchTubeChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("launchTube", true);
                }
                else
                {
                    bool exists = false;
                    _launchTube = new ObservableCollection<launchTubeDataStructure>(DataStructureParseHelpers.GetlaunchTubeDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _launchTube.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnlaunchTubeChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("launchTube", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("launchTube", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "launchTube"));
                    }
                    SetPropertyExists("launchTube", exists);
                }
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("weaponType");
            InitProperty("hangarID");
            SetPropertyIsObjectID("hangarID", true);
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

        public HangarData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _hangarID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hangarID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("hangarID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("hangarID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(hangarID, "hangarID"));
                }
                SetPropertyExists("hangarID", exists);

                _weaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weaponType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weaponType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "weaponType"));
                }
                SetPropertyExists("weaponType", exists);
                _fighterShipID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "fighterShipID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("fighterShipID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("fighterShipID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "fighterShipID"));
                }
                SetPropertyExists("fighterShipID", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("name", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("name", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "name"));
                }
                SetPropertyExists("name", exists);

                _maxFighters = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxFighters", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("maxFighters", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("maxFighters", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "maxFighters"));
                }
                SetPropertyExists("maxFighters", exists);
                _launchRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "launchRange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("launchRange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("launchRange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "launchRange"));
                }
                SetPropertyExists("launchRange", exists);

                _launchSpeedMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "launchSpeedMultiplier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("launchSpeedMultiplier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("launchSpeedMultiplier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "launchSpeedMultiplier"));
                }
                SetPropertyExists("launchSpeedMultiplier", exists);

                _bPrimary = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPrimary", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bPrimary", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bPrimary", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bPrimary"));
                }
                SetPropertyExists("bPrimary", exists);
                _bRepairHangar = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRepairHangar", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bRepairHangar", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bRepairHangar", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bRepairHangar"));
                }
                SetPropertyExists("bRepairHangar", exists);
                _bForceSearchAndDestroy = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bForceSearchAndDestroy", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bForceSearchAndDestroy", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bForceSearchAndDestroy", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bForceSearchAndDestroy"));
                }
                SetPropertyExists("bForceSearchAndDestroy", exists);
                _bIndependent = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIndependent", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bIndependent", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bIndependent", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bIndependent"));
                }
                SetPropertyExists("bIndependent", exists);
                _bSecondaryFire = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSecondaryFire", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bSecondaryFire", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bSecondaryFire", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bSecondaryFire"));
                }
                SetPropertyExists("bSecondaryFire", exists);

                _launchTube =  new ObservableCollection<launchTubeDataStructure>(DataStructureParseHelpers.GetlaunchTubeDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _launchTube.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnlaunchTubeChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("launchTube", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("launchTube", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "launchTube"));
                }
                SetPropertyExists("launchTube", exists);
            }
        }
    }
}
