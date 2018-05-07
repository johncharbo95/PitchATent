using System;
using System.Globalization;
using System.Xml;
using System.Xml.XPath;
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
            style.Font.Name = "Verdana";

            style = this.document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = this.document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = this.document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
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
            Image image = section.Headers.Primary.AddImage("../../logo.png");
            image.Height = "2.5cm";
            image.LockAspectRatio = true;
            image.RelativeVertical = RelativeVertical.Line;
            image.RelativeHorizontal = RelativeHorizontal.Margin;
            image.Top = ShapePosition.Top;
            image.Left = ShapePosition.Left;
            image.WrapFormat.Style = WrapStyle.Through;

            //----------------------------------------------------------------------------

            // Create footer
            Paragraph paragraph = section.Footers.Primary.AddParagraph();
            paragraph.AddText("Labelle Tents Inc · Route 500 Ouest · Ontario · Canada");
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
            paragraph = this.addressFrame.AddParagraph("Tents For All Events");
            paragraph.Format.Font.Name = "comic sans MS";
            paragraph.Format.Font.Color = Colors.Orange;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.SpaceAfter = 3;

            //----------------------------------------------------------------------------

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "3cm";
            paragraph.Style = "Reference";
            paragraph.AddFormattedText("Material List", TextFormat.Bold);
            paragraph.AddTab();
            paragraph.AddText("Truck, ");
            paragraph.AddDateField("dd.MM.yyyy");

            //--------------------------------------------------------------------------//
            //------//-----------//----       Table         ------//----------//--------//
            //--------------------------------------------------------------------------//

            // Create the item table
            this.table = section.AddTable();
            table.Rows.Alignment = RowAlignment.Left;
            this.table.Style = "Table";
            this.table.Borders.Color = Colors.Black;
            this.table.Borders.Width = 1;
            this.table.Borders.Left.Width = 1;
            this.table.Borders.Right.Width = 1;
            this.table.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.Cornsilk;


            // Makes the new rows for the Metal 
            row.Cells[0].AddParagraph("Metal");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].MergeRight = 6;

            int i = 0;

            while (i < 3) //max number of columns for one page before cutting into other tings is 33 (or 32 for i)
            {
                int b = 0;

                row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.Beige;
                row.Cells[b].AddParagraph("□");
                row.Cells[b].Format.Font.Bold = true;
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("Item Name");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("###");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[2].MergeDown = 1;
                b++;
                b++;
                row.Cells[b].AddParagraph("□");
                row.Cells[b].Format.Font.Bold = true;
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("Item Name");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("###");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                i++;
            }

            //adds an invisible row to space out the two tables 
            row = table.AddRow();
            row.Borders.Visible = false;

            // Makes the new rows for the covers  
            row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.Cornsilk;
            row.Cells[0].AddParagraph("Covers");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].MergeRight = 6;

            i = 0;

            while (i < 3) //max number of columns for one page before cutting into other tings is 33 (or 32 for i)
            {
                int b = 0;

                row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.Beige;
                row.Cells[b].AddParagraph("□");
                row.Cells[b].Format.Font.Bold = true;
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("Item Name");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("###");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[2].MergeDown = 1;
                b++;
                b++;
                row.Cells[b].AddParagraph("□");
                row.Cells[b].Format.Font.Bold = true;
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("Item Name");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("###");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                i++;
            }

            //adds an invisible row to space out the two tables 
            row = table.AddRow();
            row.Borders.Visible = false;

            // Makes the new rows for the Tie Downs 
            row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.Cornsilk;
            row.Cells[0].AddParagraph("Tie Downs");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].MergeRight = 6;

            i = 0;

            while (i < 3) //max number of columns for one page before cutting into other tings is 33 (or 32 for i)
            {
                int b = 0;

                row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.Beige;
                row.Cells[b].AddParagraph("□");
                row.Cells[b].Format.Font.Bold = true;
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("Item Name");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("###");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[2].MergeDown = 1;
                b++;
                b++;
                row.Cells[b].AddParagraph("□");
                row.Cells[b].Format.Font.Bold = true;
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("Item Name");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("###");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                i++;
            }

            //adds an invisible row to space out the two tables 
            row = table.AddRow();
            row.Borders.Visible = false;

            // Makes the new rows for the Walls 
            row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.Cornsilk;
            row.Cells[0].AddParagraph("Walls");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].MergeRight = 6;

            i = 0;

            while (i < 3) //max number of columns for one page before cutting into other tings is 33 (or 32 for i)
            {
                int b = 0;

                row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.Beige;
                row.Cells[b].AddParagraph("□");
                row.Cells[b].Format.Font.Bold = true;
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("Item Name");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("###");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[2].MergeDown = 1;
                b++;
                b++;
                row.Cells[b].AddParagraph("□");
                row.Cells[b].Format.Font.Bold = true;
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("Item Name");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("###");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                i++;
            }

            //adds an invisible row to space out the two tables 
            row = table.AddRow();
            row.Borders.Visible = false;

            // Makes the new rows for the accessories 
            row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.Cornsilk;
            row.Cells[0].AddParagraph("Accessories");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].MergeRight = 6;

            i = 0;

            while (i < 3) //max number of columns for one page before cutting into other tings is 33 (or 32 for i)
            {
                int b = 0;

                row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.Beige;
                row.Cells[b].AddParagraph("□");
                row.Cells[b].Format.Font.Bold = true;
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("Item Name");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("###");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[2].MergeDown = 1;
                b++;
                b++;
                row.Cells[b].AddParagraph("□");
                row.Cells[b].Format.Font.Bold = true;
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("Item Name");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row.Cells[b].AddParagraph("###");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                i++;
            }

            //adds an invisible row to space out the two tables 
            row = table.AddRow();
            row.Borders.Visible = false;

            // not sure what this does yet but pretty sure it makes an edge that surrounds the table kind of like thick borders
            this.table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 1, Color.Empty);

            //--------------------------------------------------------------------------//
            //------//-----------//----      Table 1        ------//----------//--------//
            //--------------------------------------------------------------------------//

            // Create the item table
            this.table1 = section.AddTable();
            table1.Rows.Alignment = RowAlignment.Center;
            //table1.Rows.Alignment = VerticalAlignment.Bottom;
            this.table1.Style = "Table";
            this.table1.Borders.Color = Colors.Black;
            this.table1.Borders.Width = 1;
            this.table1.Borders.Left.Width = 1;
            this.table1.Borders.Right.Width = 1;
            this.table1.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column1 = this.table1.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column1 = this.table1.AddColumn("4cm");
            column1.Format.Alignment = ParagraphAlignment.Right;

            column1 = this.table1.AddColumn("0.75cm");
            column1.Format.Alignment = ParagraphAlignment.Right;

            column1 = this.table1.AddColumn("4cm");
            column1.Format.Alignment = ParagraphAlignment.Right;

            column1 = this.table1.AddColumn("0.75cm");
            column1.Format.Alignment = ParagraphAlignment.Right;

            column1 = this.table1.AddColumn("4cm");
            column1.Format.Alignment = ParagraphAlignment.Right;

            column1 = this.table1.AddColumn("0.75cm");
            column1.Format.Alignment = ParagraphAlignment.Right;

            column1 = this.table1.AddColumn("4cm");
            column1.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table
            Row row1 = table1.AddRow();
            row1.HeadingFormat = true;
            row1.Format.Alignment = ParagraphAlignment.Center;
            row1.Format.Font.Bold = true;
            row1.Shading.Color = Colors.Cornsilk;

            row1.Cells[0].AddParagraph("□");
            row1.Cells[0].Format.Font.Bold = true;
            row1.Cells[0].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[1].AddParagraph("Tarp");
            row1.Cells[1].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[2].AddParagraph("□");
            row1.Cells[2].Format.Font.Bold = true;
            row1.Cells[2].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[3].AddParagraph("Arrache Pin");
            row1.Cells[3].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[4].AddParagraph("□");
            row1.Cells[4].Format.Font.Bold = true;
            row1.Cells[4].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[5].AddParagraph("Masse");
            row1.Cells[5].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[6].AddParagraph("□");
            row1.Cells[6].Format.Font.Bold = true;
            row1.Cells[6].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[7].AddParagraph("Patching Tape");
            row1.Cells[7].Format.Alignment = ParagraphAlignment.Center;

            row1 = table1.AddRow();
            row1.HeadingFormat = true;
            row1.Format.Alignment = ParagraphAlignment.Center;
            row1.Format.Font.Bold = true;
            row1.Shading.Color = Colors.Cornsilk;

            row1.Cells[0].AddParagraph("□");
            row1.Cells[0].Format.Font.Bold = true;
            row1.Cells[0].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[1].AddParagraph("Tarp");
            row1.Cells[1].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[2].AddParagraph("□");
            row1.Cells[2].Format.Font.Bold = true;
            row1.Cells[2].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[3].AddParagraph("Arrache Pin");
            row1.Cells[3].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[4].AddParagraph("□");
            row1.Cells[4].Format.Font.Bold = true;
            row1.Cells[4].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[5].AddParagraph("Masse");
            row1.Cells[5].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[6].AddParagraph("□");
            row1.Cells[6].Format.Font.Bold = true;
            row1.Cells[6].Format.Alignment = ParagraphAlignment.Center;

            row1.Cells[7].AddParagraph("Patching Tape");
            row1.Cells[7].Format.Alignment = ParagraphAlignment.Center;


            this.table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 1, Color.Empty);

            // Add the notes paragraph
            paragraph = this.document.LastSection.AddParagraph();
            paragraph.Format.SpaceBefore = "0.5cm";
            paragraph.Format.Borders.Width = 0.75;
            paragraph.Format.Borders.Distance = 3;
            paragraph.Format.Borders.Color = TableBorder;
            paragraph.Format.Shading.Color = TableGray;
            paragraph.AddText("notes \n \n");

        }

        //------//-----------//----------//---------//----------//----------//--------//

        /// <summary>
        /// Creates the dynamic parts of the invoice.
        /// </summary>
        //void FillContent()
        //{
        //    // Fill address in address text frame
        //    XPathNavigator item = SelectItem("/invoice/to");
        //    Paragraph paragraph = this.addressFrame.AddParagraph();
        //    paragraph.AddText(GetValue(item, "name/singleName"));
        //    paragraph.AddLineBreak();
        //    paragraph.AddText(GetValue(item, "address/line1"));
        //    paragraph.AddLineBreak();
        //    paragraph.AddText(GetValue(item, "address/postalCode") + " " + GetValue(item, "address/city"));

        //    // Iterate the invoice items
        //    double totalExtendedPrice = 0;
        //    XPathNodeIterator iter = this.navigator.Select("/invoice/items/*");
        //    while (iter.MoveNext())
        //    {
        //        item = iter.Current;
        //        double quantity = GetValueAsDouble(item, "quantity");
        //        double price = GetValueAsDouble(item, "price");
        //        double discount = GetValueAsDouble(item, "discount");

        //        // Each item fills two rows
        //        Row row1 = this.table.AddRow();
        //        Row row2 = this.table.AddRow();
        //        row1.TopPadding = 1.5;
        //        row1.Cells[0].Shading.Color = TableGray;
        //        row1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
        //        row1.Cells[0].MergeDown = 1;
        //        row1.Cells[1].Format.Alignment = ParagraphAlignment.Left;
        //        row1.Cells[1].MergeRight = 3;
        //        row1.Cells[5].Shading.Color = TableGray;
        //        row1.Cells[5].MergeDown = 1;

        //        row1.Cells[0].AddParagraph(GetValue(item, "itemNumber"));
        //        paragraph = row1.Cells[1].AddParagraph();
        //        paragraph.AddFormattedText(GetValue(item, "title"), TextFormat.Bold);
        //        paragraph.AddFormattedText(" by ", TextFormat.Italic);
        //        paragraph.AddText(GetValue(item, "author"));
        //        row2.Cells[1].AddParagraph(GetValue(item, "quantity"));
        //        row2.Cells[2].AddParagraph(price.ToString("0.00") + " €");
        //        row2.Cells[3].AddParagraph(discount.ToString("0.0"));
        //        row2.Cells[4].AddParagraph();
        //        row2.Cells[5].AddParagraph(price.ToString("0.00"));
        //        double extendedPrice = quantity * price;
        //        extendedPrice = extendedPrice * (100 - discount) / 100;
        //        row1.Cells[5].AddParagraph(extendedPrice.ToString("0.00") + " €");
        //        row1.Cells[5].VerticalAlignment = VerticalAlignment.Bottom;
        //        totalExtendedPrice += extendedPrice;

        //        this.table.SetEdge(0, this.table.Rows.Count - 2, 6, 2, Edge.Box, BorderStyle.Single, 0.75);
        //    }

        //    // Add an invisible row as a space line to the table
        //    Row row = this.table.AddRow();
        //    row.Borders.Visible = false;

        //    // Add the total price row
        //    row = this.table.AddRow();
        //    row.Cells[0].Borders.Visible = false;
        //    row.Cells[0].AddParagraph("Total Price");
        //    row.Cells[0].Format.Font.Bold = true;
        //    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        //    row.Cells[0].MergeRight = 4;
        //    row.Cells[5].AddParagraph(totalExtendedPrice.ToString("0.00") + " €");

        //    // Add the VAT row
        //    row = this.table.AddRow();
        //    row.Cells[0].Borders.Visible = false;
        //    row.Cells[0].AddParagraph("VAT (19%)");
        //    row.Cells[0].Format.Font.Bold = true;
        //    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        //    row.Cells[0].MergeRight = 4;
        //    row.Cells[5].AddParagraph((0.19 * totalExtendedPrice).ToString("0.00") + " €");

        //    // Add the additional fee row
        //    row = this.table.AddRow();
        //    row.Cells[0].Borders.Visible = false;
        //    row.Cells[0].AddParagraph("Shipping and Handling");
        //    row.Cells[5].AddParagraph(0.ToString("0.00") + " €");
        //    row.Cells[0].Format.Font.Bold = true;
        //    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        //    row.Cells[0].MergeRight = 4;

        //    // Add the total due row
        //    row = this.table.AddRow();
        //    row.Cells[0].AddParagraph("Total Due");
        //    row.Cells[0].Borders.Visible = false;
        //    row.Cells[0].Format.Font.Bold = true;
        //    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        //    row.Cells[0].MergeRight = 4;
        //    totalExtendedPrice += 0.19 * totalExtendedPrice;
        //    row.Cells[5].AddParagraph(totalExtendedPrice.ToString("0.00") + " €");

        //    // Set the borders of the specified cell range
        //    this.table.SetEdge(5, this.table.Rows.Count - 4, 1, 4, Edge.Box, BorderStyle.Single, 0.75);

        //    // Add the notes paragraph
        //    paragraph = this.document.LastSection.AddParagraph();
        //    paragraph.Format.SpaceBefore = "1cm";
        //    paragraph.Format.Borders.Width = 0.75;
        //    paragraph.Format.Borders.Distance = 3;
        //    paragraph.Format.Borders.Color = TableBorder;
        //    paragraph.Format.Shading.Color = TableGray;
        //    item = SelectItem("/invoice");
        //    paragraph.AddText(GetValue(item, "notes"));
        //}

        /// <summary>
        /// Selects a subtree in the XML data.
        /// </summary>
        /// 
        //XPathNavigator SelectItem(string path)
        //{
        //    XPathNodeIterator iter = this.navigator.Select(path);
        //    iter.MoveNext();
        //    return iter.Current;
        //}

        /// <summary>
        /// Gets an element value from the XML data.
        /// </summary>
        //static string GetValue(XPathNavigator nav, string name)
        //{
        //    //nav = nav.Clone();
        //    XPathNodeIterator iter = nav.Select(name);
        //    iter.MoveNext();
        //    return iter.Current.Value;
        //}

        ///// <summary>
        ///// Gets an element value as double from the XML data.
        ///// </summary>
        //static double GetValueAsDouble(XPathNavigator nav, string name)
        //{
        //    try
        //    {
        //        string value = GetValue(nav, name);
        //        if (value.Length == 0)
        //            return 0;
        //        return Double.Parse(value, CultureInfo.InvariantCulture);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        //    return 0;
        //}

        // Some pre-defined colors
#if true
        // RGB colors
        readonly static Color TableBorder = new Color(81, 125, 192);
        readonly static Color TableBlue = new Color(235, 240, 249);
        readonly static Color TableGray = new Color(242, 242, 242);
#else
    // CMYK colors
    readonly static Color tableBorder = Color.FromCmyk(100, 50, 0, 30);
    readonly static Color tableBlue = Color.FromCmyk(0, 80, 50, 30);
    readonly static Color tableGray = Color.FromCmyk(30, 0, 0, 0, 100);
#endif

    }
}
