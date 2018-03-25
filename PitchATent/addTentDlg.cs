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
    public partial class AddTentDlg : Form
    {

        // Constructors
        private UserInterface.Tent tent;

        public AddTentDlg(UserInterface.Tent tent)
        {
            this.tent = tent;
            InitializeComponent(this.tent);
        }

        // Properties
        public string TentSize { get; set; }
        public decimal Qty { get; set; }
        public string CoverType { get; set; }
        public string TieDown { get; set; }
        public string Walls { get; set; }
        //TODO: Add custom wall property
        public string Legs { get; set; }
        public string Notes { get; set; }
        public bool Code { get; set; }
        

        private void cb_walls_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Add custom GUI for walls if not too much time
            if(cb_walls.Text == "Custom...")
            {
                MessageBox.Show("Define custom walls...");
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //TODO: Get all values and return
            this.TentSize = cb_size.Text;
            this.Qty = nud_qty.Value;
            this.CoverType = cb_coverType.Text;
            this.TieDown = cb_holddown.Text;
            this.Walls = cb_walls.Text;
            this.Legs = cb_legs.Text;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            //TODO: Prompt user to ask if they're sure they want to cancel
            this.Close();
        }
               
        private void addTentDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
#if DEBUG
            e.Cancel = false;
            this.Code = true;
#else
            // Display a MsgBox asking the user to save changes or abort.
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
#endif
        }
    }
}
