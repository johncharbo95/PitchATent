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
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
            dateTime.Value = DateTime.Now;
        }

        private int TentCtr { get; set; }

        private void AddSmallTent_Click(object sender, EventArgs e)
        {
            var tentDialog = new formSmallTent();
            tentDialog.ShowDialog();
            tentDGV.Rows.Add();
            //TODO: Handle combobox errors
            tentDGV.Rows[TentCtr].Cells[0].Value = tentDialog.TentSize.ToString();
            tentDGV.Rows[TentCtr].Cells[1].Value = 69;
            tentDGV.Rows[TentCtr].Cells[2].Value = tentDialog.CoverType.ToString();
            tentDGV.Rows[TentCtr].Cells[3].Value = tentDialog.TieDown.ToString();
            tentDGV.Rows[TentCtr].Cells[4].Value = tentDialog.Walls.ToString();
            tentDGV.Rows[TentCtr].Cells[5].Value = tentDialog.Legs.ToString();
            TentCtr++;
        }

        private void tentDGV_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            anError.Cancel = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This would loop through the group boxes on the left and calculate the sum of everything.");
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This seemed too easy, we might get screwed later?
            PrintDialog print = new PrintDialog();
            print.ShowDialog();
        }

        private void tb_truck_TextChanged(object sender, EventArgs e)
        {
            // TODO: handle all proper events (leave, hit enter...) Ask Eric if he prefers ComboBox
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var about = new AboutBox();
        }
    }
}
