<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgGenerateReceipt
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
        Me.btnGenerateReceipt = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.fldReceiptNumber = New System.Windows.Forms.TextBox
        Me.fldEnglishName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.fldDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.lstCountries = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.fldAmount = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.fldPaymentDetails = New System.Windows.Forms.TextBox
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.Label7 = New System.Windows.Forms.Label
        Me.fldSaveDirectory = New System.Windows.Forms.TextBox
        Me.btnSelectSaveFolder = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.lstItemDescription = New System.Windows.Forms.ComboBox
        Me.btnSend2Client = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnGenerateReceipt
        '
        Me.btnGenerateReceipt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGenerateReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateReceipt.Location = New System.Drawing.Point(13, 152)
        Me.btnGenerateReceipt.Name = "btnGenerateReceipt"
        Me.btnGenerateReceipt.Size = New System.Drawing.Size(96, 29)
        Me.btnGenerateReceipt.TabIndex = 9
        Me.btnGenerateReceipt.Text = "Generate"
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(325, 152)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(99, 29)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Close"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(257, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Receipt number:"
        '
        'fldReceiptNumber
        '
        Me.fldReceiptNumber.Location = New System.Drawing.Point(346, 6)
        Me.fldReceiptNumber.Name = "fldReceiptNumber"
        Me.fldReceiptNumber.Size = New System.Drawing.Size(78, 20)
        Me.fldReceiptNumber.TabIndex = 1
        '
        'fldEnglishName
        '
        Me.fldEnglishName.Location = New System.Drawing.Point(115, 6)
        Me.fldEnglishName.Name = "fldEnglishName"
        Me.fldEnglishName.Size = New System.Drawing.Size(121, 20)
        Me.fldEnglishName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Name in English:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(257, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Receipt date:"
        '
        'fldDateTimePicker
        '
        Me.fldDateTimePicker.CustomFormat = "dd/MM/yyyy"
        Me.fldDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fldDateTimePicker.Location = New System.Drawing.Point(333, 36)
        Me.fldDateTimePicker.Name = "fldDateTimePicker"
        Me.fldDateTimePicker.ShowUpDown = True
        Me.fldDateTimePicker.Size = New System.Drawing.Size(91, 20)
        Me.fldDateTimePicker.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Customer's country:"
        '
        'lstCountries
        '
        Me.lstCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstCountries.FormattingEnabled = True
        Me.lstCountries.Location = New System.Drawing.Point(115, 36)
        Me.lstCountries.Name = "lstCountries"
        Me.lstCountries.Size = New System.Drawing.Size(121, 21)
        Me.lstCountries.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(208, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Amount (in EUR with VAT):"
        '
        'fldAmount
        '
        Me.fldAmount.Location = New System.Drawing.Point(346, 67)
        Me.fldAmount.Name = "fldAmount"
        Me.fldAmount.Size = New System.Drawing.Size(78, 20)
        Me.fldAmount.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Payment details:"
        '
        'fldPaymentDetails
        '
        Me.fldPaymentDetails.Location = New System.Drawing.Point(115, 67)
        Me.fldPaymentDetails.Name = "fldPaymentDetails"
        Me.fldPaymentDetails.Size = New System.Drawing.Size(87, 20)
        Me.fldPaymentDetails.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Save receipt to:"
        '
        'fldSaveDirectory
        '
        Me.fldSaveDirectory.Location = New System.Drawing.Point(115, 126)
        Me.fldSaveDirectory.Name = "fldSaveDirectory"
        Me.fldSaveDirectory.ReadOnly = True
        Me.fldSaveDirectory.Size = New System.Drawing.Size(279, 20)
        Me.fldSaveDirectory.TabIndex = 7
        '
        'btnSelectSaveFolder
        '
        Me.btnSelectSaveFolder.Location = New System.Drawing.Point(400, 124)
        Me.btnSelectSaveFolder.Name = "btnSelectSaveFolder"
        Me.btnSelectSaveFolder.Size = New System.Drawing.Size(24, 23)
        Me.btnSelectSaveFolder.TabIndex = 8
        Me.btnSelectSaveFolder.Text = "..."
        Me.btnSelectSaveFolder.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Item description"
        '
        'lstItemDescription
        '
        Me.lstItemDescription.FormattingEnabled = True
        Me.lstItemDescription.Location = New System.Drawing.Point(115, 95)
        Me.lstItemDescription.Name = "lstItemDescription"
        Me.lstItemDescription.Size = New System.Drawing.Size(309, 21)
        Me.lstItemDescription.TabIndex = 6
        '
        'btnSend2Client
        '
        Me.btnSend2Client.Enabled = False
        Me.btnSend2Client.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend2Client.Location = New System.Drawing.Point(115, 152)
        Me.btnSend2Client.Name = "btnSend2Client"
        Me.btnSend2Client.Size = New System.Drawing.Size(127, 29)
        Me.btnSend2Client.TabIndex = 19
        Me.btnSend2Client.Text = "Send to client"
        Me.btnSend2Client.UseVisualStyleBackColor = True
        '
        'dlgGenerateReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(435, 193)
        Me.Controls.Add(Me.btnSend2Client)
        Me.Controls.Add(Me.lstItemDescription)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnSelectSaveFolder)
        Me.Controls.Add(Me.fldSaveDirectory)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnGenerateReceipt)
        Me.Controls.Add(Me.fldPaymentDetails)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.fldAmount)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lstCountries)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.fldDateTimePicker)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.fldEnglishName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.fldReceiptNumber)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgGenerateReceipt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generate Receipt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGenerateReceipt As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fldReceiptNumber As System.Windows.Forms.TextBox
    Friend WithEvents fldEnglishName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents fldDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstCountries As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents fldAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents fldPaymentDetails As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents fldSaveDirectory As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectSaveFolder As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lstItemDescription As System.Windows.Forms.ComboBox
    Friend WithEvents btnSend2Client As System.Windows.Forms.Button

End Class
