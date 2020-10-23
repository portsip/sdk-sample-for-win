namespace SIPIMSample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAuthName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnUpdateContact = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserDomain = new System.Windows.Forms.TextBox();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ContactsList = new System.Windows.Forms.ListView();
            this.ListBoxSIPLog = new System.Windows.Forms.ListBox();
            this.BtnOffline = new System.Windows.Forms.Button();
            this.BtnClearContact = new System.Windows.Forms.Button();
            this.BtnDelContact = new System.Windows.Forms.Button();
            this.BtnAddContact = new System.Windows.Forms.Button();
            this.BtnSetStatus = new System.Windows.Forms.Button();
            this.BtnSend = new System.Windows.Forms.Button();
            this.BtnOnline = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtSendto = new System.Windows.Forms.TextBox();
            this.txtStunPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSIPPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStunServer = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtSIPServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAuthName
            // 
            this.txtAuthName.Location = new System.Drawing.Point(275, 41);
            this.txtAuthName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAuthName.Name = "txtAuthName";
            this.txtAuthName.Size = new System.Drawing.Size(108, 20);
            this.txtAuthName.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.BtnUpdateContact);
            this.groupBox1.Controls.Add(this.txtAuthName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtUserDomain);
            this.groupBox1.Controls.Add(this.txtDisplayName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ContactsList);
            this.groupBox1.Controls.Add(this.ListBoxSIPLog);
            this.groupBox1.Controls.Add(this.BtnOffline);
            this.groupBox1.Controls.Add(this.BtnClearContact);
            this.groupBox1.Controls.Add(this.BtnDelContact);
            this.groupBox1.Controls.Add(this.BtnAddContact);
            this.groupBox1.Controls.Add(this.BtnSetStatus);
            this.groupBox1.Controls.Add(this.BtnSend);
            this.groupBox1.Controls.Add(this.BtnOnline);
            this.groupBox1.Controls.Add(this.txtMessage);
            this.groupBox1.Controls.Add(this.txtContact);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.txtSendto);
            this.groupBox1.Controls.Add(this.txtStunPort);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSIPPort);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtStunServer);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtSIPServer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(723, 494);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SIP";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(232, 140);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(131, 17);
            this.radioButton2.TabIndex = 104;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Presence Agent Mode";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(29, 140);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(123, 17);
            this.radioButton1.TabIndex = 103;
            this.radioButton1.Text = "P2P Presence Mode";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(21, 130);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 33);
            this.panel1.TabIndex = 101;
            // 
            // BtnUpdateContact
            // 
            this.BtnUpdateContact.Location = new System.Drawing.Point(150, 457);
            this.BtnUpdateContact.Name = "BtnUpdateContact";
            this.BtnUpdateContact.Size = new System.Drawing.Size(100, 23);
            this.BtnUpdateContact.TabIndex = 100;
            this.BtnUpdateContact.Text = "Update Contact";
            this.BtnUpdateContact.UseVisualStyleBackColor = true;
            this.BtnUpdateContact.Click += new System.EventHandler(this.BtnUpdateContact_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(210, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Auth Name";
            // 
            // txtUserDomain
            // 
            this.txtUserDomain.Location = new System.Drawing.Point(83, 60);
            this.txtUserDomain.Name = "txtUserDomain";
            this.txtUserDomain.Size = new System.Drawing.Size(108, 20);
            this.txtUserDomain.TabIndex = 4;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(83, 38);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(108, 20);
            this.txtDisplayName.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "User Domain";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Display Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(420, 355);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Send Message";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(423, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "My Status";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(423, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(198, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Must likes sip:test@sip.portsip.com:5060";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(420, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Send to(Must likes sip:test@sip.portsip.com:5060)";
            // 
            // ContactsList
            // 
            this.ContactsList.FullRowSelect = true;
            this.ContactsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ContactsList.HideSelection = false;
            this.ContactsList.Location = new System.Drawing.Point(13, 205);
            this.ContactsList.MultiSelect = false;
            this.ContactsList.Name = "ContactsList";
            this.ContactsList.Size = new System.Drawing.Size(370, 246);
            this.ContactsList.TabIndex = 5;
            this.ContactsList.UseCompatibleStateImageBehavior = false;
            this.ContactsList.View = System.Windows.Forms.View.Details;
            // 
            // ListBoxSIPLog
            // 
            this.ListBoxSIPLog.FormattingEnabled = true;
            this.ListBoxSIPLog.Location = new System.Drawing.Point(423, 19);
            this.ListBoxSIPLog.Name = "ListBoxSIPLog";
            this.ListBoxSIPLog.Size = new System.Drawing.Size(285, 121);
            this.ListBoxSIPLog.TabIndex = 99;
            // 
            // BtnOffline
            // 
            this.BtnOffline.Location = new System.Drawing.Point(308, 173);
            this.BtnOffline.Name = "BtnOffline";
            this.BtnOffline.Size = new System.Drawing.Size(75, 23);
            this.BtnOffline.TabIndex = 10;
            this.BtnOffline.Text = "Offine";
            this.BtnOffline.UseVisualStyleBackColor = true;
            this.BtnOffline.Click += new System.EventHandler(this.BtnOffline_Click);
            // 
            // BtnClearContact
            // 
            this.BtnClearContact.Location = new System.Drawing.Point(283, 457);
            this.BtnClearContact.Name = "BtnClearContact";
            this.BtnClearContact.Size = new System.Drawing.Size(100, 23);
            this.BtnClearContact.TabIndex = 12;
            this.BtnClearContact.Text = "Clear Contact";
            this.BtnClearContact.UseVisualStyleBackColor = true;
            this.BtnClearContact.Click += new System.EventHandler(this.BtnClearContact_Click);
            // 
            // BtnDelContact
            // 
            this.BtnDelContact.Location = new System.Drawing.Point(13, 457);
            this.BtnDelContact.Name = "BtnDelContact";
            this.BtnDelContact.Size = new System.Drawing.Size(100, 23);
            this.BtnDelContact.TabIndex = 12;
            this.BtnDelContact.Text = "Del Contact";
            this.BtnDelContact.UseVisualStyleBackColor = true;
            this.BtnDelContact.Click += new System.EventHandler(this.BtnDelContact_Click);
            // 
            // BtnAddContact
            // 
            this.BtnAddContact.Location = new System.Drawing.Point(423, 247);
            this.BtnAddContact.Name = "BtnAddContact";
            this.BtnAddContact.Size = new System.Drawing.Size(100, 23);
            this.BtnAddContact.TabIndex = 12;
            this.BtnAddContact.Text = "Add contact";
            this.BtnAddContact.UseVisualStyleBackColor = true;
            this.BtnAddContact.Click += new System.EventHandler(this.BtnAddContact_Click);
            // 
            // BtnSetStatus
            // 
            this.BtnSetStatus.Location = new System.Drawing.Point(426, 319);
            this.BtnSetStatus.Name = "BtnSetStatus";
            this.BtnSetStatus.Size = new System.Drawing.Size(75, 23);
            this.BtnSetStatus.TabIndex = 14;
            this.BtnSetStatus.Text = "Set Status";
            this.BtnSetStatus.UseVisualStyleBackColor = true;
            this.BtnSetStatus.Click += new System.EventHandler(this.BtnSetStatus_Click);
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(648, 465);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(57, 23);
            this.BtnSend.TabIndex = 17;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // BtnOnline
            // 
            this.BtnOnline.Location = new System.Drawing.Point(221, 173);
            this.BtnOnline.Name = "BtnOnline";
            this.BtnOnline.Size = new System.Drawing.Size(75, 23);
            this.BtnOnline.TabIndex = 9;
            this.BtnOnline.Text = "Online";
            this.BtnOnline.UseVisualStyleBackColor = true;
            this.BtnOnline.Click += new System.EventHandler(this.BtnOnline_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(423, 371);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(258, 80);
            this.txtMessage.TabIndex = 15;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(426, 221);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(258, 20);
            this.txtContact.TabIndex = 11;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(426, 293);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(258, 20);
            this.txtStatus.TabIndex = 13;
            // 
            // txtSendto
            // 
            this.txtSendto.Location = new System.Drawing.Point(423, 468);
            this.txtSendto.Name = "txtSendto";
            this.txtSendto.Size = new System.Drawing.Size(219, 20);
            this.txtSendto.TabIndex = 16;
            // 
            // txtStunPort
            // 
            this.txtStunPort.Location = new System.Drawing.Point(275, 104);
            this.txtStunPort.Name = "txtStunPort";
            this.txtStunPort.Size = new System.Drawing.Size(108, 20);
            this.txtStunPort.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Stun Port";
            // 
            // txtSIPPort
            // 
            this.txtSIPPort.Location = new System.Drawing.Point(275, 82);
            this.txtSIPPort.Name = "txtSIPPort";
            this.txtSIPPort.Size = new System.Drawing.Size(108, 20);
            this.txtSIPPort.TabIndex = 6;
            this.txtSIPPort.Text = "5060";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "SIP Port";
            // 
            // txtStunServer
            // 
            this.txtStunServer.Location = new System.Drawing.Point(83, 104);
            this.txtStunServer.Name = "txtStunServer";
            this.txtStunServer.Size = new System.Drawing.Size(108, 20);
            this.txtStunServer.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(275, 16);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(108, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtSIPServer
            // 
            this.txtSIPServer.Location = new System.Drawing.Point(83, 82);
            this.txtSIPServer.Name = "txtSIPServer";
            this.txtSIPServer.Size = new System.Drawing.Size(108, 20);
            this.txtSIPServer.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Stun Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "SIP Server";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(83, 16);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(108, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(241, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click here to learn about PortSIP PBX/SIP Server";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(487, 11);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(170, 13);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Click here to send email to PortSIP";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 543);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.linkLabel2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "PortSIP SIPIMSample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAuthName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUserDomain;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView ContactsList;
        private System.Windows.Forms.ListBox ListBoxSIPLog;
        private System.Windows.Forms.Button BtnOffline;
        private System.Windows.Forms.Button BtnClearContact;
        private System.Windows.Forms.Button BtnDelContact;
        private System.Windows.Forms.Button BtnAddContact;
        private System.Windows.Forms.Button BtnSetStatus;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.Button BtnOnline;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtSendto;
        private System.Windows.Forms.TextBox txtStunPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSIPPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStunServer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtSIPServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button BtnUpdateContact;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panel1;
    }
}

