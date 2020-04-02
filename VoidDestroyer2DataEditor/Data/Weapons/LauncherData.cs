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
    public class LauncherData : VD2Data
    {
        string _weaponType;
        string _weaponID;
        string _ammunitionID;
        string _name;
        string _fireSoundID;
        string _muzzleFlashEffectID;

        int _capacity;
        int _randomLaunchAngle;
        int _randomLaunchSpeed;

        float _reFireRate;
        float _reloadTime;
        float _launchVelocity;

        bool _bRequiresBeamWeapon;
        bool _bNoLifeLimit;
        bool _bFireFullAmmo;
        bool _bRequiresCollisionWeapon;

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

        [Description("weaponID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponID
        {
            get
            {
                return _weaponID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _weaponID = value;
                        SetPropertyEdited("weaponID", true);
                    }
                }
            }
        }

        [Description("ammunitionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ammunitionID
        {
            get
            {
                return _ammunitionID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _ammunitionID = value;
                        SetPropertyEdited("ammunitionID", true);
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

        [Description("fireSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string fireSoundID
        {
            get
            {
                return _fireSoundID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _fireSoundID = value;
                        SetPropertyEdited("fireSoundID", true);
                    }
                }
            }
        }

        [Description("muzzleFlashEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string muzzleFlashEffectID
        {
            get
            {
                return _muzzleFlashEffectID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _muzzleFlashEffectID = value;
                        SetPropertyEdited("muzzleFlashEffectID", true);
                    }
                }
            }
        }


        [Description("capacity is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _capacity = value;
                        SetPropertyEdited("capacity", true);
                    }
                }
            }
        }

        [Description("randomLaunchAngle is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int randomLaunchAngle
        {
            get
            {
                return _randomLaunchAngle;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _randomLaunchAngle = value;
                        SetPropertyEdited("randomLaunchAngle", true);
                    }
                }
            }
        }

        [Description("randomLaunchSpeed is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int randomLaunchSpeed
        {
            get
            {
                return _randomLaunchSpeed;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _randomLaunchSpeed = value;
                        SetPropertyEdited("randomLaunchSpeed", true);
                    }
                }
            }
        }


        [Description("reFireRate is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float reFireRate
        {
            get
            {
                return _reFireRate;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _reFireRate = value;
                        SetPropertyEdited("reFireRate", true);
                    }
                }
            }
        }

        [Description("reloadTime is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float reloadTime
        {
            get
            {
                return _reloadTime;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _reloadTime = value;
                        SetPropertyEdited("reloadTime", true);
                    }
                }
            }
        }

        [Description("launchVelocity is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float launchVelocity
        {
            get
            {
                return _launchVelocity;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _launchVelocity = value;
                        SetPropertyEdited("launchVelocity", true);
                    }
                }
            }
        }


        [Description("bRequiresBeamWeapon is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bRequiresBeamWeapon
        {
            get
            {
                return _bRequiresBeamWeapon;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bRequiresBeamWeapon = value;
                        SetPropertyEdited("bRequiresBeamWeapon", true);
                    }
                }
            }
        }

        [Description("bNoLifeLimit is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoLifeLimit
        {
            get
            {
                return _bNoLifeLimit;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bNoLifeLimit = value;
                        SetPropertyEdited("bNoLifeLimit", true);
                    }
                }
            }
        }

        [Description("bFireFullAmmo is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bFireFullAmmo
        {
            get
            {
                return _bFireFullAmmo;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bFireFullAmmo = value;
                        SetPropertyEdited("bFireFullAmmo", true);
                    }
                }
            }
        }

        [Description("bRequiresCollisionWeapon is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bRequiresCollisionWeapon
        {
            get
            {
                return _bRequiresCollisionWeapon;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bRequiresCollisionWeapon = value;
                        SetPropertyEdited("bRequiresCollisionWeapon", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("weaponType");
            InitProperty("weaponID");
            SetPropertyIsObjectID("weaponID", true);
            InitProperty("ammunitionID");
            InitProperty("name");
            InitProperty("fireSoundID");
            InitProperty("muzzleFlashEffectID");

            InitProperty("capacity");
            InitProperty("randomLaunchAngle");
            InitProperty("randomLaunchSpeed");

            InitProperty("reFireRate");
            InitProperty("reloadTime");
            InitProperty("launchVelocity");

            InitProperty("bRequiresBeamWeapon");
            InitProperty("bNoLifeLimit");
            InitProperty("bFireFullAmmo");
            InitProperty("bRequiresCollisionWeapon");

        }

        public LauncherData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _weaponID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weaponID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weaponID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(weaponID, "weaponID"));
                }
                SetPropertyExists("weaponID", exists);

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
                _ammunitionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ammunitionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("ammunitionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("ammunitionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "ammunitionID"));
                }
                SetPropertyExists("ammunitionID", exists);
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
                _fireSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "fireSoundID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("fireSoundID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("fireSoundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "fireSoundID"));
                }
                SetPropertyExists("fireSoundID", exists);
                _muzzleFlashEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "muzzleFlashEffectID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("muzzleFlashEffectID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("muzzleFlashEffectID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "muzzleFlashEffectID"));
                }
                SetPropertyExists("muzzleFlashEffectID", exists);

                _capacity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "capacity", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("capacity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("capacity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "capacity"));
                }
                SetPropertyExists("capacity", exists);
                _randomLaunchAngle = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "randomLaunchAngle", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("randomLaunchAngle", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("randomLaunchAngle", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "randomLaunchAngle"));
                }
                SetPropertyExists("randomLaunchAngle", exists);
                _randomLaunchSpeed = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "randomLaunchSpeed", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("randomLaunchSpeed", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("randomLaunchSpeed", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "randomLaunchSpeed"));
                }
                SetPropertyExists("randomLaunchSpeed", exists);

                _reFireRate = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reFireRate", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("reFireRate", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("reFireRate", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "reFireRate"));
                }
                SetPropertyExists("reFireRate", exists);
                _reloadTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reloadTime", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("reloadTime", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("reloadTime", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "reloadTime"));
                }
                SetPropertyExists("reloadTime", exists);
                _launchVelocity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "launchVelocity", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("launchVelocity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("launchVelocity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "launchVelocity"));
                }
                SetPropertyExists("launchVelocity", exists);

                _bRequiresBeamWeapon = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRequiresBeamWeapon", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bRequiresBeamWeapon", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bRequiresBeamWeapon", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bRequiresBeamWeapon"));
                }
                SetPropertyExists("bRequiresBeamWeapon", exists);
                _bNoLifeLimit = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoLifeLimit", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bNoLifeLimit", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bNoLifeLimit", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bNoLifeLimit"));
                }
                SetPropertyExists("bNoLifeLimit", exists);
                _bFireFullAmmo = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFireFullAmmo", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bFireFullAmmo", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bFireFullAmmo", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bFireFullAmmo"));
                }
                SetPropertyExists("bFireFullAmmo", exists);
                _bRequiresCollisionWeapon = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRequiresCollisionWeapon", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bRequiresCollisionWeapon", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bRequiresCollisionWeapon", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bRequiresCollisionWeapon"));
                }
                SetPropertyExists("bRequiresCollisionWeapon", exists);

            }
        }
    }
}
