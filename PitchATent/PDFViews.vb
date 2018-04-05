Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.DocumentObjectModel.Shapes
Imports MigraDoc.Rendering
Imports SWPC

Public Class PDFViews

    Dim partList As List(Of SWDoc)
    Dim listTitle As String

    Dim _document As Document
    Dim _tableParts As Table

    Private TableGray As Color = New Color(242, 242, 242)
    Private TableDarkGray As Color = New Color(150, 150, 150)
    Private TableBlack As Color = New Color(50, 50, 50)

    Public Sub viewListReport(ByVal swDocs As List(Of SWPC.SWDoc), ByVal pkgOptions As SWPC.PackageOptions, ByVal listTitle As String)

        _document = New Document()

        _document.Info.Title = "List - 3D Views"
        _document.Info.Subject = "Cheat sheet of part views"
        _document.Info.Author = "Inovatech Engineering Corp."

        Me.listTitle = listTitle

        defineStyles()
        createPage()

        partList = swDocs.OrderBy(Function(x) x.partName).ToList
        fillTable(partList)

    End Sub

    Public Sub outputDocument()
        _document.UseCmykColor = True

        Dim pdfRenderer = New PdfDocumentRenderer(True)

        pdfRenderer.Document = _document
        pdfRenderer.RenderDocument()

        Dim fileName = String.Format("ViewList_{0}.pdf", listTitle)

#If DEBUG Then
        'I don't want to close the document constantly...
        fileName = fileName + Guid.NewGuid().ToString("N").ToUpper() + ".pdf"
#End If
        pdfRenderer.Save(System.IO.Path.Combine(pkgOptions.pkgOutputPath, fileName))
        '...and start a viewer.

#If DEBUG Then
        Process.Start(System.IO.Path.Combine(pkgOptions.pkgOutputPath, fileName))
