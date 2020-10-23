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
        Me.linkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxNeedRegister = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ComboBoxTransport = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ComboBoxSRTP = New System.Windows.Forms.ComboBox()
        Me.TextBoxUserDomain = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxAuthName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxDisplayName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBoxStunPort = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxStunServer = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxServerPort = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxServer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxUserName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.checkBoxAnswerVideo = New System.Windows.Forms.CheckBox()
        Me.checkBoxMakeVideo = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPRACK = New System.Windows.Forms.CheckBox()
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
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.ComboBoxCameras = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBoxMicrophones = New System.Windows.Forms.ComboBox()
        Me.ComboBoxSpeakers = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CheckBoxMute = New System.Windows.Forms.CheckBox()
        Me.TrackBarMicrophone = New System.Windows.Forms.TrackBar()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TrackBarSpeaker = New System.Windows.Forms.TrackBar()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ComboBoxVideoResolution = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.ButtonSendVideo = New System.Windows.Forms.Button()
        Me.ButtonLocalVideo = New System.Windows.Forms.Button()
        Me.ButtonCameraOptions = New System.Windows.Forms.Button()
        Me.TrackBarVideoQuality = New System.Windows.Forms.TrackBar()
        Me.remoteVideoPanel = New System.Windows.Forms.Panel()
        Me.localVideoPanel = New System.Windows.Forms.Panel()
        Me.ListBoxSIPLog = New System.Windows.Forms.ListBox()
        Me.groupBox5 = New System.Windows.Forms.GroupBox()
        Me.checkBoxOPUS = New System.Windows.Forms.CheckBox()
        Me.CheckBoxVP8 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxH264 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxG7221 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxH2631998 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSpeexWB = New System.Windows.Forms.CheckBox()
        Me.CheckBoxH263 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxAMRwb = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSpeex = New System.Windows.Forms.CheckBox()
        Me.CheckBoxG722 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxAMR = New System.Windows.Forms.CheckBox()
        Me.CheckBoxGSM = New System.Windows.Forms.CheckBox()
        Me.CheckBoxILBC = New System.Windows.Forms.CheckBox()
        Me.CheckBoxG729 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPCMA = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPCMU = New System.Windows.Forms.CheckBox()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.groupBox7 = New System.Windows.Forms.GroupBox()
        Me.checkBoxNACK = New System.Windows.Forms.CheckBox()
        Me.CheckBoxANS = New System.Windows.Forms.CheckBox()
        Me.CheckBoxAGC = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCNG = New System.Windows.Forms.CheckBox()
        Me.CheckBoxVAD = New System.Windows.Forms.CheckBox()
        Me.CheckBoxAEC = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.groupBox8 = New System.Windows.Forms.GroupBox()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.TextBoxRecordFileName = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBoxRecordFilePath = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.groupBox11 = New System.Windows.Forms.GroupBox()
        Me.button28 = New System.Windows.Forms.Button()
        Me.button27 = New System.Windows.Forms.Button()
        Me.CheckBoxForwardCallForBusy = New System.Windows.Forms.CheckBox()
        Me.textBoxForwardTo = New System.Windows.Forms.TextBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.groupBox9 = New System.Windows.Forms.GroupBox()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.TextBoxPlayFile = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.CheckBoxVP9 = New System.Windows.Forms.CheckBox()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        CType(Me.TrackBarMicrophone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarSpeaker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox4.SuspendLayout()
        CType(Me.TrackBarVideoQuality, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox5.SuspendLayout()
        Me.groupBox7.SuspendLayout()
        Me.groupBox8.SuspendLayout()
        Me.groupBox11.SuspendLayout()
        Me.groupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'linkLabel2
        '
        Me.linkLabel2.AutoSize = True
        Me.linkLabel2.Location = New System.Drawing.Point(1114, 14)
        Me.linkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.linkLabel2.Name = "linkLabel2"
        Me.linkLabel2.Size = New System.Drawing.Size(253, 20)
        Me.linkLabel2.TabIndex = 36
        Me.linkLabel2.TabStop = True
        Me.linkLabel2.Text = "Click here to send email to PortSIP"
        '
        'linkLabel1
        '
        Me.linkLabel1.AutoSize = True
        Me.linkLabel1.Location = New System.Drawing.Point(18, 14)
        Me.linkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(395, 20)
        Me.linkLabel1.TabIndex = 35
        Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "Click here to learn more about PortSIP PBX/SIP Server"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.CheckBoxNeedRegister)
        Me.groupBox1.Controls.Add(Me.Label22)
        Me.groupBox1.Controls.Add(Me.ComboBoxTransport)
        Me.groupBox1.Controls.Add(Me.Label23)
        Me.groupBox1.Controls.Add(Me.ComboBoxSRTP)
        Me.groupBox1.Controls.Add(Me.TextBoxUserDomain)
        Me.groupBox1.Controls.Add(Me.Label9)
        Me.groupBox1.Controls.Add(Me.TextBoxAuthName)
        Me.groupBox1.Controls.Add(Me.Label5)
        Me.groupBox1.Controls.Add(Me.TextBoxDisplayName)
        Me.groupBox1.Controls.Add(Me.Label6)
        Me.groupBox1.Controls.Add(Me.Button2)
        Me.groupBox1.Controls.Add(Me.Button1)
        Me.groupBox1.Controls.Add(Me.TextBoxStunPort)
        Me.groupBox1.Controls.Add(Me.Label7)
        Me.groupBox1.Controls.Add(Me.TextBoxStunServer)
        Me.groupBox1.Controls.Add(Me.Label8)
        Me.groupBox1.Controls.Add(Me.TextBoxServerPort)
        Me.groupBox1.Controls.Add(Me.Label3)
        Me.groupBox1.Controls.Add(Me.TextBoxServer)
        Me.groupBox1.Controls.Add(Me.Label4)
        Me.groupBox1.Controls.Add(Me.TextBoxPassword)
        Me.groupBox1.Controls.Add(Me.Label2)
        Me.groupBox1.Controls.Add(Me.TextBoxUserName)
        Me.groupBox1.Controls.Add(Me.Label1)
        Me.groupBox1.Location = New System.Drawing.Point(22, 38)
        Me.groupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox1.Size = New System.Drawing.Size(668, 260)
        Me.groupBox1.TabIndex = 37
        Me.groupBox1.TabStop = False
        '
        'CheckBoxNeedRegister
        '
        Me.CheckBoxNeedRegister.AutoSize = True
        Me.CheckBoxNeedRegister.Checked = True
        Me.CheckBoxNeedRegister.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxNeedRegister.Location = New System.Drawing.Point(416, 183)
        Me.CheckBoxNeedRegister.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxNeedRegister.Name = "CheckBoxNeedRegister"
        Me.CheckBoxNeedRegister.Size = New System.Drawing.Size(160, 24)
        Me.CheckBoxNeedRegister.TabIndex = 125
        Me.CheckBoxNeedRegister.Text = "Register to server"
        Me.CheckBoxNeedRegister.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(18, 211)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(81, 20)
        Me.Label22.TabIndex = 124
        Me.Label22.Text = "Transport:"
        '
        'ComboBoxTransport
        '
        Me.ComboBoxTransport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTransport.FormattingEnabled = True
        Me.ComboBoxTransport.Location = New System.Drawing.Point(108, 205)
        Me.ComboBoxTransport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBoxTransport.Name = "ComboBoxTransport"
        Me.ComboBoxTransport.Size = New System.Drawing.Size(94, 28)
        Me.ComboBoxTransport.TabIndex = 123
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(213, 211)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 20)
        Me.Label23.TabIndex = 122
        Me.Label23.Text = "SRTP"
        '
        'ComboBoxSRTP
        '
        Me.ComboBoxSRTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSRTP.FormattingEnabled = True
        Me.ComboBoxSRTP.Location = New System.Drawing.Point(272, 203)
        Me.ComboBoxSRTP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBoxSRTP.Name = "ComboBoxSRTP"
        Me.ComboBoxSRTP.Size = New System.Drawing.Size(92, 28)
        Me.ComboBoxSRTP.TabIndex = 121
        '
        'TextBoxUserDomain
        '
        Me.TextBoxUserDomain.Location = New System.Drawing.Point(126, 80)
        Me.TextBoxUserDomain.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxUserDomain.Name = "TextBoxUserDomain"
        Me.TextBoxUserDomain.Size = New System.Drawing.Size(196, 26)
        Me.TextBoxUserDomain.TabIndex = 108
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 86)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 20)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "User Domain"
        '
        'TextBoxAuthName
        '
        Me.TextBoxAuthName.Location = New System.Drawing.Point(453, 49)
        Me.TextBoxAuthName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxAuthName.Name = "TextBoxAuthName"
        Me.TextBoxAuthName.Size = New System.Drawing.Size(196, 26)
        Me.TextBoxAuthName.TabIndex = 106
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(354, 55)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 20)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "Auth Name"
        '
        'TextBoxDisplayName
        '
        Me.TextBoxDisplayName.Location = New System.Drawing.Point(126, 49)
        Me.TextBoxDisplayName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxDisplayName.Name = "TextBoxDisplayName"
        Me.TextBoxDisplayName.Size = New System.Drawing.Size(196, 26)
        Me.TextBoxDisplayName.TabIndex = 104
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 55)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 20)
        Me.Label6.TabIndex = 118
        Me.Label6.Text = "Display Name"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(537, 215)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 34)
        Me.Button2.TabIndex = 117
        Me.Button2.Text = "Offline"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(416, 217)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 34)
        Me.Button1.TabIndex = 116
        Me.Button1.Text = "Online"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBoxStunPort
        '
        Me.TextBoxStunPort.Location = New System.Drawing.Point(453, 142)
        Me.TextBoxStunPort.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxStunPort.Name = "TextBoxStunPort"
        Me.TextBoxStunPort.Size = New System.Drawing.Size(196, 26)
        Me.TextBoxStunPort.TabIndex = 114
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(399, 148)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 20)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "Port"
        '
        'TextBoxStunServer
        '
        Me.TextBoxStunServer.Location = New System.Drawing.Point(126, 142)
        Me.TextBoxStunServer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxStunServer.Name = "TextBoxStunServer"
        Me.TextBoxStunServer.Size = New System.Drawing.Size(196, 26)
        Me.TextBoxStunServer.TabIndex = 112
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 148)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 20)
        Me.Label8.TabIndex = 113
        Me.Label8.Text = "Stun Server"
        '
        'TextBoxServerPort
        '
        Me.TextBoxServerPort.Location = New System.Drawing.Point(453, 111)
        Me.TextBoxServerPort.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxServerPort.Name = "TextBoxServerPort"
        Me.TextBoxServerPort.Size = New System.Drawing.Size(196, 26)
        Me.TextBoxServerPort.TabIndex = 110
        Me.TextBoxServerPort.Text = "5060"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(348, 117)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Server Port"
        '
        'TextBoxServer
        '
        Me.TextBoxServer.Location = New System.Drawing.Point(126, 111)
        Me.TextBoxServer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxServer.Name = "TextBoxServer"
        Me.TextBoxServer.Size = New System.Drawing.Size(196, 26)
        Me.TextBoxServer.TabIndex = 109
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 117)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 20)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "SIP Server"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Location = New System.Drawing.Point(453, 18)
        Me.TextBoxPassword.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.Size = New System.Drawing.Size(196, 26)
        Me.TextBoxPassword.TabIndex = 103
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(364, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Password"
        '
        'TextBoxUserName
        '
        Me.TextBoxUserName.Location = New System.Drawing.Point(126, 18)
        Me.TextBoxUserName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxUserName.Name = "TextBoxUserName"
        Me.TextBoxUserName.Size = New System.Drawing.Size(196, 26)
        Me.TextBoxUserName.TabIndex = 101
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Username"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.checkBoxAnswerVideo)
        Me.groupBox2.Controls.Add(Me.checkBoxMakeVideo)
        Me.groupBox2.Controls.Add(Me.CheckBoxPRACK)
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
        Me.groupBox2.Location = New System.Drawing.Point(22, 297)
        Me.groupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox2.Size = New System.Drawing.Size(668, 262)
        Me.groupBox2.TabIndex = 38
        Me.groupBox2.TabStop = False
        '
        'checkBoxAnswerVideo
        '
        Me.checkBoxAnswerVideo.AutoSize = True
        Me.checkBoxAnswerVideo.Checked = True
        Me.checkBoxAnswerVideo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBoxAnswerVideo.Location = New System.Drawing.Point(502, 106)
        Me.checkBoxAnswerVideo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.checkBoxAnswerVideo.Name = "checkBoxAnswerVideo"
        Me.checkBoxAnswerVideo.Size = New System.Drawing.Size(156, 24)
        Me.checkBoxAnswerVideo.TabIndex = 128
        Me.checkBoxAnswerVideo.Text = "Answer video call"
        Me.checkBoxAnswerVideo.UseVisualStyleBackColor = True
        '
        'checkBoxMakeVideo
        '
        Me.checkBoxMakeVideo.AutoSize = True
        Me.checkBoxMakeVideo.Checked = True
        Me.checkBoxMakeVideo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBoxMakeVideo.Location = New System.Drawing.Point(297, 106)
        Me.checkBoxMakeVideo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.checkBoxMakeVideo.Name = "checkBoxMakeVideo"
        Me.checkBoxMakeVideo.Size = New System.Drawing.Size(142, 24)
        Me.checkBoxMakeVideo.TabIndex = 127
        Me.checkBoxMakeVideo.Text = "Make video call"
        Me.checkBoxMakeVideo.UseVisualStyleBackColor = True
        '
        'CheckBoxPRACK
        '
        Me.CheckBoxPRACK.AutoSize = True
        Me.CheckBoxPRACK.Location = New System.Drawing.Point(507, 31)
        Me.CheckBoxPRACK.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxPRACK.Name = "CheckBoxPRACK"
        Me.CheckBoxPRACK.Size = New System.Drawing.Size(89, 24)
        Me.CheckBoxPRACK.TabIndex = 126
        Me.CheckBoxPRACK.Text = "PRACK"
        Me.CheckBoxPRACK.UseVisualStyleBackColor = True
        '
        'CheckBoxConf
        '
        Me.CheckBoxConf.AutoSize = True
        Me.CheckBoxConf.Location = New System.Drawing.Point(297, 80)
        Me.CheckBoxConf.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxConf.Name = "CheckBoxConf"
        Me.CheckBoxConf.Size = New System.Drawing.Size(118, 24)
        Me.CheckBoxConf.TabIndex = 125
        Me.CheckBoxConf.Text = "Conference"
        Me.CheckBoxConf.UseVisualStyleBackColor = True
        '
        'CheckBoxAA
        '
        Me.CheckBoxAA.AutoSize = True
        Me.CheckBoxAA.Location = New System.Drawing.Point(502, 66)
        Me.CheckBoxAA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxAA.Name = "CheckBoxAA"
        Me.CheckBoxAA.Size = New System.Drawing.Size(126, 24)
        Me.CheckBoxAA.TabIndex = 124
        Me.CheckBoxAA.Text = "Auto Answer"
        Me.CheckBoxAA.UseVisualStyleBackColor = True
        '
        'CheckBoxDND
        '
        Me.CheckBoxDND.AutoSize = True
        Me.CheckBoxDND.Location = New System.Drawing.Point(297, 52)
        Me.CheckBoxDND.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxDND.Name = "CheckBoxDND"
        Me.CheckBoxDND.Size = New System.Drawing.Size(180, 24)
        Me.CheckBoxDND.TabIndex = 123
        Me.CheckBoxDND.Text = "Do not disturb(DND)"
        Me.CheckBoxDND.UseVisualStyleBackColor = True
        '
        'CheckBoxSDP
        '
        Me.CheckBoxSDP.AutoSize = True
        Me.CheckBoxSDP.Location = New System.Drawing.Point(297, 26)
        Me.CheckBoxSDP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxSDP.Name = "CheckBoxSDP"
        Me.CheckBoxSDP.Size = New System.Drawing.Size(193, 24)
        Me.CheckBoxSDP.TabIndex = 122
        Me.CheckBoxSDP.Text = "Make call without SDP"
        Me.CheckBoxSDP.UseVisualStyleBackColor = True
        '
        'button24
        '
        Me.button24.Location = New System.Drawing.Point(297, 212)
        Me.button24.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.button24.Name = "button24"
        Me.button24.Size = New System.Drawing.Size(172, 35)
        Me.button24.TabIndex = 120
        Me.button24.Text = "Attend Transfer"
        Me.button24.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(387, 172)
        Me.Button16.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(82, 35)
        Me.Button16.TabIndex = 119
        Me.Button16.Text = "UnHold"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'ButtonAnswer
        '
        Me.ButtonAnswer.Location = New System.Drawing.Point(477, 134)
        Me.ButtonAnswer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonAnswer.Name = "ButtonAnswer"
        Me.ButtonAnswer.Size = New System.Drawing.Size(82, 35)
        Me.ButtonAnswer.TabIndex = 114
        Me.ButtonAnswer.Text = "Answer"
        Me.ButtonAnswer.UseVisualStyleBackColor = True
        '
        'ButtonTransfer
        '
        Me.ButtonTransfer.Location = New System.Drawing.Point(478, 172)
        Me.ButtonTransfer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonTransfer.Name = "ButtonTransfer"
        Me.ButtonTransfer.Size = New System.Drawing.Size(171, 35)
        Me.ButtonTransfer.TabIndex = 113
        Me.ButtonTransfer.Text = "Transfer"
        Me.ButtonTransfer.UseVisualStyleBackColor = True
        '
        'ButtonHold
        '
        Me.ButtonHold.Location = New System.Drawing.Point(297, 172)
        Me.ButtonHold.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonHold.Name = "ButtonHold"
        Me.ButtonHold.Size = New System.Drawing.Size(82, 35)
        Me.ButtonHold.TabIndex = 112
        Me.ButtonHold.Text = "Hold"
        Me.ButtonHold.UseVisualStyleBackColor = True
        '
        'ComboBoxLines
        '
        Me.ComboBoxLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLines.FormattingEnabled = True
        Me.ComboBoxLines.Location = New System.Drawing.Point(10, 220)
        Me.ComboBoxLines.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBoxLines.Name = "ComboBoxLines"
        Me.ComboBoxLines.Size = New System.Drawing.Size(272, 28)
        Me.ComboBoxLines.TabIndex = 111
        '
        'ButtonReject
        '
        Me.ButtonReject.Location = New System.Drawing.Point(567, 134)
        Me.ButtonReject.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonReject.Name = "ButtonReject"
        Me.ButtonReject.Size = New System.Drawing.Size(82, 35)
        Me.ButtonReject.TabIndex = 110
        Me.ButtonReject.Text = "Reject"
        Me.ButtonReject.UseVisualStyleBackColor = True
        '
        'ButtonHangUp
        '
        Me.ButtonHangUp.Location = New System.Drawing.Point(387, 134)
        Me.ButtonHangUp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonHangUp.Name = "ButtonHangUp"
        Me.ButtonHangUp.Size = New System.Drawing.Size(82, 35)
        Me.ButtonHangUp.TabIndex = 109
        Me.ButtonHangUp.Text = "HangUp"
        Me.ButtonHangUp.UseVisualStyleBackColor = True
        '
        'ButtonDial
        '
        Me.ButtonDial.Location = New System.Drawing.Point(297, 134)
        Me.ButtonDial.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonDial.Name = "ButtonDial"
        Me.ButtonDial.Size = New System.Drawing.Size(82, 35)
        Me.ButtonDial.TabIndex = 108
        Me.ButtonDial.Text = "Dial"
        Me.ButtonDial.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(196, 177)
        Me.Button12.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(90, 34)
        Me.Button12.TabIndex = 107
        Me.Button12.Text = "#"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(104, 177)
        Me.Button13.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(90, 34)
        Me.Button13.TabIndex = 106
        Me.Button13.Text = "0"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(10, 177)
        Me.Button14.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(90, 34)
        Me.Button14.TabIndex = 105
        Me.Button14.Text = "*"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(196, 142)
        Me.Button9.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(90, 34)
        Me.Button9.TabIndex = 104
        Me.Button9.Text = "9"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(104, 142)
        Me.Button10.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(90, 34)
        Me.Button10.TabIndex = 103
        Me.Button10.Text = "8"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(10, 142)
        Me.Button11.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(90, 34)
        Me.Button11.TabIndex = 102
        Me.Button11.Text = "7"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(196, 106)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(90, 34)
        Me.Button6.TabIndex = 101
        Me.Button6.Text = "6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(104, 106)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(90, 34)
        Me.Button7.TabIndex = 100
        Me.Button7.Text = "5"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(10, 106)
        Me.Button8.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(90, 34)
        Me.Button8.TabIndex = 99
        Me.Button8.Text = "4"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(196, 72)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(90, 34)
        Me.Button5.TabIndex = 98
        Me.Button5.Text = "3"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(104, 72)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(90, 34)
        Me.Button4.TabIndex = 97
        Me.Button4.Text = "2"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(10, 72)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 34)
        Me.Button3.TabIndex = 96
        Me.Button3.Text = "1"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBoxPhoneNumber
        '
        Me.TextBoxPhoneNumber.Location = New System.Drawing.Point(8, 26)
        Me.TextBoxPhoneNumber.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxPhoneNumber.Name = "TextBoxPhoneNumber"
        Me.TextBoxPhoneNumber.Size = New System.Drawing.Size(277, 26)
        Me.TextBoxPhoneNumber.TabIndex = 95
        '
        'groupBox3
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
        Me.groupBox3.Location = New System.Drawing.Point(718, 297)
        Me.groupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox3.Size = New System.Drawing.Size(668, 242)
        Me.groupBox3.TabIndex = 39
        Me.groupBox3.TabStop = False
        '
        'ComboBoxCameras
        '
        Me.ComboBoxCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCameras.FormattingEnabled = True
        Me.ComboBoxCameras.Location = New System.Drawing.Point(141, 192)
        Me.ComboBoxCameras.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBoxCameras.Name = "ComboBoxCameras"
        Me.ComboBoxCameras.Size = New System.Drawing.Size(460, 28)
        Me.ComboBoxCameras.TabIndex = 56
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 197)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 20)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "Camera"
        '
        'ComboBoxMicrophones
        '
        Me.ComboBoxMicrophones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMicrophones.FormattingEnabled = True
        Me.ComboBoxMicrophones.Location = New System.Drawing.Point(141, 115)
        Me.ComboBoxMicrophones.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBoxMicrophones.Name = "ComboBoxMicrophones"
        Me.ComboBoxMicrophones.Size = New System.Drawing.Size(460, 28)
        Me.ComboBoxMicrophones.TabIndex = 54
        '
        'ComboBoxSpeakers
        '
        Me.ComboBoxSpeakers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSpeakers.FormattingEnabled = True
        Me.ComboBoxSpeakers.Location = New System.Drawing.Point(141, 151)
        Me.ComboBoxSpeakers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBoxSpeakers.Name = "ComboBoxSpeakers"
        Me.ComboBoxSpeakers.Size = New System.Drawing.Size(460, 28)
        Me.ComboBoxSpeakers.TabIndex = 53
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 118)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 20)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Microphone"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 155)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 20)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "Speaker"
        '
        'CheckBoxMute
        '
        Me.CheckBoxMute.AutoSize = True
        Me.CheckBoxMute.Location = New System.Drawing.Point(470, 58)
        Me.CheckBoxMute.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxMute.Name = "CheckBoxMute"
        Me.CheckBoxMute.Size = New System.Drawing.Size(158, 24)
        Me.CheckBoxMute.TabIndex = 50
        Me.CheckBoxMute.Text = "Mute microphone"
        Me.CheckBoxMute.UseVisualStyleBackColor = True
        '
        'TrackBarMicrophone
        '
        Me.TrackBarMicrophone.Location = New System.Drawing.Point(123, 58)
        Me.TrackBarMicrophone.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TrackBarMicrophone.Maximum = 255
        Me.TrackBarMicrophone.Name = "TrackBarMicrophone"
        Me.TrackBarMicrophone.Size = New System.Drawing.Size(321, 69)
        Me.TrackBarMicrophone.TabIndex = 49
        Me.TrackBarMicrophone.TickFrequency = 10
        Me.TrackBarMicrophone.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 63)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 20)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Microphone"
        '
        'TrackBarSpeaker
        '
        Me.TrackBarSpeaker.Location = New System.Drawing.Point(123, 12)
        Me.TrackBarSpeaker.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TrackBarSpeaker.Maximum = 255
        Me.TrackBarSpeaker.Name = "TrackBarSpeaker"
        Me.TrackBarSpeaker.Size = New System.Drawing.Size(321, 69)
        Me.TrackBarSpeaker.TabIndex = 47
        Me.TrackBarSpeaker.TickFrequency = 10
        Me.TrackBarSpeaker.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 26)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 20)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Speaker"
        '
        'groupBox4
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
        Me.groupBox4.Location = New System.Drawing.Point(22, 557)
        Me.groupBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox4.Size = New System.Drawing.Size(668, 348)
        Me.groupBox4.TabIndex = 40
        Me.groupBox4.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(404, 263)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 20)
        Me.Label21.TabIndex = 102
        Me.Label21.Text = "Normal"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(616, 260)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 20)
        Me.Label20.TabIndex = 103
        Me.Label20.Text = "Best"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(336, 263)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 20)
        Me.Label19.TabIndex = 101
        Me.Label19.Text = "Quality"
        '
        'ComboBoxVideoResolution
        '
        Me.ComboBoxVideoResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxVideoResolution.FormattingEnabled = True
        Me.ComboBoxVideoResolution.Location = New System.Drawing.Point(104, 255)
        Me.ComboBoxVideoResolution.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBoxVideoResolution.Name = "ComboBoxVideoResolution"
        Me.ComboBoxVideoResolution.Size = New System.Drawing.Size(133, 28)
        Me.ComboBoxVideoResolution.TabIndex = 100
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(4, 265)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 20)
        Me.Label18.TabIndex = 99
        Me.Label18.Text = "Resolution"
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(538, 297)
        Me.Button15.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(120, 35)
        Me.Button15.TabIndex = 97
        Me.Button15.Text = "Stop Video"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'ButtonSendVideo
        '
        Me.ButtonSendVideo.Location = New System.Drawing.Point(394, 297)
        Me.ButtonSendVideo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonSendVideo.Name = "ButtonSendVideo"
        Me.ButtonSendVideo.Size = New System.Drawing.Size(120, 35)
        Me.ButtonSendVideo.TabIndex = 96
        Me.ButtonSendVideo.Text = "Send Video"
        Me.ButtonSendVideo.UseVisualStyleBackColor = True
        '
        'ButtonLocalVideo
        '
        Me.ButtonLocalVideo.Location = New System.Drawing.Point(152, 297)
        Me.ButtonLocalVideo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonLocalVideo.Name = "ButtonLocalVideo"
        Me.ButtonLocalVideo.Size = New System.Drawing.Size(120, 35)
        Me.ButtonLocalVideo.TabIndex = 95
        Me.ButtonLocalVideo.Text = "Local Video"
        Me.ButtonLocalVideo.UseVisualStyleBackColor = True
        '
        'ButtonCameraOptions
        '
        Me.ButtonCameraOptions.Location = New System.Drawing.Point(9, 297)
        Me.ButtonCameraOptions.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonCameraOptions.Name = "ButtonCameraOptions"
        Me.ButtonCameraOptions.Size = New System.Drawing.Size(120, 35)
        Me.ButtonCameraOptions.TabIndex = 94
        Me.ButtonCameraOptions.Text = "Options"
        Me.ButtonCameraOptions.UseVisualStyleBackColor = True
        '
        'TrackBarVideoQuality
        '
        Me.TrackBarVideoQuality.Location = New System.Drawing.Point(453, 255)
        Me.TrackBarVideoQuality.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TrackBarVideoQuality.Maximum = 2000
        Me.TrackBarVideoQuality.Minimum = 100
        Me.TrackBarVideoQuality.Name = "TrackBarVideoQuality"
        Me.TrackBarVideoQuality.Size = New System.Drawing.Size(178, 69)
        Me.TrackBarVideoQuality.TabIndex = 98
        Me.TrackBarVideoQuality.TickFrequency = 100
        Me.TrackBarVideoQuality.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarVideoQuality.Value = 300
        '
        'remoteVideoPanel
        '
        Me.remoteVideoPanel.Location = New System.Drawing.Point(394, 15)
        Me.remoteVideoPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.remoteVideoPanel.Name = "remoteVideoPanel"
        Me.remoteVideoPanel.Size = New System.Drawing.Size(264, 222)
        Me.remoteVideoPanel.TabIndex = 1
        '
        'localVideoPanel
        '
        Me.localVideoPanel.Location = New System.Drawing.Point(8, 15)
        Me.localVideoPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.localVideoPanel.Name = "localVideoPanel"
        Me.localVideoPanel.Size = New System.Drawing.Size(264, 222)
        Me.localVideoPanel.TabIndex = 0
        '
        'ListBoxSIPLog
        '
        Me.ListBoxSIPLog.FormattingEnabled = True
        Me.ListBoxSIPLog.ItemHeight = 20
        Me.ListBoxSIPLog.Location = New System.Drawing.Point(718, 65)
        Me.ListBoxSIPLog.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ListBoxSIPLog.Name = "ListBoxSIPLog"
        Me.ListBoxSIPLog.Size = New System.Drawing.Size(644, 184)
        Me.ListBoxSIPLog.TabIndex = 41
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.CheckBoxVP9)
        Me.groupBox5.Controls.Add(Me.checkBoxOPUS)
        Me.groupBox5.Controls.Add(Me.CheckBoxVP8)
        Me.groupBox5.Controls.Add(Me.CheckBoxH264)
        Me.groupBox5.Controls.Add(Me.CheckBoxG7221)
        Me.groupBox5.Controls.Add(Me.CheckBoxSpeexWB)
        Me.groupBox5.Controls.Add(Me.CheckBoxAMRwb)
        Me.groupBox5.Controls.Add(Me.CheckBoxSpeex)
        Me.groupBox5.Controls.Add(Me.CheckBoxG722)
        Me.groupBox5.Controls.Add(Me.CheckBoxAMR)
        Me.groupBox5.Controls.Add(Me.CheckBoxGSM)
        Me.groupBox5.Controls.Add(Me.CheckBoxILBC)
        Me.groupBox5.Controls.Add(Me.CheckBoxG729)
        Me.groupBox5.Controls.Add(Me.CheckBoxPCMA)
        Me.groupBox5.Controls.Add(Me.CheckBoxPCMU)
        Me.groupBox5.Location = New System.Drawing.Point(22, 909)
        Me.groupBox5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox5.Size = New System.Drawing.Size(668, 145)
        Me.groupBox5.TabIndex = 42
        Me.groupBox5.TabStop = False
        '
        'checkBoxOPUS
        '
        Me.checkBoxOPUS.AutoSize = True
        Me.checkBoxOPUS.Location = New System.Drawing.Point(538, 57)
        Me.checkBoxOPUS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.checkBoxOPUS.Name = "checkBoxOPUS"
        Me.checkBoxOPUS.Size = New System.Drawing.Size(73, 24)
        Me.checkBoxOPUS.TabIndex = 111
        Me.checkBoxOPUS.Text = "Opus"
        Me.checkBoxOPUS.UseVisualStyleBackColor = True
        '
        'CheckBoxVP8
        '
        Me.CheckBoxVP8.AutoSize = True
        Me.CheckBoxVP8.Location = New System.Drawing.Point(125, 111)
        Me.CheckBoxVP8.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxVP8.Name = "CheckBoxVP8"
        Me.CheckBoxVP8.Size = New System.Drawing.Size(65, 24)
        Me.CheckBoxVP8.TabIndex = 110
        Me.CheckBoxVP8.Text = "VP8"
        Me.CheckBoxVP8.UseVisualStyleBackColor = True
        '
        'CheckBoxH264
        '
        Me.CheckBoxH264.AutoSize = True
        Me.CheckBoxH264.Checked = True
        Me.CheckBoxH264.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxH264.Location = New System.Drawing.Point(20, 111)
        Me.CheckBoxH264.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxH264.Name = "CheckBoxH264"
        Me.CheckBoxH264.Size = New System.Drawing.Size(74, 24)
        Me.CheckBoxH264.TabIndex = 65
        Me.CheckBoxH264.Text = "H264"
        Me.CheckBoxH264.UseVisualStyleBackColor = True
        '
        'CheckBoxG7221
        '
        Me.CheckBoxG7221.AutoSize = True
        Me.CheckBoxG7221.Location = New System.Drawing.Point(104, 55)
        Me.CheckBoxG7221.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxG7221.Name = "CheckBoxG7221"
        Me.CheckBoxG7221.Size = New System.Drawing.Size(88, 24)
        Me.CheckBoxG7221.TabIndex = 109
        Me.CheckBoxG7221.Text = "G722.1"
        Me.CheckBoxG7221.UseVisualStyleBackColor = True
        '
        'CheckBoxH2631998
        '
        Me.CheckBoxH2631998.AutoSize = True
        Me.CheckBoxH2631998.Location = New System.Drawing.Point(193, 1064)
        Me.CheckBoxH2631998.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxH2631998.Name = "CheckBoxH2631998"
        Me.CheckBoxH2631998.Size = New System.Drawing.Size(115, 24)
        Me.CheckBoxH2631998.TabIndex = 64
        Me.CheckBoxH2631998.Text = "H263-1998"
        Me.CheckBoxH2631998.UseVisualStyleBackColor = True
        Me.CheckBoxH2631998.Visible = False
        '
        'CheckBoxSpeexWB
        '
        Me.CheckBoxSpeexWB.AutoSize = True
        Me.CheckBoxSpeexWB.Location = New System.Drawing.Point(310, 55)
        Me.CheckBoxSpeexWB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxSpeexWB.Name = "CheckBoxSpeexWB"
        Me.CheckBoxSpeexWB.Size = New System.Drawing.Size(120, 24)
        Me.CheckBoxSpeexWB.TabIndex = 108
        Me.CheckBoxSpeexWB.Text = "SPEEX-WB"
        Me.CheckBoxSpeexWB.UseVisualStyleBackColor = True
        '
        'CheckBoxH263
        '
        Me.CheckBoxH263.AutoSize = True
        Me.CheckBoxH263.Location = New System.Drawing.Point(61, 1064)
        Me.CheckBoxH263.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxH263.Name = "CheckBoxH263"
        Me.CheckBoxH263.Size = New System.Drawing.Size(74, 24)
        Me.CheckBoxH263.TabIndex = 63
        Me.CheckBoxH263.Text = "H263"
        Me.CheckBoxH263.UseVisualStyleBackColor = True
        Me.CheckBoxH263.Visible = False
        '
        'CheckBoxAMRwb
        '
        Me.CheckBoxAMRwb.AutoSize = True
        Me.CheckBoxAMRwb.Location = New System.Drawing.Point(201, 55)
        Me.CheckBoxAMRwb.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxAMRwb.Name = "CheckBoxAMRwb"
        Me.CheckBoxAMRwb.Size = New System.Drawing.Size(102, 24)
        Me.CheckBoxAMRwb.TabIndex = 106
        Me.CheckBoxAMRwb.Text = "AMR-WB"
        Me.CheckBoxAMRwb.UseVisualStyleBackColor = True
        '
        'CheckBoxSpeex
        '
        Me.CheckBoxSpeex.AutoSize = True
        Me.CheckBoxSpeex.Location = New System.Drawing.Point(441, 55)
        Me.CheckBoxSpeex.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxSpeex.Name = "CheckBoxSpeex"
        Me.CheckBoxSpeex.Size = New System.Drawing.Size(89, 24)
        Me.CheckBoxSpeex.TabIndex = 107
        Me.CheckBoxSpeex.Text = "SPEEX"
        Me.CheckBoxSpeex.UseVisualStyleBackColor = True
        '
        'CheckBoxG722
        '
        Me.CheckBoxG722.AutoSize = True
        Me.CheckBoxG722.Location = New System.Drawing.Point(21, 55)
        Me.CheckBoxG722.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxG722.Name = "CheckBoxG722"
        Me.CheckBoxG722.Size = New System.Drawing.Size(75, 24)
        Me.CheckBoxG722.TabIndex = 105
        Me.CheckBoxG722.Text = "G722"
        Me.CheckBoxG722.UseVisualStyleBackColor = True
        '
        'CheckBoxAMR
        '
        Me.CheckBoxAMR.AutoSize = True
        Me.CheckBoxAMR.Location = New System.Drawing.Point(540, 20)
        Me.CheckBoxAMR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxAMR.Name = "CheckBoxAMR"
        Me.CheckBoxAMR.Size = New System.Drawing.Size(71, 24)
        Me.CheckBoxAMR.TabIndex = 104
        Me.CheckBoxAMR.Text = "AMR"
        Me.CheckBoxAMR.UseVisualStyleBackColor = True
        '
        'CheckBoxGSM
        '
        Me.CheckBoxGSM.AutoSize = True
        Me.CheckBoxGSM.Location = New System.Drawing.Point(456, 20)
        Me.CheckBoxGSM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxGSM.Name = "CheckBoxGSM"
        Me.CheckBoxGSM.Size = New System.Drawing.Size(72, 24)
        Me.CheckBoxGSM.TabIndex = 103
        Me.CheckBoxGSM.Text = "GSM"
        Me.CheckBoxGSM.UseVisualStyleBackColor = True
        '
        'CheckBoxILBC
        '
        Me.CheckBoxILBC.AutoSize = True
        Me.CheckBoxILBC.Location = New System.Drawing.Point(375, 20)
        Me.CheckBoxILBC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxILBC.Name = "CheckBoxILBC"
        Me.CheckBoxILBC.Size = New System.Drawing.Size(69, 24)
        Me.CheckBoxILBC.TabIndex = 102
        Me.CheckBoxILBC.Text = "iLBC"
        Me.CheckBoxILBC.UseVisualStyleBackColor = True
        '
        'CheckBoxG729
        '
        Me.CheckBoxG729.AutoSize = True
        Me.CheckBoxG729.Checked = True
        Me.CheckBoxG729.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxG729.Location = New System.Drawing.Point(288, 20)
        Me.CheckBoxG729.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxG729.Name = "CheckBoxG729"
        Me.CheckBoxG729.Size = New System.Drawing.Size(75, 24)
        Me.CheckBoxG729.TabIndex = 101
        Me.CheckBoxG729.Text = "G729"
        Me.CheckBoxG729.UseVisualStyleBackColor = True
        '
        'CheckBoxPCMA
        '
        Me.CheckBoxPCMA.AutoSize = True
        Me.CheckBoxPCMA.Checked = True
        Me.CheckBoxPCMA.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxPCMA.Location = New System.Drawing.Point(153, 20)
        Me.CheckBoxPCMA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxPCMA.Name = "CheckBoxPCMA"
        Me.CheckBoxPCMA.Size = New System.Drawing.Size(117, 24)
        Me.CheckBoxPCMA.TabIndex = 100
        Me.CheckBoxPCMA.Text = "G711 aLaw"
        Me.CheckBoxPCMA.UseVisualStyleBackColor = True
        '
        'CheckBoxPCMU
        '
        Me.CheckBoxPCMU.AutoSize = True
        Me.CheckBoxPCMU.Checked = True
        Me.CheckBoxPCMU.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxPCMU.Location = New System.Drawing.Point(21, 20)
        Me.CheckBoxPCMU.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxPCMU.Name = "CheckBoxPCMU"
        Me.CheckBoxPCMU.Size = New System.Drawing.Size(117, 24)
        Me.CheckBoxPCMU.TabIndex = 99
        Me.CheckBoxPCMU.Text = "G711 uLaw"
        Me.CheckBoxPCMU.UseVisualStyleBackColor = True
        '
        'Button22
        '
        Me.Button22.Location = New System.Drawing.Point(718, 262)
        Me.Button22.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(130, 35)
        Me.Button22.TabIndex = 43
        Me.Button22.Text = "Clear"
        Me.Button22.UseVisualStyleBackColor = True
        '
        'groupBox7
        '
        Me.groupBox7.Controls.Add(Me.checkBoxNACK)
        Me.groupBox7.Controls.Add(Me.CheckBoxANS)
        Me.groupBox7.Controls.Add(Me.CheckBoxAGC)
        Me.groupBox7.Controls.Add(Me.CheckBoxCNG)
        Me.groupBox7.Controls.Add(Me.CheckBoxVAD)
        Me.groupBox7.Controls.Add(Me.CheckBoxAEC)
        Me.groupBox7.Location = New System.Drawing.Point(718, 985)
        Me.groupBox7.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox7.Name = "groupBox7"
        Me.groupBox7.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox7.Size = New System.Drawing.Size(624, 69)
        Me.groupBox7.TabIndex = 45
        Me.groupBox7.TabStop = False
        '
        'checkBoxNACK
        '
        Me.checkBoxNACK.AutoSize = True
        Me.checkBoxNACK.Checked = True
        Me.checkBoxNACK.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBoxNACK.Location = New System.Drawing.Point(531, 22)
        Me.checkBoxNACK.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.checkBoxNACK.Name = "checkBoxNACK"
        Me.checkBoxNACK.Size = New System.Drawing.Size(78, 24)
        Me.checkBoxNACK.TabIndex = 73
        Me.checkBoxNACK.Text = "NACK"
        Me.checkBoxNACK.UseVisualStyleBackColor = True
        '
        'CheckBoxANS
        '
        Me.CheckBoxANS.AutoSize = True
        Me.CheckBoxANS.Location = New System.Drawing.Point(440, 22)
        Me.CheckBoxANS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxANS.Name = "CheckBoxANS"
        Me.CheckBoxANS.Size = New System.Drawing.Size(68, 24)
        Me.CheckBoxANS.TabIndex = 72
        Me.CheckBoxANS.Text = "ANS"
        Me.CheckBoxANS.UseVisualStyleBackColor = True
        '
        'CheckBoxAGC
        '
        Me.CheckBoxAGC.AutoSize = True
        Me.CheckBoxAGC.Location = New System.Drawing.Point(345, 22)
        Me.CheckBoxAGC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxAGC.Name = "CheckBoxAGC"
        Me.CheckBoxAGC.Size = New System.Drawing.Size(70, 24)
        Me.CheckBoxAGC.TabIndex = 71
        Me.CheckBoxAGC.Text = "AGC"
        Me.CheckBoxAGC.UseVisualStyleBackColor = True
        '
        'CheckBoxCNG
        '
        Me.CheckBoxCNG.AutoSize = True
        Me.CheckBoxCNG.Location = New System.Drawing.Point(232, 22)
        Me.CheckBoxCNG.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxCNG.Name = "CheckBoxCNG"
        Me.CheckBoxCNG.Size = New System.Drawing.Size(70, 24)
        Me.CheckBoxCNG.TabIndex = 70
        Me.CheckBoxCNG.Text = "CNG"
        Me.CheckBoxCNG.UseVisualStyleBackColor = True
        '
        'CheckBoxVAD
        '
        Me.CheckBoxVAD.AutoSize = True
        Me.CheckBoxVAD.Location = New System.Drawing.Point(123, 22)
        Me.CheckBoxVAD.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxVAD.Name = "CheckBoxVAD"
        Me.CheckBoxVAD.Size = New System.Drawing.Size(69, 24)
        Me.CheckBoxVAD.TabIndex = 69
        Me.CheckBoxVAD.Text = "VAD"
        Me.CheckBoxVAD.UseVisualStyleBackColor = True
        '
        'CheckBoxAEC
        '
        Me.CheckBoxAEC.AutoSize = True
        Me.CheckBoxAEC.Checked = True
        Me.CheckBoxAEC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAEC.Location = New System.Drawing.Point(18, 22)
        Me.CheckBoxAEC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxAEC.Name = "CheckBoxAEC"
        Me.CheckBoxAEC.Size = New System.Drawing.Size(68, 24)
        Me.CheckBoxAEC.TabIndex = 68
        Me.CheckBoxAEC.Text = "AEC"
        Me.CheckBoxAEC.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(312, 38)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(196, 24)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "Audio Stream Callback"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(170, 34)
        Me.Button17.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(60, 31)
        Me.Button17.TabIndex = 7
        Me.Button17.Text = "..."
        Me.Button17.UseVisualStyleBackColor = True
        '
        'groupBox8
        '
        Me.groupBox8.Controls.Add(Me.Button18)
        Me.groupBox8.Controls.Add(Me.Button19)
        Me.groupBox8.Controls.Add(Me.CheckBox1)
        Me.groupBox8.Controls.Add(Me.Button17)
        Me.groupBox8.Controls.Add(Me.TextBoxRecordFileName)
        Me.groupBox8.Controls.Add(Me.Label25)
        Me.groupBox8.Controls.Add(Me.TextBoxRecordFilePath)
        Me.groupBox8.Controls.Add(Me.Label26)
        Me.groupBox8.Location = New System.Drawing.Point(718, 558)
        Me.groupBox8.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox8.Name = "groupBox8"
        Me.groupBox8.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox8.Size = New System.Drawing.Size(646, 180)
        Me.groupBox8.TabIndex = 46
        Me.groupBox8.TabStop = False
        Me.groupBox8.Text = "Audio and Video Recording"
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(478, 122)
        Me.Button18.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(111, 34)
        Me.Button18.TabIndex = 13
        Me.Button18.Text = "StopRecord"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(358, 122)
        Me.Button19.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(112, 35)
        Me.Button19.TabIndex = 14
        Me.Button19.Text = "StartRecord"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'TextBoxRecordFileName
        '
        Me.TextBoxRecordFileName.Location = New System.Drawing.Point(196, 125)
        Me.TextBoxRecordFileName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxRecordFileName.Name = "TextBoxRecordFileName"
        Me.TextBoxRecordFileName.Size = New System.Drawing.Size(136, 26)
        Me.TextBoxRecordFileName.TabIndex = 3
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(14, 132)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(129, 20)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Record file name"
        '
        'TextBoxRecordFilePath
        '
        Me.TextBoxRecordFilePath.Location = New System.Drawing.Point(18, 74)
        Me.TextBoxRecordFilePath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxRecordFilePath.Name = "TextBoxRecordFilePath"
        Me.TextBoxRecordFilePath.ReadOnly = True
        Me.TextBoxRecordFilePath.Size = New System.Drawing.Size(570, 26)
        Me.TextBoxRecordFilePath.TabIndex = 1
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(9, 42)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(149, 20)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Record file directory"
        '
        'groupBox11
        '
        Me.groupBox11.Controls.Add(Me.button28)
        Me.groupBox11.Controls.Add(Me.button27)
        Me.groupBox11.Controls.Add(Me.CheckBoxForwardCallForBusy)
        Me.groupBox11.Controls.Add(Me.textBoxForwardTo)
        Me.groupBox11.Controls.Add(Me.label16)
        Me.groupBox11.Location = New System.Drawing.Point(1077, 754)
        Me.groupBox11.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox11.Name = "groupBox11"
        Me.groupBox11.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox11.Size = New System.Drawing.Size(266, 182)
        Me.groupBox11.TabIndex = 47
        Me.groupBox11.TabStop = False
        Me.groupBox11.Text = "Call Forward"
        '
        'button28
        '
        Me.button28.Location = New System.Drawing.Point(140, 126)
        Me.button28.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.button28.Name = "button28"
        Me.button28.Size = New System.Drawing.Size(112, 35)
        Me.button28.TabIndex = 4
        Me.button28.Text = "Disable"
        Me.button28.UseVisualStyleBackColor = True
        '
        'button27
        '
        Me.button27.Location = New System.Drawing.Point(16, 126)
        Me.button27.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.button27.Name = "button27"
        Me.button27.Size = New System.Drawing.Size(112, 35)
        Me.button27.TabIndex = 3
        Me.button27.Text = "Enable"
        Me.button27.UseVisualStyleBackColor = True
        '
        'CheckBoxForwardCallForBusy
        '
        Me.CheckBoxForwardCallForBusy.AutoSize = True
        Me.CheckBoxForwardCallForBusy.Location = New System.Drawing.Point(15, 94)
        Me.CheckBoxForwardCallForBusy.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxForwardCallForBusy.Name = "CheckBoxForwardCallForBusy"
        Me.CheckBoxForwardCallForBusy.Size = New System.Drawing.Size(233, 24)
        Me.CheckBoxForwardCallForBusy.TabIndex = 2
        Me.CheckBoxForwardCallForBusy.Text = "Forward call when on phone"
        Me.CheckBoxForwardCallForBusy.UseVisualStyleBackColor = True
        '
        'textBoxForwardTo
        '
        Me.textBoxForwardTo.Location = New System.Drawing.Point(15, 54)
        Me.textBoxForwardTo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.textBoxForwardTo.Name = "textBoxForwardTo"
        Me.textBoxForwardTo.Size = New System.Drawing.Size(235, 26)
        Me.textBoxForwardTo.TabIndex = 1
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(10, 29)
        Me.label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(116, 20)
        Me.label16.TabIndex = 0
        Me.label16.Text = "Forward call to:"
        '
        'groupBox9
        '
        Me.groupBox9.Controls.Add(Me.Button23)
        Me.groupBox9.Controls.Add(Me.Button21)
        Me.groupBox9.Controls.Add(Me.Button20)
        Me.groupBox9.Controls.Add(Me.TextBoxPlayFile)
        Me.groupBox9.Controls.Add(Me.Label27)
        Me.groupBox9.Location = New System.Drawing.Point(718, 754)
        Me.groupBox9.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox9.Name = "groupBox9"
        Me.groupBox9.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox9.Size = New System.Drawing.Size(304, 182)
        Me.groupBox9.TabIndex = 48
        Me.groupBox9.TabStop = False
        Me.groupBox9.Text = "Play audio file(Wave)"
        '
        'Button23
        '
        Me.Button23.Location = New System.Drawing.Point(162, 132)
        Me.Button23.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(112, 34)
        Me.Button23.TabIndex = 12
        Me.Button23.Text = "Stop"
        Me.Button23.UseVisualStyleBackColor = True
        '
        'Button21
        '
        Me.Button21.Location = New System.Drawing.Point(18, 132)
        Me.Button21.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(112, 34)
        Me.Button21.TabIndex = 11
        Me.Button21.Text = "Start"
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button20
        '
        Me.Button20.Location = New System.Drawing.Point(124, 29)
        Me.Button20.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(104, 34)
        Me.Button20.TabIndex = 10
        Me.Button20.Text = "..."
        Me.Button20.UseVisualStyleBackColor = True
        '
        'TextBoxPlayFile
        '
        Me.TextBoxPlayFile.Location = New System.Drawing.Point(9, 77)
        Me.TextBoxPlayFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxPlayFile.Name = "TextBoxPlayFile"
        Me.TextBoxPlayFile.ReadOnly = True
        Me.TextBoxPlayFile.Size = New System.Drawing.Size(271, 26)
        Me.TextBoxPlayFile.TabIndex = 9
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(15, 34)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(75, 20)
        Me.Label27.TabIndex = 8
        Me.Label27.Text = "select file"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "wav"
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Title = "Select wave file"
        '
        'CheckBoxVP9
        '
        Me.CheckBoxVP9.AutoSize = True
        Me.CheckBoxVP9.Location = New System.Drawing.Point(221, 111)
        Me.CheckBoxVP9.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBoxVP9.Name = "CheckBoxVP9"
        Me.CheckBoxVP9.Size = New System.Drawing.Size(65, 24)
        Me.CheckBoxVP9.TabIndex = 112
        Me.CheckBoxVP9.Text = "VP9"
        Me.CheckBoxVP9.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1380, 1092)
        Me.Controls.Add(Me.groupBox9)
        Me.Controls.Add(Me.groupBox11)
        Me.Controls.Add(Me.groupBox8)
        Me.Controls.Add(Me.groupBox7)
        Me.Controls.Add(Me.CheckBoxH2631998)
        Me.Controls.Add(Me.Button22)
        Me.Controls.Add(Me.CheckBoxH263)
        Me.Controls.Add(Me.groupBox5)
        Me.Controls.Add(Me.ListBoxSIPLog)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.linkLabel2)
        Me.Controls.Add(Me.linkLabel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "PortSIP SIPSample"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        CType(Me.TrackBarMicrophone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarSpeaker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        CType(Me.TrackBarVideoQuality, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.groupBox7.ResumeLayout(False)
        Me.groupBox7.PerformLayout()
        Me.groupBox8.ResumeLayout(False)
        Me.groupBox8.PerformLayout()
        Me.groupBox11.ResumeLayout(False)
        Me.groupBox11.PerformLayout()
        Me.groupBox9.ResumeLayout(False)
        Me.groupBox9.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region

    Private WithEvents linkLabel2 As System.Windows.Forms.LinkLabel
    Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
	Private groupBox1 As System.Windows.Forms.GroupBox
	Friend Label22 As System.Windows.Forms.Label
    Private WithEvents ComboBoxTransport As System.Windows.Forms.ComboBox
	Friend Label23 As System.Windows.Forms.Label
    Private WithEvents ComboBoxSRTP As System.Windows.Forms.ComboBox
	Friend TextBoxUserDomain As System.Windows.Forms.TextBox
	Friend Label9 As System.Windows.Forms.Label
	Friend TextBoxAuthName As System.Windows.Forms.TextBox
	Friend Label5 As System.Windows.Forms.Label
	Friend TextBoxDisplayName As System.Windows.Forms.TextBox
	Friend Label6 As System.Windows.Forms.Label
    Private WithEvents Button2 As System.Windows.Forms.Button
    Private WithEvents Button1 As System.Windows.Forms.Button
    Friend TextBoxStunPort As System.Windows.Forms.TextBox
    Friend Label7 As System.Windows.Forms.Label
    Friend TextBoxStunServer As System.Windows.Forms.TextBox
    Friend Label8 As System.Windows.Forms.Label
    Friend TextBoxServerPort As System.Windows.Forms.TextBox
    Friend Label3 As System.Windows.Forms.Label
    Friend TextBoxServer As System.Windows.Forms.TextBox
    Friend Label4 As System.Windows.Forms.Label
    Friend TextBoxPassword As System.Windows.Forms.TextBox
    Friend Label2 As System.Windows.Forms.Label
    Friend TextBoxUserName As System.Windows.Forms.TextBox
    Friend Label1 As System.Windows.Forms.Label
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents button24 As System.Windows.Forms.Button
    Private WithEvents Button16 As System.Windows.Forms.Button
    Private WithEvents ButtonAnswer As System.Windows.Forms.Button
    Private WithEvents ButtonTransfer As System.Windows.Forms.Button
    Private WithEvents ButtonHold As System.Windows.Forms.Button
    Private WithEvents ComboBoxLines As System.Windows.Forms.ComboBox
    Private WithEvents ButtonReject As System.Windows.Forms.Button
    Private WithEvents ButtonHangUp As System.Windows.Forms.Button
    Private WithEvents ButtonDial As System.Windows.Forms.Button
    Private WithEvents Button12 As System.Windows.Forms.Button
    Private WithEvents Button13 As System.Windows.Forms.Button
    Private WithEvents Button14 As System.Windows.Forms.Button
    Private WithEvents Button9 As System.Windows.Forms.Button
    Private WithEvents Button10 As System.Windows.Forms.Button
    Private WithEvents Button11 As System.Windows.Forms.Button
    Private WithEvents Button6 As System.Windows.Forms.Button
    Private WithEvents Button7 As System.Windows.Forms.Button
    Private WithEvents Button8 As System.Windows.Forms.Button
    Private WithEvents Button5 As System.Windows.Forms.Button
    Private WithEvents Button4 As System.Windows.Forms.Button
    Private WithEvents Button3 As System.Windows.Forms.Button
    Friend TextBoxPhoneNumber As System.Windows.Forms.TextBox
    Private groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents CheckBoxMute As System.Windows.Forms.CheckBox
    Private WithEvents TrackBarMicrophone As System.Windows.Forms.TrackBar
    Friend Label11 As System.Windows.Forms.Label
    Private WithEvents TrackBarSpeaker As System.Windows.Forms.TrackBar
    Friend Label10 As System.Windows.Forms.Label
    Private WithEvents ComboBoxCameras As System.Windows.Forms.ComboBox
    Friend Label14 As System.Windows.Forms.Label
    Private WithEvents ComboBoxMicrophones As System.Windows.Forms.ComboBox
    Private WithEvents ComboBoxSpeakers As System.Windows.Forms.ComboBox
    Friend Label12 As System.Windows.Forms.Label
    Friend Label13 As System.Windows.Forms.Label
    Private groupBox4 As System.Windows.Forms.GroupBox
    Private remoteVideoPanel As System.Windows.Forms.Panel
    Private localVideoPanel As System.Windows.Forms.Panel
    Friend Label21 As System.Windows.Forms.Label
    Friend Label20 As System.Windows.Forms.Label
    Friend Label19 As System.Windows.Forms.Label
    Private WithEvents ComboBoxVideoResolution As System.Windows.Forms.ComboBox
    Friend Label18 As System.Windows.Forms.Label
    Private WithEvents Button15 As System.Windows.Forms.Button
    Private WithEvents ButtonSendVideo As System.Windows.Forms.Button
    Private WithEvents ButtonLocalVideo As System.Windows.Forms.Button
    Private WithEvents ButtonCameraOptions As System.Windows.Forms.Button
    Private WithEvents TrackBarVideoQuality As System.Windows.Forms.TrackBar
    Private ListBoxSIPLog As System.Windows.Forms.ListBox
    Private groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents CheckBoxG7221 As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxSpeexWB As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxAMRwb As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxSpeex As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxG722 As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxAMR As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxGSM As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxILBC As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxG729 As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxPCMA As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxPCMU As System.Windows.Forms.CheckBox
    Private WithEvents Button22 As System.Windows.Forms.Button
    Private WithEvents CheckBoxH264 As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxH2631998 As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxH263 As System.Windows.Forms.CheckBox
    Private groupBox7 As System.Windows.Forms.GroupBox
    Private WithEvents CheckBoxAGC As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxCNG As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxVAD As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxAEC As System.Windows.Forms.CheckBox
    Private WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Private WithEvents Button17 As System.Windows.Forms.Button
    Friend groupBox8 As System.Windows.Forms.GroupBox
    Friend TextBoxRecordFileName As System.Windows.Forms.TextBox
    Friend Label25 As System.Windows.Forms.Label
    Friend TextBoxRecordFilePath As System.Windows.Forms.TextBox
    Friend Label26 As System.Windows.Forms.Label
    Private groupBox11 As System.Windows.Forms.GroupBox
    Private WithEvents button28 As System.Windows.Forms.Button
    Private WithEvents button27 As System.Windows.Forms.Button
    Private WithEvents CheckBoxForwardCallForBusy As System.Windows.Forms.CheckBox
    Private textBoxForwardTo As System.Windows.Forms.TextBox
    Private label16 As System.Windows.Forms.Label
    Friend groupBox9 As System.Windows.Forms.GroupBox
    Private WithEvents Button23 As System.Windows.Forms.Button
    Private WithEvents Button21 As System.Windows.Forms.Button
    Private WithEvents Button20 As System.Windows.Forms.Button
    Friend TextBoxPlayFile As System.Windows.Forms.TextBox
    Friend Label27 As System.Windows.Forms.Label
    Friend OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents Button18 As System.Windows.Forms.Button
    Private WithEvents Button19 As System.Windows.Forms.Button
    Private WithEvents CheckBoxVP8 As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxNeedRegister As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxANS As System.Windows.Forms.CheckBox
    Private WithEvents checkBoxOPUS As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxPRACK As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxConf As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxAA As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxDND As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxSDP As System.Windows.Forms.CheckBox
    Private WithEvents checkBoxAnswerVideo As System.Windows.Forms.CheckBox
    Private WithEvents checkBoxMakeVideo As System.Windows.Forms.CheckBox
    Private WithEvents checkBoxNACK As System.Windows.Forms.CheckBox
    Private WithEvents CheckBoxVP9 As System.Windows.Forms.CheckBox
End Class

