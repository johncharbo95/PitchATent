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
    public partial class formSmallTent : Form
    {
        public formSmallTent()
        {
            InitializeComponent();
        }

        public string TentSize { get; set; }
        public int Qty { get; set; }
        public string CoverType { get; set; }
        public string TieDown { get; set; }
        public string Walls { get; set; }
        //TODO: Add custom wall property
        public string Legs { get; set; }
        public string Notes { get; set; }

        private void cb_ST_walls_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Add custom GUI for walls if not too much time
            if(cb_ST_walls.Text == "Custom...")
            {
                MessageBox.Show("Define custom walls...");
            }
        }

        private void btn_ST_add_Click(object sender, EventArgs e)
        {
            //TODO: Get all values and return
            this.TentSize = cb_ST_size.Text;
            //TODO: get quantity somehow?;
            this.CoverType = cb_ST_coverType.Text;
            this.TieDown = cb_ST_holddown.Text;
            this.Walls = cb_ST_walls.Text;
            this.Legs = cb_ST_legs.Text;
            this.Close();
        }

        private void btn_ST_cancel_Click(object sender, EventArgs e)
        {
            //TODO: Prompt user to ask if they're sure they want to cancel
            this.Close();
        }

    }
}