#End If
    End Sub

    Private Sub defineStyles()
        Dim style As Style = _document.Styles("Normal")

        'Get the predefine style Normal.
        style.Font.Name = "Segoe UI"
        'Because all styles are derived from Normal, the next line changes the 
        'font of the whole document. Or, more exactly, it changes the font of
        'all styles and paragraphs that do not redefine the font.
        style = _document.Styles(StyleNames.Header)
        style.ParagraphFormat.AddTabStop("19cm", TabAlignment.Right)

        style = _document.Styles(StyleNames.Footer)
        style.ParagraphFormat.AddTabStop("19cm", TabAlignment.Right)

        'Create a new style called Table based on style Normal.
        style = _document.Styles.AddStyle("Table", "Normal")
        style.Font.Name = "Segoe UI Semilight"
        style.Font.Size = 9

        'Create a new style called Title based on style Normal.
        style = _document.Styles.AddStyle("Title", "Normal")
        style.Font.Name = "Segoe UI Semibold"
        style.Font.Size = 9

        'Create a new style called Reference based on style Normal.
        style = _document.Styles.AddStyle("Reference", "Normal")
        style.ParagraphFormat.SpaceBefore = "5mm"
        style.ParagraphFormat.SpaceAfter = "5mm"
        style.ParagraphFormat.TabStops.AddTabStop("19cm", TabAlignment.Right)

    End Sub

    Private Sub createPage()
        Dim section As Section = _document.AddSection()

        section.PageSetup = _document.DefaultPageSetup.Clone()
        With section.PageSetup
            'using the pageformat.letter didnt' seem to work...
            .PageWidth = "8.5in"
            .PageHeight = "11.0in"
            .TopMargin = "3.00cm"
            .LeftMargin = "1.295cm"
            .RightMargin = "1.295cm"
            .StartingNumber = 1
        End With

        Dim logo = section.Headers.Primary.AddImage("assets/Logo.png")
        'Place logo in header
        With logo
            .Height = "1.5cm"
            .LockAspectRatio = True
            .RelativeVertical = RelativeVertical.Line
            .RelativeHorizontal = RelativeHorizontal.Margin
            .Top = ShapePosition.Top
            .Left = ShapePosition.Right
            .WrapFormat.Style = WrapStyle.Through
        End With

        'Create a footer
        Dim paragraph = section.Footers.Primary.AddParagraph()
        paragraph.AddText("101 Steve Fonyo Dr ● K0B 1R0 Vankleek Hill ● Canada")
        paragraph.Format.Font.Size = 9
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.AddTab()
        paragraph.AddPageField()
        paragraph.AddText(" of ")
        paragraph.AddNumPagesField()


        paragraph = section.Headers.Primary.AddParagraph(String.Format("List View - {0}", listTitle))
        With paragraph.Format.Font
            .Size = 10
            .Bold = True
        End With
        paragraph.AddLineBreak()
        paragraph.AddText(String.Format("Pkg: {0}/{1}", pkgOptions.machineModel, pkgOptions.projectName))
        paragraph.AddLineBreak()
        paragraph.AddText("Exported Time,Date: ")
        paragraph.AddText(Date.Now.ToLocalTime.ToShortTimeString)
        paragraph.AddText(", ")
        paragraph.AddDateField("dd.MM.yyyy")
        paragraph.Format.SpaceAfter = 1

        'Create table for parts
        _tableParts = section.AddTable()
        _tableParts.Style = "Table"
        _tableParts.Borders.Color = TableBlack
        _tableParts.Borders.Width = 0.25
        _tableParts.Borders.Left.Width = 0.25
        _tableParts.Borders.Right.Width = 0.25
        _tableParts.Rows.LeftIndent = 0

        'Before you can add a row, you must define the columns.
        Dim Column = _tableParts.AddColumn("6.33333cm")
        Column.Format.Alignment = ParagraphAlignment.Center

        Column = _tableParts.AddColumn("6.33333cm")
        Column.Format.Alignment = ParagraphAlignment.Center

        Column = _tableParts.AddColumn("6.33333cm")
        Column.Format.Alignment = ParagraphAlignment.Center

    End Sub

    Private Sub fillTable(ByVal list As List(Of SWDoc))

        'add statistics

        Dim itemNumber As Integer = 0
        Dim row As Row = Nothing
        For Each doc In list

            If itemNumber Mod 3 = 0 Then
                row = _tableParts.AddRow()
                row.HeadingFormat = False
                row.Format.Alignment = ParagraphAlignment.Center
                row.Format.Font.Bold = True
            End If
            fillCell(itemNumber Mod 3, row, doc)

            itemNumber += 1
        Next

    End Sub

    Private Sub fillCell(ByVal cellNumber As Integer, ByRef row As Row, ByRef part As SWDoc)

        Dim imgPath As String = System.IO.Path.Combine(pkgOptions.pathSnapshots, part.fullPartName & ".png")

        Dim paragraph As Paragraph

        row.Cells(cellNumber).Format.Font.Bold = False
        row.Cells(cellNumber).Format.Alignment = ParagraphAlignment.Center
        row.Cells(cellNumber).VerticalAlignment = VerticalAlignment.Top
        paragraph = row.Cells(cellNumber).AddParagraph()
        paragraph.AddText(part.fullPartName)

        paragraph = row.Cells(cellNumber).AddParagraph()
        If System.IO.File.Exists(imgPath) Then
            Dim isoView = paragraph.AddImage(imgPath)
            With isoView
                .Height = "4.25cm"
                .LockAspectRatio = True
                .RelativeVertical = RelativeVertical.Paragraph
                .RelativeHorizontal = RelativeHorizontal.Character
                .WrapFormat.Style = WrapStyle.Through
            End With
        End If
        paragraph = row.Cells(cellNumber).AddParagraph()
        Dim formattedText As New FormattedText
        formattedText.Font.Size = 14
        formattedText.Font.Bold = True
        formattedText.AddText(String.Format("Qty - {0}", part.quantity))
        paragraph.Add(formattedText)
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Size = 7
        paragraph.AddText(String.Format("-In:{0}", part.parentFullname))

    End Sub
End Class
