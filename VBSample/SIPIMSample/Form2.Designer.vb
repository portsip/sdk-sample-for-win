Partial Class Form2
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
		Me.button2 = New System.Windows.Forms.Button()
		Me.lblFrom = New System.Windows.Forms.Label()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.button1 = New System.Windows.Forms.Button()
		Me.groupBox1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' button2
		' 
		Me.button2.Location = New System.Drawing.Point(177, 128)
		Me.button2.Name = "button2"
		Me.button2.Size = New System.Drawing.Size(75, 23)
		Me.button2.TabIndex = 0
		Me.button2.Text = "Reject"
		Me.button2.UseVisualStyleBackColor = True
		AddHandler Me.button2.Click, New System.EventHandler(AddressOf Me.button2_Click)
		' 
		' lblFrom
		' 
		Me.lblFrom.AutoSize = True
		Me.lblFrom.Location = New System.Drawing.Point(64, 36)
		Me.lblFrom.Name = "lblFrom"
		Me.lblFrom.Size = New System.Drawing.Size(0, 13)
		Me.lblFrom.TabIndex = 1
		Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		' 
		' groupBox1
		' 
		Me.groupBox1.Controls.Add(Me.button2)
		Me.groupBox1.Controls.Add(Me.lblFrom)
		Me.groupBox1.Controls.Add(Me.label1)
		Me.groupBox1.Controls.Add(Me.button1)
		Me.groupBox1.Location = New System.Drawing.Point(12, 12)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(319, 163)
		Me.groupBox1.TabIndex = 3
		Me.groupBox1.TabStop = False
		' 
		' label1
		' 
		Me.label1.AutoSize = True
		Me.label1.Location = New System.Drawing.Point(36, 58)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(247, 13)
		Me.label1.TabIndex = 1
		Me.label1.Text = "wants to communicate with you and see your satus"
		' 
		' button1
		' 
		Me.button1.Location = New System.Drawing.Point(67, 128)
		Me.button1.Name = "button1"
		Me.button1.Size = New System.Drawing.Size(75, 23)
		Me.button1.TabIndex = 0
		Me.button1.Text = "Accept"
		Me.button1.UseVisualStyleBackColor = True
		AddHandler Me.button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
		' 
		' Form2
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(341, 187)
		Me.Controls.Add(Me.groupBox1)
		Me.MaximizeBox = False
		Me.Name = "Form2"
		Me.Text = "Online Status Request"
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private button2 As System.Windows.Forms.Button
	Private lblFrom As System.Windows.Forms.Label
	Private groupBox1 As System.Windows.Forms.GroupBox
	Private label1 As System.Windows.Forms.Label
	Private button1 As System.Windows.Forms.Button
End Class
