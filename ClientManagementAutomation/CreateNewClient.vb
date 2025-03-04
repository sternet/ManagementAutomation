Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports System.Text
Imports System.IO
Imports System.Deployment.Application
Imports System.Net.Mail

Public Class CreateNewClient

    Private Const DIARY_NEWCLIENT = "http://simeonsdietdiary.com/diary_crm_create.php"
    Private Const SITE_NEWCLIENT = "/site_crm_create.php"
    Private Const MAILING_NEWCLIENT = "/mailing_crm_create.php"

    Private loadedClient As Client = Nothing

    Private Function ValidateOrderInformation(Optional ByVal generatePassword As Boolean = True, Optional ByVal ignorePassword As Boolean = False) As Boolean
        If Helper.IsEmpty(tbFirstName.Text) Then
            MsgBox("Please, provide first name")
            tbFirstName.Focus()
            Return False
        End If
        If Helper.IsEmpty(tbLastName.Text) Then
            MsgBox("Please, provide last name")
            tbLastName.Focus()
            Return False
        End If
        If Helper.IsEmpty(tbEmail.Text) Then
            MsgBox("Please, provide email")
            tbEmail.Focus()
            Return False
        End If
        If Helper.IsEmpty(cmbPackage.Text) Then
            MsgBox("Please, select package")
            cmbPackage.Focus()
            Return False
        End If
        If Helper.IsEmpty(cmbLanguage.Text) Then
            MsgBox("Please, select language")
            cmbLanguage.Focus()
            Return False
        End If
        If Helper.IsEmpty(cmbSites.Text) Then
            MsgBox("Please, select site")
            cmbSites.Focus()
            Return False
        End If
        If Helper.IsEmpty(tbPassword.Text) Then
            If generatePassword Then
                tbPassword.Text = Helper.GeneratePassword()
            ElseIf Not ignorePassword Then
                MsgBox("Password missing! Please, click Diary or Site buttons first")
                Return False
            End If
        End If
        Return True
    End Function

    Private Function ValidateShippingInformation() As Boolean
        If Helper.IsEmpty(cmbPaymentMethod.Text) Then
            MsgBox("Please, select payment method")
            cmbPaymentMethod.Focus()
            Return False
        End If
        If Helper.IsEmpty(tbAmount.Text) Then
            MsgBox("Please, provide paid amount")
            tbAmount.Focus()
            Return False
        End If
        If cmbPaymentMethod.Text.Trim <> Helper.PAYMENT_CASH Then
            If Helper.IsEmpty(tbShippingAddress.Text) Then
                MsgBox("Credit card payment - shipping address is probably needed")
                Return True
            End If
        End If
        Return True
    End Function

    Private Sub btnDiary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiary.Click
        If Not ValidateOrderInformation() Then Return
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim la = Helper.GetShortLanguage(cmbLanguage.Text)
            Dim passwordMD5 = Helper.GetMd5Hash(tbPassword.Text)
            Dim supporterEmail As String = Helper.ExtractSupporterEmail(cmbSupporter.Text.Trim)
            Dim url As String = String.Format("{0}?firstName={1}&lastName={2}&email={3}&language={4}&password={5}&supporter={6}", DIARY_NEWCLIENT, tbFirstName.Text.Trim, tbLastName.Text.Trim, tbEmail.Text.Trim, la, passwordMD5, supporterEmail)
            Helper.Log("Invoking Diary script: " + url)
            Dim requester = New Net.WebClient
            requester.Headers.Add("user-agent", GetUserAgent())
            requester.Encoding = Encoding.UTF8
            Dim result As String = requester.DownloadString(url)
            Helper.Log("Received response: " + result)
            If result.Contains("successfully") Or result.Contains("already") Then
                lblDiaryStatus.BackColor = Color.Green
                SendNotificationToAnatSternViaSMTP(tbPassword.Text.Trim, cmbSupporter.Text.Trim)
            Else
                lblDiaryStatus.BackColor = Color.Red
            End If
            ClearToolStripMenuItem.Enabled = True
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Helper.Log("Failed to create diary user: " + ex.Message)
            lblDiaryStatus.BackColor = Color.Red
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SendNotificationToAnatSternViaSMTP(ByRef password As String, ByRef supporterEmail As String)
        Dim anatEmail As String = "contact@dietasimeonsa.eu"
        Dim bodyHtml As String = BuildNotificationBody(password, supporterEmail)

        Try
            Helper.SendMail(anatEmail, anatEmail, anatEmail, anatEmail, anatEmail, anatEmail, False, "Клиент создан в дневнике", bodyHtml)
        Catch ex As Exception
            MsgBox("Failed to send notification to Anat Stern " & ex.Message)
        End Try
    End Sub
    Private Function GetUserAgent() As String
        Dim assemblyName As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
        Dim appVersion As String = If(ApplicationDeployment.IsNetworkDeployed, ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(), My.Application.Info.Version.ToString())
        Return $"{assemblyName}/{appVersion}"
    End Function

    Private Function BuildNotificationBody(ByRef password As String, ByRef supporterEmail As String) As String
        Dim bodyHtml As String
        bodyHtml = String.Format("<p><strong>Клиент создан в дневнике:</strong><br/>Имя: {0}<br/>Фамилия: {1}<br/>Email: {2}<br/>Пароль: {3}<br/>Язык: {4}<br/>Сайт: {5}<br/>Консультант: {6}</p>",
                                    tbFirstName.Text.Trim, tbLastName.Text.Trim, tbEmail.Text.Trim, password, cmbLanguage.Text, cmbSites.Text, supporterEmail)
        bodyHtml = bodyHtml & String.Format("<p><strong>Данные о пакете и оплате:</strong><br/>Пакет: {0}<br/>Оплата: {1}<br/>Способ: {2}</p>", cmbPackage.Text, tbAmount.Text.Trim, cmbPaymentMethod.Text)
        Return bodyHtml
    End Function

    Private Sub btnSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSite.Click
        If Not ValidateOrderInformation() Then Return
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim fullSite As String = Helper.GetFullSite(cmbSites.Text)
            Dim url As String = String.Format("{0}{1}?firstName={2}&lastName={3}&email={4}&password={5}&site={6}", fullSite, SITE_NEWCLIENT, tbFirstName.Text.Trim, tbLastName.Text.Trim, tbEmail.Text.Trim, tbPassword.Text, cmbSites.Text)
            Helper.Log("Invoking Site script: " + url)
            Dim requester = New Net.WebClient
            requester.Encoding = Encoding.UTF8
            requester.Headers.Add("User-Agent", GetUserAgent())
            Dim result As String = requester.DownloadString(url)
            Helper.Log("Received response: " + result)
            If result.Contains("successfully") Then
                lblSiteStatus.BackColor = Color.Green
            Else
                MsgBox("User not created on the site. Received response: " & result)
                lblSiteStatus.BackColor = Color.Red
            End If
            ClearToolStripMenuItem.Enabled = True
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Helper.Log("Failed to create site and forum user: " + ex.Message)
            lblSiteStatus.BackColor = Color.Red
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnMailingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMailingList.Click
        If Not ValidateOrderInformation(generatePassword:=False, ignorePassword:=True) Then Return
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim campaignName As String = Helper.GetClientsCampaignName(cmbLanguage.Text.Trim)
            Dim campaignId As String = GetResponseAPI.FindCampaignIdByName(campaignName)
            Helper.Log("Subscribing to the clients campaign " & campaignName)
            If GetResponseAPI.SubscribeToCampaign(campaignId, tbEmail.Text.Trim, tbFirstName.Text.Trim) Then
                Helper.Log("Subscribed")
                lblMailingStatus.BackColor = Color.Green
            Else
                Helper.Log("Something went wrong!")
                lblMailingStatus.BackColor = Color.Red
            End If

            ClearToolStripMenuItem.Enabled = True
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Helper.Log("Failed to subscribe to mailing list: " + ex.Message)
            lblMailingStatus.BackColor = Color.Red
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbLanguage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLanguage.SelectedIndexChanged
        If Helper.IsEmpty(cmbLanguage.Text) Then Return
        Dim site As String = Helper.GetSelectedLanguageSite(cmbLanguage.Text)
        If Not Helper.IsEmpty(cmbSites.Text) Then
            If cmbSites.Text <> site Then
                MsgBox("Please, notice, that the selected site does not match the selected language!")
            End If
            Return
        Else
            cmbSites.Text = site
        End If
    End Sub

    Private Sub btnNewCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCustomer.Click
        tbFirstName.Text = ""
        tbLastName.Text = ""
        tbEmail.Text = ""
        cmbPackage.SelectedIndex = -1
        cmbLanguage.SelectedIndex = -1
        cmbSites.SelectedIndex = -1
        tbPassword.Text = ""

        lblDiaryStatus.BackColor = Color.White
        lblSiteStatus.BackColor = Color.White
        lblMailingStatus.BackColor = Color.White
        lblSendFirstMailStatus.BackColor = Color.White

        cmbPaymentMethod.SelectedIndex = -1
        tbAmount.Text = ""
        tbShippingAddress.Text = ""
        lblSendShippingMailStatus.BackColor = Color.White

        tbMobilePhone.Text = ""
        tbSecondPhone.Text = ""
        lblLoadClientStatus.BackColor = Color.White

        tbHomeAddress.Text = ""
        tbMedicalConditions.Text = ""
        tbAdditionalNotes.Text = ""
        lblUpdateClientStatus.BackColor = Color.White

        cmbSupporter.Enabled = True
        btnSite.Enabled = True
        tbShippingAddress.Enabled = True
        btnSendShippingMail.Enabled = True

        loadedClient = Nothing
        btnUpdateClient.Enabled = False
        lblUpdateEnableHint.Visible = True
    End Sub

    Private Sub CreateBusinessContact()
        Dim olApp As Outlook.Application
        Dim objNS As Outlook.NameSpace
        Dim bcmRootFolder As Outlook.Folder
        Dim olFolders As Outlook.Folders
        Dim bcmContactsFldr As Outlook.Folder
        Dim newContact As Outlook.ContactItem

        olApp = CreateObject("Outlook.Application")
        objNS = olApp.GetNamespace("MAPI")
        olFolders = objNS.Session.Folders
        bcmRootFolder = olFolders("Business Contact Manager")
        bcmContactsFldr = bcmRootFolder.Folders("Business Records").Folders("Business Contacts")

        Dim existContact As Outlook.ContactItem
        existContact = bcmContactsFldr.Items.Find("[Email1Address] = '" + tbEmail.Text.Trim + "'")
        If existContact Is Nothing Then
            newContact = bcmContactsFldr.Items.Add("IPM.Contact.BCM.Contact")
        Else
            newContact = existContact
        End If

        newContact.FirstName = tbFirstName.Text.Trim
        newContact.LastName = tbLastName.Text.Trim
        newContact.FileAs = tbFirstName.Text.Trim + " " + tbLastName.Text.Trim
        newContact.Email1Address = tbEmail.Text.Trim
        newContact.Language = cmbLanguage.Text
        newContact.JobTitle = cmbSupporter.Text.Trim

        newContact.PrimaryTelephoneNumber = tbMobilePhone.Text.Trim
        newContact.MobileTelephoneNumber = tbMobilePhone.Text.Trim
        newContact.HomeTelephoneNumber = tbSecondPhone.Text.Trim
        newContact.HomeAddress = tbShippingAddress.Text.Trim
        newContact.SelectedMailingAddress = Outlook.OlMailingAddress.olHome

        If Not newContact.Body Is Nothing Then
            newContact.Body += vbCrLf
        Else
            newContact.Body = ""
        End If

        newContact.Body += GetTimestamp() + vbCrLf

        newContact.Body += vbCrLf + "Order details" + vbCrLf
        newContact.Body += "===========" + vbCrLf
        newContact.Body += "Payed: " + tbAmount.Text.Trim + vbCrLf
        newContact.Body += "For package: " + cmbPackage.Text + vbCrLf
        newContact.Body += "Package language: " + cmbLanguage.Text + vbCrLf

        newContact.Body += vbCrLf + "Shipping information" + vbCrLf
        newContact.Body += "=================" + vbCrLf
        If Not Helper.IsEmpty(tbShippingAddress.Text.Trim) Then
            newContact.Body += "Wanted shipping" + vbCrLf
            newContact.Body += "Shipping address: " + tbShippingAddress.Text.Trim + vbCrLf
        Else
            newContact.Body += "No shipping requested" + vbCrLf
        End If

        newContact.Body += vbCrLf + "Medical conditions" + vbCrLf
        newContact.Body += "================" + vbCrLf
        If Not Helper.IsEmpty(tbMedicalConditions.Text.Trim) Then
            newContact.Body += "Has medical problems" + vbCrLf + tbMedicalConditions.Text.Trim + vbCrLf
        Else
            newContact.Body += "No known medical problems" + vbCrLf
        End If

        If Not Helper.IsEmpty(tbAdditionalNotes.Text.Trim) Then
            newContact.Body += vbCrLf + "Additional notes" + vbCrLf
            newContact.Body += "===" + vbCrLf
            newContact.Body += tbAdditionalNotes.Text.Trim + vbCrLf
        End If

        newContact.Save()

        newContact.GetInspector.Display()

        newContact = Nothing
        bcmContactsFldr = Nothing
        bcmRootFolder = Nothing
        olFolders = Nothing
        objNS = Nothing
        olApp = Nothing
    End Sub

    Private Function GetTimestamp() As String
        Return Now.ToString("F", System.Globalization.CultureInfo.CreateSpecificCulture("en-UK"))
    End Function

    Private Sub btnSendFirstMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendFirstMail.Click
        If Not ValidateOrderInformation(generatePassword:=False, ignorePassword:=False) Then Return
        Me.Cursor = Cursors.WaitCursor
        Try
            SendFirstEmailViaSMTP()
            Helper.Log("First email was successfully created and sent to " + tbEmail.Text)
            lblSendFirstMailStatus.BackColor = Color.Green
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Helper.Log("Failed to create and send first email for the client: " + ex.Message)
            lblSendFirstMailStatus.BackColor = Color.Red
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SendFirstEmailViaSMTP()
        Dim subject As String = BuildFirstClientEmailSubject()
        Dim bodyHtml As String = BuildFirstClientEmailHTMLBody()
        Dim bodyText As String = Helper.StripTags(bodyHtml)

        Dim providerName As String = Helper.GetSiteNameAsSenderName(cmbLanguage.Text)
        Dim providerEmail As String = "support@" & cmbSites.Text.ToLower()

        Dim replyToName As String = Helper.ExtractSupporterName(cmbSupporter.Text.Trim)
        Dim replyToEmail As String = Helper.ExtractSupporterEmail(cmbSupporter.Text.Trim)
        If Helper.IsEmpty(replyToEmail) Then
            replyToName = providerName
            replyToEmail = providerEmail
        End If

        Dim recipientEmail As String = tbEmail.Text.Trim

        Helper.SendMail(providerName, providerEmail, replyToName, replyToEmail, recipientEmail, recipientEmail, True, subject, bodyHtml)
    End Sub

    Private Function BuildFirstClientEmailSubject() As String
        If cmbLanguage.Text = Helper.LANG_HEBREW Then
            Return "מרכז התמיכה - דיאטת דר' סימאונס"
        ElseIf cmbLanguage.Text = Helper.LANG_RUSSIAN Then
            Return "Центр Поддержки - Диета Доктора Симеонса"
        ElseIf cmbLanguage.Text = Helper.LANG_ESTONIAN Then
            Return "Simeonsi Dieet - Tugikeskus"
        ElseIf cmbLanguage.Text = Helper.LANG_FINNISH Then
            Return "Simeonsin Dieetti - Tukikeskus"
        ElseIf cmbLanguage.Text = Helper.LANG_SWEDISH Then
            Return "Simeons Diet - Support"
        Else
            Return "Simeons Diet - Support Center"
        End If
    End Function

    Private Function BuildFirstClientEmailHTMLBody() As String
        Dim letterFolder = Nothing
        If cmbPackage.Text = Helper.PACKAGE_FULL Or cmbPackage.Text = Helper.PACKAGE_FULL_BOOK Or cmbPackage.Text = Helper.PACKAGE_SUPPORT Then
            letterFolder = "Full"
            'ElseIf cmbPackage.Text = Helper.PACKAGE_BASIC Or cmbPackage.Text = Helper.PACKAGE_BASIC_BOOK Or cmbPackage.Text = Helper.PACKAGE_GUIDE Then
            '    letterFolder = "Basic"
        Else 'PACKAGE_BOOK
            letterFolder = "Basic"
        End If

        Dim bodyFilePath As String = AppDomain.CurrentDomain.BaseDirectory &
            "FirstEmail\" & letterFolder & "\Letter." & Helper.GetShortLanguage(cmbLanguage.Text) & ".html"
        If Not File.Exists(bodyFilePath) Then
            Throw New Exception("Letter not found for package " & cmbPackage.Text.Trim & " and language " & cmbLanguage.Text)
        End If
        Dim htmlBody As String = System.IO.File.ReadAllText(bodyFilePath)

        htmlBody = htmlBody.Replace("[[password]]", tbPassword.Text.Trim)
        htmlBody = htmlBody.Replace("[[email]]", tbEmail.Text.Trim)
        htmlBody = htmlBody.Replace("[[site]]", cmbSites.Text.ToLower())
        htmlBody = htmlBody.Replace("[[accessPassword]]", Helper.GetBasicPackagePassword(cmbLanguage.Text))

        Dim supporterEmail As String = Helper.ExtractSupporterEmail(cmbSupporter.Text.Trim)
        If supporterEmail Is Nothing Then
            Dim senderEmail As String = "support@" & cmbSites.Text.ToLower()
            htmlBody = htmlBody.Replace("[[supportMail]]", senderEmail)
        Else
            htmlBody = htmlBody.Replace("[[supportMail]]", supporterEmail)
        End If

        Return htmlBody
    End Function

    Private Function BuildFirstClientEmailAttachments() As String()
        Dim baseFilePath As String = AppDomain.CurrentDomain.BaseDirectory & "FirstEmail\Files\" & Helper.GetLongLanguage(cmbLanguage.Text, cmbSites.Text) & "\"
        If cmbLanguage.Text = Helper.LANG_HEBREW Then
            Return New String() {
                baseFilePath & "Guide.pdf",
                baseFilePath & "Checklist.pdf",
                baseFilePath & "Phase 1.pdf",
                baseFilePath & "Phase 2.pdf",
                baseFilePath & "Phase 4.pdf"}
        Else
            Return New String() {
                baseFilePath & "Checklist.pdf",
                baseFilePath & "Phase 1.pdf",
                baseFilePath & "Phase 2.pdf",
                baseFilePath & "Phase 4.pdf"}
        End If
    End Function

    Private Sub CreateNewClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetConsoleOutput()

        FillSupporters()
        FillLanguages()
        FillSites()
        SetBuildInfo()

        'InitializeTestData()
    End Sub

    Private Function GetLogFileName() As String
        Dim desktopFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim logFileName As String = Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().ProcessName) & ".log"
        Return desktopFolder & "\" & logFileName
    End Function

    Private Sub SetConsoleOutput()
        Dim writer As StreamWriter = Nothing
        writer = New StreamWriter(GetLogFileName(), True)
        writer.AutoFlush = True
        Console.SetOut(writer)
    End Sub

    Private Sub FillSupporters()
        If Not My.Settings.SupportersEmails Is Nothing Then
            For Each supportEmail In My.Settings.SupportersEmails
                cmbSupporter.Items.Add(supportEmail)
            Next
        End If
    End Sub

    Private Sub FillLanguages()
        cmbLanguage.Items.Add(Helper.LANG_RUSSIAN)
        cmbLanguage.Items.Add(Helper.LANG_ENGLISH)
        cmbLanguage.Items.Add(Helper.LANG_ESTONIAN)
        cmbLanguage.Items.Add(Helper.LANG_HEBREW)
        cmbLanguage.Items.Add(Helper.LANG_FINNISH)
        cmbLanguage.Items.Add(Helper.LANG_SWEDISH)
        cmbLanguage.Sorted = True
    End Sub

    Private Sub FillSites()
        cmbSites.Items.Add(Helper.SITE_ENGLISH)
        cmbSites.Items.Add(Helper.SITE_ESTONIAN)
        cmbSites.Items.Add(Helper.SITE_HEBREW)
        cmbSites.Items.Add(Helper.SITE_RUSSIAN)
        cmbSites.Items.Add(Helper.SITE_FINNISH)
        cmbSites.Items.Add(Helper.SITE_SWEDISH)
        cmbSites.Sorted = True
    End Sub

    Private Sub SetBuildInfo()
        If ApplicationDeployment.IsNetworkDeployed Then
            lblVersion.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Else
            lblVersion.Text = My.Application.Info.Version.ToString
        End If
    End Sub

    Private Sub InitializeTestData()
        tbFirstName.Text = "Alex"
        tbLastName.Text = "Stern"
        tbEmail.Text = "alex.bfree@gmail.com"
        tbPassword.Text = "123qwe"
        cmbLanguage.SelectedIndex = 5

        cmbPackage.SelectedIndex = 1
        cmbPaymentMethod.SelectedIndex = 1
        tbAmount.Text = "83"

        'ExtractForumUser("site and forum user יעל2 were successfully created")
    End Sub

    Private Sub btnAddSupporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSupporter.Click
        Dim newSupporterDlg As New NewSupporter
        If newSupporterDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            If My.Settings.SupportersEmails Is Nothing Then
                My.Settings.SupportersEmails = New System.Collections.Specialized.StringCollection
            End If
            My.Settings.SupportersEmails.Add(newSupporterDlg.supporter)
            My.Settings.Save()
            cmbSupporter.Items.Add(newSupporterDlg.supporter)
        End If
    End Sub

    Private Sub btnRemoveSupporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSupporter.Click
        If cmbSupporter.SelectedIndex = -1 Then
            MsgBox("Please, select a supporter to delete")
            Exit Sub
        End If
        If MsgBox("Delete supporter " & cmbSupporter.Text & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            My.Settings.SupportersEmails.Remove(cmbSupporter.Text)
            My.Settings.Save()
            cmbSupporter.Items.Remove(cmbSupporter.Text)
        End If
    End Sub

    Private Sub btnSendShippingMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendShippingMail.Click
        If Not ValidateOrderInformation(generatePassword:=False, ignorePassword:=True) Then Return
        If Not ValidateShippingInformation() Then Return

        Dim sendShippingInstructionsDialog As New dlgSendShippingInstructions()

        sendShippingInstructionsDialog.setCustomerSite(cmbSites.Text)
        sendShippingInstructionsDialog.setCustomerPackage(cmbPackage.Text)
        sendShippingInstructionsDialog.setCustomerFirstName(tbFirstName.Text.Trim)
        sendShippingInstructionsDialog.setCustomerLastName(tbLastName.Text.Trim)
        'sendShippingInstructionsDialog.setCustomerLanguage(cmbLanguage.Text)
        sendShippingInstructionsDialog.setCustomerAddress(tbShippingAddress.Text.Trim)
        sendShippingInstructionsDialog.setCustomerPhone(tbMobilePhone.Text)

        If sendShippingInstructionsDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Helper.Log("Sent delivery instructions")
            lblSendShippingMailStatus.BackColor = Color.Green
        Else
            Helper.Log("Delivery instructions not sent!")
            lblSendShippingMailStatus.BackColor = Color.Red
        End If
    End Sub

    Private Function HasSupport(ByRef packageType) As Boolean
        If cmbPackage.Text = Helper.PACKAGE_FULL Or cmbPackage.Text = Helper.PACKAGE_FULL_BOOK Or cmbPackage.Text = Helper.PACKAGE_SUPPORT Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function HasShipping(ByRef packageType) As Boolean
        'Or cmbPackage.Text = Helper.PACKAGE_BASIC Or cmbPackage.Text = Helper.PACKAGE_BASIC_BOOK _
        If cmbPackage.Text = Helper.PACKAGE_FULL Or cmbPackage.Text = Helper.PACKAGE_FULL_BOOK _
            Or cmbPackage.Text = Helper.PACKAGE_BOOK Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub cmbPackage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPackage.SelectedIndexChanged
        If HasSupport(cmbPackage.Text) Then
            cmbSupporter.Enabled = True
            btnSite.Enabled = True
        Else
            cmbSupporter.SelectedIndex = -1
            cmbSupporter.Enabled = False
            btnSite.Enabled = False
        End If
        If HasShipping(cmbPackage.Text) Then
            btnSendShippingMail.Enabled = True
        Else
            btnSendShippingMail.Enabled = False
        End If
    End Sub

    Private Sub linkCopy_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkCopy.LinkClicked
        tbHomeAddress.Text = tbShippingAddress.Text
    End Sub

    Private Sub cmbPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaymentMethod.SelectedIndexChanged
        If cmbPaymentMethod.Text.Trim = Helper.PAYMENT_CASH Then
            tbShippingAddress.Text = ""
            tbShippingAddress.Enabled = False
        Else
            tbShippingAddress.Text = tbHomeAddress.Text.Trim
            tbShippingAddress.Enabled = True
        End If
    End Sub

    Private Sub btnLoadClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadClient.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not Helper.IsEmpty(tbMobilePhone.Text) Then
                Try
                    loadedClient = ClientsService.GetClientByPhone(tbMobilePhone.Text.Trim)
                Catch ex As Exception
                    If Not ex.Message.Contains("No client found") Then
                        Throw ex
                    End If
                End Try
            End If
            If loadedClient Is Nothing And Not Helper.IsEmpty(tbSecondPhone.Text) Then
                Try
                    loadedClient = ClientsService.GetClientByPhone(tbSecondPhone.Text.Trim)
                Catch ex As Exception
                    If Not ex.Message.Contains("No client found") Then
                        Throw ex
                    End If
                End Try
            End If
            If loadedClient Is Nothing And Not Helper.IsEmpty(tbEmail.Text) Then
                MsgBox("No client found with provided phone numbers, searching by email...")
                Try
                    loadedClient = ClientsService.GetClientByEmail(tbEmail.Text.Trim)
                Catch ex As Exception
                    If Not ex.Message.Contains("No client found") Then
                        Throw ex
                    End If
                End Try
            End If
            If Not loadedClient Is Nothing Then
                PopulateLoadedClient()
                btnUpdateClient.Enabled = True
                lblUpdateEnableHint.Visible = False
            Else
                MsgBox("No client found!")
            End If
        Catch ex As Exception
            MsgBox("Failed to load client: " + ex.Message)
            Helper.Log("Failed to load client: " + ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PopulateLoadedClient()
        With loadedClient
            tbFirstName.Text = .firstName
            tbLastName.Text = .lastName
            tbEmail.Text = .email
            If .language = Helper.LANG_SHORT_ENGLISH Then
                cmbLanguage.Text = Helper.LANG_ENGLISH
            ElseIf .language = Helper.LANG_SHORT_ESTONIAN Then
                cmbLanguage.Text = Helper.LANG_ESTONIAN
            ElseIf .language = Helper.LANG_SHORT_FINNISH Then
                cmbLanguage.Text = Helper.LANG_FINNISH
            ElseIf .language = Helper.LANG_SHORT_HEBREW Then
                cmbLanguage.Text = Helper.LANG_HEBREW
            ElseIf .language = Helper.LANG_SHORT_RUSSIAN Then
                cmbLanguage.Text = Helper.LANG_RUSSIAN
            ElseIf .language = Helper.LANG_SHORT_SWEDISH Then
                cmbLanguage.Text = Helper.LANG_SWEDISH
            End If
            tbShippingAddress.Text = .shippingAddress
            tbMobilePhone.Text = .mobilePhone
            tbSecondPhone.Text = .homePhone
            tbHomeAddress.Text = .homeAddress
            tbMedicalConditions.Text = .healthNotes
            tbAdditionalNotes.Text = .comments & vbCrLf & vbCrLf & Date.Now.ToString("dd MMM yyyy - HH:mm") & vbCrLf
        End With
    End Sub

    Private Sub btnUpdateClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateClient.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            With loadedClient
                .email = tbEmail.Text.Trim
                .language = Helper.GetShortLanguage(cmbLanguage.Text)
                .mobilePhone = tbMobilePhone.Text.Trim
                .homePhone = tbSecondPhone.Text.Trim
                .homeAddress = tbHomeAddress.Text.Trim
                .shippingAddress = tbShippingAddress.Text.Trim
                .healthNotes = tbMedicalConditions.Text.Trim
                .comments = tbAdditionalNotes.Text.Trim
            End With
            ClientsService.UpdateClient(loadedClient)
        Catch ex As Exception
            MsgBox("Failed to update client: " + ex.Message)
            Helper.Log("Failed to update client: " + ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub linkViewLog_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkViewLog.LinkClicked
        Process.Start("notepad.exe", GetLogFileName())
    End Sub

End Class
