Imports System
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Text
Imports System.Collections
Imports System.Collections.Generic
Imports System.Net
Imports System.Web

Public Class ClientsService

    Private Const SERVICE_URL = "http://simeonsdietdiary.com:9095/client"
    'Private Const SERVICE_URL = "http://localhost:8090/client"

    Private Shared Function GetJsonResponse(ByRef method As String, ByRef uri As String, Optional ByRef postParameters As Hashtable = Nothing) As Dictionary(Of String, Object)
        Dim jss As New JavaScriptSerializer()

        System.Net.ServicePointManager.Expect100Continue = False

        Dim finalUrl As String = SERVICE_URL & uri

        Dim webRequest As HttpWebRequest = HttpWebRequest.Create(finalUrl)
        webRequest.Method = method
        webRequest.ContentType = "application/json"
        webRequest.Accept = "application/json"

        Dim responseString As String = Nothing

        Try
            If method <> "GET" Then
                Dim requestBytes As Byte()
                If Not postParameters Is Nothing Then
                    Dim serializedRequest As String = jss.Serialize(postParameters)
                    requestBytes = Encoding.UTF8.GetBytes(serializedRequest)
                Else
                    requestBytes = New Byte() {}
                End If
                Dim requestStream As Stream = webRequest.GetRequestStream()
                requestStream.Write(requestBytes, 0, requestBytes.Length)
                requestStream.Close()
            End If

            Dim response As HttpWebResponse = webRequest.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()

            Dim reader As StreamReader = New StreamReader(responseStream)
            responseString = reader.ReadToEnd()
            reader.Close()

            responseStream.Close()
            response.Close()
        Catch e As Exception
            Throw New Exception("Failed to execute request " & finalUrl & " using method " & method & " : " & e.Message)
        End Try

        Dim jsonContent As Dictionary(Of String, Object) = jss.DeserializeObject(responseString)

        Dim value As Object = Nothing
        If Not jsonContent Is Nothing Then
            If jsonContent.TryGetValue("error", value) Then
                Dim jsonError As Dictionary(Of String, Object) = value
                Throw New Exception("Failed to execute request " & finalUrl & " using method " & method & " : " & jsonError("message") & ", " & jsonError("code"))
            End If
        End If
        Return jsonContent
    End Function

    Private Shared Sub PrintJsonResponse(ByRef jsonResponse As Dictionary(Of String, Object), Optional ByVal tabs As String = "")
        If jsonResponse Is Nothing Then Exit Sub
        Console.WriteLine(tabs & "{")
        Dim newTabs = tabs & vbTab
        For Each key As Object In jsonResponse.Keys
            Console.Write(newTabs & key.ToString() & " : ")
            Dim keyValue As Object = jsonResponse(key)
            If TypeOf keyValue Is Dictionary(Of String, Object) Then
                PrintJsonResponse(keyValue, newTabs)
            Else
                Console.WriteLine(CStr(keyValue))
            End If
        Next
        Console.WriteLine(tabs & "}")
    End Sub

    Public Shared Function GetClientByPhone(ByVal phone As String) As Client
        Dim uri As String = "/phone/?phone=" & HttpUtility.UrlEncode(phone)
        Dim jsonResponse As Dictionary(Of String, Object) = GetJsonResponse("GET", uri)
        Return Client.From(jsonResponse)
    End Function

    Public Shared Function GetClientByEmail(ByVal email As String) As Client
        Dim uri As String = "/email/?email=" & HttpUtility.UrlEncode(email)
        Dim jsonResponse As Dictionary(Of String, Object) = GetJsonResponse("GET", uri)
        Return Client.From(jsonResponse)
    End Function

    Public Shared Sub UpdateClient(ByRef client As Client)
        Dim postParameters As New Hashtable
        With client
            postParameters("email") = client.email
            postParameters("language") = client.language
            postParameters("mobilePhone") = client.mobilePhone
            postParameters("homePhone") = client.homePhone
            postParameters("homeAddress") = client.homeAddress
            postParameters("shippingAddress") = client.shippingAddress
            postParameters("healthNotes") = client.healthNotes
            postParameters("comments") = client.comments
        End With

        Dim uri As String = "/" & client.dbCode
        Dim jsonResponse As Dictionary(Of String, Object) = GetJsonResponse("POST", uri, postParameters)
        MsgBox("Client was updated successfully")
    End Sub

End Class
