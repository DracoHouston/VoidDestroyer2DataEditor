using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VoidDestroyer2DataEditor
{
    class MeshDB
    {
        public Dictionary<string, MeshDocument> Data;

        public MeshDB()
        {
            Data = new Dictionary<string, MeshDocument>();
        }

        public void LoadData()
        {
            VD2FileSource basesource = EditorUserSettings.UserSettings.GetSourceByShortName("Base");
            VD2FileSource modsource = EditorUserSettings.UserSettings.GetSourceByShortName("Mod");
            if (modsource != null)
            {
                if (Directory.Exists(EditorUserSettings.UserSettings.VD2Path + "Mod\\Media\\models"))
                {
                    List<string> folders = Directory.EnumerateDirectories(EditorUserSettings.UserSettings.VD2Path + "Mod\\Media\\models").ToList();
                    foreach (string folder in folders)
                    {
                        List<string> files = Directory.EnumerateFiles(folder).ToList();
                        foreach (string file in files)
                        {
                            if (Path.GetExtension(file) == ".mesh")
                            {
                                MeshDocument meshdoc = new MeshDocument();
                                meshdoc.MeshName = Path.GetFileName(file);
                                meshdoc.FilePath = file;
                                meshdoc.Source = modsource;
                                if (!Data.ContainsKey("Mod:" + Path.GetFileNameWithoutExtension(file)))
                                {
                                    Data.Add("Mod:" + Path.GetFileNameWithoutExtension(file), meshdoc);
                                }
                            }
                        }
                    }
                }
            }
            if (basesource != null)
            {
                if (Directory.Exists(EditorUserSettings.UserSettings.VD2Path + "Media\\models"))
                {
                    List<string> folders = Directory.EnumerateDirectories(EditorUserSettings.UserSettings.VD2Path + "Media\\models").ToList();
                    foreach (string folder in folders)
                    {
                        List<string> files = Directory.EnumerateFiles(folder).ToList();
                        foreach (string file in files)
                        {
                            if (Path.GetExtension(file) == ".mesh")
                            {
                                MeshDocument meshdoc = new MeshDocument();
                                meshdoc.MeshName = Path.GetFileName(file);
                                meshdoc.FilePath = file;
                                meshdoc.Source = basesource;
                                if (!Data.ContainsKey("Base:" + Path.GetFileNameWithoutExtension(file)))
                                {
                                    Data.Add("Base:" + Path.GetFileNameWithoutExtension(file), meshdoc);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void RemoveFile(MeshDocument inFileToRemove)
        {
            foreach (KeyValuePair<string, MeshDocument> file in Data)
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
