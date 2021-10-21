Imports System.Net
Imports System.Text
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.IO
Imports Microsoft.Win32
Imports System.Security.Cryptography
Imports System.Threading
Imports System.ComponentModel

Public Class Helper

    Public Const LANG_RUSSIAN = "Русский"
    Public Const LANG_HEBREW = "עברית"
    Public Const LANG_ESTONIAN = "Eesti"
    Public Const LANG_ENGLISH = "English"
    Public Const LANG_FINNISH = "Suomi"
    Public Const LANG_SWEDISH = "Svenska"

    Public Const LANG_SHORT_RUSSIAN = "ru"
    Public Const LANG_SHORT_HEBREW = "he"
    Public Const LANG_SHORT_ESTONIAN = "et"
    Public Const LANG_SHORT_ENGLISH = "en"
    Public Const LANG_SHORT_FINNISH = "fi"
    Public Const LANG_SHORT_SWEDISH = "se"

    Public Const SITE_RUSSIAN = "DietaSimeonsa.eu"
    Public Const SITE_HEBREW = "DietatSimeons.co.il"
    Public Const SITE_ESTONIAN = "SimeonsiDieet.ee"
    Public Const SITE_ENGLISH = "SimeonsDiet.co.uk"
    Public Const SITE_FINNISH = "SimeonsinDieetti.fi"
    Public Const SITE_SWEDISH = "SimeonsDiet.se"

    Public Const LEADS_CAMPAIGN_NAME_RUSSIAN = "dietasimeonsa"
    Public Const LEADS_CAMPAIGN_NAME_HEBREW = "dietatsimeons"
    Public Const LEADS_CAMPAIGN_NAME_ESTONIA = "simeonsidiet"
    Public Const LEADS_CAMPAIGN_NAME_UNITED_STATES = "simeonsdiet"
    Public Const LEADS_CAMPAIGN_NAME_FINLAND = "simeonsindieet"
    Public Const LEADS_CAMPAIGN_NAME_SWEDEN = "simeonsdietse"

    Public Const FULL_SITE_RUSSIAN = "http://www.dietasimeonsa.eu"
    Public Const FULL_SITE_HEBREW = "http://www.dietatsimeons.co.il"
    Public Const FULL_SITE_ESTONIAN = "http://www.simeonsidieet.ee"
    Public Const FULL_SITE_ENGLISH = "http://www.simeonsdiet.co.uk"
    Public Const FULL_SITE_FINNISH = "http://www.simeonsindieetti.fi"
    Public Const FULL_SITE_SWEDISH = "http://www.simeonsdiet.se"

    Public Const PACKAGE_FULL_BOOK = "Full package + Book"
    Public Const PACKAGE_FULL = "Full package"
    Public Const PACKAGE_GUIDE = "Guide only"
    Public Const PACKAGE_BOOK = "Book only"
    Public Const PACKAGE_SUPPORT = "Support only"

    Public Const PAYMENT_CREDIT = "Credit card"
    Public Const PAYMENT_CASH = "Cash on spot"
    Public Const PAYMENT_TRANSFER = "Bank transfer"

    Public Const COUNTRY_RUSSIA = "Russia"
    Public Const COUNTRY_ISRAEL = "Israel"
    Public Const COUNTRY_ESTONIA = "Estonia"
    Public Const COUNTRY_UKRAIN = "Ukrain"
    Public Const COUNTRY_LITHUANIA = "Lithuania"
    Public Const COUNTRY_FINLAND = "Finland"
    Public Const COUNTRY_SWEDEN = "Sweden"
    Public Const COUNTRY_UNITED_STATES = "United States"
    Public Const COUNTRY_UNITED_KINDOM = "United Kindom"

    Public Const ANAT_STERN_RUSSIAN = "Анат Штерн"
    Public Const ANAT_STERN_HEBREW = "ענת שטרן"
    Public Const ANAT_STERN_ESTONIAN = "Anat Stern"
    Public Const ANAT_STERN_ENGLISH = "Anat Stern"

    Public Const SITE_NAME_RUSSIAN = "Диета д-ра Симеонса"
    Public Const SITE_NAME_HEBREW = "דיאטת דר' סימאונס"
    Public Const SITE_NAME_ESTONIAN = "Dr. Simeonsi Dieet"
    Public Const SITE_NAME_ENGLISH = "Dr. Simeons Diet"
    Public Const SITE_NAME_FINNISH = "T-ri Simeonsin dieetti"
    Public Const SITE_NAME_SWEDISH = "Dr. Simeons Diet"

    Public Const SHIPPING_METHOD_REGISTERED_MAIL = "Registered mail"
    Public Const SHIPPING_METHOD_COURIER = "Courier"
    Public Const SHIPPING_METHOD_SHIPPMENT_ABROAD = "Shippment abroad"
    Public Const SHIPPING_METHOD_PICKUP = "Pickup"

    Public Const BASIC_PACKAGE_PASSWORD_RUSSIAN = "DietaSimeonsa2014"
    Public Const BASIC_PACKAGE_PASSWORD_HEBREW = "DietatSimeons2014"

    Public Shared Function GeneratePassword() As String
        Const passwordMaxLength As Integer = 6
        Dim str As String = "123456789"
        Dim sb As String = ""
        Dim r = New Random
        Dim te As Integer = 0
        For i = 1 To passwordMaxLength
            te = r.Next(str.Length)
            sb = sb + str.ElementAt(te)
        Next
        Return sb
    End Function

    Public Shared Function GetMd5Hash(ByVal input As String) As String
        Dim md5Hash As MD5 = MD5.Create

        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
        Dim sBuilder As New StringBuilder()

        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        Return sBuilder.ToString()
    End Function

    Public Shared Function GetShortLanguage(ByRef language As String) As String
        If language = LANG_RUSSIAN Then
            Return LANG_SHORT_RUSSIAN
        ElseIf language = LANG_HEBREW Then
            Return LANG_SHORT_HEBREW
        ElseIf language = LANG_ESTONIAN Then
            Return LANG_SHORT_ESTONIAN
        ElseIf language = LANG_ENGLISH Then
            Return LANG_SHORT_ENGLISH
        ElseIf language = LANG_FINNISH Then
            Return LANG_SHORT_FINNISH
        ElseIf language = LANG_SWEDISH Then
            Return LANG_SHORT_SWEDISH
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function GetLongLanguage(ByRef language As String, ByRef site As String) As String
        Dim shortLanguage As String = GetShortLanguage(language)
        Return shortLanguage
    End Function

    Public Shared Function GetFullSite(ByRef site As String) As String
        If site = SITE_RUSSIAN Then
            Return FULL_SITE_RUSSIAN
        ElseIf site = SITE_HEBREW Then
            Return FULL_SITE_HEBREW
        ElseIf site = SITE_ESTONIAN Then
            Return FULL_SITE_ESTONIAN
        ElseIf site = SITE_ENGLISH Then
            Return FULL_SITE_ENGLISH
        ElseIf site = SITE_SWEDISH Then
            Return FULL_SITE_SWEDISH
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function GetSelectedLanguageSite(ByRef selectedLanguage As String) As String
        If selectedLanguage = LANG_RUSSIAN Then
            Return SITE_RUSSIAN
        ElseIf selectedLanguage = LANG_HEBREW Then
            Return SITE_HEBREW
        ElseIf selectedLanguage = LANG_ESTONIAN Then
            Return SITE_ESTONIAN
        ElseIf selectedLanguage = LANG_ENGLISH Then
            Return SITE_ENGLISH
        ElseIf selectedLanguage = LANG_FINNISH Then
            Return SITE_FINNISH
        ElseIf selectedLanguage = LANG_SWEDISH Then
            Return SITE_SWEDISH
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function GetLanguageDefaultCountry(ByRef language As String) As String
        If language = LANG_RUSSIAN Then
            Return COUNTRY_RUSSIA
        ElseIf language = LANG_HEBREW Then
            Return COUNTRY_ISRAEL
        ElseIf language = LANG_ESTONIAN Then
            Return COUNTRY_ESTONIA
        ElseIf language = LANG_ENGLISH Then
            Return COUNTRY_UNITED_KINDOM
        ElseIf language = LANG_FINNISH Then
            Return COUNTRY_FINLAND
        ElseIf language = LANG_SWEDISH Then
            Return COUNTRY_SWEDEN
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function GetLeadsCampaignName(ByRef language As String) As String
        If language = LANG_RUSSIAN Then
            Return LEADS_CAMPAIGN_NAME_RUSSIAN
        ElseIf language = LANG_HEBREW Then
            Return LEADS_CAMPAIGN_NAME_HEBREW
        ElseIf language = LANG_ESTONIAN Then
            Return LEADS_CAMPAIGN_NAME_ESTONIA
        ElseIf language = LANG_ENGLISH Then
            Return LEADS_CAMPAIGN_NAME_UNITED_STATES
        ElseIf language = LANG_FINNISH Then
            Return LEADS_CAMPAIGN_NAME_FINLAND
        ElseIf language = LANG_SWEDISH Then
            Return LEADS_CAMPAIGN_NAME_SWEDEN
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function GetClientsCampaignName(ByRef language As String) As String
        Dim leadsCampaignName As String = GetLeadsCampaignName(language)
        Return leadsCampaignName & "4clients"
    End Function

    Public Shared Function IsEmpty(ByRef value As String) As Boolean
        If value Is Nothing Then
            Return True
        End If
        Return value.Trim.Length = 0
    End Function

    Public Shared Sub SendMail( _
        ByRef fromName As String, ByRef fromEmail As String, _
        ByRef replyToName As String, ByRef replyToEmail As String, _
        ByRef recipientName As String, ByRef recipientEmail As String, ByVal ccToSender As Boolean, _
        ByRef subject As String, ByRef body As String)

        'SendMailWithAttachments(senderName, senderEmail, recipientName, recipientEmail, ccToSender, subject, body, Nothing)

        Dim mailMessage As New MailMessage

        With mailMessage
            If Not IsEmpty(recipientName) Then
                .To.Add(New MailAddress(recipientEmail, recipientName, Encoding.UTF8))
            Else
                .To.Add(New MailAddress(recipientEmail))
            End If
            .From = New MailAddress(fromEmail, fromName, Encoding.UTF8)
            If Not IsEmpty(replyToName) Then
                .ReplyTo = New MailAddress(replyToEmail, replyToName, Encoding.UTF8)
            Else
                .ReplyTo = New MailAddress(replyToEmail)
            End If
            If ccToSender Then
                .Bcc.Add(New MailAddress(replyToEmail))
            End If
            .Subject = subject
            .SubjectEncoding = Encoding.UTF8
            .Body = body
            .BodyEncoding = Encoding.UTF8
            .IsBodyHtml = True
        End With

        Dim smtpServer As New SmtpClient
        smtpServer.Host = My.Settings.smtpHost
        smtpServer.Port = My.Settings.smtpPort
        smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
        smtpServer.EnableSsl = True
        smtpServer.Credentials = New Net.NetworkCredential(My.Settings.smtpUsername, My.Settings.smtpPassword)
        smtpServer.Timeout = 15 * 60 * 1000 '15 minutes
        smtpServer.ServicePoint.SetTcpKeepAlive(False, 0, 0)
        smtpServer.ServicePoint.MaxIdleTime = System.Threading.Timeout.Infinite

        Log("Sending email to '" & recipientEmail & "', subject: " & subject)
        Log("Using " & My.Settings.smtpHost & ":" & My.Settings.smtpPort & " with SSL, auth " & My.Settings.smtpUsername & "/" & My.Settings.smtpPassword)

        smtpServer.Send(mailMessage)
    End Sub

    'Public Shared Sub SendMailOneAttachment( _
    '    ByRef senderName As String, ByRef senderEmail As String, _
    '    ByRef recipientName As String, ByRef recipientEmail As String, ByVal ccToSender As Boolean, _
    '    ByRef subject As String, ByRef body As String, ByRef attachmentFile As String)

    '    SendMailWithAttachments(senderName, senderEmail, recipientName, recipientEmail, ccToSender, subject, body, New String() {attachmentFile})
    'End Sub

    'Public Shared Sub SendMailWithAttachments( _
    '    ByRef senderName As String, ByRef senderEmail As String, _
    '    ByRef recipientName As String, ByRef recipientEmail As String, ByVal ccToSender As Boolean, _
    '    ByRef subject As String, ByRef body As String, ByRef attachments As String())

    '    Dim mailMessage As New MailMessage

    '    With mailMessage
    '        If Not IsEmpty(recipientName) Then
    '            .To.Add(New MailAddress(recipientEmail, recipientName, Encoding.UTF8))
    '        Else
    '            .To.Add(New MailAddress(recipientEmail))
    '        End If
    '        If Not IsEmpty(senderName) Then
    '            .From = New MailAddress(senderEmail, senderName, Encoding.UTF8)
    '        Else
    '            .From = New MailAddress(senderEmail)
    '        End If
    '        If ccToSender Then
    '            .Bcc.Add(New MailAddress(senderEmail))
    '        End If
    '        .Subject = subject
    '        .SubjectEncoding = Encoding.UTF8
    '        .Body = body
    '        .BodyEncoding = Encoding.UTF8
    '        .IsBodyHtml = True
    '        If Not attachments Is Nothing Then
    '            For Each attachment In attachments
    '                .Attachments.Add(New Attachment(attachment))
    '            Next
    '        End If
    '    End With

    '    Dim smtpServer As New SmtpClient
    '    smtpServer.Host = My.Settings.smtpHost
    '    smtpServer.Port = My.Settings.smtpPort
    '    smtpServer.EnableSsl = False
    '    smtpServer.Credentials = New Net.NetworkCredential(My.Settings.smtpUsername, My.Settings.smtpPassword)
    '    smtpServer.Timeout = 15 * 60 * 1000 '15 minutes
    '    smtpServer.ServicePoint.SetTcpKeepAlive(False, 0, 0)
    '    smtpServer.ServicePoint.MaxIdleTime = System.Threading.Timeout.Infinite

    '    'AddHandler smtpServer.SendCompleted, AddressOf SendCompletedCallback
    '    Console.WriteLine(vbCrLf & "[" & DateTime.Now & "] Sending email to '" & recipientEmail & "', subject: " & subject & ", with " & If(attachments IsNot Nothing, attachments.Length, 0) & " attachments")
    '    'smtpServer.SendAsync(mailMessage, recipientName)

    '    smtpServer.Send(mailMessage)
    'End Sub

    'Private Shared Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
    '    Dim recipient As String = CStr(e.UserState)
    '    If e.Error IsNot Nothing Then
    '        Dim message As String = e.Error.Message
    '        Dim fullStack As String = e.Error.ToString
    '        If TypeOf e.Error Is SmtpException Then
    '            Dim ex As SmtpException = e.Error
    '            Dim inner As Exception = e.Error.InnerException
    '            While inner IsNot Nothing
    '                message = message & " > " & inner.Message
    '                fullStack = fullStack & " > " & inner.ToString
    '                inner = inner.InnerException
    '            End While
    '        End If
    '        Console.WriteLine(vbCrLf & "[" & DateTime.Now & "] Failed to send email to '" & recipient & "': " & fullStack)
    '        MsgBox("Failed to send email to " & recipient & ": " & message)
    '    Else
    '        Console.WriteLine(vbCrLf & "[" & DateTime.Now & "] Mail was successfully sent to '" & recipient & "'")
    '    End If
    'End Sub

    Public Shared Function GetAnatSternName(ByRef language As String) As String
        If language = LANG_RUSSIAN Then
            Return ANAT_STERN_RUSSIAN
        ElseIf language = LANG_HEBREW Then
            Return ANAT_STERN_HEBREW
        ElseIf language = LANG_ESTONIAN Then
            Return ANAT_STERN_ESTONIAN
        ElseIf language = LANG_ENGLISH Then
            Return ANAT_STERN_ENGLISH
        ElseIf language = LANG_FINNISH Then
            Return ANAT_STERN_ENGLISH
        ElseIf language = LANG_SWEDISH Then
            Return ANAT_STERN_ENGLISH
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function GetSiteNameAsSenderName(ByRef language As String) As String
        If language = LANG_RUSSIAN Then
            Return SITE_NAME_RUSSIAN
        ElseIf language = LANG_HEBREW Then
            Return SITE_NAME_HEBREW
        ElseIf language = LANG_ESTONIAN Then
            Return SITE_NAME_ESTONIAN
        ElseIf language = LANG_ENGLISH Then
            Return SITE_NAME_ENGLISH
        ElseIf language = LANG_FINNISH Then
            Return SITE_NAME_FINNISH
        ElseIf language = LANG_SWEDISH Then
            Return SITE_NAME_SWEDISH
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function GetBasicPackagePassword(ByRef language As String) As String
        If language = LANG_RUSSIAN Then
            Return BASIC_PACKAGE_PASSWORD_RUSSIAN
        ElseIf language = LANG_HEBREW Then
            Return BASIC_PACKAGE_PASSWORD_HEBREW
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function GetDatedReceiptPath(ByRef receiptNumber As Integer, ByRef englishName As String, ByRef receiptDate As Date) As String
        Dim monthFolder As String = receiptDate.Year & "\"
        If receiptDate.Month < 10 Then
            monthFolder = monthFolder & "0" & receiptDate.Month
        Else
            monthFolder = monthFolder & "\" & receiptDate.Month
        End If
        monthFolder = monthFolder & " " & receiptDate.Year

        If Not Directory.Exists(My.Settings.SaveDirectory & "\" & monthFolder) Then
            Directory.CreateDirectory(My.Settings.SaveDirectory & "\" & monthFolder)
        End If

        Return My.Settings.SaveDirectory & "\" & monthFolder & "\" & CStr(receiptNumber) & " Dieting Package " & englishName & ".pdf"
    End Function

    Public Shared Function ExtractSupporterName(ByVal supporterNameAndEmail As String) As String
        If IsEmpty(supporterNameAndEmail) Then Return Nothing
        Dim nameOnly As String = supporterNameAndEmail.Substring(0, supporterNameAndEmail.IndexOf(" ("))
        Return nameOnly
    End Function

    Public Shared Function ExtractSupporterEmail(ByVal supporterNameAndEmail As String) As String
        If IsEmpty(supporterNameAndEmail) Then Return Nothing
        Dim emailOnly As String = supporterNameAndEmail.Substring(supporterNameAndEmail.IndexOf("(") + 2)
        emailOnly = emailOnly.Substring(0, emailOnly.Length - 2)
        Return emailOnly
    End Function

    Public Shared Function StripTags(ByVal HTML As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(HTML, "<[^>]*>", "")
    End Function

    Public Shared Function Base64Encode(ByRef Content As String) As String
        Return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Content))
    End Function

    Public Shared Function IsEU(ByRef Country As String) As Boolean
        If Country = COUNTRY_ESTONIA Or _
            Country = COUNTRY_LITHUANIA Or _
            Country = COUNTRY_FINLAND Or _
            Country = COUNTRY_SWEDEN Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Sub Log(ByVal entry As String)
        Console.WriteLine(vbCrLf & "[" & DateTime.Now & "] " + entry)
    End Sub
End Class
