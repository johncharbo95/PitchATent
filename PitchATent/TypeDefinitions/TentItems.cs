using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchATent
{
    public class TentItems
    {
        public TentItems(string type, int qty)
        {
            this.Type = type;
            this.Qty = qty;
        }
        public string Type { get; set; }
        public int Qty { get; set; }
    }
}
