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
            InitializeComponent();

            switch (tent)
            {
                case UserInterface.Tent.Large:
                    this.Text = "Add Large Tent";
                    this.cb_size.Items.AddRange(new object[] {
                    "40x40",
                    "40x60",
                    "40x80",
                    "40x100",
                    "40x120",
                    "40x140",
                    "40x160",
                    "40x180",
                    "40x200",
                    "40x220",
                    "40x240",
                    "40x260",
                    "40x280",
                    "40x300",
                    "60x40",
                    "60x60",
                    "60x70",
                    "60x80",
                    "60x90",
                    "60x100",
                    "60x110",
                    "60x120",
                    "60x130",
                    "60x140",
                    "60x150",
                    "60x160",
                    "60x170",
                    "60x180",
                    "60x190",
                    "60x200",
                    "60x210",
                    "60x220",
                    "60x230",
                    "60x240",
                    "60x250",
                    "90x60",
                    "90x90",
                    "90x120",
                    "90x150",
                    "90x180",
                    "90x210",
                    "90x240",
                    "90x270",
                    "90x300"});
                    this.cb_size.SelectedIndex = 0;
                    this.cb_holddown.Items.AddRange(new object[] {
                    "Pins",
                    "1 ton Concrete Block"});
                    this.cb_holddown.SelectedIndex = 0;
                    this.cb_coverType.Enabled = false;
                    // No cover types
                    //this.cb_coverType.Items.AddRange(new object[] {
                    //"Regular",
                    //"New",
                    //"Old",
                    //"Barbecue",
                    //"Soft"});
                    //this.cb_coverType.SelectedIndex = 0;
                    this.cb_walls.Items.AddRange(new object[] {
                    "Full Plain",
                    "Full Window",
                    "Half Plain Half Window",
                    "Full Plain Fiesta",
                    "Full Window Fiesta",
                    "Half Plain Half Window Fiesta",
                    "None"});
                    this.cb_walls.SelectedIndex = 0;
                    break;
                case UserInterface.Tent.Small:
                    this.Text = "Add Small Tent";
                    this.cb_size.Items.AddRange(new object[] {
                    "10x10",
                    "10x15",
                    "10x20",
                    "15x15",
                    "20x20",
                    "20x30",
                    "20x40",
                    "30x30",
                    "Hexagon",
                    ""});
                    this.cb_size.SelectedIndex = 0;
                    // TODO: Give option to choose which type of blocks to bring
                    this.cb_holddown.Items.AddRange(new object[] {
                    "Pins",
                    "Water Barrels",
                    "250 lb Concrete Block",
                    "400 lb Concrete Block",
                    "600 lb Concrete Block",
                    "1/2 ton Concrete Block",
                    "1 ton Concrete Block"});
                    this.cb_holddown.SelectedIndex = 0;
                    this.cb_coverType.Items.AddRange(new object[] {
                    "Regular",
                    "New",
                    "Old",
                    "Barbecue",
                    "Soft",
                    "Number 1",
                    "Number 2",
                    "Number 3",
                    "Number 4",
                    "Number 5",
                    "Number 6",
                    "Number 7",
                    "Number 8",});
                    this.cb_coverType.SelectedIndex = 0;
                    // No 8x10 Window walls
                    this.cb_walls.Items.AddRange(new object[] {
                    "Full Plain",
                    "Full Window",
                    "Half Plain Half Window",
                    "Full Plain Fiesta",
                    "Full Window Fiesta",
                    "Half Plain Half Window Fiesta",
                    "None"});
                    this.cb_walls.SelectedIndex = 0;
                    // TODO: Can't have 10 foot fiesta walls (if 10 ft legs is selected)
                    this.cb_legs.Items.AddRange(new object[] {
                    "8 ft",
                    "8 ft Adjustable",
                    "10 ft",
                    "10 ft Adjustable",
                    "Hexagon"});
                    this.cb_legs.SelectedIndex = 0;
                    break;
                case UserInterface.Tent.Frame:
                    this.Text = "Add Frame";
                    this.cb_size.Items.AddRange(new object[] {
                    "30x30",
                        "30x40",
                        "30x45",
                        "30x50",
                        "30x55",
                        "30x60",
                        "30x65",
                        "30x70",
                        "30x75",
                        "30x80",
                        "30x85",
                        "30x90",
                        "30x95",
                        "30x100",
                        "30x105",
                        "30x110",
                        "30x115",
                        "30x120",
                        "30x125",
                        "30x130",
                        "30x135",
                        "30x140",
                        "30x145",
                        "30x150",
                        "30x155",
                        "30x160",
                        "30x165",
                        "30x170",
                        "30x175",
                        "30x180",
                        "30x185",
                        "30x190",
                        "30x195",
                        "30x200",
                        "30x205",
                        "30x210",
                        "30x215",
                        "30x220",
                        "30x225",
                        "30x230",
                        "30x235",
                        "30x240",
                    ""});
                    this.cb_size.SelectedIndex = 0;
                    this.cb_holddown.Items.AddRange(new object[] {
                    "Pins",
                    "Water Barrels",
                    "1/2 ton Concrete Block",
                    "1 ton Concrete Block"});
                    this.cb_holddown.SelectedIndex = 0;
                    this.cb_coverType.Items.AddRange(new object[] {
                    "Regular",
                    "New",
                    "Old"});
                    this.cb_coverType.SelectedIndex = 0;
                    this.cb_walls.Items.AddRange(new object[] {
                    "Full Plain",
                    "Full Window",
                    "Half Plain Half Window",
                    "None"});
                    this.cb_walls.SelectedIndex = 0;
                    this.cb_legs.Items.AddRange(new object[] {
                    "8 ft",
                    "10 ft"});
                    this.cb_legs.SelectedIndex = 0;
                    break;
                case UserInterface.Tent.ClearSpan:
                    this.Text = "Add ClearSpan";
                    this.cb_size.Items.AddRange(new object[]{
                        "30x15",
                        "30x30",
                        "30x40",
                        "30x45",
                        "30x50",
                        "30x55",
                        "30x60",
                        "30x65",
                        "30x70",
                        "30x75",
                        "30x80",
                        "30x85",
                        "30x90",
                        "30x95",
                        "30x100",
                        "30x105",
                        "30x110",
                        "30x115",
                        "30x120",
                        "30x125",
                        "30x130",
                        "30x135",
                        "30x140",
                        "30x145",
                        "30x150",
                        "30x155",
                        "30x160",
                        "30x165",
                        "30x170",
                        "30x175",
                        "30x180",
                        "30x185",
                        "30x190",
                        "30x195",
                        "30x200",
                        "30x205",
                        "30x210",
                        "30x215",
                        "30x220",
                        "30x225",
                        "30x230",
                        "30x235",
                        "30x240",
                        "40x15",
                        "40x30",
                        "40x40",
                        "40x45",
                        "40x50",
                        "40x55",
                        "40x60",
                        "40x65",
                        "40x70",
                        "40x75",
                        "40x80",
                        "40x85",
                        "40x90",
                        "40x95",
                        "40x100",
                        "40x105",
                        "40x110",
                        "40x115",
                        "40x120",
                        "40x125",
                        "40x130",
                        "40x135",
                        "40x140",
                        "40x145",
                        "40x150",
                        "40x155",
                        "40x160",
                        "40x165",
                        "40x170",
                        "40x175",
                        "40x180",
                        "40x185",
                        "40x190",
                        "40x195",
                        "40x200",
                        "40x205",
                        "40x210",
                        "40x215",
                        "40x220",
                        "40x225",
                        "40x230",
                        "40x235",
                        "40x240",
                        "50x15",
                        "50x30",
                        "50x40",
                        "50x45",
                        "50x50",
                        "50x55",
                        "50x60",
                        "50x65",
                        "50x70",
                        "50x75",
                        "50x80",
                        "50x85",
                        "50x90",
                        "50x95",
                        "50x100",
                        "50x105",
                        "50x110",
                        "50x115",
                        "50x120",
                        "50x125",
                        "50x130",
                        "50x135",
                        "50x140",
                        "50x145",
                        "50x150",
                        "50x155",
                        "50x160",
                        "50x165",
                        "50x170",
                        "50x175",
                        "50x180",
                        "50x185",
                        "50x190",
                        "50x195",
                        "50x200",
                        "50x205",
                        "50x210",
                        "50x215",
                        "50x220",
                        "50x225",
                        "50x230",
                        "50x235",
                        "50x240"});
                    this.cb_size.SelectedIndex = 0;
                    this.cb_holddown.Enabled = false;
                    this.cb_coverType.Items.AddRange(new object[] {
                    "Regular",
                    "Clear"});
                    this.cb_coverType.SelectedIndex = 0;
                    this.cb_walls.Items.AddRange(new object[] {
                    "Full Plain",
                    "Full Bay Window",
                    "Full French Window",
                    "Half Plain Half Bay Window",
                    "None"});
                    this.cb_walls.SelectedIndex = 0;
                    this.cb_legs.Items.AddRange(new object[] {
                    "8 ft",
                    "10 ft"});
                    this.cb_legs.SelectedIndex = 0;
                    break;
                default:
                    break;

            } // end switch
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
        public UserInterface.Tent TypeOfTent { get; set; }
        

        private void cb_walls_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the user selects to use a custom wall configuration, open the custom wall dialog.
            if(cb_walls.Text == "Custom...")
            {
                var cstmWalls = new AddCustomWallsDlg(TypeOfTent);
                cstmWalls.ShowDialog();
                int PlainWalls = cstmWalls.Plain;
                int FPlainWalls = cstmWalls.FPlain;
                int WindowWalls = cstmWalls.Window;
                int FWindowWalls = cstmWalls.FWindow;

                string Walls = String.Format("Plain Walls: {0}\n" +
                    "Plain Fiesta Walls: {1}\n" +
                    "Window Walls: {2}\n" +
                    "Window Fiesta Walls: {3}", 
                    PlainWalls.ToString(),
                    FPlainWalls.ToString(),
                    WindowWalls.ToString(),
                    FWindowWalls.ToString());
                MessageBox.Show(Walls);
            }
        }
        /// <summary>
        /// Updates the fields in the dialog with the values stored in the properties.
        /// </summary>
        public void UpdateFields()
        {
            cb_coverType.Text = this.CoverType;
            cb_size.Text = this.TentSize;
            nud_qty.Value = this.Qty;
            cb_holddown.Text = this.TieDown;
            cb_walls.Text = this.Walls;
            cb_legs.Text = this.Legs;
        }

        /// <summary>
        /// Updates the properties of the class depending on the values currently in the dialog.
        /// </summary>
        public void UpdateProperties()
        {
            this.TentSize = cb_size.Text;
            this.Qty = nud_qty.Value;
            this.CoverType = cb_coverType.Text;
            this.TieDown = cb_holddown.Text;
            this.Walls = cb_walls.Text;
            this.Legs = cb_legs.Text;
            this.TypeOfTent = tent;
        }

        #region Buttons
        private void btn_done_Click(object sender, EventArgs e)
        {
            UpdateProperties();
            this.Code = true;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Code = false;
            this.Close();
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            // Reset all GUI items to default (first) items
            cb_size.SelectedIndex = 0;
            nud_qty.Value = 1;
            cb_coverType.SelectedIndex = 0;
            cb_holddown.SelectedIndex = 0;
            cb_walls.SelectedIndex = 0;
            cb_legs.SelectedIndex = 0;

            // Update the properties of the object, just in case...
            UpdateProperties();
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

        private void cb_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TypeOfTent == UserInterface.Tent.Small)
            {
                if(cb_size.Text == "Hexagon")
                {
                    // Set the legs combobox to Hexagon
                    cb_legs.SelectedIndex = 4;
                    this.Legs = "Hexagon";
                }
            }
        }
    }
}
