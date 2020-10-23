Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Partial Class Form2
	Inherits Form
	Private Accept As Boolean = True
	Public Function GetAccept() As Boolean
		Return Accept
	End Function
	Public Sub New()
		InitializeComponent()
	End Sub
	Public Sub SetContactName(ContactName As String)
		lblFrom.Text = ContactName
	End Sub
	Public Sub SetSubject(Subject As String)
		

	End Sub

	Private Sub button1_Click(sender As Object, e As EventArgs)
		Accept = True
		Close()
	End Sub

	Private Sub button2_Click(sender As Object, e As EventArgs)
		Accept = False
		Close()
	End Sub
End Class
