Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports SIPSample.PortSIP



Public Partial Class Form1
	Inherits Form
	Implements SIPCallbackEvents

	Private Const MAX_LINES As Integer = 9
	' Maximum lines
	Private Const LINE_BASE As Integer = 1


    Private _CallSessions As Session() = New Session(MAX_LINES - 1) {}

	Private _SIPInited As Boolean = False
	Private _SIPLogined As Boolean = False
	Private _CurrentlyLine As Integer = LINE_BASE


	Private _sdkLib As PortSIPLib


	'''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	'''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	Private Function findSession(sessionId As Integer) As Integer
		Dim index As Integer = -1
		For i As Integer = LINE_BASE To MAX_LINES - 1
			If _CallSessions(i).getSessionId() = sessionId Then
				index = i
				Exit For
			End If
		Next

		Return index
	End Function


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


	Private Sub updatePrackSetting()
		If Not _SIPInited Then
			Return
		End If

		_sdkLib.enableReliableProvisional(checkBoxPRACK.Checked)
	End Sub

    Private Function joinConference(ByVal index As Int32) As Int32
        If _SIPInited = False Then
            Return 0
        End If
        If CheckBoxConf.Checked = False Then
            Return 0
        End If
        _sdkLib.setRemoteVideoWindow(_CallSessions(_CurrentlyLine).getSessionId(), IntPtr.Zero)
        _sdkLib.joinToConference(_CallSessions(index).getSessionId())

        ' We need to unhold the line in conference
        If _CallSessions(index).getSessionState() Then
            _sdkLib.unHold(_CallSessions(index).getSessionId())
            _CallSessions(index).setHoldState(False)
        End If
        Return 0
    End Function



	Private Sub loadDevices()
		If _SIPInited = False Then
			Return
		End If

		Dim num As Integer = _sdkLib.getNumOfPlayoutDevices()
		For i As Integer = 0 To num - 1
			Dim deviceName As New StringBuilder()
			deviceName.Length = 256

			If _sdkLib.getPlayoutDeviceName(i, deviceName, 256) = 0 Then
				ComboBoxSpeakers.Items.Add(deviceName.ToString())
			End If

			ComboBoxSpeakers.SelectedIndex = 0
		Next


		num = _sdkLib.getNumOfRecordingDevices()
		For i As Integer = 0 To num - 1
			Dim deviceName As New StringBuilder()
			deviceName.Length = 256

			If _sdkLib.getRecordingDeviceName(i, deviceName, 256) = 0 Then
				ComboBoxMicrophones.Items.Add(deviceName.ToString())
			End If

			ComboBoxMicrophones.SelectedIndex = 0
		Next


		num = _sdkLib.getNumOfVideoCaptureDevices()
		For i As Integer = 0 To num - 1
			Dim uniqueId As New StringBuilder()
			uniqueId.Length = 256
			Dim deviceName As New StringBuilder()
			deviceName.Length = 256

			If _sdkLib.getVideoCaptureDeviceName(i, uniqueId, 256, deviceName, 256) = 0 Then
				ComboBoxCameras.Items.Add(deviceName.ToString())
			End If

			ComboBoxCameras.SelectedIndex = 0
		Next


		Dim volume As Integer = _sdkLib.getSpeakerVolume()
		TrackBarSpeaker.SetRange(0, 255)
		TrackBarSpeaker.Value = volume

		volume = _sdkLib.getMicVolume()
		TrackBarMicrophone.SetRange(0, 255)
		TrackBarMicrophone.Value = volume

	End Sub


	Private Sub InitSettings()
		If _SIPInited = False Then
			Return
		End If

		If checkBoxAEC.Checked = True Then
			_sdkLib.enableAEC(EC_MODES.EC_DEFAULT)
		Else
			_sdkLib.enableAEC(EC_MODES.EC_NONE)
		End If

		If checkBoxVAD.Checked = True Then
			_sdkLib.enableVAD(True)
		Else
			_sdkLib.enableVAD(False)
		End If

		If checkBoxCNG.Checked = True Then
			_sdkLib.enableCNG(True)
		Else
			_sdkLib.enableCNG(False)
		End If

		If checkBoxAGC.Checked = True Then
			_sdkLib.enableAGC(AGC_MODES.AGC_DEFAULT)
		Else
            _sdkLib.enableAGC(AGC_MODES.AGC_NONE)
		End If

		If checkBoxANS.Checked = True Then
			_sdkLib.enableANS(NS_MODES.NS_DEFAULT)
		Else
			_sdkLib.enableANS(NS_MODES.NS_NONE)
        End If

        _sdkLib.setVideoNackStatus(checkBoxNACK.Checked)

		_sdkLib.setDoNotDisturb(CheckBoxDND.Checked)
	End Sub


	Private Sub SetSRTPType()
		If _SIPInited = False Then
			Return
		End If

		Dim SRTPPolicy As SRTP_POLICY = SRTP_POLICY.SRTP_POLICY_NONE

		Select Case ComboBoxSRTP.SelectedIndex
			Case 0
				SRTPPolicy = SRTP_POLICY.SRTP_POLICY_NONE
				Exit Select

			Case 1
				SRTPPolicy = SRTP_POLICY.SRTP_POLICY_PREFER
				Exit Select

			Case 2
				SRTPPolicy = SRTP_POLICY.SRTP_POLICY_FORCE
				Exit Select
		End Select

        _sdkLib.setSrtpPolicy(SRTPPolicy, True)
    End Sub


	Private Sub SetVideoResolution()
		If _SIPInited = False Then
			Return
		End If

        Dim width As Int32 = 352
        Dim height As Int32 = 288

		Select Case ComboBoxVideoResolution.SelectedIndex
			Case 0
                width = 176
                height = 144
				Exit Select
			Case 1
                width = 352
                height = 288
				Exit Select
			Case 2
                width = 640
                height = 480
				Exit Select
			Case 3
                width = 800
                height = 600
				Exit Select
			Case 4
                width = 1024
                height = 768
				Exit Select
			Case 5
                width = 1280
                height = 720
				Exit Select
			Case 6
                width = 320
                height = 240
				Exit Select
		End Select

		_sdkLib.setVideoResolution(width, height)
	End Sub


	Private Sub SetVideoQuality()
		If _SIPInited = False Then
			Return
		End If

        _sdkLib.setVideoBitrate(_CallSessions(_CurrentlyLine).getSessionId(), TrackBarVideoQuality.Value)
	End Sub


	' Default we just using PCMU, PCMA, and G.279
	Private Sub InitDefaultAudioCodecs()
		If _SIPInited = False Then
			Return
		End If


		_sdkLib.clearAudioCodec()


		' Default we just using PCMU, PCMA, G729
		_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_PCMU)
		_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_PCMA)
		_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_G729)

		_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_DTMF)
		' for DTMF as RTP Event - RFC2833
	End Sub




	Private Sub UpdateAudioCodecs()
		If _SIPInited = False Then
			Return
		End If

		_sdkLib.clearAudioCodec()

		If checkBoxPCMU.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_PCMU)
		End If


		If checkBoxPCMA.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_PCMA)
		End If


		If checkBoxG729.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_G729)
		End If


		If checkBoxILBC.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_ILBC)
		End If


		If checkBoxGSM.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_GSM)
		End If


		If checkBoxAMR.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_AMR)
		End If

		If CheckBoxG722.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_G722)
		End If

		If CheckBoxSpeex.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_SPEEX)
		End If

		If CheckBoxAMRwb.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_AMRWB)
		End If

		If CheckBoxSpeexWB.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_SPEEXWB)
		End If

		If CheckBoxG7221.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_G7221)
		End If

		If checkBoxOPUS.Checked = True Then
			_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_OPUS)
		End If

		_sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_DTMF)

	End Sub


	Private Sub UpdateVideoCodecs()
		If _SIPInited = False Then
			Return
		End If

		_sdkLib.clearVideoCodec()

		If checkBoxH263.Checked = True Then
			_sdkLib.addVideoCodec(VIDEOCODEC_TYPE.VIDEO_CODEC_H263)
		End If

		If checkBoxH2631998.Checked = True Then
			_sdkLib.addVideoCodec(VIDEOCODEC_TYPE.VIDEO_CODEC_H263_1998)
		End If

		If checkBoxH264.Checked = True Then
			_sdkLib.addVideoCodec(VIDEOCODEC_TYPE.VIDEO_CODEC_H264)
		End If

		If checkBoxVP8.Checked = True Then
			_sdkLib.addVideoCodec(VIDEOCODEC_TYPE.VIDEO_CODEC_VP8)
        End If

        If CheckBoxVP9.Checked = True Then
            _sdkLib.addVideoCodec(VIDEOCODEC_TYPE.VIDEO_CODEC_VP9)
        End If
	End Sub


	Public Sub New()
		InitializeComponent()
	End Sub


	Private Sub deRegisterFromServer()
		If _SIPInited = False Then
			Return
		End If

		For i As Integer = LINE_BASE To MAX_LINES - 1
			If _CallSessions(i).getRecvCallState() = True Then
				_sdkLib.rejectCall(_CallSessions(i).getSessionId(), 486)
			ElseIf _CallSessions(i).getSessionState() = True Then
				_sdkLib.hangUp(_CallSessions(i).getSessionId())
			End If

			_CallSessions(i).reset()
		Next

        If _SIPLogined Then
            _sdkLib.removeUser()
            _sdkLib.unRegisterServer()
            _SIPLogined = False
        End If


		If _SIPInited Then
			_sdkLib.unInitialize()
			_sdkLib.releaseCallbackHandlers()

			_SIPInited = False
		End If


		ListBoxSIPLog.Items.Clear()

		ComboBoxLines.SelectedIndex = 0
		_CurrentlyLine = LINE_BASE


		ComboBoxSpeakers.Items.Clear()
		ComboBoxMicrophones.Items.Clear()
		ComboBoxCameras.Items.Clear()
	End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        ' Create the call sessions array, allows maximum 500 lines,
        ' but we just use 8 lines with this sample, we need a class to save the call sessions information

        Dim i As Integer = 0
        For i = 0 To MAX_LINES - 1
            _CallSessions(i) = New Session()
            _CallSessions(i).reset()
        Next

        _SIPInited = False
        _SIPLogined = False
        _CurrentlyLine = LINE_BASE


        TrackBarSpeaker.SetRange(0, 255)
        TrackBarSpeaker.Value = 0

        TrackBarMicrophone.SetRange(0, 255)
        TrackBarMicrophone.Value = 0

        ComboBoxTransport.Items.Add("UDP")
        ComboBoxTransport.Items.Add("TLS")
        ComboBoxTransport.Items.Add("TCP")
        ComboBoxTransport.Items.Add("PERS")

        ComboBoxTransport.SelectedIndex = 0

        ComboBoxSRTP.Items.Add("None")
        ComboBoxSRTP.Items.Add("Prefer")
        ComboBoxSRTP.Items.Add("Force")

        ComboBoxSRTP.SelectedIndex = 0


        ComboBoxVideoResolution.Items.Add("QCIF")
        ComboBoxVideoResolution.Items.Add("CIF")
        ComboBoxVideoResolution.Items.Add("VGA")
        ComboBoxVideoResolution.Items.Add("SVGA")
        ComboBoxVideoResolution.Items.Add("XVGA")
        ComboBoxVideoResolution.Items.Add("720P")
        ComboBoxVideoResolution.Items.Add("QVGA")

        ComboBoxVideoResolution.SelectedIndex = 1

        ComboBoxLines.Items.Add("Line-1")
        ComboBoxLines.Items.Add("Line-2")
        ComboBoxLines.Items.Add("Line-3")
        ComboBoxLines.Items.Add("Line-4")
        ComboBoxLines.Items.Add("Line-5")
        ComboBoxLines.Items.Add("Line-6")
        ComboBoxLines.Items.Add("Line-7")
        ComboBoxLines.Items.Add("Line-8")


        ComboBoxLines.SelectedIndex = 0
    End Sub




    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        deRegisterFromServer()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If _SIPInited = True Then
            MessageBox.Show("You are already logged in.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        If TextBoxUserName.Text.Length <= 0 Then
            MessageBox.Show("The user name does not allows empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        If TextBoxPassword.Text.Length <= 0 Then
            MessageBox.Show("The password does not allows empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If TextBoxServer.Text.Length <= 0 Then
            MessageBox.Show("The SIP server does not allows empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim SIPServerPort As Integer = 0
        If TextBoxServerPort.Text.Length > 0 Then
            SIPServerPort = Integer.Parse(TextBoxServerPort.Text)
            If SIPServerPort > 65535 OrElse SIPServerPort <= 0 Then
                MessageBox.Show("The SIP server port is out of range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                Return
            End If
        End If


        Dim StunServerPort As Integer = 0
        If TextBoxStunPort.Text.Length > 0 Then
            StunServerPort = Integer.Parse(TextBoxStunPort.Text)
            If StunServerPort > 65535 OrElse StunServerPort <= 0 Then
                MessageBox.Show("The Stun server port is out of range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                Return
            End If
        End If

        ' Generate the random port for SIP
        Dim rd As New Random()
        Dim LocalSIPPort As Integer = rd.[Next](1000, 5000) + 4000

        Dim transport As TRANSPORT_TYPE = TRANSPORT_TYPE.TRANSPORT_UDP
        Select Case ComboBoxTransport.SelectedIndex
            Case 0
                transport = TRANSPORT_TYPE.TRANSPORT_UDP
                Exit Select

            Case 1
                transport = TRANSPORT_TYPE.TRANSPORT_TLS
                Exit Select

            Case 2
                transport = TRANSPORT_TYPE.TRANSPORT_TCP
                Exit Select

            Case 3
                transport = TRANSPORT_TYPE.TRANSPORT_PERS
                Exit Select
        End Select


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
        Dim stunServer As String = TextBoxStunServer.Text

        ' Initialize the SDK
        ' Use 0.0.0.0 for local IP then the SDK will choose an available local IP automatically.
        ' You also can specify a certain local IP to instead of "0.0.0.0", more details please read the SDK User Manual
        Dim rt As Int32 = _sdkLib.initialize(transport, "0.0.0.0", LocalSIPPort, PORTSIP_LOG_LEVEL.PORTSIP_LOG_NONE, logFilePath, MAX_LINES, agent, 0, 0, "\", "", False)

        If rt <> 0 Then
            _sdkLib.releaseCallbackHandlers()
            MessageBox.Show("Initialize failure.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        ListBoxSIPLog.Items.Add("Initialized.")
        _SIPInited = True

        loadDevices()

        Dim userName As String = TextBoxUserName.Text
        Dim password As String = TextBoxPassword.Text
        Dim sipDomain As String = TextBoxUserDomain.Text
        Dim SIPServer As String = TextBoxServer.Text
        Dim displayName As String = TextBoxDisplayName.Text
        Dim authName As String = TextBoxAuthName.Text

        Dim outboundServerPort As Integer = 0
        Dim outboundServer As String = ""

        ' Example: set the codec parameter for AMR-WB
        '
        '             
        '            _sdkLib.setAudioCodecParameter(AUDIOCODEC_TYPE.AUDIOCODEC_AMRWB, "mode-set=0; octet-align=0; robust-sorting=0");
        '             
        '   



        ' Set the SIP user information
        ' Use 0.0.0.0 for local IP then the SDK will choose an available local IP automatically.
        'You also can specify a certain local IP to instead of "0.0.0.0", more details please read the SDK User Manual
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


        SetSRTPType()


        Dim licenseKey As String = "PORTSIP_TEST_LICENSE"
        rt = _sdkLib.setLicenseKey(licenseKey)
        If rt = PortSIP_Errors.ECoreTrialVersionLicenseKey Then
            MessageBox.Show("This sample was built base on evaluation PortSIP VoIP SDK, which allows only three minutes conversation. The conversation will be cut off automatically after three minutes, then you can't hearing anything. Feel free contact us at: sales@portsip.com to purchase the official version.")
        End If

        If rt = PortSIP_Errors.ECoreWrongLicenseKey Then
            MessageBox.Show("The wrong license key was detected, please check with sales@portsip.com or support@portsip.com")
        End If

        _sdkLib.setLocalVideoWindow(localVideoPanel.Handle)

        SetVideoResolution()
        SetVideoQuality()

        UpdateAudioCodecs()
        UpdateVideoCodecs()

        InitSettings()
        updatePrackSetting()

        If checkBoxNeedRegister.Checked Then
            rt = _sdkLib.registerServer(120, 0)
            If rt <> 0 Then
                _sdkLib.removeUser()
                _SIPInited = False
                _sdkLib.unInitialize()
                _sdkLib.releaseCallbackHandlers()

                ListBoxSIPLog.Items.Clear()

                MessageBox.Show("register to server failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


            ListBoxSIPLog.Items.Add("Registering...")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        If _SIPInited = False Then
            Return
        End If

        deRegisterFromServer()
    End Sub

    Private Sub ComboBoxLines_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxLines.SelectedIndexChanged
        If _SIPInited = False OrElse (checkBoxNeedRegister.Checked AndAlso (_SIPLogined = False)) Then
            ComboBoxLines.SelectedIndex = 0
            Return
        End If

        If _CurrentlyLine = (ComboBoxLines.SelectedIndex + LINE_BASE) Then
            Return
        End If

        If CheckBoxConf.Checked = True Then
            _CurrentlyLine = ComboBoxLines.SelectedIndex + LINE_BASE
            Return
        End If

        ' To switch the line, must hold currently line first
        If _CallSessions(_CurrentlyLine).getSessionState() = True AndAlso _CallSessions(_CurrentlyLine).getHoldState() = False Then
            _sdkLib.hold(_CallSessions(_CurrentlyLine).getSessionId())
            _sdkLib.setRemoteVideoWindow(_CallSessions(_CurrentlyLine).getSessionId(), IntPtr.Zero)
            _CallSessions(_CurrentlyLine).setHoldState(True)

            Dim Text As String = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": Hold"
            ListBoxSIPLog.Items.Add(Text)
        End If



        _CurrentlyLine = ComboBoxLines.SelectedIndex + LINE_BASE


        ' If target line was in hold state, then un-hold it
        If _CallSessions(_CurrentlyLine).getSessionState() = True AndAlso _CallSessions(_CurrentlyLine).getHoldState() = True Then
            _sdkLib.unHold(_CallSessions(_CurrentlyLine).getSessionId())
            _sdkLib.setRemoteVideoWindow(_CallSessions(_CurrentlyLine).getSessionId(), remoteVideoPanel.Handle)
            _CallSessions(_CurrentlyLine).setHoldState(False)

            Dim Text As String = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": UnHold - call established"
            ListBoxSIPLog.Items.Add(Text)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "1"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 1, 160, True)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "2"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 2, 160, True)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "3"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 3, 160, True)
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button8.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "4"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 4, 160, True)
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button7.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "5"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 5, 160, True)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "6"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 6, 160, True)
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button11.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "7"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 7, 160, True)
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button10.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "8"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 8, 160, True)
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button9.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "9"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 9, 160, True)
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button14.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "*"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 10, 160, True)
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button13.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "0"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 0, 160, True)
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button12.Click
        TextBoxPhoneNumber.Text = TextBoxPhoneNumber.Text & "#"
        If _SIPInited = True AndAlso _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.sendDtmf(_CallSessions(_CurrentlyLine).getSessionId(), DTMF_METHOD.DTMF_RFC2833, 11, 160, True)
        End If
    End Sub

    Private Sub ButtonDial_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonDial.Click
        If _SIPInited = False OrElse (checkBoxNeedRegister.Checked AndAlso (_SIPLogined = False)) Then
            Return
        End If
        If TextBoxPhoneNumber.Text.Length <= 0 Then
            MessageBox.Show("The phone number is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If _CallSessions(_CurrentlyLine).getSessionState() = True OrElse _CallSessions(_CurrentlyLine).getRecvCallState() = True Then
            MessageBox.Show("Current line is busy now, please switch a line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        Dim callTo As String = TextBoxPhoneNumber.Text

        UpdateAudioCodecs()
        UpdateVideoCodecs()

        ' Ensure the we have been added one audio codec at least
        If _sdkLib.isAudioCodecEmpty() = True Then
            InitDefaultAudioCodecs()
        End If

        '  Usually for 3PCC need to make call without SDP
        Dim hasSdp As [Boolean] = True
        If CheckBoxSDP.Checked = True Then
            hasSdp = False
        End If

        _sdkLib.setAudioDeviceId(ComboBoxMicrophones.SelectedIndex, ComboBoxSpeakers.SelectedIndex)

        Dim sessionId As Integer = _sdkLib.[call](callTo, hasSdp, checkBoxMakeVideo.Checked)
        If sessionId <= 0 Then
            ListBoxSIPLog.Items.Add("Call failure")
            Return
        End If

        _sdkLib.setRemoteVideoWindow(sessionId, remoteVideoPanel.Handle)

        _CallSessions(_CurrentlyLine).setSessionId(sessionId)
        _CallSessions(_CurrentlyLine).setSessionState(True)

        Dim Text As String = "Line " & _CurrentlyLine.ToString()
        Text = Text & ": Calling..."
        ListBoxSIPLog.Items.Add(Text)
    End Sub

    Private Sub ButtonHangUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonHangUp.Click
        If _SIPInited = False OrElse (checkBoxNeedRegister.Checked AndAlso (_SIPLogined = False)) Then
            Return
        End If

        If _CallSessions(_CurrentlyLine).getRecvCallState() = True Then
            _sdkLib.rejectCall(_CallSessions(_CurrentlyLine).getSessionId(), 486)
            _CallSessions(_CurrentlyLine).reset()

            Dim Text As String = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": Rejected call"
            ListBoxSIPLog.Items.Add(Text)

            Return
        End If

        If _CallSessions(_CurrentlyLine).getSessionState() = True Then
            _sdkLib.hangUp(_CallSessions(_CurrentlyLine).getSessionId())
            _CallSessions(_CurrentlyLine).reset()

            Dim Text As String = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": Hang up"
            ListBoxSIPLog.Items.Add(Text)
        End If
    End Sub

    Private Sub ButtonAnswer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAnswer.Click
        If _SIPInited = False OrElse (checkBoxNeedRegister.Checked AndAlso (_SIPLogined = False)) Then
            Return
        End If

        If _CallSessions(_CurrentlyLine).getRecvCallState() = False Then
            MessageBox.Show("No incoming call on current line, please switch a line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        _CallSessions(_CurrentlyLine).setRecvCallState(False)
        _CallSessions(_CurrentlyLine).setSessionState(True)

        _sdkLib.setRemoteVideoWindow(_CallSessions(_CurrentlyLine).getSessionId(), remoteVideoPanel.Handle)

        Dim rt As Integer = _sdkLib.answerCall(_CallSessions(_CurrentlyLine).getSessionId(), checkBoxAnswerVideo.Checked)
        If rt = 0 Then
            Dim Text As String = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": Call established"
            ListBoxSIPLog.Items.Add(Text)


            joinConference(_CurrentlyLine)
        Else
            _CallSessions(_CurrentlyLine).reset()

            Dim Text As String = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": failed to answer call !"
            ListBoxSIPLog.Items.Add(Text)
        End If

    End Sub

    Private Sub ButtonReject_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonReject.Click
        If _SIPInited = False OrElse (checkBoxNeedRegister.Checked AndAlso (_SIPLogined = False)) Then
            Return
        End If

        If _CallSessions(_CurrentlyLine).getRecvCallState() = True Then
            _sdkLib.rejectCall(_CallSessions(_CurrentlyLine).getSessionId(), 486)
            _CallSessions(_CurrentlyLine).reset()

            Dim Text As String = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": Rejected call"
            ListBoxSIPLog.Items.Add(Text)

            Return
        End If
    End Sub

    Private Sub ButtonHold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonHold.Click
        If _SIPInited = False OrElse (checkBoxNeedRegister.Checked AndAlso (_SIPLogined = False)) Then
            Return
        End If

        If _CallSessions(_CurrentlyLine).getSessionState() = False OrElse _CallSessions(_CurrentlyLine).getHoldState() = True Then
            Return
        End If


        Dim Text As String
        Dim rt As Integer = _sdkLib.hold(_CallSessions(_CurrentlyLine).getSessionId())
        If rt <> 0 Then
            Text = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": hold failure."
            ListBoxSIPLog.Items.Add(Text)

            Return
        End If


        _CallSessions(_CurrentlyLine).setHoldState(True)

        Text = "Line " & _CurrentlyLine.ToString()
        Text = Text & ": hold"
        ListBoxSIPLog.Items.Add(Text)
    End Sub

    Private Sub Button16_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button16.Click
        If _SIPInited = False OrElse (checkBoxNeedRegister.Checked AndAlso (_SIPLogined = False)) Then
            Return
        End If

        If _CallSessions(_CurrentlyLine).getSessionState() = False OrElse _CallSessions(_CurrentlyLine).getHoldState() = False Then
            Return
        End If

        Dim Text As String
        Dim rt As Integer = _sdkLib.unHold(_CallSessions(_CurrentlyLine).getSessionId())
        If rt <> 0 Then
            _CallSessions(_CurrentlyLine).setHoldState(False)

            Text = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": Un-Hold Failure."
            ListBoxSIPLog.Items.Add(Text)

            Return
        End If

        _CallSessions(_CurrentlyLine).setHoldState(False)

        Text = "Line " & _CurrentlyLine.ToString()
        Text = Text & ": Un-Hold"
        ListBoxSIPLog.Items.Add(Text)
    End Sub

    Private Sub ButtonTransfer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonTransfer.Click
        If _SIPInited = False OrElse (checkBoxNeedRegister.Checked AndAlso (_SIPLogined = False)) Then
            Return
        End If

        If _CallSessions(_CurrentlyLine).getSessionState() = False Then
            MessageBox.Show("Need to make the call established first", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim TransferDlg As New TransferCallForm()
        If TransferDlg.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        Dim referTo As String = TransferDlg.GetTransferNumber()
        If referTo.Length <= 0 Then
            MessageBox.Show("The transfer number is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim rt As Integer = _sdkLib.refer(_CallSessions(_CurrentlyLine).getSessionId(), referTo)
        If rt <> 0 Then
            Dim Text As String = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": failed to Transfer"
            ListBoxSIPLog.Items.Add(Text)
        Else
            Dim Text As String = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": Transferring"
            ListBoxSIPLog.Items.Add(Text)
        End If
    End Sub

    Private Sub button24_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button24.Click
        If _SIPInited = False OrElse (checkBoxNeedRegister.Checked AndAlso (_SIPLogined = False)) Then
            Return
        End If

        If _CallSessions(_CurrentlyLine).getSessionState() = False Then
            MessageBox.Show("Need to make the call established first", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim TransferDlg As New TransferCallForm()
        If TransferDlg.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        Dim referTo As String = TransferDlg.GetTransferNumber()

        If referTo.Length <= 0 Then
            MessageBox.Show("The transfer number is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim replaceLine As Integer = TransferDlg.GetReplaceLineNum()
        If replaceLine <= 0 OrElse replaceLine >= MAX_LINES Then
            MessageBox.Show("The replace line out of range", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        If _CallSessions(replaceLine).getSessionState() = False Then
            MessageBox.Show("The replace line does not established yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim rt As Integer = _sdkLib.attendedRefer(_CallSessions(_CurrentlyLine).getSessionId(), _CallSessions(replaceLine).getSessionId(), referTo)

        If rt <> 0 Then
            Dim Text As String = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": failed to Attend transfer"
            ListBoxSIPLog.Items.Add(Text)
        Else
            Dim Text As String = "Line " & _CurrentlyLine.ToString()
            Text = Text & ": Transferring"
            ListBoxSIPLog.Items.Add(Text)
        End If
    End Sub

    Private Sub CheckBoxConf_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxConf.CheckedChanged
        If _SIPInited = False OrElse (checkBoxNeedRegister.Checked AndAlso (_SIPLogined = False)) Then
            CheckBoxConf.Checked = False
            Return
        End If


        Dim width As Int32 = 352
        Dim height As Int32 = 288

        Select Case ComboBoxVideoResolution.SelectedIndex
            Case 0
                width = 176
                height = 144
                Exit Select
            Case 1
                width = 352
                height = 288
                Exit Select
            Case 2
                width = 640
                height = 480
                Exit Select
            Case 3
                width = 800
                height = 600
                Exit Select
            Case 4
                width = 1024
                height = 768
                Exit Select
            Case 5
                width = 1280
                height = 720
                Exit Select
            Case 6
                width = 320
                height = 240
                Exit Select
        End Select


        If CheckBoxConf.Checked = True Then
            Dim rt As Integer = _sdkLib.createVideoConference(remoteVideoPanel.Handle, width, height, False)
            If rt = 0 Then
                ListBoxSIPLog.Items.Add("Make conference succeeded")
                For i As Integer = LINE_BASE To MAX_LINES - 1
                    If _CallSessions(i).getSessionState() = True Then
                        joinConference(i)
                    End If
                Next
            Else
                ListBoxSIPLog.Items.Add("Failed to create conference")
                CheckBoxConf.Checked = False
            End If
        Else
            ' Stop conference
            ' Before stop the conference, MUST place all lines to hold state



            For i As Integer = LINE_BASE To MAX_LINES - 1
                If _CallSessions(i).getSessionState() = True AndAlso _CallSessions(i).getHoldState() = False AndAlso _CurrentlyLine <> i Then

                    ' Hold it 
                    _sdkLib.hold(_CallSessions(i).getSessionId())
                    _CallSessions(i).setHoldState(True)
                End If
            Next

            _sdkLib.destroyConference()

            If _CallSessions(_CurrentlyLine).getSessionState() = True AndAlso _CallSessions(_CurrentlyLine).getHoldState() = False Then
                _sdkLib.setRemoteVideoWindow(_CallSessions(_CurrentlyLine).getSessionId(), remoteVideoPanel.Handle)
            End If
            ListBoxSIPLog.Items.Add("Taken off Conference")
        End If
    End Sub

    Private Sub ButtonLocalVideo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonLocalVideo.Click
        If _SIPInited = False Then
            Return
        End If

        If ButtonLocalVideo.Text = "Local Video" Then
            _sdkLib.displayLocalVideo(True, True)
            ButtonLocalVideo.Text = "Stop Local"
        Else
            _sdkLib.displayLocalVideo(False, False)
            localVideoPanel.Refresh()
            ButtonLocalVideo.Text = "Local Video"
        End If
    End Sub

    Private Sub TrackBarSpeaker_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TrackBarSpeaker.ValueChanged
        If _SIPInited = False Then
            Return
        End If

        _sdkLib.setSpeakerVolume(TrackBarSpeaker.Value)
    End Sub

    Private Sub TrackBarMicrophone_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TrackBarMicrophone.ValueChanged
        If _SIPInited = False Then
            Return
        End If

        _sdkLib.setMicVolume(TrackBarMicrophone.Value)
    End Sub

    Private Sub ComboBoxMicrophones_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxMicrophones.SelectedIndexChanged
        If _SIPInited = False Then
            Return
        End If

        _sdkLib.setAudioDeviceId(ComboBoxMicrophones.SelectedIndex, ComboBoxSpeakers.SelectedIndex)
    End Sub

    Private Sub ComboBoxSpeakers_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxSpeakers.SelectedIndexChanged
        If _SIPInited = False Then
            Return
        End If

        _sdkLib.setAudioDeviceId(ComboBoxMicrophones.SelectedIndex, ComboBoxSpeakers.SelectedIndex)
    End Sub

    Private Sub ComboBoxCameras_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxCameras.SelectedIndexChanged
        If _SIPInited = False Then
            Return
        End If
        _sdkLib.setVideoDeviceId(ComboBoxCameras.SelectedIndex)
    End Sub

    Private Sub ComboBoxVideoResolution_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxVideoResolution.SelectedIndexChanged
        If _SIPInited = False Then
            Return
        End If

        SetVideoResolution()
    End Sub

    Private Sub TrackBarVideoQuality_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TrackBarVideoQuality.ValueChanged
        If _SIPInited = False Then
            Return
        End If

        SetVideoQuality()
    End Sub


    Private Sub ComboBoxSRTP_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxSRTP.SelectedIndexChanged
        If _SIPInited = False Then
            Return
        End If

        SetSRTPType()
    End Sub

    Private Sub ButtonCameraOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCameraOptions.Click
        If _SIPInited = False Then
            Return
        End If

        Dim uniqueId As New StringBuilder()
        uniqueId.Length = 256
        Dim deviceName As New StringBuilder()
        deviceName.Length = 256

        Dim rt As Integer = _sdkLib.getVideoCaptureDeviceName(ComboBoxCameras.SelectedIndex, uniqueId, 256, deviceName, 256)
        If rt <> 0 Then
            MessageBox.Show("Failed to get camera name .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        rt = _sdkLib.showVideoCaptureSettingsDialogBox(uniqueId.ToString(), uniqueId.Length, "Camera settings", Handle, 200, 200)
        If rt <> 0 Then
            MessageBox.Show("Show the camera settings dialog failure.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

    End Sub

    Private Sub ButtonSendVideo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSendVideo.Click
        If _SIPInited = False Then
            Return
        End If

        If _CallSessions(_CurrentlyLine).getSessionState() = False And _CallSessions(_CurrentlyLine).getRecvCallState() = False Then
            Return
        End If

        Dim rt As Integer = _sdkLib.sendVideo(_CallSessions(_CurrentlyLine).getSessionId(), True)
        If rt <> 0 Then
            MessageBox.Show("Start video sending failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button15.Click
        If _SIPInited = False Then
            Return
        End If

        If _CallSessions(_CurrentlyLine).getSessionState() = False Then
            Return
        End If

        _sdkLib.sendVideo(_CallSessions(_CurrentlyLine).getSessionId(), False)
    End Sub

    Private Sub CheckBoxMute_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxMute.CheckedChanged
        If _SIPInited = False Then
            Return
        End If
        _sdkLib.muteMicrophone(CheckBoxMute.Checked)
    End Sub

    Private Sub checkBoxPCMU_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxPCMU.CheckedChanged
        UpdateAudioCodecs()
    End Sub

    Private Sub checkBoxPCMA_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxPCMA.CheckedChanged
        UpdateAudioCodecs()
    End Sub

    Private Sub checkBoxG729_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxG729.CheckedChanged
        UpdateAudioCodecs()
    End Sub

    Private Sub checkBoxILBC_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxILBC.CheckedChanged
        UpdateAudioCodecs()
    End Sub

    Private Sub checkBoxGSM_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxGSM.CheckedChanged
        UpdateAudioCodecs()
    End Sub

    Private Sub checkBoxAMR_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxAMR.CheckedChanged
        UpdateAudioCodecs()
    End Sub


    Private Sub CheckBoxG722_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxG722.CheckedChanged
        UpdateAudioCodecs()
    End Sub

    Private Sub CheckBoxG7221_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxG7221.CheckedChanged
        UpdateAudioCodecs()
    End Sub

    Private Sub CheckBoxAMRwb_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxAMRwb.CheckedChanged
        UpdateAudioCodecs()
    End Sub

    Private Sub CheckBoxSpeexWB_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxSpeexWB.CheckedChanged
        UpdateAudioCodecs()
    End Sub

    Private Sub CheckBoxSpeex_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxSpeex.CheckedChanged
        UpdateAudioCodecs()
    End Sub

    Private Sub checkBoxOPUS_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxOPUS.CheckedChanged
        UpdateAudioCodecs()
    End Sub


    Private Sub checkBoxH263_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxH263.CheckedChanged
        UpdateVideoCodecs()
    End Sub

    Private Sub checkBoxH2631998_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxH2631998.CheckedChanged
        UpdateVideoCodecs()
    End Sub

    Private Sub checkBoxH264_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxH264.CheckedChanged
        UpdateVideoCodecs()
    End Sub


    Private Sub checkBoxVP8_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxVP8.CheckedChanged
        UpdateVideoCodecs()
    End Sub

    Private Sub checkBoxAEC_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxAEC.CheckedChanged
        If _SIPInited = False Then
            Return
        End If
        If checkBoxAEC.Checked = True Then
            _sdkLib.enableAEC(EC_MODES.EC_DEFAULT)
        Else
            _sdkLib.enableAEC(EC_MODES.EC_NONE)
        End If
    End Sub

    Private Sub checkBoxVAD_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxVAD.CheckedChanged
        If _SIPInited = False Then
            Return
        End If

        _sdkLib.enableVAD(checkBoxVAD.Checked)
    End Sub

    Private Sub checkBoxCNG_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxCNG.CheckedChanged
        If _SIPInited = False Then
            Return
        End If

        _sdkLib.enableCNG(checkBoxAEC.Checked)
    End Sub

    Private Sub checkBoxAGC_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxAGC.CheckedChanged
        If _SIPInited = False Then
            Return
        End If

        If checkBoxAGC.Checked = True Then
            _sdkLib.enableAGC(AGC_MODES.AGC_DEFAULT)
        Else
            _sdkLib.enableAGC(AGC_MODES.AGC_NONE)
        End If
    End Sub

    Private Sub checkBoxANS_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxANS.CheckedChanged
        If _SIPInited = False Then
            Return
        End If

        If checkBoxANS.Checked = True Then
            _sdkLib.enableANS(NS_MODES.NS_DEFAULT)
        Else
            _sdkLib.enableANS(NS_MODES.NS_NONE)
        End If

    End Sub

    Private Sub checkBoxNACK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBoxNACK.CheckedChanged
        If _SIPInited = False Then
            Return
        End If

        _sdkLib.setVideoNackStatus(checkBoxNACK.Checked)
    End Sub

    Private Sub Button17_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button17.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBoxRecordFilePath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub checkBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBox1.CheckedChanged
        If _SIPInited = False Then
            MessageBox.Show("Please initialize the SDK first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If checkBox1.Checked = True Then

            ' Callback the audio stream from each line
            Dim rt As Integer = _sdkLib.enableAudioStreamCallback(0, _CallSessions(_CurrentlyLine).getSessionId(), True, AUDIOSTREAM_CALLBACK_MODE.AUDIOSTREAM_REMOTE_PER_CHANNEL)
            If rt <> 0 Then
                MessageBox.Show("Failed to enable the audio stream callback.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                checkBox1.Checked = False
            End If
        Else
            ' Disable audio stream callback
            _sdkLib.enableAudioStreamCallback(0, _CallSessions(_CurrentlyLine).getSessionId(), False, AUDIOSTREAM_CALLBACK_MODE.AUDIOSTREAM_REMOTE_PER_CHANNEL)
        End If
    End Sub



    Private Sub Button19_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles Button19.Click
        If _SIPInited = False Then
            MessageBox.Show("Please initialize the SDK first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If TextBoxRecordFilePath.Text.Length <= 0 OrElse TextBoxRecordFileName.Text.Length <= 0 Then
            MessageBox.Show("The file path or file name is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        Dim filePath As String = TextBoxRecordFilePath.Text
        Dim fileName As String = TextBoxRecordFileName.Text

        Dim audioRecordFileFormat As AUDIO_RECORDING_FILEFORMAT = AUDIO_RECORDING_FILEFORMAT.FILEFORMAT_WAVE

        '  Start recording
        Dim rt As Integer = _sdkLib.startRecord(_CallSessions(_CurrentlyLine).getSessionId(), filePath, fileName, True, audioRecordFileFormat, RECORD_MODE.RECORD_BOTH, _
         VIDEOCODEC_TYPE.VIDEO_CODEC_H264, RECORD_MODE.RECORD_RECV)
        If rt <> 0 Then
            MessageBox.Show("Failed to start record conversation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        MessageBox.Show("Started record conversation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub Button18_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button18.Click
        If _SIPInited = False Then
            Return
        End If

        _sdkLib.stopRecord(_CallSessions(_CurrentlyLine).getSessionId())

        MessageBox.Show("Stop record conversation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub


    Private Sub Button20_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button20.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBoxPlayFile.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button21_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button21.Click
        If _SIPInited = False Then
            MessageBox.Show("Please initialize the SDK first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If TextBoxPlayFile.Text.Length <= 0 Then
            MessageBox.Show("The play file is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim waveFile As String = TextBoxPlayFile.Text

        _sdkLib.playAudioFileToRemote(_CallSessions(_CurrentlyLine).getSessionId(), waveFile, 16000, False)

    End Sub

    Private Sub Button23_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button23.Click
        If _SIPInited = False Then
            Return
        End If
        _sdkLib.stopPlayAudioFileToRemote(_CallSessions(_CurrentlyLine).getSessionId())
    End Sub

    Private Sub button27_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button27.Click
        If _SIPInited = False Then
            MessageBox.Show("Please initialize the SDK first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return
        End If

        Dim forwardTo As String = textBoxForwardTo.Text
        If forwardTo.IndexOf("sip:") = -1 OrElse forwardTo.IndexOf("@") = -1 Then
            MessageBox.Show("The forward address must likes sip:xxxx@sip.portsip.com.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return
        End If

        If checkBoxForwardCallForBusy.Checked = True Then
            _sdkLib.enableCallForward(True, forwardTo)
        Else
            _sdkLib.enableCallForward(False, forwardTo)
        End If

        MessageBox.Show("The call forward is enabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End Sub

    Private Sub button28_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button28.Click
        If _SIPInited = False Then
            MessageBox.Show("Please initialize the SDK first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return
        End If

        _sdkLib.disableCallForward()

        MessageBox.Show("The call forward is disabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://portsip.com/portsip-pbx")
    End Sub

    Private Sub linkLabel2_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabel2.LinkClicked
        System.Diagnostics.Process.Start("mailto:sales@portsip.com")
    End Sub


    Private Sub Button22_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button22.Click
        ListBoxSIPLog.Items.Clear()
    End Sub



    Private Sub checkBoxPRACK_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxPRACK.CheckedChanged
        updatePrackSetting()
    End Sub

    Private Sub CheckBoxDND_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxDND.CheckedChanged
        If _SIPInited = False Then
            Return
        End If

        _sdkLib.setDoNotDisturb(CheckBoxDND.Checked)
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
        ' use the Invoke method to modify the control.
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
        Dim index As Integer = -1
        For i As Integer = LINE_BASE To MAX_LINES - 1
            If _CallSessions(i).getSessionState() = False AndAlso _CallSessions(i).getRecvCallState() = False Then
                index = i
                _CallSessions(i).setRecvCallState(True)
                Exit For
            End If
        Next

        If index = -1 Then
            _sdkLib.rejectCall(sessionId, 486)
            Return 0
        End If

        ' If more than one codecs using, then they are separated with "#",
        ' for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
        If existsVideo Then
        End If
        ' If more than one codecs using, then they are separated with "#",
        ' for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
        If existsAudio Then
        End If

        _CallSessions(index).setSessionId(sessionId)
        Dim Text As String = String.Empty

        Dim needIgnoreAutoAnswer As Boolean = False
        Dim j As Integer = 0

        For j = LINE_BASE To MAX_LINES - 1
            If _CallSessions(j).getSessionState() = True Then
                needIgnoreAutoAnswer = True
                Exit For
            End If
        Next

        Dim AA As [Boolean] = False
        Dim answerVideo As Boolean = False
        ListBoxSIPLog.Invoke(New MethodInvoker(Function() _
              AA = CheckBoxAA.Checked))

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() _
        answerVideo = checkBoxAnswerVideo.Checked))

        If needIgnoreAutoAnswer = False AndAlso AA = True Then
            _CallSessions(index).setRecvCallState(False)
            _CallSessions(index).setSessionState(True)


            ListBoxSIPLog.Invoke(New MethodInvoker(Function() _
            _sdkLib.setRemoteVideoWindow(_CallSessions(index).getSessionId(), remoteVideoPanel.Handle)))

            _sdkLib.answerCall(_CallSessions(index).getSessionId(), answerVideo)

            Text = "Line " & index.ToString()
            Text = Text & ": Answered call by Auto answer"

            ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

            Return 0
        End If

        Text = "Line " & index.ToString()
        Text = Text & ": Call incoming from "
        Text = Text & callerDisplayName
        Text = Text & "<"
        Text = Text & caller
        Text = Text & ">"


        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        '  You should write your own code to play the wav file here for alert the incoming call(incoming tone);

        Return 0

    End Function

    Public Function onInviteTrying(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onInviteTrying
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Call is trying..."

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function


    Public Function onInviteSessionProgress(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal audioCodecNames As [String], ByVal videoCodecNames As [String], ByVal existsEarlyMedia As [Boolean],
     ByVal existsAudio As [Boolean], ByVal existsVideo As [Boolean], ByVal sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onInviteSessionProgress
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        ' If more than one codecs using, then they are separated with "#",
        ' for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
        If existsVideo Then
        End If
        ' If more than one codecs using, then they are separated with "#",
        ' for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
        If existsAudio Then
        End If

        _CallSessions(i).setSessionState(True)

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Call session progress."

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        _CallSessions(i).setEarlyMeida(existsEarlyMedia)

        Return 0
    End Function

    Public Function onInviteRinging(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32,
                                    ByVal statusText As [String], ByVal statusCode As Int32, ByVal sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onInviteRinging
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        ' No early media, you must play the local WAVE  file for ringing tone
        If _CallSessions(i).hasEarlyMedia() = False Then
        End If

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Ringing..."

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))


        Return 0
    End Function


    Public Function onInviteAnswered(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal callerDisplayName As [String], ByVal caller As [String], ByVal calleeDisplayName As [String],
     ByVal callee As [String], ByVal audioCodecNames As [String], ByVal videoCodecNames As [String], ByVal existsAudio As [Boolean], ByVal existsVideo As [Boolean], ByVal sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onInviteAnswered
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        ' If more than one codecs using, then they are separated with "#",
        ' for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
        If existsVideo Then
        End If
        ' If more than one codecs using, then they are separated with "#",
        ' for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
        If existsAudio Then
        End If


        _CallSessions(i).setSessionState(True)

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Call established"

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() _
        ListBoxSIPLog.Items.Add(Text)))

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() _
        joinConference(i)))


        ' If this is the refer call then need set it to normal
        If _CallSessions(i).isReferCall() Then
            _CallSessions(i).setReferCall(False, 0)
        End If

        Return 0
    End Function


    Public Function onInviteFailure(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal reason As [String], ByVal code As Int32, ByVal sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onInviteFailure
        Dim index As Integer = findSession(sessionId)
        If index = -1 Then
            Return 0
        End If

        Dim Text As String = "Line " & index.ToString()
        Text += ": call failure, "
        Text += reason
        Text += ", "
        Text += code.ToString()

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))


        If _CallSessions(index).isReferCall() Then
            ' Take off the origin call from HOLD if the refer call is failure
            Dim originIndex As Integer = -1
            For i As Integer = LINE_BASE To MAX_LINES - 1
                ' Looking for the origin call
                If _CallSessions(i).getSessionId() = _CallSessions(index).getOriginCallSessionId() Then
                    originIndex = i
                    Exit For
                End If
            Next

            If originIndex <> -1 Then
                _sdkLib.unHold(_CallSessions(index).getOriginCallSessionId())
                _CallSessions(originIndex).setHoldState(False)

                ' Switch the currently line to origin call line
                _CurrentlyLine = originIndex
                ComboBoxLines.SelectedIndex = _CurrentlyLine - 1

                Text = "Current line is set to: "
                Text += _CurrentlyLine.ToString()

                ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))
            End If
        End If

        _CallSessions(index).reset()

        Return 0
    End Function


    Public Function onInviteUpdated(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal audioCodecNames As [String], ByVal videoCodecNames As [String], ByVal existsAudio As [Boolean],
     ByVal existsVideo As [Boolean], ByVal sipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onInviteUpdated
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        ' If more than one codecs using, then they are separated with "#",
        ' for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
        If existsVideo Then
        End If
        ' If more than one codecs using, then they are separated with "#",
        ' for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
        If existsAudio Then
        End If

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Call is updated"

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function

    Public Function onInviteConnected(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onInviteConnected
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Call is connected"

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function


    Public Function onInviteBeginingForward(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal forwardTo As [String]) As Int32 Implements SIPCallbackEvents.onInviteBeginingForward
        Dim Text As String = "An incoming call was forwarded to: "
        Text = Text & forwardTo

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function


    Public Function onInviteClosed(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onInviteClosed
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        _CallSessions(i).reset()

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Call closed"

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function


    Public Function onDialogStateUpdated(callbackIndex As Int32, callbackObject As Int32, BLFMonitoredUri As [String], BLFDialogState As [String], BLFDialogId As [String], BLFDialogDirection As [String]) As Int32 Implements SIPCallbackEvents.onDialogStateUpdated


        Dim Text As String = "The user "
        Text += BLFMonitoredUri
        Text += " dialog state is updated: "
        Text += BLFDialogState
        Text += ", dialog id: "
        Text += BLFDialogId
        Text += ", direction: "
        Text += BLFDialogDirection

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function


    Public Function onRemoteHold(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onRemoteHold
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Placed on hold by remote."

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function


    Public Function onRemoteUnHold(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal audioCodecNames As [String], ByVal videoCodecNames As [String], ByVal existsAudio As [Boolean], _
     ByVal existsVideo As [Boolean]) As Int32 Implements SIPCallbackEvents.onRemoteUnHold
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Take off hold by remote."

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function


    Public Function onReceivedRefer(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal referId As Int32, ByVal [to] As [String], ByVal from As [String],
     ByVal referSipMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onReceivedRefer
        Dim index As Integer = findSession(sessionId)
        If index = -1 Then
            _sdkLib.rejectRefer(referId)
            Return 0
        End If

        Dim Text As String = "Received REFER on line "
        Text += index.ToString()
        Text += ", refer to "
        Text += [to]

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() _
              ListBoxSIPLog.Items.Add(Text)))


        ' Accept the REFER automatically
        Dim referSessionId As Integer = _sdkLib.acceptRefer(referId, referSipMessage.ToString())
        If referSessionId <= 0 Then
            Text = "Failed to accept REFER on line"
            ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))
        Else
            _sdkLib.hangUp(_CallSessions(index).getSessionId())
            _CallSessions(index).reset()

            _CallSessions(index).setSessionId(referSessionId)
            _CallSessions(index).setSessionState(True)


            Text = "Accepted the REFER."
            ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))
        End If

        Return 0

    End Function


    Public Function onReferAccepted(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onReferAccepted
        Dim index As Integer = findSession(sessionId)
        If index = -1 Then
            Return 0
        End If

        Dim Text As String = "Line "
        Text += index.ToString()
        Text += ", the REFER was accepted"

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function



    Public Function onReferRejected(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal reason As [String], ByVal code As Int32) As Int32 Implements SIPCallbackEvents.onReferRejected
        Dim index As Integer = findSession(sessionId)
        If index = -1 Then
            Return 0
        End If

        Dim Text As String = "Line "
        Text += index.ToString()
        Text += ", the REFER was rejected"

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function


    Public Function onTransferTrying(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onTransferTrying
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Transfer Trying"

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))


        Return 0
    End Function

    Public Function onTransferRinging(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onTransferRinging
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Transfer Ringing"

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function



    Public Function onACTVTransferSuccess(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onACTVTransferSuccess
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        _sdkLib.hangUp(_CallSessions(i).getSessionId())
        _CallSessions(i).reset()

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Transfer succeeded, close the call."

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function


    Public Function onACTVTransferFailure(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal reason As [String], ByVal code As Int32) As Int32 Implements SIPCallbackEvents.onACTVTransferFailure
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        Dim Text As String = "Line " & i.ToString()
        Text = Text & ": Transfer failure"

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        '  reason is error reason
        '  code is error code

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


    Public Function onRecvDtmfTone(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal tone As Int32) As Int32 Implements SIPCallbackEvents.onRecvDtmfTone
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        Dim DTMFTone As String = tone.ToString()
        Select Case tone
            Case 10
                DTMFTone = "*"
                Exit Select

            Case 11
                DTMFTone = "#"
                Exit Select

            Case 12
                DTMFTone = "A"
                Exit Select

            Case 13
                DTMFTone = "B"
                Exit Select

            Case 14
                DTMFTone = "C"
                Exit Select

            Case 15
                DTMFTone = "D"
                Exit Select

            Case 16
                DTMFTone = "FLASH"
                Exit Select
        End Select

        Dim Text As String = "Received DTMF Tone: "
        Text += DTMFTone
        Text += " on line "
        Text += i.ToString()

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))


        Return 0
    End Function


    Public Function onPresenceRecvSubscribe(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal subscribeId As Int32, ByVal fromDisplayName As [String], ByVal from As [String], ByVal subject As [String]) As Int32 Implements SIPCallbackEvents.onPresenceRecvSubscribe


        Return 0
    End Function


    Public Function onPresenceOnline(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal fromDisplayName As [String], ByVal from As [String], ByVal stateText As [String]) As Int32 Implements SIPCallbackEvents.onPresenceOnline

        Return 0
    End Function

    Public Function onPresenceOffline(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal fromDisplayName As [String], ByVal from As [String]) As Int32 Implements SIPCallbackEvents.onPresenceOffline


        Return 0
    End Function


    Public Function onRecvOptions(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal optionsMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onRecvOptions
        '         string text = "Received an OPTIONS message: ";
        '       text += optionsMessage.ToString();
        '     MessageBox.Show(text, "Received an OPTIONS message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        Return 0
    End Function

    Public Function onRecvInfo(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal infoMessage As StringBuilder) As Int32 Implements SIPCallbackEvents.onRecvInfo
        Dim text As String = "Received a INFO message: "
        text += infoMessage.ToString()

        MessageBox.Show(text, "Received a INFO message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

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


    Public Function onRecvMessage(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal mimeType As [String], ByVal subMimeType As [String], ByVal messageData As Byte(), _
     ByVal messageDataLength As Int32) As Int32 Implements SIPCallbackEvents.onRecvMessage
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        Dim text As String = "Received a MESSAGE message on line "
        text += i.ToString()

        If mimeType = "text" AndAlso subMimeType = "plain" Then
            Dim mesageText As String = GetString(messageData)
            ' The messageData is binary data
        ElseIf mimeType = "application" AndAlso subMimeType = "vnd.3gpp.sms" Then
            ' The messageData is binary data
        ElseIf mimeType = "application" AndAlso subMimeType = "vnd.3gpp2.sms" Then
        End If

        MessageBox.Show(text, "Received a MESSAGE message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Return 0
    End Function


    Public Function onRecvOutOfDialogMessage(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal fromDisplayName As [String], ByVal from As [String], ByVal toDisplayName As [String], ByVal [to] As [String], _
     ByVal mimeType As [String], ByVal subMimeType As [String], ByVal messageData As Byte(), ByVal messageDataLength As Int32) As Int32 Implements SIPCallbackEvents.onRecvOutOfDialogMessage
        Dim text As String = "Received a message(out of dialog) from "
        text += from

        If mimeType = "text" AndAlso subMimeType = "plain" Then
            Dim mesageText As String = GetString(messageData)
            ' The messageData is binary data
        ElseIf mimeType = "application" AndAlso subMimeType = "vnd.3gpp.sms" Then
            ' The messageData is binary data
        ElseIf mimeType = "application" AndAlso subMimeType = "vnd.3gpp2.sms" Then
        End If

        MessageBox.Show(text, "Received a out of dialog MESSAGE message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Return 0
    End Function

    Public Function onSendMessageSuccess(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal messageId As Int32) As Int32 Implements SIPCallbackEvents.onSendMessageSuccess
        Return 0
    End Function


    Public Function onSendMessageFailure(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal messageId As Int32, ByVal reason As [String], ByVal code As Int32) As Int32 Implements SIPCallbackEvents.onSendMessageFailure

        Return 0
    End Function



    Public Function onSendOutOfDialogMessageSuccess(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal messageId As Int32, ByVal fromDisplayName As [String], ByVal from As [String], ByVal toDisplayName As [String], _
     ByVal [to] As [String]) As Int32 Implements SIPCallbackEvents.onSendOutOfDialogMessageSuccess


        Return 0
    End Function

    Public Function onSendOutOfDialogMessageFailure(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal messageId As Int32, ByVal fromDisplayName As [String], ByVal from As [String], ByVal toDisplayName As [String], _
     ByVal [to] As [String], ByVal reason As [String], ByVal code As Int32) As Int32 Implements SIPCallbackEvents.onSendOutOfDialogMessageFailure
        Return 0
    End Function


    Public Function onPlayAudioFileFinished(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32, ByVal fileName As [String]) As Int32 Implements SIPCallbackEvents.onPlayAudioFileFinished
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        Dim Text As String = "Play audio file - "
        Text += fileName
        Text += " end on line: "
        Text += i.ToString()

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function

    Public Function onPlayVideoFileFinished(ByVal callbackIndex As Int32, ByVal callbackObject As Int32, ByVal sessionId As Int32) As Int32 Implements SIPCallbackEvents.onPlayVideoFileFinished
        Dim i As Integer = findSession(sessionId)
        If i = -1 Then
            Return 0
        End If

        Dim Text As String = "Play video file end on line: "
        Text += i.ToString()

        ListBoxSIPLog.Invoke(New MethodInvoker(Function() ListBoxSIPLog.Items.Add(Text)))

        Return 0
    End Function


    Public Function onReceivedRtpPacket(ByVal callbackObject As IntPtr, ByVal sessionId As Int32, ByVal isAudio As [Boolean], ByVal RTPPacket As Byte(), ByVal packetSize As Int32) As Int32 Implements SIPCallbackEvents.onReceivedRtpPacket
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

    Public Function onSendingRtpPacket(ByVal callbackObject As IntPtr, ByVal sessionId As Int32, ByVal isAudio As [Boolean], ByVal RTPPacket As Byte(), ByVal packetSize As Int32) As Int32 Implements SIPCallbackEvents.onSendingRtpPacket

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


    Public Function onAudioRawCallback(ByVal callbackObject As IntPtr, ByVal sessionId As Int32, ByVal callbackType As Int32, <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=4)> ByVal data As Byte(), ByVal dataLength As Int32, ByVal samplingFreqHz As Int32) As Int32 Implements SIPCallbackEvents.onAudioRawCallback

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


    Public Function onVideoRawCallback(ByVal callbackObject As IntPtr, ByVal sessionId As Int32, ByVal callbackType As Int32, ByVal width As Int32, ByVal height As Int32, <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=6)> ByVal data As Byte(), _
     ByVal dataLength As Int32) As Int32 Implements SIPCallbackEvents.onVideoRawCallback
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
