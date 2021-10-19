Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.Rendering
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.DocumentObjectModel.Shapes
Imports PeriodicalReceiptsGenerator.frmReceiptsGeneration
Imports System.IO

Public Class ReceiptGenerator

    Private Const EUR_SUFFIX As String = " EUR"
    Private Const PAYMENT_DESCRIPTION As String = "Consultation services and materials"
    Private Const COUNTRY As String = "Estonia"

    Dim receiptNumber As Integer
    Dim receiptData As Payment
    Dim targetRootFolderPath As String

    Dim receiptDocument As Document
    Dim section As Section

    Public Sub GenerateReceipt(ByVal receiptNumber As Integer, ByRef receiptData As Payment, ByRef targetRootFolderPath As String)
        Me.receiptNumber = receiptNumber
        Me.receiptData = receiptData
        Me.targetRootFolderPath = targetRootFolderPath

        InitializeReceipt()

        DefineStyles()
        CreatePage()
        SaveReceipt()
    End Sub

    Private Sub InitializeReceipt()
        receiptDocument = New Document
        receiptDocument.Info.Title = "Shtern Consulting Receipt"
        receiptDocument.Info.Subject = "Receipt for purchasing of our consultation services and materials"
        receiptDocument.Info.Author = "Anat Stern"
    End Sub

    Private Sub DefineStyles()
        Dim style As Style = receiptDocument.Styles("Normal")
        style.Font.Name = "Arial"
        style.Font.Size = 10

        style = receiptDocument.Styles(StyleNames.Header)
        style.ParagraphFormat.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right)

        style = receiptDocument.Styles(StyleNames.Footer)
        style.ParagraphFormat.AddTabStop("8cm", MigraDoc.DocumentObjectModel.TabAlignment.Center)

        style = receiptDocument.Styles.AddStyle("Table", "Normal")
        style.Font.Name = "Arial"
        style.Font.Size = 9
    End Sub

    Private Sub CreatePage()
        section = receiptDocument.AddSection()

        CreateCompanySignatureFrame()
        CreateReceiptFrame()
        CreateCustomerInfoFrame()
        CreateReceiptTable()
        CreatePaymenthInformation()
        CreateFooter()
    End Sub

    Private Sub CreateCompanySignatureFrame()
        Dim companySignatureFrame As MigraDoc.DocumentObjectModel.Shapes.TextFrame = section.AddTextFrame()
        companySignatureFrame.Height = "3.0cm"
        companySignatureFrame.Width = "7.0cm"
        companySignatureFrame.Left = ShapePosition.Left
        companySignatureFrame.RelativeHorizontal = RelativeHorizontal.Margin
        companySignatureFrame.Top = "2.0cm"
        companySignatureFrame.RelativeVertical = RelativeVertical.Page

        Dim paragraph As Paragraph = companySignatureFrame.AddParagraph("Shtern Consulting OÜ")
        paragraph.Format.Font.Size = 12
        paragraph.Format.Font.Italic = True
        paragraph.Format.Font.Bold = True

        paragraph = section.AddParagraph()
        paragraph.Format.Font.Italic = True
        paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.Gray
        paragraph.Format.SpaceAfter = "0.5cm"
        paragraph.AddText("Reg nr: 12409467")
        paragraph.AddLineBreak()
        paragraph.AddText("KMKR nr: EE101731702")

        paragraph = section.AddParagraph()
        paragraph.Format.LineSpacingRule = LineSpacingRule.Exactly
        paragraph.Format.LineSpacing = "0.5cm"
        paragraph.AddText("Mõisatamme 19")
        paragraph.AddLineBreak()
        paragraph.AddText("Tartu, 60534")
        paragraph.AddLineBreak()
        paragraph.AddText("Estonia")
        paragraph.AddLineBreak()
        paragraph.AddText("Tel: +372-568-15512")
    End Sub

    Private Sub CreateReceiptFrame()
        Dim receiptFrame As MigraDoc.DocumentObjectModel.Shapes.TextFrame = section.AddTextFrame()
        receiptFrame.Height = "3.0cm"
        receiptFrame.Width = "5.0cm"
        receiptFrame.Left = ShapePosition.Right
        receiptFrame.RelativeHorizontal = RelativeHorizontal.Margin
        receiptFrame.Top = "2.0cm"
        receiptFrame.RelativeVertical = RelativeVertical.Page

        Dim paragraph As Paragraph = receiptFrame.AddParagraph("RECEIPT")
        paragraph.Format.Alignment = ParagraphAlignment.Right
        paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.Gray
        paragraph.Format.Font.Bold = True
        paragraph.Format.Font.Size = 20
        paragraph.Format.SpaceAfter = 10

        paragraph = receiptFrame.AddParagraph("Receipt #: " & receiptNumber)
        paragraph.Format.Alignment = ParagraphAlignment.Right
        paragraph.Format.LineSpacingRule = LineSpacingRule.OnePtFive
        paragraph.AddLineBreak()
        paragraph.AddText("Date: " & receiptData.shortDate)
    End Sub

    Private Sub CreateCustomerInfoFrame()
        Dim companySignatureFrame As MigraDoc.DocumentObjectModel.Shapes.TextFrame = section.AddTextFrame()
        companySignatureFrame.Height = "3.0cm"
        companySignatureFrame.Width = "7.0cm"
        companySignatureFrame.Left = ShapePosition.Left
        companySignatureFrame.RelativeHorizontal = RelativeHorizontal.Margin
        companySignatureFrame.Top = "7cm"
        companySignatureFrame.RelativeVertical = RelativeVertical.Page

        Dim paragraph As Paragraph = companySignatureFrame.AddParagraph("Customer:")
        paragraph.Format.Font.Bold = True

        paragraph = companySignatureFrame.AddParagraph
        paragraph.Format.LineSpacingRule = LineSpacingRule.Exactly
        paragraph.Format.LineSpacing = "0.5cm"
        paragraph.AddText(receiptData.name)
        paragraph.AddLineBreak()
        paragraph.AddText(COUNTRY)
    End Sub

    Private Sub CreateReceiptTable()
        Dim TableBorder As MigraDoc.DocumentObjectModel.Color = New MigraDoc.DocumentObjectModel.Color(81, 125, 192)
        Dim TableBlue As MigraDoc.DocumentObjectModel.Color = New MigraDoc.DocumentObjectModel.Color(235, 240, 249)

        Dim sum As Decimal = CDec(receiptData.sum.Replace(",", "."))
        Dim amount As Decimal = Math.Truncate(sum / 1.2 * 100) / 100
        Dim vatAmount As Decimal = sum - amount

        Dim amountWithVATString As String = CStr(sum) & EUR_SUFFIX
        Dim amountNoVATString As String = CStr(amount) & EUR_SUFFIX
        Dim zeroAmountString As String = "0" & EUR_SUFFIX

        Dim paragraph As Paragraph = section.AddParagraph()
        paragraph.Format.SpaceBefore = "3cm"

        Dim invoicingTable As MigraDoc.DocumentObjectModel.Tables.Table

        invoicingTable = section.AddTable()
        invoicingTable.Style = "Table"
        invoicingTable.Borders.Color = TableBorder
        invoicingTable.Borders.Width = 0.25
        invoicingTable.Borders.Left.Width = 0.5
        invoicingTable.Borders.Right.Width = 0.5
        invoicingTable.Rows.LeftIndent = 0

        Dim column As MigraDoc.DocumentObjectModel.Tables.Column = invoicingTable.AddColumn("15cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = invoicingTable.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Center

        Dim row As MigraDoc.DocumentObjectModel.Tables.Row = invoicingTable.AddRow()
        row.HeadingFormat = True
        row.Format.Font.Bold = True
        row.Shading.Color = TableBlue
        row.TopPadding = "0.2cm"
        row.BottomPadding = "0.2cm"

        row.Cells(0).AddParagraph("Description")
        row.Cells(0).Format.Font.Bold = True
        row.Cells(0).VerticalAlignment = VerticalAlignment.Center
        row.Cells(1).AddParagraph("Price")

        row = invoicingTable.AddRow()
        row.TopPadding = "0.2cm"
        row.BottomPadding = "0.2cm"
        row.Cells(0).AddParagraph(PAYMENT_DESCRIPTION)
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(amountNoVATString)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Center

        row = invoicingTable.AddRow()
        row.TopPadding = "0.2cm"
        row.BottomPadding = "0.2cm"
        row.Cells(0).AddParagraph(" ")

        row = invoicingTable.AddRow()
        row.TopPadding = "0.2cm"
        row.BottomPadding = "0.2cm"
        row.Cells(0).AddParagraph(" ")

        row = invoicingTable.AddRow()
        row.TopPadding = "0.2cm"
        row.BottomPadding = "0.2cm"
        row.Cells(0).AddParagraph("SUBTOTAL")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Right
        row.Cells(0).Borders.Left.Visible = False
        row.Cells(0).Borders.Bottom.Visible = False
        row.Cells(1).AddParagraph(amountNoVATString)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Center

        row = invoicingTable.AddRow()
        row.TopPadding = "0.2cm"
        row.BottomPadding = "0.2cm"

        Dim vatLabel As String
        vatLabel = "VAT (20%)"
        row.Cells(0).AddParagraph(vatLabel)
        row.Cells(0).Format.Alignment = ParagraphAlignment.Right
        row.Cells(0).Borders.Left.Visible = False
        row.Cells(0).Borders.Bottom.Visible = False
        row.Cells(1).AddParagraph(CStr(vatAmount) & EUR_SUFFIX)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Center

        row = invoicingTable.AddRow()
        row.TopPadding = "0.2cm"
        row.BottomPadding = "0.2cm"
        row.Cells(0).AddParagraph("TOTAL DUE").Format.Font.Bold = True
        row.Cells(0).Format.Alignment = ParagraphAlignment.Right
        row.Cells(0).Borders.Left.Visible = False
        row.Cells(0).Borders.Bottom.Visible = False
        row.Cells(1).AddParagraph(amountWithVATString).Format.Font.Bold = True
        row.Cells(1).Format.Alignment = ParagraphAlignment.Center
    End Sub

    Private Sub CreatePaymenthInformation()
        Dim companySignatureFrame As MigraDoc.DocumentObjectModel.Shapes.TextFrame = section.AddTextFrame()
        companySignatureFrame.Height = "3.0cm"
        companySignatureFrame.Width = "7.0cm"
        companySignatureFrame.Left = ShapePosition.Left
        companySignatureFrame.RelativeHorizontal = RelativeHorizontal.Margin
        companySignatureFrame.Top = "16.5cm"
        companySignatureFrame.RelativeVertical = RelativeVertical.Page

        Dim paragraph As Paragraph = companySignatureFrame.AddParagraph()
        paragraph.AddFormattedText("Payment method", TextFormat.Bold)
        paragraph.AddText(": " & GetPaymentDetails())
    End Sub

    Private Function GetPaymentDetails() As String
        Return "bank transfer"
    End Function

    Private Sub CreateFooter()
        Dim footerFrame As MigraDoc.DocumentObjectModel.Shapes.TextFrame = section.AddTextFrame()
        footerFrame.Height = "10cm"
        footerFrame.Width = "18cm"
        footerFrame.Left = ShapePosition.Left
        footerFrame.RelativeHorizontal = RelativeHorizontal.Margin
        footerFrame.Top = "16.5cm"
        footerFrame.RelativeVertical = RelativeVertical.Page

        Dim paragraph As Paragraph = footerFrame.AddParagraph("Thank you for your purchase!")
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Bold = True
        paragraph.Format.SpaceBefore = "0.5cm"
        paragraph.Format.SpaceAfter = "0.5cm"

        paragraph = footerFrame.AddParagraph("Please, allow us 24 hours for shipping your materials, in the case that you ordered a shippable item.")
        paragraph.Format.Alignment = ParagraphAlignment.Justify
        paragraph.Format.SpaceBefore = "0.5cm"
        paragraph.Format.SpaceAfter = "0.5cm"
    End Sub

    Private Function SaveReceipt() As Boolean
        Dim receiptFilename As String = GetDatedReceiptPath(receiptNumber, receiptData.name, receiptData.shortDate)
        Try
            Dim pdfRenderer As New PdfDocumentRenderer(False, PdfSharp.Pdf.PdfFontEmbedding.Always)
            pdfRenderer.Document = receiptDocument
            pdfRenderer.RenderDocument()
            pdfRenderer.PdfDocument.Save(receiptFilename)
            Return True
        Catch e As Exception
            MsgBox("Failed to save the receipt document " & receiptFilename & ": " & e.ToString)
            Return False
        End Try
    End Function

    Private Function GetDatedReceiptPath(ByRef receiptNumber As Integer, ByRef clientName As String, ByRef shortDate As String) As String
        Dim receiptDate As Date = Date.ParseExact(shortDate, "dd-MM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim monthFolder As String = receiptDate.Year & "\"
        If receiptDate.Month < 10 Then
            monthFolder = monthFolder & "0" & receiptDate.Month
        Else
            monthFolder = monthFolder & "\" & receiptDate.Month
        End If
        monthFolder = monthFolder & " " & receiptDate.Year

        If Not Directory.Exists(targetRootFolderPath & "\" & monthFolder) Then
            Directory.CreateDirectory(targetRootFolderPath & "\" & monthFolder)
        End If

        Return targetRootFolderPath & "\" & monthFolder & "\" & CStr(receiptNumber) & " Receipt " & clientName & ".pdf"
    End Function

End Class
