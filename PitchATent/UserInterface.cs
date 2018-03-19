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

        private void AddTent_Click(object sender, EventArgs e)
        {
            tentDGV.Rows.Add();
            MessageBox.Show(this.tentDGV.Rows[0].Cells[2].Value.ToString());
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
    }
}
