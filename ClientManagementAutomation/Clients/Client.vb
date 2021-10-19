Public Class Client
    Public dbCode As Long
    Public firstName As String
    Public lastName As String
    Public email As String
    Public language As String
    Public mobilePhone As String
    Public homePhone As String
    Public homeAddress As String
    Public shippingAddress As String
    Public healthNotes As String
    Public comments As String

    Public Shared Function From(ByVal jsonResponse As Dictionary(Of String, Object)) As Client
        Dim client As New Client
        With client
            .dbCode = Long.Parse(jsonResponse("dbCode"))
            .firstName = jsonResponse("firstName")
            .lastName = jsonResponse("lastName")
            .email = jsonResponse("email")
            .language = jsonResponse("language")
            .mobilePhone = jsonResponse("mobilePhone")
            .homePhone = jsonResponse("homePhone")
            .homeAddress = jsonResponse("homeAddress")
            .shippingAddress = jsonResponse("shippingAddress")
            .healthNotes = jsonResponse("healthNotes")
            .comments = jsonResponse("comments")
        End With
        Return client
    End Function

End Class
