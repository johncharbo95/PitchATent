using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

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
        public int Barrels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Concrete250 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Concrete400 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Concrete600 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ConcreteHalfTon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    #endregion

    public class DataHandler
    {
        public enum Legs { shortLegs, longLegs, none};

        public static void CountTents(ref ListNames ListOfLists)
        {
            // Declare lists of TentItems
            List<TentItems> MetalItemList = new List<TentItems>();
            List<TentItems> WallList = new List<TentItems>();
            List<TentItems> CoverList = new List<TentItems>();
            List<TentItems> HoldDownList = new List<TentItems>();

            // Read databases. This returns the full database as IEnumerable type.
            var SmallDB = ReadTentDatabase<SmallTentDB>(UserInterface.Tent.Small);
            var LargeDB = ReadTentDatabase<LargeTentDB>(UserInterface.Tent.Large);
            // TODO: Add frame and clearspan classes.

            // Declare variables.
            Legs leg = Legs.none;
            string legTentType = null;
            DatabaseInterface db = null;

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
                        legTentType = "pour petites tentes";

                        // Get the appropriate row from the small tent database, depending on the size of the tent.
                        SmallTentDB SmallRow = GetDataBaseRow<SmallTentDB>(SmallDB, size);
                        db = SmallRow;
                        if (SmallRow != null)
                        {
                            // Metal list
                            // TODO: string builder for legs, cable, poteau de milieu
                            HandleList("Pipe", SmallRow.Pipe * qty, MetalItemList);
                            HandleList("Pipe 5ft", SmallRow.Pipe5 * qty, MetalItemList);
                            HandleList("T - 20x30/20x40", SmallRow.SmallTee * qty, MetalItemList);
                            HandleList("T - 30x30", SmallRow.LargeTee * qty, MetalItemList);
                            HandleList("Entures", SmallRow.Enture * qty, MetalItemList);
                            HandleList("Coins", SmallRow.Corner * qty, MetalItemList);
                            HandleList("Brace", SmallRow.Brace * qty, MetalItemList);
                        }
                        else
                        {
                            throw new System.ArgumentNullException("Small Tent Database Object");
                        }
                        break;

                    case UserInterface.Tent.Large:
                        legTentType = "pour grosses tentes";

                        // Get the appropriate row from the large tent database, depending on the size of the tent.
                        LargeTentDB LargeRow = GetDataBaseRow<LargeTentDB>(LargeDB, size);
                        db = LargeRow;
                        break;

                    case UserInterface.Tent.Frame:
                        db = null;
                        break;

                    case UserInterface.Tent.ClearSpan:
                        db = null;
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
                        HandleList("Pattes Hexagone", db.Legs * qty, MetalItemList);
                    }
                }

                // This can definitely be optimized but it works...
                // Insert walls in list.
                if (leg == Legs.shortLegs)
                {
                    switch (ListOfLists.tentWalls[i])
                    {
                        case "Full Plain":
                            HandleList("Murs 10 pieds, plain", db.Walls10 * qty, WallList);
                            HandleList("Murs 15 pieds, plain", db.Walls15 * qty, WallList);
                            HandleList("Murs 20 pieds, plain", db.Walls20 * qty, WallList);
                            break;
                        case "Full Window":
                            HandleList("Murs 10 pieds, window", db.Walls10 * qty, WallList);
                            HandleList("Murs 15 pieds, window", db.Walls15 * qty, WallList);
                            HandleList("Murs 20 pieds, window", db.Walls20 * qty, WallList);
                            break;
                        case "Half Plain Half Window":
                            HandleList("Murs 10 pieds, plain", (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList("Murs 15 pieds, plain", (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList("Murs 20 pieds, plain", (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            HandleList("Murs 10 pieds, window", (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList("Murs 15 pieds, window", (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList("Murs 20 pieds, window", (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            break;
                        case "Full Plain Fiesta":
                            HandleList("Murs 10 pieds, plain, Fiesta", db.Walls10 * qty, WallList);
                            HandleList("Murs 15 pieds, plain, Fiesta", db.Walls15 * qty, WallList);
                            HandleList("Murs 20 pieds, plain, Fiesta", db.Walls20 * qty, WallList);
                            break;
                        case "Full Window Fiesta":
                            HandleList("Murs 10 pieds, window, Fiesta", db.Walls10 * qty, WallList);
                            HandleList("Murs 15 pieds, window, Fiesta", db.Walls15 * qty, WallList);
                            HandleList("Murs 20 pieds, window, Fiesta", db.Walls20 * qty, WallList);
                            break;
                        case "Half Plain Half Window Fiesta":
                            HandleList("Murs 10 pieds, plain, Fiesta", (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList("Murs 15 pieds, plain, Fiesta", (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList("Murs 20 pieds, plain, Fiesta", (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            HandleList("Murs 10 pieds, window, Fiesta", (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList("Murs 15 pieds, window, Fiesta", (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList("Murs 20 pieds, window, Fiesta", (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            break;
                    }

                }
                else if (leg == Legs.longLegs)
                {
                    switch (ListOfLists.tentWalls[i])
                    {
                        case "Full Plain":
                            HandleList("Murs 10 pieds, plain, pour pattes de 10 pieds", db.Walls10 * qty, WallList);
                            HandleList("Murs 15 pieds, plain, pour pattes de 10 pieds", db.Walls15 * qty, WallList);
                            HandleList("Murs 20 pieds, plain, pour pattes de 10 pieds", db.Walls20 * qty, WallList);
                            break;
                        case "Full Window":
                            HandleList("Murs 10 pieds, window, pour pattes de 10 pieds", db.Walls10 * qty, WallList);
                            HandleList("Murs 15 pieds, window, pour pattes de 10 pieds", db.Walls15 * qty, WallList);
                            HandleList("Murs 20 pieds, window, pour pattes de 10 pieds", db.Walls20 * qty, WallList);
                            break;
                        case "Half Plain Half Window":
                            HandleList("Murs 10 pieds, plain, pour pattes de 10 pieds", (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList("Murs 15 pieds, plain, pour pattes de 10 pieds", (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList("Murs 20 pieds, plain, pour pattes de 10 pieds", (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            HandleList("Murs 10 pieds, window, pour pattes de 10 pieds", (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList("Murs 15 pieds, window, pour pattes de 10 pieds", (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList("Murs 20 pieds, window, pour pattes de 10 pieds", (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            break;
                        default:
                            throw new Exception("Fiesta walls are not available for tents with 10 ft legs");
                    }
                }
                else
                {
                    throw new Exception("Leg enum assigned null value");
                }

                string cables = string.Format("Cables {0}", ListOfLists.tentSizes[i]);
                HandleList(cables, qty, WallList);

                string covers = string.Format("Cover {0} {1}", ListOfLists.tentSizes[i], ListOfLists.tentCoverTypes[i]);
                HandleList(covers, qty, CoverList);
            }

            DataHandler.printAllLists(MetalItemList,WallList,CoverList,HoldDownList);

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


        private static IEnumerable<Database> ReadTentDatabase<Database>(UserInterface.Tent typeOfTent)
        {
            
            string filename = null;
            switch (typeOfTent)
            {
                case UserInterface.Tent.Small:
                    filename = @"C:\Users\OFFICE19\source\repos\PitchATent\PitchATent\SmallTents.csv";
                    break;
                case UserInterface.Tent.Large:
                    Console.WriteLine("No database yet");
                    break;
                case UserInterface.Tent.Frame:
                    Console.WriteLine("No database yet");
                    break;
                case UserInterface.Tent.ClearSpan:
                    Console.WriteLine("No database yet");
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
