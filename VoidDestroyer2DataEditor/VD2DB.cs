using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace VoidDestroyer2DataEditor
{
    class VD2DB<T> where T : VD2Data
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
        public VD2DB(string inFolderName)
        {
            //string SteamPath = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "C:\\Program Files (x86)\\Steam");
            string VD2Path = EditorUserSettings.UserSettings.VD2Path;//SteamPath + "\\steamapps\\common\\Void Destroyer 2";
            //VD2Path = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 369530", "InstallLocation", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Void Destroyer 2");
            DataPath = "\\Data";
            FolderName = inFolderName;
            AdditionalSubfolders = new List<string>();
            Data = new Dictionary<string, T>();
            LoadData(VD2Path + DataPath + "\\" + FolderName);
        }

        //A folder and any number of subfolders containing the same type
        public VD2DB(string inFolderName, List<string> inAdditionalSubfolders)
        {
            //string SteamPath = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "C:\\Program Files (x86)\\Steam");
            string VD2Path = EditorUserSettings.UserSettings.VD2Path;//SteamPath + "\\steamapps\\common\\Void Destroyer 2";
            //VD2Path = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 369530", "InstallLocation", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Void Destroyer 2");
            DataPath = "\\Data";
            FolderName = inFolderName;
            AdditionalSubfolders = inAdditionalSubfolders;
            Data = new Dictionary<string, T>();
            LoadData(VD2Path + DataPath + "\\" + FolderName);

            for (int i = 0; i < AdditionalSubfolders.Count; i++)
            {
                LoadData(VD2Path + DataPath + "\\" + FolderName + "\\" + AdditionalSubfolders[i]);
            }
        }

        public virtual void LoadData(string inPath)
        {
            List<string> datafiles = Directory.EnumerateFiles(inPath).ToList();
            for (int i = 0; i < datafiles.Count; i++)
            {
                if (datafiles[i].EndsWith(".xml"))
                {
                    string dataname = datafiles[i].Substring(inPath.Length + 1, (datafiles[i].Length - inPath.Length) - 5);
                    T currentdata = System.Activator.CreateInstance(typeof(T), datafiles[i]) as T;
                    Data.Add(dataname, currentdata);
                }
            }
        }
    }
}
