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
            paragraph.Format.Font.Color = Colors.DarkOrange;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.SpaceAfter = 3;

            //----------------------------------------------------------------------------

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "2cm";
            paragraph.Style = "Reference";
            paragraph.AddFormattedText("List Of Materials", TextFormat.Bold);
            paragraph.AddTab();
            paragraph.AddText("Truck And Trailer, ");
            paragraph.AddDateField("dd.MM.yyyy");
            paragraph.Format.Font.Size = 14;

            //--------------------------------------------------------------------------//
            //------//-----------//----     Metal Table      -----//----------//--------//
            //--------------------------------------------------------------------------//

            // Create the item table
            this.table = section.AddTable();
            table.Rows.Alignment = RowAlignment.Center;
            this.table.Style = "Table";
            this.table.Borders.Color = Colors.Black;
            this.table.Borders.Width = 1;
            this.table.Borders.Left.Width = 1;
            this.table.Borders.Right.Width = 1;
            this.table.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("3cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("3cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("3cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("0.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = TableGray;


            // Makes the new rows for the Metal 
            row.Cells[0].AddParagraph("Metal");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].MergeRight = 10;

            int i = 0;

            while (i < 3) //max number of columns for one page before cutting into other tings is 33 (or 32 for i)
            {
                int b = 0;

                row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.White;
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
                row.Cells[b].AddParagraph("#");
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
                row.Cells[b].AddParagraph("#");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
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
                row.Cells[b].AddParagraph("#");
                row.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                i++;
            }

            row = table.AddRow();
            row.Borders.Visible = false;

            //--------------------------------------------------------------------------//
            //------//-----------//----     Covers Table     -----//----------//--------//
            //--------------------------------------------------------------------------//

            // Create the item table
            this.table = section.AddTable();
            table.Rows.Alignment = RowAlignment.Center;
            this.table.Style = "Table";
            this.table.Borders.Color = Colors.Black;
            this.table.Borders.Width = 1;
            this.table.Borders.Left.Width = 1;
            this.table.Borders.Right.Width = 1;
            this.table.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column2 = this.table.AddColumn("0.5cm");
            column2.Format.Alignment = ParagraphAlignment.Center;

            column2 = this.table.AddColumn("3cm");
            column2.Format.Alignment = ParagraphAlignment.Right;

            column2 = this.table.AddColumn("0.5cm");
            column2.Format.Alignment = ParagraphAlignment.Right;

            column2 = this.table.AddColumn("0.75cm");
            column2.Format.Alignment = ParagraphAlignment.Right;

            column2 = this.table.AddColumn("0.5cm");
            column2.Format.Alignment = ParagraphAlignment.Center;

            column2 = this.table.AddColumn("3cm");
            column2.Format.Alignment = ParagraphAlignment.Right;

            column2 = this.table.AddColumn("0.5cm");
            column2.Format.Alignment = ParagraphAlignment.Right;

            column2 = this.table.AddColumn("0.75cm");
            column2.Format.Alignment = ParagraphAlignment.Right;

            column2 = this.table.AddColumn("0.5cm");
            column2.Format.Alignment = ParagraphAlignment.Center;

            column2 = this.table.AddColumn("3cm");
            column2.Format.Alignment = ParagraphAlignment.Right;

            column2 = this.table.AddColumn("0.5cm");
            column2.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table
            Row row2 = table.AddRow();
            row2.HeadingFormat = true;
            row2.Format.Alignment = ParagraphAlignment.Center;
            row2.Format.Font.Bold = true;
            row2.Shading.Color = TableGray;

            row2.Cells[0].AddParagraph("Covers");
            row2.Cells[0].Format.Font.Bold = true;
            row2.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row2.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row2.Cells[0].MergeRight = 10;

            i = 0;
            while (i < 3) //max number of columns for one page before cutting into other tings is 33 (or 32 for i)
            {
                int b = 0;

                row2 = table.AddRow();
                row2.HeadingFormat = true;
                row2.Format.Alignment = ParagraphAlignment.Center;
                row2.Format.Font.Bold = true;
                row2.Shading.Color = Colors.White;
                row2.Cells[b].AddParagraph("□");
                row2.Cells[b].Format.Font.Bold = true;
                row2.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row2.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row2.Cells[b].AddParagraph("Item Name");
                row2.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row2.Cells[b].AddParagraph("#");
                row2.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row2.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[2].MergeDown = 1;
                b++;
                b++;
                row2.Cells[b].AddParagraph("□");
                row2.Cells[b].Format.Font.Bold = true;
                row2.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row2.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row2.Cells[b].AddParagraph("Item Name");
                row2.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row2.Cells[b].AddParagraph("#");
                row2.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row2.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                b++;
                b++;
                row2.Cells[b].AddParagraph("□");
                row2.Cells[b].Format.Font.Bold = true;
                row2.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row2.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row2.Cells[b].AddParagraph("Item Name");
                row2.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row2.Cells[b].AddParagraph("#");
                row2.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row2.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                i++;
            }

            //adds an invisible row to space out the two tables 
            row2 = table.AddRow();
            row2.Borders.Visible = false;

            // Create the item table
            this.table = section.AddTable();
            table.Rows.Alignment = RowAlignment.Center;
            this.table.Style = "Table";
            this.table.Borders.Color = Colors.Black;
            this.table.Borders.Width = 1;
            this.table.Borders.Left.Width = 1;
            this.table.Borders.Right.Width = 1;
            this.table.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column3 = this.table.AddColumn("0.5cm");
            column3.Format.Alignment = ParagraphAlignment.Center;

            column3 = this.table.AddColumn("3cm");
            column3.Format.Alignment = ParagraphAlignment.Right;

            column3 = this.table.AddColumn("0.5cm");
            column3.Format.Alignment = ParagraphAlignment.Right;

            column3 = this.table.AddColumn("0.75cm");
            column3.Format.Alignment = ParagraphAlignment.Right;

            column3 = this.table.AddColumn("0.5cm");
            column3.Format.Alignment = ParagraphAlignment.Center;

            column3 = this.table.AddColumn("3cm");
            column3.Format.Alignment = ParagraphAlignment.Right;

            column3 = this.table.AddColumn("0.5cm");
            column3.Format.Alignment = ParagraphAlignment.Right;

            column3 = this.table.AddColumn("0.75cm");
            column3.Format.Alignment = ParagraphAlignment.Right;

            column3 = this.table.AddColumn("0.5cm");
            column3.Format.Alignment = ParagraphAlignment.Center;

            column3 = this.table.AddColumn("3cm");
            column3.Format.Alignment = ParagraphAlignment.Right;

            column3 = this.table.AddColumn("0.5cm");
            column3.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table
            Row row3 = table.AddRow();
            row3.HeadingFormat = true;
            row3.Format.Alignment = ParagraphAlignment.Center;
            row3.Format.Font.Bold = true;
            row3.Shading.Color = TableGray;

            row3.Cells[0].AddParagraph("Tie Downs");
            row3.Cells[0].Format.Font.Bold = true;
            row3.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row3.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row3.Cells[0].MergeRight = 10;

            i = 0;
            while (i < 3) //max number of columns for one page before cutting into other tings is 33 (or 32 for i)
            {
                int b = 0;

                row3 = table.AddRow();
                row3.HeadingFormat = true;
                row3.Format.Alignment = ParagraphAlignment.Center;
                row3.Format.Font.Bold = true;
                row3.Shading.Color = Colors.White;
                row3.Cells[b].AddParagraph("□");
                row3.Cells[b].Format.Font.Bold = true;
                row3.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row3.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row3.Cells[b].AddParagraph("Item Name");
                row3.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row3.Cells[b].AddParagraph("#");
                row3.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row3.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[2].MergeDown = 1;
                b++;
                b++;
                row3.Cells[b].AddParagraph("□");
                row3.Cells[b].Format.Font.Bold = true;
                row3.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row3.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row3.Cells[b].AddParagraph("Item Name");
                row3.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row3.Cells[b].AddParagraph("#");
                row3.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row3.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                b++;
                b++;
                row3.Cells[b].AddParagraph("□");
                row3.Cells[b].Format.Font.Bold = true;
                row3.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row3.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row3.Cells[b].AddParagraph("Item Name");
                row3.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row3.Cells[b].AddParagraph("#");
                row3.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row3.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                i++;
            }

            //adds an invisible row to space out the two tables 
            row3 = table.AddRow();
            row3.Borders.Visible = false;

            //--------------------------------------------------------------------------//
            //------//-----------//----  Tie Downs Table     -----//----------//--------//
            //--------------------------------------------------------------------------//
            
            // Create the item table
            this.table = section.AddTable();
            table.Rows.Alignment = RowAlignment.Center;
            this.table.Style = "Table";
            this.table.Borders.Color = Colors.Black;
            this.table.Borders.Width = 1;
            this.table.Borders.Left.Width = 1;
            this.table.Borders.Right.Width = 1;
            this.table.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column4 = this.table.AddColumn("0.5cm");
            column4.Format.Alignment = ParagraphAlignment.Center;

            column4 = this.table.AddColumn("3cm");
            column4.Format.Alignment = ParagraphAlignment.Right;

            column4 = this.table.AddColumn("0.5cm");
            column4.Format.Alignment = ParagraphAlignment.Right;

            column4 = this.table.AddColumn("0.75cm");
            column4.Format.Alignment = ParagraphAlignment.Right;

            column4 = this.table.AddColumn("0.5cm");
            column4.Format.Alignment = ParagraphAlignment.Center;

            column4 = this.table.AddColumn("3cm");
            column4.Format.Alignment = ParagraphAlignment.Right;

            column4 = this.table.AddColumn("0.5cm");
            column4.Format.Alignment = ParagraphAlignment.Right;

            column4 = this.table.AddColumn("0.75cm");
            column4.Format.Alignment = ParagraphAlignment.Right;

            column4 = this.table.AddColumn("0.5cm");
            column4.Format.Alignment = ParagraphAlignment.Center;

            column4 = this.table.AddColumn("3cm");
            column4.Format.Alignment = ParagraphAlignment.Right;

            column4 = this.table.AddColumn("0.5cm");
            column4.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table
            Row row4 = table.AddRow();
            row4.HeadingFormat = true;
            row4.Format.Alignment = ParagraphAlignment.Center;
            row4.Format.Font.Bold = true;
            row4.Shading.Color = TableGray;

            row4.Cells[0].AddParagraph("Walls");
            row4.Cells[0].Format.Font.Bold = true;
            row4.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row4.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row4.Cells[0].MergeRight = 10;

            i = 0;
            while (i < 3) //max number of columns for one page before cutting into other tings is 33 (or 32 for i)
            {
                int b = 0;

                row4 = table.AddRow();
                row4.HeadingFormat = true;
                row4.Format.Alignment = ParagraphAlignment.Center;
                row4.Format.Font.Bold = true;
                row4.Shading.Color = Colors.White;
                row4.Cells[b].AddParagraph("□");
                row4.Cells[b].Format.Font.Bold = true;
                row4.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row4.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row4.Cells[b].AddParagraph("Item Name");
                row4.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row4.Cells[b].AddParagraph("#");
                row4.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row4.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[2].MergeDown = 1;
                b++;
                b++;
                row4.Cells[b].AddParagraph("□");
                row4.Cells[b].Format.Font.Bold = true;
                row4.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row4.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row4.Cells[b].AddParagraph("Item Name");
                row4.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row4.Cells[b].AddParagraph("#");
                row4.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row4.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                b++;
                b++;
                row4.Cells[b].AddParagraph("□");
                row4.Cells[b].Format.Font.Bold = true;
                row4.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row4.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row4.Cells[b].AddParagraph("Item Name");
                row4.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row4.Cells[b].AddParagraph("#");
                row4.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row4.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                i++;
            }

            //adds an invisible row to space out the two tables 
            row4 = table.AddRow();
            row4.Borders.Visible = false;

            //--------------------------------------------------------------------------//
            //------//-----------//----   Accessories Table  -----//----------//--------//
            //--------------------------------------------------------------------------//
            // Create the item table
            this.table = section.AddTable();
            table.Rows.Alignment = RowAlignment.Center;
            this.table.Style = "Table";
            this.table.Borders.Color = Colors.Black;
            this.table.Borders.Width = 1;
            this.table.Borders.Left.Width = 1;
            this.table.Borders.Right.Width = 1;
            this.table.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column5 = this.table.AddColumn("0.5cm");
            column5.Format.Alignment = ParagraphAlignment.Center;

            column5 = this.table.AddColumn("3cm");
            column5.Format.Alignment = ParagraphAlignment.Right;

            column5 = this.table.AddColumn("0.5cm");
            column5.Format.Alignment = ParagraphAlignment.Right;

            column5 = this.table.AddColumn("0.75cm");
            column5.Format.Alignment = ParagraphAlignment.Right;

            column5 = this.table.AddColumn("0.5cm");
            column5.Format.Alignment = ParagraphAlignment.Center;

            column5 = this.table.AddColumn("3cm");
            column5.Format.Alignment = ParagraphAlignment.Right;

            column5 = this.table.AddColumn("0.5cm");
            column5.Format.Alignment = ParagraphAlignment.Right;

            column5 = this.table.AddColumn("0.75cm");
            column5.Format.Alignment = ParagraphAlignment.Right;

            column5 = this.table.AddColumn("0.5cm");
            column5.Format.Alignment = ParagraphAlignment.Center;

            column5 = this.table.AddColumn("3cm");
            column5.Format.Alignment = ParagraphAlignment.Right;

            column5 = this.table.AddColumn("0.5cm");
            column5.Format.Alignment = ParagraphAlignment.Right;

            //----------------------------------------------------------------------------

            // Create the header of the table
            Row row5 = table.AddRow();
            row5.HeadingFormat = true;
            row5.Format.Alignment = ParagraphAlignment.Center;
            row5.Format.Font.Bold = true;
            row5.Shading.Color = TableGray;

            row5.Cells[0].AddParagraph("Accessories");
            row5.Cells[0].Format.Font.Bold = true;
            row5.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row5.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row5.Cells[0].MergeRight = 10;

            i = 0;
            while (i < 3) //max number of columns for one page before cutting into other tings is 33 (or 32 for i)
            {
                int b = 0;

                row5 = table.AddRow();
                row5.HeadingFormat = true;
                row5.Format.Alignment = ParagraphAlignment.Center;
                row5.Format.Font.Bold = true;
                row5.Shading.Color = Colors.White;
                row5.Cells[b].AddParagraph("□");
                row5.Cells[b].Format.Font.Bold = true;
                row5.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row5.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row5.Cells[b].AddParagraph("Item Name");
                row5.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row5.Cells[b].AddParagraph("#");
                row5.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row5.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[2].MergeDown = 1;
                b++;
                b++;
                row5.Cells[b].AddParagraph("□");
                row5.Cells[b].Format.Font.Bold = true;
                row5.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row5.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row5.Cells[b].AddParagraph("Item Name");
                row5.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row5.Cells[b].AddParagraph("#");
                row5.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row5.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                b++;
                b++;
                row5.Cells[b].AddParagraph("□");
                row5.Cells[b].Format.Font.Bold = true;
                row5.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row5.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                //row.Cells[0].MergeDown = 1;
                b++;
                row5.Cells[b].AddParagraph("Item Name");
                row5.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[1].MergeRight = 0;
                //row.Cells[1].MergeDown = 1;
                b++;
                row5.Cells[b].AddParagraph("#");
                row5.Cells[b].Format.Alignment = ParagraphAlignment.Center;
                row5.Cells[b].VerticalAlignment = VerticalAlignment.Center;
                i++;
            }

            //adds an invisible row to space out the two tables 
            row5 = table.AddRow();
            row5.Borders.Visible = false;

            // not sure what this does yet but pretty sure it makes an edge that surrounds the table kind of like thick borders
            this.table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 1, Color.Empty);

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
            this.table1.Borders.Width = 1;
            this.table1.Borders.Left.Width = 1;
            this.table1.Borders.Right.Width = 1;
            this.table1.Rows.LeftIndent = 0;

            //----------------------------------------------------------------------------

            // Before you can add a row, you must define the columns
            Column column6 = this.table1.AddColumn("0.75cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column6 = this.table1.AddColumn("3cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("0.75cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("3.8cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("0.75cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("3cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("0.75cm");
            column6.Format.Alignment = ParagraphAlignment.Right;

            column6 = this.table1.AddColumn("3.8cm");
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

            row6.Cells[7].AddParagraph("Impact Screws");
            row6.Cells[7].Format.Alignment = ParagraphAlignment.Center;

            // Add the notes paragraph
            paragraph = section.AddParagraph();
            //this.document.LastSection.AddParagraph();
            paragraph.Format.SpaceBefore = "0.5cm";
            paragraph.Format.Borders.Width = 0.75;
            paragraph.Format.Borders.Distance = 3;
            paragraph.Format.Borders.Color = TableBorder;
            paragraph.Format.Shading.Color = TableGray;
            paragraph.AddText("notes \n \n \n \n");

        }

        //---------------------------------------------------------------------------------//

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
