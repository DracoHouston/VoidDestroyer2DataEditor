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
    public class StationData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _faction;
        string _stationClass;
        string _stationSizeAsShip;
        string _meshName;
        string _wireframeMaterial;
        string _explosionID;
        string _tacticalExplosionID;
        string _collisionShape;
        string _resourceProduced;
        string _displayName;
        string _shieldID;
        string _collisionMeshName;

        ObservableCollection<string> _descriptionText;
        ObservableCollection<string> _hangarID;

        int _creditCost;
        int _rockSubPosition;
        int _energyUpKeep;
        int _oreUpKeep;
        int _noUpKeepNumber;

        float _health;
        float _buildTimeCost;

        bool _bCommsOverride;
        bool _isMassInfinite;
        bool _bBaseDefenseOverride;
        bool _bFarBuild;
        bool _bBaseBuildOverride;
        bool _bCommonPlatform;
        bool _bLocalBuild;
        bool _bStartGate;
        bool _bEndGate;
        bool _bAccelerator;

        Vector3D _dockingArms;
        Vector3D _dockingArmsEnd;

        debrisInfoDataStructure _debrisInfo;
        refuelAreaDataStructure _refuelArea;
        alwaysOnEffectDataStructure _alwaysOnEffect;
        repairAreaDataStructure _repairArea;

        ObservableCollection<attachmentDataStructure> _attachment;
        ObservableCollection<turretDataStructure> _turret;
        ObservableCollection<physicalRotatingElementDataStructure> _physicalRotatingElement;
        ObservableCollection<mineDataStructure> _mine;

        [Description("objectType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string objectType
        {
            get
            {
                return _objectType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _objectType = value;
                        SetPropertyEdited("objectType", true);
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

        [Description("faction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string faction
        {
            get
            {
                return _faction;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _faction = value;
                        SetPropertyEdited("faction", true);
                    }
                }
            }
        }

        [Description("stationClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string stationClass
        {
            get
            {
                return _stationClass;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _stationClass = value;
                        SetPropertyEdited("stationClass", true);
                    }
                }
            }
        }

        [Description("stationSizeAsShip is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string stationSizeAsShip
        {
            get
            {
                return _stationSizeAsShip;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _stationSizeAsShip = value;
                        SetPropertyEdited("stationSizeAsShip", true);
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

        [Description("wireframeMaterial is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string wireframeMaterial
        {
            get
            {
                return _wireframeMaterial;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _wireframeMaterial = value;
                        SetPropertyEdited("wireframeMaterial", true);
                    }
                }
            }
        }

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string explosionID
        {
            get
            {
                return _explosionID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _explosionID = value;
                        SetPropertyEdited("explosionID", true);
                    }
                }
            }
        }

        [Description("tacticalExplosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string tacticalExplosionID
        {
            get
            {
                return _tacticalExplosionID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _tacticalExplosionID = value;
                        SetPropertyEdited("tacticalExplosionID", true);
                    }
                }
            }
        }

        [Description("collisionShape is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string collisionShape
        {
            get
            {
                return _collisionShape;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _collisionShape = value;
                        SetPropertyEdited("collisionShape", true);
                    }
                }
            }
        }

        [Description("resourceProduced is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string resourceProduced
        {
            get
            {
                return _resourceProduced;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _resourceProduced = value;
                        SetPropertyEdited("resourceProduced", true);
                    }
                }
            }
        }

        [Description("displayName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string displayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _displayName = value;
                        SetPropertyEdited("displayName", true);
                    }
                }
            }
        }

        [Description("shieldID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shieldID
        {
            get
            {
                return _shieldID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shieldID = value;
                        SetPropertyEdited("shieldID", true);
                    }
                }
            }
        }

        [Description("collisionMeshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string collisionMeshName
        {
            get
            {
                return _collisionMeshName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _collisionMeshName = value;
                        SetPropertyEdited("collisionMeshName", true);
                    }
                }
            }
        }


        [Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> descriptionText
        {
            get
            {
                return _descriptionText;
            }
            set
            {
                _descriptionText = value;
            }
        }

        private void OndescriptionTextChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("descriptionText", true);
                }
                else
                {
                    bool exists = false;
                    _descriptionText = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText", out exists));
                    _descriptionText.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OndescriptionTextChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("descriptionText", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("descriptionText", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "descriptionText"));
                    }
                    SetPropertyExists("descriptionText", exists);
                }
            }
        }

        [Description("hangarID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> hangarID
        {
            get
            {
                return _hangarID;
            }
            set
            {
                _hangarID = value;
            }
        }

        private void OnhangarIDChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("hangarID", true);
                }
                else
                {
                    bool exists = false;
                    _hangarID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "hangarID", out exists));
                    _hangarID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnhangarIDChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("hangarID", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("hangarID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "hangarID"));
                    }
                    SetPropertyExists("hangarID", exists);
                }
            }
        }


        [Description("creditCost is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int creditCost
        {
            get
            {
                return _creditCost;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _creditCost = value;
                        SetPropertyEdited("creditCost", true);
                    }
                }
            }
        }

        [Description("rockSubPosition is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rockSubPosition
        {
            get
            {
                return _rockSubPosition;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _rockSubPosition = value;
                        SetPropertyEdited("rockSubPosition", true);
                    }
                }
            }
        }

        [Description("energyUpKeep is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int energyUpKeep
        {
            get
            {
                return _energyUpKeep;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _energyUpKeep = value;
                        SetPropertyEdited("energyUpKeep", true);
                    }
                }
            }
        }

        [Description("oreUpKeep is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int oreUpKeep
        {
            get
            {
                return _oreUpKeep;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _oreUpKeep = value;
                        SetPropertyEdited("oreUpKeep", true);
                    }
                }
            }
        }

        [Description("noUpKeepNumber is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int noUpKeepNumber
        {
            get
            {
                return _noUpKeepNumber;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _noUpKeepNumber = value;
                        SetPropertyEdited("noUpKeepNumber", true);
                    }
                }
            }
        }


        [Description("health is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float health
        {
            get
            {
                return _health;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _health = value;
                        SetPropertyEdited("health", true);
                    }
                }
            }
        }

        [Description("buildTimeCost is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float buildTimeCost
        {
            get
            {
                return _buildTimeCost;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _buildTimeCost = value;
                        SetPropertyEdited("buildTimeCost", true);
                    }
                }
            }
        }


        [Description("bCommsOverride is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCommsOverride
        {
            get
            {
                return _bCommsOverride;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCommsOverride = value;
                        SetPropertyEdited("bCommsOverride", true);
                    }
                }
            }
        }

        [Description("isMassInfinite is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool isMassInfinite
        {
            get
            {
                return _isMassInfinite;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _isMassInfinite = value;
                        SetPropertyEdited("isMassInfinite", true);
                    }
                }
            }
        }

        [Description("bBaseDefenseOverride is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bBaseDefenseOverride
        {
            get
            {
                return _bBaseDefenseOverride;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bBaseDefenseOverride = value;
                        SetPropertyEdited("bBaseDefenseOverride", true);
                    }
                }
            }
        }

        [Description("bFarBuild is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bFarBuild
        {
            get
            {
                return _bFarBuild;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bFarBuild = value;
                        SetPropertyEdited("bFarBuild", true);
                    }
                }
            }
        }

        [Description("bBaseBuildOverride is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bBaseBuildOverride
        {
            get
            {
                return _bBaseBuildOverride;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bBaseBuildOverride = value;
                        SetPropertyEdited("bBaseBuildOverride", true);
                    }
                }
            }
        }

        [Description("bCommonPlatform is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCommonPlatform
        {
            get
            {
                return _bCommonPlatform;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCommonPlatform = value;
                        SetPropertyEdited("bCommonPlatform", true);
                    }
                }
            }
        }

        [Description("bLocalBuild is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bLocalBuild
        {
            get
            {
                return _bLocalBuild;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bLocalBuild = value;
                        SetPropertyEdited("bLocalBuild", true);
                    }
                }
            }
        }

        [Description("bStartGate is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bStartGate
        {
            get
            {
                return _bStartGate;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bStartGate = value;
                        SetPropertyEdited("bStartGate", true);
                    }
                }
            }
        }

        [Description("bEndGate is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bEndGate
        {
            get
            {
                return _bEndGate;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bEndGate = value;
                        SetPropertyEdited("bEndGate", true);
                    }
                }
            }
        }

        [Description("bAccelerator is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAccelerator
        {
            get
            {
                return _bAccelerator;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bAccelerator = value;
                        SetPropertyEdited("bAccelerator", true);
                    }
                }
            }
        }


        [Description("dockingArms is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D dockingArms
        {
            get
            {
                return _dockingArms;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _dockingArms = value;
                        SetPropertyEdited("dockingArms", true);
                    }
                }
            }
        }

        [Description("dockingArmsEnd is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D dockingArmsEnd
        {
            get
            {
                return _dockingArmsEnd;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _dockingArmsEnd = value;
                        SetPropertyEdited("dockingArmsEnd", true);
                    }
                }
            }
        }


        [Description("debrisInfo is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public debrisInfoDataStructure debrisInfo
        {
            get
            {
                return _debrisInfo;
            }
            set
            {
                _debrisInfo = value;
            }
        }

        [Description("refuelArea is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public refuelAreaDataStructure refuelArea
        {
            get
            {
                return _refuelArea;
            }
            set
            {
                _refuelArea = value;
            }
        }

        [Description("alwaysOnEffect is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public alwaysOnEffectDataStructure alwaysOnEffect
        {
            get
            {
                return _alwaysOnEffect;
            }
            set
            {
                _alwaysOnEffect = value;
            }
        }

        [Description("repairArea is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public repairAreaDataStructure repairArea
        {
            get
            {
                return _repairArea;
            }
            set
            {
                _repairArea = value;
            }
        }


        [Description("attachment is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<attachmentDataStructure> attachment
        {
            get
            {
                return _attachment;
            }
            set
            {
                _attachment = value;
            }
        }

        private void OnattachmentChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("attachment", true);
                }
                else
                {
                    bool exists = false;
                    _attachment = new ObservableCollection<attachmentDataStructure>(DataStructureParseHelpers.GetattachmentDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _attachment.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnattachmentChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("attachment", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("attachment", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "attachment"));
                    }
                    SetPropertyExists("attachment", exists);
                }
            }
        }

        [Description("turret is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<turretDataStructure> turret
        {
            get
            {
                return _turret;
            }
            set
            {
                _turret = value;
            }
        }

        private void OnturretChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("turret", true);
                }
                else
                {
                    bool exists = false;
                    _turret = new ObservableCollection<turretDataStructure>(DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _turret.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnturretChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("turret", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("turret", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "turret"));
                    }
                    SetPropertyExists("turret", exists);
                }
            }
        }

        [Description("physicalRotatingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<physicalRotatingElementDataStructure> physicalRotatingElement
        {
            get
            {
                return _physicalRotatingElement;
            }
            set
            {
                _physicalRotatingElement = value;
            }
        }

        private void OnphysicalRotatingElementChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("physicalRotatingElement", true);
                }
                else
                {
                    bool exists = false;
                    _physicalRotatingElement = new ObservableCollection<physicalRotatingElementDataStructure>(DataStructureParseHelpers.GetphysicalRotatingElementDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _physicalRotatingElement.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnphysicalRotatingElementChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("physicalRotatingElement", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("physicalRotatingElement", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "physicalRotatingElement"));
                    }
                    SetPropertyExists("physicalRotatingElement", exists);
                }
            }
        }

        [Description("mine is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<mineDataStructure> mine
        {
            get
            {
                return _mine;
            }
            set
            {
                _mine = value;
            }
        }

        private void OnmineChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("mine", true);
                }
                else
                {
                    bool exists = false;
                    _mine = new ObservableCollection<mineDataStructure>(DataStructureParseHelpers.GetmineDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _mine.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnmineChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("mine", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("mine", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "mine"));
                    }
                    SetPropertyExists("mine", exists);
                }
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("faction");
            InitProperty("stationClass");
            InitProperty("stationSizeAsShip");
            InitProperty("meshName");
            InitProperty("wireframeMaterial");
            InitProperty("explosionID");
            InitProperty("tacticalExplosionID");
            InitProperty("collisionShape");
            InitProperty("resourceProduced");
            InitProperty("displayName");
            InitProperty("shieldID");
            InitProperty("collisionMeshName");

            InitProperty("descriptionText");
            InitProperty("hangarID");

            InitProperty("creditCost");
            InitProperty("rockSubPosition");
            InitProperty("energyUpKeep");
            InitProperty("oreUpKeep");
            InitProperty("noUpKeepNumber");

            InitProperty("health");
            InitProperty("buildTimeCost");

            InitProperty("bCommsOverride");
            InitProperty("isMassInfinite");
            InitProperty("bBaseDefenseOverride");
            InitProperty("bFarBuild");
            InitProperty("bBaseBuildOverride");
            InitProperty("bCommonPlatform");
            InitProperty("bLocalBuild");
            InitProperty("bStartGate");
            InitProperty("bEndGate");
            InitProperty("bAccelerator");

            InitProperty("dockingArms");
            InitProperty("dockingArmsEnd");

            InitProperty("debrisInfo");
            InitProperty("refuelArea");
            InitProperty("alwaysOnEffect");
            InitProperty("repairArea");

            InitProperty("attachment");
            InitProperty("turret");
            InitProperty("physicalRotatingElement");
            InitProperty("mine");
        }

        public StationData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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

                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("objectType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("objectType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "objectType"));
                }
                SetPropertyExists("objectType", exists);
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
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("faction", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("faction", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "faction"));
                }
                SetPropertyExists("faction", exists);
                _stationClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "stationClass", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("stationClass", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("stationClass", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "stationClass"));
                }
                SetPropertyExists("stationClass", exists);
                _stationSizeAsShip = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "stationSizeAsShip", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("stationSizeAsShip", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("stationSizeAsShip", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "stationSizeAsShip"));
                }
                SetPropertyExists("stationSizeAsShip", exists);
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
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("wireframeMaterial", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("wireframeMaterial", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "wireframeMaterial"));
                }
                SetPropertyExists("wireframeMaterial", exists);
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("explosionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("explosionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "explosionID"));
                }
                SetPropertyExists("explosionID", exists);
                _tacticalExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tacticalExplosionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("tacticalExplosionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("tacticalExplosionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "tacticalExplosionID"));
                }
                SetPropertyExists("tacticalExplosionID", exists);
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("collisionShape", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("collisionShape", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "collisionShape"));
                }
                SetPropertyExists("collisionShape", exists);
                _resourceProduced = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "resourceProduced", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("resourceProduced", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("resourceProduced", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "resourceProduced"));
                }
                SetPropertyExists("resourceProduced", exists);
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("displayName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("displayName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "displayName"));
                }
                SetPropertyExists("displayName", exists);
                _shieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shieldID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shieldID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shieldID"));
                }
                SetPropertyExists("shieldID", exists);
                _collisionMeshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionMeshName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("collisionMeshName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("collisionMeshName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "collisionMeshName"));
                }
                SetPropertyExists("collisionMeshName", exists);

                _descriptionText = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText", out exists));
                _descriptionText.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OndescriptionTextChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("descriptionText", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("descriptionText", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "descriptionText"));
                }
                SetPropertyExists("descriptionText", exists);
                _hangarID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "hangarID", out exists));
                _hangarID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnhangarIDChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("hangarID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("hangarID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "hangarID"));
                }
                SetPropertyExists("hangarID", exists);

                _creditCost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "creditCost", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("creditCost", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("creditCost", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "creditCost"));
                }
                SetPropertyExists("creditCost", exists);
                _rockSubPosition = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rockSubPosition", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("rockSubPosition", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("rockSubPosition", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "rockSubPosition"));
                }
                SetPropertyExists("rockSubPosition", exists);
                _energyUpKeep = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "energyUpKeep", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("energyUpKeep", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("energyUpKeep", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "energyUpKeep"));
                }
                SetPropertyExists("energyUpKeep", exists);
                _oreUpKeep = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "oreUpKeep", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("oreUpKeep", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("oreUpKeep", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "oreUpKeep"));
                }
                SetPropertyExists("oreUpKeep", exists);
                _noUpKeepNumber = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "noUpKeepNumber", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("noUpKeepNumber", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("noUpKeepNumber", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "noUpKeepNumber"));
                }
                SetPropertyExists("noUpKeepNumber", exists);

                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("health", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("health", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "health"));
                }
                SetPropertyExists("health", exists);
                _buildTimeCost = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "buildTimeCost", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("buildTimeCost", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("buildTimeCost", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "buildTimeCost"));
                }
                SetPropertyExists("buildTimeCost", exists);

                _bCommsOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommsOverride", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCommsOverride", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCommsOverride", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCommsOverride"));
                }
                SetPropertyExists("bCommsOverride", exists);
                _isMassInfinite = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "isMassInfinite", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("isMassInfinite", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("isMassInfinite", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "isMassInfinite"));
                }
                SetPropertyExists("isMassInfinite", exists);
                _bBaseDefenseOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBaseDefenseOverride", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bBaseDefenseOverride", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bBaseDefenseOverride", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bBaseDefenseOverride"));
                }
                SetPropertyExists("bBaseDefenseOverride", exists);
                _bFarBuild = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFarBuild", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bFarBuild", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bFarBuild", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bFarBuild"));
                }
                SetPropertyExists("bFarBuild", exists);
                _bBaseBuildOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBaseBuildOverride", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bBaseBuildOverride", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bBaseBuildOverride", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bBaseBuildOverride"));
                }
                SetPropertyExists("bBaseBuildOverride", exists);
                _bCommonPlatform = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommonPlatform", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCommonPlatform", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCommonPlatform", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCommonPlatform"));
                }
                SetPropertyExists("bCommonPlatform", exists);
                _bLocalBuild = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLocalBuild", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bLocalBuild", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bLocalBuild", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bLocalBuild"));
                }
                SetPropertyExists("bLocalBuild", exists);
                _bStartGate = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bStartGate", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bStartGate", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bStartGate", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bStartGate"));
                }
                SetPropertyExists("bStartGate", exists);
                _bEndGate = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bEndGate", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bEndGate", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bEndGate", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bEndGate"));
                }
                SetPropertyExists("bEndGate", exists);
                _bAccelerator = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAccelerator", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bAccelerator", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bAccelerator", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bAccelerator"));
                }
                SetPropertyExists("bAccelerator", exists);

                _dockingArms = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArms", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dockingArms", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dockingArms", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dockingArms"));
                }
                SetPropertyExists("dockingArms", exists);
                _dockingArmsEnd = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArmsEnd", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dockingArmsEnd", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dockingArmsEnd", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dockingArmsEnd"));
                }
                SetPropertyExists("dockingArmsEnd", exists);

                _debrisInfo = DataStructureParseHelpers.GetdebrisInfoDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("debrisInfo", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("debrisInfo", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "debrisInfo"));
                }
                SetPropertyExists("debrisInfo", exists);
                _refuelArea = DataStructureParseHelpers.GetrefuelAreaDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("refuelArea", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("refuelArea", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "refuelArea"));
                }
                SetPropertyExists("refuelArea", exists);
                _alwaysOnEffect = DataStructureParseHelpers.GetalwaysOnEffectDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("alwaysOnEffect", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("alwaysOnEffect", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "alwaysOnEffect"));
                }
                SetPropertyExists("alwaysOnEffect", exists);
                _repairArea = DataStructureParseHelpers.GetrepairAreaDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("repairArea", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("repairArea", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "repairArea"));
                }
                SetPropertyExists("repairArea", exists);

                _attachment =  new ObservableCollection<attachmentDataStructure>(DataStructureParseHelpers.GetattachmentDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _attachment.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnattachmentChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("attachment", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("attachment", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "attachment"));
                }
                SetPropertyExists("attachment", exists);
                _turret =  new ObservableCollection<turretDataStructure>(DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _turret.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnturretChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("turret", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("turret", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "turret"));
                }
                SetPropertyExists("turret", exists);
                _physicalRotatingElement =  new ObservableCollection<physicalRotatingElementDataStructure>(DataStructureParseHelpers.GetphysicalRotatingElementDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _physicalRotatingElement.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnphysicalRotatingElementChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("physicalRotatingElement", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("physicalRotatingElement", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "physicalRotatingElement"));
                }
                SetPropertyExists("physicalRotatingElement", exists);
                _mine =  new ObservableCollection<mineDataStructure>(DataStructureParseHelpers.GetmineDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _mine.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnmineChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("mine", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("mine", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "mine"));
                }
                SetPropertyExists("mine", exists);
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
            if (PropertyExists("objectType"))
            {
                xmltextlines.Add("<objectType attr1=\"" + _objectType + "\"/>");
            }
            if (PropertyExists("name"))
            {
                xmltextlines.Add("<name attr1=\"" + _name + "\"/>");
            }
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("faction"))
            {
                xmltextlines.Add("<faction attr1=\"" + _faction + "\"/>");
            }
            if (PropertyExists("stationClass"))
            {
                xmltextlines.Add("<stationClass attr1=\"" + _stationClass + "\"/>");
            }
            if (PropertyExists("stationSizeAsShip"))
            {
                xmltextlines.Add("<stationSizeAsShip attr1=\"" + _stationSizeAsShip + "\"/>");
            }
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }
            if (PropertyExists("wireframeMaterial"))
            {
                xmltextlines.Add("<wireframeMaterial attr1=\"" + _wireframeMaterial + "\"/>");
            }
            if (PropertyExists("explosionID"))
            {
                xmltextlines.Add("<explosionID attr1=\"" + _explosionID + "\"/>");
            }
            if (PropertyExists("tacticalExplosionID"))
            {
                xmltextlines.Add("<tacticalExplosionID attr1=\"" + _tacticalExplosionID + "\"/>");
            }
            if (PropertyExists("collisionShape"))
            {
                xmltextlines.Add("<collisionShape attr1=\"" + _collisionShape + "\"/>");
            }
            if (PropertyExists("resourceProduced"))
            {
                xmltextlines.Add("<resourceProduced attr1=\"" + _resourceProduced + "\"/>");
            }
            if (PropertyExists("displayName"))
            {
                xmltextlines.Add("<displayName attr1=\"" + _displayName + "\"/>");
            }
            if (PropertyExists("shieldID"))
            {
                xmltextlines.Add("<shieldID attr1=\"" + _shieldID + "\"/>");
            }
            if (PropertyExists("collisionMeshName"))
            {
                xmltextlines.Add("<collisionMeshName attr1=\"" + _collisionMeshName + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"String Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("descriptionText"))
            {
                foreach (string result in _descriptionText)
                {
                    xmltextlines.Add("<descriptionText attr1=\"" + result + "\"/>");
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("hangarID"))
            {
                foreach (string result in _hangarID)
                {
                    xmltextlines.Add("<hangarID attr1=\"" + result + "\"/>");
                }
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("creditCost"))
            {
                xmltextlines.Add("<creditCost attr1=\"" + _creditCost.ToString() + "\"/>");
            }
            if (PropertyExists("rockSubPosition"))
            {
                xmltextlines.Add("<rockSubPosition attr1=\"" + _rockSubPosition.ToString() + "\"/>");
            }
            if (PropertyExists("energyUpKeep"))
            {
                xmltextlines.Add("<energyUpKeep attr1=\"" + _energyUpKeep.ToString() + "\"/>");
            }
            if (PropertyExists("oreUpKeep"))
            {
                xmltextlines.Add("<oreUpKeep attr1=\"" + _oreUpKeep.ToString() + "\"/>");
            }
            if (PropertyExists("noUpKeepNumber"))
            {
                xmltextlines.Add("<noUpKeepNumber attr1=\"" + _noUpKeepNumber.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("health"))
            {
                xmltextlines.Add("<health attr1=\"" + _health.ToString() + "\"/>");
            }
            if (PropertyExists("buildTimeCost"))
            {
                xmltextlines.Add("<buildTimeCost attr1=\"" + _buildTimeCost.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bCommsOverride"))
            {
                xmltextlines.Add("<bCommsOverride attr1=\"" + ((_bCommsOverride) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("isMassInfinite"))
            {
                xmltextlines.Add("<isMassInfinite attr1=\"" + ((_isMassInfinite) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bBaseDefenseOverride"))
            {
                xmltextlines.Add("<bBaseDefenseOverride attr1=\"" + ((_bBaseDefenseOverride) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bFarBuild"))
            {
                xmltextlines.Add("<bFarBuild attr1=\"" + ((_bFarBuild) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bBaseBuildOverride"))
            {
                xmltextlines.Add("<bBaseBuildOverride attr1=\"" + ((_bBaseBuildOverride) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCommonPlatform"))
            {
                xmltextlines.Add("<bCommonPlatform attr1=\"" + ((_bCommonPlatform) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bLocalBuild"))
            {
                xmltextlines.Add("<bLocalBuild attr1=\"" + ((_bLocalBuild) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bStartGate"))
            {
                xmltextlines.Add("<bStartGate attr1=\"" + ((_bStartGate) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bEndGate"))
            {
                xmltextlines.Add("<bEndGate attr1=\"" + ((_bEndGate) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bAccelerator"))
            {
                xmltextlines.Add("<bAccelerator attr1=\"" + ((_bAccelerator) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("dockingArms"))
            {
                xmltextlines.Add("<dockingArms x=\"" + _dockingArms.x.ToString() + "\" y=\"" + _dockingArms.y.ToString() + "\" z=\"" + _dockingArms.z.ToString() + "\"/>");
            }
            if (PropertyExists("dockingArmsEnd"))
            {
                xmltextlines.Add("<dockingArmsEnd x=\"" + _dockingArmsEnd.x.ToString() + "\" y=\"" + _dockingArmsEnd.y.ToString() + "\" z=\"" + _dockingArmsEnd.z.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structures...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("debrisInfo"))
            {
                xmltextlines.AddRange(_debrisInfo.AsVD2XML());
                xmltextlines.Add("");
            }
            if (PropertyExists("refuelArea"))
            {
                xmltextlines.AddRange(_refuelArea.AsVD2XML());
                xmltextlines.Add("");
            }
            if (PropertyExists("alwaysOnEffect"))
            {
                xmltextlines.AddRange(_alwaysOnEffect.AsVD2XML());
                xmltextlines.Add("");
            }
            if (PropertyExists("repairArea"))
            {
                xmltextlines.AddRange(_repairArea.AsVD2XML());
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structure Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("attachment"))
            {
                foreach (attachmentDataStructure result in _attachment)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("turret"))
            {
                foreach (turretDataStructure result in _turret)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("physicalRotatingElement"))
            {
                foreach (physicalRotatingElementDataStructure result in _physicalRotatingElement)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("mine"))
            {
                foreach (mineDataStructure result in _mine)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
            ResetAllPropertyEdited();
        }
    }
}
