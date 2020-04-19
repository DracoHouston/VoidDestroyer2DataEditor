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
    public partial class DocumentTabControl : TabControl
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private Dictionary<Button, TabPage> DocumentButtons = new Dictionary<Button, TabPage>();

        private bool _ShowCloseButtons = true;
        private Image _CloseButtonImage;

        public event CancelEventHandler CloseClick;

        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Show / Hide Close Button(s)")]
        public bool ShowCloseButtons
        {
            get
            {
                return _ShowCloseButtons;
            }
            set
            {
                _ShowCloseButtons = value;

                foreach (var btn in DocumentButtons.Keys)
                {
                    btn.Visible = _ShowCloseButtons;
                }
                Repos();
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Appearance")]
        [Description("Close Image")]
        public Image CloseButtonImage
        {
            get
            {
                return _CloseButtonImage;
            }

            set
            {
                _CloseButtonImage = value;
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Repos();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (!Visible)
            {
                Visible = true;
            }
            TabPage tpCurrent = (TabPage)e.Control;
            Rectangle rtCurrent = this.GetTabRect(this.TabPages.IndexOf(tpCurrent));

            Button btnClose = new Button();

            btnClose.Image = Properties.Resources.DocumentCloseButton;
            btnClose.ImageAlign = ContentAlignment.MiddleRight;
            btnClose.TextAlign = ContentAlignment.MiddleLeft;

            btnClose.Size = new Size(rtCurrent.Height - 1,
               rtCurrent.Height - 1);
            btnClose.Location = new Point(rtCurrent.X + rtCurrent.Width -
               rtCurrent.Height - 1, rtCurrent.Y + 1);

            SetParent(btnClose.Handle, this.Handle);

            btnClose.Click += OnCloseClick;

            DocumentButtons.Add(btnClose, tpCurrent);
            
            //tpCurrent.
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            Button btn = CloseButton((TabPage)e.Control);
            btn.Dispose();
            Repos();
            if (TabPages.Count == 0)
            {
                Visible = false;
            }
        }

        protected override void OnLayout(LayoutEventArgs lea)
        {
            base.OnLayout(lea);
            Repos();
        }

        protected virtual void OnCloseClick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Button btnClose = (Button)sender;
                TabPage tpCurrent = DocumentButtons[btnClose];

                CancelEventArgs cea = new CancelEventArgs();

                CloseClick?.Invoke(sender, cea);

                if (!cea.Cancel)
                {
                    TabPages.Remove(tpCurrent);

                    btnClose.Dispose();
                    Repos();
                    if (TabPages.Count == 0)
                    {
                        Visible = false;
                    }                    
                }
            }
        }

        public void Repos()
        {
            foreach (var but in DocumentButtons)
            {
                Repos(but.Value);
            }
        }

        public void Repos(TabPage tpCurrent)
        {
            Button btnClose = CloseButton(tpCurrent);

            if (btnClose != null)
            {
                int tpIndex = TabPages.IndexOf(tpCurrent);
                if (tpIndex >= 0)
                {
                    Rectangle rctCurrent = GetTabRect(tpIndex);

                    if (SelectedTab == tpCurrent)
                    {
                        btnClose.Size = new Size(rctCurrent.Height - 1, rctCurrent.Height - 1);
                        btnClose.Location = new Point(rctCurrent.X + rctCurrent.Width - rctCurrent.Height, rctCurrent.Y + 1);
                    }
                    else
                    {
                        btnClose.Size = new Size(rctCurrent.Height - 3, rctCurrent.Height - 2);
                        btnClose.Location = new Point(rctCurrent.X + rctCurrent.Width - rctCurrent.Height - 1, rctCurrent.Y + 1);
                    }

                    btnClose.Visible = ShowCloseButtons;
                    btnClose.BringToFront();
                }

            }

        }

        protected Button CloseButton(TabPage tpCurrent)
        {
            return (from item in DocumentButtons where item.Value == tpCurrent select item.Key).FirstOrDefault();
        }

        public DocumentTabControl()
        {
            InitializeComponent();
        }

        public event ScrollEventHandler HScroll;
        private int oldValue = 0;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x114) // WM_HSCROLL
            {
                this.OnHScroll(new ScrollEventArgs(((ScrollEventType)LoWord(m.WParam)), oldValue, HiWord(m.WParam), ScrollOrientation.HorizontalScroll));
            }
        }

        protected void OnHScroll(ScrollEventArgs sev)
        {
            if (this.HScroll != null)
            {
                this.HScroll(this, sev);
            }

            if (sev.Type == ScrollEventType.EndScroll)
            {
                this.oldValue = sev.NewValue;
            }

            Repos();
        }

        private int LoWord(IntPtr dWord)
        {
            return dWord.ToInt32() & 0xffff;
        }

        private int HiWord(IntPtr dWord)
        {
            if ((dWord.ToInt32() & 0x80000000) == 0x80000000)
            {
                return (dWord.ToInt32() >> 16);
            }
            else
            {
                return (dWord.ToInt32() >> 16) & 0xffff;
            }
        }
    }
}
