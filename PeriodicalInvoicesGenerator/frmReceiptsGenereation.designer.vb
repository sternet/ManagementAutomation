<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceiptsGeneration
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.fldStartReceiptNumber = New System.Windows.Forms.TextBox
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.Label7 = New System.Windows.Forms.Label
        Me.fldSaveDirectory = New System.Windows.Forms.TextBox
        Me.btnSelectSaveFolder = New System.Windows.Forms.Button
        Me.btnSelectCSVFile = New System.Windows.Forms.Button
        Me.fldBankStatementsPath = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnGenerateReceipts = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Start receipt number:"
        '
        'fldStartReceiptNumber
        '
        Me.fldStartReceiptNumber.Location = New System.Drawing.Point(122, 39)
        Me.fldStartReceiptNumber.Name = "fldStartReceiptNumber"
        Me.fldStartReceiptNumber.Size = New System.Drawing.Size(78, 20)
        Me.fldStartReceiptNumber.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Save receipts to:"
        '
        'fldSaveDirectory
        '
        Me.fldSaveDirectory.Location = New System.Drawing.Point(122, 65)
        Me.fldSaveDirectory.Name = "fldSaveDirectory"
        Me.fldSaveDirectory.ReadOnly = True
        Me.fldSaveDirectory.Size = New System.Drawing.Size(271, 20)
        Me.fldSaveDirectory.TabIndex = 3
        '
        'btnSelectSaveFolder
        '
        Me.btnSelectSaveFolder.Location = New System.Drawing.Point(399, 63)
        Me.btnSelectSaveFolder.Name = "btnSelectSaveFolder"
        Me.btnSelectSaveFolder.Size = New System.Drawing.Size(24, 23)
        Me.btnSelectSaveFolder.TabIndex = 4
        Me.btnSelectSaveFolder.Text = "..."
        Me.btnSelectSaveFolder.UseVisualStyleBackColor = True
        '
        'btnSelectCSVFile
        '
        Me.btnSelectCSVFile.Location = New System.Drawing.Point(399, 10)
        Me.btnSelectCSVFile.Name = "btnSelectCSVFile"
        Me.btnSelectCSVFile.Size = New System.Drawing.Size(24, 23)
        Me.btnSelectCSVFile.TabIndex = 1
        Me.btnSelectCSVFile.Text = "..."
        Me.btnSelectCSVFile.UseVisualStyleBackColor = True
        '
        'fldBankStatementsPath
        '
        Me.fldBankStatementsPath.Location = New System.Drawing.Point(122, 12)
        Me.fldBankStatementsPath.Name = "fldBankStatementsPath"
        Me.fldBankStatementsPath.ReadOnly = True
        Me.fldBankStatementsPath.Size = New System.Drawing.Size(271, 20)
        Me.fldBankStatementsPath.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Bank statements CSV:"
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(324, 112)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(99, 29)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        '
        'btnGenerateReceipts
        '
        Me.btnGenerateReceipts.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGenerateReceipts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateReceipts.Location = New System.Drawing.Point(11, 112)
        Me.btnGenerateReceipts.Name = "btnGenerateReceipts"
        Me.btnGenerateReceipts.Size = New System.Drawing.Size(145, 29)
        Me.btnGenerateReceipts.TabIndex = 5
        Me.btnGenerateReceipts.Text = "Generate Receipts"
        '
        'frmReceiptsGeneration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 153)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnGenerateReceipts)
        Me.Controls.Add(Me.btnSelectCSVFile)
        Me.Controls.Add(Me.fldBankStatementsPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSelectSaveFolder)
        Me.Controls.Add(Me.fldSaveDirectory)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.fldStartReceiptNumber)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReceiptsGeneration"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generate Receipts From Bank Statement"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fldStartReceiptNumber As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents fldSaveDirectory As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectSaveFolder As System.Windows.Forms.Button
    Friend WithEvents btnSelectCSVFile As System.Windows.Forms.Button
    Friend WithEvents fldBankStatementsPath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnGenerateReceipts As System.Windows.Forms.Button

End Class
