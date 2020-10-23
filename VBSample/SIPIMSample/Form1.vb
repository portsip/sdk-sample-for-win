Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports SIPIMSample.PortSIP
Imports SIPIMSample.PortSIP.Config



Public Partial Class Form1
	Inherits Form
	Implements SIPCallbackEvents

	Private _SIPInited As Boolean = False
	Private _SIPLogined As Boolean = False
	Private _xmlContact As XmlConfig

	Private _sdkLib As PortSIPLib


	Private Function GetBytes(str As String) As Byte()
		Return System.Text.Encoding.[Default].GetBytes(str)
	End Function

	Private Function GetString(bytes As Byte()) As String
		Return System.Text.Encoding.[Default].GetString(bytes)
	End Function

	Private Function getLocalIP() As String
		Dim localIP As New StringBuilder()
		localIP.Length = 64
		Dim nics As Integer = _sdkLib.getNICNums()
		For i As Integer = 0 To nics - 1
			_sdkLib.getLocalIpAddress(i, localIP, 64)
			If localIP.ToString().IndexOf(":") = -1 Then
				' No ":" in the IP then it's the IPv4 address, we use it in our sample
				Exit For
					' the ":" is occurs in the IP then this is the IPv6 address.
					' In our sample we don't use the IPv6.
			Else

			End If
		Next

		Return localIP.ToString()
	End Function


	Public Sub New()
		InitializeComponent()


		Control.CheckForIllegalCrossThreadCalls = False
	End Sub


	Private Sub Form1_Load(sender As Object, e As EventArgs)
		ContactsList.Columns.Clear()
		ContactsList.Columns.Add("SIP Url", 180, HorizontalAlignment.Left)
		ContactsList.Columns.Add("Status", 120, HorizontalAlignment.Left)
		ContactsList.Columns.Add("Subscribed", 70, HorizontalAlignment.Left)
		ContactsList.Columns.Add("AcceptSubscribed", 70, HorizontalAlignment.Left)
		ContactsList.Columns.Add("SubscribeID", 0, HorizontalAlignment.Left)



		Dim path As String = System.IO.Directory.GetCurrentDirectory() & "\SIPIMContacts.xml"

		_xmlContact = New XmlConfig(path)

		_xmlContact.ReadContacts(ContactsList)
	End Sub



	Private Sub Offline()

        If _SIPLogined = False Then
            Return
        End If

        If RadioButton1.Checked Then
            _sdkLib.setPresenceStatus(0, "unpublish")
            Return
        End If

        For i As Integer = 0 To ContactsList.Items.Count - 1
			Dim SipUri As String = ContactsList.Items(i).SubItems(0).Text
			Dim subscribeId As Integer = Integer.Parse(ContactsList.Items(i).SubItems(4).Text)

			If ContactsList.Items(i).SubItems(3).Text = "Accepted" AndAlso subscribeId <> -1 Then
                _sdkLib.setPresenceStatus(subscribeId, "Offline")
            End If
		Next

		_xmlContact.WriteContacts(ContactsList)
	End Sub


	Private Sub Release()
		If _SIPInited = False Then
			Return
		End If




        If _SIPLogined = True Then
            Offline()
            _sdkLib.unRegisterServer()

            Threading.Thread.Sleep(3000)
            _SIPLogined = False
        End If


        If _SIPInited = True Then
            _sdkLib.removeUser()
            _sdkLib.unInitialize()
            _sdkLib.releaseCallbackHandlers()

            _SIPInited = False
        End If


        ListBoxSIPLog.Items.Clear()
	End Sub

	Private Sub BtnOnline_Click(sender As Object, e As EventArgs)
		If _SIPInited = True Then
			MessageBox.Show("You are already logged in.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If


		If txtUserName.Text.Length <= 0 Then
			MessageBox.Show("The user name does not allows empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If


		If txtPassword.Text.Length <= 0 Then
			MessageBox.Show("The password does not allows empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		If txtSIPServer.Text.Length <= 0 Then
			MessageBox.Show("The proxy server does not allows empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		Dim SIPServerPort As Integer = 0
		If txtSIPPort.Text.Length > 0 Then
			SIPServerPort = Integer.Parse(txtSIPPort.Text)
			If SIPServerPort > 65535 OrElse SIPServerPort <= 0 Then
				MessageBox.Show("The SIP server port out of range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

				Return
			End If
		End If


		Dim StunServerPort As Integer = 0
		If txtStunServer.Text.Length > 0 Then
			StunServerPort = Integer.Parse(txtStunPort.Text)
			If StunServerPort > 65535 OrElse StunServerPort <= 0 Then
				MessageBox.Show("The Stun server port out of range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

				Return
			End If
        End If


        Dim rd As New Random()
        ' Generate the random port for SIP
        Dim LocalSIPPort As Integer = rd.[Next](1000, 5000) + 4000
        Dim transport As TRANSPORT_TYPE = TRANSPORT_TYPE.TRANSPORT_UDP

		'
		' Create the class instance of PortSIP VoIP SDK, you can create more than one instances and 
		' each instance register to a SIP server to support multiples accounts & providers.
		' for example:
		'
'            _sdkLib1 = new PortSIPLib(1, 1, this);
'            _sdkLib2 = new PortSIPLib(2, 2, this);
'            _sdkLib3 = new PortSIPLib(3, 3, this);
'            

		_sdkLib = New PortSIPLib(0, 0, Me)

		'
		' Create and set the SIP callback handers, this MUST called before
		' _sdkLib.initialize();
		'
		_sdkLib.createCallbackHandlers()

		Dim logFilePath As String = "d:\"
		' The log file path, you can change it - the folder MUST exists
        Dim agent As String = "PortSIP VoIP SDK"
		Dim stunServer As String = txtStunServer.Text

        ' Initialize the SDK
        ' Use 0.0.0.0 for local IP then the SDK will choose an available local IP automatically.
        'You also can specify a certain local IP to instead of "0.0.0.0", more details please read the SDK User Manual
        Dim rt As Int32 = _sdkLib.initialize(transport, "0.0.0.0", LocalSIPPort, PORTSIP_LOG_LEVEL.PORTSIP_LOG_NONE, logFilePath, 8, agent, 0, 0, "/", "", False)

        If rt <> 0 Then
            _sdkLib.releaseCallbackHandlers()
            MessageBox.Show("initialize failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

		ListBoxSIPLog.Items.Add("Initialized.")
		_SIPInited = True

		Dim userName As String = txtUserName.Text
		Dim password As String = txtPassword.Text
        Dim sipDomain As String = txtUserDomain.Text
		Dim SIPServer As String = txtSIPServer.Text
		Dim displayName As String = txtDisplayName.Text
		Dim authName As String = txtAuthName.Text

		Dim outboundServerPort As Integer = 0
		Dim outboundServer As String = ""




        ' Set the SIP user information

        rt = _sdkLib.setUser(userName, _
                             displayName, _
                             authName, _
                             password, _
                            sipDomain, _
                            SIPServer, _
                            SIPServerPort, _
                            stunServer, _
                            StunServerPort, _
                            outboundServer, _
                            outboundServerPort)
		If rt <> 0 Then
			_sdkLib.unInitialize()
			_sdkLib.releaseCallbackHandlers()

			_SIPInited = False

			ListBoxSIPLog.Items.Clear()

			MessageBox.Show("setUser failure.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		ListBoxSIPLog.Items.Add("Succeeded set user information.")



        Dim licenseKey As String = "PORTSIP_TEST_LICENSE"
        rt = _sdkLib.setLicenseKey(licenseKey)
        If rt = PortSIP_Errors.ECoreTrialVersionLicenseKey Then
            MessageBox.Show("This sample was built base on evaluation PortSIP VoIP SDK, which allows only three minutes conversation. The conversation will be cut off automatically after three minutes, then you can't hearing anything. Feel free contact us at: sales@portsip.com to purchase the official version.")
        End If

        If rt = PortSIP_Errors.ECoreWrongLicenseKey Then
            MessageBox.Show("The wrong license key was detected, please check with sales@portsip.com or support@portsip.com")
        End If

        If RadioButton1.Checked Then
            _sdkLib.setPresenceMode(0)
        Else
            _sdkLib.setPresenceMode(1)
        End If

        rt = _sdkLib.registerServer(120, 0)
		If rt <> 0 Then
            _SIPInited = False
            _sdkLib.removeUser()
			_sdkLib.unInitialize()

			_sdkLib.releaseCallbackHandlers()

			ListBoxSIPLog.Items.Clear()

			MessageBox.Show("register to server failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If


		ListBoxSIPLog.Items.Add("Registering...")
	End Sub

	Private Sub BtnOffline_Click(sender As Object, e As EventArgs)
		If _SIPInited = False Then
			Return
		End If

		Release()
	End Sub

	Private Sub BtnDelContact_Click(sender As Object, e As EventArgs)
		If ContactsList.SelectedItems.Count > 0 Then
			ContactsList.Items.RemoveAt(ContactsList.SelectedItems(0).Index)
		End If

		_xmlContact.WriteContacts(ContactsList)
	End Sub

	Private Sub BtnClearContact_Click(sender As Object, e As EventArgs)
		ContactsList.Items.Clear()
		_xmlContact.WriteContacts(ContactsList)
	End Sub

    Private Sub UpdateContact()

        For i As Integer = 0 To ContactsList.Items.Count - 1
            Dim SipUri As String = ContactsList.Items(i).SubItems(0).Text
            Dim subject As String = "Hello"
            Dim subscribeId As Integer = Integer.Parse(ContactsList.Items(i).SubItems(4).Text)
            If ContactsList.Items(i).SubItems(2).Text = "subscribed" Then
                _sdkLib.presenceSubscribe(SipUri, subject)
            End If

            Dim statusText As String = txtStatus.Text

            If RadioButton1.Checked Then
                If ContactsList.Items(i).SubItems(3).Text = "Accepted" AndAlso subscribeId <> -1 Then
                    _sdkLib.setPresenceStatus(subscribeId, statusText)
                End If
            Else
                If i = 0 Then
                    _sdkLib.setPresenceStatus(0, "Offline")
                End If
            End If
        Next
    End Sub

    Private Sub BtnUpdateContact_Click(sender As Object, e As EventArgs)
		UpdateContact()
	End Sub

	Private Sub BtnAddContact_Click(sender As Object, e As EventArgs)
        If _SIPLogined = False Then
            Return
        End If

        Dim Contact As String = txtContact.Text

        If Contact.Length <= 0 Then
            Return
        End If

        If (Contact.IndexOf("sip:") = -1 Or Contact.IndexOf("@") = -1) Then
            MessageBox.Show("The contact name must likes: sip:username@sip.portsip.com")
            Return
        End If

        Dim subject As String = "Hello"
        _sdkLib.presenceSubscribe(Contact, subject)


        For i As Integer = 0 To ContactsList.Items.Count - 1
			Dim SipUri As String = ContactsList.Items(i).SubItems(0).Text
			If SipUri = Contact Then
				ContactsList.Items(i).SubItems(2).Text = "subscribed"
				Return
			End If
		Next

		Dim Li As New ListViewItem()
		Li.Text = Contact
		Li.SubItems.Add("offLine")
		Li.SubItems.Add("subscribed")
		Li.SubItems.Add("")
		Li.SubItems.Add("0")
		ContactsList.Items.Add(Li)
		_xmlContact.WriteContacts(ContactsList)
	End Sub

	Private Sub BtnSetStatus_Click(sender As Object, e As EventArgs)
        If _SIPLogined = False Then
            Return
        End If

        Dim statusText As String = txtStatus.Text

        If RadioButton2.Checked Then
            _sdkLib.setPresenceStatus(0, statusText)
            Return
        End If

        For i As Integer = 0 To ContactsList.Items.Count - 1
			Dim SipUri As String = ContactsList.Items(i).SubItems(0).Text
			Dim subscribeId As Integer = Integer.Parse(ContactsList.Items(i).SubItems(4).Text)


            If ContactsList.Items(i).SubItems(3).Text = "Accepted" AndAlso subscribeId <> -1 Then
                _sdkLib.setPresenceStatus(subscribeId, statusText)
            End If
		Next
	End Sub

	Private Sub BtnSend_Click(sender As Object, e As EventArgs)
		If _SIPLogined = False Then
			Return
		End If

		If txtMessage.Text.Length <= 0 OrElse txtSendto.Text.Length <= 0 Then
			Return
		End If
		Dim sendTo As String = txtSendto.Text
		Dim message As String = txtMessage.Text

        Dim rt As Long = _sdkLib.sendOutOfDialogMessage(sendTo, "text", "plain", False, GetBytes(message), GetBytes(message).Length)

		If rt <= 0 Then
				' The message is sending, the rt is message ID, you can save it and use it to identify which message is success or failure
				' in onSendOutOutOfDialogMessageSuccess/onSendOutOutOfDialogMessageFailure events.
		Else
		End If
	End Sub

	Private Sub linkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
		System.Diagnostics.Process.Start("http://portsip.com/portsip-pbx")
	End Sub

	Private Sub linkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
		System.Diagnostics.Process.Start("mailto:sales@portsip.com")
	End Sub


    '''///////////////////////////////////////////////////////////////////////////////////////////////////////////
    '''///////////////////////////////////////////////////////////////////////////////////////////////////////////

    ''' <summary>
    '''  With below all onXXX functions, you MUST use the Invoke/BeginInvoke method if you want
    '''  modify any control on the Forms.
    '''  More details please visit: http://msdn.microsoft.com/en-us/library/ms171728.aspx
    '''  The Invoke method is recommended.
    '''  
    '''  if you don't like Invoke/BeginInvoke method, then  you can add this line to Form_Load:
    '''  Control.CheckForIllegalCrossThreadCalls = false;
    '''  This requires .NET 2.0 or higher
    ''' 
    ''' </summary>
    ''' 

    Public Function onRegisterSuccess(callbackIndex As Int32, callbackObject As Int32, statusText As [String], statusCode As Int32, sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onRegisterSuccess
        ' Use the Invoke method to modify the control.
        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add("Registration succeeded")))

        _SIPLogined = True

        Return 0
    End Function


    Public Function onRegisterFailure(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal statusText As [String], ByVal statusCode As Int32, sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onRegisterFailure
        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add("Registration failure")))

        _SIPLogined = False

        Return 0
    End Function

    Public Function onInviteIncoming(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal callerDisplayName As [String], ByVal caller As [String], ByVal calleeDisplayName As [String],
     ByVal callee As [String], ByVal audioCodecNames As [String], ByVal videoCodecNames As [String],
     ByVal existsAudio As [Boolean], ByVal existsVideo As [Boolean], ByVal sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onInviteIncoming


        Return 0

    End Function

    Public Function onInviteTrying(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onInviteTrying

        Return 0
    End Function


    Public Function onInviteSessionProgress(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal audioCodecNames As [String], ByVal videoCodecNames As [String], ByVal existsEarlyMedia As [Boolean],
     ByVal existsAudio As [Boolean], ByVal existsVideo As [Boolean], ByVal sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onInviteSessionProgress

        Return 0
    End Function

    Public Function onInviteRinging(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32,
                                    ByVal statusText As [String], ByVal statusCode As Int32, ByVal sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onInviteRinging

        Return 0
    End Function


    Public Function onInviteAnswered(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal callerDisplayName As [String], ByVal caller As [String], ByVal calleeDisplayName As [String],
     ByVal callee As [String], ByVal audioCodecNames As [String], ByVal videoCodecNames As [String], ByVal existsAudio As [Boolean], ByVal existsVideo As [Boolean], ByVal sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onInviteAnswered

        Return 0
    End Function


    Public Function onInviteFailure(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal reason As [String], ByVal code As Int32, ByVal sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onInviteFailure

        Return 0
    End Function


    Public Function onInviteUpdated(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal audioCodecNames As [String], ByVal videoCodecNames As [String], ByVal existsAudio As [Boolean],
     ByVal existsVideo As [Boolean], ByVal sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onInviteUpdated


        Return 0
    End Function


    Public Function onInviteConnected(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onInviteConnected

        Return 0
    End Function


    Public Function onInviteBeginingForward(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal forwardTo As [String]) As Int32 Implements SIPCallbackEvents.onInviteBeginingForward

        Return 0
    End Function


    Public Function onInviteClosed(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onInviteClosed


        Return 0
    End Function

    Public Function onDialogStateUpdated(callbackIndex As Int32, callbackObject As Int32, BLFMonitoredUri As [String], BLFDialogState As [String], BLFDialogId As [String], BLFDialogDirection As [String]) As Int32 Implements SIPCallbackEvents.onDialogStateUpdated

        Return 0
    End Function

    Public Function onRemoteHold(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onRemoteHold

        Return 0
    End Function


    Public Function onRemoteUnHold(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal audioCodecNames As [String], ByVal videoCodecNames As [String], ByVal existsAudio As [Boolean], _
     ByVal existsVideo As [Boolean]) As Int32 Implements SIPCallbackEvents.onRemoteUnHold

        Return 0
    End Function


    Public Function onReceivedRefer(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal referId As Int32, ByVal [to] As [String], ByVal from As [String],
     ByVal referSipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onReceivedRefer

        Return 0
    End Function


    Public Function onReferAccepted(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onReferAccepted
        Return 0
    End Function



    Public Function onReferRejected(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal reason As [String], ByVal code As Int32) As Int32 Implements SIPCallbackEvents.onReferRejected

        Return 0
    End Function


    Public Function onTransferTrying(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onTransferTrying
        Return 0
    End Function

    Public Function onTransferRinging(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onTransferRinging
        Return 0
    End Function



    Public Function onACTVTransferSuccess(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onACTVTransferSuccess
        Return 0
    End Function


    Public Function onACTVTransferFailure(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal reason As [String], ByVal code As Int32) As Int32 Implements SIPCallbackEvents.onACTVTransferFailure
        Return 0
    End Function

    Public Function onReceivedSignaling(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal signaling As StringBuilder) As Int32 Implements SIPCallbackEvents.onReceivedSignaling
        ' This event will be fired when the SDK received a SIP message
        ' you can use signaling to access the SIP message.

        Return 0
    End Function


    Public Function onSendingSignaling(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal signaling As StringBuilder) As Int32 Implements SIPCallbackEvents.onSendingSignaling
        ' This event will be fired when the SDK sent a SIP message
        ' you can use signaling to access the SIP message.

        Return 0
    End Function




    Public Function onWaitingVoiceMessage(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal messageAccount As [String], ByVal urgentNewMessageCount As Int32, ByVal urgentOldMessageCount As Int32, ByVal newMessageCount As Int32, _
     ByVal oldMessageCount As Int32) As Int32 Implements SIPCallbackEvents.onWaitingVoiceMessage

        Dim Text As String = messageAccount
        Text += " has voice message."


        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        ' You can use these parameters to check the voice message count

        '  urgentNewMessageCount;
        '  urgentOldMessageCount;
        '  newMessageCount;
        '  oldMessageCount;

        Return 0
    End Function


    Public Function onWaitingFaxMessage(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal messageAccount As [String], ByVal urgentNewMessageCount As Int32, ByVal urgentOldMessageCount As Int32, ByVal newMessageCount As Int32, _
     ByVal oldMessageCount As Int32) As Int32 Implements SIPCallbackEvents.onWaitingFaxMessage
        Dim Text As String = messageAccount
        Text += " has FAX message."


        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))


        ' You can use these parameters to check the FAX message count

        '  urgentNewMessageCount;
        '  urgentOldMessageCount;
        '  newMessageCount;
        '  oldMessageCount;

        Return 0
    End Function


	Public Function onRecvDtmfTone(callbackIndex As Int32, callbackObject As Int32, sessionId As Int32, tone As Int32) As Int32 Implements SIPCallbackEvents.onRecvDtmfTone

		Return 0
	End Function


	Public Function onPresenceRecvSubscribe(callbackIndex As Int32, callbackObject As Int32, subscribeId As Int32, fromDisplayName As [String], from As [String], subject As [String]) As Int32 Implements SIPCallbackEvents.onPresenceRecvSubscribe
        Dim fromSipUri As String = from
        If (from.IndexOf("sip:") = -1) Then
            fromSipUri = "sip:" & from
        End If
        For i As Integer = 0 To ContactsList.Items.Count - 1
			Dim SipUri As String = ContactsList.Items(i).SubItems(0).Text

			If SipUri = fromSipUri Then
				If ContactsList.Items(i).SubItems(3).Text = "Blocked" Then
					_sdkLib.presenceRejectSubscribe(subscribeId)
				ElseIf ContactsList.Items(i).SubItems(3).Text = "Accepted" Then
					Dim nOldSubscribID As Integer = Integer.Parse(ContactsList.Items(i).SubItems(4).Text)
					ContactsList.Items(i).SubItems(4).Text = subscribeId.ToString()
					_sdkLib.presenceAcceptSubscribe(subscribeId)
                    Dim status As String = "Available"

                    If RadioButton1.Checked Then
                        _sdkLib.setPresenceStatus(subscribeId, status)
                    Else
                        If i = 0 Then
                            _sdkLib.setPresenceStatus(0, status)
                        End If
                    End If

                    ContactsList.Items(i).SubItems(3).Text = "Accepted"

					If ContactsList.Items(i).SubItems(2).Text = "subscribed" AndAlso nOldSubscribID >= 0 Then
                        _sdkLib.presenceSubscribe(fromSipUri, subject)
                    End If
				Else
					Dim AddContactsDlg1 As New Form2()

					AddContactsDlg1.SetContactName(from)

					AddContactsDlg1.ShowDialog()

					If AddContactsDlg1.GetAccept() = True Then
						_sdkLib.presenceAcceptSubscribe(subscribeId)
						ContactsList.Items(i).SubItems(4).Text = subscribeId.ToString()
						ContactsList.Items(i).SubItems(3).Text = "Accepted"
                        Dim status As String = "Available"

                        If RadioButton1.Checked Then
                            _sdkLib.setPresenceStatus(subscribeId, status)
                        Else
                            If i = 0 Then
                                _sdkLib.setPresenceStatus(0, status)
                            End If
                        End If

                        _xmlContact.WriteContacts(ContactsList)
					Else
						ContactsList.Items(i).SubItems(3).Text = "Blocked"
						ContactsList.Items(i).SubItems(4).Text = "0"

						_sdkLib.presenceRejectSubscribe(subscribeId)
						_xmlContact.WriteContacts(ContactsList)
					End If
				End If
				Return 0
			End If
		Next


		Dim AddContactsDlg As New Form2()

		Dim fromContact As String = fromDisplayName
		fromContact += " <"
		fromContact += from
		fromContact += ">"
		AddContactsDlg.SetContactName(fromContact)
		AddContactsDlg.ShowDialog()

		If AddContactsDlg.GetAccept() = True Then
			Dim Li As New ListViewItem()
			Li.Text = fromSipUri
			Li.SubItems.Add("onLine")
			Li.SubItems.Add("")
			Li.SubItems.Add("Accepted")
			Li.SubItems.Add(subscribeId.ToString())
			ContactsList.Items.Add(Li)

			_sdkLib.presenceAcceptSubscribe(subscribeId)
            Dim status As String = "Available"

            If RadioButton1.Checked Then
                _sdkLib.setPresenceStatus(subscribeId, status)
            Else
                _sdkLib.setPresenceStatus(0, status)
            End If
        Else
			Dim Li As New ListViewItem()
			Li.Text = fromSipUri
			Li.SubItems.Add("offLine")
			Li.SubItems.Add("")
			Li.SubItems.Add("Blocked")
			Li.SubItems.Add("0")
			ContactsList.Items.Add(Li)

			_sdkLib.presenceRejectSubscribe(subscribeId)
		End If
		_xmlContact.WriteContacts(ContactsList)

		Return 0
	End Function


	Public Function onPresenceOnline(callbackIndex As Int32, callbackObject As Int32, fromDisplayName As [String], from As [String], stateText As [String]) As Int32 Implements SIPCallbackEvents.onPresenceOnline
        Dim fromSipUri As String = from
        If (from.IndexOf("sip:") = -1) Then
            fromSipUri = "sip:" & from
        End If

        For i As Integer = 0 To ContactsList.Items.Count - 1
			Dim SipUri As String = ContactsList.Items(i).SubItems(0).Text
			If SipUri = fromSipUri Then
				ContactsList.Items(i).SubItems(1).Text = "onLine:" & stateText
			End If
		Next

		Return 0
	End Function

	Public Function onPresenceOffline(callbackIndex As Int32, callbackObject As Int32, fromDisplayName As [String], from As [String]) As Int32 Implements SIPCallbackEvents.onPresenceOffline
        Dim fromSipUri As String = from
        If (from.IndexOf("sip:") = -1) Then
            fromSipUri = "sip:" & from
        End If

        For i As Integer = 0 To ContactsList.Items.Count - 1
			Dim SipUri As String = ContactsList.Items(i).SubItems(0).Text
			If SipUri = fromSipUri Then
                ContactsList.Items(i).SubItems(1).Text = "Offline"
                ContactsList.Items(i).SubItems(4).Text = "0"
			End If
		Next

		Return 0
	End Function


	Public Function onRecvOptions(callbackIndex As Int32, callbackObject As Int32, optionsMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onRecvOptions
		'       string text = "Received an OPTIONS message: ";
		'       text += optionsMessage.ToString();
		'     MessageBox.Show(text, "Received an OPTIONS message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

		Return 0
	End Function

    Public Function onRecvInfo(callbackIndex As Int32, callbackObject As Int32, infoMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onRecvInfo
        '        string text = "Received a INFO message: ";
        '         text += infoMessage.ToString();

        '       MessageBox.Show(text, "Received a INFO message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        Return 0
    End Function

    Public Function onRecvNotifyOfSubscription(callbackIndex As Int32, callbackObject As Int32, subscribeId As Int32, notifyMsg As StringBuilder, contentData As Byte(), contentLenght As Int32) As Int32 Implements SIPCallbackEvents.onRecvNotifyOfSubscription

        Return 0
    End Function

    Public Function onSubscriptionFailure(callbackIndex As Int32, callbackObject As Int32, subscribeId As Int32, statusCode As Int32) As Int32 Implements SIPCallbackEvents.onSubscriptionFailure
        Return 0
    End Function

    Public Function onSubscriptionTerminated(callbackIndex As Int32, callbackObject As Int32, subscribeId As Int32) As Int32 Implements SIPCallbackEvents.onSubscriptionTerminated

        Return 0
    End Function


    Public Function onRecvMessage(callbackIndex As Int32, callbackObject As Int32, sessionId As Int32, mimeType As [String], subMimeType As [String], messageData As Byte(), _
		messageDataLength As Int32) As Int32 Implements SIPCallbackEvents.onRecvMessage


		Return 0
	End Function


	Public Function onRecvOutOfDialogMessage(callbackIndex As Int32, callbackObject As Int32, fromDisplayName As [String], from As [String], toDisplayName As [String], [to] As [String], _
		mimeType As [String], subMimeType As [String], messageData As Byte(), messageDataLength As Int32) As Int32 Implements SIPCallbackEvents.onRecvOutOfDialogMessage
		Dim text As String = "Received a message(out of dialog) from "
		text += from

		If mimeType = "text" AndAlso subMimeType = "plain" Then
			Dim receivedMsg As String = GetString(messageData)
			MessageBox.Show(receivedMsg, text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		ElseIf mimeType = "application" AndAlso subMimeType = "vnd.3gpp.sms" Then
			' The messageData is binary data

			MessageBox.Show(text, "Received a binary message.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		ElseIf mimeType = "application" AndAlso subMimeType = "vnd.3gpp2.sms" Then
			' The messageData is binary data

			MessageBox.Show(text, "Received a binary message.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If

		Return 0
	End Function

	Public Function onSendMessageSuccess(callbackIndex As Int32, callbackObject As Int32, sessionId As Int32, messageId As Int32) As Int32 Implements SIPCallbackEvents.onSendMessageSuccess
		Return 0
	End Function


	Public Function onSendMessageFailure(callbackIndex As Int32, callbackObject As Int32, sessionId As Int32, messageId As Int32, reason As [String], code As Int32) As Int32 Implements SIPCallbackEvents.onSendMessageFailure

		Return 0
	End Function



	Public Function onSendOutOfDialogMessageSuccess(callbackIndex As Int32, callbackObject As Int32, messageId As Int32, fromDisplayName As [String], from As [String], toDisplayName As [String], _
		[to] As [String]) As Int32 Implements SIPCallbackEvents.onSendOutOfDialogMessageSuccess

		' Use messageId to identify which message is success.
		Return 0
	End Function

	Public Function onSendOutOfDialogMessageFailure(callbackIndex As Int32, callbackObject As Int32, messageId As Int32, fromDisplayName As [String], from As [String], toDisplayName As [String], _
		[to] As [String], reason As [String], code As Int32) As Int32 Implements SIPCallbackEvents.onSendOutOfDialogMessageFailure
		' Use messageId to identify which message is failure.
		Return 0
	End Function


	Public Function onPlayAudioFileFinished(callbackIndex As Int32, callbackObject As Int32, sessionId As Int32, fileName As [String]) As Int32 Implements SIPCallbackEvents.onPlayAudioFileFinished

		Return 0
	End Function

	Public Function onPlayVideoFileFinished(callbackIndex As Int32, callbackObject As Int32, sessionId As Int32) As Int32 Implements SIPCallbackEvents.onPlayVideoFileFinished


		Return 0
	End Function


	Public Function onReceivedRtpPacket(callbackObject As IntPtr, sessionId As Int32, isAudio As [Boolean], RTPPacket As Byte(), packetSize As Int32) As Int32 Implements SIPCallbackEvents.onReceivedRtpPacket
		'
'                !!! IMPORTANT !!!
'
'                Don't call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
'                other code which will spend long time, you should post a message to main thread(main window) or other thread,
'                let the thread to call SDK API functions or other code.
'
'            


		Return 0
	End Function

	Public Function onSendingRtpPacket(callbackObject As IntPtr, sessionId As Int32, isAudio As [Boolean], RTPPacket As Byte(), packetSize As Int32) As Int32 Implements SIPCallbackEvents.onSendingRtpPacket

		'
'                !!! IMPORTANT !!!
'
'                Don't call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
'                other code which will spend long time, you should post a message to main thread(main window) or other thread,
'                let the thread to call SDK API functions or other code.
'
'            

		Return 0
	End Function


	Public Function onAudioRawCallback(callbackObject As IntPtr, sessionId As Int32, callbackType As Int32, <MarshalAs(UnmanagedType.LPArray, SizeParamIndex := 4)> data As Byte(), dataLength As Int32, samplingFreqHz As Int32) As Int32 Implements SIPCallbackEvents.onAudioRawCallback

		'
'                !!! IMPORTANT !!!
'
'                Don't call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
'                other code which will spend long time, you should post a message to main thread(main window) or other thread,
'                let the thread to call SDK API functions or other code.
'
'            


		' The data parameter is audio stream as PCM format, 16bit, Mono.
		' the dataLength parameter is audio steam data length.



		'
		' IMPORTANT: the data length is stored in dataLength parameter!!!
		'

		Dim type As AUDIOSTREAM_CALLBACK_MODE = CType(callbackType, AUDIOSTREAM_CALLBACK_MODE)

				' The callback data is mixed from local record device - microphone
				' The sessionId is CALLBACK_SESSION_ID.PORTSIP_LOCAL_MIX_ID

		If type = AUDIOSTREAM_CALLBACK_MODE.AUDIOSTREAM_LOCAL_MIX Then
				' The callback data is mixed from local record device - microphone
				' The sessionId is CALLBACK_SESSION_ID.PORTSIP_REMOTE_MIX_ID
		ElseIf type = AUDIOSTREAM_CALLBACK_MODE.AUDIOSTREAM_REMOTE_MIX Then
				' The callback data is from local record device of each session, use the sessionId to identifying the session.
		ElseIf type = AUDIOSTREAM_CALLBACK_MODE.AUDIOSTREAM_LOCAL_PER_CHANNEL Then
				' The callback data is received from remote side of each session, use the sessionId to identifying the session.
		ElseIf type = AUDIOSTREAM_CALLBACK_MODE.AUDIOSTREAM_REMOTE_PER_CHANNEL Then
		End If




		Return 0
	End Function


    Public Function onVideoRawCallback(callbackObject As IntPtr, sessionId As Int32, callbackType As Int32, width As Int32, height As Int32, <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=6)> data As Byte(),
        dataLength As Int32) As Int32 Implements SIPCallbackEvents.onVideoRawCallback
        '
        '                !!! IMPORTANT !!!
        '
        '                Don't call any PortSIP SDK API functions in here directly. If you want to call the PortSIP API functions or 
        '                other code which will spend long time, you should post a message to main thread(main window) or other thread,
        '                let the thread to call SDK API functions or other code.
        '
        '                The video data format is YUV420, YV12.
        '            


        '
        ' IMPORTANT: the data length is stored in dataLength parameter!!!
        '

        Dim type As VIDEOSTREAM_CALLBACK_MODE = CType(callbackType, VIDEOSTREAM_CALLBACK_MODE)


        If type = VIDEOSTREAM_CALLBACK_MODE.VIDEOSTREAM_LOCAL Then

        ElseIf type = VIDEOSTREAM_CALLBACK_MODE.VIDEOSTREAM_REMOTE Then
        End If


        Return 0

    End Function
End Class
