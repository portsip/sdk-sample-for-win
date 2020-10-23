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
        Me.txtAuthName = New System.Windows.Forms.TextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnUpdateContact = New System.Windows.Forms.Button()
        Me.label9 = New System.Windows.Forms.Label()
        Me.txtUserDomain = New System.Windows.Forms.TextBox()
        Me.txtDisplayName = New System.Windows.Forms.TextBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label13 = New System.Windows.Forms.Label()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.ContactsList = New System.Windows.Forms.ListView()
        Me.ListBoxSIPLog = New System.Windows.Forms.ListBox()
        Me.BtnOffline = New System.Windows.Forms.Button()
        Me.BtnClearContact = New System.Windows.Forms.Button()
        Me.BtnDelContact = New System.Windows.Forms.Button()
        Me.BtnAddContact = New System.Windows.Forms.Button()
        Me.BtnSetStatus = New System.Windows.Forms.Button()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.BtnOnline = New System.Windows.Forms.Button()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtSendto = New System.Windows.Forms.TextBox()
        Me.txtStunPort = New System.Windows.Forms.TextBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.txtSIPPort = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtStunServer = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtSIPServer = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.linkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.groupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAuthName
        '
        Me.txtAuthName.Location = New System.Drawing.Point(412, 58)
        Me.txtAuthName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAuthName.Name = "txtAuthName"
        Me.txtAuthName.Size = New System.Drawing.Size(160, 26)
        Me.txtAuthName.TabIndex = 3
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.Panel1)
        Me.groupBox1.Controls.Add(Me.BtnUpdateContact)
        Me.groupBox1.Controls.Add(Me.txtAuthName)
        Me.groupBox1.Controls.Add(Me.label9)
        Me.groupBox1.Controls.Add(Me.txtUserDomain)
        Me.groupBox1.Controls.Add(Me.txtDisplayName)
        Me.groupBox1.Controls.Add(Me.label10)
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.label13)
        Me.groupBox1.Controls.Add(Me.label11)
        Me.groupBox1.Controls.Add(Me.label12)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.ContactsList)
        Me.groupBox1.Controls.Add(Me.ListBoxSIPLog)
        Me.groupBox1.Controls.Add(Me.BtnOffline)
        Me.groupBox1.Controls.Add(Me.BtnClearContact)
        Me.groupBox1.Controls.Add(Me.BtnDelContact)
        Me.groupBox1.Controls.Add(Me.BtnAddContact)
        Me.groupBox1.Controls.Add(Me.BtnSetStatus)
        Me.groupBox1.Controls.Add(Me.BtnSend)
        Me.groupBox1.Controls.Add(Me.BtnOnline)
        Me.groupBox1.Controls.Add(Me.txtMessage)
        Me.groupBox1.Controls.Add(Me.txtContact)
        Me.groupBox1.Controls.Add(Me.txtStatus)
        Me.groupBox1.Controls.Add(Me.txtSendto)
        Me.groupBox1.Controls.Add(Me.txtStunPort)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.txtSIPPort)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.txtStunServer)
        Me.groupBox1.Controls.Add(Me.txtPassword)
        Me.groupBox1.Controls.Add(Me.txtSIPServer)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.txtUserName)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(22, 49)
        Me.groupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox1.Size = New System.Drawing.Size(1092, 765)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "SIP"
        '
        'BtnUpdateContact
        '
        Me.BtnUpdateContact.Location = New System.Drawing.Point(225, 685)
        Me.BtnUpdateContact.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnUpdateContact.Name = "BtnUpdateContact"
        Me.BtnUpdateContact.Size = New System.Drawing.Size(150, 35)
        Me.BtnUpdateContact.TabIndex = 100
        Me.BtnUpdateContact.Text = "Update Contact"
        Me.BtnUpdateContact.UseVisualStyleBackColor = True
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(315, 63)
        Me.label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(89, 20)
        Me.label9.TabIndex = 19
        Me.label9.Text = "Auth Name"
        '
        'txtUserDomain
        '
        Me.txtUserDomain.Location = New System.Drawing.Point(124, 92)
        Me.txtUserDomain.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUserDomain.Name = "txtUserDomain"
        Me.txtUserDomain.Size = New System.Drawing.Size(160, 26)
        Me.txtUserDomain.TabIndex = 4
        '
        'txtDisplayName
        '
        Me.txtDisplayName.Location = New System.Drawing.Point(124, 58)
        Me.txtDisplayName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDisplayName.Name = "txtDisplayName"
        Me.txtDisplayName.Size = New System.Drawing.Size(160, 26)
        Me.txtDisplayName.TabIndex = 2
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(15, 97)
        Me.label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(102, 20)
        Me.label10.TabIndex = 18
        Me.label10.Text = "User Domain"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(9, 63)
        Me.label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(106, 20)
        Me.label8.TabIndex = 20
        Me.label8.Text = "Display Name"
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(630, 528)
        Me.label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(116, 20)
        Me.label13.TabIndex = 6
        Me.label13.Text = "Send Message"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(634, 408)
        Me.label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(80, 20)
        Me.label11.TabIndex = 6
        Me.label11.Text = "My Status"
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(634, 297)
        Me.label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(296, 20)
        Me.label12.TabIndex = 6
        Me.label12.Text = "Must likes sip:test@sip.portsip.com:5060"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(630, 677)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(362, 20)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Send to(Must likes sip:test@sip.portsip.com:5060)"
        '
        'ContactsList
        '
        Me.ContactsList.FullRowSelect = True
        Me.ContactsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ContactsList.HideSelection = False
        Me.ContactsList.Location = New System.Drawing.Point(20, 297)
        Me.ContactsList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ContactsList.MultiSelect = False
        Me.ContactsList.Name = "ContactsList"
        Me.ContactsList.Size = New System.Drawing.Size(553, 376)
        Me.ContactsList.TabIndex = 5
        Me.ContactsList.UseCompatibleStateImageBehavior = False
        Me.ContactsList.View = System.Windows.Forms.View.Details
        '
        'ListBoxSIPLog
        '
        Me.ListBoxSIPLog.FormattingEnabled = True
        Me.ListBoxSIPLog.ItemHeight = 20
        Me.ListBoxSIPLog.Location = New System.Drawing.Point(634, 29)
        Me.ListBoxSIPLog.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ListBoxSIPLog.Name = "ListBoxSIPLog"
        Me.ListBoxSIPLog.Size = New System.Drawing.Size(426, 184)
        Me.ListBoxSIPLog.TabIndex = 99
        '
        'BtnOffline
        '
        Me.BtnOffline.Location = New System.Drawing.Point(462, 248)
        Me.BtnOffline.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnOffline.Name = "BtnOffline"
        Me.BtnOffline.Size = New System.Drawing.Size(112, 35)
        Me.BtnOffline.TabIndex = 10
        Me.BtnOffline.Text = "Offine"
        Me.BtnOffline.UseVisualStyleBackColor = True
        '
        'BtnClearContact
        '
        Me.BtnClearContact.Location = New System.Drawing.Point(424, 685)
        Me.BtnClearContact.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnClearContact.Name = "BtnClearContact"
        Me.BtnClearContact.Size = New System.Drawing.Size(150, 35)
        Me.BtnClearContact.TabIndex = 12
        Me.BtnClearContact.Text = "Clear Contact"
        Me.BtnClearContact.UseVisualStyleBackColor = True
        '
        'BtnDelContact
        '
        Me.BtnDelContact.Location = New System.Drawing.Point(20, 685)
        Me.BtnDelContact.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnDelContact.Name = "BtnDelContact"
        Me.BtnDelContact.Size = New System.Drawing.Size(150, 35)
        Me.BtnDelContact.TabIndex = 12
        Me.BtnDelContact.Text = "Del Contact"
        Me.BtnDelContact.UseVisualStyleBackColor = True
        '
        'BtnAddContact
        '
        Me.BtnAddContact.Location = New System.Drawing.Point(634, 362)
        Me.BtnAddContact.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnAddContact.Name = "BtnAddContact"
        Me.BtnAddContact.Size = New System.Drawing.Size(150, 35)
        Me.BtnAddContact.TabIndex = 12
        Me.BtnAddContact.Text = "Add contact"
        Me.BtnAddContact.UseVisualStyleBackColor = True
        '
        'BtnSetStatus
        '
        Me.BtnSetStatus.Location = New System.Drawing.Point(639, 473)
        Me.BtnSetStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnSetStatus.Name = "BtnSetStatus"
        Me.BtnSetStatus.Size = New System.Drawing.Size(112, 35)
        Me.BtnSetStatus.TabIndex = 14
        Me.BtnSetStatus.Text = "Set Status"
        Me.BtnSetStatus.UseVisualStyleBackColor = True
        '
        'BtnSend
        '
        Me.BtnSend.Location = New System.Drawing.Point(972, 697)
        Me.BtnSend.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(86, 35)
        Me.BtnSend.TabIndex = 17
        Me.BtnSend.Text = "Send"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'BtnOnline
        '
        Me.BtnOnline.Location = New System.Drawing.Point(332, 248)
        Me.BtnOnline.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnOnline.Name = "BtnOnline"
        Me.BtnOnline.Size = New System.Drawing.Size(112, 35)
        Me.BtnOnline.TabIndex = 9
        Me.BtnOnline.Text = "Online"
        Me.BtnOnline.UseVisualStyleBackColor = True
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(634, 553)
        Me.txtMessage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(385, 121)
        Me.txtMessage.TabIndex = 15
        '
        'txtContact
        '
        Me.txtContact.Location = New System.Drawing.Point(639, 322)
        Me.txtContact.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(385, 26)
        Me.txtContact.TabIndex = 11
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(639, 433)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(385, 26)
        Me.txtStatus.TabIndex = 13
        '
        'txtSendto
        '
        Me.txtSendto.Location = New System.Drawing.Point(634, 702)
        Me.txtSendto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSendto.Name = "txtSendto"
        Me.txtSendto.Size = New System.Drawing.Size(326, 26)
        Me.txtSendto.TabIndex = 16
        '
        'txtStunPort
        '
        Me.txtStunPort.Location = New System.Drawing.Point(412, 160)
        Me.txtStunPort.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtStunPort.Name = "txtStunPort"
        Me.txtStunPort.Size = New System.Drawing.Size(160, 26)
        Me.txtStunPort.TabIndex = 8
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(328, 165)
        Me.label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(76, 20)
        Me.label7.TabIndex = 0
        Me.label7.Text = "Stun Port"
        '
        'txtSIPPort
        '
        Me.txtSIPPort.Location = New System.Drawing.Point(412, 126)
        Me.txtSIPPort.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSIPPort.Name = "txtSIPPort"
        Me.txtSIPPort.Size = New System.Drawing.Size(160, 26)
        Me.txtSIPPort.TabIndex = 6
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(336, 131)
        Me.label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(68, 20)
        Me.label5.TabIndex = 0
        Me.label5.Text = "SIP Port"
        '
        'txtStunServer
        '
        Me.txtStunServer.Location = New System.Drawing.Point(124, 160)
        Me.txtStunServer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtStunServer.Name = "txtStunServer"
        Me.txtStunServer.Size = New System.Drawing.Size(160, 26)
        Me.txtStunServer.TabIndex = 7
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(412, 25)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(160, 26)
        Me.txtPassword.TabIndex = 1
        '
        'txtSIPServer
        '
        Me.txtSIPServer.Location = New System.Drawing.Point(124, 126)
        Me.txtSIPServer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSIPServer.Name = "txtSIPServer"
        Me.txtSIPServer.Size = New System.Drawing.Size(160, 26)
        Me.txtSIPServer.TabIndex = 5
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(22, 165)
        Me.label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(93, 20)
        Me.label6.TabIndex = 0
        Me.label6.Text = "Stun Server"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(326, 29)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(78, 20)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Password"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(30, 131)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(85, 20)
        Me.label4.TabIndex = 0
        Me.label4.Text = "SIP Server"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(124, 25)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(160, 26)
        Me.txtUserName.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(27, 29)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(89, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "User Name"
        '
        'linkLabel1
        '
        Me.linkLabel1.AutoSize = True
        Me.linkLabel1.Location = New System.Drawing.Point(18, 14)
        Me.linkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(395, 20)
        Me.linkLabel1.TabIndex = 4
        Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "Click here to learn more about PortSIP PBX/SIP Server"
        '
        'linkLabel2
        '
        Me.linkLabel2.AutoSize = True
        Me.linkLabel2.Location = New System.Drawing.Point(658, 14)
        Me.linkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.linkLabel2.Name = "linkLabel2"
        Me.linkLabel2.Size = New System.Drawing.Size(253, 20)
        Me.linkLabel2.TabIndex = 5
        Me.linkLabel2.TabStop = True
        Me.linkLabel2.Text = "Click here to send email to PortSIP"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Location = New System.Drawing.Point(34, 194)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(538, 46)
        Me.Panel1.TabIndex = 101
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(14, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(237, 24)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Peer to Peer Presence mode"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(298, 12)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(192, 24)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Presence Agent mode"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1139, 828)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.linkLabel1)
        Me.Controls.Add(Me.linkLabel2)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "PortSIP SIPIMSample"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private txtAuthName As System.Windows.Forms.TextBox
	Private groupBox1 As System.Windows.Forms.GroupBox
	Private label9 As System.Windows.Forms.Label
	Private txtUserDomain As System.Windows.Forms.TextBox
	Private txtDisplayName As System.Windows.Forms.TextBox
	Private label10 As System.Windows.Forms.Label
	Private label8 As System.Windows.Forms.Label
	Private label13 As System.Windows.Forms.Label
	Private label11 As System.Windows.Forms.Label
	Private label12 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private ContactsList As System.Windows.Forms.ListView
	Private ListBoxSIPLog As System.Windows.Forms.ListBox
	Private BtnOffline As System.Windows.Forms.Button
	Private BtnClearContact As System.Windows.Forms.Button
	Private BtnDelContact As System.Windows.Forms.Button
	Private BtnAddContact As System.Windows.Forms.Button
	Private BtnSetStatus As System.Windows.Forms.Button
	Private BtnSend As System.Windows.Forms.Button
	Private BtnOnline As System.Windows.Forms.Button
	Private txtMessage As System.Windows.Forms.TextBox
	Private txtContact As System.Windows.Forms.TextBox
	Private txtStatus As System.Windows.Forms.TextBox
	Private txtSendto As System.Windows.Forms.TextBox
	Private txtStunPort As System.Windows.Forms.TextBox
	Private label7 As System.Windows.Forms.Label
	Private txtSIPPort As System.Windows.Forms.TextBox
	Private label5 As System.Windows.Forms.Label
	Private txtStunServer As System.Windows.Forms.TextBox
	Private txtPassword As System.Windows.Forms.TextBox
	Private txtSIPServer As System.Windows.Forms.TextBox
	Private label6 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private txtUserName As System.Windows.Forms.TextBox
	Private label1 As System.Windows.Forms.Label
	Private linkLabel1 As System.Windows.Forms.LinkLabel
	Private linkLabel2 As System.Windows.Forms.LinkLabel
	Private BtnUpdateContact As System.Windows.Forms.Button
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents RadioButton2 As Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As Windows.Forms.RadioButton
End Class

