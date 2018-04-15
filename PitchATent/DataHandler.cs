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
    /// <summary>
    /// Classes with purpose of being used in lists.
    /// </summary>
    public class Covers
    {
        // Constructor
        public Covers(string size, string type, int qty)
        {
            this.Size = size;
            this.Type = type;
            this.Qty = qty;
        }

        public string Size { get; set; }
        public string Type { get; set; }
        public int Qty { get; set; }
    }

    public class HoldDowns
    {
        public HoldDowns(string type, int qty)
        {
            this.Type = type;
            this.Qty = qty;
        }
        public string Type { get; set; }
        public int Qty { get; set; }
    }
    
    public class Walls
    {
        public Walls(string type, int height, int width, int qty)
        {
            this.Type = type;
            this.Height = height;
            this.Width = width;
            this.Qty = qty;
        }
        public string Type { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Qty { get; set; }
    }

    public class Legs
    {
        public Legs(string type, int height, int qty)
        {
            this.Type = type;
            this.Height = height;
            this.Qty = qty;
        }
        
        public string Type { get; set; }
        public int Height { get; set; }
        public int Qty { get; set; }
    }

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

    public class SmallTentDB
    {
        /*
        public SmallTentDB(string size, int pipe, int pipe5, int smallTee, int largeTee, int enture,
            int corner, int brace, int legs, int cable, int middlePost, int pinsW, int pinsR, int barrels,
            int concrete250, int concrete400, int concrete600, int concreteHalfTon, int concreteTon,
            int comeAlong, int walls10, int walls15, int walls20)
        {
            this.Size = size;
            this.Pipe = pipe;
            this.Pipe5 = pipe5;
            this.SmallTee = smallTee;
            this.LargeTee = LargeTee;
            this.Enture = enture;
            this.Corner = corner;
            this.Brace = brace;
            this.Legs = legs;
            this.Cable = cable;
            this.MiddlePost = middlePost;
            this.PinsW = pinsW;
            this.PinsR = pinsR;
            this.Barrels = barrels;
            this.Concrete250 = concrete250;
            this.Concrete400 = concrete400;
            this.Concrete600 = concrete600;
            this.ConcreteHalfTon = concreteHalfTon;
            this.ConcreteTon = concreteTon;
            this.ComeAlong = comeAlong;
            this.Walls10 = walls10;
            this.Walls15 = walls15;
            this.Walls20 = walls20;
        }
        */
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

            // Loop through all tents
            for (int i = 0; i < ListOfLists.tentType.Count; ++i)
            {
                // Get the quantity of that particular tent
                int qty = ListOfLists.tentQties[i];

                // Get the cover size and type of tent
                string size = ListOfLists.tentSizes[i];
                UserInterface.Tent typeOfTent = ListOfLists.tentType[i];

                // Send the size to the ReadDatabase function and return an object with the values
                var db = ReadTentDatabase(size);

                // Depending on the type of tent, load database and retrieve values
                switch (ListOfLists.tentType[i])
                {
                    case UserInterface.Tent.Small:
                        
                        if (db != null)
                        {
                            // Metal list
                            // TODO: string builder for legs, cable, poteau de milieu
                            HandleList("Pipe", db.Pipe, MetalItemList);
                            HandleList("Pipe 5ft", db.Pipe5, MetalItemList);
                            HandleList("T - 20x30/20x40", db.SmallTee, MetalItemList);
                            HandleList("T - 30x30", db.LargeTee, MetalItemList);
                            HandleList("Entures", db.Enture, MetalItemList);
                            HandleList("Coins", db.Corner, MetalItemList);
                            HandleList("Brace", db.Brace, MetalItemList);
                        }
                        else
                        {
                            throw new System.ArgumentNullException("Small Tent Database Object");
                        }
                        break;

                    case UserInterface.Tent.Large:
                        break;

                    case UserInterface.Tent.Frame:
                        break;

                    case UserInterface.Tent.ClearSpan:
                        break;
                }

                // Hold Down list
                switch (ListOfLists.tentHoldDowns[i])
                {
                    case "Pins":
                        HandleList("White Pins", db.PinsW, HoldDownList);
                        HandleList("Red Pins", db.PinsR, HoldDownList);
                        break;
                    case "Water Barrels":
                        HandleList("Water Barrels", db.Barrels, HoldDownList);
                        break;
                    case "250 lb Concrete Block":
                        HandleList("250 lb Concrete Block", db.Concrete250, HoldDownList);
                        break;
                    case "400 lb Concrete Block":
                        HandleList("400 lb Concrete Block", db.Concrete400, HoldDownList);
                        break;
                    case "600 lb Concrete Block":
                        HandleList("600 lb Concrete Block", db.Concrete600, HoldDownList);
                        break;
                    case "1/2 ton Concrete Block":
                        HandleList("1/2 ton Concrete Block", db.ConcreteHalfTon, HoldDownList);
                        break;
                    case "1 ton Concrete Block":
                        HandleList("1 ton Concrete Block", db.ConcreteTon, HoldDownList);
                        break;
                }
                //Comealongs
                HandleList("Come Along", db.ComeAlong, HoldDownList);

                // Walls and legs list (codependant)
                Legs leg = Legs.none;
                switch (ListOfLists.tentLegs[i])
                {
                    case "8 ft":
                        HandleList("Pattes 8 pieds", db.Legs, MetalItemList);
                        leg = Legs.shortLegs;
                        break;
                    case "8 ft Adjustable":
                        HandleList("Pattes 8 pieds ajustable", db.Legs, MetalItemList);
                        leg = Legs.shortLegs;
                        break;
                    case "10 ft":
                        HandleList("Pattes 10 pieds", db.Legs, MetalItemList);
                        leg = Legs.longLegs;
                        break;
                    case "10 ft Adjustable":
                        HandleList("Pattes 10 pieds ajustable", db.Legs, MetalItemList);
                        leg = Legs.longLegs;
                        break;
                    case "Hexagon":
                        // If the size of the cover selected is not hexagon, throw an error.
                        if (ListOfLists.tentSizes[i] != "Hexagon")
                        {
                            throw new Exception("Hexagon legs were chosen, but the cover type for this tent is Hexagon.");
                        }
                        else
                        {
                            HandleList("Pattes Hexagone", db.Legs, MetalItemList);
                            HandleList("Murs 20 pieds", db.Walls20, WallList);
                        }
                        break;
                }

                if (leg == Legs.shortLegs)
                {
                    HandleList("Murs 10 pieds", db.Walls10, WallList);
                    HandleList("Murs 15 pieds", db.Walls15, WallList);
                    HandleList("Murs 20 pieds", db.Walls20, WallList);
                }
                else if (leg == Legs.longLegs)
                {
                    HandleList("Murs 10 pieds, pour pattes de 10 pieds", db.Walls10, WallList);
                    HandleList("Murs 15 pieds, pour pattes de 10 pieds", db.Walls15, WallList);
                    HandleList("Murs 20 pieds, pour pattes de 10 pieds", db.Walls20, WallList);
                }
                else
                {
                    throw new Exception("Leg enum assigned null value");
                }
                // Get counts of tent sizes by cover types


                // Get counts of hold downs

                // Get counts of walls

                // Get counts of legs

                // Get counts of special things depending on type of tent (entures, coins, etc...)
            }


        }
        private static SmallTentDB ReadTentDatabase(string size)
        {
            // Initiate a reader
            string filename = @"C:\Users\OFFICE19\source\repos\PitchATent\PitchATent\SmallTents.csv";
            System.IO.StreamReader reader = new System.IO.StreamReader(filename);

            // Initiate CSVHelper's CSV Reader
            var csv = new CsvReader(reader);

            // Get the records in the CSV file according to class SmallTentDB
            var records = csv.GetRecords<SmallTentDB>();

            // Loop through the records
            foreach (var record in records)
            {

                // If the size field in the record matches the function parameter, return the object.
                if (record.Size == size)
                {
                    var db = record;
                    return db;
                }
            }

            // If there was no match, return null
            return null;
            
        }

        private static void HandleList(string item, int quantity, List<TentItems> list)
        {
            // If item is not in the list and quantity is not 0
            if (!list.Any(e => e.Type == item) && quantity != 0)
            {
                // Add it to the list
                list.Add(new TentItems(item, quantity));
            }
            // Else, if the item is already in the list and quantity is not 0
            else if (list.Any(e => (e.Type == item) && (e.Qty > 0)))
            {
                // Get the object from the list and update the quantity
                var obj = list.Find(e => e.Type == item);
                obj.Qty += quantity;
            }
            
        }


    }
}
