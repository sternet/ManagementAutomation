Imports System
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Text
Imports System.Collections
Imports System.Collections.Generic
Imports System.Net

Public Class GetResponseAPI

    Private Const MY_API_KEY = "4003be56f161ef69f84d846f71818064"

    Private Const API_URL = "http://api2.getresponse.com"

    Private Shared Function GetJsonResponse(ByRef method As String, ByRef requestParams As Hashtable) As Dictionary(Of String, Object)
        Dim jss As New JavaScriptSerializer()

        Dim request As New Hashtable
        request("jsonrpc") = "2.0"
        request("id") = 1

        request("method") = method

        Dim paramsArray As Object() = {MY_API_KEY, requestParams}
        request("params") = paramsArray

        System.Net.ServicePointManager.Expect100Continue = False

        Dim webRequest As HttpWebRequest = HttpWebRequest.Create(API_URL)
        webRequest.Method = "POST"

        Dim serializedRequest As String = jss.Serialize(request)
        Dim requestBytes As Byte() = Encoding.UTF8.GetBytes(serializedRequest)

        Dim responseString As String = Nothing

        Try
            Dim requestStream As Stream = webRequest.GetRequestStream()
            requestStream.Write(requestBytes, 0, requestBytes.Length)
            requestStream.Close()

            Dim response As HttpWebResponse = webRequest.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()

            Dim reader As StreamReader = New StreamReader(responseStream)
            responseString = reader.ReadToEnd()
            reader.Close()

            responseStream.Close()
            response.Close()
        Catch e As Exception
            Console.WriteLine(e.Message)
            Environment.Exit(0)
        End Try

        Dim jsonContent As Dictionary(Of String, Object) = jss.DeserializeObject(responseString)
        Dim value As Object = Nothing
        If jsonContent.TryGetValue("error", value) Then
            Dim jsonError As Dictionary(Of String, Object) = value
            Throw New Exception("Failed to execute request " & method & " with params " & serializedRequest & " : " & jsonError("message") & ", " & jsonError("code"))
        End If
        Dim jsonResponse As Dictionary(Of String, Object) = jsonContent("result")

        Return jsonResponse
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

    Public Shared Function FindByEmailCampaignAndContactIds(ByRef email As String, ByVal campaignPrefix As String) As Dictionary(Of String, String)
        Dim method As String = "get_contacts"

        Dim containsObj As New Hashtable
        containsObj("CONTAINS") = campaignPrefix & "%"

        Dim nameObj As New Hashtable
        nameObj("name") = containsObj

        Dim paramsObj As New Hashtable
        paramsObj("get_campaigns") = nameObj

        Dim operatorObj As New Hashtable
        operatorObj("EQUALS") = email
        paramsObj("email") = operatorObj

        Dim jsonResponse As Dictionary(Of String, Object) = GetJsonResponse(method, paramsObj)
        PrintJsonResponse(jsonResponse)

        Dim emailCampaigns As Dictionary(Of String, String) = New Dictionary(Of String, String)
        For Each contactId As String In jsonResponse.Keys
            emailCampaigns(contactId) = jsonResponse(contactId)("campaign")
        Next

        Return emailCampaigns
    End Function

    Public Shared Function GetCampaignName(ByVal campaignId As String) As String
        Dim method As String = "get_campaign"

        Dim campaignObj As New Hashtable
        campaignObj("campaign") = campaignId

        Dim jsonResponse As Dictionary(Of String, Object) = GetJsonResponse(method, campaignObj)
        PrintJsonResponse(jsonResponse)

        Return jsonResponse(campaignId)("name")
    End Function

    Public Shared Sub DeleteContact(ByVal contactId As String)
        Dim method As String = "delete_contact"

        Dim contactObj As New Hashtable
        contactObj("contact") = contactId

        Dim jsonResponse As Dictionary(Of String, Object) = GetJsonResponse(method, contactObj)
        PrintJsonResponse(jsonResponse)
    End Sub

    Public Shared Function FindCampaignIdByName(ByVal campaignName As String) As String
        Dim method As String = "get_campaigns"

        Dim operatorObj As New Hashtable
        operatorObj("EQUALS") = campaignName

        Dim nameObj As New Hashtable
        nameObj("name") = operatorObj

        Dim jsonResponse As Dictionary(Of String, Object) = GetJsonResponse(method, nameObj)
        PrintJsonResponse(jsonResponse)

        For Each campaingId As String In jsonResponse.Keys
            Return campaingId
        Next

        Return Nothing
    End Function

    Public Shared Function SubscribeToCampaign(ByVal campaignId As String, ByVal email As String, ByVal name As String) As Boolean
        Dim method As String = "add_contact"

        Dim addContactObj As New Hashtable
        addContactObj("campaign") = campaignId
        addContactObj("name") = name
        addContactObj("email") = email
        addContactObj("cycle_day") = 0

        Dim jsonResponse As Dictionary(Of String, Object) = GetJsonResponse(method, addContactObj)
        PrintJsonResponse(jsonResponse)

        Dim queued As Boolean = False
        Return jsonResponse.TryGetValue("queued", queued)
    End Function


End Class
