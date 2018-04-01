using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PitchATent
{
    public partial class AddCustomWallsDlg : Form
    {
        private UserInterface.Tent tent;
        public AddCustomWallsDlg(UserInterface.Tent tent)
        {
            this.tent = tent;
            InitializeComponent();
            if (tent == UserInterface.Tent.Frame || tent == UserInterface.Tent.ClearSpan)
            {
                // Disable all Fiesta options
                this.lbl_FPlain.Enabled = false;
                this.lbl_FWindow.Enabled = false;
                this.nud_FPlain.Enabled = false;
                this.nud_FWindow.Enabled = false;

                // Hide all Fiesta options
                this.lbl_FPlain.Visible = false;
                this.lbl_FWindow.Visible = false;
                this.nud_FPlain.Visible = false;
                this.nud_FWindow.Visible = false;

                // Move buttons up and resize Form
                this.btn_AllToZero.Location = new System.Drawing.Point(13, 82);
                this.btn_Done.Location = new System.Drawing.Point(129, 82);
                this.btn_Cancel.Location = new System.Drawing.Point(204, 82);
                this.ClientSize = new System.Drawing.Size(284, 119);
            }
        }
        public class CustomWalls
        {
            // Constructors
            public CustomWalls(string Type, int Qty)
            {
                this.Type = Type;
                this.Qty = Qty;
            }

            public string Type { get; set; }
            public int Qty { get; set; }

        }

        public bool Code { get; set; } = false;
        public List<CustomWalls> WallList = new List<CustomWalls>();

        private int _Plain = 0;
        public int Plain
        {
            get
            {
                return _Plain;
            }
            set
            {
                _Plain = value;
                CheckList("Plain", _Plain);
            }
        }

        private int _FPlain = 0;
        public int FPlain
        {
            get
            {
                return _FPlain;
            }
            set
            {
                _FPlain = value;
                CheckList("Plain Fiesta", _FPlain);
            }
        }

        private int _Window = 0;
        public int Window
        {
            get
            {
                return _Window;
            }
            set
            {
                _Window = value;
                CheckList("Window", _Window);
            }
        }

        private int _FWindow = 0;
        public int FWindow
        {
            get
            {
                return _FWindow;
            }
            set
            {
                _FWindow = value;
                CheckList("Window Fiesta", _FWindow);
            }
        }

        public void CheckList(string type, int qty)
        {
            if (!WallList.Any(w => w.Type == type) && qty != 0)
            {
                WallList.Add(new CustomWalls(type, qty));
            }
            else if (qty == 0 && WallList.Any(w => w.Type == type))
            {
                WallList.RemoveAll(w => w.Type == type);
            }
        }

        private void btn_AllToZero_Click(object sender, EventArgs e)
        {
            nud_Plain.Value = 0;
            nud_Window.Value = 0;
            nud_FPlain.Value = 0;
            nud_FWindow.Value = 0;
        }
        #region Buttons
        private void btn_Done_Click(object sender, EventArgs e)
        {
            //UpdateProperties();
            this.Plain = Convert.ToInt32(nud_Plain.Value);
            this.FPlain = Convert.ToInt32(nud_FPlain.Value);
            this.Window = Convert.ToInt32(nud_Window.Value);
            this.FWindow = Convert.ToInt32(nud_FWindow.Value);
            this.Code = true;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Code = false;
            this.Close();
        }
        #endregion

        private void addTentDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
#if DEBUG
            e.Cancel = false;
            this.Code = true;
#else
            // Display a MsgBox asking the user to save changes or abort.
            if (this.Code == false)
            {
                if (MessageBox.Show("Are you sure?", this.Text,
               MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    // Cancel the Closing event from closing the form.
                    this.Code = false;
                    e.Cancel = false;
                    // Call method to save file...
                }
                else
                {
                    this.Code = true;
                    e.Cancel = true;
                }
            }

#endif
        }
    }
}
