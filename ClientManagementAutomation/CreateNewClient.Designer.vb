<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateNewClient
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateNewClient))
        Me.gbOrderInformation = New System.Windows.Forms.GroupBox
        Me.tbPassword = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnRemoveSupporter = New System.Windows.Forms.Button
        Me.btnAddSupporter = New System.Windows.Forms.Button
        Me.cmbSupporter = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbSites = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbLanguage = New System.Windows.Forms.ComboBox
        Me.lblSendFirstMailStatus = New System.Windows.Forms.Label
        Me.btnSendFirstMail = New System.Windows.Forms.Button
        Me.lblMailingStatus = New System.Windows.Forms.Label
        Me.lblSiteStatus = New System.Windows.Forms.Label
        Me.lblDiaryStatus = New System.Windows.Forms.Label
        Me.btnMailingList = New System.Windows.Forms.Button
        Me.btnSite = New System.Windows.Forms.Button
        Me.btnDiary = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbPackage = New System.Windows.Forms.ComboBox
        Me.tbEmail = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbLastName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbFirstName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbSecondPhone = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.tbMobilePhone = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.tbMedicalConditions = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.menuLog = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.gbClientManagement = New System.Windows.Forms.GroupBox
        Me.lblUpdateEnableHint = New System.Windows.Forms.Label
        Me.linkCopy = New System.Windows.Forms.LinkLabel
        Me.lblLoadClientStatus = New System.Windows.Forms.Label
        Me.btnLoadClient = New System.Windows.Forms.Button
        Me.tbHomeAddress = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.tbAdditionalNotes = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblUpdateClientStatus = New System.Windows.Forms.Label
        Me.btnUpdateClient = New System.Windows.Forms.Button
        Me.btnNewCustomer = New System.Windows.Forms.Button
        Me.lblSendShippingMailStatus = New System.Windows.Forms.Label
        Me.btnSendShippingMail = New System.Windows.Forms.Button
        Me.gbPaymentAndShipping = New System.Windows.Forms.GroupBox
        Me.tbAmount = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbPaymentMethod = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbShippingAddress = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.linkViewLog = New System.Windows.Forms.LinkLabel
        Me.lblVersion = New System.Windows.Forms.Label
        Me.gbOrderInformation.SuspendLayout()
        Me.menuLog.SuspendLayout()
        Me.gbClientManagement.SuspendLayout()
        Me.gbPaymentAndShipping.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbOrderInformation
        '
        Me.gbOrderInformation.Controls.Add(Me.tbPassword)
        Me.gbOrderInformation.Controls.Add(Me.Label5)
        Me.gbOrderInformation.Controls.Add(Me.btnRemoveSupporter)
        Me.gbOrderInformation.Controls.Add(Me.btnAddSupporter)
        Me.gbOrderInformation.Controls.Add(Me.cmbSupporter)
        Me.gbOrderInformation.Controls.Add(Me.Label16)
        Me.gbOrderInformation.Controls.Add(Me.cmbSites)
        Me.gbOrderInformation.Controls.Add(Me.Label4)
        Me.gbOrderInformation.Controls.Add(Me.Label12)
        Me.gbOrderInformation.Controls.Add(Me.cmbLanguage)
        Me.gbOrderInformation.Controls.Add(Me.lblSendFirstMailStatus)
        Me.gbOrderInformation.Controls.Add(Me.btnSendFirstMail)
        Me.gbOrderInformation.Controls.Add(Me.lblMailingStatus)
        Me.gbOrderInformation.Controls.Add(Me.lblSiteStatus)
        Me.gbOrderInformation.Controls.Add(Me.lblDiaryStatus)
        Me.gbOrderInformation.Controls.Add(Me.btnMailingList)
        Me.gbOrderInformation.Controls.Add(Me.btnSite)
        Me.gbOrderInformation.Controls.Add(Me.btnDiary)
        Me.gbOrderInformation.Controls.Add(Me.Label8)
        Me.gbOrderInformation.Controls.Add(Me.cmbPackage)
        Me.gbOrderInformation.Controls.Add(Me.tbEmail)
        Me.gbOrderInformation.Controls.Add(Me.Label3)
        Me.gbOrderInformation.Controls.Add(Me.tbLastName)
        Me.gbOrderInformation.Controls.Add(Me.Label2)
        Me.gbOrderInformation.Controls.Add(Me.tbFirstName)
        Me.gbOrderInformation.Controls.Add(Me.Label1)
        Me.gbOrderInformation.Location = New System.Drawing.Point(12, 12)
        Me.gbOrderInformation.Name = "gbOrderInformation"
        Me.gbOrderInformation.Size = New System.Drawing.Size(393, 316)
        Me.gbOrderInformation.TabIndex = 0
        Me.gbOrderInformation.TabStop = False
        Me.gbOrderInformation.Text = "Order Details"
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(297, 172)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.Size = New System.Drawing.Size(81, 20)
        Me.tbPassword.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(237, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Password:"
        '
        'btnRemoveSupporter
        '
        Me.btnRemoveSupporter.Location = New System.Drawing.Point(352, 136)
        Me.btnRemoveSupporter.Name = "btnRemoveSupporter"
        Me.btnRemoveSupporter.Size = New System.Drawing.Size(26, 23)
        Me.btnRemoveSupporter.TabIndex = 38
        Me.btnRemoveSupporter.Text = "-"
        Me.btnRemoveSupporter.UseVisualStyleBackColor = True
        '
        'btnAddSupporter
        '
        Me.btnAddSupporter.Location = New System.Drawing.Point(323, 136)
        Me.btnAddSupporter.Name = "btnAddSupporter"
        Me.btnAddSupporter.Size = New System.Drawing.Size(26, 23)
        Me.btnAddSupporter.TabIndex = 37
        Me.btnAddSupporter.Text = "+"
        Me.btnAddSupporter.UseVisualStyleBackColor = True
        '
        'cmbSupporter
        '
        Me.cmbSupporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSupporter.FormattingEnabled = True
        Me.cmbSupporter.Location = New System.Drawing.Point(75, 137)
        Me.cmbSupporter.Name = "cmbSupporter"
        Me.cmbSupporter.Size = New System.Drawing.Size(242, 21)
        Me.cmbSupporter.TabIndex = 6
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 140)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Supporter:"
        '
        'cmbSites
        '
        Me.cmbSites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSites.FormattingEnabled = True
        Me.cmbSites.Location = New System.Drawing.Point(226, 107)
        Me.cmbSites.Name = "cmbSites"
        Me.cmbSites.Size = New System.Drawing.Size(152, 21)
        Me.cmbSites.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(192, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Site:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 110)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Language:"
        '
        'cmbLanguage
        '
        Me.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLanguage.FormattingEnabled = True
        Me.cmbLanguage.Location = New System.Drawing.Point(75, 107)
        Me.cmbLanguage.Name = "cmbLanguage"
        Me.cmbLanguage.Size = New System.Drawing.Size(107, 21)
        Me.cmbLanguage.TabIndex = 4
        '
        'lblSendFirstMailStatus
        '
        Me.lblSendFirstMailStatus.BackColor = System.Drawing.Color.White
        Me.lblSendFirstMailStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSendFirstMailStatus.Location = New System.Drawing.Point(167, 267)
        Me.lblSendFirstMailStatus.Name = "lblSendFirstMailStatus"
        Me.lblSendFirstMailStatus.Size = New System.Drawing.Size(59, 30)
        Me.lblSendFirstMailStatus.TabIndex = 30
        '
        'btnSendFirstMail
        '
        Me.btnSendFirstMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSendFirstMail.Location = New System.Drawing.Point(16, 266)
        Me.btnSendFirstMail.Name = "btnSendFirstMail"
        Me.btnSendFirstMail.Size = New System.Drawing.Size(145, 30)
        Me.btnSendFirstMail.TabIndex = 11
        Me.btnSendFirstMail.Text = "4. First Mail"
        Me.btnSendFirstMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSendFirstMail.UseVisualStyleBackColor = True
        '
        'lblMailingStatus
        '
        Me.lblMailingStatus.BackColor = System.Drawing.Color.White
        Me.lblMailingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMailingStatus.Location = New System.Drawing.Point(167, 235)
        Me.lblMailingStatus.Name = "lblMailingStatus"
        Me.lblMailingStatus.Size = New System.Drawing.Size(59, 30)
        Me.lblMailingStatus.TabIndex = 28
        '
        'lblSiteStatus
        '
        Me.lblSiteStatus.BackColor = System.Drawing.Color.White
        Me.lblSiteStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSiteStatus.Location = New System.Drawing.Point(167, 203)
        Me.lblSiteStatus.Name = "lblSiteStatus"
        Me.lblSiteStatus.Size = New System.Drawing.Size(59, 30)
        Me.lblSiteStatus.TabIndex = 27
        '
        'lblDiaryStatus
        '
        Me.lblDiaryStatus.BackColor = System.Drawing.Color.White
        Me.lblDiaryStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiaryStatus.Location = New System.Drawing.Point(167, 171)
        Me.lblDiaryStatus.Name = "lblDiaryStatus"
        Me.lblDiaryStatus.Size = New System.Drawing.Size(59, 30)
        Me.lblDiaryStatus.TabIndex = 26
        '
        'btnMailingList
        '
        Me.btnMailingList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnMailingList.Location = New System.Drawing.Point(16, 235)
        Me.btnMailingList.Name = "btnMailingList"
        Me.btnMailingList.Size = New System.Drawing.Size(145, 30)
        Me.btnMailingList.TabIndex = 10
        Me.btnMailingList.Text = "3. Mailing List"
        Me.btnMailingList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMailingList.UseVisualStyleBackColor = True
        '
        'btnSite
        '
        Me.btnSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSite.Location = New System.Drawing.Point(16, 203)
        Me.btnSite.Name = "btnSite"
        Me.btnSite.Size = New System.Drawing.Size(145, 30)
        Me.btnSite.TabIndex = 9
        Me.btnSite.Text = "2. Site"
        Me.btnSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSite.UseVisualStyleBackColor = True
        '
        'btnDiary
        '
        Me.btnDiary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnDiary.Location = New System.Drawing.Point(16, 171)
        Me.btnDiary.Name = "btnDiary"
        Me.btnDiary.Size = New System.Drawing.Size(145, 30)
        Me.btnDiary.TabIndex = 8
        Me.btnDiary.Text = "1. Diary"
        Me.btnDiary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDiary.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Package:"
        '
        'cmbPackage
        '
        Me.cmbPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPackage.FormattingEnabled = True
        Me.cmbPackage.Items.AddRange(New Object() {"Full package + Book", "Full package", "Basic package + Book", "Basic package", "Guide only", "Book only", "Support only"})
        Me.cmbPackage.Location = New System.Drawing.Point(75, 77)
        Me.cmbPackage.Name = "cmbPackage"
        Me.cmbPackage.Size = New System.Drawing.Size(140, 21)
        Me.cmbPackage.TabIndex = 3
        '
        'tbEmail
        '
        Me.tbEmail.Location = New System.Drawing.Point(75, 49)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(303, 20)
        Me.tbEmail.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Email:"
        '
        'tbLastName
        '
        Me.tbLastName.Location = New System.Drawing.Point(255, 22)
        Me.tbLastName.Name = "tbLastName"
        Me.tbLastName.Size = New System.Drawing.Size(123, 20)
        Me.tbLastName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(191, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Last name:"
        '
        'tbFirstName
        '
        Me.tbFirstName.Location = New System.Drawing.Point(76, 22)
        Me.tbFirstName.Name = "tbFirstName"
        Me.tbFirstName.Size = New System.Drawing.Size(107, 20)
        Me.tbFirstName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First name:"
        '
        'tbSecondPhone
        '
        Me.tbSecondPhone.Location = New System.Drawing.Point(283, 22)
        Me.tbSecondPhone.Name = "tbSecondPhone"
        Me.tbSecondPhone.Size = New System.Drawing.Size(100, 20)
        Me.tbSecondPhone.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(202, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Second phone:"
        '
        'tbMobilePhone
        '
        Me.tbMobilePhone.Location = New System.Drawing.Point(93, 22)
        Me.tbMobilePhone.Name = "tbMobilePhone"
        Me.tbMobilePhone.Size = New System.Drawing.Size(100, 20)
        Me.tbMobilePhone.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Mobile phone:"
        '
        'tbMedicalConditions
        '
        Me.tbMedicalConditions.AcceptsReturn = True
        Me.tbMedicalConditions.AcceptsTab = True
        Me.tbMedicalConditions.Location = New System.Drawing.Point(16, 156)
        Me.tbMedicalConditions.Multiline = True
        Me.tbMedicalConditions.Name = "tbMedicalConditions"
        Me.tbMedicalConditions.Size = New System.Drawing.Size(367, 65)
        Me.tbMedicalConditions.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 140)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Medical conditions:"
        '
        'menuLog
        '
        Me.menuLog.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.ClearToolStripMenuItem})
        Me.menuLog.Name = "menuLog"
        Me.menuLog.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuLog.Size = New System.Drawing.Size(103, 48)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Enabled = False
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Enabled = False
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'gbClientManagement
        '
        Me.gbClientManagement.Controls.Add(Me.lblUpdateEnableHint)
        Me.gbClientManagement.Controls.Add(Me.linkCopy)
        Me.gbClientManagement.Controls.Add(Me.lblLoadClientStatus)
        Me.gbClientManagement.Controls.Add(Me.btnLoadClient)
        Me.gbClientManagement.Controls.Add(Me.tbHomeAddress)
        Me.gbClientManagement.Controls.Add(Me.Label11)
        Me.gbClientManagement.Controls.Add(Me.tbAdditionalNotes)
        Me.gbClientManagement.Controls.Add(Me.Label15)
        Me.gbClientManagement.Controls.Add(Me.lblUpdateClientStatus)
        Me.gbClientManagement.Controls.Add(Me.tbSecondPhone)
        Me.gbClientManagement.Controls.Add(Me.btnUpdateClient)
        Me.gbClientManagement.Controls.Add(Me.Label9)
        Me.gbClientManagement.Controls.Add(Me.tbMobilePhone)
        Me.gbClientManagement.Controls.Add(Me.Label10)
        Me.gbClientManagement.Controls.Add(Me.tbMedicalConditions)
        Me.gbClientManagement.Controls.Add(Me.Label14)
        Me.gbClientManagement.Location = New System.Drawing.Point(411, 12)
        Me.gbClientManagement.Name = "gbClientManagement"
        Me.gbClientManagement.Size = New System.Drawing.Size(399, 583)
        Me.gbClientManagement.TabIndex = 10
        Me.gbClientManagement.TabStop = False
        Me.gbClientManagement.Text = "Client Management"
        '
        'lblUpdateEnableHint
        '
        Me.lblUpdateEnableHint.Location = New System.Drawing.Point(231, 538)
        Me.lblUpdateEnableHint.Name = "lblUpdateEnableHint"
        Me.lblUpdateEnableHint.Size = New System.Drawing.Size(152, 30)
        Me.lblUpdateEnableHint.TabIndex = 33
        Me.lblUpdateEnableHint.Text = "To update load client first..."
        Me.lblUpdateEnableHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linkCopy
        '
        Me.linkCopy.AutoSize = True
        Me.linkCopy.Location = New System.Drawing.Point(267, 95)
        Me.linkCopy.Name = "linkCopy"
        Me.linkCopy.Size = New System.Drawing.Size(116, 13)
        Me.linkCopy.TabIndex = 32
        Me.linkCopy.TabStop = True
        Me.linkCopy.Text = "Copy Shipping Address"
        '
        'lblLoadClientStatus
        '
        Me.lblLoadClientStatus.BackColor = System.Drawing.Color.White
        Me.lblLoadClientStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLoadClientStatus.Location = New System.Drawing.Point(167, 52)
        Me.lblLoadClientStatus.Name = "lblLoadClientStatus"
        Me.lblLoadClientStatus.Size = New System.Drawing.Size(59, 30)
        Me.lblLoadClientStatus.TabIndex = 31
        '
        'btnLoadClient
        '
        Me.btnLoadClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnLoadClient.Location = New System.Drawing.Point(16, 52)
        Me.btnLoadClient.Name = "btnLoadClient"
        Me.btnLoadClient.Size = New System.Drawing.Size(145, 30)
        Me.btnLoadClient.TabIndex = 2
        Me.btnLoadClient.Text = "5. Load Client"
        Me.btnLoadClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoadClient.UseVisualStyleBackColor = True
        '
        'tbHomeAddress
        '
        Me.tbHomeAddress.Location = New System.Drawing.Point(16, 114)
        Me.tbHomeAddress.Name = "tbHomeAddress"
        Me.tbHomeAddress.Size = New System.Drawing.Size(367, 20)
        Me.tbHomeAddress.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Home address:"
        '
        'tbAdditionalNotes
        '
        Me.tbAdditionalNotes.AcceptsReturn = True
        Me.tbAdditionalNotes.AcceptsTab = True
        Me.tbAdditionalNotes.Location = New System.Drawing.Point(16, 243)
        Me.tbAdditionalNotes.Multiline = True
        Me.tbAdditionalNotes.Name = "tbAdditionalNotes"
        Me.tbAdditionalNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbAdditionalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbAdditionalNotes.Size = New System.Drawing.Size(367, 282)
        Me.tbAdditionalNotes.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 227)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 13)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Additional Notes:"
        '
        'lblUpdateClientStatus
        '
        Me.lblUpdateClientStatus.BackColor = System.Drawing.Color.White
        Me.lblUpdateClientStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUpdateClientStatus.Location = New System.Drawing.Point(165, 538)
        Me.lblUpdateClientStatus.Name = "lblUpdateClientStatus"
        Me.lblUpdateClientStatus.Size = New System.Drawing.Size(59, 30)
        Me.lblUpdateClientStatus.TabIndex = 29
        '
        'btnUpdateClient
        '
        Me.btnUpdateClient.Enabled = False
        Me.btnUpdateClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnUpdateClient.Location = New System.Drawing.Point(14, 538)
        Me.btnUpdateClient.Name = "btnUpdateClient"
        Me.btnUpdateClient.Size = New System.Drawing.Size(145, 30)
        Me.btnUpdateClient.TabIndex = 6
        Me.btnUpdateClient.Text = "6. Update Client"
        Me.btnUpdateClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateClient.UseVisualStyleBackColor = True
        '
        'btnNewCustomer
        '
        Me.btnNewCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnNewCustomer.Location = New System.Drawing.Point(12, 565)
        Me.btnNewCustomer.Name = "btnNewCustomer"
        Me.btnNewCustomer.Size = New System.Drawing.Size(210, 30)
        Me.btnNewCustomer.TabIndex = 0
        Me.btnNewCustomer.Text = "New Customer"
        Me.btnNewCustomer.UseVisualStyleBackColor = True
        '
        'lblSendShippingMailStatus
        '
        Me.lblSendShippingMailStatus.BackColor = System.Drawing.Color.White
        Me.lblSendShippingMailStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSendShippingMailStatus.Location = New System.Drawing.Point(168, 146)
        Me.lblSendShippingMailStatus.Name = "lblSendShippingMailStatus"
        Me.lblSendShippingMailStatus.Size = New System.Drawing.Size(59, 30)
        Me.lblSendShippingMailStatus.TabIndex = 35
        '
        'btnSendShippingMail
        '
        Me.btnSendShippingMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSendShippingMail.Location = New System.Drawing.Point(18, 146)
        Me.btnSendShippingMail.Name = "btnSendShippingMail"
        Me.btnSendShippingMail.Size = New System.Drawing.Size(145, 30)
        Me.btnSendShippingMail.TabIndex = 3
        Me.btnSendShippingMail.Text = "4. Shipping Mail"
        Me.btnSendShippingMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSendShippingMail.UseVisualStyleBackColor = True
        '
        'gbPaymentAndShipping
        '
        Me.gbPaymentAndShipping.Controls.Add(Me.tbAmount)
        Me.gbPaymentAndShipping.Controls.Add(Me.Label6)
        Me.gbPaymentAndShipping.Controls.Add(Me.cmbPaymentMethod)
        Me.gbPaymentAndShipping.Controls.Add(Me.lblSendShippingMailStatus)
        Me.gbPaymentAndShipping.Controls.Add(Me.Label7)
        Me.gbPaymentAndShipping.Controls.Add(Me.btnSendShippingMail)
        Me.gbPaymentAndShipping.Controls.Add(Me.tbShippingAddress)
        Me.gbPaymentAndShipping.Controls.Add(Me.Label13)
        Me.gbPaymentAndShipping.Location = New System.Drawing.Point(12, 334)
        Me.gbPaymentAndShipping.Name = "gbPaymentAndShipping"
        Me.gbPaymentAndShipping.Size = New System.Drawing.Size(393, 207)
        Me.gbPaymentAndShipping.TabIndex = 38
        Me.gbPaymentAndShipping.TabStop = False
        Me.gbPaymentAndShipping.Text = "Payment and Shipping"
        '
        'tbAmount
        '
        Me.tbAmount.Location = New System.Drawing.Point(116, 59)
        Me.tbAmount.Name = "tbAmount"
        Me.tbAmount.Size = New System.Drawing.Size(76, 20)
        Me.tbAmount.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Amount:"
        '
        'cmbPaymentMethod
        '
        Me.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymentMethod.FormattingEnabled = True
        Me.cmbPaymentMethod.Items.AddRange(New Object() {"Credit card", "Cash on spot", "Bank transfer"})
        Me.cmbPaymentMethod.Location = New System.Drawing.Point(117, 28)
        Me.cmbPaymentMethod.Name = "cmbPaymentMethod"
        Me.cmbPaymentMethod.Size = New System.Drawing.Size(143, 21)
        Me.cmbPaymentMethod.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Payment meythod:"
        '
        'tbShippingAddress
        '
        Me.tbShippingAddress.Location = New System.Drawing.Point(18, 107)
        Me.tbShippingAddress.Name = "tbShippingAddress"
        Me.tbShippingAddress.Size = New System.Drawing.Size(359, 20)
        Me.tbShippingAddress.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 91)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Shipping address:"
        '
        'linkViewLog
        '
        Me.linkViewLog.AutoSize = True
        Me.linkViewLog.Location = New System.Drawing.Point(354, 582)
        Me.linkViewLog.Name = "linkViewLog"
        Me.linkViewLog.Size = New System.Drawing.Size(51, 13)
        Me.linkViewLog.TabIndex = 1
        Me.linkViewLog.TabStop = True
        Me.linkViewLog.Text = "View Log"
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(224, 576)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(125, 19)
        Me.lblVersion.TabIndex = 39
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CreateNewClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 607)
        Me.Controls.Add(Me.linkViewLog)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.gbPaymentAndShipping)
        Me.Controls.Add(Me.btnNewCustomer)
        Me.Controls.Add(Me.gbClientManagement)
        Me.Controls.Add(Me.gbOrderInformation)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "CreateNewClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New Customer"
        Me.gbOrderInformation.ResumeLayout(False)
        Me.gbOrderInformation.PerformLayout()
        Me.menuLog.ResumeLayout(False)
        Me.gbClientManagement.ResumeLayout(False)
        Me.gbClientManagement.PerformLayout()
        Me.gbPaymentAndShipping.ResumeLayout(False)
        Me.gbPaymentAndShipping.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbOrderInformation As System.Windows.Forms.GroupBox
    Friend WithEvents tbEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents menuLog As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbClientManagement As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbPackage As System.Windows.Forms.ComboBox
    Friend WithEvents tbMedicalConditions As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbAdditionalNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbSecondPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbMobilePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblSendFirstMailStatus As System.Windows.Forms.Label
    Friend WithEvents btnSendFirstMail As System.Windows.Forms.Button
    Friend WithEvents lblUpdateClientStatus As System.Windows.Forms.Label
    Friend WithEvents btnUpdateClient As System.Windows.Forms.Button
    Friend WithEvents lblMailingStatus As System.Windows.Forms.Label
    Friend WithEvents lblSiteStatus As System.Windows.Forms.Label
    Friend WithEvents lblDiaryStatus As System.Windows.Forms.Label
    Friend WithEvents btnMailingList As System.Windows.Forms.Button
    Friend WithEvents btnSite As System.Windows.Forms.Button
    Friend WithEvents btnNewCustomer As System.Windows.Forms.Button
    Friend WithEvents btnDiary As System.Windows.Forms.Button
    Friend WithEvents lblSendShippingMailStatus As System.Windows.Forms.Label
    Friend WithEvents btnSendShippingMail As System.Windows.Forms.Button
    Friend WithEvents tbPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnRemoveSupporter As System.Windows.Forms.Button
    Friend WithEvents btnAddSupporter As System.Windows.Forms.Button
    Friend WithEvents cmbSupporter As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbSites As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents gbPaymentAndShipping As System.Windows.Forms.GroupBox
    Friend WithEvents tbAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbPaymentMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbShippingAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbHomeAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblLoadClientStatus As System.Windows.Forms.Label
    Friend WithEvents btnLoadClient As System.Windows.Forms.Button
    Friend WithEvents linkViewLog As System.Windows.Forms.LinkLabel
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents linkCopy As System.Windows.Forms.LinkLabel
    Friend WithEvents lblUpdateEnableHint As System.Windows.Forms.Label

End Class
