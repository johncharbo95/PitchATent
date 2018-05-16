using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchATent
{
    public class ListNames
    {
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
        public List<UserInterface.Tent> tentType { get; set; }
        public List<string> tentSizes { get; set; }
        public List<int> tentQties { get; set; }
        public List<string> tentCoverTypes { get; set; }
        public List<string> tentHoldDowns { get; set; }
        public List<string> tentWalls { get; set; }
        public List<string> tentLegs { get; set; }
    }
}
