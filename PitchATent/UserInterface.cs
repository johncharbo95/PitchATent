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
            MessageBox.Show("Not yet dumb dumb");
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
