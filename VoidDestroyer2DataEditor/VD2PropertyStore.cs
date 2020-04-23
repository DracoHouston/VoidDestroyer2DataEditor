using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VoidDestroyer2DataEditor
{
    public class VD2PropertyStore
    {
        protected Dictionary<string, VD2PropertyInfo> VD2PropertyInfos;

        public event EventHandler<VD2PropertyChangedEventArgs> VD2PropertyChanged;

        public VD2PropertyStore()
        {
            VD2PropertyInfos = new Dictionary<string, VD2PropertyInfo>();
            InitAllProperties();
        }

        public virtual void InitAllProperties()
        {

        }

        public void InitProperty(string inName)
        {
            if (!VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfos.Add(inName, new VD2PropertyInfo());
            }
        }

        public virtual void SetPropertyEdited(string inName, bool inEdited)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.EditedByUser = inEdited;
                    
                    if (!info.Exists)
                    {
                        info.Exists = true;
                    }

                    UpdatePropertyInfo(inName, info);
                    VD2PropertyChangedEventArgs e = new VD2PropertyChangedEventArgs();
                    e.PropertyInfo = info;
                    e.PropertyName = inName;
                    e.NewValue = GetType().GetProperty(inName).GetValue(this);
                    EventHandler<VD2PropertyChangedEventArgs> handler = VD2PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, e);
                    }
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

        public void ResetAllPropertyEdited()
        {
            foreach (KeyValuePair<string, VD2PropertyInfo> info in VD2PropertyInfos)
            {
                info.Value.EditedByUser = false;
                System.Reflection.PropertyInfo prop = GetType().GetProperty(info.Key);
                if (prop.PropertyType == typeof(System.Collections.ObjectModel.ObservableCollection<VD2DataStructure>))
                {
                    object o = prop.GetValue(this);
                    System.Collections.ObjectModel.ObservableCollection<VD2DataStructure> val = (System.Collections.ObjectModel.ObservableCollection<VD2DataStructure>)o;
                    if (val != null)
                    {
                        foreach (VD2DataStructure ds in val)
                        {
                            ds.ResetAllPropertyEdited();
                        }
                    }
                }
                if ((prop.PropertyType == typeof(VD2DataStructure)) || (prop.PropertyType.IsSubclassOf(typeof(VD2DataStructure))))
                {
                    VD2DataStructure ds = (VD2DataStructure)prop.GetValue(this);
                    if (ds != null)
                    {
                        ds.ResetAllPropertyEdited();
                    }
                }
            }
            
        }

        [Browsable(false)]
        public bool Unsaved
        {
            get
            {
                List<VD2PropertyInfo> props = VD2PropertyInfos.Values.ToList();
                for (int i = 0; i < props.Count; i++)
                {
                    if (props[i].EditedByUser)
                    {
                        return true;
                    }
                }
                return false;
            }
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

        public void SetPropertyIsObjectID(string inName, bool inIsObjectID)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.IsObjectID = inIsObjectID;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyIsObjectID(string inName)
        {
            bool result = false;
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.IsObjectID;
                }
            }
            return result;
        }

        public void SetPropertyIsObjectIDRef(string inName, bool inIsObjectIDRef, List<string> inRefTypes)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.IsObjectIDRef = inIsObjectIDRef;
                    info.ObjectIDRefTypes = inRefTypes;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyIsObjectIDRef(string inName, out List<string> outRefTypes)
        {
            bool result = false;
            List<string> reftypes = new List<string>();
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.IsObjectIDRef;
                    reftypes.AddRange(info.ObjectIDRefTypes);
                }
            }
            outRefTypes = reftypes;
            return result;
        }

        public void SetPropertyIsCollection(string inName, bool inIsCollection, Type inElementType)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.IsCollection = inIsCollection;
                    info.CollectionElementType = inElementType;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyIsCollection(string inName, out Type outElementType)
        {
            bool result = false;
            Type elementtype = typeof(object);
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.IsCollection;
                    elementtype = info.CollectionElementType;
                }
            }
            outElementType = elementtype;
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
