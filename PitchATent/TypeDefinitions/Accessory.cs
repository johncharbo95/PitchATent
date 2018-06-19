using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PitchATent
{
    /// <summary>
    /// Class to hold properties of an accessory: the accessory name and the quantity
    /// </summary>
    public class Accessory
    {
        // Constructors

        public Accessory() { }

        public Accessory(string Item, int Qty)
        {
            this.Item = Item;
            this.Qty = Qty;
        }

        // Properties
        [XmlElement(Order = 1,ElementName = "Accessory")]
        public string Item { get; set; }
        [XmlElement(Order = 2, ElementName = "Quantity")]
        public int Qty { get; set; }
    }
}

