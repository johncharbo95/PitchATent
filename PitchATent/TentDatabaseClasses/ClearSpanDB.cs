using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchATent
{
    public class ClearSpanDB : IDatabase
    {
        public string Size { get; set; }
        public int Legs { get; set; }
        public int MiddlePost { get; set; }
        public int PinsW { get; set; }
        public int PinsR { get; set; }
        public int Barrels { get; set; }
        public int Concrete250 { get; set; }
        public int Concrete400 { get; set; }
        public int Concrete600 { get; set; }
        public int ConcreteHalfTon { get; set; }
        public int ConcreteTon { get; set; }
        public int Walls10 { get; set; }
        public int Walls15 { get; set; }
        public int Walls20 { get; set; }
        public int ComeAlong { get; set; }
        public int Cover15 { get; set; }
        public int Cover10 { get; set; }
        public int Triangle { get; set; }
    }
}
