using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidDestroyer2DataEditor
{
    class EditorUI
    {
        private static EditorUI Instance = null;

        public MainEditorForm EditorForm;
        public static EditorUI UI
        {
            get
            {
                EditorUI result = null;
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
        }
    }
}
