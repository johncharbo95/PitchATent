using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace PitchATent
{
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
            IDatabase db = new SmallTentDB();

            IEnumerable<SmallTentDB> SmallDB = ReadTentDatabase<SmallTentDB>(UserInterface.Tent.Small);
            List<SmallTentDB> Small = SmallDB.ToList();
            IEnumerable<LargeTentDB> LargeDB = ReadTentDatabase<LargeTentDB>(UserInterface.Tent.Large);
            List<LargeTentDB> Large = LargeDB.ToList();
            IEnumerable<FrameDB> FrameDB = ReadTentDatabase<FrameDB>(UserInterface.Tent.Frame);
            List<FrameDB> Frame = FrameDB.ToList();
            IEnumerable<ClearSpanDB> ClearSpanDB = ReadTentDatabase<ClearSpanDB>(UserInterface.Tent.ClearSpan);
            List<ClearSpanDB> ClearSpan = ClearSpanDB.ToList();

            // Loop through all tents
            for (int i = 0; i < ListOfLists.tentType.Count; ++i)
            {

                // Get the quantity of that particular tent
                int qty = ListOfLists.tentQties[i];

                // Get the cover size, type of cover and type of tent
                string size = ListOfLists.tentSizes[i];
                UserInterface.Tent typeOfTent = ListOfLists.tentType[i];
                string coverType = ListOfLists.tentCoverTypes[i];

                // Depending on the type and size of tent, get the appropriate row in the database.
                switch (ListOfLists.tentType[i])
                {
                    case UserInterface.Tent.Small:
                        {
                            legTentType = "ST";

                            // Get the appropriate row from the small tent database, depending on the size of the tent.
                            SmallTentDB SmallRow = Small.Find(b => b.Size == size);
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
                                    HandleList("Hexagone", qty, CoverList);
                                }
                                else
                                {
                                    HandleList("Coins", SmallRow.Corner * qty, MetalItemList);
                                    HandleList(SmallRow.Size + " " + coverType, qty, CoverList);
                                }
                                HandleList("Brace - 30", SmallRow.Brace * qty, MetalItemList);
                                HandleList(string.Format("PM {0}", size), SmallRow.MiddlePost * qty, MetalItemList);
                                HandleList(string.Format("Cables {0}", size), SmallRow.Cable * qty, WallList);
                            }
                        }
                        break;

                    case UserInterface.Tent.Large:
                        legTentType = "BT";

                        // Get the appropriate row from the large tent database, depending on the size of the tent.
                        LargeTentDB LargeRow = Large.Find(b => b.Size == size);
                        db = LargeRow;

                        if (LargeRow != null)
                        {
                            HandleList(string.Format("PM {0}", size.Substring(0, 2)), LargeRow.MiddlePost * qty, MetalItemList);
                            HandleList("Plates", LargeRow.Plates * qty, MetalItemList);
                            HandleList(string.Format("Mid {0}' x 20' {1}",size.Substring(0,2), coverType), LargeRow.Mid20 * qty, CoverList);
                            HandleList(string.Format("Mid {0}' x 30' {1}", size.Substring(0,2), coverType), LargeRow.Mid30 * qty, CoverList);
                            HandleList(string.Format("End {0}' {1}", size.Substring(0,2), coverType), 2 * qty, CoverList);
                        }
                        break;

                    case UserInterface.Tent.Frame:
                        // Get the appropriate row from the frame database, depending on the size of the tent.
                        FrameDB FrameRow = Frame.Find(b => b.Size == size);
                        db = FrameRow;

                        if (FrameRow != null)
                        {
                            // TODO: Handle mids and ends after database is fixed
                            HandleList("Mid 10' " + coverType, FrameRow.Cover10 * qty, CoverList);
                            HandleList("Mid 15' " + coverType, FrameRow.Cover15 * qty, CoverList);
                            HandleList("End Frame " + coverType, qty, CoverList);
                        }

                        break;

                    case UserInterface.Tent.ClearSpan:
                        // Get the appropriate row from the ClearSpan database, depending on the size of the tent.
                        ClearSpanDB ClearSpanRow = ClearSpan.Find(b => b.Size == size);
                        db = ClearSpanRow;

                        // Get the width of the ClearSpan
                        int ClearSpanWidth = Convert.ToInt32(size.Substring(0, 2));                       

                        if (ClearSpanRow != null)
                        {
                            HandleList(string.Format("ClearSpan {0}' x 10' {1}", ClearSpanWidth.ToString(), coverType), ClearSpanRow.Cover10 * qty, CoverList);
                            HandleList(string.Format("ClearSpan {0}' x 15' {1}", ClearSpanWidth.ToString(), coverType), ClearSpanRow.Cover15 * qty, CoverList);
                            
                            switch(ClearSpanWidth)
                            {
                                case 30:
                                    HandleList("Triangle 30'", ClearSpanRow.Triangle * qty, CoverList);
                                    break;
                                case 40:
                                    HandleList("Triangle 40'", ClearSpanRow.Triangle * qty, CoverList);
                                    break;
                                case 50:
                                    HandleList("Triangle 50'", ClearSpanRow.Triangle * qty, CoverList);
                                    break;
                            }

                            if (ListOfLists.tentWalls[i] != "None")
                            {
                                switch (ListOfLists.tentWalls[i])
                                {
                                    case "Full Plain":
                                        HandleList("Mur CSP 10'", ClearSpanRow.CSPWalls10 * qty, WallList);
                                        HandleList("Mur CSP 15'", ClearSpanRow.CSPWalls15 * qty, WallList);
                                        HandleList("Mur CSP 20'", ClearSpanRow.CSPWalls20 * qty, WallList);
                                        break;
                                    case "Full Bay Window":
                                        HandleList("Mur CSP 10' Bay", ClearSpanRow.CSPWalls10 * qty, WallList);
                                        HandleList("Mur CSP 15' Bay", ClearSpanRow.CSPWalls15 * qty, WallList);
                                        HandleList("Mur CSP 20' Bay", ClearSpanRow.CSPWalls20 * qty, WallList);
                                        break;
                                    case "Full French Window":
                                        HandleList("Mur CSP 10' FW", ClearSpanRow.CSPWalls10 * qty, WallList);
                                        HandleList("Mur CSP 15' FW", ClearSpanRow.CSPWalls15 * qty, WallList);
                                        HandleList("Mur CSP 20' FW", ClearSpanRow.CSPWalls20 * qty, WallList);
                                        break;
                                    case "Half Plain Half Bay Window":
                                        HandleList("Mur CSP 10'", (int)System.Math.Ceiling((double)ClearSpanRow.CSPWalls10 / 2) * qty, WallList);
                                        HandleList("Mur CSP 15'", (int)System.Math.Ceiling((double)ClearSpanRow.CSPWalls15 / 2) * qty, WallList);
                                        HandleList("Mur CSP 20'", (int)System.Math.Ceiling((double)ClearSpanRow.CSPWalls20 / 2) * qty, WallList);
                                        HandleList("Mur CSP 10' Bay", (int)System.Math.Ceiling((double)ClearSpanRow.CSPWalls10 / 2) * qty, WallList);
                                        HandleList("Mur CSP 15' Bay", (int)System.Math.Ceiling((double)ClearSpanRow.CSPWalls15 / 2) * qty, WallList);
                                        HandleList("Mur CSP 20' Bay", (int)System.Math.Ceiling((double)ClearSpanRow.CSPWalls20 / 2) * qty, WallList);
                                        break;
                                }
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
                        HandleList("250 lb Block", db.Concrete250 * qty, HoldDownList);
                        break;
                    case "400 lb Concrete Block":
                        HandleList("400 lb Block", db.Concrete400 * qty, HoldDownList);
                        break;
                    case "600 lb Concrete Block":
                        HandleList("600 lb Block", db.Concrete600 * qty, HoldDownList);
                        break;
                    case "1/2 ton Concrete Block":
                        HandleList("1/2 ton Block", db.ConcreteHalfTon * qty, HoldDownList);
                        break;
                    case "1 ton Concrete Block":
                        HandleList("1 ton Block", db.ConcreteTon * qty, HoldDownList);
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
                        // Assign shortLegs enum to leg variable because hex tents have 8' high walls...
                        leg = Legs.shortLegs;
                        HandleList("Pattes Hex", db.Legs * qty, MetalItemList);
                    }
                }

                // This can definitely be optimized but it works...
                // Insert walls in list.
                if (leg != Legs.none && ListOfLists.tentWalls[i] != "None")
                {

                    string leg_length = null;
                    if (leg == Legs.longLegs)
                    {
                        leg_length = ", 10'";
                    }

                    switch (ListOfLists.tentWalls[i])
                    {
                        case "Full Plain":
                            HandleList(string.Format("Murs 10' P{0}", leg_length), db.Walls10 * qty, WallList);
                            HandleList(string.Format("Murs 15' P{0}", leg_length), db.Walls15 * qty, WallList);
                            HandleList(string.Format("Murs 20' P{0}", leg_length), db.Walls20 * qty, WallList);
                            break;                           
                        case "Full Window":                  
                            HandleList(string.Format("Murs 10' W{0}", leg_length), db.Walls10 * qty, WallList);
                            HandleList(string.Format("Murs 15' W{0}", leg_length), db.Walls15 * qty, WallList);
                            HandleList(string.Format("Murs 20' W{0}", leg_length), db.Walls20 * qty, WallList);
                            break;                           
                        case "Half Plain Half Window":       
                            HandleList(string.Format("Murs 10' P{0}", leg_length), (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 15' P{0}", leg_length), (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 20' P{0}", leg_length), (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 10' W{0}", leg_length), (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 15' W{0}", leg_length), (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 20' W{0}", leg_length), (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            break;                           
                        case "Full Plain Fiesta":            
                            HandleList(string.Format("Murs 10' PF, {0}", leg_length), db.Walls10 * qty, WallList);
                            HandleList(string.Format("Murs 15' PF, {0}", leg_length), db.Walls15 * qty, WallList);
                            HandleList(string.Format("Murs 20' PF, {0}", leg_length), db.Walls20 * qty, WallList);
                            break;                           
                        case "Full Window Fiesta":           
                            HandleList(string.Format("Murs 10' WF, {0}", leg_length), db.Walls10 * qty, WallList);
                            HandleList(string.Format("Murs 15' WF, {0}", leg_length), db.Walls15 * qty, WallList);
                            HandleList(string.Format("Murs 20' WF, {0}", leg_length), db.Walls20 * qty, WallList);
                            break;                           
                        case "Half Plain Half Window Fiesta":
                            HandleList(string.Format("Murs 10' PF, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 15' PF, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 20' PF, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 10' WF, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls10 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 15' WF, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls15 / 2) * qty, WallList);
                            HandleList(string.Format("Murs 20' WF, {0}", leg_length), (int)System.Math.Ceiling((double)db.Walls20 / 2) * qty, WallList);
                            break;
                    }

                }

            }

            // Collect all the lists into the "counts" object to be returned.
            counts.Covers = CoverList;
            counts.Metal = MetalItemList;
            counts.TieDowns = HoldDownList;
            counts.Walls = WallList;
            
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
