using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PitchATent
{
    /// <summary>
    /// Class to hold properties of an accessory: the accessory name and the quantity
    /// </summary>
    public class Accessory
    {
        // Constructor
        public Accessory(string Item, int Qty)
        {
            this.Item = Item;
            this.Qty = Qty;
        }

        // Properties
        public string Item { get; set; }
        public int Qty { get; set; }
    }

    public partial class AccessoryDlg : Form
    {
        public AccessoryDlg()
        {
            InitializeComponent();
        }

        #region Properties
        
        

        // List of accessories
        public List<Accessory> AccList = new List<Accessory>();

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
                CheckList("Black Floor", Convert.ToInt32(_BlackFloor));
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
                CheckList("Varnish Floor", Convert.ToInt32(_VarnishFloor));
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
                CheckList("Tar Filler", Convert.ToInt32(_TarFiller));
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
                CheckList("Spot Lights", _SpotLights);
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
                CheckList("Chandelier", _Chandelier);
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
                CheckList("Cafe Lights, 25 ft.", _Cafe25);
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
                CheckList("Cafe Lights, 50 ft.", _Cafe50);
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
                CheckList("Cafe Lights, 100 ft.", _Cafe100);
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
                CheckList("Extension Cord, 25 ft.", _Extension25);
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
                CheckList("Extension Cord, 50 ft.", _Extension50);
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
                CheckList("Extension Cord, 100 ft.", _Extension100);
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
                CheckList("Single Door", _SingleDoor);
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
                CheckList("Double Door", _DoubleDoor);
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
                CheckList("Exit Sign", _ExitSign);
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
                CheckList("Fire Extinguisher", _FireExtinguisher);
            }
        }

        /// <summary>
        /// Checks the existing accessory list  for the a string. 
        /// 
        /// If the string does not exist, it adds the object to the list.
        /// If the string exists in the list and the current quantity is zero, the object is removed from the list.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="quantity"></param>
        private void CheckList(string item, int quantity)
        {
            // If item is not in the list and quantity is not 0
            if (!AccList.Any(a => a.Item == item) && quantity != 0)
            {
                // Add it to the list
                AccList.Add(new Accessory(item, quantity));
            }
            // Else, if the item is in the list and quantity is not 0
            else if(AccList.Any(a => a.Item == item) && quantity != 0)
            {
                // Remove the previous item
                AccList.RemoveAll(a => a.Item == item);

                // Add the one with new quantity
                AccList.Add(new Accessory(item, quantity));
            }
            // Else, if the item is in the list and quantity is 0
            else if (quantity == 0 && AccList.Any(a => a.Item == item))
            {
                // Remove it from the list
                AccList.RemoveAll(a => a.Item == item);
            }
        }

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
            SaveAccessoryList();
            this.Close();
        }
        
        

        #region IO

        /// <summary>
        /// Saves the list of accessories to a Comma-Separated Value file for later use if needed.
        /// </summary>
        private void SaveAccessoryList()
        {
            string filename = "AccessoryQty.csv";
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
                {
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
                    file.WriteLine("SingleDoor,{0}", SingleDoor.ToString());
                    file.WriteLine("DoubleDoor,{0}", DoubleDoor.ToString());
                    file.WriteLine("FireExtinguisher,{0}", FireExtinguisher.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Unable to open or write to file. Restarting at 0 for all.","Accessories", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        
        /// <summary>
        /// Loads the list of accessories from a Comma-Separated Value file.
        /// </summary>
        public void LoadAccessoryList()
        {
            string filename = "AccessoryQty.csv";

            // Read each line into a string array
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filename);
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
                        default:
#if DEBUG
                            MessageBox.Show("Unknown option");
#endif
                            break;
                    }
                }
            }
            catch (FileNotFoundException e)
            {
#if DEBUG
                Console.WriteLine("File {0} could not be found", filename);
                return;
#else
                MessageBox.Show(@"Unable to find previously stored accessory data. Restarting all quantities at 0.
                                Contact support if this becomes a recurring problem.");
#endif
            }
            
            
            
        }
        #endregion
    }
}
