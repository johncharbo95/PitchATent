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

        public enum Tent { small, large, frame, clearspan};

        private int TentCtr { get; set; }

        private void AddSmallTent_Click(object sender, EventArgs e)
        {
            openDialog(Tent.small);
        }

        private void btn_tentAddLarge_Click(object sender, EventArgs e)
        {
            openDialog(Tent.large);
        }

        private void tentDGV_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            // Cancel the error
            anError.ThrowException = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            // TODO: Evaluate using a refresh button or automatic refresh
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

        private void btn_addFrame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This doesn't do anything yet");
        }

        private void btn_addClearSpan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This doesn't do anything yet");
        }

        private void openDialog(UserInterface.Tent tent)
        {
            var tentDialog = new addTentDlg(tent);
            tentDialog.ShowDialog();
            //this.tentDGV.Rows.Add();
            if (tentDialog.Code == true)
            {
                this.tentDGV.Rows.Add();
                this.tentDGV.Rows[TentCtr].Cells[0].Value = tentDialog.TentSize;
                this.tentDGV.Rows[TentCtr].Cells[1].Value = tentDialog.Qty.ToString();
                this.tentDGV.Rows[TentCtr].Cells[2].Value = tentDialog.CoverType;
                this.tentDGV.Rows[TentCtr].Cells[3].Value = tentDialog.TieDown;
                this.tentDGV.Rows[TentCtr].Cells[4].Value = tentDialog.Walls;
                this.tentDGV.Rows[TentCtr].Cells[5].Value = tentDialog.Legs;
                TentCtr++;
            }
        }

    }
}
