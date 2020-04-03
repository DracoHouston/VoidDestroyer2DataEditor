using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor.UI
{
    public partial class ErrorMessageDialog : Form
    {
        string TitleText;
        string MessageText;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Description("The text for the title label"), Category("Appearance")]
        public string ErrorTitleText
        {
            get
            {
                return TitleText;
            }
            set
            {
                TitleText = value;
                label1.Text = TitleText;
            }
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Description("The text for the error message text box"), Category("Appearance")]
        public string ErrorMessageText
        {
            get
            {
                return MessageText;
            }
            set
            {
                MessageText = value;
                textBox1.Text = MessageText;
            }
        }

        public ErrorMessageDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
