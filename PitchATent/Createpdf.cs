using System;
using System.Globalization;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;
using System.Diagnostics;
//
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using MigraDoc;
using MigraDoc.RtfRendering;

namespace PitchATent
{
    public class Createpdf
    {
        // Default Constructor
        public Createpdf() { }

        public Createpdf(string truck, string trailer, string driver, ItemCounts counts)
        {
            this.Truck = truck;
            this.Trailer = trailer;
            this.Driver = driver;
            this.Counts = counts;
        }
        public Createpdf(string truck, string trailer, string driver, ItemCounts counts,List<Accessory> acc)
        {
            this.Truck = truck;
            this.Trailer = trailer;
            this.Driver = driver;
            this.Counts = counts;
            this.Acc = acc;
        }
        public string Truck { get; set; }
        public string Trailer { get; set; }
        public string Driver { get; set; }
        public ItemCounts Counts { get; set; }
        public List<Accessory> Acc { get; set; }

        /// <summary>
        /// The MigraDoc document that represents the invoice.
        /// </summary>
        Document document;
        /// <summary>
        /// The text frame of the MigraDoc document that contains the address.
        /// </summary>
        TextFrame addressFrame;
        /// <summary>
        /// The table of the MigraDoc document that contains the invoice items.
        /// </summary>
        Table table;
        Table table1;

