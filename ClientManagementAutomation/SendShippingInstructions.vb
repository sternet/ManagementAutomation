Imports System.Windows.Forms
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports System.Net.Mail

Public Class dlgSendShippingInstructions

    Private Const BODY_HEADER = "<html><head><meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" /><body dir=""[[direction]]"" style=""font-size: 16px"">"
    Private Const BODY_FOOTER = "</body></html>"

    Private customerFirstName As String
    Private customerLastName As String
    Private customerPhone As String
    Private customerAddress As String
    Private customerLanguage As String = Helper.LANG_HEBREW
    Private customerPackage As String
    Private customerSite As String

    Public Sub setCustomerSite(ByVal customerSite As String)
        Me.customerSite = customerSite
    End Sub

    Public Sub setCustomerPackage(ByVal customerPackage As String)
        Me.customerPackage = customerPackage
    End Sub

    Public Sub setCustomerLanguage(ByVal customerLanguage As String)
        Me.customerLanguage = customerLanguage
    End Sub

    Public Sub setCustomerFirstName(ByVal customerFirstName As String)
        Me.customerFirstName = customerFirstName
    End Sub

    Public Sub setCustomerLastName(ByVal customerLastName As String)
        Me.customerLastName = customerLastName
    End Sub

    Public Sub setCustomerPhone(ByVal customerPhone As String)
        Me.customerPhone = customerPhone
    End Sub

    Public Sub setCustomerAddress(ByVal customerAddress As String)
        Me.customerAddress = customerAddress
    End Sub

    Private Sub dlgSendShippingInstructions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbShippingMethod.Items.Add(Helper.SHIPPING_METHOD_REGISTERED_MAIL)
        cmbShippingMethod.Items.Add(Helper.SHIPPING_METHOD_COURIER)
        cmbShippingMethod.Items.Add(Helper.SHIPPING_METHOD_SHIPPMENT_ABROAD)
        cmbShippingMethod.Items.Add(Helper.SHIPPING_METHOD_PICKUP)
        cmbShippingMethod.SelectedIndex = 0

        If Not My.Settings.DeliveryPersonEmails Is Nothing Then
            For Each deliveryPersonEmail In My.Settings.DeliveryPersonEmails
                cmbDeliveryPerson.Items.Add(deliveryPersonEmail)
            Next
        End If
        If cmbDeliveryPerson.Items.Count > 0 Then
            cmbDeliveryPerson.SelectedIndex = 0
        End If

        fldSubject.Text = BuildSubject()
        fldBody.Text = BuildBody()

        If customerLanguage = Helper.LANG_HEBREW Then
            fldSubject.RightToLeft = Windows.Forms.RightToLeft.Yes
            fldBody.RightToLeft = Windows.Forms.RightToLeft.Yes
        End If
    End Sub

    Private Function BuildSubject() As String
        Return customerFirstName & " - " & TranslatePackageContent() & " - " & TranslateShippingMethod()
    End Function

    Private Function HasGlobulesAndBook() As Boolean
        If customerPackage = Helper.PACKAGE_FULL_BOOK Or customerPackage = Helper.PACKAGE_BASIC_BOOK Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function BookOnly() As Boolean
        Return customerPackage = Helper.PACKAGE_BOOK
    End Function

    Private Function TranslatePackageContent() As String
        If customerLanguage = Helper.LANG_HEBREW Then
            If HasGlobulesAndBook() Then
                Return "ערכה עם מדריך בעברית"
            ElseIf BookOnly() Then
                Return "מדריך בעברית"
            Else
                Return "ערכה"
            End If
        ElseIf customerLanguage = Helper.LANG_RUSSIAN Then
            If HasGlobulesAndBook() Then
                Return "Пакет с руководством на русском"
            ElseIf BookOnly() Then
                Return "Руководство на русском"
            Else
                Return "Пакет"
            End If
        ElseIf customerLanguage = Helper.LANG_ESTONIAN Then
            If HasGlobulesAndBook() Then
                Return "Pakk koos eesti juhendiga"
            ElseIf BookOnly() Then
                Return "Eesti juhend"
            Else
                Return "Pakk"
            End If
        Else 'English
            If HasGlobulesAndBook() Then
                Return "Package with english guide"
            ElseIf BookOnly() Then
                Return "English guide"
            Else
                Return "Package"
            End If
        End If
    End Function

    Private Function TranslateShippingMethod() As String
        If cmbShippingMethod.Text = Helper.SHIPPING_METHOD_REGISTERED_MAIL Then
            If customerLanguage = Helper.LANG_HEBREW Then
                Return "דואר רשום"
            ElseIf customerLanguage = Helper.LANG_RUSSIAN Then
                Return "Зарегистрированная посылка"
            ElseIf customerLanguage = Helper.LANG_ESTONIAN Then
                Return "Тähitud pakk"
            Else
                Return Helper.SHIPPING_METHOD_REGISTERED_MAIL
            End If
        ElseIf cmbShippingMethod.Text = Helper.SHIPPING_METHOD_COURIER Then
            If customerLanguage = Helper.LANG_HEBREW Then
                Return "שליח"
            ElseIf customerLanguage = Helper.LANG_RUSSIAN Then
                Return "Посыльный"
            ElseIf customerLanguage = Helper.LANG_ESTONIAN Then
                Return "Kullersaadetis"
            Else
                Return Helper.SHIPPING_METHOD_COURIER
            End If
        ElseIf cmbShippingMethod.Text = Helper.SHIPPING_METHOD_SHIPPMENT_ABROAD Then
            If customerLanguage = Helper.LANG_HEBREW Then
                Return "משלוח לחו""ל"
            ElseIf customerLanguage = Helper.LANG_RUSSIAN Then
                Return "Посылка зарубеж"
            ElseIf customerLanguage = Helper.LANG_ESTONIAN Then
                Return "Välismaale"
            Else
                Return Helper.SHIPPING_METHOD_SHIPPMENT_ABROAD
            End If
        ElseIf cmbShippingMethod.Text = Helper.SHIPPING_METHOD_PICKUP Then
            If customerLanguage = Helper.LANG_HEBREW Then
                Return "איסוף"
            ElseIf customerLanguage = Helper.LANG_RUSSIAN Then
                Return "Заберёт"
            ElseIf customerLanguage = Helper.LANG_ESTONIAN Then
                Return "Võtab"
            Else
                Return Helper.SHIPPING_METHOD_PICKUP
            End If
        Else
            Return ""
        End If
    End Function

    Private Function BuildBody() As String
        Return "================" & vbCrLf & _
                customerFirstName & " " & customerLastName & vbCrLf & _
                customerAddress & vbCrLf & _
                "================" & vbCrLf & _
                GetCustomerPhone()
    End Function

    Private Function GetCustomerPhone() As String
        If cmbShippingMethod.Text = Helper.SHIPPING_METHOD_COURIER Then
            Return customerPhone
        Else
            Return ""
        End If
    End Function

    'Private Function TranslateCount() As String
    '    If customerLanguage = Helper.LANG_HEBREW Then
    '        Return "כמות של ערכות"
    '    ElseIf customerLanguage = Helper.LANG_RUSSIAN Then
    '        Return "Количество пакетов"
    '    ElseIf customerLanguage = Helper.LANG_ESTONIAN Then
    '        Return "Pakendite arv"
    '    Else
    '        Return "Number of packages"
    '    End If
    'End Function

    'Private Function TranslateName() As String
    '    If customerLanguage = Helper.LANG_HEBREW Then
    '        Return "שם פרטי"
    '    ElseIf customerLanguage = Helper.LANG_RUSSIAN Then
    '        Return "Имя клиента"
    '    ElseIf customerLanguage = Helper.LANG_ESTONIAN Then
    '        Return "Kliendi nimi"
    '    Else
    '        Return "Customer name"
    '    End If
    'End Function

    'Private Function TranslateShippingAddress() As String
    '    If customerLanguage = Helper.LANG_HEBREW Then
    '        Return "כתובת למשלוח"
    '    ElseIf customerLanguage = Helper.LANG_RUSSIAN Then
    '        Return "Адрес пересылки"
    '    ElseIf customerLanguage = Helper.LANG_ESTONIAN Then
    '        Return "Postiaadress"
    '    Else
    '        Return "Shipping address"
    '    End If
    'End Function

    'Private Function TranslatePhone() As String
    '    If customerLanguage = Helper.LANG_HEBREW Then
    '        Return "טלפון ליצירת קשר"
    '    ElseIf customerLanguage = Helper.LANG_RUSSIAN Then
    '        Return "Телефон для связи"
    '    ElseIf customerLanguage = Helper.LANG_ESTONIAN Then
    '        Return "Kontakttelefon"
    '    Else
    '        Return "Contact phone"
    '    End If
    'End Function

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Send_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Send_Button.Click
        If Not ValidateInformation() Then Exit Sub
        If SendShippingInstructionsViaSMTP() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        End If
        Me.Close()
    End Sub

    Private Function SendShippingInstructionsViaOutlook() As Boolean
        Dim anatEmail As String = "contact@" & customerSite.ToLower()

        Dim subject As String = fldSubject.Text.Trim
        Dim bodyHtml As String = BuildEmailBodyHtml()

        Dim mailSent As Boolean = True

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim olApp As Outlook.Application = CreateObject("Outlook.Application")
            Dim firstEmail As Outlook.MailItem = DirectCast(olApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)

            firstEmail.Subject = subject
            firstEmail.BodyFormat = Outlook.OlBodyFormat.olFormatHTML
            firstEmail.HTMLBody = bodyHtml

            firstEmail.Recipients.Add(cmbDeliveryPerson.Text)
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
            MsgBox("Failed to send shipping instructions to the delivery person" & ex.ToString)
            mailSent = False
        End Try
        Me.Cursor = Cursors.Default

        Return mailSent
    End Function

    Private Function SendShippingInstructionsViaSMTP() As Boolean
        Dim anatEmail As String = "contact@" & customerSite.ToLower()

        Dim subject As String = fldSubject.Text.Trim
        Dim bodyHtml As String = BuildEmailBodyHtml()

        Dim mailSent As Boolean = True

        Me.Cursor = Cursors.WaitCursor
        Try
            Helper.SendMail(anatEmail, anatEmail, anatEmail, anatEmail, cmbDeliveryPerson.Text, cmbDeliveryPerson.Text, True, subject, bodyHtml)
        Catch ex As Exception
            MsgBox("Failed to send shipping instructions to the delivery person: " & ex.Message)
            mailSent = False
        End Try

        Me.Cursor = Cursors.Default

        Return mailSent
    End Function

    Private Function BuildEmailBodyHtml() As String
        Return BODY_HEADER.Replace("[[direction]]", GetBodyDirection()) & fldBody.Text.Replace(vbCrLf, "<br/>") & BODY_FOOTER
    End Function

    Private Function BuildEmailBodyText() As String
        Return fldBody.Text.Trim
    End Function

    Private Function GetBodyDirection() As String
        If customerLanguage = Helper.LANG_HEBREW Then
            Return "rtl"
        Else
            Return "lrt"
        End If
    End Function

    Private Function ValidateInformation() As Boolean
        If cmbShippingMethod.SelectedIndex = -1 Then
            MsgBox("Please, select the shipping method")
            Return False
        End If
        If cmbDeliveryPerson.SelectedIndex = -1 Then
            MsgBox("Please, select a delivery person's email")
            Return False
        End If
        If Helper.IsEmpty(fldSubject.Text) Then
            MsgBox("Subject is empty! Change any field to the left to rebuild")
        End If
        If Helper.IsEmpty(fldBody.Text) Then
            MsgBox("Body is empty! Change any field to the left to rebuild")
        End If
        If cmbShippingMethod.Text = Helper.SHIPPING_METHOD_COURIER And Helper.IsEmpty(customerPhone) Then
            MsgBox("Please, supply customer phone before sending shipping instructions with courier delivery")
        End If
        Return True
    End Function

    Private Sub cmbPackageContent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fldSubject.Text = BuildSubject()
        fldBody.Text = BuildBody()
    End Sub

    Private Sub cmbShippingMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShippingMethod.SelectedIndexChanged
        fldSubject.Text = BuildSubject()
        fldBody.Text = BuildBody()
    End Sub

    Private Sub fldCount_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fldSubject.Text = BuildSubject()
        fldBody.Text = BuildBody()
    End Sub

    Private Sub btnAddDeliveryPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDeliveryPerson.Click
        Dim newDeliveryPersonEmail As String = InputBox("Please, supply delivery person's email", "Add new delivery person")
        If Not Helper.IsEmpty(newDeliveryPersonEmail) Then
            If My.Settings.DeliveryPersonEmails Is Nothing Then
                My.Settings.DeliveryPersonEmails = New System.Collections.Specialized.StringCollection
            End If
            My.Settings.DeliveryPersonEmails.Add(newDeliveryPersonEmail)
            My.Settings.Save()
            cmbDeliveryPerson.Items.Add(newDeliveryPersonEmail)
        End If
    End Sub

    Private Sub btnRemoveDeliveryPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveDeliveryPerson.Click
        If cmbDeliveryPerson.SelectedIndex = -1 Then
            MsgBox("Please, select a delivery person's email to delete")
            Exit Sub
        End If
        If MsgBox("Delete delivery person's email " & cmbDeliveryPerson.Text & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            My.Settings.DeliveryPersonEmails.Remove(cmbDeliveryPerson.Text)
            My.Settings.Save()
            cmbDeliveryPerson.Items.Remove(cmbDeliveryPerson.Text)
        End If
    End Sub
End Class
