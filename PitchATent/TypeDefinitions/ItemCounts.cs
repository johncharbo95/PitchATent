using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PitchATent
{
    public class ItemCounts
    {
        [XmlElement]
        public List<TentItems> Metal { get; set; }

        [XmlElement]
        public List<TentItems> Walls { get; set; }

        [XmlElement]
        public List<TentItems> Covers { get; set; }

        [XmlElement]
        public List<TentItems> TieDowns { get; set; }
    }
}
