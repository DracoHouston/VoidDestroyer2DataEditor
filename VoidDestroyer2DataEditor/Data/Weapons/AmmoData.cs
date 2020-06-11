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
    public class AmmoData : VD2Data
    {
        string _objectType;
        string _projectileID;
        string _projectileType;
        string _projectileParticleName;
        string _meshName;
        string _explosionID;
        string _projectileExpireExplosionID;
        string _areaOfEffectID;
        string _instantKillShipClass;
        string _materialNameHead;
        string _materialNameTail;
        string _ribbonID;
        string _dPExpire;

        int _damageOverTime;
        int _damageOverTimeMax;
        int _duration;
        int _maxDuration;
        int _projectileHeadSize;
        int _projectileTailSize;

        float _projectileVelocity;
        float _initialLife;
        float _damage;
        float _weaponPush;
        float _range;

        bool _bShowProjectileExpire;
        bool _bPersistsOnHit;
        bool _bAntiCapital;
        bool _bCrewKiller;
        bool _bIgnoresShields;
        bool _bMining;

        Vector3D _projectileSize;

        canisterDataStructure _canister;

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

        [Description("projectileID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string projectileID
        {
            get
            {
                return _projectileID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _projectileID = value;
                        SetPropertyEdited("projectileID", true);
                    }
                }
            }
        }

        [Description("projectileType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string projectileType
        {
            get
            {
                return _projectileType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _projectileType = value;
                        SetPropertyEdited("projectileType", true);
                    }
                }
            }
        }

        [Description("projectileParticleName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string projectileParticleName
        {
            get
            {
                return _projectileParticleName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _projectileParticleName = value;
                        SetPropertyEdited("projectileParticleName", true);
                    }
                }
            }
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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

        [Description("projectileExpireExplosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string projectileExpireExplosionID
        {
            get
            {
                return _projectileExpireExplosionID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _projectileExpireExplosionID = value;
                        SetPropertyEdited("projectileExpireExplosionID", true);
                    }
                }
            }
        }

        [Description("areaOfEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string areaOfEffectID
        {
            get
            {
                return _areaOfEffectID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _areaOfEffectID = value;
                        SetPropertyEdited("areaOfEffectID", true);
                    }
                }
            }
        }

        [Description("instantKillShipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string instantKillShipClass
        {
            get
            {
                return _instantKillShipClass;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _instantKillShipClass = value;
                        SetPropertyEdited("instantKillShipClass", true);
                    }
                }
            }
        }

        [Description("materialNameHead is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string materialNameHead
        {
            get
            {
                return _materialNameHead;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _materialNameHead = value;
                        SetPropertyEdited("materialNameHead", true);
                    }
                }
            }
        }

        [Description("materialNameTail is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string materialNameTail
        {
            get
            {
                return _materialNameTail;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _materialNameTail = value;
                        SetPropertyEdited("materialNameTail", true);
                    }
                }
            }
        }

        [Description("ribbonID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string ribbonID
        {
            get
            {
                return _ribbonID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _ribbonID = value;
                        SetPropertyEdited("ribbonID", true);
                    }
                }
            }
        }

        [Description("dPExpire is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string dPExpire
        {
            get
            {
                return _dPExpire;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _dPExpire = value;
                        SetPropertyEdited("dPExpire", true);
                    }
                }
            }
        }


        [Description("damageOverTime is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int damageOverTime
        {
            get
            {
                return _damageOverTime;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _damageOverTime = value;
                        SetPropertyEdited("damageOverTime", true);
                    }
                }
            }
        }

        [Description("damageOverTimeMax is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int damageOverTimeMax
        {
            get
            {
                return _damageOverTimeMax;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _damageOverTimeMax = value;
                        SetPropertyEdited("damageOverTimeMax", true);
                    }
                }
            }
        }

        [Description("duration is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int duration
        {
            get
            {
                return _duration;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _duration = value;
                        SetPropertyEdited("duration", true);
                    }
                }
            }
        }

        [Description("maxDuration is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int maxDuration
        {
            get
            {
                return _maxDuration;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _maxDuration = value;
                        SetPropertyEdited("maxDuration", true);
                    }
                }
            }
        }

        [Description("projectileHeadSize is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int projectileHeadSize
        {
            get
            {
                return _projectileHeadSize;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _projectileHeadSize = value;
                        SetPropertyEdited("projectileHeadSize", true);
                    }
                }
            }
        }

        [Description("projectileTailSize is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int projectileTailSize
        {
            get
            {
                return _projectileTailSize;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _projectileTailSize = value;
                        SetPropertyEdited("projectileTailSize", true);
                    }
                }
            }
        }


        [Description("projectileVelocity is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float projectileVelocity
        {
            get
            {
                return _projectileVelocity;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _projectileVelocity = value;
                        SetPropertyEdited("projectileVelocity", true);
                    }
                }
            }
        }

        [Description("initialLife is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float initialLife
        {
            get
            {
                return _initialLife;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _initialLife = value;
                        SetPropertyEdited("initialLife", true);
                    }
                }
            }
        }

        [Description("damage is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float damage
        {
            get
            {
                return _damage;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _damage = value;
                        SetPropertyEdited("damage", true);
                    }
                }
            }
        }

        [Description("weaponPush is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float weaponPush
        {
            get
            {
                return _weaponPush;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _weaponPush = value;
                        SetPropertyEdited("weaponPush", true);
                    }
                }
            }
        }

        [Description("range is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float range
        {
            get
            {
                return _range;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _range = value;
                        SetPropertyEdited("range", true);
                    }
                }
            }
        }


        [Description("bShowProjectileExpire is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bShowProjectileExpire
        {
            get
            {
                return _bShowProjectileExpire;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bShowProjectileExpire = value;
                        SetPropertyEdited("bShowProjectileExpire", true);
                    }
                }
            }
        }

        [Description("bPersistsOnHit is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPersistsOnHit
        {
            get
            {
                return _bPersistsOnHit;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bPersistsOnHit = value;
                        SetPropertyEdited("bPersistsOnHit", true);
                    }
                }
            }
        }

        [Description("bAntiCapital is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAntiCapital
        {
            get
            {
                return _bAntiCapital;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bAntiCapital = value;
                        SetPropertyEdited("bAntiCapital", true);
                    }
                }
            }
        }

        [Description("bCrewKiller is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCrewKiller
        {
            get
            {
                return _bCrewKiller;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCrewKiller = value;
                        SetPropertyEdited("bCrewKiller", true);
                    }
                }
            }
        }

        [Description("bIgnoresShields is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bIgnoresShields
        {
            get
            {
                return _bIgnoresShields;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bIgnoresShields = value;
                        SetPropertyEdited("bIgnoresShields", true);
                    }
                }
            }
        }

        [Description("bMining is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bMining
        {
            get
            {
                return _bMining;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bMining = value;
                        SetPropertyEdited("bMining", true);
                    }
                }
            }
        }


        [Description("projectileSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D projectileSize
        {
            get
            {
                return _projectileSize;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _projectileSize.OnElementChanged -= projectileSize_OnElementChanged;
                        _projectileSize = value;
                        _projectileSize.OnElementChanged += projectileSize_OnElementChanged;
                        SetPropertyEdited("projectileSize", true);
                    }
                }
            }
        }

        private void projectileSize_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("projectileSize", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= projectileSize_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += projectileSize_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= projectileSize_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += projectileSize_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= projectileSize_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += projectileSize_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }


        [Browsable(false), Description("canister is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public canisterDataStructure canister
        {
            get
            {
                return _canister;
            }
            set
            {
                _canister = value;
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("projectileID");
            SetPropertyIsObjectID("projectileID", true);
            InitProperty("projectileType");
            InitProperty("projectileParticleName");
            List<string> projectileParticleNamereftypes = new List<string>();
            projectileParticleNamereftypes.Add("ParticleUniverse");
            SetPropertyIsObjectIDRef("projectileParticleName", true, projectileParticleNamereftypes);
            InitProperty("meshName");
            List<string> meshNamereftypes = new List<string>();
            meshNamereftypes.Add("Mesh");
            SetPropertyIsObjectIDRef("meshName", true, meshNamereftypes);
            InitProperty("explosionID");
            List<string> explosionIDreftypes = new List<string>();
            explosionIDreftypes.Add("Explosion");
            SetPropertyIsObjectIDRef("explosionID", true, explosionIDreftypes);
            InitProperty("projectileExpireExplosionID");
            List<string> projectileExpireExplosionIDreftypes = new List<string>();
            projectileExpireExplosionIDreftypes.Add("Explosion");
            SetPropertyIsObjectIDRef("projectileExpireExplosionID", true, projectileExpireExplosionIDreftypes);
            InitProperty("areaOfEffectID");
            List<string> areaOfEffectIDreftypes = new List<string>();
            areaOfEffectIDreftypes.Add("AreaOfEffect");
            SetPropertyIsObjectIDRef("areaOfEffectID", true, areaOfEffectIDreftypes);
            InitProperty("instantKillShipClass");
            InitProperty("materialNameHead");
            InitProperty("materialNameTail");
            InitProperty("ribbonID");
            List<string> ribbonIDreftypes = new List<string>();
            ribbonIDreftypes.Add("Effect");
            SetPropertyIsObjectIDRef("ribbonID", true, ribbonIDreftypes);
            InitProperty("dPExpire");

            InitProperty("damageOverTime");
            InitProperty("damageOverTimeMax");
            InitProperty("duration");
            InitProperty("maxDuration");
            InitProperty("projectileHeadSize");
            InitProperty("projectileTailSize");

            InitProperty("projectileVelocity");
            InitProperty("initialLife");
            InitProperty("damage");
            InitProperty("weaponPush");
            InitProperty("range");

            InitProperty("bShowProjectileExpire");
            InitProperty("bPersistsOnHit");
            InitProperty("bAntiCapital");
            InitProperty("bCrewKiller");
            InitProperty("bIgnoresShields");
            InitProperty("bMining");

            InitProperty("projectileSize");

            InitProperty("canister");

        }

        public AmmoData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
        }

        public override void LoadDataFromXML()
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _projectileID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("projectileID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("projectileID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(projectileID, "projectileID"));
                }
                SetPropertyExists("projectileID", exists);

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
                _projectileType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("projectileType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("projectileType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "projectileType"));
                }
                SetPropertyExists("projectileType", exists);
                _projectileParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileParticleName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("projectileParticleName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("projectileParticleName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "projectileParticleName"));
                }
                SetPropertyExists("projectileParticleName", exists);
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
                _projectileExpireExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileExpireExplosionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("projectileExpireExplosionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("projectileExpireExplosionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "projectileExpireExplosionID"));
                }
                SetPropertyExists("projectileExpireExplosionID", exists);
                _areaOfEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "areaOfEffectID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("areaOfEffectID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("areaOfEffectID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "areaOfEffectID"));
                }
                SetPropertyExists("areaOfEffectID", exists);
                _instantKillShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "instantKillShipClass", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("instantKillShipClass", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("instantKillShipClass", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "instantKillShipClass"));
                }
                SetPropertyExists("instantKillShipClass", exists);
                _materialNameHead = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialNameHead", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("materialNameHead", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("materialNameHead", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "materialNameHead"));
                }
                SetPropertyExists("materialNameHead", exists);
                _materialNameTail = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialNameTail", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("materialNameTail", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("materialNameTail", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "materialNameTail"));
                }
                SetPropertyExists("materialNameTail", exists);
                _ribbonID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ribbonID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("ribbonID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("ribbonID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "ribbonID"));
                }
                SetPropertyExists("ribbonID", exists);
                _dPExpire = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dPExpire", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dPExpire", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dPExpire", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dPExpire"));
                }
                SetPropertyExists("dPExpire", exists);

                _damageOverTime = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "damageOverTime", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("damageOverTime", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("damageOverTime", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "damageOverTime"));
                }
                SetPropertyExists("damageOverTime", exists);
                _damageOverTimeMax = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "damageOverTimeMax", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("damageOverTimeMax", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("damageOverTimeMax", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "damageOverTimeMax"));
                }
                SetPropertyExists("damageOverTimeMax", exists);
                _duration = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "duration", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("duration", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("duration", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "duration"));
                }
                SetPropertyExists("duration", exists);
                _maxDuration = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxDuration", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("maxDuration", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("maxDuration", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "maxDuration"));
                }
                SetPropertyExists("maxDuration", exists);
                _projectileHeadSize = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "projectileHeadSize", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("projectileHeadSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("projectileHeadSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "projectileHeadSize"));
                }
                SetPropertyExists("projectileHeadSize", exists);
                _projectileTailSize = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "projectileTailSize", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("projectileTailSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("projectileTailSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "projectileTailSize"));
                }
                SetPropertyExists("projectileTailSize", exists);

                _projectileVelocity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "projectileVelocity", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("projectileVelocity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("projectileVelocity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "projectileVelocity"));
                }
                SetPropertyExists("projectileVelocity", exists);
                _initialLife = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialLife", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("initialLife", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("initialLife", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "initialLife"));
                }
                SetPropertyExists("initialLife", exists);
                _damage = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "damage", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("damage", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("damage", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "damage"));
                }
                SetPropertyExists("damage", exists);
                _weaponPush = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "weaponPush", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weaponPush", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weaponPush", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "weaponPush"));
                }
                SetPropertyExists("weaponPush", exists);
                _range = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "range", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("range", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("range", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "range"));
                }
                SetPropertyExists("range", exists);

                _bShowProjectileExpire = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowProjectileExpire", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bShowProjectileExpire", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bShowProjectileExpire", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bShowProjectileExpire"));
                }
                SetPropertyExists("bShowProjectileExpire", exists);
                _bPersistsOnHit = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPersistsOnHit", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bPersistsOnHit", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bPersistsOnHit", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bPersistsOnHit"));
                }
                SetPropertyExists("bPersistsOnHit", exists);
                _bAntiCapital = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAntiCapital", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bAntiCapital", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bAntiCapital", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bAntiCapital"));
                }
                SetPropertyExists("bAntiCapital", exists);
                _bCrewKiller = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCrewKiller", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCrewKiller", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCrewKiller", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCrewKiller"));
                }
                SetPropertyExists("bCrewKiller", exists);
                _bIgnoresShields = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIgnoresShields", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bIgnoresShields", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bIgnoresShields", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bIgnoresShields"));
                }
                SetPropertyExists("bIgnoresShields", exists);
                _bMining = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bMining", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bMining", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bMining", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bMining"));
                }
                SetPropertyExists("bMining", exists);

                _projectileSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "projectileSize", out exists);
                _projectileSize.OnElementChanged += projectileSize_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("projectileSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("projectileSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "projectileSize"));
                }
                SetPropertyExists("projectileSize", exists);

                _canister = DataStructureParseHelpers.GetcanisterDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("canister", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("canister", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "canister"));
                }
                SetPropertyExists("canister", exists);

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
            if (PropertyExists("projectileID"))
            {
                xmltextlines.Add("<projectileID attr1=\"" + _projectileID + "\"/>");
            }
            if (PropertyExists("projectileType"))
            {
                xmltextlines.Add("<projectileType attr1=\"" + _projectileType + "\"/>");
            }
            if (PropertyExists("projectileParticleName"))
            {
                xmltextlines.Add("<projectileParticleName attr1=\"" + _projectileParticleName + "\"/>");
            }
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }
            if (PropertyExists("explosionID"))
            {
                xmltextlines.Add("<explosionID attr1=\"" + _explosionID + "\"/>");
            }
            if (PropertyExists("projectileExpireExplosionID"))
            {
                xmltextlines.Add("<projectileExpireExplosionID attr1=\"" + _projectileExpireExplosionID + "\"/>");
            }
            if (PropertyExists("areaOfEffectID"))
            {
                xmltextlines.Add("<areaOfEffectID attr1=\"" + _areaOfEffectID + "\"/>");
            }
            if (PropertyExists("instantKillShipClass"))
            {
                xmltextlines.Add("<instantKillShipClass attr1=\"" + _instantKillShipClass + "\"/>");
            }
            if (PropertyExists("materialNameHead"))
            {
                xmltextlines.Add("<materialNameHead attr1=\"" + _materialNameHead + "\"/>");
            }
            if (PropertyExists("materialNameTail"))
            {
                xmltextlines.Add("<materialNameTail attr1=\"" + _materialNameTail + "\"/>");
            }
            if (PropertyExists("ribbonID"))
            {
                xmltextlines.Add("<ribbonID attr1=\"" + _ribbonID + "\"/>");
            }
            if (PropertyExists("dPExpire"))
            {
                xmltextlines.Add("<dPExpire attr1=\"" + _dPExpire + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("damageOverTime"))
            {
                xmltextlines.Add("<damageOverTime attr1=\"" + _damageOverTime.ToString() + "\"/>");
            }
            if (PropertyExists("damageOverTimeMax"))
            {
                xmltextlines.Add("<damageOverTimeMax attr1=\"" + _damageOverTimeMax.ToString() + "\"/>");
            }
            if (PropertyExists("duration"))
            {
                xmltextlines.Add("<duration attr1=\"" + _duration.ToString() + "\"/>");
            }
            if (PropertyExists("maxDuration"))
            {
                xmltextlines.Add("<maxDuration attr1=\"" + _maxDuration.ToString() + "\"/>");
            }
            if (PropertyExists("projectileHeadSize"))
            {
                xmltextlines.Add("<projectileHeadSize attr1=\"" + _projectileHeadSize.ToString() + "\"/>");
            }
            if (PropertyExists("projectileTailSize"))
            {
                xmltextlines.Add("<projectileTailSize attr1=\"" + _projectileTailSize.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("projectileVelocity"))
            {
                xmltextlines.Add("<projectileVelocity attr1=\"" + _projectileVelocity.ToString() + "\"/>");
            }
            if (PropertyExists("initialLife"))
            {
                xmltextlines.Add("<initialLife attr1=\"" + _initialLife.ToString() + "\"/>");
            }
            if (PropertyExists("damage"))
            {
                xmltextlines.Add("<damage attr1=\"" + _damage.ToString() + "\"/>");
            }
            if (PropertyExists("weaponPush"))
            {
                xmltextlines.Add("<weaponPush attr1=\"" + _weaponPush.ToString() + "\"/>");
            }
            if (PropertyExists("range"))
            {
                xmltextlines.Add("<range attr1=\"" + _range.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bShowProjectileExpire"))
            {
                xmltextlines.Add("<bShowProjectileExpire attr1=\"" + ((_bShowProjectileExpire) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bPersistsOnHit"))
            {
                xmltextlines.Add("<bPersistsOnHit attr1=\"" + ((_bPersistsOnHit) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bAntiCapital"))
            {
                xmltextlines.Add("<bAntiCapital attr1=\"" + ((_bAntiCapital) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCrewKiller"))
            {
                xmltextlines.Add("<bCrewKiller attr1=\"" + ((_bCrewKiller) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bIgnoresShields"))
            {
                xmltextlines.Add("<bIgnoresShields attr1=\"" + ((_bIgnoresShields) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bMining"))
            {
                xmltextlines.Add("<bMining attr1=\"" + ((_bMining) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("projectileSize"))
            {
                xmltextlines.Add("<projectileSize x=\"" + _projectileSize.x.ToString() + "\" y=\"" + _projectileSize.y.ToString() + "\" z=\"" + _projectileSize.z.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structures...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("canister"))
            {
                xmltextlines.AddRange(_canister.AsVD2XML());
                xmltextlines.Add("");
            }

            SafeWriteAllLines(_FilePath, xmltextlines);
        }
    }
}
