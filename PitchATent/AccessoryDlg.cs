using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace PitchATent
{
    
    public partial class AccessoryDlg : Form
    {
        public AccessoryDlg()
        {
            InitializeComponent();
        }

        #region Properties
        
        

        private int _BlackFloor = 0;
        public int BlackFloor
        {
            get
            {
                return _BlackFloor;
            }
            set
            {
                _BlackFloor = value;
                DataHandler.HandleList("Black Floor", Convert.ToInt32(_BlackFloor),UserInterface.AccList);
            }

        }

        private int _VarnishFloor = 0;
        public int VarnishFloor
        {
            get
            {
                return _VarnishFloor;
            }
            set
            {
                _VarnishFloor = value;
                DataHandler.HandleList("Varnish Floor", Convert.ToInt32(_VarnishFloor), UserInterface.AccList);
            }
        }
        private bool _TarFiller;
        public bool TarFiller
        {
            get
            {
                return _TarFiller;
            }
            set
            {
                _TarFiller = value;
                DataHandler.HandleList("Tar Filler", Convert.ToInt32(_TarFiller), UserInterface.AccList);
            }
        }

        private int _SpotLights = 0;
        public int SpotLights
        {
            get
            {
                return _SpotLights;
            }
            set
            {
                _SpotLights = value;
                DataHandler.HandleList("Spot Lights", _SpotLights, UserInterface.AccList);
            }
        }

        private int _Chandelier = 0;
        public int Chandelier
        {
            get
            {
                return _Chandelier;
            }
            set
            {
                _Chandelier = value;
                DataHandler.HandleList("Chandelier", _Chandelier, UserInterface.AccList);
            }
        }

        private int _Cafe25 = 0;
        public int Cafe25
        {
            get
            {
                return _Cafe25;
            }
            set
            {
                _Cafe25 = value;
                DataHandler.HandleList("Cafe Lights, 25 ft.", _Cafe25, UserInterface.AccList);
            }
        }

        private int _Cafe50 = 0;
        public int Cafe50
        {
            get
            {
                return _Cafe50;
            }
            set
            {
                _Cafe50 = value;
                DataHandler.HandleList("Cafe Lights, 50 ft.", _Cafe50, UserInterface.AccList);
            }
        }

        private int _Cafe100 = 0;
        public int Cafe100
        {
            get
            {
                return _Cafe100;
            }
            set
            {
                _Cafe100 = value;
                DataHandler.HandleList("Cafe Lights, 100 ft.", _Cafe100, UserInterface.AccList);
            }
        }

        private int _Extension25 = 0;
        public int Extension25
        {
            get
            {
                return _Extension25;
            }
            set
            {
                _Extension25 = value;
                DataHandler.HandleList("Extension 25'", _Extension25, UserInterface.AccList);
            }
        }

        private int _Extension50 = 0;
        public int Extension50
        {
            get
            {
                return _Extension50;
            }
            set
            {
                _Extension50 = value;
                DataHandler.HandleList("Extension 50'", _Extension50, UserInterface.AccList);
            }
        }

        private int _Extension100 = 0;
        public int Extension100
        {
            get
            {
                return _Extension100;
            }
            set
            {
                _Extension100 = value;
                DataHandler.HandleList("Extension 100'", _Extension100, UserInterface.AccList);
            }
        }

        private int _SingleDoor = 0;
        public int SingleDoor
        {
            get
            {
                return _SingleDoor;
            }
            set
            {
                _SingleDoor = value;
                DataHandler.HandleList("Single Door", _SingleDoor, UserInterface.AccList);
            }
        }

        private int _DoubleDoor = 0;
        public int DoubleDoor
        {
            get
            {
                return _DoubleDoor;
            }
            set
            {
                _DoubleDoor = value;
                DataHandler.HandleList("Double Door", _DoubleDoor, UserInterface.AccList);
            }
        }

        private int _ExitSign = 0;
        public int ExitSign
        {
            get
            {
                return _ExitSign;
            }
            set
            {
                _ExitSign = value;
                DataHandler.HandleList("Exit Sign", _ExitSign, UserInterface.AccList);
            }
        }

        private int _FireExtinguisher = 0;
        public int FireExtinguisher
        {
            get
            {
                return _FireExtinguisher;
            }
            set
            {
                _FireExtinguisher = value;
                DataHandler.HandleList("Fire Extinguisher", _FireExtinguisher, UserInterface.AccList);
            }
        }

        private int _BlockCover = 0;
        public int BlockCover
        {
            get
            {
                return _BlockCover;
            }
            set
            {
                _BlockCover = value;
                DataHandler.HandleList("Block Cover", _BlockCover, UserInterface.AccList);
            }
        }

        private int _Gutter10 = 0;
        public int Gutter10
        {
            get
            {
                return _Gutter10;
            }
            set
            {
                _Gutter10 = value;
                DataHandler.HandleList("Gutter 10'", _Gutter10, UserInterface.AccList);
            }
        }

        private int _Gutter15 = 0;
        public int Gutter15
        {
            get
            {
                return _Gutter15;
            }
            set
            {
                _Gutter15 = value;
                DataHandler.HandleList("Gutter 15'", _Gutter15, UserInterface.AccList);
            }
        }

        private int _Gutter20 = 0;
        public int Gutter20
        {
            get
            {
                return _Gutter20;
            }
            set
            {
                _Gutter20 = value;
                DataHandler.HandleList("Gutter 20'", _Gutter20, UserInterface.AccList);
            }
        }

        public string filename { get; set; }


        

        #endregion

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            // Simnply retrieve values and update properties

            this.BlackFloor = Convert.ToInt32(nud_BlackFloor.Value);
            this.VarnishFloor = Convert.ToInt32(nud_VarnishFloor.Value);
            this.TarFiller = checkbox_TarFiller.Checked;
            this.SpotLights = Convert.ToInt32(nud_SpotLight.Value);
            this.Chandelier = Convert.ToInt32(nud_Chandelier.Value);
            this.Cafe25 = Convert.ToInt32(nud_25CL.Value);
            this.Cafe50 = Convert.ToInt32(nud_50CL.Value);
            this.Cafe100 = Convert.ToInt32(nud_100CL.Value);
            this.Extension25 = Convert.ToInt32(nud_Extension25.Value);
            this.Extension50 = Convert.ToInt32(nud_Extension50.Value);
            this.Extension100 = Convert.ToInt32(nud_Extension100.Value);
            this.SingleDoor = Convert.ToInt32(nud_SingleDoor.Value);
            this.DoubleDoor = Convert.ToInt32(nud_DoubleDoor.Value);
            this.FireExtinguisher = Convert.ToInt32(nud_Extinguisher.Value);
            this.BlockCover = Convert.ToInt32(nud_BlockCovers.Value);
            this.Gutter10 = Convert.ToInt32(nud_Gutter10.Value);
            this.Gutter15 = Convert.ToInt32(nud_Gutter15.Value);
            this.Gutter20 = Convert.ToInt32(nud_Gutter20.Value);
            if (!SaveAccessoryList())
            {
                MessageBox.Show("There was a problem retaining the accessories entered into the dialog.", "Accessories", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Close();
        }
        
        

        #region IO

        /// <summary>
        /// Saves the list of accessories to a Comma-Separated Value file for later use if needed.
        /// </summary>
        private bool SaveAccessoryList()
        {
            // Temporary file for storing accessory data
            string fname = "AccessoryData.csv";

            // Check if output folder already exists
            string OutputPath = @"C:\ProgramData\Charbonneau Vendette Solutions\";
           
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
                Console.WriteLine("Creating new path {0}.", OutputPath);
            }

            // Create full path for file for storing accessory data
            filename = OutputPath + fname;
            
            
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
                {
                    Console.WriteLine("Writing to {0}.", filename);
                    file.WriteLine("BlackFloor,{0}",BlackFloor.ToString());
                    file.WriteLine("VarnishFloor,{0}", VarnishFloor.ToString());
                    file.WriteLine("TarFiller,{0}", TarFiller.ToString());
                    file.WriteLine("SpotLights,{0}", SpotLights.ToString());
                    file.WriteLine("Chandelier,{0}", Chandelier.ToString());
                    file.WriteLine("Cafe25,{0}", Cafe25.ToString());
                    file.WriteLine("Cafe50,{0}", Cafe50.ToString());
                    file.WriteLine("Cafe100,{0}", Cafe100.ToString());
                    file.WriteLine("Extension25,{0}", Extension25.ToString());
                    file.WriteLine("Extension50,{0}", Extension50.ToString());
                    file.WriteLine("Extension100,{0}", Extension100.ToString());
                    file.WriteLine("ExitSign,{0}", ExitSign.ToString());
                    file.WriteLine("SingleDoor,{0}", SingleDoor.ToString());
                    file.WriteLine("DoubleDoor,{0}", DoubleDoor.ToString());
                    file.WriteLine("FireExtinguisher,{0}", FireExtinguisher.ToString());
                    file.WriteLine("BlockCover,{0}", BlockCover.ToString());
                    file.WriteLine("Gutter10,{0}", Gutter10.ToString());
                    file.WriteLine("Gutter15,{0}", Gutter15.ToString());
                    file.WriteLine("Gutter20,{0}", Gutter20.ToString());
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// Loads the list of accessories from a Comma-Separated Value file.
        /// </summary>
        public void LoadAccessoryList(string fname)
        {
            
            
                // Read each line into a string array
                Console.WriteLine("Reading from {0}.",fname);
                string[] lines = System.IO.File.ReadAllLines(fname);
                foreach (string line in lines)
                {
#if DEBUG
                    //Console.WriteLine(line);
#endif
                    string[] tokens = line.Split(',');
                    switch (tokens[0])
                    {
                        case "BlackFloor":
                            BlackFloor = Convert.ToInt32(tokens[1]);
                            nud_BlackFloor.Value = Convert.ToDecimal(BlackFloor);
                            break;
                        case "VarnishFloor":
                            VarnishFloor = Convert.ToInt32(tokens[1]);
                            nud_VarnishFloor.Value = Convert.ToDecimal(VarnishFloor);
                            break;
                        case "TarFiller":
                            if (tokens[1] == "False")
                            {
                                TarFiller = false;
                            }
                            else
                            {
                                TarFiller = true;
                            }
                            checkbox_TarFiller.Checked = TarFiller;
                            break;
                        case "SpotLights":
                            SpotLights = Convert.ToInt32(tokens[1]);
                            nud_SpotLight.Value = Convert.ToDecimal(SpotLights);
                            break;
                        case "Chandelier":
                            Chandelier = Convert.ToInt32(tokens[1]);
                            nud_Chandelier.Value = Convert.ToDecimal(Chandelier);
                            break;
                        case "Cafe25":
                            Cafe25 = Convert.ToInt32(tokens[1]);
                            nud_25CL.Value = Convert.ToDecimal(Cafe25);
                            break;
                        case "Cafe50":
                            Cafe50 = Convert.ToInt32(tokens[1]);
                            nud_50CL.Value = Convert.ToDecimal(Cafe50);
                            break;
                        case "Cafe100":
                            Cafe100 = Convert.ToInt32(tokens[1]);
                            nud_100CL.Value = Convert.ToDecimal(Cafe100);
                            break;
                        case "Extension25":
                            Extension25 = Convert.ToInt32(tokens[1]);
                            nud_Extension25.Value = Convert.ToDecimal(Extension25);
                            break;
                        case "Extension50":
                            Extension50 = Convert.ToInt32(tokens[1]);
                            nud_Extension50.Value = Convert.ToDecimal(Extension50);
                            break;
                        case "Extension100":
                            Extension100 = Convert.ToInt32(tokens[1]);
                            nud_Extension100.Value = Convert.ToDecimal(Extension100);
                            break;
                        case "SingleDoor":
                            SingleDoor = Convert.ToInt32(tokens[1]);
                            nud_SingleDoor.Value = Convert.ToDecimal(SingleDoor);
                            break;
                        case "DoubleDoor":
                            DoubleDoor = Convert.ToInt32(tokens[1]);
                            nud_DoubleDoor.Value = Convert.ToDecimal(DoubleDoor);
                            break;
                        case "ExitSign":
                            ExitSign = Convert.ToInt32(tokens[1]);
                            nud_ExitSign.Value = Convert.ToDecimal(ExitSign);
                            break;
                        case "FireExtinguisher":
                            FireExtinguisher = Convert.ToInt32(tokens[1]);
                            nud_Extinguisher.Value = Convert.ToDecimal(FireExtinguisher);
                            break;
                        case "BlockCover":
                            BlockCover = Convert.ToInt32(tokens[1]);
                            nud_BlockCovers.Value = Convert.ToDecimal(BlockCover);
                            break;
                        case "Gutter10":
                            Gutter10 = Convert.ToInt32(tokens[1]);
                            nud_Gutter10.Value = Convert.ToDecimal(Gutter10);
                            break;
                        case "Gutter15":
                            Gutter15 = Convert.ToInt32(tokens[1]);
                            nud_Gutter15.Value = Convert.ToDecimal(Gutter15);
                            break;
                        case "Gutter20":
                            Gutter20 = Convert.ToInt32(tokens[1]);
                            nud_Gutter20.Value = Convert.ToDecimal(Gutter20);
                            break;
                        default:
#if DEBUG
                            MessageBox.Show("Unknown option");
#endif
                            break;
                    }
                }
            
            //catch
            //{
            //    MessageBox.Show("Unable to open to file. Restarting at 0 for all.", "Accessories", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

        }
        #endregion

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            // Set all GUI items to 0 or false
            nud_BlackFloor.Value = 0;
            nud_VarnishFloor.Value= 0;
            checkbox_TarFiller.Checked = false;
            nud_SpotLight.Value = 0;
            nud_Chandelier.Value = 0;
            nud_25CL.Value = 0;
            nud_50CL.Value = 0;
            nud_100CL.Value = 0;
            nud_Extension25.Value = 0;
            nud_Extension50.Value = 0;
            nud_Extension100.Value = 0;
            nud_SingleDoor.Value = 0;
            nud_DoubleDoor.Value = 0;
            nud_Extinguisher.Value = 0;
            nud_BlockCovers.Value = 0;
            nud_Gutter10.Value = 0;
            nud_Gutter15.Value = 0;
            nud_Gutter20.Value = 0;
            
            // Update the properties. This could be a function because I use the same code twice, but I got lazy and copy pasted. :)
            this.BlackFloor = Convert.ToInt32(nud_BlackFloor.Value);
            this.VarnishFloor = Convert.ToInt32(nud_VarnishFloor.Value);
            this.TarFiller = checkbox_TarFiller.Checked;
            this.SpotLights = Convert.ToInt32(nud_SpotLight.Value);
            this.Chandelier = Convert.ToInt32(nud_Chandelier.Value);
            this.Cafe25 = Convert.ToInt32(nud_25CL.Value);
            this.Cafe50 = Convert.ToInt32(nud_50CL.Value);
            this.Cafe100 = Convert.ToInt32(nud_100CL.Value);
            this.Extension25 = Convert.ToInt32(nud_Extension25.Value);
            this.Extension50 = Convert.ToInt32(nud_Extension50.Value);
            this.Extension100 = Convert.ToInt32(nud_Extension100.Value);
            this.SingleDoor = Convert.ToInt32(nud_SingleDoor.Value);
            this.DoubleDoor = Convert.ToInt32(nud_DoubleDoor.Value);
            this.FireExtinguisher = Convert.ToInt32(nud_Extinguisher.Value);
            this.BlockCover = Convert.ToInt32(nud_BlockCovers.Value);
            this.Gutter10 = Convert.ToInt32(nud_Gutter10.Value);
            this.Gutter15 = Convert.ToInt32(nud_Gutter15.Value);
            this.Gutter20 = Convert.ToInt32(nud_Gutter20.Value);

        }
    }
}
