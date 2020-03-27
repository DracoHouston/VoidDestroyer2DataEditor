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
    class LauncherData : VD2Data
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
                _weaponType = value;
                SetPropertyEdited("weaponType", true);
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
                _weaponID = value;
                SetPropertyEdited("weaponID", true);
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
                _ammunitionID = value;
                SetPropertyEdited("ammunitionID", true);
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

        [Description("fireSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string fireSoundID
        {
            get
            {
                return _fireSoundID;
            }
            set
            {
                _fireSoundID = value;
                SetPropertyEdited("fireSoundID", true);
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
                _muzzleFlashEffectID = value;
                SetPropertyEdited("muzzleFlashEffectID", true);
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
                _capacity = value;
                SetPropertyEdited("capacity", true);
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
                _randomLaunchAngle = value;
                SetPropertyEdited("randomLaunchAngle", true);
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
                _randomLaunchSpeed = value;
                SetPropertyEdited("randomLaunchSpeed", true);
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
                _reFireRate = value;
                SetPropertyEdited("reFireRate", true);
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
                _reloadTime = value;
                SetPropertyEdited("reloadTime", true);
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
                _launchVelocity = value;
                SetPropertyEdited("launchVelocity", true);
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
                _bRequiresBeamWeapon = value;
                SetPropertyEdited("bRequiresBeamWeapon", true);
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
                _bNoLifeLimit = value;
                SetPropertyEdited("bNoLifeLimit", true);
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
                _bFireFullAmmo = value;
                SetPropertyEdited("bFireFullAmmo", true);
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
                _bRequiresCollisionWeapon = value;
                SetPropertyEdited("bRequiresCollisionWeapon", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("weaponType");
            InitProperty("weaponID");
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

        public LauncherData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _weaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponType", out exists);
                SetPropertyExistsInBaseData("weaponType", exists);
                SetPropertyExists("weaponType", exists);
                _weaponID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponID", out exists);
                SetPropertyExistsInBaseData("weaponID", exists);
                SetPropertyExists("weaponID", exists);
                _ammunitionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ammunitionID", out exists);
                SetPropertyExistsInBaseData("ammunitionID", exists);
                SetPropertyExists("ammunitionID", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                SetPropertyExistsInBaseData("name", exists);
                SetPropertyExists("name", exists);
                _fireSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "fireSoundID", out exists);
                SetPropertyExistsInBaseData("fireSoundID", exists);
                SetPropertyExists("fireSoundID", exists);
                _muzzleFlashEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "muzzleFlashEffectID", out exists);
                SetPropertyExistsInBaseData("muzzleFlashEffectID", exists);
                SetPropertyExists("muzzleFlashEffectID", exists);

                _capacity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "capacity", out exists);
                SetPropertyExistsInBaseData("capacity", exists);
                SetPropertyExists("capacity", exists);
                _randomLaunchAngle = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "randomLaunchAngle", out exists);
                SetPropertyExistsInBaseData("randomLaunchAngle", exists);
                SetPropertyExists("randomLaunchAngle", exists);
                _randomLaunchSpeed = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "randomLaunchSpeed", out exists);
                SetPropertyExistsInBaseData("randomLaunchSpeed", exists);
                SetPropertyExists("randomLaunchSpeed", exists);

                _reFireRate = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reFireRate", out exists);
                SetPropertyExistsInBaseData("reFireRate", exists);
                SetPropertyExists("reFireRate", exists);
                _reloadTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reloadTime", out exists);
                SetPropertyExistsInBaseData("reloadTime", exists);
                SetPropertyExists("reloadTime", exists);
                _launchVelocity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "launchVelocity", out exists);
                SetPropertyExistsInBaseData("launchVelocity", exists);
                SetPropertyExists("launchVelocity", exists);

                _bRequiresBeamWeapon = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRequiresBeamWeapon", out exists);
                SetPropertyExistsInBaseData("bRequiresBeamWeapon", exists);
                SetPropertyExists("bRequiresBeamWeapon", exists);
                _bNoLifeLimit = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoLifeLimit", out exists);
                SetPropertyExistsInBaseData("bNoLifeLimit", exists);
                SetPropertyExists("bNoLifeLimit", exists);
                _bFireFullAmmo = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFireFullAmmo", out exists);
                SetPropertyExistsInBaseData("bFireFullAmmo", exists);
                SetPropertyExists("bFireFullAmmo", exists);
                _bRequiresCollisionWeapon = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRequiresCollisionWeapon", out exists);
                SetPropertyExistsInBaseData("bRequiresCollisionWeapon", exists);
                SetPropertyExists("bRequiresCollisionWeapon", exists);

            }
        }
    }
}
