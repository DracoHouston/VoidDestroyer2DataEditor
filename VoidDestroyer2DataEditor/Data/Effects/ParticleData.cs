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
    public class ParticleData : VD2Data
    {
        string _objectID;
        string _systemName;

        int _renderDistance;

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

        [Description("systemName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string systemName
        {
            get
            {
                return _systemName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _systemName = value;
                        SetPropertyEdited("systemName", true);
                    }
                }
            }
        }


        [Description("renderDistance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int renderDistance
        {
            get
            {
                return _renderDistance;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _renderDistance = value;
                        SetPropertyEdited("renderDistance", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("systemName");

            InitProperty("renderDistance");

        }

        public ParticleData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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

                _systemName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "systemName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("systemName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("systemName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "systemName"));
                }
                SetPropertyExists("systemName", exists);

                _renderDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "renderDistance", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("renderDistance", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("renderDistance", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "renderDistance"));
                }
                SetPropertyExists("renderDistance", exists);

            }
        }
    }
}
