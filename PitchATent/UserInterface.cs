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

        public enum Tent { small, large, frame, clearspan,none};

        private int TentCtr { get; set; }
        private bool NewAccessory { get; set; } = true;

        private void btn_addSmallTent_Click(object sender, EventArgs e)
        {
            openDialog(Tent.small);
        }

        private void btn_addLargeTent_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Creates a new dialog object and shows it to the user. After making the selections, the values in the main dialog are updated with them.
        /// </summary>
        private void openDialog(UserInterface.Tent tent)
        {
            var tentDialog = new AddTentDlg(tent);
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
                this.tentDGV.Rows[TentCtr].Cells[6].Value = tentDialog.TypeOfTent;
                TentCtr++;
            }
        }

        /// <summary>
        /// On the click of the "Accessories" button, determines if this is the first time adding accessories. 
        /// If it is, the dialog shows 0 values everywhere. If not, it is considered "Edit mode" and shows the existing accessories.
        /// </summary>
        private void btn_AddAcc_Click(object sender, EventArgs e)
        {
            var AccessoryDialog = new AccessoryDlg();
            if (NewAccessory == true)
            {
                AccessoryDialog.AccList.ForEach(i => Console.WriteLine(i.Item + ", " +  i.Qty.ToString()));
                NewAccessory = false;
            }
            else
            {   
                AccessoryDialog.LoadAccessoryList();
                NewAccessory = false;
            }
            AccessoryDialog.ShowDialog();
            if (accDGV.Rows.Count != 0)
            {
                accDGV.Rows.Clear();
            }
            foreach (var n in AccessoryDialog.AccList)
            {
                accDGV.Rows.Add(n.Item, n.Qty.ToString());
            }
        }

        /// <summary>
        /// Allows the user to edit the contents of a specific row from the ContextMenuStrip of the DataGridView.
        /// </summary>
        private void editRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get index of selected row
            int selectedRowIndex = tentDGV.SelectedCells[0].RowIndex;

            // Get the type of tent (enum)
            Tent typeOfTent = (UserInterface.Tent)tentDGV.Rows[selectedRowIndex].Cells[6].Value;

            // Create new object of AddTentDlg class
            var TentDLG = new AddTentDlg(typeOfTent);

            // Set properties of object according to values in selected row
            TentDLG.TentSize = this.tentDGV.Rows[selectedRowIndex].Cells[0].Value.ToString();
            TentDLG.Qty = Convert.ToDecimal(this.tentDGV.Rows[selectedRowIndex].Cells[1].Value);
            TentDLG.CoverType = this.tentDGV.Rows[selectedRowIndex].Cells[2].Value.ToString();
            TentDLG.TieDown = this.tentDGV.Rows[selectedRowIndex].Cells[3].Value.ToString();
            TentDLG.Walls = this.tentDGV.Rows[selectedRowIndex].Cells[4].Value.ToString();
            TentDLG.Legs = this.tentDGV.Rows[selectedRowIndex].Cells[5].Value.ToString();

            // Update the Dialog with these values
            TentDLG.UpdateFields();

            // Show the Dialog
            TentDLG.ShowDialog();

            // Update Main Dialog with new values
            this.tentDGV.Rows[selectedRowIndex].Cells[0].Value = TentDLG.TentSize;
            this.tentDGV.Rows[selectedRowIndex].Cells[1].Value = TentDLG.Qty.ToString();
            this.tentDGV.Rows[selectedRowIndex].Cells[2].Value = TentDLG.CoverType;
            this.tentDGV.Rows[selectedRowIndex].Cells[3].Value = TentDLG.TieDown;
            this.tentDGV.Rows[selectedRowIndex].Cells[4].Value = TentDLG.Walls;
            this.tentDGV.Rows[selectedRowIndex].Cells[5].Value = TentDLG.Legs;
            this.tentDGV.Rows[selectedRowIndex].Cells[6].Value = typeOfTent;
           
            }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowToDelete = tentDGV.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            tentDGV.Rows.RemoveAt(rowToDelete);
            tentDGV.ClearSelection();
        }

        private void tentDGV_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                var hti = tentDGV.HitTest(e.X, e.Y);
                tentDGV.ClearSelection();
                tentDGV.Rows[hti.RowIndex].Selected = true;
            }
        }
    }
}
