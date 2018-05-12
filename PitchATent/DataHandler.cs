using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Xml;
using System.Xml.Serialization;

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

    public class ItemCounts
    {
        public List<TentItems> Metal { get; set; }
        public List<TentItems> Walls { get; set; }
        public List<TentItems> Covers { get; set; }
        public List<TentItems> TieDowns { get; set; }
    }
    
    #region Objects
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

    public interface DatabaseInterface
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
    
    public class SmallTentDB:DatabaseInterface
    {
        public string Size { get; set; }
        public int Pipe { get; set; }
        public int Pipe5 { get; set; }
        public int SmallTee { get; set; }
        public int LargeTee { get; set; }
        public int Enture { get; set; }
        public int Corner { get; set; }
        public int Brace { get; set; }
        public int Legs { get; set; }
        public int Cable { get; set; }
        public int MiddlePost { get; set; }
        public int PinsW { get; set; }
        public int PinsR { get; set; }
        public int Barrels { get; set; }
        public int Concrete250 { get; set; }
        public int Concrete400 { get; set; }
        public int Concrete600 { get; set; }
        public int ConcreteHalfTon { get; set; }
        public int ConcreteTon { get; set; }
        public int ComeAlong { get; set; }
        public int Walls10 { get; set; }
        public int Walls15 { get; set; }
        public int Walls20 { get; set; }
    }

    public class LargeTentDB:DatabaseInterface
    {
        public string Size { get; set; }
        public int MiddlePost { get; set; }
        public int PinsW { get; set; }
        public int PinsR { get; set; }
        public int ConcreteTon { get; set; }
        public int ComeAlong { get; set; }
        public int Legs { get; set; }
        public int Walls10 { get; set; }
        public int Walls15 { get; set; }
        public int Walls20 { get; set; }
        public int Mid20 { get; set; }
        public int Mid30 { get; set; }
        public int Plates { get; set; }
        public int Barrels { get; set; }
        public int Concrete250 { get; set; }
        public int Concrete400 { get; set; }
        public int Concrete600 { get; set; }
        public int ConcreteHalfTon { get; set; }
    }

    public class FrameDB : DatabaseInterface
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
    }

    public class ClearSpanDB : DatabaseInterface
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
    #endregion

    public class DataHandler
    {
        
        public enum Legs { shortLegs, longLegs, none};

        public ItemCounts CountTents(ref ListNames ListOfLists)
        {
            // Declare lists of TentItems
            List<TentItems> MetalItemList = new List<TentItems>();
            List<TentItems> WallList = new List<TentItems>();
            List<TentItems> CoverList = new List<TentItems>();
            List<TentItems> HoldDownList = new List<TentItems>();

            // Declare object of ItemCounts class
            ItemCounts counts = new ItemCounts();

            // Declare variables.
            Legs leg = Legs.none;
            string legTentType = null;
            DatabaseInterface db = new SmallTentDB();

            IEnumerable<SmallTentDB> SmallDB = ReadTentDatabase<SmallTentDB>(UserInterface.Tent.Small);
            IEnumerable<LargeTentDB> LargeDB = ReadTentDatabase<LargeTentDB>(UserInterface.Tent.Large);
            IEnumerable<FrameDB> FrameDB = ReadTentDatabase<FrameDB>(UserInterface.Tent.Frame);
            IEnumerable<ClearSpanDB> ClearSpanDB = ReadTentDatabase<ClearSpanDB>(UserInterface.Tent.ClearSpan);

            // Loop through all tents
            for (int i = 0; i < ListOfLists.tentType.Count; ++i)
            {

                // Get the quantity of that particular tent
                int qty = ListOfLists.tentQties[i];

                // Get the cover size and type of tent
                string size = ListOfLists.tentSizes[i];
                UserInterface.Tent typeOfTent = ListOfLists.tentType[i];

                // Depending on the type and size of tent, get the appropriate row in the database.
                switch (ListOfLists.tentType[i])
                {
                    case UserInterface.Tent.Small:
                        {
                            legTentType = "ST";

                            // Get the appropriate row from the small tent database, depending on the size of the tent.
                            SmallTentDB SmallRow = GetDataBaseRow<SmallTentDB>(SmallDB, size);
                            db = SmallRow;
                            if (SmallRow != null)
                            {
                                // Metal list
                                // TODO: string builder for legs, cable, poteau de milieu
                                HandleList("Pipe", SmallRow.Pipe * qty, MetalItemList);
                                HandleList("Pipe 5ft", SmallRow.Pipe5 * qty, MetalItemList);
                                HandleList("T - 20", SmallRow.SmallTee * qty, MetalItemList);
                                HandleList("T - 30", SmallRow.LargeTee * qty, MetalItemList);
                                HandleList("Entures", SmallRow.Enture * qty, MetalItemList);
                                if (size == "Hexagon")
                                {
                                    HandleList("Coins Hex", SmallRow.Corner * qty, MetalItemList);
                                }
                                else
                                {
                                    HandleList("Coins", SmallRow.Corner * qty, MetalItemList);
                                }
                                HandleList("Brace", SmallRow.Brace * qty, MetalItemList);
                                HandleList(string.Format("PM {0}", size), SmallRow.MiddlePost * qty, MetalItemList);
                                HandleList(string.Format("Cables {0}", size), SmallRow.Cable * qty, WallList);
                            }
                        }
                        break;

                    case UserInterface.Tent.Large:
                        legTentType = "BT";

                        // Get the appropriate row from the large tent database, depending on the size of the tent.
                        LargeTentDB LargeRow = GetDataBaseRow<LargeTentDB>(LargeDB, size);
                        db = LargeRow;

                        if (LargeRow != null)
                        {
                            HandleList(string.Format("PM {0}", size), LargeRow.MiddlePost * qty, MetalItemList);
                            HandleList("Plates", LargeRow.Plates * qty, MetalItemList);
                            HandleList("Mid 20 pieds", LargeRow.Mid20 * qty, CoverList);
                            HandleList("Mid 30 pieds", LargeRow.Mid30 * qty, CoverList);
                            HandleList(string.Format("End {0}", size), 2 * qty, CoverList);
                        }
                        break;

                    case UserInterface.Tent.Frame:
                        // Get the appropriate row from the frame database, depending on the size of the tent.
                        FrameDB FrameRow = GetDataBaseRow<FrameDB>(FrameDB, size);
                        db = FrameRow;

                        if (FrameRow != null)
                        {
                            HandleList("Frame 10'", FrameRow.Cover10 * qty, CoverList);
                            HandleList("Frame 15'", FrameRow.Cover15 * qty, CoverList);
                        }

                        break;

                    case UserInterface.Tent.ClearSpan:
                        // Get the appropriate row from the ClearSpan database, depending on the size of the tent.
                        ClearSpanDB ClearSpanRow = GetDataBaseRow<ClearSpanDB>(ClearSpanDB, size);
                        db = ClearSpanRow;

                        // Get the width of the ClearSpan
                        int ClearSpanWidth = Convert.ToInt32(size.Substring(0, 2));                       

                        if (ClearSpanRow != null)
                        {
                            HandleList("ClearSpan 10'", ClearSpanRow.Cover10 * qty, CoverList);
                            HandleList("ClearSpan 15'", ClearSpanRow.Cover15 * qty, CoverList);
                            
                            switch(ClearSpanWidth)
                            {
                                case 30:
                                    HandleList("Triangle ClearSpan 30 pieds", ClearSpanRow.Triangle * qty, CoverList);
                                    break;
                                case 40:
                                    HandleList("Triangle ClearSpan 40 pieds", ClearSpanRow.Triangle * qty, CoverList);
                                    break;
                                case 50:
                                    HandleList("Triangle ClearSpan 50 pieds", ClearSpanRow.Triangle * qty, CoverList);
                                    break;
                            }
                        }
                        break;
                }

                // Hold Down list
                switch (ListOfLists.tentHoldDowns[i])
                {
                    case "Pins":
                        HandleList("White Pins", db.PinsW * qty, HoldDownList);
                        HandleList("Red Pins", db.PinsR * qty, HoldDownList);
                        break;
                    case "Water Barrels":
                        HandleList("Water Barrels", db.Barrels * qty, HoldDownList);
                        break;
                    case "250 lb Concrete Block":
                        HandleList("250 lb Concrete Block", db.Concrete250 * qty, HoldDownList);
                        break;
                    case "400 lb Concrete Block":
                        HandleList("400 lb Concrete Block", db.Concrete400 * qty, HoldDownList);
                        break;
                    case "600 lb Concrete Block":
                        HandleList("600 lb Concrete Block", db.Concrete600 * qty, HoldDownList);
                        break;
                    case "1/2 ton Concrete Block":
                        HandleList("1/2 ton Concrete Block", db.ConcreteHalfTon * qty, HoldDownList);
                        break;
                    case "1 ton Concrete Block":
                        HandleList("1 ton Concrete Block", db.ConcreteTon * qty, HoldDownList);
                        break;
                }

                //Comealongs
                HandleList("Come Along", db.ComeAlong * qty, HoldDownList);

                // If the tent is not hexagon, build the string for type of legs and handle it
                string tentLegs = ListOfLists.tentLegs[i];
                if (tentLegs != "Hexagon")
                {

                    string LegsForList = string.Format("Pattes {0} {1}", tentLegs, legTentType);
                    HandleList(LegsForList, db.Legs * qty, MetalItemList);

                    // Assign enum depending on leg type
                    if (tentLegs == "8 ft" || tentLegs == "8 ft Adjustable")
                    {
                        leg = Legs.shortLegs;
                    }
                    else if (tentLegs == "10 ft" || tentLegs == "10 ft Adjustable")
                    {
                        leg = Legs.longLegs;
                    }
                }
                else
                {
                    // If the size of the cover selected is not hexagon, throw an error.
                    if (ListOfLists.tentSizes[i] != "Hexagon")
                    {
                        throw new Exception("Hexagon legs were chosen, but the cover type for this tent is not Hexagon.");
                    }
                    else
                    {
                        HandleList("Pattes Hex", db.Legs * qty, MetalItemList);
                    }
                }

                // This can definitely be optimized but it works...
                // Insert walls in list.
                if (leg != Legs.none)
                {

                    string leg_length = null;
                    if (leg == Legs.longLegs)
                    {
                        leg_length = "10 pieds";
                    }

                    switch (ListOfLists.tentWalls[i])
                    {
                        case "Full Plain":
                            HandleList(string.Format("Murs 10 pieds, plain, {0}",leg_length), db.Walls10 * qty, WallList);
                            HandleList(string.Format("Murs 15 pieds, plain, {0}", leg_length), db.Walls15 * qty, WallList);
                            HandleList(string.Format("Murs 20 pieds, plain, {0}", leg_length), db.Walls20 * qty, WallList);
                            break;
                        case "Full Window":
                            HandleList(string.Format("Murs 10 pieds, window, {0}", leg_length), db.Walls10 * qty, WallList);
                            HandleList(string.Format("Murs 15 pieds, window, {0}", leg_length), db.Walls15 * qty, WallList);
                            HandleList(string.Format("Murs 20 pieds, window, {0}", leg_length), db.Walls20 * qty, WallList);
                            break;
                        case "Half Plain Half Window":
                            HandleList(string.Format("Murs 10 pieds, plain, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 15 pieds, plain, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 20 pieds, plain, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 10 pieds, window, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 15 pieds, window, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 20 pieds, window, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            break;
                        case "Full Plain Fiesta":
                            HandleList(string.Format("Murs 10 pieds, plain, Fiesta, {0}", leg_length), db.Walls10 * qty, WallList);
                            HandleList(string.Format("Murs 15 pieds, plain, Fiesta, {0}", leg_length), db.Walls15 * qty, WallList);
                            HandleList(string.Format("Murs 20 pieds, plain, Fiesta, {0}", leg_length), db.Walls20 * qty, WallList);
                            break;
                        case "Full Window Fiesta":
                            HandleList(string.Format("Murs 10 pieds, window, Fiesta, {0}", leg_length), db.Walls10 * qty, WallList);
                            HandleList(string.Format("Murs 15 pieds, window, Fiesta, {0}", leg_length), db.Walls15 * qty, WallList);
                            HandleList(string.Format("Murs 20 pieds, window, Fiesta, {0}", leg_length), db.Walls20 * qty, WallList);
                            break;
                        case "Half Plain Half Window Fiesta":
                            HandleList(string.Format("Murs 10 pieds, plain, Fiesta, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 15 pieds, plain, Fiesta, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 20 pieds, plain, Fiesta, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 10 pieds, window, Fiesta, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 15 pieds, window, Fiesta, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 20 pieds, window, Fiesta, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            break;
                    }

                }
                else
                {
                    throw new Exception("Leg enum assigned null value");
                }

                //HandleList(string.Format("Cables {0}", ListOfLists.tentSizes[i]), qty, WallList);

                if (typeOfTent != UserInterface.Tent.Frame && typeOfTent != UserInterface.Tent.ClearSpan)
                {
                    if (ListOfLists.tentSizes[i] != "Hexagon")
                    {
                        string covers = string.Format("{0} {1}", ListOfLists.tentSizes[i], ListOfLists.tentCoverTypes[i]);
                        HandleList(covers, qty, CoverList);
                    }
                    else
                    {
                        HandleList(string.Format("Hex {0}", ListOfLists.tentCoverTypes[i]),qty,CoverList);
                    }
                    
                }
                
            }

            DataHandler.printAllLists(MetalItemList,WallList,CoverList,HoldDownList);
            counts.Covers = CoverList;
            counts.Metal = MetalItemList;
            counts.TieDowns = HoldDownList;
            counts.Walls = WallList;

            //// Serialize the list
            //var serializer = new XmlSerializer(counts.GetType());
            //using (var writer = XmlWriter.Create("list.xml"))
            //{
            //    serializer.Serialize(writer, counts);
            //}

            return counts;

        }

        private static IEnumerable<Database> ReadTentDatabase<Database>(UserInterface.Tent typeOfTent)
        {

            string filename = null;
           
            switch (typeOfTent)
            {
                case UserInterface.Tent.Small:
                    filename = @"../../SmallTents.csv";
                    break;
                case UserInterface.Tent.Large:
                    filename = @"../../LargeTents.csv";
                    break;
                case UserInterface.Tent.Frame:
                    filename = @"../../Frames.csv";
                    break;
                case UserInterface.Tent.ClearSpan:
                    filename = @"../../ClearSpans.csv";
                    break;
            }

            // Initiate a reader
            System.IO.StreamReader reader = new System.IO.StreamReader(filename);

            // Initiate CSVHelper's CSV Reader
            var csv = new CsvReader(reader);

            // Get the records in the CSV file according to class SmallTentDB
            var records = csv.GetRecords<Database>();

            return records;

        }

        // Temporary function to print lists to command line for debugging instead of generating a PDF
        public static void printAllLists(List<TentItems> Metal, List<TentItems> Walls, List<TentItems> Covers, List<TentItems> HoldDowns)
        {
            Console.WriteLine("///////////////////////////////////////////////////////////////////////");
            Console.WriteLine("-------------METAL------------");
            Metal.ForEach(l => Console.WriteLine(string.Format("{0} --> Quantity {1}", l.Type, l.Qty)));
            Console.WriteLine("-------------WALLS------------");
            Walls.ForEach(l => Console.WriteLine(string.Format("{0} --> Quantity {1}", l.Type, l.Qty)));
            Console.WriteLine("------------COVERS------------");
            Covers.ForEach(l => Console.WriteLine(string.Format("{0} --> Quantity {1}", l.Type, l.Qty)));
            Console.WriteLine("------------HOLDDOWNS---------");
            HoldDowns.ForEach(l => Console.WriteLine(string.Format("{0} --> Quantity {1}", l.Type, l.Qty)));
            Console.WriteLine("///////////////////////////////////////////////////////////////////////");
        }
        
        private static Database GetDataBaseRow<Database>(IEnumerable<Database> db, string size)
            where Database : DatabaseInterface
        {
            foreach (var row in db)
            {
                if (row.Size == size)
                {
                    return row;
                }
            }

            return default(Database);
        }
        
        private static void HandleList(string item, int quantity, List<TentItems> list)
        {
            // If item is not in the list and quantity is not 0
            if (!list.Any(e => e.Type == item) && quantity != 0)
            {
                // Add it to the list
                list.Add(new TentItems(item, quantity));
#if DEBUG
                //Console.WriteLine(string.Format("{0} --> Quantity: {1}", item, quantity));
#endif
            }
            // Else, if the item is already in the list and quantity is not 0
            else if (list.Any(e => (e.Type == item) && (e.Qty > 0)))
            {
                // Get the object from the list and update the quantity
                var obj = list.Find(e => e.Type == item);
                obj.Qty += quantity;
#if DEBUG
                //Console.WriteLine(string.Format("{0} --> Quantity: {1}", item, quantity));
#endif
            }
            
        }


    }
}
