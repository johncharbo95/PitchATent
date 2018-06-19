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
    /// Contains a list of tents and accessories required to load.
    /// </summary>
    public class PitchATentJob
    {
        public PitchATentJob() { }

        public PitchATentJob(List<TentListItem> tentList,List<Accessory> accList)
        {
            this.TentList = tentList;
            this.AccList = accList;
        }

        [XmlElement(Order = 1, ElementName = "TentList")]
        public List<TentListItem> TentList { get; set; }

        [XmlElement(Order = 2,ElementName = "AccessoryList")]
        public List<Accessory> AccList { get; set; }
    }
}
