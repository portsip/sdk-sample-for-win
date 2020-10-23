Partial Class TransferCallForm
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
		Me.TextBoxLineNum = New System.Windows.Forms.TextBox()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.TextBoxTranferNumber = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		' 
		' TextBoxLineNum
		' 
		Me.TextBoxLineNum.Location = New System.Drawing.Point(67, 139)
		Me.TextBoxLineNum.Name = "TextBoxLineNum"
		Me.TextBoxLineNum.Size = New System.Drawing.Size(76, 20)
		Me.TextBoxLineNum.TabIndex = 55
		' 
		' label5
		' 
		Me.label5.AutoSize = True
		Me.label5.Location = New System.Drawing.Point(18, 144)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(47, 13)
		Me.label5.TabIndex = 54
		Me.label5.Text = "Line No."
		' 
		' label4
		' 
		Me.label4.AutoSize = True
		Me.label4.Location = New System.Drawing.Point(18, 121)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(150, 13)
		Me.label4.TabIndex = 53
		Me.label4.Text = "line would you want to replace"
		' 
		' label3
		' 
		Me.label3.AutoSize = True
		Me.label3.Location = New System.Drawing.Point(18, 102)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(197, 13)
		Me.label3.TabIndex = 52
		Me.label3.Text = "For attended transfer,please enter which"
		' 
		' Label2
		' 
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(18, 51)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(176, 13)
		Me.Label2.TabIndex = 51
		Me.Label2.Text = "(Likes: sip:number@sip.portsip.com)"
		' 
		' Button1
		' 
		Me.Button1.Location = New System.Drawing.Point(103, 73)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 21)
		Me.Button1.TabIndex = 50
		Me.Button1.Text = "Transfer"
		Me.Button1.UseVisualStyleBackColor = True
		AddHandler Me.Button1.Click, New System.EventHandler(AddressOf Me.Button1_Click)
		' 
		' TextBoxTranferNumber
		' 
		Me.TextBoxTranferNumber.Location = New System.Drawing.Point(14, 25)
		Me.TextBoxTranferNumber.Name = "TextBoxTranferNumber"
		Me.TextBoxTranferNumber.Size = New System.Drawing.Size(249, 20)
		Me.TextBoxTranferNumber.TabIndex = 49
		' 
		' Label1
		' 
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(114, 13)
		Me.Label1.TabIndex = 48
		Me.Label1.Text = "Enter Transfer Number"
		' 
		' TransferCallForm
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(281, 176)
		Me.Controls.Add(Me.TextBoxLineNum)
		Me.Controls.Add(Me.label5)
		Me.Controls.Add(Me.label4)
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.TextBoxTranferNumber)
		Me.Controls.Add(Me.Label1)
		Me.MaximizeBox = False
		Me.Name = "TransferCallForm"
		Me.Text = "TransferCallForm"
		AddHandler Me.Load, New System.EventHandler(AddressOf Me.TransferCallForm_Load)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private TextBoxLineNum As System.Windows.Forms.TextBox
	Private label5 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Friend Label2 As System.Windows.Forms.Label
    Private WithEvents Button1 As System.Windows.Forms.Button
	Friend TextBoxTranferNumber As System.Windows.Forms.TextBox
	Friend Label1 As System.Windows.Forms.Label
End Class
