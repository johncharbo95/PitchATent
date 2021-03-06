﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PitchATent
{
    public class ListNames
    {
        public ListNames() { }

        
        public ListNames(List<UserInterface.Tent> TentType,
            List<string> TentSizes,
            List<int> TentQty,
            List<string> TentCoverTypes,
            List<string> TentHoldDowns,
            List<string> TentWalls,
            List<string> TentLegs)
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
        public List<UserInterface.Tent> tentType { get; set; }
        [XmlElement(Order = 2, ElementName = "TentSize")]
        public List<string> tentSizes { get; set; }
        [XmlElement(Order = 3, ElementName = "Quantity")]
        public List<int> tentQties { get; set; }
        [XmlElement(Order = 4, ElementName = "TentCoverType")]
        public List<string> tentCoverTypes { get; set; }
        [XmlElement(Order = 5, ElementName = "HoldDown")]
        public List<string> tentHoldDowns { get; set; }
        [XmlElement(Order = 6, ElementName = "Walls")]
        public List<string> tentWalls { get; set; }
        [XmlElement(Order = 7, ElementName = "Legs")]
        public List<string> tentLegs { get; set; }
    }
}
