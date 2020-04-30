using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VoidDestroyer2DataEditor
{
    class ImageSetDB
    {
        public Dictionary<string, ImageSetDocument> Data;

        public ImageSetDB()
        {
            Data = new Dictionary<string, ImageSetDocument>();
        }

        public void LoadData()
        {
            VD2FileSource basesource = EditorUserSettings.UserSettings.GetSourceByShortName("Base");
            VD2FileSource modsource = EditorUserSettings.UserSettings.GetSourceByShortName("Mod");
            if (Directory.Exists(EditorUserSettings.UserSettings.VD2Path + "Mod\\Media\\gui\\imagesets"))
            {
                List<string> files = Directory.EnumerateFiles(EditorUserSettings.UserSettings.VD2Path + "Mod\\Media\\gui\\imagesets").ToList();
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".imageset")
                    {
                        ImageSetDocument imagesetdoc = new ImageSetDocument(Path.GetFileNameWithoutExtension(file), file, modsource);
                        Data.Add("Mod:" + imagesetdoc.ImageSetName, imagesetdoc);
                    }
                }
            }
            if (Directory.Exists(EditorUserSettings.UserSettings.VD2Path + "Media\\gui\\imagesets"))
            {
                List<string> files = Directory.EnumerateFiles(EditorUserSettings.UserSettings.VD2Path + "Media\\gui\\imagesets").ToList();
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".imageset")
                    {
                        ImageSetDocument imagesetdoc = new ImageSetDocument(Path.GetFileNameWithoutExtension(file), file, basesource);
                        Data.Add("Base:" + imagesetdoc.ImageSetName, imagesetdoc);
                    }
                }
            }
            return;
        }

        public void RemoveFile(ImageSetDocument inFileToRemove)
        {
            foreach (KeyValuePair<string, ImageSetDocument> file in Data)
            {
                if (file.Value == inFileToRemove)
                {
                    Data.Remove(file.Key);
                    return;
                }
            }
        }
    }
}
