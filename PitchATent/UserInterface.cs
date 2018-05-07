using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace PitchATent
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
            dateTime.Value = DateTime.Now;
        }

        public enum Tent { Small, Large, Frame, ClearSpan};

        private int TentCtr { get; set; }
        private bool NewAccessory { get; set; } = true;

        #region Add Tent Buttons
        private void btn_addSmallTent_Click(object sender, EventArgs e)
        {
            openTentDialog(Tent.Small);
        }

        private void btn_addLargeTent_Click(object sender, EventArgs e)
        {
            openTentDialog(Tent.Large);
        }

        private void btn_addFrame_Click(object sender, EventArgs e)
        {
            openTentDialog(Tent.Frame);
        }

        private void btn_addClearSpan_Click(object sender, EventArgs e)
        {
            openTentDialog(Tent.ClearSpan);
        }
        #endregion

        private void tentDGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Cancel the error
            e.ThrowException = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
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
        
        /// <summary>
        /// Creates a new dialog object and shows it to the user. After making the selections, the values in the main dialog are updated with them.
        /// </summary>
        private void openTentDialog(UserInterface.Tent tent)
        {
            var tentDialog = new AddTentDlg(tent);
            tentDialog.ShowDialog();
            if (tentDialog.Code == true)
            {
                this.tentDGV.Rows.Add();
                this.tentDGV.Rows[TentCtr].Cells[0].Value = tentDialog.TypeOfTent;
                this.tentDGV.Rows[TentCtr].Cells[1].Value = tentDialog.TentSize;
                this.tentDGV.Rows[TentCtr].Cells[2].Value = tentDialog.Qty.ToString();
                this.tentDGV.Rows[TentCtr].Cells[3].Value = tentDialog.CoverType;
                this.tentDGV.Rows[TentCtr].Cells[4].Value = tentDialog.TieDown;
                this.tentDGV.Rows[TentCtr].Cells[5].Value = tentDialog.Walls;
                this.tentDGV.Rows[TentCtr].Cells[6].Value = tentDialog.Legs;
                TentCtr++; 
            }
            UpdateList();
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

        #region Tent DataGridView Context Menu Strip
        /// <summary>
        /// Allows the user to edit the contents of a specific row from the ContextMenuStrip of the DataGridView.
        /// </summary>
        private void editRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get index of selected row
            int selectedRowIndex = tentDGV.SelectedCells[0].RowIndex;

            // Get the type of tent (enum)
            Tent typeOfTent = (UserInterface.Tent)tentDGV.Rows[selectedRowIndex].Cells[0].Value;

            // Create new object of AddTentDlg class
            var TentDLG = new AddTentDlg(typeOfTent);

            // Set properties of object according to values in selected row
            TentDLG.TentSize = this.tentDGV.Rows[selectedRowIndex].Cells[1].Value.ToString();
            TentDLG.Qty = Convert.ToDecimal(this.tentDGV.Rows[selectedRowIndex].Cells[2].Value);
            TentDLG.CoverType = this.tentDGV.Rows[selectedRowIndex].Cells[3].Value.ToString();
            TentDLG.TieDown = this.tentDGV.Rows[selectedRowIndex].Cells[4].Value.ToString();
            TentDLG.Walls = this.tentDGV.Rows[selectedRowIndex].Cells[5].Value.ToString();
            TentDLG.Legs = this.tentDGV.Rows[selectedRowIndex].Cells[6].Value.ToString();

            // Update the Dialog with these values
            TentDLG.UpdateFields();

            // Show the Dialog
            TentDLG.ShowDialog();

            // Update Main Dialog with new values
            this.tentDGV.Rows[selectedRowIndex].Cells[0].Value = TentDLG.TentSize;
            this.tentDGV.Rows[selectedRowIndex].Cells[1].Value = typeOfTent;
            this.tentDGV.Rows[selectedRowIndex].Cells[2].Value = TentDLG.Qty.ToString();
            this.tentDGV.Rows[selectedRowIndex].Cells[3].Value = TentDLG.CoverType;
            this.tentDGV.Rows[selectedRowIndex].Cells[4].Value = TentDLG.TieDown;
            this.tentDGV.Rows[selectedRowIndex].Cells[5].Value = TentDLG.Walls;
            this.tentDGV.Rows[selectedRowIndex].Cells[6].Value = TentDLG.Legs;
            }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in tentDGV.SelectedRows)
            {
                // Remove the row
                tentDGV.Rows.Remove(row);

                // Decrease row count by one
                --TentCtr;
            }

            // Update the list
            UpdateList();

            // Clear selected rows
            tentDGV.ClearSelection();
        }

        private void tentDGV_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Delete)
            {
                Console.WriteLine("Delete key pressed.");
                foreach(DataGridViewRow row in tentDGV.SelectedRows)
                {
                    // Remove the row
                    tentDGV.Rows.Remove(row);

                    // Decrease count
                    --TentCtr;
                }

                // Update the list of items
                UpdateList();

                tentDGV.ClearSelection();                
                e.Handled = true;
            }
        }

        #endregion

        private void UpdateList()
        {

            // Declare lists
            List<Tent> tentTypes = new List<Tent>();
            List<string> tentSizes = new List<string>();
            List<int> tentQties = new List<int>();
            List<string> tentCoverTypes = new List<string>();
            List<string> tentHoldDowns = new List<string>();
            List<string> tentWalls = new List<string>();
            List<string> tentLegs = new List<string>();

            // Loop through tentDGV and store data in lists
            if (tentDGV.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in tentDGV.Rows)
                {
                    tentTypes.Add((Tent)row.Cells[0].Value);
                    tentSizes.Add(row.Cells[1].Value.ToString());
                    tentQties.Add(Convert.ToInt32(row.Cells[2].Value));
                    tentCoverTypes.Add(row.Cells[3].Value.ToString());
                    tentHoldDowns.Add(row.Cells[4].Value.ToString());
                    tentWalls.Add(row.Cells[5].Value.ToString());
                    tentLegs.Add(row.Cells[6].Value.ToString());
                }

                // Create object with the lists and send for processing
                var ListOfLists = new ListNames(tentTypes, tentSizes, tentQties, tentCoverTypes, tentHoldDowns, tentWalls, tentLegs);
                DataHandler handler = new DataHandler();
                var counts = handler.CountTents(ref ListOfLists);
                PopulatePreview(counts);
                
            }
            
        }

        private void PopulatePreview(ItemCounts counts)
        {

            if (this.previewDGV.Rows.Count != 0)
            {
                this.previewDGV.Rows.Clear();
            }

            var metals = counts.Metal;
            var walls = counts.Walls;
            var covers = counts.Covers;
            var tiedowns = counts.TieDowns;

            int i = 0;

            // Loop through all items in covers list
            foreach (var cover in covers)
            {
                this.previewDGV.Rows.Add();
                this.previewDGV.Rows[i].Cells[0].Value = cover.Type;
                this.previewDGV.Rows[i].Cells[1].Value = cover.Qty.ToString();
                i++;
            }

            // Loop through all items in metal list
            foreach (var metal in metals)
            {
                this.previewDGV.Rows.Add();
                this.previewDGV.Rows[i].Cells[0].Value = metal.Type;
                this.previewDGV.Rows[i].Cells[1].Value = metal.Qty.ToString();
                i++;
            }

            // Loop through all items in wall list
            foreach (var wall in walls)
            {
                this.previewDGV.Rows.Add();
                this.previewDGV.Rows[i].Cells[0].Value = wall.Type;
                this.previewDGV.Rows[i].Cells[1].Value = wall.Qty.ToString();
                i++;
            }

            // Loop through all items in tie down list
            foreach (var tiedown in tiedowns)
            {
                this.previewDGV.Rows.Add();
                this.previewDGV.Rows[i].Cells[0].Value = tiedown.Type;
                this.previewDGV.Rows[i].Cells[1].Value = tiedown.Qty.ToString();
                i++;
            }
        }

        
        private void tentDGV_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                var hti = tentDGV.HitTest(e.X, e.Y);
                if (hti.RowIndex != -1)
                {
                    if (tentDGV.SelectedRows.Count < 2)
                    {
                        tentDGV.ClearSelection();
                    }
                    
                    tentDGV.Rows[hti.RowIndex].Selected = true;
                }
                
            }
        }

        private void btn_GeneratePDF_Click(object sender, EventArgs e)
        {
            // Generate the PDF
            Createpdf pdf = new Createpdf();
            // Create a MigraDoc document
            Document document = pdf.CreateDocument();
            document.UseCmykColor = true;

            // Create a renderer for PDF that uses Unicode font encoding
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

            // Set the MigraDoc document
            pdfRenderer.Document = document;

            // Create the PDF document
            pdfRenderer.RenderDocument();

            // Save the PDF document...
            string filename = "Invoice.pdf";

            pdfRenderer.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
    }
}
