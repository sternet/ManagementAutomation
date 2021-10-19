Public Class NewSupporter

    Public supporter As String

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Helper.IsEmpty(fldName.Text) Then
            MsgBox("Please, provide supporter's name")
            Exit Sub
        End If
        If Helper.IsEmpty(fldEmail.Text) Then
            MsgBox("Please, provide supporter's email")
            Exit Sub
        End If

        If Not My.Settings.SupportersEmails Is Nothing Then
            For Each supporterEmail In My.Settings.SupportersEmails
                If supporterEmail.EndsWith(fldEmail.Text.Trim & ")") Then
                    MsgBox("Supporter with this email already exists!")
                    Exit Sub
                End If
            Next
        End If

        supporter = fldName.Text.Trim & " ( " & fldEmail.Text.Trim & " ) "

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class