        //------//-----------//----------//---------//----------//----------//--------//
        /// <summary>
        /// Creates the invoice document.
        /// </summary>
        public Document CreateDocument()
        {
            // Create a new MigraDoc document
            this.document = new Document();
            this.document.Info.Title = "test sheet alex";
            this.document.Info.Subject = "Demonstrates how to create an invoice.";
            this.document.Info.Author = "Alexandre Vendette";

            DefineStyles();

            CreatePage();

            // FillContent();

            return this.document;
        }
        //------//-----------//----------//---------//----------//----------//--------//
        void DefineStyles()
        {
            // Get the predefined style Normal.
            Style style = this.document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Calibri";

            style = this.document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = this.document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = this.document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Calibri";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 12;

            // Create a new style called Reference based on style Normal
            style = this.document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        //------//-----------//----------//---------//----------//----------//--------//

        /// <summary>
        /// Creates the static parts of the invoice.
        /// </summary>
        void CreatePage()
        {
            string date = DateTime.Now.ToString(); // dont think i need this line anymore 

            // Each MigraDoc document needs at least one section.
            Section section = this.document.AddSection();

            //----------------------------------------------------------------------------

            // Put a logo in the header
            Image image = section.Headers.Primary.AddImage("../../logo2.png");
            image.Width = "18cm";
            image.LockAspectRatio = false;
            //image.Height = "2.5cm";
            image.RelativeVertical = RelativeVertical.Line;
            image.RelativeHorizontal = RelativeHorizontal.Margin;
            image.Top = ShapePosition.Top;
            image.Left = ShapePosition.Left;
            image.WrapFormat.Style = WrapStyle.Through;

            //----------------------------------------------------------------------------

            // Create footer
            Paragraph paragraph = section.Footers.Primary.AddParagraph();
            paragraph.AddText("Charbonneau Vendette Solutions ");
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            //----------------------------------------------------------------------------

            // Create the text frame for the address
            this.addressFrame = section.AddTextFrame();
            this.addressFrame.Height = "3.0cm";
            this.addressFrame.Width = "7.0cm";
            this.addressFrame.Left = ShapePosition.Left;
            this.addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            this.addressFrame.Top = "3.5cm";
            this.addressFrame.RelativeVertical = RelativeVertical.Page;

            //----------------------------------------------------------------------------

            // Put sender in address frame
            paragraph = this.addressFrame.AddParagraph("     Tents For All Events");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Color = Colors.Black;
            paragraph.Format.Font.Size = 13;
            paragraph.Format.SpaceBefore = "0.075cm";
            paragraph.Format.SpaceAfter = 3;

            //----------------------------------------------------------------------------
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "2cm";
            paragraph.Style = "Reference";
            if (Driver == null)
            {
                paragraph.AddText("Driver: __________________");
            }
            else
            {
                paragraph.AddText(string.Format("Driver: {0}",Driver));
            }
            
            paragraph.AddTab();
            // TODO: Revisit exceptions (like not having a trailer)
            paragraph.AddText(string.Format("Truck {0}, Trailer {1}, ", Truck, Trailer));
            paragraph.AddDateField("dd.MM.yyyy");
            paragraph.Format.Font.Size = 14;

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "0.5cm";
            paragraph.Style = "Reference";
            paragraph.AddFormattedText("List Of Materials", TextFormat.Bold);
            paragraph.Format.Font.Size = 14;
            //paragraph.AddTab();
            

            //--------------------------------------------------------------------------//
            //------//-----------//----     Metal Table      -----//----------//--------//
            //--------------------------------------------------------------------------//
            
            // Create the item table
            this.table = section.AddTable();
            table.Rows.Alignment = RowAlignment.Center;
            this.table.Style = "Table";
            this.table.Borders.Color = Colors.Black;
            this.table.Borders.Width = 0.5;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("4.08cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            
            column = this.table.AddColumn("4.08cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            
            column = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("4.08cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.LightGray;

            // Makes the new rows for the Metal 
            row.Cells[0].AddParagraph("Metal");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].MergeRight = 8;

            // Get count of metal items
            int MetalTableSize = Counts.Metal.Count;

            // Extract metal list to small variable name ;)
            List<TentItems> metal = Counts.Metal;

            int b = 0;
            int r = 0;

            if (metal != null)
            {
                for (int i = 0; i < MetalTableSize; ++i)  //max number of rows for one page before cutting into other tings is 33 (or 32 for i)
                {

                    if (i == 0 || i % 3 == 0)
                    {
                        row = table.AddRow();
                        row.HeadingFormat = true;
                        row.Format.Alignment = ParagraphAlignment.Center;
                        row.Format.Font.Bold = true;
                        row.Shading.Color = Colors.White;
                        b = 0;
                        r++;
                    }


                    row.Cells[b].AddParagraph("□");
                    row.Cells[b].Format.Font.Bold = true;
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                    //row.Cells[0].MergeDown = 1;
                    b++;
                    row.Cells[b].AddParagraph(metal[i].Type);
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    //row.Cells[1].MergeRight = 0;
                    //row.Cells[1].MergeDown = 1;
                    b++;
                    row.Cells[b].AddParagraph(metal[i].Qty.ToString());
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                    //row.Cells[2].MergeDown = 1;
                    //row.Cells[b].Format.Borders.Right.Width = 2;
                    b++;
                }
            }
            this.table.SetEdge(0, 1, 3, r,Edge.Right, BorderStyle.Single, 1, Colors.Black);
            this.table.SetEdge(3, 1, 3, r, Edge.Right, BorderStyle.Single, 1, Colors.Black);
            this.table.SetEdge(0, 0, 9, r + 1, Edge.Box, BorderStyle.Single, 1, Colors.Black);

            //row = table.AddRow();
            //row.Borders.Visible = false;

            //--------------------------------------------------------------------------//
            //------//-----------//--    End Metal Table      ----//----------//--------//
            //--------------------------------------------------------------------------//

            //--------------------------------------------------------------------------//
            //------//-----------//----     Covers Table     -----//----------//--------//
            //--------------------------------------------------------------------------//

            // Create the item table
            this.table = section.AddTable();
            table.Rows.Alignment = RowAlignment.Center;
            this.table.Style = "Table";
            this.table.Borders.Color = Colors.Black;
            this.table.Borders.Width = 0.5;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column2 = this.table.AddColumn("0.5cm");
            column2.Format.Alignment = ParagraphAlignment.Center;

            column2 = this.table.AddColumn("4.08cm");
            column2.Format.Alignment = ParagraphAlignment.Right;

            column2= this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column2= this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column2= this.table.AddColumn("4.08cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column2= this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column2= this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column2= this.table.AddColumn("4.08cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column2= this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table
            Row row2 = table.AddRow();
            row2.HeadingFormat = true;
            row2.Format.Alignment = ParagraphAlignment.Center;
            row2.Format.Font.Bold = true;
            row2.Shading.Color = Colors.LightGray;

            row2.Cells[0].AddParagraph("Covers");
            row2.Cells[0].Format.Font.Bold = true;
            row2.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row2.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row2.Cells[0].MergeRight = 8;

            // Extract to smaller variable name
            List<TentItems> cover = Counts.Covers;

            // Get the size
            int CoverTableSize = cover.Count;

            // Reset b to zero
            b = 0;
            r = 0;

            if (cover != null)
            {
                for (int i = 0; i < CoverTableSize; ++i)  //max number of rows for one page before cutting into other tings is 33 (or 32 for i)
                {

                    if (i == 0 || i % 3 == 0)
                    {
                        row = table.AddRow();
                        row.HeadingFormat = true;
                        row.Format.Alignment = ParagraphAlignment.Center;
                        row.Format.Font.Bold = true;
                        row.Shading.Color = Colors.White;
                        b = 0;
                        r++;
                    }


                    row.Cells[b].AddParagraph("□");
                    row.Cells[b].Format.Font.Bold = true;
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                    //row.Cells[0].MergeDown = 1;
                    b++;
                    row.Cells[b].AddParagraph(cover[i].Type);
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    //row.Cells[1].MergeRight = 0;
                    //row.Cells[1].MergeDown = 1;
                    b++;
                    row.Cells[b].AddParagraph(cover[i].Qty.ToString());
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                    //row.Cells[2].MergeDown = 1;
                    b++;
                }
                this.table.SetEdge(0, 1, 3, r, Edge.Right, BorderStyle.Single, 1, Colors.Black);
                this.table.SetEdge(3, 1, 3, r, Edge.Right, BorderStyle.Single, 1, Colors.Black);
                this.table.SetEdge(0, 0, 9, r + 1, Edge.Box, BorderStyle.Single, 1, Colors.Black);

                //adds an invisible row to space out the two tables 
                //row2 = table.AddRow();
                //row2.Borders.Visible = false;
            }

            //--------------------------------------------------------------------------//
            //------//-----------//----     Walls  Table     -----//----------//--------//
            //--------------------------------------------------------------------------//

            // Create the item table
            this.table = section.AddTable();
            table.Rows.Alignment = RowAlignment.Center;
            this.table.Style = "Table";
            this.table.Borders.Color = Colors.Black;
            this.table.Borders.Width = 0.5;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column3 = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column3= this.table.AddColumn("4.08cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column3= this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column3= this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column3 = this.table.AddColumn("4.08cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column3 = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column3 = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column3 = this.table.AddColumn("4.08cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column3 = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table
            Row row3 = table.AddRow();
            row3.HeadingFormat = true;
            row3.Format.Alignment = ParagraphAlignment.Center;
            row3.Format.Font.Bold = true;
            row3.Shading.Color = Colors.LightGray;

            row3.Cells[0].AddParagraph("Walls");
            row3.Cells[0].Format.Font.Bold = true;
            row3.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row3.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row3.Cells[0].MergeRight = 8;

            // Extract to smaller variable name
            List<TentItems> walls = Counts.Walls;

            // Get the size
            int WallsTableSize = walls.Count;

            // Reset b to zero
            b = 0;
            r = 0;

            if (cover != null)
            {
                for (int i = 0; i < WallsTableSize; ++i)  //max number of rows for one page before cutting into other tings is 33 (or 32 for i)
                {

                    if (i == 0 || i % 3 == 0)
                    {
                        row = table.AddRow();
                        row.HeadingFormat = true;
                        row.Format.Alignment = ParagraphAlignment.Center;
                        row.Format.Font.Bold = true;
                        row.Shading.Color = Colors.White;
                        b = 0;
                        r++;
                    }


                    row.Cells[b].AddParagraph("□");
                    row.Cells[b].Format.Font.Bold = true;
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                    //row.Cells[0].MergeDown = 1;
                    b++;
                    row.Cells[b].AddParagraph(walls[i].Type);
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    //row.Cells[1].MergeRight = 0;
                    //row.Cells[1].MergeDown = 1;
                    b++;
                    row.Cells[b].AddParagraph(walls[i].Qty.ToString());
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                    //row.Cells[2].MergeDown = 1;
                    b++;
                }
                this.table.SetEdge(0, 1, 3, r, Edge.Right, BorderStyle.Single, 1, Colors.Black);
                this.table.SetEdge(3, 1, 3, r, Edge.Right, BorderStyle.Single, 1, Colors.Black);
                this.table.SetEdge(0, 0, 9, r+1, Edge.Box, BorderStyle.Single, 1, Colors.Black);
                //adds an invisible row to space out the two tables 
                //row3 = table.AddRow();
                //row3.Borders.Visible = false;
            }
            //--------------------------------------------------------------------------//
            //------//-----------//----  Tie Downs Table     -----//----------//--------//
            //--------------------------------------------------------------------------//

            // Create the item table
            this.table = section.AddTable();
            table.Rows.Alignment = RowAlignment.Center;
            this.table.Style = "Table";
            this.table.Borders.Color = Colors.Black;
            this.table.Borders.Width = 0.5;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
           Column column4 = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

           column4 = this.table.AddColumn("4.08cm");
            column.Format.Alignment = ParagraphAlignment.Right;

           column4 = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

           column4 = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

           column4 = this.table.AddColumn("4.08cm");
            column.Format.Alignment = ParagraphAlignment.Right;

           column4 = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

           column4 = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

           column4 = this.table.AddColumn("4.08cm");
            column.Format.Alignment = ParagraphAlignment.Right;

           column4 = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table
            row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.LightGray;

            row.Cells[0].AddParagraph("Tie-Downs");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].MergeRight = 8;

            // Get count of tie down items
            int TieDownTableSize = Counts.TieDowns.Count;

            // Extract to smaller list
            List<TentItems> TieDown = Counts.TieDowns;

            b = 0;
            r = 0;

            for (int i = 0; i < TieDownTableSize; ++i)
            {
                if (i == 0 || i % 3 == 0)
                {
                    row = table.AddRow();
                    row.HeadingFormat = true;
                    row.Format.Alignment = ParagraphAlignment.Center;
                    row.Format.Font.Bold = true;
                    row.Shading.Color = Colors.White;
                    r++;
                }
                
                row.Cells[b].AddParagraph("□");
                row.Cells[b].Format.Font.Bold = true;
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph(TieDown[i].Type);
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph(TieDown[i].Qty.ToString());
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[2].MergeDown = 1;
                b++;                
            }
            this.table.SetEdge(0, 1, 3, r, Edge.Right, BorderStyle.Single, 1, Colors.Black);
            this.table.SetEdge(3, 1, 3, r, Edge.Right, BorderStyle.Single, 1, Colors.Black);
            this.table.SetEdge(0, 0, 9, r + 1, Edge.Box, BorderStyle.Single, 1, Colors.Black);
            //adds an invisible row to space out the two tables 
            //row = table.AddRow();
            //row.Borders.Visible = false;

            //--------------------------------------------------------------------------//
            //------//-----------//----   Accessories Table  -----//----------//--------//
            //--------------------------------------------------------------------------//
            if (Acc != null)
            {
                // Create the item table
                this.table = section.AddTable();
                table.Rows.Alignment = RowAlignment.Center;
                this.table.Style = "Table";
                this.table.Borders.Color = Colors.Black;
                this.table.Borders.Width = 0.5;
                this.table.Borders.Left.Width = 0.5;
                this.table.Borders.Right.Width = 0.5;
                this.table.Rows.LeftIndent = 0;

                //----------------------------------------------------------------------------

                // Before you can add a row, you must define the columns
                Column column5 = this.table.AddColumn("0.5cm");
                column.Format.Alignment = ParagraphAlignment.Center;

                column5 = this.table.AddColumn("4.08cm");
                column.Format.Alignment = ParagraphAlignment.Right;

                column5 = this.table.AddColumn("0.75cm");
                column.Format.Alignment = ParagraphAlignment.Right;

                column5 = this.table.AddColumn("0.5cm");
                column.Format.Alignment = ParagraphAlignment.Center;

                column5 = this.table.AddColumn("4.08cm");
                column.Format.Alignment = ParagraphAlignment.Right;

                column5 = this.table.AddColumn("0.75cm");
                column.Format.Alignment = ParagraphAlignment.Right;

                column5 = this.table.AddColumn("0.5cm");
                column.Format.Alignment = ParagraphAlignment.Center;

                column5 = this.table.AddColumn("4.08cm");
                column.Format.Alignment = ParagraphAlignment.Right;

                column5 = this.table.AddColumn("0.75cm");
                column.Format.Alignment = ParagraphAlignment.Right;

                //----------------------------------------------------------------------------

                // Create the header of the table
                row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.LightGray;

                row.Cells[0].AddParagraph("Accessories");
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[0].MergeRight = 8;

                // Get count of accessories
                int AccTableSize = Acc.Count;

                b = 0;
                r = 0;
                for (int i = 0; i < AccTableSize; ++i)
                {
                    if (i == 0 || i % 3 == 0)
                    {
                        row = table.AddRow();
                        row.HeadingFormat = true;
                        row.Format.Alignment = ParagraphAlignment.Center;
                        row.Format.Font.Bold = true;
                        row.Shading.Color = Colors.White;
                        b = 0;
                        r++;
                    }
                    row.Cells[b].AddParagraph("□");
                    row.Cells[b].Format.Font.Bold = true;
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                    //row.Cells[0].MergeDown = 1;
                    b++;
                    row.Cells[b].AddParagraph(Acc[i].Item);
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    //row.Cells[1].MergeRight = 0;
                    //row.Cells[1].MergeDown = 1;
                    b++;
                    row.Cells[b].AddParagraph(Acc[i].Qty.ToString());
                    row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                    //row.Cells[2].MergeDown = 1;
                    b++;
                }
            }
            this.table.SetEdge(0, 1, 3, r, Edge.Right, BorderStyle.Single, 1, Colors.Black);
            this.table.SetEdge(3, 1, 3, r, Edge.Right, BorderStyle.Single, 1, Colors.Black);
            this.table.SetEdge(0, 0, 9, r + 1, Edge.Box, BorderStyle.Single, 1, Colors.Black);
            //adds an invisible row to space out the two tables 
            //row = table.AddRow();
            //row.Borders.Visible = false;


            // not sure what this does yet but pretty sure it makes an edge that surrounds the table kind of like thick borders
            //this.table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 1, Color.Empty);

            //--------------------------------------------------------------------------//
            //------//-----------//---- Stuff After Tables  ------//----------//--------//
            //--------------------------------------------------------------------------//

            //section.AddPageBreak();

            //document.AddSection();

            MigraDoc.DocumentObjectModel.Paragraph paragraph1 = section.AddParagraph();
            paragraph1.Format.LineSpacingRule = MigraDoc.DocumentObjectModel.LineSpacingRule.Exactly;
            paragraph1.Format.LineSpacing = MigraDoc.DocumentObjectModel.Unit.FromMillimeter(40);

            //--------------------------------------------------------------------------//
            //------//-----------//---  Unforgetables Table  -----//----------//--------//
            //--------------------------------------------------------------------------//

            // Create the item table
            this.table1 = section.AddTable();
            table1.Rows.Alignment = RowAlignment.Center;
            //table1.Rows.Alignment = VerticalAlignment.Bottom;
            this.table1.Style = "Table";
            this.table1.Borders.Color = Colors.Black;
            this.table1.Borders.Width = 0.5;
            this.table1.Borders.Left.Width = 0.5;
            this.table1.Borders.Right.Width = 0.5;
            this.table1.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column6 = this.table1.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column6 = this.table1.AddColumn("3cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("0.5cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("4cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("0.5cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("3cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("0.5cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("4cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table

            Row row6 = table1.AddRow();
            row6.HeadingFormat = true;
            row6.Format.Alignment = ParagraphAlignment.Center;
            row6.Format.Font.Bold = true;
            row6.Shading.Color = Colors.White;

            row6.Cells[0].AddParagraph("□");
            row6.Cells[0].Format.Font.Bold = true;
            row6.Cells[0].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[1].AddParagraph("Blue Tarp");
            row6.Cells[1].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[2].AddParagraph("□");
            row6.Cells[2].Format.Font.Bold = true;
            row6.Cells[2].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[3].AddParagraph("Clips");
            row6.Cells[3].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[4].AddParagraph("□");
            row6.Cells[4].Format.Font.Bold = true;
            row6.Cells[4].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[5].AddParagraph("Patch Kit");
            row6.Cells[5].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[6].AddParagraph("□");
            row6.Cells[6].Format.Font.Bold = true;
            row6.Cells[6].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[7].AddParagraph("Jack Hammer/Fuel");
            row6.Cells[7].Format.Alignment = ParagraphAlignment.Center;

            row6 = table1.AddRow();
            row6.HeadingFormat = true;
            row6.Format.Alignment = ParagraphAlignment.Center;
            row6.Format.Font.Bold = true;
            row6.Shading.Color = Colors.White;

            row6.Cells[0].AddParagraph("□");
            row6.Cells[0].Format.Font.Bold = true;
            row6.Cells[0].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[1].AddParagraph("Spray 9/Rags");
            row6.Cells[1].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[2].AddParagraph("□");
            row6.Cells[2].Format.Font.Bold = true;
            row6.Cells[2].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[3].AddParagraph("Sledge Hammer");
            row6.Cells[3].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[4].AddParagraph("□");
            row6.Cells[4].Format.Font.Bold = true;
            row6.Cells[4].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[5].AddParagraph("Step Ladder");
            row6.Cells[5].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[6].AddParagraph("□");
            row6.Cells[6].Format.Font.Bold = true;
            row6.Cells[6].Format.Alignment = ParagraphAlignment.Center;

            row6.Cells[7].AddParagraph("Impact/Screws");
            row6.Cells[7].Format.Alignment = ParagraphAlignment.Center;
            this.table1.SetEdge(0, 0, 8, 2, Edge.Box, BorderStyle.Single, 1, Colors.Black);

            // Add the notes paragraph
            paragraph = section.AddParagraph();
            //this.document.LastSection.AddParagraph();
            paragraph.Format.SpaceBefore = "0.5cm";
            paragraph.Format.Borders.Width = 0.75;
            paragraph.Format.Borders.Distance = 3;
            paragraph.Format.Borders.Color = Colors.Black;
            paragraph.Format.Shading.Color = Colors.LightGray;
            paragraph.AddText("notes \n \n \n \n");

        }

        //---------------------------------------------------------------------------------//

        // Some pre-defined colors
#if true
        // RGB colors
        //readonly static Color Colors.Black = new Color(81, 125, 192);
        //readonly static Color TableBlue = new Color(235, 240, 249);
        //readonly static Color Colors.Gray = new Color(242, 242, 242);
#else
    // CMYK colors
    readonly static Color Colors.Black = Color.FromCmyk(100, 50, 0, 30);
    readonly static Color tableBlue = Color.FromCmyk(0, 80, 50, 30);
    readonly static Color Colors.Gray = Color.FromCmyk(30, 0, 0, 0, 100);
#endif

    }
}
