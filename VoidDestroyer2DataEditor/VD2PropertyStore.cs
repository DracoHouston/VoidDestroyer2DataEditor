using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidDestroyer2DataEditor
{
    class VD2PropertyStore
    {
        public Dictionary<string, VD2PropertyInfo> VD2PropertyInfos;

        public VD2PropertyStore()
        {
            VD2PropertyInfos = new Dictionary<string, VD2PropertyInfo>();
        }

        public void InitProperty(string inName)
        {
            if (!VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfos.Add(inName, new VD2PropertyInfo());
            }
        }

        public void SetPropertyEdited(string inName, bool inEdited)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.EditedByUser = inEdited;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyEdited(string inName)
        {
            bool result = false;
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.EditedByUser;
                }
            }
            return result;
        }

        public void SetPropertyExists(string inName, bool inExists)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.Exists = inExists;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyExists(string inName)
        {
            bool result = false;
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.Exists;
                }
            }
            return result;
        }

        public void SetPropertyExistsInBaseData(string inName, bool inExistsInBaseData)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.ExistsInBaseData = inExistsInBaseData;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyExistsInBaseData(string inName)
        {
            bool result = false;
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.ExistsInBaseData;
                }
            }
            return result;
        }

        public void UpdatePropertyInfo(string inName, VD2PropertyInfo inInfo)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfos.Remove(inName);
                VD2PropertyInfos.Add(inName, inInfo);
            }
        }
    }
}
