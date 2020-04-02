using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace VoidDestroyer2DataEditor
{
    public class VD2DataStructure : VD2PropertyStore
    {
        public VD2Data ParentDataFile;
        public XmlNode DataNode;

        public VD2DataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base()
        {
            ParentDataFile = inParentDataFile;
            DataNode = inDataNode;
        }
    }
}
