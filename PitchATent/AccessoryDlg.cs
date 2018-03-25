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
    public partial class AccessoryDlg : Form
    {
        public AccessoryDlg()
        {
            InitializeComponent();
        }

        // Declare Properties
        public bool BlackFloor { get; set; } = false;
        public bool VarnishFloor { get; set; } = false;
        public bool TarFiller { get; set; } = false;
        public int SpotLights { get; set; } = 0;
        public int Chandelier { get; set; } = 0;
        public int Cafe25 { get; set; } = 0;
        public int Cafe50 { get; set; } = 0;
        public int Cafe100 { get; set; } = 0;
        public int ExtensionCord { get; set; } = 0;
        public int SingleDoor { get; set; } = 0;
        public int DoubleDoor { get; set; } = 0;
        public int ExitSign { get; set; } = 0;
        public int FireExtinguisher { get; set; } = 0;

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            // Simnply retrieve values and update properties
            this.BlackFloor = checkbox_BlackFloor.Checked;
            this.VarnishFloor = checkbox_VarnishFloor.Checked;
            this.TarFiller = checkbox_TarFiller.Checked;
            this.SpotLights = Convert.ToInt32(nud_SpotLight.Value);
            this.Chandelier = Convert.ToInt32(nud_Chandelier.Value);
            this.Cafe25 = Convert.ToInt32(nud_25CL.Value);
            this.Cafe50 = Convert.ToInt32(nud_50CL.Value);
            this.Cafe100 = Convert.ToInt32(nud_100CL.Value);
            this.ExtensionCord = Convert.ToInt32(nud_Extension.Value);
            this.SingleDoor = Convert.ToInt32(nud_SingleDoor.Value);
            this.DoubleDoor = Convert.ToInt32(nud_DoubleDoor.Value);
            this.FireExtinguisher = Convert.ToInt32(nud_Extinguisher.Value);
            SaveAccessoryList();
            this.Close();
        }

        #region IO
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
                    file.WriteLine("ExtensionCord,{0}", ExtensionCord.ToString());
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
        
        public void LoadAccessoryList()
        {
            string filename = "AccessoryQty.csv";
            // Read each line into a string array
            string[] lines = System.IO.File.ReadAllLines(filename);
            
            foreach (string line in lines)
            {
#if DEBUG
                Console.WriteLine(line);
#endif
                string[] tokens = line.Split(',');
                switch (tokens[0])
                {
                    case "BlackFloor":
                        if (tokens[1] == "False")
                        {
                            BlackFloor = false;
                        }
                        else
                        {
                            BlackFloor = true;
                        }
                        checkbox_BlackFloor.Checked = BlackFloor;
                        break;
                    case "VarnishFloor":
                        if (tokens[1] == "False")
                        {
                            VarnishFloor = false;
                        }
                        else
                        {
                            VarnishFloor = true;
                        }
                        checkbox_VarnishFloor.Checked = VarnishFloor;
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
                    case "ExtensionCord":
                        ExtensionCord = Convert.ToInt32(tokens[1]);
                        nud_Extension.Value = Convert.ToDecimal(ExtensionCord);
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
        #endregion
    }
}
