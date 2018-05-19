using System;
using System.IO;
using System.Collections;
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
            InstallDate = DateTime.Now;
            dateTime.Value = InstallDate;
            ResizeRedraw = true;
        }

        public enum Tent { Small, Large, Frame, ClearSpan};

        private int TentCtr { get; set; }
        private bool NewAccessory { get; set; } = true;
        public DateTime InstallDate { get; set; }
        public bool ShowPDF { get; set; } = true;

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
            // Set the ShowPDF property to false to not show the PDF
            ShowPDF = false;

            // Generate the document
            string fname = GenerateReport();
            
            // https://stackoverflow.com/questions/6103705/how-can-i-send-a-file-document-to-the-printer-and-have-it-print?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa

            if (!string.IsNullOrEmpty(fname))
            {
                PrintDialog pdialog = new PrintDialog();

                if (pdialog.ShowDialog() == DialogResult.OK)
                {

                    

                    ProcessStartInfo info = new ProcessStartInfo
                    {
                        Verb = "PrintTo",
                        FileName = fname,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        Arguments = "\"" + pdialog.PrinterSettings.PrinterName + "\"",
                        UseShellExecute = true
                    };

                    Console.WriteLine(fname);

                    Process p = new Process
                    {
                        StartInfo = info
                    };
                    p.Start();

                    p.WaitForExit();
                    
                }
            }
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

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            // Update the property
            InstallDate = dateTime.Value;
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

        private ItemCounts UpdateList()
        {

            // Declare lists
            List<Tent> tentTypes = new List<Tent>();
            List<string> tentSizes = new List<string>();
            List<int> tentQties = new List<int>();
            List<string> tentCoverTypes = new List<string>();
            List<string> tentHoldDowns = new List<string>();
            List<string> tentWalls = new List<string>();
            List<string> tentLegs = new List<string>();

            ItemCounts counts = new ItemCounts();

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
                counts = handler.CountTents(ref ListOfLists); 
                
            }

            if (counts != null)
                PopulatePreview(counts);

            return counts;

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

            if (covers != null)
            {
                metals = metals.OrderBy(o => o.Type).ToList();
                walls = walls.OrderBy(o => o.Type).ToList();
                covers = covers.OrderBy(o => o.Type).ToList();
                tiedowns = tiedowns.OrderBy(o => o.Type).ToList();

                int i = 0;


                // Loop through all items in metal list
                foreach (var metal in metals)
                {
                    this.previewDGV.Rows.Add();
                    this.previewDGV.Rows[i].Cells[0].Value = metal.Type;
                    this.previewDGV.Rows[i].Cells[1].Value = metal.Qty.ToString();
                    i++;
                }

                // Loop through all items in covers list
                foreach (var cover in covers)
                {
                    this.previewDGV.Rows.Add();
                    this.previewDGV.Rows[i].Cells[0].Value = cover.Type;
                    this.previewDGV.Rows[i].Cells[1].Value = cover.Qty.ToString();
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

        private string GenerateReport()
        {
            // Get information about the truck, trailer, driver
            string truck = tb_truck.Text;
            string trailer = tb_trailer.Text;
            string driver = tb_driver.Text;
            string filename = String.Empty;

            // Test for null or empty strings
            if (String.IsNullOrEmpty(truck))
            {
                truck = "not assigned";
            }
            if (String.IsNullOrEmpty(trailer))
            {
                trailer = "not assigned";
            }
            if (String.IsNullOrEmpty(driver))
            {
                driver = "_______________";
            }

            // Get today's date
            string date = InstallDate.ToString("yyyy-MM-dd");

            // Get the My Documents path
            string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Check if output folder already exists
            string OutputPath = @MyDocumentsPath + @"\Truck Loads\";
            Console.WriteLine(OutputPath);
            if (!File.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }

            // Get the final count of items
            ItemCounts counts = UpdateList();

            // If the counts list is null, show a warning to the user and do not generate a PDF
            if (counts.Covers != null)
            {
                // Get items from accessory list
                List<Accessory> AccList = new List<Accessory>();
                int qty = 0;
                string item = "";

                // Call default constructor
                Createpdf pdf = new Createpdf();

                if (accDGV.Rows.Count != 0)
                {
                    foreach (DataGridViewRow row in accDGV.Rows)
                    {
                        item = row.Cells[0].Value.ToString();
                        qty = Convert.ToInt32(row.Cells[1].Value);
                        Accessory acc = new Accessory(item, qty);
                        AccList.Add(acc);
                    }
                    // Generate the PDF
                    pdf = new Createpdf(truck, trailer, driver, counts, AccList);
                }
                else
                {
                    // Generate the PDF
                    pdf = new Createpdf(truck, trailer, driver, counts);
                }

                // Create a MigraDoc document
                Document document = pdf.CreateDocument();
                document.UseCmykColor = true;

                // Create a renderer for PDF that uses Unicode font encoding
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true)
                {

                    // Set the MigraDoc document
                    Document = document
                };

                // Create the PDF document
                pdfRenderer.RenderDocument();

                // Save the PDF document...
                // TODO: Check if file already exists
                filename = string.Format(@"{0}MaterialList_{2}_truck{1}.pdf", OutputPath, truck, date);

                pdfRenderer.Save(filename);

                // ...and start a viewer if desired
                if (ShowPDF == true)
                {
                    Process.Start(filename);
                }
                
            }
            else
            {
                MessageBox.Show("You can not generate a list at this point, because you have no tents listed. Please add tents to this load.",
                    "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                filename = string.Empty;
            }

            return filename;

        }

        private void btn_GeneratePDF_Click(object sender, EventArgs e)
        {
            ShowPDF = true;
            GenerateReport();
        }

        #region ClearButtons
        private void btn_ClearTents_Click(object sender, EventArgs e)
        {
            int tentCount = this.tentDGV.Rows.Count;
            if (tentCount > 0)
            {
                if (MessageBox.Show("Are you sure you want to clear current tents? Your changes will not be saved.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.tentDGV.Rows.Clear();
                    UpdateList();
                    this.previewDGV.Rows.Clear();
                    TentCtr = 0;
                }
            }
        }

        private void btn_ClearAcc_Click(object sender, EventArgs e)
        {
            int accCount = this.accDGV.Rows.Count;
            if (accCount > 0)
            {
                if (MessageBox.Show("Are you sure you want to clear current accessories? Your changes will not be saved.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.accDGV.Rows.Clear();
                    NewAccessory = true;

                }
            }
        }
        #endregion

        #region AddTentDlg ContextMenuStrip
        private void addSmallTentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTentDialog(UserInterface.Tent.Small);
        }

        private void addLargeTentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTentDialog(UserInterface.Tent.Large);
        }

        private void addFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTentDialog(UserInterface.Tent.Frame);
        }

        private void addClearSpanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTentDialog(UserInterface.Tent.ClearSpan);
        }

        private void editRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get index of selected row
            int selectedRowIndex = tentDGV.SelectedCells[0].RowIndex;

            // Get the type of tent (enum)
            Tent typeOfTent = (UserInterface.Tent)tentDGV.Rows[selectedRowIndex].Cells[0].Value;

            // Create new object of AddTentDlg class
            var TentDLG = new AddTentDlg(typeOfTent)
            {

                // Set properties of object according to values in selected row
                TentSize = this.tentDGV.Rows[selectedRowIndex].Cells[1].Value.ToString(),
                Qty = Convert.ToDecimal(this.tentDGV.Rows[selectedRowIndex].Cells[2].Value),
                CoverType = this.tentDGV.Rows[selectedRowIndex].Cells[3].Value.ToString(),
                TieDown = this.tentDGV.Rows[selectedRowIndex].Cells[4].Value.ToString(),
                Walls = this.tentDGV.Rows[selectedRowIndex].Cells[5].Value.ToString(),
                Legs = this.tentDGV.Rows[selectedRowIndex].Cells[6].Value.ToString()
            };

            // Update the Dialog with these values
            TentDLG.UpdateFields();

            // Show the Dialog
            TentDLG.StartPosition = FormStartPosition.Manual;
            TentDLG.Location = new Point(100, 100);

            if (TentDLG.ShowDialog() == DialogResult.OK)
            {
                // Update Main Dialog with new values
                this.tentDGV.Rows[selectedRowIndex].Cells[0].Value = typeOfTent;
                this.tentDGV.Rows[selectedRowIndex].Cells[1].Value = TentDLG.TentSize;
                this.tentDGV.Rows[selectedRowIndex].Cells[2].Value = TentDLG.Qty.ToString();
                this.tentDGV.Rows[selectedRowIndex].Cells[3].Value = TentDLG.CoverType;
                this.tentDGV.Rows[selectedRowIndex].Cells[4].Value = TentDLG.TieDown;
                this.tentDGV.Rows[selectedRowIndex].Cells[5].Value = TentDLG.Walls;
                this.tentDGV.Rows[selectedRowIndex].Cells[6].Value = TentDLG.Legs;

                // Update the list of items
                UpdateList();
            }

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
        #endregion
    }
}
