Partial Class Form1
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	#Region "Windows Form Designer generated code"

	''' <summary>
	''' Required method for Designer support - do not modify
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
		Me.CheckBoxSpeex = New System.Windows.Forms.CheckBox()
		Me.linkLabel2 = New System.Windows.Forms.LinkLabel()
		Me.CheckBoxG722 = New System.Windows.Forms.CheckBox()
		Me.ButtonLocalVideo = New System.Windows.Forms.Button()
		Me.checkBoxAMR = New System.Windows.Forms.CheckBox()
		Me.ButtonCameraOptions = New System.Windows.Forms.Button()
		Me.CheckBoxG7221 = New System.Windows.Forms.CheckBox()
		Me.CheckBoxSpeexWB = New System.Windows.Forms.CheckBox()
		Me.CheckBoxAMRwb = New System.Windows.Forms.CheckBox()
		Me.checkBoxGSM = New System.Windows.Forms.CheckBox()
		Me.ComboBoxVideoResolution = New System.Windows.Forms.ComboBox()
		Me.Button22 = New System.Windows.Forms.Button()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.checkBoxILBC = New System.Windows.Forms.CheckBox()
		Me.Button15 = New System.Windows.Forms.Button()
		Me.ButtonSendVideo = New System.Windows.Forms.Button()
		Me.checkBoxG729 = New System.Windows.Forms.CheckBox()
		Me.groupBox5 = New System.Windows.Forms.GroupBox()
		Me.checkBoxOpus = New System.Windows.Forms.CheckBox()
		Me.checkBoxPCMA = New System.Windows.Forms.CheckBox()
		Me.checkBoxPCMU = New System.Windows.Forms.CheckBox()
		Me.ComboBoxCameras = New System.Windows.Forms.ComboBox()
		Me.ListBoxSIPLog = New System.Windows.Forms.ListBox()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.ComboBoxMicrophones = New System.Windows.Forms.ComboBox()
		Me.TrackBarVideoQuality = New System.Windows.Forms.TrackBar()
		Me.ComboBoxSpeakers = New System.Windows.Forms.ComboBox()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.localVideoPanel = New System.Windows.Forms.Panel()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.CheckBoxMute = New System.Windows.Forms.CheckBox()
		Me.remoteVideoPanel = New System.Windows.Forms.Panel()
		Me.TrackBarMicrophone = New System.Windows.Forms.TrackBar()
		Me.groupBox6 = New System.Windows.Forms.GroupBox()
		Me.checkBoxVP8 = New System.Windows.Forms.CheckBox()
		Me.checkBoxH264 = New System.Windows.Forms.CheckBox()
		Me.checkBoxH2631998 = New System.Windows.Forms.CheckBox()
		Me.checkBoxH263 = New System.Windows.Forms.CheckBox()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.button27 = New System.Windows.Forms.Button()
		Me.checkBoxForwardCallForBusy = New System.Windows.Forms.CheckBox()
		Me.textBoxForwardTo = New System.Windows.Forms.TextBox()
		Me.label16 = New System.Windows.Forms.Label()
		Me.groupBox9 = New System.Windows.Forms.GroupBox()
		Me.Button23 = New System.Windows.Forms.Button()
		Me.Button21 = New System.Windows.Forms.Button()
		Me.Button20 = New System.Windows.Forms.Button()
		Me.TextBoxPlayFile = New System.Windows.Forms.TextBox()
		Me.Label27 = New System.Windows.Forms.Label()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.Button18 = New System.Windows.Forms.Button()
		Me.Button19 = New System.Windows.Forms.Button()
		Me.button28 = New System.Windows.Forms.Button()
		Me.Button17 = New System.Windows.Forms.Button()
		Me.checkBox1 = New System.Windows.Forms.CheckBox()
		Me.checkBoxAGC = New System.Windows.Forms.CheckBox()
		Me.checkBoxCNG = New System.Windows.Forms.CheckBox()
		Me.groupBox11 = New System.Windows.Forms.GroupBox()
		Me.checkBoxVAD = New System.Windows.Forms.CheckBox()
		Me.groupBox7 = New System.Windows.Forms.GroupBox()
		Me.checkBoxANS = New System.Windows.Forms.CheckBox()
		Me.checkBoxAEC = New System.Windows.Forms.CheckBox()
		Me.TextBoxRecordFileName = New System.Windows.Forms.TextBox()
		Me.groupBox8 = New System.Windows.Forms.GroupBox()
		Me.Label25 = New System.Windows.Forms.Label()
		Me.TextBoxRecordFilePath = New System.Windows.Forms.TextBox()
		Me.Label26 = New System.Windows.Forms.Label()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.groupBox2 = New System.Windows.Forms.GroupBox()
		Me.checkBoxMakeVideoCall = New System.Windows.Forms.CheckBox()
		Me.checkBoxAnswerVideo = New System.Windows.Forms.CheckBox()
		Me.checkBoxPRACK = New System.Windows.Forms.CheckBox()
		Me.CheckBoxConf = New System.Windows.Forms.CheckBox()
		Me.CheckBoxAA = New System.Windows.Forms.CheckBox()
		Me.CheckBoxDND = New System.Windows.Forms.CheckBox()
		Me.CheckBoxSDP = New System.Windows.Forms.CheckBox()
		Me.button24 = New System.Windows.Forms.Button()
		Me.Button16 = New System.Windows.Forms.Button()
		Me.ButtonAnswer = New System.Windows.Forms.Button()
		Me.ButtonTransfer = New System.Windows.Forms.Button()
		Me.ButtonHold = New System.Windows.Forms.Button()
		Me.ComboBoxLines = New System.Windows.Forms.ComboBox()
		Me.ButtonReject = New System.Windows.Forms.Button()
		Me.ButtonHangUp = New System.Windows.Forms.Button()
		Me.ButtonDial = New System.Windows.Forms.Button()
		Me.Button12 = New System.Windows.Forms.Button()
		Me.Button13 = New System.Windows.Forms.Button()
		Me.Button14 = New System.Windows.Forms.Button()
		Me.Button9 = New System.Windows.Forms.Button()
		Me.Button10 = New System.Windows.Forms.Button()
		Me.Button11 = New System.Windows.Forms.Button()
		Me.Button6 = New System.Windows.Forms.Button()
		Me.Button7 = New System.Windows.Forms.Button()
		Me.Button8 = New System.Windows.Forms.Button()
		Me.Button5 = New System.Windows.Forms.Button()
		Me.Button4 = New System.Windows.Forms.Button()
		Me.Button3 = New System.Windows.Forms.Button()
		Me.TextBoxPhoneNumber = New System.Windows.Forms.TextBox()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label23 = New System.Windows.Forms.Label()
		Me.ComboBoxSRTP = New System.Windows.Forms.ComboBox()
		Me.textBoxLocalPort = New System.Windows.Forms.TextBox()
		Me.label3 = New System.Windows.Forms.Label()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.TextBoxPassword = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.TextBoxUserName = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
		Me.Label21 = New System.Windows.Forms.Label()
		Me.groupBox3 = New System.Windows.Forms.GroupBox()
		Me.TrackBarSpeaker = New System.Windows.Forms.TrackBar()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.groupBox4 = New System.Windows.Forms.GroupBox()
		Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
		Me.groupBox5.SuspendLayout()
		DirectCast(Me.TrackBarVideoQuality, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.TrackBarMicrophone, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.groupBox6.SuspendLayout()
		Me.groupBox9.SuspendLayout()
		Me.groupBox11.SuspendLayout()
		Me.groupBox7.SuspendLayout()
		Me.groupBox8.SuspendLayout()
		Me.groupBox2.SuspendLayout()
		Me.groupBox1.SuspendLayout()
		Me.groupBox3.SuspendLayout()
		DirectCast(Me.TrackBarSpeaker, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.groupBox4.SuspendLayout()
		Me.SuspendLayout()
		' 
		' CheckBoxSpeex
		' 
		Me.CheckBoxSpeex.AutoSize = True
		Me.CheckBoxSpeex.Location = New System.Drawing.Point(303, 36)
		Me.CheckBoxSpeex.Name = "CheckBoxSpeex"
		Me.CheckBoxSpeex.Size = New System.Drawing.Size(61, 17)
		Me.CheckBoxSpeex.TabIndex = 107
		Me.CheckBoxSpeex.Text = "SPEEX"
		Me.CheckBoxSpeex.UseVisualStyleBackColor = True
		AddHandler Me.CheckBoxSpeex.CheckedChanged, New System.EventHandler(AddressOf Me.CheckBoxSpeex_CheckedChanged)
		' 
		' linkLabel2
		' 
		Me.linkLabel2.AutoSize = True
		Me.linkLabel2.Location = New System.Drawing.Point(772, 11)
		Me.linkLabel2.Name = "linkLabel2"
		Me.linkLabel2.Size = New System.Drawing.Size(170, 13)
		Me.linkLabel2.TabIndex = 50
		Me.linkLabel2.TabStop = True
		Me.linkLabel2.Text = "Click here to send email to PortSIP"
		AddHandler Me.linkLabel2.LinkClicked, New System.Windows.Forms.LinkLabelLinkClickedEventHandler(AddressOf Me.linkLabel2_LinkClicked)
		' 
		' CheckBoxG722
		' 
		Me.CheckBoxG722.AutoSize = True
		Me.CheckBoxG722.Location = New System.Drawing.Point(14, 36)
		Me.CheckBoxG722.Name = "CheckBoxG722"
		Me.CheckBoxG722.Size = New System.Drawing.Size(52, 17)
		Me.CheckBoxG722.TabIndex = 105
		Me.CheckBoxG722.Text = "G722"
		Me.CheckBoxG722.UseVisualStyleBackColor = True
		AddHandler Me.CheckBoxG722.CheckedChanged, New System.EventHandler(AddressOf Me.CheckBoxG722_CheckedChanged)
		' 
		' ButtonLocalVideo
		' 
		Me.ButtonLocalVideo.Location = New System.Drawing.Point(101, 193)
		Me.ButtonLocalVideo.Name = "ButtonLocalVideo"
		Me.ButtonLocalVideo.Size = New System.Drawing.Size(80, 23)
		Me.ButtonLocalVideo.TabIndex = 95
		Me.ButtonLocalVideo.Text = "Local Video"
		Me.ButtonLocalVideo.UseVisualStyleBackColor = True
		AddHandler Me.ButtonLocalVideo.Click, New System.EventHandler(AddressOf Me.ButtonLocalVideo_Click)
		' 
		' checkBoxAMR
		' 
		Me.checkBoxAMR.AutoSize = True
		Me.checkBoxAMR.Location = New System.Drawing.Point(360, 13)
		Me.checkBoxAMR.Name = "checkBoxAMR"
		Me.checkBoxAMR.Size = New System.Drawing.Size(50, 17)
		Me.checkBoxAMR.TabIndex = 104
		Me.checkBoxAMR.Text = "AMR"
		Me.checkBoxAMR.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxAMR.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxAMR_CheckedChanged)
		' 
		' ButtonCameraOptions
		' 
		Me.ButtonCameraOptions.Location = New System.Drawing.Point(6, 193)
		Me.ButtonCameraOptions.Name = "ButtonCameraOptions"
		Me.ButtonCameraOptions.Size = New System.Drawing.Size(80, 23)
		Me.ButtonCameraOptions.TabIndex = 94
		Me.ButtonCameraOptions.Text = "Options"
		Me.ButtonCameraOptions.UseVisualStyleBackColor = True
		AddHandler Me.ButtonCameraOptions.Click, New System.EventHandler(AddressOf Me.ButtonCameraOptions_Click)
		' 
		' CheckBoxG7221
		' 
		Me.CheckBoxG7221.AutoSize = True
		Me.CheckBoxG7221.Location = New System.Drawing.Point(73, 36)
		Me.CheckBoxG7221.Name = "CheckBoxG7221"
		Me.CheckBoxG7221.Size = New System.Drawing.Size(61, 17)
		Me.CheckBoxG7221.TabIndex = 109
		Me.CheckBoxG7221.Text = "G722.1"
		Me.CheckBoxG7221.UseVisualStyleBackColor = True
		AddHandler Me.CheckBoxG7221.CheckedChanged, New System.EventHandler(AddressOf Me.CheckBoxG7221_CheckedChanged)
		' 
		' CheckBoxSpeexWB
		' 
		Me.CheckBoxSpeexWB.AutoSize = True
		Me.CheckBoxSpeexWB.Location = New System.Drawing.Point(213, 36)
		Me.CheckBoxSpeexWB.Name = "CheckBoxSpeexWB"
		Me.CheckBoxSpeexWB.Size = New System.Drawing.Size(82, 17)
		Me.CheckBoxSpeexWB.TabIndex = 108
		Me.CheckBoxSpeexWB.Text = "SPEEX-WB"
		Me.CheckBoxSpeexWB.UseVisualStyleBackColor = True
		AddHandler Me.CheckBoxSpeexWB.CheckedChanged, New System.EventHandler(AddressOf Me.CheckBoxSpeexWB_CheckedChanged)
		' 
		' CheckBoxAMRwb
		' 
		Me.CheckBoxAMRwb.AutoSize = True
		Me.CheckBoxAMRwb.Location = New System.Drawing.Point(140, 36)
		Me.CheckBoxAMRwb.Name = "CheckBoxAMRwb"
		Me.CheckBoxAMRwb.Size = New System.Drawing.Size(71, 17)
		Me.CheckBoxAMRwb.TabIndex = 106
		Me.CheckBoxAMRwb.Text = "AMR-WB"
		Me.CheckBoxAMRwb.UseVisualStyleBackColor = True
		AddHandler Me.CheckBoxAMRwb.CheckedChanged, New System.EventHandler(AddressOf Me.CheckBoxAMRwb_CheckedChanged)
		' 
		' checkBoxGSM
		' 
		Me.checkBoxGSM.AutoSize = True
		Me.checkBoxGSM.Location = New System.Drawing.Point(304, 13)
		Me.checkBoxGSM.Name = "checkBoxGSM"
		Me.checkBoxGSM.Size = New System.Drawing.Size(50, 17)
		Me.checkBoxGSM.TabIndex = 103
		Me.checkBoxGSM.Text = "GSM"
		Me.checkBoxGSM.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxGSM.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxGSM_CheckedChanged)
		' 
		' ComboBoxVideoResolution
		' 
		Me.ComboBoxVideoResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboBoxVideoResolution.FormattingEnabled = True
		Me.ComboBoxVideoResolution.Location = New System.Drawing.Point(69, 166)
		Me.ComboBoxVideoResolution.Name = "ComboBoxVideoResolution"
		Me.ComboBoxVideoResolution.Size = New System.Drawing.Size(90, 21)
		Me.ComboBoxVideoResolution.TabIndex = 100
		AddHandler Me.ComboBoxVideoResolution.SelectedIndexChanged, New System.EventHandler(AddressOf Me.ComboBoxVideoResolution_SelectedIndexChanged)
		' 
		' Button22
		' 
		Me.Button22.Location = New System.Drawing.Point(496, 212)
		Me.Button22.Name = "Button22"
		Me.Button22.Size = New System.Drawing.Size(87, 23)
		Me.Button22.TabIndex = 57
		Me.Button22.Text = "Clear"
		Me.Button22.UseVisualStyleBackColor = True
		AddHandler Me.Button22.Click, New System.EventHandler(AddressOf Me.Button22_Click)
		' 
		' Label18
		' 
		Me.Label18.AutoSize = True
		Me.Label18.Location = New System.Drawing.Point(3, 172)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(57, 13)
		Me.Label18.TabIndex = 99
		Me.Label18.Text = "Resolution"
		' 
		' checkBoxILBC
		' 
		Me.checkBoxILBC.AutoSize = True
		Me.checkBoxILBC.Location = New System.Drawing.Point(250, 13)
		Me.checkBoxILBC.Name = "checkBoxILBC"
		Me.checkBoxILBC.Size = New System.Drawing.Size(48, 17)
		Me.checkBoxILBC.TabIndex = 102
		Me.checkBoxILBC.Text = "iLBC"
		Me.checkBoxILBC.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxILBC.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxILBC_CheckedChanged)
		' 
		' Button15
		' 
		Me.Button15.Location = New System.Drawing.Point(359, 193)
		Me.Button15.Name = "Button15"
		Me.Button15.Size = New System.Drawing.Size(80, 23)
		Me.Button15.TabIndex = 97
		Me.Button15.Text = "Stop Video"
		Me.Button15.UseVisualStyleBackColor = True
		AddHandler Me.Button15.Click, New System.EventHandler(AddressOf Me.Button15_Click)
		' 
		' ButtonSendVideo
		' 
		Me.ButtonSendVideo.Location = New System.Drawing.Point(263, 193)
		Me.ButtonSendVideo.Name = "ButtonSendVideo"
		Me.ButtonSendVideo.Size = New System.Drawing.Size(80, 23)
		Me.ButtonSendVideo.TabIndex = 96
		Me.ButtonSendVideo.Text = "Send Video"
		Me.ButtonSendVideo.UseVisualStyleBackColor = True
		AddHandler Me.ButtonSendVideo.Click, New System.EventHandler(AddressOf Me.ButtonSendVideo_Click)
		' 
		' checkBoxG729
		' 
		Me.checkBoxG729.AutoSize = True
		Me.checkBoxG729.Checked = True
		Me.checkBoxG729.CheckState = System.Windows.Forms.CheckState.Checked
		Me.checkBoxG729.Location = New System.Drawing.Point(192, 13)
		Me.checkBoxG729.Name = "checkBoxG729"
		Me.checkBoxG729.Size = New System.Drawing.Size(52, 17)
		Me.checkBoxG729.TabIndex = 101
		Me.checkBoxG729.Text = "G729"
		Me.checkBoxG729.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxG729.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxG729_CheckedChanged)
		' 
		' groupBox5
		' 
		Me.groupBox5.Controls.Add(Me.checkBoxOpus)
		Me.groupBox5.Controls.Add(Me.CheckBoxG7221)
		Me.groupBox5.Controls.Add(Me.CheckBoxSpeexWB)
		Me.groupBox5.Controls.Add(Me.CheckBoxAMRwb)
		Me.groupBox5.Controls.Add(Me.CheckBoxSpeex)
		Me.groupBox5.Controls.Add(Me.CheckBoxG722)
		Me.groupBox5.Controls.Add(Me.checkBoxAMR)
		Me.groupBox5.Controls.Add(Me.checkBoxGSM)
		Me.groupBox5.Controls.Add(Me.checkBoxILBC)
		Me.groupBox5.Controls.Add(Me.checkBoxG729)
		Me.groupBox5.Controls.Add(Me.checkBoxPCMA)
		Me.groupBox5.Controls.Add(Me.checkBoxPCMU)
		Me.groupBox5.Location = New System.Drawing.Point(32, 586)
		Me.groupBox5.Name = "groupBox5"
		Me.groupBox5.Size = New System.Drawing.Size(445, 55)
		Me.groupBox5.TabIndex = 56
		Me.groupBox5.TabStop = False
		' 
		' checkBoxOpus
		' 
		Me.checkBoxOpus.AutoSize = True
		Me.checkBoxOpus.Location = New System.Drawing.Point(365, 36)
		Me.checkBoxOpus.Name = "checkBoxOpus"
		Me.checkBoxOpus.Size = New System.Drawing.Size(56, 17)
		Me.checkBoxOpus.TabIndex = 108
		Me.checkBoxOpus.Text = "OPUS"
		Me.checkBoxOpus.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxOpus.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxOpus_CheckedChanged)
		' 
		' checkBoxPCMA
		' 
		Me.checkBoxPCMA.AutoSize = True
		Me.checkBoxPCMA.Checked = True
		Me.checkBoxPCMA.CheckState = System.Windows.Forms.CheckState.Checked
		Me.checkBoxPCMA.Location = New System.Drawing.Point(102, 13)
		Me.checkBoxPCMA.Name = "checkBoxPCMA"
		Me.checkBoxPCMA.Size = New System.Drawing.Size(81, 17)
		Me.checkBoxPCMA.TabIndex = 100
		Me.checkBoxPCMA.Text = "G711 aLaw"
		Me.checkBoxPCMA.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxPCMA.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxPCMA_CheckedChanged)
		' 
		' checkBoxPCMU
		' 
		Me.checkBoxPCMU.AutoSize = True
		Me.checkBoxPCMU.Checked = True
		Me.checkBoxPCMU.CheckState = System.Windows.Forms.CheckState.Checked
		Me.checkBoxPCMU.Location = New System.Drawing.Point(14, 13)
		Me.checkBoxPCMU.Name = "checkBoxPCMU"
		Me.checkBoxPCMU.Size = New System.Drawing.Size(81, 17)
		Me.checkBoxPCMU.TabIndex = 99
		Me.checkBoxPCMU.Text = "G711 uLaw"
		Me.checkBoxPCMU.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxPCMU.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxPCMU_CheckedChanged)
		' 
		' ComboBoxCameras
		' 
		Me.ComboBoxCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboBoxCameras.FormattingEnabled = True
		Me.ComboBoxCameras.Location = New System.Drawing.Point(94, 125)
		Me.ComboBoxCameras.Name = "ComboBoxCameras"
		Me.ComboBoxCameras.Size = New System.Drawing.Size(308, 21)
		Me.ComboBoxCameras.TabIndex = 56
		AddHandler Me.ComboBoxCameras.SelectedIndexChanged, New System.EventHandler(AddressOf Me.ComboBoxCameras_SelectedIndexChanged)
		' 
		' ListBoxSIPLog
		' 
		Me.ListBoxSIPLog.FormattingEnabled = True
		Me.ListBoxSIPLog.Location = New System.Drawing.Point(496, 44)
		Me.ListBoxSIPLog.Name = "ListBoxSIPLog"
		Me.ListBoxSIPLog.Size = New System.Drawing.Size(431, 160)
		Me.ListBoxSIPLog.TabIndex = 55
		' 
		' Label14
		' 
		Me.Label14.AutoSize = True
		Me.Label14.Location = New System.Drawing.Point(11, 128)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(43, 13)
		Me.Label14.TabIndex = 55
		Me.Label14.Text = "Camera"
		' 
		' ComboBoxMicrophones
		' 
		Me.ComboBoxMicrophones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboBoxMicrophones.FormattingEnabled = True
		Me.ComboBoxMicrophones.Location = New System.Drawing.Point(94, 75)
		Me.ComboBoxMicrophones.Name = "ComboBoxMicrophones"
		Me.ComboBoxMicrophones.Size = New System.Drawing.Size(308, 21)
		Me.ComboBoxMicrophones.TabIndex = 54
		AddHandler Me.ComboBoxMicrophones.SelectedIndexChanged, New System.EventHandler(AddressOf Me.ComboBoxMicrophones_SelectedIndexChanged)
		' 
		' TrackBarVideoQuality
		' 
		Me.TrackBarVideoQuality.Location = New System.Drawing.Point(302, 166)
		Me.TrackBarVideoQuality.Maximum = 2000
		Me.TrackBarVideoQuality.Minimum = 100
		Me.TrackBarVideoQuality.Name = "TrackBarVideoQuality"
		Me.TrackBarVideoQuality.Size = New System.Drawing.Size(119, 45)
		Me.TrackBarVideoQuality.TabIndex = 98
		Me.TrackBarVideoQuality.TickFrequency = 100
		Me.TrackBarVideoQuality.TickStyle = System.Windows.Forms.TickStyle.None
		Me.TrackBarVideoQuality.Value = 300
		AddHandler Me.TrackBarVideoQuality.ValueChanged, New System.EventHandler(AddressOf Me.TrackBarVideoQuality_ValueChanged)
		' 
		' ComboBoxSpeakers
		' 
		Me.ComboBoxSpeakers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboBoxSpeakers.FormattingEnabled = True
		Me.ComboBoxSpeakers.Location = New System.Drawing.Point(94, 98)
		Me.ComboBoxSpeakers.Name = "ComboBoxSpeakers"
		Me.ComboBoxSpeakers.Size = New System.Drawing.Size(308, 21)
		Me.ComboBoxSpeakers.TabIndex = 53
		AddHandler Me.ComboBoxSpeakers.SelectedIndexChanged, New System.EventHandler(AddressOf Me.ComboBoxSpeakers_SelectedIndexChanged)
		' 
		' Label12
		' 
		Me.Label12.AutoSize = True
		Me.Label12.Location = New System.Drawing.Point(11, 77)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(63, 13)
		Me.Label12.TabIndex = 52
		Me.Label12.Text = "Microphone"
		' 
		' localVideoPanel
		' 
		Me.localVideoPanel.Location = New System.Drawing.Point(5, 10)
		Me.localVideoPanel.Name = "localVideoPanel"
		Me.localVideoPanel.Size = New System.Drawing.Size(176, 144)
		Me.localVideoPanel.TabIndex = 0
		' 
		' Label13
		' 
		Me.Label13.AutoSize = True
		Me.Label13.Location = New System.Drawing.Point(11, 101)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(47, 13)
		Me.Label13.TabIndex = 51
		Me.Label13.Text = "Speaker"
		' 
		' CheckBoxMute
		' 
		Me.CheckBoxMute.AutoSize = True
		Me.CheckBoxMute.Location = New System.Drawing.Point(313, 38)
		Me.CheckBoxMute.Name = "CheckBoxMute"
		Me.CheckBoxMute.Size = New System.Drawing.Size(108, 17)
		Me.CheckBoxMute.TabIndex = 50
		Me.CheckBoxMute.Text = "Mute microphone"
		Me.CheckBoxMute.UseVisualStyleBackColor = True
		AddHandler Me.CheckBoxMute.CheckedChanged, New System.EventHandler(AddressOf Me.CheckBoxMute_CheckedChanged)
		' 
		' remoteVideoPanel
		' 
		Me.remoteVideoPanel.Location = New System.Drawing.Point(263, 10)
		Me.remoteVideoPanel.Name = "remoteVideoPanel"
		Me.remoteVideoPanel.Size = New System.Drawing.Size(176, 144)
		Me.remoteVideoPanel.TabIndex = 1
		' 
		' TrackBarMicrophone
		' 
		Me.TrackBarMicrophone.Location = New System.Drawing.Point(82, 38)
		Me.TrackBarMicrophone.Maximum = 255
		Me.TrackBarMicrophone.Name = "TrackBarMicrophone"
		Me.TrackBarMicrophone.Size = New System.Drawing.Size(214, 45)
		Me.TrackBarMicrophone.TabIndex = 49
		Me.TrackBarMicrophone.TickFrequency = 10
		Me.TrackBarMicrophone.TickStyle = System.Windows.Forms.TickStyle.None
		AddHandler Me.TrackBarMicrophone.ValueChanged, New System.EventHandler(AddressOf Me.TrackBarMicrophone_ValueChanged)
		' 
		' groupBox6
		' 
		Me.groupBox6.Controls.Add(Me.checkBoxVP8)
		Me.groupBox6.Controls.Add(Me.checkBoxH264)
		Me.groupBox6.Controls.Add(Me.checkBoxH2631998)
		Me.groupBox6.Controls.Add(Me.checkBoxH263)
		Me.groupBox6.Location = New System.Drawing.Point(32, 638)
		Me.groupBox6.Name = "groupBox6"
		Me.groupBox6.Size = New System.Drawing.Size(445, 42)
		Me.groupBox6.TabIndex = 58
		Me.groupBox6.TabStop = False
		' 
		' checkBoxVP8
		' 
		Me.checkBoxVP8.AutoSize = True
		Me.checkBoxVP8.Location = New System.Drawing.Point(359, 14)
		Me.checkBoxVP8.Name = "checkBoxVP8"
		Me.checkBoxVP8.Size = New System.Drawing.Size(46, 17)
		Me.checkBoxVP8.TabIndex = 66
		Me.checkBoxVP8.Text = "VP8"
		Me.checkBoxVP8.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxVP8.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxVP8_CheckedChanged)
		' 
		' checkBoxH264
		' 
		Me.checkBoxH264.AutoSize = True
		Me.checkBoxH264.Checked = True
		Me.checkBoxH264.CheckState = System.Windows.Forms.CheckState.Checked
		Me.checkBoxH264.Location = New System.Drawing.Point(274, 14)
		Me.checkBoxH264.Name = "checkBoxH264"
		Me.checkBoxH264.Size = New System.Drawing.Size(52, 17)
		Me.checkBoxH264.TabIndex = 65
		Me.checkBoxH264.Text = "H264"
		Me.checkBoxH264.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxH264.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxH264_CheckedChanged)
		' 
		' checkBoxH2631998
		' 
		Me.checkBoxH2631998.AutoSize = True
		Me.checkBoxH2631998.Location = New System.Drawing.Point(144, 14)
		Me.checkBoxH2631998.Name = "checkBoxH2631998"
		Me.checkBoxH2631998.Size = New System.Drawing.Size(79, 17)
		Me.checkBoxH2631998.TabIndex = 64
		Me.checkBoxH2631998.Text = "H263-1998"
		Me.checkBoxH2631998.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxH2631998.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxH2631998_CheckedChanged)
		' 
		' checkBoxH263
		' 
		Me.checkBoxH263.AutoSize = True
		Me.checkBoxH263.Location = New System.Drawing.Point(14, 14)
		Me.checkBoxH263.Name = "checkBoxH263"
		Me.checkBoxH263.Size = New System.Drawing.Size(52, 17)
		Me.checkBoxH263.TabIndex = 63
		Me.checkBoxH263.Text = "H263"
		Me.checkBoxH263.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxH263.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxH263_CheckedChanged)
		' 
		' Label11
		' 
		Me.Label11.AutoSize = True
		Me.Label11.Location = New System.Drawing.Point(11, 41)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(63, 13)
		Me.Label11.TabIndex = 48
		Me.Label11.Text = "Microphone"
		' 
		' button27
		' 
		Me.button27.Location = New System.Drawing.Point(11, 82)
		Me.button27.Name = "button27"
		Me.button27.Size = New System.Drawing.Size(75, 23)
		Me.button27.TabIndex = 3
		Me.button27.Text = "Enable"
		Me.button27.UseVisualStyleBackColor = True
		AddHandler Me.button27.Click, New System.EventHandler(AddressOf Me.button27_Click)
		' 
		' checkBoxForwardCallForBusy
		' 
		Me.checkBoxForwardCallForBusy.AutoSize = True
		Me.checkBoxForwardCallForBusy.Location = New System.Drawing.Point(10, 61)
		Me.checkBoxForwardCallForBusy.Name = "checkBoxForwardCallForBusy"
		Me.checkBoxForwardCallForBusy.Size = New System.Drawing.Size(160, 17)
		Me.checkBoxForwardCallForBusy.TabIndex = 2
		Me.checkBoxForwardCallForBusy.Text = "Forward call when on phone"
		Me.checkBoxForwardCallForBusy.UseVisualStyleBackColor = True
		' 
		' textBoxForwardTo
		' 
		Me.textBoxForwardTo.Location = New System.Drawing.Point(10, 35)
		Me.textBoxForwardTo.Name = "textBoxForwardTo"
		Me.textBoxForwardTo.Size = New System.Drawing.Size(158, 20)
		Me.textBoxForwardTo.TabIndex = 1
		' 
		' label16
		' 
		Me.label16.AutoSize = True
		Me.label16.Location = New System.Drawing.Point(7, 19)
		Me.label16.Name = "label16"
		Me.label16.Size = New System.Drawing.Size(79, 13)
		Me.label16.TabIndex = 0
		Me.label16.Text = "Forward call to:"
		' 
		' groupBox9
		' 
		Me.groupBox9.Controls.Add(Me.Button23)
		Me.groupBox9.Controls.Add(Me.Button21)
		Me.groupBox9.Controls.Add(Me.Button20)
		Me.groupBox9.Controls.Add(Me.TextBoxPlayFile)
		Me.groupBox9.Controls.Add(Me.Label27)
		Me.groupBox9.Location = New System.Drawing.Point(497, 525)
		Me.groupBox9.Name = "groupBox9"
		Me.groupBox9.Size = New System.Drawing.Size(203, 118)
		Me.groupBox9.TabIndex = 62
		Me.groupBox9.TabStop = False
		Me.groupBox9.Text = "Play audio file(Wave)"
		' 
		' Button23
		' 
		Me.Button23.Location = New System.Drawing.Point(108, 86)
		Me.Button23.Name = "Button23"
		Me.Button23.Size = New System.Drawing.Size(75, 22)
		Me.Button23.TabIndex = 12
		Me.Button23.Text = "Stop"
		Me.Button23.UseVisualStyleBackColor = True
		AddHandler Me.Button23.Click, New System.EventHandler(AddressOf Me.Button23_Click)
		' 
		' Button21
		' 
		Me.Button21.Location = New System.Drawing.Point(12, 86)
		Me.Button21.Name = "Button21"
		Me.Button21.Size = New System.Drawing.Size(75, 22)
		Me.Button21.TabIndex = 11
		Me.Button21.Text = "Start"
		Me.Button21.UseVisualStyleBackColor = True
		AddHandler Me.Button21.Click, New System.EventHandler(AddressOf Me.Button21_Click)
		' 
		' Button20
		' 
		Me.Button20.Location = New System.Drawing.Point(83, 19)
		Me.Button20.Name = "Button20"
		Me.Button20.Size = New System.Drawing.Size(69, 22)
		Me.Button20.TabIndex = 10
		Me.Button20.Text = "..."
		Me.Button20.UseVisualStyleBackColor = True
		AddHandler Me.Button20.Click, New System.EventHandler(AddressOf Me.Button20_Click)
		' 
		' TextBoxPlayFile
		' 
		Me.TextBoxPlayFile.Location = New System.Drawing.Point(6, 50)
		Me.TextBoxPlayFile.Name = "TextBoxPlayFile"
		Me.TextBoxPlayFile.[ReadOnly] = True
		Me.TextBoxPlayFile.Size = New System.Drawing.Size(182, 20)
		Me.TextBoxPlayFile.TabIndex = 9
		' 
		' Label27
		' 
		Me.Label27.AutoSize = True
		Me.Label27.Location = New System.Drawing.Point(10, 22)
		Me.Label27.Name = "Label27"
		Me.Label27.Size = New System.Drawing.Size(51, 13)
		Me.Label27.TabIndex = 8
		Me.Label27.Text = "select file"
		' 
		' OpenFileDialog1
		' 
		Me.OpenFileDialog1.DefaultExt = "wav"
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		Me.OpenFileDialog1.Title = "Select wave file"
		' 
		' Button18
		' 
		Me.Button18.Location = New System.Drawing.Point(319, 73)
		Me.Button18.Name = "Button18"
		Me.Button18.Size = New System.Drawing.Size(74, 22)
		Me.Button18.TabIndex = 13
		Me.Button18.Text = "StopRecord"
		Me.Button18.UseVisualStyleBackColor = True
		AddHandler Me.Button18.Click, New System.EventHandler(AddressOf Me.Button18_Click)
		' 
		' Button19
		' 
		Me.Button19.Location = New System.Drawing.Point(239, 73)
		Me.Button19.Name = "Button19"
		Me.Button19.Size = New System.Drawing.Size(75, 23)
		Me.Button19.TabIndex = 14
		Me.Button19.Text = "StartRecord"
		Me.Button19.UseVisualStyleBackColor = True
		AddHandler Me.Button19.Click, New System.EventHandler(AddressOf Me.Button19_Click)
		' 
		' button28
		' 
		Me.button28.Location = New System.Drawing.Point(93, 82)
		Me.button28.Name = "button28"
		Me.button28.Size = New System.Drawing.Size(75, 23)
		Me.button28.TabIndex = 4
		Me.button28.Text = "Disable"
		Me.button28.UseVisualStyleBackColor = True
		AddHandler Me.button28.Click, New System.EventHandler(AddressOf Me.button28_Click)
		' 
		' Button17
		' 
		Me.Button17.Location = New System.Drawing.Point(113, 22)
		Me.Button17.Name = "Button17"
		Me.Button17.Size = New System.Drawing.Size(40, 20)
		Me.Button17.TabIndex = 7
		Me.Button17.Text = "..."
		Me.Button17.UseVisualStyleBackColor = True
		AddHandler Me.Button17.Click, New System.EventHandler(AddressOf Me.Button17_Click)
		' 
		' checkBox1
		' 
		Me.checkBox1.AutoSize = True
		Me.checkBox1.Location = New System.Drawing.Point(208, 25)
		Me.checkBox1.Name = "checkBox1"
		Me.checkBox1.Size = New System.Drawing.Size(133, 17)
		Me.checkBox1.TabIndex = 12
		Me.checkBox1.Text = "Audio Stream Callback"
		Me.checkBox1.UseVisualStyleBackColor = True
		AddHandler Me.checkBox1.CheckedChanged, New System.EventHandler(AddressOf Me.checkBox1_CheckedChanged)
		' 
		' checkBoxAGC
		' 
		Me.checkBoxAGC.AutoSize = True
		Me.checkBoxAGC.Location = New System.Drawing.Point(278, 14)
		Me.checkBoxAGC.Name = "checkBoxAGC"
		Me.checkBoxAGC.Size = New System.Drawing.Size(48, 17)
		Me.checkBoxAGC.TabIndex = 71
		Me.checkBoxAGC.Text = "AGC"
		Me.checkBoxAGC.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxAGC.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxAGC_CheckedChanged)
		' 
		' checkBoxCNG
		' 
		Me.checkBoxCNG.AutoSize = True
		Me.checkBoxCNG.Location = New System.Drawing.Point(183, 14)
		Me.checkBoxCNG.Name = "checkBoxCNG"
		Me.checkBoxCNG.Size = New System.Drawing.Size(49, 17)
		Me.checkBoxCNG.TabIndex = 70
		Me.checkBoxCNG.Text = "CNG"
		Me.checkBoxCNG.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxCNG.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxCNG_CheckedChanged)
		' 
		' groupBox11
		' 
		Me.groupBox11.Controls.Add(Me.button28)
		Me.groupBox11.Controls.Add(Me.button27)
		Me.groupBox11.Controls.Add(Me.checkBoxForwardCallForBusy)
		Me.groupBox11.Controls.Add(Me.textBoxForwardTo)
		Me.groupBox11.Controls.Add(Me.label16)
		Me.groupBox11.Location = New System.Drawing.Point(750, 525)
		Me.groupBox11.Name = "groupBox11"
		Me.groupBox11.Size = New System.Drawing.Size(177, 118)
		Me.groupBox11.TabIndex = 61
		Me.groupBox11.TabStop = False
		Me.groupBox11.Text = "Call Forward"
		' 
		' checkBoxVAD
		' 
		Me.checkBoxVAD.AutoSize = True
		Me.checkBoxVAD.Location = New System.Drawing.Point(94, 14)
		Me.checkBoxVAD.Name = "checkBoxVAD"
		Me.checkBoxVAD.Size = New System.Drawing.Size(48, 17)
		Me.checkBoxVAD.TabIndex = 69
		Me.checkBoxVAD.Text = "VAD"
		Me.checkBoxVAD.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxVAD.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxVAD_CheckedChanged)
		' 
		' groupBox7
		' 
		Me.groupBox7.Controls.Add(Me.checkBoxANS)
		Me.groupBox7.Controls.Add(Me.checkBoxAGC)
		Me.groupBox7.Controls.Add(Me.checkBoxCNG)
		Me.groupBox7.Controls.Add(Me.checkBoxVAD)
		Me.groupBox7.Controls.Add(Me.checkBoxAEC)
		Me.groupBox7.Location = New System.Drawing.Point(497, 638)
		Me.groupBox7.Name = "groupBox7"
		Me.groupBox7.Size = New System.Drawing.Size(431, 42)
		Me.groupBox7.TabIndex = 59
		Me.groupBox7.TabStop = False
		' 
		' checkBoxANS
		' 
		Me.checkBoxANS.AutoSize = True
		Me.checkBoxANS.Location = New System.Drawing.Point(354, 14)
		Me.checkBoxANS.Name = "checkBoxANS"
		Me.checkBoxANS.Size = New System.Drawing.Size(48, 17)
		Me.checkBoxANS.TabIndex = 72
		Me.checkBoxANS.Text = "ANS"
		Me.checkBoxANS.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxANS.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxANS_CheckedChanged)
		' 
		' checkBoxAEC
		' 
		Me.checkBoxAEC.AutoSize = True
		Me.checkBoxAEC.Checked = True
		Me.checkBoxAEC.CheckState = System.Windows.Forms.CheckState.Checked
		Me.checkBoxAEC.Location = New System.Drawing.Point(12, 14)
		Me.checkBoxAEC.Name = "checkBoxAEC"
		Me.checkBoxAEC.Size = New System.Drawing.Size(47, 17)
		Me.checkBoxAEC.TabIndex = 68
		Me.checkBoxAEC.Text = "AEC"
		Me.checkBoxAEC.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxAEC.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxAEC_CheckedChanged)
		' 
		' TextBoxRecordFileName
		' 
		Me.TextBoxRecordFileName.Location = New System.Drawing.Point(131, 75)
		Me.TextBoxRecordFileName.Name = "TextBoxRecordFileName"
		Me.TextBoxRecordFileName.Size = New System.Drawing.Size(92, 20)
		Me.TextBoxRecordFileName.TabIndex = 3
		' 
		' groupBox8
		' 
		Me.groupBox8.Controls.Add(Me.Button18)
		Me.groupBox8.Controls.Add(Me.Button19)
		Me.groupBox8.Controls.Add(Me.checkBox1)
		Me.groupBox8.Controls.Add(Me.Button17)
		Me.groupBox8.Controls.Add(Me.TextBoxRecordFileName)
		Me.groupBox8.Controls.Add(Me.Label25)
		Me.groupBox8.Controls.Add(Me.TextBoxRecordFilePath)
		Me.groupBox8.Controls.Add(Me.Label26)
		Me.groupBox8.Location = New System.Drawing.Point(497, 407)
		Me.groupBox8.Name = "groupBox8"
		Me.groupBox8.Size = New System.Drawing.Size(431, 107)
		Me.groupBox8.TabIndex = 60
		Me.groupBox8.TabStop = False
		Me.groupBox8.Text = "Audio and Video Recording"
		' 
		' Label25
		' 
		Me.Label25.AutoSize = True
		Me.Label25.Location = New System.Drawing.Point(9, 80)
		Me.Label25.Name = "Label25"
		Me.Label25.Size = New System.Drawing.Size(87, 13)
		Me.Label25.TabIndex = 2
		Me.Label25.Text = "Record file name"
		' 
		' TextBoxRecordFilePath
		' 
		Me.TextBoxRecordFilePath.Location = New System.Drawing.Point(12, 48)
		Me.TextBoxRecordFilePath.Name = "TextBoxRecordFilePath"
		Me.TextBoxRecordFilePath.[ReadOnly] = True
		Me.TextBoxRecordFilePath.Size = New System.Drawing.Size(381, 20)
		Me.TextBoxRecordFilePath.TabIndex = 1
		' 
		' Label26
		' 
		Me.Label26.AutoSize = True
		Me.Label26.Location = New System.Drawing.Point(6, 27)
		Me.Label26.Name = "Label26"
		Me.Label26.Size = New System.Drawing.Size(101, 13)
		Me.Label26.TabIndex = 0
		Me.Label26.Text = "Record file directory"
		' 
		' Label19
		' 
		Me.Label19.AutoSize = True
		Me.Label19.Location = New System.Drawing.Point(224, 171)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(39, 13)
		Me.Label19.TabIndex = 101
		Me.Label19.Text = "Quality"
		' 
		' Label20
		' 
		Me.Label20.AutoSize = True
		Me.Label20.Location = New System.Drawing.Point(411, 169)
		Me.Label20.Name = "Label20"
		Me.Label20.Size = New System.Drawing.Size(28, 13)
		Me.Label20.TabIndex = 103
		Me.Label20.Text = "Best"
		' 
		' groupBox2
		' 
		Me.groupBox2.Controls.Add(Me.checkBoxMakeVideoCall)
		Me.groupBox2.Controls.Add(Me.checkBoxAnswerVideo)
		Me.groupBox2.Controls.Add(Me.checkBoxPRACK)
		Me.groupBox2.Controls.Add(Me.CheckBoxConf)
		Me.groupBox2.Controls.Add(Me.CheckBoxAA)
		Me.groupBox2.Controls.Add(Me.CheckBoxDND)
		Me.groupBox2.Controls.Add(Me.CheckBoxSDP)
		Me.groupBox2.Controls.Add(Me.button24)
		Me.groupBox2.Controls.Add(Me.Button16)
		Me.groupBox2.Controls.Add(Me.ButtonAnswer)
		Me.groupBox2.Controls.Add(Me.ButtonTransfer)
		Me.groupBox2.Controls.Add(Me.ButtonHold)
		Me.groupBox2.Controls.Add(Me.ComboBoxLines)
		Me.groupBox2.Controls.Add(Me.ButtonReject)
		Me.groupBox2.Controls.Add(Me.ButtonHangUp)
		Me.groupBox2.Controls.Add(Me.ButtonDial)
		Me.groupBox2.Controls.Add(Me.Button12)
		Me.groupBox2.Controls.Add(Me.Button13)
		Me.groupBox2.Controls.Add(Me.Button14)
		Me.groupBox2.Controls.Add(Me.Button9)
		Me.groupBox2.Controls.Add(Me.Button10)
		Me.groupBox2.Controls.Add(Me.Button11)
		Me.groupBox2.Controls.Add(Me.Button6)
		Me.groupBox2.Controls.Add(Me.Button7)
		Me.groupBox2.Controls.Add(Me.Button8)
		Me.groupBox2.Controls.Add(Me.Button5)
		Me.groupBox2.Controls.Add(Me.Button4)
		Me.groupBox2.Controls.Add(Me.Button3)
		Me.groupBox2.Controls.Add(Me.TextBoxPhoneNumber)
		Me.groupBox2.Location = New System.Drawing.Point(32, 169)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(445, 181)
		Me.groupBox2.TabIndex = 52
		Me.groupBox2.TabStop = False
		' 
		' checkBoxMakeVideoCall
		' 
		Me.checkBoxMakeVideoCall.AutoSize = True
		Me.checkBoxMakeVideoCall.Checked = True
		Me.checkBoxMakeVideoCall.CheckState = System.Windows.Forms.CheckState.Checked
		Me.checkBoxMakeVideoCall.Location = New System.Drawing.Point(202, 70)
		Me.checkBoxMakeVideoCall.Name = "checkBoxMakeVideoCall"
		Me.checkBoxMakeVideoCall.Size = New System.Drawing.Size(101, 17)
		Me.checkBoxMakeVideoCall.TabIndex = 130
		Me.checkBoxMakeVideoCall.Text = "Make video call"
		Me.checkBoxMakeVideoCall.UseVisualStyleBackColor = True
		' 
		' checkBoxAnswerVideo
		' 
		Me.checkBoxAnswerVideo.AutoSize = True
		Me.checkBoxAnswerVideo.Checked = True
		Me.checkBoxAnswerVideo.CheckState = System.Windows.Forms.CheckState.Checked
		Me.checkBoxAnswerVideo.Location = New System.Drawing.Point(317, 70)
		Me.checkBoxAnswerVideo.Name = "checkBoxAnswerVideo"
		Me.checkBoxAnswerVideo.Size = New System.Drawing.Size(109, 17)
		Me.checkBoxAnswerVideo.TabIndex = 129
		Me.checkBoxAnswerVideo.Text = "Answer video call"
		Me.checkBoxAnswerVideo.UseVisualStyleBackColor = True
		' 
		' checkBoxPRACK
		' 
		Me.checkBoxPRACK.AutoSize = True
		Me.checkBoxPRACK.Location = New System.Drawing.Point(348, 19)
		Me.checkBoxPRACK.Name = "checkBoxPRACK"
		Me.checkBoxPRACK.Size = New System.Drawing.Size(62, 17)
		Me.checkBoxPRACK.TabIndex = 128
		Me.checkBoxPRACK.Text = "PRACK"
		Me.checkBoxPRACK.UseVisualStyleBackColor = True
		AddHandler Me.checkBoxPRACK.CheckedChanged, New System.EventHandler(AddressOf Me.checkBoxPRACK_CheckedChanged)
		' 
		' CheckBoxConf
		' 
		Me.CheckBoxConf.AutoSize = True
		Me.CheckBoxConf.Location = New System.Drawing.Point(202, 50)
		Me.CheckBoxConf.Name = "CheckBoxConf"
		Me.CheckBoxConf.Size = New System.Drawing.Size(81, 17)
		Me.CheckBoxConf.TabIndex = 127
		Me.CheckBoxConf.Text = "Conference"
		Me.CheckBoxConf.UseVisualStyleBackColor = True
		AddHandler Me.CheckBoxConf.CheckedChanged, New System.EventHandler(AddressOf Me.CheckBoxConf_CheckedChanged)
		' 
		' CheckBoxAA
		' 
		Me.CheckBoxAA.AutoSize = True
		Me.CheckBoxAA.Location = New System.Drawing.Point(317, 50)
		Me.CheckBoxAA.Name = "CheckBoxAA"
		Me.CheckBoxAA.Size = New System.Drawing.Size(86, 17)
		Me.CheckBoxAA.TabIndex = 126
		Me.CheckBoxAA.Text = "Auto Answer"
		Me.CheckBoxAA.UseVisualStyleBackColor = True
		' 
		' CheckBoxDND
		' 
		Me.CheckBoxDND.AutoSize = True
		Me.CheckBoxDND.Location = New System.Drawing.Point(202, 33)
		Me.CheckBoxDND.Name = "CheckBoxDND"
		Me.CheckBoxDND.Size = New System.Drawing.Size(122, 17)
		Me.CheckBoxDND.TabIndex = 125
		Me.CheckBoxDND.Text = "Do not disturb(DND)"
		Me.CheckBoxDND.UseVisualStyleBackColor = True
		AddHandler Me.CheckBoxDND.CheckedChanged, New System.EventHandler(AddressOf Me.CheckBoxDND_CheckedChanged)
		' 
		' CheckBoxSDP
		' 
		Me.CheckBoxSDP.AutoSize = True
		Me.CheckBoxSDP.Location = New System.Drawing.Point(202, 16)
		Me.CheckBoxSDP.Name = "CheckBoxSDP"
		Me.CheckBoxSDP.Size = New System.Drawing.Size(134, 17)
		Me.CheckBoxSDP.TabIndex = 124
		Me.CheckBoxSDP.Text = "Make call without SDP"
		Me.CheckBoxSDP.UseVisualStyleBackColor = True
		' 
		' button24
		' 
		Me.button24.Location = New System.Drawing.Point(199, 143)
		Me.button24.Name = "button24"
		Me.button24.Size = New System.Drawing.Size(115, 23)
		Me.button24.TabIndex = 120
		Me.button24.Text = "Attend Transfer"
		Me.button24.UseVisualStyleBackColor = True
		AddHandler Me.button24.Click, New System.EventHandler(AddressOf Me.button24_Click)
		' 
		' Button16
		' 
		Me.Button16.Location = New System.Drawing.Point(259, 117)
		Me.Button16.Name = "Button16"
		Me.Button16.Size = New System.Drawing.Size(55, 23)
		Me.Button16.TabIndex = 119
		Me.Button16.Text = "UnHold"
		Me.Button16.UseVisualStyleBackColor = True
		AddHandler Me.Button16.Click, New System.EventHandler(AddressOf Me.Button16_Click)
		' 
		' ButtonAnswer
		' 
		Me.ButtonAnswer.Location = New System.Drawing.Point(319, 92)
		Me.ButtonAnswer.Name = "ButtonAnswer"
		Me.ButtonAnswer.Size = New System.Drawing.Size(55, 23)
		Me.ButtonAnswer.TabIndex = 114
		Me.ButtonAnswer.Text = "Answer"
		Me.ButtonAnswer.UseVisualStyleBackColor = True
		AddHandler Me.ButtonAnswer.Click, New System.EventHandler(AddressOf Me.ButtonAnswer_Click)
		' 
		' ButtonTransfer
		' 
		Me.ButtonTransfer.Location = New System.Drawing.Point(320, 117)
		Me.ButtonTransfer.Name = "ButtonTransfer"
		Me.ButtonTransfer.Size = New System.Drawing.Size(114, 23)
		Me.ButtonTransfer.TabIndex = 113
		Me.ButtonTransfer.Text = "Transfer"
		Me.ButtonTransfer.UseVisualStyleBackColor = True
		AddHandler Me.ButtonTransfer.Click, New System.EventHandler(AddressOf Me.ButtonTransfer_Click)
		' 
		' ButtonHold
		' 
		Me.ButtonHold.Location = New System.Drawing.Point(199, 117)
		Me.ButtonHold.Name = "ButtonHold"
		Me.ButtonHold.Size = New System.Drawing.Size(55, 23)
		Me.ButtonHold.TabIndex = 112
		Me.ButtonHold.Text = "Hold"
		Me.ButtonHold.UseVisualStyleBackColor = True
		AddHandler Me.ButtonHold.Click, New System.EventHandler(AddressOf Me.ButtonHold_Click)
		' 
		' ComboBoxLines
		' 
		Me.ComboBoxLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboBoxLines.FormattingEnabled = True
		Me.ComboBoxLines.Location = New System.Drawing.Point(8, 145)
		Me.ComboBoxLines.Name = "ComboBoxLines"
		Me.ComboBoxLines.Size = New System.Drawing.Size(183, 21)
		Me.ComboBoxLines.TabIndex = 111
		AddHandler Me.ComboBoxLines.SelectedIndexChanged, New System.EventHandler(AddressOf Me.ComboBoxLines_SelectedIndexChanged)
		' 
		' ButtonReject
		' 
		Me.ButtonReject.Location = New System.Drawing.Point(379, 92)
		Me.ButtonReject.Name = "ButtonReject"
		Me.ButtonReject.Size = New System.Drawing.Size(55, 23)
		Me.ButtonReject.TabIndex = 110
		Me.ButtonReject.Text = "Reject"
		Me.ButtonReject.UseVisualStyleBackColor = True
		AddHandler Me.ButtonReject.Click, New System.EventHandler(AddressOf Me.ButtonReject_Click)
		' 
		' ButtonHangUp
		' 
		Me.ButtonHangUp.Location = New System.Drawing.Point(259, 92)
		Me.ButtonHangUp.Name = "ButtonHangUp"
		Me.ButtonHangUp.Size = New System.Drawing.Size(55, 23)
		Me.ButtonHangUp.TabIndex = 109
		Me.ButtonHangUp.Text = "HangUp"
		Me.ButtonHangUp.UseVisualStyleBackColor = True
		AddHandler Me.ButtonHangUp.Click, New System.EventHandler(AddressOf Me.ButtonHangUp_Click)
		' 
		' ButtonDial
		' 
		Me.ButtonDial.Location = New System.Drawing.Point(199, 92)
		Me.ButtonDial.Name = "ButtonDial"
		Me.ButtonDial.Size = New System.Drawing.Size(55, 23)
		Me.ButtonDial.TabIndex = 108
		Me.ButtonDial.Text = "Dial"
		Me.ButtonDial.UseVisualStyleBackColor = True
		AddHandler Me.ButtonDial.Click, New System.EventHandler(AddressOf Me.ButtonDial_Click)
		' 
		' Button12
		' 
		Me.Button12.Location = New System.Drawing.Point(132, 117)
		Me.Button12.Name = "Button12"
		Me.Button12.Size = New System.Drawing.Size(60, 22)
		Me.Button12.TabIndex = 107
		Me.Button12.Text = "#"
		Me.Button12.UseVisualStyleBackColor = True
		AddHandler Me.Button12.Click, New System.EventHandler(AddressOf Me.Button12_Click)
		' 
		' Button13
		' 
		Me.Button13.Location = New System.Drawing.Point(70, 117)
		Me.Button13.Name = "Button13"
		Me.Button13.Size = New System.Drawing.Size(60, 22)
		Me.Button13.TabIndex = 106
		Me.Button13.Text = "0"
		Me.Button13.UseVisualStyleBackColor = True
		AddHandler Me.Button13.Click, New System.EventHandler(AddressOf Me.Button13_Click)
		' 
		' Button14
		' 
		Me.Button14.Location = New System.Drawing.Point(8, 117)
		Me.Button14.Name = "Button14"
		Me.Button14.Size = New System.Drawing.Size(60, 22)
		Me.Button14.TabIndex = 105
		Me.Button14.Text = "*"
		Me.Button14.UseVisualStyleBackColor = True
		AddHandler Me.Button14.Click, New System.EventHandler(AddressOf Me.Button14_Click)
		' 
		' Button9
		' 
		Me.Button9.Location = New System.Drawing.Point(132, 94)
		Me.Button9.Name = "Button9"
		Me.Button9.Size = New System.Drawing.Size(60, 22)
		Me.Button9.TabIndex = 104
		Me.Button9.Text = "9"
		Me.Button9.UseVisualStyleBackColor = True
		AddHandler Me.Button9.Click, New System.EventHandler(AddressOf Me.Button9_Click)
		' 
		' Button10
		' 
		Me.Button10.Location = New System.Drawing.Point(70, 94)
		Me.Button10.Name = "Button10"
		Me.Button10.Size = New System.Drawing.Size(60, 22)
		Me.Button10.TabIndex = 103
		Me.Button10.Text = "8"
		Me.Button10.UseVisualStyleBackColor = True
		AddHandler Me.Button10.Click, New System.EventHandler(AddressOf Me.Button10_Click)
		' 
		' Button11
		' 
		Me.Button11.Location = New System.Drawing.Point(8, 94)
		Me.Button11.Name = "Button11"
		Me.Button11.Size = New System.Drawing.Size(60, 22)
		Me.Button11.TabIndex = 102
		Me.Button11.Text = "7"
		Me.Button11.UseVisualStyleBackColor = True
		AddHandler Me.Button11.Click, New System.EventHandler(AddressOf Me.Button11_Click)
		' 
		' Button6
		' 
		Me.Button6.Location = New System.Drawing.Point(132, 71)
		Me.Button6.Name = "Button6"
		Me.Button6.Size = New System.Drawing.Size(60, 22)
		Me.Button6.TabIndex = 101
		Me.Button6.Text = "6"
		Me.Button6.UseVisualStyleBackColor = True
		AddHandler Me.Button6.Click, New System.EventHandler(AddressOf Me.Button6_Click)
		' 
		' Button7
		' 
		Me.Button7.Location = New System.Drawing.Point(70, 71)
		Me.Button7.Name = "Button7"
		Me.Button7.Size = New System.Drawing.Size(60, 22)
		Me.Button7.TabIndex = 100
		Me.Button7.Text = "5"
		Me.Button7.UseVisualStyleBackColor = True
		AddHandler Me.Button7.Click, New System.EventHandler(AddressOf Me.Button7_Click)
		' 
		' Button8
		' 
		Me.Button8.Location = New System.Drawing.Point(8, 71)
		Me.Button8.Name = "Button8"
		Me.Button8.Size = New System.Drawing.Size(60, 22)
		Me.Button8.TabIndex = 99
		Me.Button8.Text = "4"
		Me.Button8.UseVisualStyleBackColor = True
		AddHandler Me.Button8.Click, New System.EventHandler(AddressOf Me.Button8_Click)
		' 
		' Button5
		' 
		Me.Button5.Location = New System.Drawing.Point(132, 49)
		Me.Button5.Name = "Button5"
		Me.Button5.Size = New System.Drawing.Size(60, 22)
		Me.Button5.TabIndex = 98
		Me.Button5.Text = "3"
		Me.Button5.UseVisualStyleBackColor = True
		AddHandler Me.Button5.Click, New System.EventHandler(AddressOf Me.Button5_Click)
		' 
		' Button4
		' 
		Me.Button4.Location = New System.Drawing.Point(70, 49)
		Me.Button4.Name = "Button4"
		Me.Button4.Size = New System.Drawing.Size(60, 22)
		Me.Button4.TabIndex = 97
		Me.Button4.Text = "2"
		Me.Button4.UseVisualStyleBackColor = True
		AddHandler Me.Button4.Click, New System.EventHandler(AddressOf Me.Button4_Click)
		' 
		' Button3
		' 
		Me.Button3.Location = New System.Drawing.Point(8, 49)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(60, 22)
		Me.Button3.TabIndex = 96
		Me.Button3.Text = "1"
		Me.Button3.UseVisualStyleBackColor = True
		AddHandler Me.Button3.Click, New System.EventHandler(AddressOf Me.Button3_Click)
		' 
		' TextBoxPhoneNumber
		' 
		Me.TextBoxPhoneNumber.Location = New System.Drawing.Point(6, 19)
		Me.TextBoxPhoneNumber.Name = "TextBoxPhoneNumber"
		Me.TextBoxPhoneNumber.Size = New System.Drawing.Size(186, 20)
		Me.TextBoxPhoneNumber.TabIndex = 95
		' 
		' groupBox1
		' 
		Me.groupBox1.Controls.Add(Me.Label23)
		Me.groupBox1.Controls.Add(Me.ComboBoxSRTP)
		Me.groupBox1.Controls.Add(Me.textBoxLocalPort)
		Me.groupBox1.Controls.Add(Me.label3)
		Me.groupBox1.Controls.Add(Me.Button2)
		Me.groupBox1.Controls.Add(Me.Button1)
		Me.groupBox1.Controls.Add(Me.TextBoxPassword)
		Me.groupBox1.Controls.Add(Me.Label2)
		Me.groupBox1.Controls.Add(Me.TextBoxUserName)
		Me.groupBox1.Controls.Add(Me.Label1)
		Me.groupBox1.Location = New System.Drawing.Point(32, 27)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(445, 136)
		Me.groupBox1.TabIndex = 51
		Me.groupBox1.TabStop = False
		' 
		' Label23
		' 
		Me.Label23.AutoSize = True
		Me.Label23.Location = New System.Drawing.Point(34, 107)
		Me.Label23.Name = "Label23"
		Me.Label23.Size = New System.Drawing.Size(36, 13)
		Me.Label23.TabIndex = 101
		Me.Label23.Text = "SRTP"
		' 
		' ComboBoxSRTP
		' 
		Me.ComboBoxSRTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboBoxSRTP.FormattingEnabled = True
		Me.ComboBoxSRTP.Location = New System.Drawing.Point(96, 104)
		Me.ComboBoxSRTP.Name = "ComboBoxSRTP"
		Me.ComboBoxSRTP.Size = New System.Drawing.Size(63, 21)
		Me.ComboBoxSRTP.TabIndex = 100
		AddHandler Me.ComboBoxSRTP.SelectedIndexChanged, New System.EventHandler(AddressOf Me.ComboBoxSRTP_SelectedIndexChanged)
		' 
		' textBoxLocalPort
		' 
		Me.textBoxLocalPort.Location = New System.Drawing.Point(96, 78)
		Me.textBoxLocalPort.Name = "textBoxLocalPort"
		Me.textBoxLocalPort.Size = New System.Drawing.Size(218, 20)
		Me.textBoxLocalPort.TabIndex = 99
		Me.textBoxLocalPort.Text = "5060"
		' 
		' label3
		' 
		Me.label3.AutoSize = True
		Me.label3.Location = New System.Drawing.Point(19, 81)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(54, 13)
		Me.label3.TabIndex = 98
		Me.label3.Text = "Local port"
		' 
		' Button2
		' 
		Me.Button2.Location = New System.Drawing.Point(346, 78)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(75, 22)
		Me.Button2.TabIndex = 97
		Me.Button2.Text = "Uninitialize"
		Me.Button2.UseVisualStyleBackColor = True
		AddHandler Me.Button2.Click, New System.EventHandler(AddressOf Me.Button2_Click)
		' 
		' Button1
		' 
		Me.Button1.Location = New System.Drawing.Point(346, 41)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 22)
		Me.Button1.TabIndex = 96
		Me.Button1.Text = "Initialize"
		Me.Button1.UseVisualStyleBackColor = True
		AddHandler Me.Button1.Click, New System.EventHandler(AddressOf Me.Button1_Click)
		' 
		' TextBoxPassword
		' 
		Me.TextBoxPassword.Location = New System.Drawing.Point(96, 46)
		Me.TextBoxPassword.Name = "TextBoxPassword"
		Me.TextBoxPassword.PasswordChar = "*"C
		Me.TextBoxPassword.Size = New System.Drawing.Size(218, 20)
		Me.TextBoxPassword.TabIndex = 94
		' 
		' Label2
		' 
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(19, 50)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(53, 13)
		Me.Label2.TabIndex = 95
		Me.Label2.Text = "Password"
		' 
		' TextBoxUserName
		' 
		Me.TextBoxUserName.Location = New System.Drawing.Point(96, 20)
		Me.TextBoxUserName.Name = "TextBoxUserName"
		Me.TextBoxUserName.Size = New System.Drawing.Size(218, 20)
		Me.TextBoxUserName.TabIndex = 92
		' 
		' Label1
		' 
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(19, 24)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(55, 13)
		Me.Label1.TabIndex = 93
		Me.Label1.Text = "Username"
		' 
		' linkLabel1
		' 
		Me.linkLabel1.AutoSize = True
		Me.linkLabel1.Location = New System.Drawing.Point(29, 11)
		Me.linkLabel1.Name = "linkLabel1"
		Me.linkLabel1.Size = New System.Drawing.Size(172, 13)
		Me.linkLabel1.TabIndex = 49
		Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "Click here to learn more about PortSIP PBX/SIP Server"
		AddHandler Me.linkLabel1.LinkClicked, New System.Windows.Forms.LinkLabelLinkClickedEventHandler(AddressOf Me.linkLabel1_LinkClicked)
		' 
		' Label21
		' 
		Me.Label21.AutoSize = True
		Me.Label21.Location = New System.Drawing.Point(269, 171)
		Me.Label21.Name = "Label21"
		Me.Label21.Size = New System.Drawing.Size(40, 13)
		Me.Label21.TabIndex = 102
		Me.Label21.Text = "Normal"
		' 
		' groupBox3
		' 
		Me.groupBox3.Controls.Add(Me.ComboBoxCameras)
		Me.groupBox3.Controls.Add(Me.Label14)
		Me.groupBox3.Controls.Add(Me.ComboBoxMicrophones)
		Me.groupBox3.Controls.Add(Me.ComboBoxSpeakers)
		Me.groupBox3.Controls.Add(Me.Label12)
		Me.groupBox3.Controls.Add(Me.Label13)
		Me.groupBox3.Controls.Add(Me.CheckBoxMute)
		Me.groupBox3.Controls.Add(Me.TrackBarMicrophone)
		Me.groupBox3.Controls.Add(Me.Label11)
		Me.groupBox3.Controls.Add(Me.TrackBarSpeaker)
		Me.groupBox3.Controls.Add(Me.Label10)
		Me.groupBox3.Location = New System.Drawing.Point(497, 238)
		Me.groupBox3.Name = "groupBox3"
		Me.groupBox3.Size = New System.Drawing.Size(431, 157)
		Me.groupBox3.TabIndex = 53
		Me.groupBox3.TabStop = False
		' 
		' TrackBarSpeaker
		' 
		Me.TrackBarSpeaker.Location = New System.Drawing.Point(82, 8)
		Me.TrackBarSpeaker.Maximum = 255
		Me.TrackBarSpeaker.Name = "TrackBarSpeaker"
		Me.TrackBarSpeaker.Size = New System.Drawing.Size(214, 45)
		Me.TrackBarSpeaker.TabIndex = 47
		Me.TrackBarSpeaker.TickFrequency = 10
		Me.TrackBarSpeaker.TickStyle = System.Windows.Forms.TickStyle.None
		AddHandler Me.TrackBarSpeaker.ValueChanged, New System.EventHandler(AddressOf Me.TrackBarSpeaker_ValueChanged)
		' 
		' Label10
		' 
		Me.Label10.AutoSize = True
		Me.Label10.Location = New System.Drawing.Point(11, 17)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(47, 13)
		Me.Label10.TabIndex = 46
		Me.Label10.Text = "Speaker"
		' 
		' groupBox4
		' 
		Me.groupBox4.Controls.Add(Me.Label21)
		Me.groupBox4.Controls.Add(Me.Label20)
		Me.groupBox4.Controls.Add(Me.Label19)
		Me.groupBox4.Controls.Add(Me.ComboBoxVideoResolution)
		Me.groupBox4.Controls.Add(Me.Label18)
		Me.groupBox4.Controls.Add(Me.Button15)
		Me.groupBox4.Controls.Add(Me.ButtonSendVideo)
		Me.groupBox4.Controls.Add(Me.ButtonLocalVideo)
		Me.groupBox4.Controls.Add(Me.ButtonCameraOptions)
		Me.groupBox4.Controls.Add(Me.TrackBarVideoQuality)
		Me.groupBox4.Controls.Add(Me.remoteVideoPanel)
		Me.groupBox4.Controls.Add(Me.localVideoPanel)
		Me.groupBox4.Location = New System.Drawing.Point(32, 356)
		Me.groupBox4.Name = "groupBox4"
		Me.groupBox4.Size = New System.Drawing.Size(445, 224)
		Me.groupBox4.TabIndex = 54
		Me.groupBox4.TabStop = False
		' 
		' Form1
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(970, 687)
		Me.Controls.Add(Me.linkLabel2)
		Me.Controls.Add(Me.Button22)
		Me.Controls.Add(Me.groupBox5)
		Me.Controls.Add(Me.ListBoxSIPLog)
		Me.Controls.Add(Me.groupBox6)
		Me.Controls.Add(Me.groupBox9)
		Me.Controls.Add(Me.groupBox11)
		Me.Controls.Add(Me.groupBox7)
		Me.Controls.Add(Me.groupBox8)
		Me.Controls.Add(Me.groupBox2)
		Me.Controls.Add(Me.groupBox1)
		Me.Controls.Add(Me.linkLabel1)
		Me.Controls.Add(Me.groupBox3)
		Me.Controls.Add(Me.groupBox4)
		Me.MaximizeBox = False
		Me.Name = "Form1"
		Me.Text = "PortSIP P2PSample"
		AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
		AddHandler Me.FormClosing, New System.Windows.Forms.FormClosingEventHandler(AddressOf Me.Form1_FormClosing)
		Me.groupBox5.ResumeLayout(False)
		Me.groupBox5.PerformLayout()
		DirectCast(Me.TrackBarVideoQuality, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.TrackBarMicrophone, System.ComponentModel.ISupportInitialize).EndInit()
		Me.groupBox6.ResumeLayout(False)
		Me.groupBox6.PerformLayout()
		Me.groupBox9.ResumeLayout(False)
		Me.groupBox9.PerformLayout()
		Me.groupBox11.ResumeLayout(False)
		Me.groupBox11.PerformLayout()
		Me.groupBox7.ResumeLayout(False)
		Me.groupBox7.PerformLayout()
		Me.groupBox8.ResumeLayout(False)
		Me.groupBox8.PerformLayout()
		Me.groupBox2.ResumeLayout(False)
		Me.groupBox2.PerformLayout()
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox1.PerformLayout()
		Me.groupBox3.ResumeLayout(False)
		Me.groupBox3.PerformLayout()
		DirectCast(Me.TrackBarSpeaker, System.ComponentModel.ISupportInitialize).EndInit()
		Me.groupBox4.ResumeLayout(False)
		Me.groupBox4.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Friend CheckBoxSpeex As System.Windows.Forms.CheckBox
	Private linkLabel2 As System.Windows.Forms.LinkLabel
	Friend CheckBoxG722 As System.Windows.Forms.CheckBox
	Friend ButtonLocalVideo As System.Windows.Forms.Button
	Private checkBoxAMR As System.Windows.Forms.CheckBox
	Friend ButtonCameraOptions As System.Windows.Forms.Button
	Friend CheckBoxG7221 As System.Windows.Forms.CheckBox
	Friend CheckBoxSpeexWB As System.Windows.Forms.CheckBox
	Friend CheckBoxAMRwb As System.Windows.Forms.CheckBox
	Private checkBoxGSM As System.Windows.Forms.CheckBox
	Friend ComboBoxVideoResolution As System.Windows.Forms.ComboBox
	Friend Button22 As System.Windows.Forms.Button
	Friend Label18 As System.Windows.Forms.Label
	Private checkBoxILBC As System.Windows.Forms.CheckBox
	Friend Button15 As System.Windows.Forms.Button
	Friend ButtonSendVideo As System.Windows.Forms.Button
	Private checkBoxG729 As System.Windows.Forms.CheckBox
	Private groupBox5 As System.Windows.Forms.GroupBox
	Private checkBoxPCMA As System.Windows.Forms.CheckBox
	Private checkBoxPCMU As System.Windows.Forms.CheckBox
	Friend ComboBoxCameras As System.Windows.Forms.ComboBox
	Private ListBoxSIPLog As System.Windows.Forms.ListBox
	Friend Label14 As System.Windows.Forms.Label
	Friend ComboBoxMicrophones As System.Windows.Forms.ComboBox
	Friend TrackBarVideoQuality As System.Windows.Forms.TrackBar
	Friend ComboBoxSpeakers As System.Windows.Forms.ComboBox
	Friend Label12 As System.Windows.Forms.Label
	Private localVideoPanel As System.Windows.Forms.Panel
	Friend Label13 As System.Windows.Forms.Label
	Friend CheckBoxMute As System.Windows.Forms.CheckBox
	Private remoteVideoPanel As System.Windows.Forms.Panel
	Friend TrackBarMicrophone As System.Windows.Forms.TrackBar
	Private groupBox6 As System.Windows.Forms.GroupBox
	Private checkBoxH264 As System.Windows.Forms.CheckBox
	Private checkBoxH2631998 As System.Windows.Forms.CheckBox
	Private checkBoxH263 As System.Windows.Forms.CheckBox
	Friend Label11 As System.Windows.Forms.Label
	Private button27 As System.Windows.Forms.Button
	Private checkBoxForwardCallForBusy As System.Windows.Forms.CheckBox
	Private textBoxForwardTo As System.Windows.Forms.TextBox
	Private label16 As System.Windows.Forms.Label
	Friend groupBox9 As System.Windows.Forms.GroupBox
	Friend Button23 As System.Windows.Forms.Button
	Friend Button21 As System.Windows.Forms.Button
	Friend Button20 As System.Windows.Forms.Button
	Friend TextBoxPlayFile As System.Windows.Forms.TextBox
	Friend Label27 As System.Windows.Forms.Label
	Friend OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
	Friend Button18 As System.Windows.Forms.Button
	Friend Button19 As System.Windows.Forms.Button
	Private button28 As System.Windows.Forms.Button
	Friend Button17 As System.Windows.Forms.Button
	Private checkBox1 As System.Windows.Forms.CheckBox
	Private checkBoxAGC As System.Windows.Forms.CheckBox
	Private checkBoxCNG As System.Windows.Forms.CheckBox
	Private groupBox11 As System.Windows.Forms.GroupBox
	Private checkBoxVAD As System.Windows.Forms.CheckBox
	Private groupBox7 As System.Windows.Forms.GroupBox
	Private checkBoxAEC As System.Windows.Forms.CheckBox
	Friend TextBoxRecordFileName As System.Windows.Forms.TextBox
	Friend groupBox8 As System.Windows.Forms.GroupBox
	Friend Label25 As System.Windows.Forms.Label
	Friend TextBoxRecordFilePath As System.Windows.Forms.TextBox
	Friend Label26 As System.Windows.Forms.Label
	Friend Label19 As System.Windows.Forms.Label
	Friend Label20 As System.Windows.Forms.Label
	Private groupBox2 As System.Windows.Forms.GroupBox
	Friend button24 As System.Windows.Forms.Button
	Friend Button16 As System.Windows.Forms.Button
	Friend ButtonAnswer As System.Windows.Forms.Button
	Friend ButtonTransfer As System.Windows.Forms.Button
	Friend ButtonHold As System.Windows.Forms.Button
	Friend ComboBoxLines As System.Windows.Forms.ComboBox
	Friend ButtonReject As System.Windows.Forms.Button
	Friend ButtonHangUp As System.Windows.Forms.Button
	Friend ButtonDial As System.Windows.Forms.Button
	Friend Button12 As System.Windows.Forms.Button
	Friend Button13 As System.Windows.Forms.Button
	Friend Button14 As System.Windows.Forms.Button
	Friend Button9 As System.Windows.Forms.Button
	Friend Button10 As System.Windows.Forms.Button
	Friend Button11 As System.Windows.Forms.Button
	Friend Button6 As System.Windows.Forms.Button
	Friend Button7 As System.Windows.Forms.Button
	Friend Button8 As System.Windows.Forms.Button
	Friend Button5 As System.Windows.Forms.Button
	Friend Button4 As System.Windows.Forms.Button
	Friend Button3 As System.Windows.Forms.Button
	Friend TextBoxPhoneNumber As System.Windows.Forms.TextBox
	Private groupBox1 As System.Windows.Forms.GroupBox
	Private linkLabel1 As System.Windows.Forms.LinkLabel
	Friend Label21 As System.Windows.Forms.Label
	Private groupBox3 As System.Windows.Forms.GroupBox
	Friend TrackBarSpeaker As System.Windows.Forms.TrackBar
	Friend Label10 As System.Windows.Forms.Label
	Private groupBox4 As System.Windows.Forms.GroupBox
	Friend FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
	Friend Label23 As System.Windows.Forms.Label
	Friend ComboBoxSRTP As System.Windows.Forms.ComboBox
	Private textBoxLocalPort As System.Windows.Forms.TextBox
	Private label3 As System.Windows.Forms.Label
	Friend Button2 As System.Windows.Forms.Button
	Friend Button1 As System.Windows.Forms.Button
	Friend TextBoxPassword As System.Windows.Forms.TextBox
	Friend Label2 As System.Windows.Forms.Label
	Friend TextBoxUserName As System.Windows.Forms.TextBox
	Friend Label1 As System.Windows.Forms.Label
	Private checkBoxVP8 As System.Windows.Forms.CheckBox
	Private checkBoxPRACK As System.Windows.Forms.CheckBox
	Friend CheckBoxConf As System.Windows.Forms.CheckBox
	Friend CheckBoxAA As System.Windows.Forms.CheckBox
	Friend CheckBoxDND As System.Windows.Forms.CheckBox
	Friend CheckBoxSDP As System.Windows.Forms.CheckBox
	Friend checkBoxMakeVideoCall As System.Windows.Forms.CheckBox
	Friend checkBoxAnswerVideo As System.Windows.Forms.CheckBox
	Friend checkBoxOpus As System.Windows.Forms.CheckBox
	Private checkBoxANS As System.Windows.Forms.CheckBox
End Class

