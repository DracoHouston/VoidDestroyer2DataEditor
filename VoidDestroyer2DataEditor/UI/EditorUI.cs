using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    class EditorUI
    {
        private static EditorUI Instance = null;

        public MainEditorForm EditorForm;

        public EditorModes CurrentEditorMode;

        public static EditorUI UI
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new EditorUI();
                }
                return Instance;
            }
        }

        private EditorUI()
        {
            
        }

        public void InitUI(MainEditorForm inEditorForm)
        {
            EditorForm = inEditorForm;
            CurrentEditorMode = EditorModes.BaseReadOnly;
        }

        public DialogResult GetVD2PathUsingDialog(out string outPath)
        {
            DialogResult result = EditorForm.VD2PathFinderDialog.ShowDialog();
            string pathonly = "";
            if (result == DialogResult.OK)
            {
                pathonly = EditorForm.VD2PathFinderDialog.FileName.Substring(0, EditorForm.VD2PathFinderDialog.FileName.Length - "Void Destroyer 2.exe".Length);                
            }
            outPath = pathonly;
            return result;
        }
    }
}
