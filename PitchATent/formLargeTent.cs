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
    public partial class formLargeTent : Form
    {
        public formLargeTent()
        {
            InitializeComponent();
        }

        public string TentSize { get; set; }
        public decimal Qty { get; set; }
        public string CoverType { get; set; }
        public string TieDown { get; set; }
        public string Walls { get; set; }
        //TODO: Add custom wall property
        public string Legs {get; set; }
        public string Notes { get; set; }

        private void cb_LT_walls_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Add custom GUI for walls if not too much time
            if(cb_LT_walls.Text == "Custom...")
            {
                MessageBox.Show("Define custom walls...");
            }
        }

        private void btn_LT_add_Click(object sender, EventArgs e)
        {
            //TODO: Get all values and return
            this.TentSize = cb_LT_size.Text;
            this.Qty = nud_LT_qty.Value;
            this.CoverType = cb_LT_coverType.Text;
            this.TieDown = cb_LT_holddown.Text;
            this.Walls = cb_LT_walls.Text;
            this.Close();
        }

        private void btn_LT_cancel_Click(object sender, EventArgs e)
        {
            //TODO: Prompt user to ask if they're sure they want to cancel
            this.Close();
        }

    }
}
