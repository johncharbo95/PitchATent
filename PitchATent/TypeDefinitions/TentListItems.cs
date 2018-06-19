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
    /// Characteristics of a tent.
    /// </summary>
    public class TentListItem
    {
        public TentListItem() { }

        public TentListItem(UserInterface.Tent TentType,
            string TentSizes,
            int TentQty,
            string TentCoverTypes,
            string TentHoldDowns,
            string TentWalls,
            string TentLegs)
        {
            this.tentType = TentType;
            this.tentSizes = TentSizes;
            this.tentQties = TentQty;
            this.tentCoverTypes = TentCoverTypes;
            this.tentHoldDowns = TentHoldDowns;
            this.tentWalls = TentWalls;
            this.tentLegs = TentLegs;
        }

        [XmlElement(Order = 1, ElementName = "TentType")]
        public UserInterface.Tent tentType { get; set; }
        [XmlElement(Order = 2, ElementName = "TentSize")]
        public string tentSizes { get; set; }
        [XmlElement(Order = 3, ElementName = "Quantity")]
        public int tentQties { get; set; }
        [XmlElement(Order = 4, ElementName = "TentCoverType")]
        public string tentCoverTypes { get; set; }
        [XmlElement(Order = 5, ElementName = "HoldDown")]
        public string tentHoldDowns { get; set; }
        [XmlElement(Order = 6, ElementName = "Walls")]
        public string tentWalls { get; set; }
        [XmlElement(Order = 7, ElementName = "Legs")]
        public string tentLegs { get; set; }
    }
}
