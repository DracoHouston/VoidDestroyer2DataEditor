using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace VoidDestroyer2DataEditor
{
    public class VD2DB<T> where T : VD2Data
    {

        public string FolderName;
        public List<string> AdditionalSubfolders;
        public string DataPath;
        public string VD2Path;
        public Dictionary<string, T> Data;

        //Load nothing, to load after instantiation 
        public VD2DB()
        {
            FolderName = "";
            DataPath = "";
            VD2Path = "";
            AdditionalSubfolders = new List<string>();
            Data = new Dictionary<string, T>();
        }

        //Just this folder
        /*public VD2DB(string inFolderName)
        {
            //string SteamPath = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "C:\\Program Files (x86)\\Steam");
            string VD2Path = EditorUserSettings.UserSettings.VD2Path;//SteamPath + "\\steamapps\\common\\Void Destroyer 2";
            //VD2Path = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 369530", "InstallLocation", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Void Destroyer 2");
            if ((EditorUI.UI.CurrentEditorMode == EditorModes.BaseReadOnly) || (EditorUI.UI.CurrentEditorMode == EditorModes.BaseReadWrite))
            {
                DataPath = "\\Data";
            }
            else
            {
                DataPath = "\\Mod\\Data";
            }
            FolderName = inFolderName;
            AdditionalSubfolders = new List<string>();
            Data = new Dictionary<string, T>();
            LoadData(VD2Path + DataPath + "\\" + FolderName);
        }*/

        //A folder and any number of subfolders containing the same type
        public VD2DB(string inFolderName, List<string> inAdditionalSubfolders = null)
        {
            //string SteamPath = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "C:\\Program Files (x86)\\Steam");
            string VD2Path = EditorUserSettings.UserSettings.VD2Path;//SteamPath + "\\steamapps\\common\\Void Destroyer 2";
            //VD2Path = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 369530", "InstallLocation", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Void Destroyer 2");
            /*if ((EditorUI.UI.CurrentEditorMode == EditorModes.BaseReadOnly) || (EditorUI.UI.CurrentEditorMode == EditorModes.BaseReadWrite))
            {
                DataPath = "\\Data";
            }
            else
            {
                DataPath = "\\Mod\\Data";
            }*/
            FolderName = inFolderName;
            AdditionalSubfolders = inAdditionalSubfolders;
            Data = new Dictionary<string, T>();          
        }

        public void LoadData()
        {
            for (int sourceidx = 0; sourceidx < EditorUserSettings.UserSettings.Sources.Count; sourceidx++)
            {
                LoadInData(FolderName, EditorUserSettings.UserSettings.Sources[sourceidx]);
                if (AdditionalSubfolders != null)
                {
                    for (int i = 0; i < AdditionalSubfolders.Count; i++)
                    {
                        LoadInData(FolderName + "\\" + AdditionalSubfolders[i], EditorUserSettings.UserSettings.Sources[sourceidx]);
                    }
                }
            }
        }

        private void LoadInData(string inPath, VD2FileSource inSource)
        {
            string fullpath = EditorUserSettings.UserSettings.VD2Path + inSource.Path + "Data\\" + inPath;
            if (Directory.Exists(fullpath))
            {
                List<string> datafiles = Directory.EnumerateFiles(fullpath).ToList();
                for (int i = 0; i < datafiles.Count; i++)
                {
                    if (datafiles[i].EndsWith(".xml"))
                    {
                        string dataname = inSource.ShortName + "\\" + datafiles[i].Substring(fullpath.Length + 1, (datafiles[i].Length - fullpath.Length) - 5);
                        T currentdata = System.Activator.CreateInstance(typeof(T), datafiles[i], inSource) as T;
                        Data.Add(dataname, currentdata);
                    }
                }
            }
        }

        public T LoadSingleFileFromAbsolutePath(string inPath, VD2FileSource inSource)
        {
            if (inPath.EndsWith(".xml"))
            {
                string dataname = inSource.ShortName + "\\" + Path.GetFileNameWithoutExtension(inPath);
                T currentdata = System.Activator.CreateInstance(typeof(T), inPath, inSource) as T;
                Data.Add(dataname, currentdata);
                return currentdata;
            }
            return null;
        }

        public bool DoesPropertyExistInBaseData(string inObjectID, string inPropertyName)
        {
            foreach (T currentdata in Data.Values)
            {
                if (currentdata.GetObjectID() == inObjectID)
                {
                    if (currentdata.Source != null)
                    {
                        if (currentdata.Source.ShortName == "Base")
                        {
                            if (currentdata.PropertyExists(inPropertyName))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void RemoveFile(T inFileToRemove)
        {
            foreach (KeyValuePair<string, T> file in Data)
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
