using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PitchATent
{
    public class TentItems
    {
        public TentItems() { }

        public TentItems(string type, int qty)
        {
            this.Type = type;
            this.Qty = qty;
        }

        [XmlText]
        public string Type { get; set; }

        [XmlText]
        public int Qty { get; set; }
    }
}
