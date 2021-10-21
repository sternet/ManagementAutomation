Imports System
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Text
Imports System.Collections
Imports System.Collections.Generic
Imports System.Net

Public Class GetResponseAPI

    Private Const GETRESPONSE_API_V3 = "https://api.getresponse.com/v3"
    Private Const CRM_API_KEY = "api-key u8g664f09izpqkvpmr152sko7wsisi2q"

    Private Shared Function GetJsonResponse(ByVal isGet As Boolean, ByVal method As String, ByVal body As String) As Dictionary(Of String, Object)

        Dim uri As String = GETRESPONSE_API_V3 + method
        If isGet Then
            uri = uri + body
        End If

        Dim webRequest As HttpWebRequest = HttpWebRequest.Create(uri)
        With webRequest
            If isGet Then
                .Method = "GET"
            Else
                .Method = "POST"
            End If
            .ContentType = "application/json"
            .Accept = "application/json"
            .Headers.Add("X-Auth-Token", CRM_API_KEY)
            .Timeout = 3000
            .ReadWriteTimeout = 3000
        End With

        Dim responseString As String = Nothing

        Try
            If Not isGet Then
                Dim requestStream As Stream = webRequest.GetRequestStream()
                Dim requestBytes As Byte() = Encoding.UTF8.GetBytes(body)
                requestStream.Write(requestBytes, 0, requestBytes.Length)
                requestStream.Close()
            End If

            Try
                Dim response As HttpWebResponse = webRequest.GetResponse()
                Dim responseStream As Stream = response.GetResponseStream()
                Dim reader As StreamReader = New StreamReader(responseStream)
                responseString = reader.ReadToEnd()
                reader.Close()
                responseStream.Close()
                response.Close()

                If response.StatusCode = 200 Then
                    Dim jss As JavaScriptSerializer = New JavaScriptSerializer
                    Dim jsonContent As Object = jss.Deserialize(Of Object)(responseString)
                    If CType(jsonContent, System.Array).GetLength(0) = 0 Then
                        Return Nothing
                    End If
                    Return jsonContent(0)
                ElseIf response.StatusCode = 202 Then
                    Return Nothing
                Else
                    Throw New InvalidOperationException("Failed to get valid response from GetResponse API for query " & body & _
                                                            ", unsupported response code: " & response.StatusCode)
                End If
            Catch ex As WebException
                If CType(ex.Response, HttpWebResponse).StatusCode = 409 Then
                    Return Nothing
                End If
                Dim responseStream As Stream = ex.Response.GetResponseStream()
                Dim reader As StreamReader = New StreamReader(responseStream)
                responseString = reader.ReadToEnd()
                reader.Close()
                responseStream.Close()

                Dim jss As JavaScriptSerializer = New JavaScriptSerializer
                Dim jsonContent As Object = jss.Deserialize(Of Object)(responseString)
                Dim errorResponse As Dictionary(Of String, Object) = CType(jsonContent, Dictionary(Of String, Object))
                If errorResponse.ContainsKey("httpStatus") Then
                    Throw New InvalidOperationException("Failed to get valid response from GetResponse API for query " & body & ": " & _
                                        errorResponse("code") & ", " & errorResponse("codeDescription") & ", " & errorResponse("message") & _
                                        ", " & New JavaScriptSerializer().Serialize(errorResponse("context")))
                Else
                    Dim errorContent As String = jss.Serialize(errorResponse)
                    Throw New InvalidOperationException("Failed to get valid response from GetResponse API for query " & body & ": " & errorContent)
                End If
            End Try
        Catch ex As InvalidOperationException
            Throw ex
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Throw New InvalidOperationException("Failed to get valid response from GetResponse API for query " & body & ": " & ex.Message)
        End Try
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

    Public Shared Function FindCampaignIdByName(ByVal campaignName As String) As String
        Dim method As String = "/campaigns"

        Dim jsonResponse As Dictionary(Of String, Object) = GetJsonResponse(True, method, "?query[name]=" & campaignName & "&fields=campaignId,name")
        If jsonResponse Is Nothing Then
            Throw New InvalidOperationException("Campaing " & campaignName & " not found")
        End If

        PrintJsonResponse(jsonResponse)
        Return jsonResponse("campaignId")
    End Function

    Public Shared Function SubscribeToCampaign(ByVal campaignId As String, ByVal email As String, ByVal name As String) As Boolean
        Dim method As String = "/contacts"

        Dim newSubscriber As New Hashtable
        newSubscriber("name") = name
        Dim campaign As New Hashtable()
        campaign.Add("campaignId", campaignId)
        newSubscriber("campaign") = campaign
        newSubscriber("email") = email
        newSubscriber("dayOfCycle") = 0

        Try
            Dim jss As JavaScriptSerializer = New JavaScriptSerializer
            Dim subscriber As String = jss.Serialize(newSubscriber)
            GetJsonResponse(False, method, subscriber)
            Return True
        Catch e As Exception
            Console.WriteLine(e.Message)
            Return False
        End Try
    End Function

End Class
