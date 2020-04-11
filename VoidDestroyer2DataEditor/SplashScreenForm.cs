using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    public partial class SplashScreenForm : Form
    {
        int step = 0;
        public SplashScreenForm()
        {
            InitializeComponent();
        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timer1.Start();
                
                //Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (step == 0)
            {
                OgreControl mv = new OgreControl();
                mv.Size = new Size(1, 1);
                Controls.Add(mv);
                step++;
            }
            if (step == 1)
            {
                Close();
            }
        }
    }
}
