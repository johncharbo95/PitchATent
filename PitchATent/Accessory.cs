using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

