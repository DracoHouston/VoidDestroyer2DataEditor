using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    [ToolboxBitmap(typeof(TabControl))]
    public partial class EditorTabControl : TabControl
    {
        public EditorTabControl()
        {
            InitializeComponent();
        }
    }
}
