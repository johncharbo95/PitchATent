using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchATent
{
    public interface IDatabase
    {
        //https://stackoverflow.com/questions/39659145/t-does-not-contain-a-definition?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
        string Size { get; set; }
        int Legs { get; set; }
        int MiddlePost { get; set; }
        int PinsW { get; set; }
        int PinsR { get; set; }
        int Barrels { get; set; }
        int Concrete250 { get; set; }
        int Concrete400 { get; set; }
        int Concrete600 { get; set; }
        int ConcreteHalfTon { get; set; }
        int ConcreteTon { get; set; }
        int Walls10 { get; set; }
        int Walls15 { get; set; }
        int Walls20 { get; set; }
        int ComeAlong { get; set; }
    }
}
