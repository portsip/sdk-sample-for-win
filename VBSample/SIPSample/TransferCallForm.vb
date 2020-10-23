Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Partial Class TransferCallForm
	Inherits Form
	Public Sub New()
		InitializeComponent()
	End Sub

	Private TransferNumber As String = String.Empty

	Public Function GetTransferNumber() As String
		Return TransferNumber
	End Function

	Public Function GetReplaceLineNum() As Integer
		If TextBoxLineNum.Text.Length <= 0 Then
			Return 0
		End If

		Return Integer.Parse(TextBoxLineNum.Text)
	End Function

	Private Sub TransferCallForm_Load(sender As Object, e As EventArgs)
		TransferNumber = ""
		TextBoxTranferNumber.Text = ""

		TextBoxLineNum.Text = ""
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs)
		If TextBoxTranferNumber.Text.Length > 0 Then
			TransferNumber = TextBoxTranferNumber.Text
			TextBoxTranferNumber.Text = ""
			Me.DialogResult = DialogResult.OK
		Else
			MessageBox.Show("Please enter the transfer number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
	End Sub
End Class
