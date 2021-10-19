Imports System.Windows.Forms
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.Rendering
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.DocumentObjectModel.Shapes
Imports System.IO
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop

Public Class dlgGenerateReceipt

    Private Const EUR_SUFFIX As String = " EUR"

    Private paymentMethod As String
    Private customerFirstName As String
    Private customerEmail As String
    Private customerCountry As String
    Private customerLanguage As String
    Private customerSite As String
    Private customerAmountWithVAT As String
    Private receiptNumber As Integer
    Private receiptFilename As String
    Private receiptGenerated As Boolean

    Public Sub setPaymentMethod(ByVal paymentMethod As String)
        Me.paymentMethod = paymentMethod
    End Sub

    Public Sub setCustomerCountry(ByVal customerCountry As String)
        Me.customerCountry = customerCountry
    End Sub

    Public Sub setCustomerLanguage(ByVal customerLanguage As String)
        Me.customerLanguage = customerLanguage
    End Sub

    Public Sub setCustomerFirstName(ByVal customerFirstName As String)
        Me.customerFirstName = customerFirstName
    End Sub

    Public Sub setCustomerEmail(ByVal customerEmail As String)
        Me.customerEmail = customerEmail
    End Sub

    Public Sub setCustomerSite(ByVal customerSite As String)
        Me.customerSite = customerSite
    End Sub

    Public Sub setCustomerAmountWithVAT(ByVal customerAmountWithVAT As String)
        Me.customerAmountWithVAT = customerAmountWithVAT
    End Sub

    Public Function GetReceiptFilename() As String
        Return receiptFilename
    End Function

    Private Sub btnGenerateReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateReceipt.Click
        Dim generatedAndSent As Boolean = False
        If Not ValidateInput() Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        SaveSettings()
        GenerateReceipt()
        btnSend2Client.Enabled = receiptGenerated
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSend2Client_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend2Client.Click
        Me.Cursor = Cursors.WaitCursor
        SendReceipt()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SaveSettings()
        My.Settings.LastReceiptNumber = receiptNumber

        Dim found As Boolean = False
        For Each itemDescription In My.Settings.ItemDescriptions
            If itemDescription = lstItemDescription.Text.Trim Then
                found = True
            End If
        Next
        If Not found Then
            My.Settings.ItemDescriptions.Add(lstItemDescription.Text.Trim)
            lstItemDescription.Items.Add(lstItemDescription.Text.Trim)
        End If

        My.Settings.Save()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If receiptGenerated Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Abort
        End If
        Me.Close()
    End Sub

    Private Function IsEmpty(ByRef value As String) As Boolean
        If value Is Nothing Then
            Return True
        ElseIf value.Trim.Length = 0 Then
            Return True
        End If
        Return False
    End Function

    Private Function ValidateInput() As Boolean
        If IsEmpty(fldEnglishName.Text) Then
            MsgBox("Please, enter English Name of the Customer")
            Return False
        End If
        Dim receiptDate As String = fldDateTimePicker.Text
        If IsEmpty(receiptDate) Then
            MsgBox("Please, enter valid Receipt Date")
            Return False
        End If
        If IsEmpty(fldAmount.Text) Then
            MsgBox("Please, enter valid Receipt Amount in EUR")
            Return False
        End If
        If IsEmpty(lstItemDescription.Text) Then
            MsgBox("Please, enter an item description")
            Return False
        End If
        If paymentMethod = Helper.PAYMENT_CREDIT And IsEmpty(fldPaymentDetails.Text) Then
            MsgBox("Please, enter Credit Card transaction details")
            Return False
        End If
        If Not IsEmpty(fldReceiptNumber.Text) Then
            Dim tempReceiptNumber As Integer
            Try
                tempReceiptNumber = CInt(fldReceiptNumber.Text.Trim)
                fldReceiptNumber.Text = CStr(tempReceiptNumber)
            Catch ex As Exception
                MsgBox("Receipt number is not a valid integer")
                Return False
            End Try
            If tempReceiptNumber <> My.Settings.LastReceiptNumber + 1 Then
                Dim result As MsgBoxResult = MsgBox("Press YES to use the entered number. Press NO to generate one", MsgBoxStyle.YesNoCancel)
                If result = MsgBoxResult.Cancel Then
                    Return False
                ElseIf result = MsgBoxResult.No Then
                    fldReceiptNumber.Text = receiptNumber
                Else
                    receiptNumber = tempReceiptNumber
                End If
            End If
        Else
            fldReceiptNumber.Text = receiptNumber
        End If
        Return True
    End Function

    Private Sub dlgGenerateReceipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        receiptNumber = My.Settings.LastReceiptNumber + 1
        fldReceiptNumber.Text = receiptNumber
        fldAmount.Text = customerAmountWithVAT

        For Each country In GetPredefinedCountriesList()
            Dim added As Integer = lstCountries.Items.Add(country)
            If country = customerCountry Then
                lstCountries.SelectedIndex = added
            End If
        Next

        For Each itemDescription In My.Settings.ItemDescriptions
            lstItemDescription.Items.Add(itemDescription)
        Next
        lstItemDescription.SelectedIndex = 0

        fldSaveDirectory.Text = My.Settings.SaveDirectory
        receiptGenerated = False
    End Sub

    Public Function GetPredefinedCountriesList() As List(Of String)
        Dim countries As New List(Of String)
        countries.Add(Helper.COUNTRY_ESTONIA)
        countries.Add(Helper.COUNTRY_FINLAND)
        countries.Add(Helper.COUNTRY_ISRAEL)
        countries.Add(Helper.COUNTRY_LITHUANIA)
        countries.Add(Helper.COUNTRY_RUSSIA)
        countries.Add(Helper.COUNTRY_SWEDEN)
        countries.Add(Helper.COUNTRY_UKRAIN)
        countries.Add(Helper.COUNTRY_UNITED_KINDOM)
        countries.Add(Helper.COUNTRY_UNITED_STATES)
        Return countries
    End Function

    Private Sub GenerateReceipt()
        If IsEmpty(fldSaveDirectory.Text) Or Not FileIO.FileSystem.DirectoryExists(fldSaveDirectory.Text) Then
            MsgBox("Please, select a valid directory to save the receipts to")
        End If

        receipt = New Document
        receipt.Info.Title = "Shtern Consulting Receipt"
        receipt.Info.Subject = "Receipt for buying one or more Dieting Packages"
        receipt.Info.Author = "Anat Stern"

        DefineStyles()
        CreatePage()

        receiptGenerated = SaveAndOpenDocument()
    End Sub

    Private TableBorder As MigraDoc.DocumentObjectModel.Color = New MigraDoc.DocumentObjectModel.Color(81, 125, 192)
    Private TableBlue As MigraDoc.DocumentObjectModel.Color = New MigraDoc.DocumentObjectModel.Color(235, 240, 249)

    Dim receipt As Document
    Dim invoicingTable As MigraDoc.DocumentObjectModel.Tables.Table
    Dim section As Section

    Private Sub DefineStyles()
        Dim style As Style = receipt.Styles("Normal")
        style.Font.Name = "Arial"
        style.Font.Size = 10

        style = receipt.Styles(StyleNames.Header)
        style.ParagraphFormat.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right)

        style = receipt.Styles(StyleNames.Footer)
        style.ParagraphFormat.AddTabStop("8cm", MigraDoc.DocumentObjectModel.TabAlignment.Center)

        style = receipt.Styles.AddStyle("Table", "Normal")
        style.Font.Name = "Arial"
        style.Font.Size = 9
    End Sub

    Private Sub CreatePage()
        section = receipt.AddSection()

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
        paragraph.AddText("Date: " & fldDateTimePicker.Text)
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
        paragraph.AddText(fldEnglishName.Text)
        paragraph.AddLineBreak()
        paragraph.AddText(lstCountries.Text.Trim)
    End Sub

    Private Sub CreateReceiptTable()
        Dim amount As Decimal = If(Helper.IsEU(lstCountries.Text.Trim), Math.Truncate(CDec(fldAmount.Text.Trim) / 1.2 * 100) / 100, CDec(fldAmount.Text.Trim))
        Dim vatAmount As Decimal = CDec(fldAmount.Text.Trim) - amount

        Dim amountWithVATString As String = fldAmount.Text.Trim & EUR_SUFFIX
        Dim amountNoVATString As String = CStr(amount) & EUR_SUFFIX
        Dim zeroAmountString As String = "0" & EUR_SUFFIX

        Dim paragraph As Paragraph = section.AddParagraph()
        paragraph.Format.SpaceBefore = "3cm"

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
        row.Cells(0).AddParagraph(lstItemDescription.Text.Trim)
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
        If Helper.IsEU(lstCountries.Text.Trim) Then
            vatLabel = "VAT (20%)"
        Else
            vatLabel = "VAT (0%)"
        End If
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
        If Helper.IsEU(lstCountries.Text.Trim) Then
            row.Cells(1).AddParagraph(amountWithVATString).Format.Font.Bold = True
        Else
            row.Cells(1).AddParagraph(amountWithVATString).Format.Font.Bold = True
        End If
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
        If paymentMethod = Helper.PAYMENT_CASH Then
            Return "cash"
        ElseIf paymentMethod = Helper.PAYMENT_CREDIT Then
            Return "online - " & fldPaymentDetails.Text.Trim
        Else
            Return "bank transfer"
        End If
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

        paragraph = footerFrame.AddParagraph("Please, allow us 24 hours for shipping your package, in the case that you ordered a shippable item. Within 24 hours you will also receive your instructions for entering the client's support area on our website.")
        paragraph.Format.Alignment = ParagraphAlignment.Justify
        paragraph.Format.SpaceBefore = "0.5cm"
        paragraph.Format.SpaceAfter = "0.5cm"

        paragraph = footerFrame.AddParagraph()
        paragraph.AddFormattedText("Return Policy", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.SpaceBefore = "0.5cm"

        paragraph = footerFrame.AddParagraph()
        paragraph.AddText("Due to the nature of our product, we cannot provide you any refund once the physical package and the access instructions have been mailed and/or emailed to you. You have 24 hours to request an immediate refund before we ship your package. After that period, if you feel and kind of dissatisfaction and would like to request full or partial refund, please, don't hesitate to contact us over email of phone provided below, and your case would be looked into personally and resolved to the mutual satisfaction.")
        paragraph.Format.Alignment = ParagraphAlignment.Justify
        paragraph.Format.SpaceAfter = "0.5cm"
    End Sub

    Private Function SaveAndOpenDocument() As Boolean
        receiptFilename = Helper.GetDatedReceiptPath(receiptNumber, fldEnglishName.Text.Trim, fldDateTimePicker.Value)
        Try
            Dim pdfRenderer As New PdfDocumentRenderer(False, PdfSharp.Pdf.PdfFontEmbedding.Always)
            pdfRenderer.Document = receipt
            pdfRenderer.RenderDocument()
            pdfRenderer.PdfDocument.Save(receiptFilename)
            Process.Start(receiptFilename)
            Return True
        Catch e As Exception
            MsgBox("Failed to save and open the document " & receiptFilename, e.ToString)
            Return False
        End Try
    End Function

    Private Sub btnSelectSaveFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSaveFolder.Click
        If FolderBrowserDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            fldSaveDirectory.Text = FolderBrowserDialog.SelectedPath
            My.Settings.SaveDirectory = FolderBrowserDialog.SelectedPath
            My.Settings.Save()
        End If
    End Sub

    Private Sub SendReceipt()
        If Not File.Exists(receiptFilename) Then
            MsgBox("Receipt file not found: " & receiptFilename & ", can't send it")
            Exit Sub
        End If

        Dim senderEmail As String = "contact@" & customerSite.ToLower()
        Dim anatEmail As String = "contact@dietasimeonsa.eu"

        Dim subject As String = BuildEmailSubject()
        Dim bodyHtml As String = BuildEmailBody(senderEmail, customerAmountWithVAT)

        Try
            Dim olApp As Outlook.Application = CreateObject("Outlook.Application")
            Dim firstEmail As Outlook.MailItem = DirectCast(olApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)

            firstEmail.Subject = subject
            firstEmail.BodyFormat = Outlook.OlBodyFormat.olFormatHTML
            firstEmail.HTMLBody = bodyHtml
            firstEmail.Attachments.Add(receiptFilename)

            firstEmail.Recipients.Add(customerEmail)
            firstEmail.ReplyRecipients.Add(senderEmail)
            firstEmail.BCC = anatEmail

            For Each sender As Outlook.Account In olApp.Application.Session.Accounts
                If sender.SmtpAddress.ToLower.StartsWith("contact") And sender.SmtpAddress.ToLower.Contains(customerSite.ToLower) Then
                    firstEmail.SendUsingAccount = sender
                    Exit For
                End If
            Next

            firstEmail.Send()
            firstEmail = Nothing
            olApp = Nothing
        Catch ex As Exception
            MsgBox("Failed to send receipt to the customer " & ex.ToString)
        End Try
    End Sub

    Private Function BuildEmailSubject() As String
        If customerLanguage = Helper.LANG_HEBREW Then
            Return "תודה שקנית מאיתנו! מצורפת חשבונית"
        ElseIf customerLanguage = Helper.LANG_RUSSIAN Then
            Return "Спасибо за вашу покупку! Приложена накладная"
        ElseIf customerLanguage = Helper.LANG_ESTONIAN Then
            Return "Täname teid ostu eest! Lisatud arve"
        ElseIf customerLanguage = Helper.LANG_ENGLISH Then
            Return "Thank you for your purchase! Attached the receipt"
        Else
            Return Nothing
        End If
    End Function

    Private Function BuildEmailBody(ByVal contactEmail As String, ByVal amountWithVAT As String) As String
        Dim bodyFilePath As String = AppDomain.CurrentDomain.BaseDirectory & "Invoicing\Receipt." & _
                                            Helper.GetShortLanguage(customerLanguage) & ".html"
        Dim htmlBody As String = System.IO.File.ReadAllText(bodyFilePath)
        htmlBody = htmlBody.Replace("[[customerFirstName]]", customerFirstName)
        htmlBody = htmlBody.Replace("[[euro]]", amountWithVAT)
        htmlBody = htmlBody.Replace("[[customerSite]]", customerSite)
        Return htmlBody
    End Function
End Class
