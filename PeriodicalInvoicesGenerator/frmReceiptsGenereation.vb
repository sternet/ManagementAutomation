Imports System.Windows.Forms
Imports System.IO

Public Class frmReceiptsGeneration

    Private Sub btnGenerateReceipts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateReceipts.Click
        If Not ValidateInput() Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        GenerateReceipts()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
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
        If IsEmpty(fldBankStatementsPath.Text) Or Not FileIO.FileSystem.FileExists(fldBankStatementsPath.Text) Then
            MsgBox("Please, select a valid bank statements CSV file to load")
            Return False
        End If
        If Not IsEmpty(fldStartReceiptNumber.Text) Then
            Dim tempReceiptNumber As Integer
            Try
                tempReceiptNumber = CInt(fldStartReceiptNumber.Text.Trim)
                fldStartReceiptNumber.Text = CStr(tempReceiptNumber)
            Catch ex As Exception
                MsgBox("Receipt number is not a valid integer")
                Return False
            End Try
        End If
        If IsEmpty(fldSaveDirectory.Text) Or Not FileIO.FileSystem.DirectoryExists(fldSaveDirectory.Text) Then
            MsgBox("Please, select a valid directory to save the receipts to")
            Return False
        End If
        Return True
    End Function

    Public Structure Payment
        Dim shortDate As String
        Dim name As String
        Dim sum As String
    End Structure

    Private Function LoadPayments(ByRef bankStatementsPath As String) As List(Of Payment)
        Dim payments As New List(Of Payment)

        Dim bankStatementsCSVFile As FileIO.TextFieldParser = New FileIO.TextFieldParser(bankStatementsPath, System.Text.Encoding.GetEncoding("iso-8859-13"))
        bankStatementsCSVFile.TextFieldType = FileIO.FieldType.Delimited
        bankStatementsCSVFile.Delimiters = New String() {";"}
        bankStatementsCSVFile.HasFieldsEnclosedInQuotes = True

        Do While Not bankStatementsCSVFile.EndOfData
            Try
                Dim paymentRecord As String() = bankStatementsCSVFile.ReadFields
                If paymentRecord(0) = "Kliendi konto" Or paymentRecord(7) = "D" Then Continue Do

                Dim paymentData As New Payment
                With paymentData
                    .shortDate = paymentRecord(2)
                    .name = paymentRecord(4)
                    .sum = paymentRecord(8)
                End With
                payments.Add(paymentData)
            Catch ex As FileIO.MalformedLineException
                Stop
            End Try
        Loop

        Return payments
    End Function

    Private Sub GenerateReceipts()
        Dim receiptNumber As Integer = CInt(fldStartReceiptNumber.Text.Trim)
        Dim payments As List(Of Payment) = LoadPayments(fldBankStatementsPath.Text.Trim)
        For i As Integer = 0 To payments.Count - 1
            Dim receiptData As Payment = payments(i)
            Dim generator As New ReceiptGenerator
            generator.GenerateReceipt(receiptNumber + i, receiptData, fldSaveDirectory.Text.Trim)
        Next
    End Sub

    Private Sub btnSelectSaveFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSaveFolder.Click
        If FolderBrowserDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            fldSaveDirectory.Text = FolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub btnSelectCSVFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectCSVFile.Click
        Dim dialog As OpenFileDialog = New OpenFileDialog()

        dialog.Title = "Select Bank Statements CSV File"
        dialog.InitialDirectory = "C:\"
        dialog.Filter = "CSV files (*.csv)|*.*|All files (*.*)|*.*"
        dialog.FilterIndex = 1
        dialog.RestoreDirectory = True

        If dialog.ShowDialog() = DialogResult.OK Then
            fldBankStatementsPath.Text = dialog.FileName
        End If
    End Sub

    Private Sub InitializeTestData()
        fldBankStatementsPath.Text = "C:\Users\Alexander\Downloads\statement.csv"
        fldStartReceiptNumber.Text = "5"
        fldSaveDirectory.Text = "C:\Users\Alexander\Downloads\receipts"
    End Sub

    Private Sub frmReceiptsGeneration_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'InitializeTestData()
    End Sub
End Class
