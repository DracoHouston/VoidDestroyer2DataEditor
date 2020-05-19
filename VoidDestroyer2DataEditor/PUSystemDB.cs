using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidDestroyer2DataEditor
{
    class PUSystemDB
    {
        public Dictionary<string, PUDocument> Data;

        public PUSystemDB()
        {
            Data = new Dictionary<string, PUDocument>();
        }

        public void LoadData()
        {
            int systemcount = OgreRenderer.Renderer.EditorRS.GetPUTemplatesCount();
            for (int i = 0; i < systemcount; i++)
            {
                string templatename = OgreRenderer.Renderer.EditorRS.GetPUTemplatesAtIndex(i);
                Data.Add(templatename, new PUDocument(templatename));
            }
        }
    }
}
