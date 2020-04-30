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
    public class AsteroidData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _meshName;
        string _wireframeMaterial;
        string _tacticalExplosionID;
        string _babyExplosionID;
        string _explosionID;
        string _asteroidSize;
        string _displayName;
        string _asteroidType;

        ObservableCollection<string> _descriptionText;
        ObservableCollection<string> _collisionShape;

        int _babySpawnDamage;

        float _health;

        bool _bShowInTactical;
        bool _isMassInfinite;
        bool _bCanAddViaBattleEditorSlider;

        Vector3D _deathLinearVelocity;

        deathSpawnDataStructure _deathSpawn;

        ObservableCollection<VD2DataStructure> _baby;

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

        [Description("babyExplosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string babyExplosionID
        {
            get
            {
                return _babyExplosionID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _babyExplosionID = value;
                        SetPropertyEdited("babyExplosionID", true);
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

        [Description("asteroidSize is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string asteroidSize
        {
            get
            {
                return _asteroidSize;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _asteroidSize = value;
                        SetPropertyEdited("asteroidSize", true);
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

        [Description("asteroidType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string asteroidType
        {
            get
            {
                return _asteroidType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _asteroidType = value;
                        SetPropertyEdited("asteroidType", true);
                    }
                }
            }
        }


        [Browsable(false), Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> descriptionText
        {
            get
            {
                return _descriptionText;
            }
            set
            {
                if (_descriptionText != null)
                {
                    _descriptionText.CollectionChanged -= OndescriptionTextChanged;
                }
                _descriptionText = value;
                if (_descriptionText != null)
                {
                    _descriptionText.CollectionChanged += OndescriptionTextChanged;
                }
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
                    _descriptionText.CollectionChanged += OndescriptionTextChanged;
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

        [Browsable(false), Description("collisionShape is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> collisionShape
        {
            get
            {
                return _collisionShape;
            }
            set
            {
                if (_collisionShape != null)
                {
                    _collisionShape.CollectionChanged -= OncollisionShapeChanged;
                }
                _collisionShape = value;
                if (_collisionShape != null)
                {
                    _collisionShape.CollectionChanged += OncollisionShapeChanged;
                }
            }
        }

        private void OncollisionShapeChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("collisionShape", true);
                }
                else
                {
                    bool exists = false;
                    _collisionShape = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "collisionShape", out exists));
                    _collisionShape.CollectionChanged += OncollisionShapeChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("collisionShape", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("collisionShape", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "collisionShape"));
                    }
                    SetPropertyExists("collisionShape", exists);
                }
            }
        }


        [Description("babySpawnDamage is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int babySpawnDamage
        {
            get
            {
                return _babySpawnDamage;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _babySpawnDamage = value;
                        SetPropertyEdited("babySpawnDamage", true);
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


        [Description("bShowInTactical is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bShowInTactical
        {
            get
            {
                return _bShowInTactical;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bShowInTactical = value;
                        SetPropertyEdited("bShowInTactical", true);
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

        [Description("bCanAddViaBattleEditorSlider is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCanAddViaBattleEditorSlider
        {
            get
            {
                return _bCanAddViaBattleEditorSlider;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCanAddViaBattleEditorSlider = value;
                        SetPropertyEdited("bCanAddViaBattleEditorSlider", true);
                    }
                }
            }
        }


        [Description("deathLinearVelocity is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D deathLinearVelocity
        {
            get
            {
                return _deathLinearVelocity;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _deathLinearVelocity.OnElementChanged -= deathLinearVelocity_OnElementChanged;
                        _deathLinearVelocity = value;
                        _deathLinearVelocity.OnElementChanged += deathLinearVelocity_OnElementChanged;
                        SetPropertyEdited("deathLinearVelocity", true);
                    }
                }
            }
        }

        private void deathLinearVelocity_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("deathLinearVelocity", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= deathLinearVelocity_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += deathLinearVelocity_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= deathLinearVelocity_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += deathLinearVelocity_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= deathLinearVelocity_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += deathLinearVelocity_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }


        [Browsable(false), Description("deathSpawn is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public deathSpawnDataStructure deathSpawn
        {
            get
            {
                return _deathSpawn;
            }
            set
            {
                _deathSpawn = value;
            }
        }


        [Browsable(false), Description("baby is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<VD2DataStructure> baby
        {
            get
            {
                return _baby;
            }
            set
            {
                if (_baby != null)
                {
                    _baby.CollectionChanged -= OnbabyChanged;
                }
                _baby = value;
                if (_baby != null)
                {
                    _baby.CollectionChanged += OnbabyChanged;
                }
            }
        }

        private void OnbabyChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("baby", true);
                }
                else
                {
                    bool exists = false;
                    _baby = new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetbabyDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _baby.CollectionChanged += OnbabyChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("baby", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("baby", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "baby"));
                    }
                    SetPropertyExists("baby", exists);
                }
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("meshName");
            InitProperty("wireframeMaterial");
            InitProperty("tacticalExplosionID");
            InitProperty("babyExplosionID");
            InitProperty("explosionID");
            InitProperty("asteroidSize");
            InitProperty("displayName");
            InitProperty("asteroidType");

            InitProperty("descriptionText");
            SetPropertyIsCollection("descriptionText", true, typeof(string));
            InitProperty("collisionShape");
            SetPropertyIsCollection("collisionShape", true, typeof(string));

            InitProperty("babySpawnDamage");

            InitProperty("health");

            InitProperty("bShowInTactical");
            InitProperty("isMassInfinite");
            InitProperty("bCanAddViaBattleEditorSlider");

            InitProperty("deathLinearVelocity");

            InitProperty("deathSpawn");

            InitProperty("baby");
            SetPropertyIsCollection("baby", true, typeof(babyDataStructure));
        }

        public AsteroidData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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
                _babyExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "babyExplosionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("babyExplosionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("babyExplosionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "babyExplosionID"));
                }
                SetPropertyExists("babyExplosionID", exists);
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
                _asteroidSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "asteroidSize", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("asteroidSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("asteroidSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "asteroidSize"));
                }
                SetPropertyExists("asteroidSize", exists);
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
                _asteroidType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "asteroidType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("asteroidType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("asteroidType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "asteroidType"));
                }
                SetPropertyExists("asteroidType", exists);

                _descriptionText = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText", out exists));
                _descriptionText.CollectionChanged += OndescriptionTextChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("descriptionText", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("descriptionText", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "descriptionText"));
                }
                SetPropertyExists("descriptionText", exists);
                _collisionShape = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "collisionShape", out exists));
                _collisionShape.CollectionChanged += OncollisionShapeChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("collisionShape", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("collisionShape", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "collisionShape"));
                }
                SetPropertyExists("collisionShape", exists);

                _babySpawnDamage = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "babySpawnDamage", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("babySpawnDamage", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("babySpawnDamage", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "babySpawnDamage"));
                }
                SetPropertyExists("babySpawnDamage", exists);

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

                _bShowInTactical = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInTactical", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bShowInTactical", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bShowInTactical", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bShowInTactical"));
                }
                SetPropertyExists("bShowInTactical", exists);
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
                _bCanAddViaBattleEditorSlider = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanAddViaBattleEditorSlider", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCanAddViaBattleEditorSlider", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCanAddViaBattleEditorSlider", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCanAddViaBattleEditorSlider"));
                }
                SetPropertyExists("bCanAddViaBattleEditorSlider", exists);

                _deathLinearVelocity = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "deathLinearVelocity", out exists);
                _deathLinearVelocity.OnElementChanged += deathLinearVelocity_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("deathLinearVelocity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("deathLinearVelocity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "deathLinearVelocity"));
                }
                SetPropertyExists("deathLinearVelocity", exists);

                _deathSpawn = DataStructureParseHelpers.GetdeathSpawnDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("deathSpawn", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("deathSpawn", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "deathSpawn"));
                }
                SetPropertyExists("deathSpawn", exists);

                _baby =  new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetbabyDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _baby.CollectionChanged += OnbabyChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("baby", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("baby", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "baby"));
                }
                SetPropertyExists("baby", exists);
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
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }
            if (PropertyExists("wireframeMaterial"))
            {
                xmltextlines.Add("<wireframeMaterial attr1=\"" + _wireframeMaterial + "\"/>");
            }
            if (PropertyExists("tacticalExplosionID"))
            {
                xmltextlines.Add("<tacticalExplosionID attr1=\"" + _tacticalExplosionID + "\"/>");
            }
            if (PropertyExists("babyExplosionID"))
            {
                xmltextlines.Add("<babyExplosionID attr1=\"" + _babyExplosionID + "\"/>");
            }
            if (PropertyExists("explosionID"))
            {
                xmltextlines.Add("<explosionID attr1=\"" + _explosionID + "\"/>");
            }
            if (PropertyExists("asteroidSize"))
            {
                xmltextlines.Add("<asteroidSize attr1=\"" + _asteroidSize + "\"/>");
            }
            if (PropertyExists("displayName"))
            {
                xmltextlines.Add("<displayName attr1=\"" + _displayName + "\"/>");
            }
            if (PropertyExists("asteroidType"))
            {
                xmltextlines.Add("<asteroidType attr1=\"" + _asteroidType + "\"/>");
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
            if (PropertyExists("collisionShape"))
            {
                foreach (string result in _collisionShape)
                {
                    xmltextlines.Add("<collisionShape attr1=\"" + result + "\"/>");
                }
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("babySpawnDamage"))
            {
                xmltextlines.Add("<babySpawnDamage attr1=\"" + _babySpawnDamage.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("health"))
            {
                xmltextlines.Add("<health attr1=\"" + _health.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bShowInTactical"))
            {
                xmltextlines.Add("<bShowInTactical attr1=\"" + ((_bShowInTactical) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("isMassInfinite"))
            {
                xmltextlines.Add("<isMassInfinite attr1=\"" + ((_isMassInfinite) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCanAddViaBattleEditorSlider"))
            {
                xmltextlines.Add("<bCanAddViaBattleEditorSlider attr1=\"" + ((_bCanAddViaBattleEditorSlider) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("deathLinearVelocity"))
            {
                xmltextlines.Add("<deathLinearVelocity x=\"" + _deathLinearVelocity.x.ToString() + "\" y=\"" + _deathLinearVelocity.y.ToString() + "\" z=\"" + _deathLinearVelocity.z.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structures...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("deathSpawn"))
            {
                xmltextlines.AddRange(_deathSpawn.AsVD2XML());
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structure Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("baby"))
            {
                foreach (babyDataStructure result in _baby)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
        }
    }
}
