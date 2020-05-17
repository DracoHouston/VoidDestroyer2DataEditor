﻿using System;
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
                timer1.Stop();
                OgreControl mv = new OgreControl();
                mv.SplashLoadingWindow = true;
                mv.Size = new Size(1, 1);
                Controls.Add(mv);
                step++;
                timer1.Start();
            }
            else if (step == 1)
            {
                timer1.Stop();
                EditorUI.UI.ReloadData();
                step++;
                timer1.Start();
            }
            else if (step >= 2)
            {
                Close();
            }
        }
    }
}
