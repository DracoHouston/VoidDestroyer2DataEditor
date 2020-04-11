using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidDestroyer2DataEditor
{
    public class VD2PropertyChangedEventArgs : EventArgs
    {
        public VD2PropertyInfo PropertyInfo;
        public string PropertyName;
        public object NewValue;
    }
}
