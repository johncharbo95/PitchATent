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
                    "Concrete Blocks"});
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
                    "None",
                    "Custom..."});
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
                    this.cb_holddown.Items.AddRange(new object[] {
                    "Pins",
                    "Water Barrels",
                    "Concrete Blocks"});
                    this.cb_holddown.SelectedIndex = 0;
                    this.cb_coverType.Items.AddRange(new object[] {
                    "Regular",
                    "New",
                    "Old",
                    "Barbecue",
                    "Soft"});
                    this.cb_coverType.SelectedIndex = 0;
                    this.cb_walls.Items.AddRange(new object[] {
                    "Full Plain",
                    "Full Window",
                    "Half Plain Half Window",
                    "Full Plain Fiesta",
                    "Full Window Fiesta",
                    "Half Plain Half Window Fiesta",
                    "None",
                    "Custom..."});
                    this.cb_walls.SelectedIndex = 0;
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
                    "30x60",
                    "30x70",
                    "30x80",
                    "30x85",
                    "30x90",
                    "30x95",
                    "30x100",
                    ""});
                    this.cb_size.SelectedIndex = 0;
                    this.cb_holddown.Items.AddRange(new object[] {
                    "Pins",
                    "Water Barrels",
                    "Concrete Blocks"});
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
                    "None",
                    "Custom..."});
                    this.cb_walls.SelectedIndex = 0;
                    this.cb_legs.Items.AddRange(new object[] {
                    "8 ft",
                    "10 ft"});
                    this.cb_legs.SelectedIndex = 0;
                    break;
                case UserInterface.Tent.ClearSpan:
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
    }
}
