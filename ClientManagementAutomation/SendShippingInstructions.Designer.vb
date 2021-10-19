<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSendShippingInstructions
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
        Me.Send_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnRemoveDeliveryPerson = New System.Windows.Forms.Button
        Me.btnAddDeliveryPerson = New System.Windows.Forms.Button
        Me.cmbDeliveryPerson = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbShippingMethod = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.fldBody = New System.Windows.Forms.TextBox
        Me.fldSubject = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Send_Button
        '
        Me.Send_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Send_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Send_Button.Location = New System.Drawing.Point(12, 301)
        Me.Send_Button.Name = "Send_Button"
        Me.Send_Button.Size = New System.Drawing.Size(145, 30)
        Me.Send_Button.TabIndex = 1
        Me.Send_Button.Text = "Send Mail"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(214, 301)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(80, 30)
        Me.Cancel_Button.TabIndex = 2
        Me.Cancel_Button.Text = "Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnRemoveDeliveryPerson)
        Me.GroupBox1.Controls.Add(Me.btnAddDeliveryPerson)
        Me.GroupBox1.Controls.Add(Me.cmbDeliveryPerson)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmbShippingMethod)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 115)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Shipment details"
        '
        'btnRemoveDeliveryPerson
        '
        Me.btnRemoveDeliveryPerson.Location = New System.Drawing.Point(231, 77)
        Me.btnRemoveDeliveryPerson.Name = "btnRemoveDeliveryPerson"
        Me.btnRemoveDeliveryPerson.Size = New System.Drawing.Size(26, 20)
        Me.btnRemoveDeliveryPerson.TabIndex = 28
        Me.btnRemoveDeliveryPerson.Text = "-"
        Me.btnRemoveDeliveryPerson.UseVisualStyleBackColor = True
        '
        'btnAddDeliveryPerson
        '
        Me.btnAddDeliveryPerson.Location = New System.Drawing.Point(204, 77)
        Me.btnAddDeliveryPerson.Name = "btnAddDeliveryPerson"
        Me.btnAddDeliveryPerson.Size = New System.Drawing.Size(26, 20)
        Me.btnAddDeliveryPerson.TabIndex = 27
        Me.btnAddDeliveryPerson.Text = "+"
        Me.btnAddDeliveryPerson.UseVisualStyleBackColor = True
        '
        'cmbDeliveryPerson
        '
        Me.cmbDeliveryPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDeliveryPerson.FormattingEnabled = True
        Me.cmbDeliveryPerson.Location = New System.Drawing.Point(10, 77)
        Me.cmbDeliveryPerson.Name = "cmbDeliveryPerson"
        Me.cmbDeliveryPerson.Size = New System.Drawing.Size(189, 21)
        Me.cmbDeliveryPerson.TabIndex = 25
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Delivery person:"
        '
        'cmbShippingMethod
        '
        Me.cmbShippingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShippingMethod.FormattingEnabled = True
        Me.cmbShippingMethod.Location = New System.Drawing.Point(121, 23)
        Me.cmbShippingMethod.Name = "cmbShippingMethod"
        Me.cmbShippingMethod.Size = New System.Drawing.Size(134, 21)
        Me.cmbShippingMethod.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Shipping method:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.fldBody)
        Me.GroupBox2.Controls.Add(Me.fldSubject)
        Me.GroupBox2.Location = New System.Drawing.Point(300, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(462, 315)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Email content"
        '
        'fldBody
        '
        Me.fldBody.AcceptsReturn = True
        Me.fldBody.AcceptsTab = True
        Me.fldBody.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fldBody.Location = New System.Drawing.Point(22, 49)
        Me.fldBody.Multiline = True
        Me.fldBody.Name = "fldBody"
        Me.fldBody.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.fldBody.Size = New System.Drawing.Size(413, 245)
        Me.fldBody.TabIndex = 6
        '
        'fldSubject
        '
        Me.fldSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fldSubject.Location = New System.Drawing.Point(21, 23)
        Me.fldSubject.Name = "fldSubject"
        Me.fldSubject.Size = New System.Drawing.Size(414, 20)
        Me.fldSubject.TabIndex = 5
        '
        'dlgSendShippingInstructions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 343)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.Send_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSendShippingInstructions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Send Shipping Instructions"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Send_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbShippingMethod As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents fldBody As System.Windows.Forms.TextBox
    Friend WithEvents fldSubject As System.Windows.Forms.TextBox
    Friend WithEvents btnRemoveDeliveryPerson As System.Windows.Forms.Button
    Friend WithEvents btnAddDeliveryPerson As System.Windows.Forms.Button
    Friend WithEvents cmbDeliveryPerson As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label

End Class
