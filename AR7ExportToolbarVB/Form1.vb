Public Class Form1
	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Dim button As ExportToolStripButton = New ExportToolStripButton(Viewer1)
		' button.AvailableExports.Remove("PDF") ' remove exports that you don't want to make available, even if the assembly is there

		Viewer1.Toolbar.MainBar.Items.Insert(3, button)
	End Sub

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Viewer1.LoadDocument("PageReport1.rdlx")
	End Sub
End Class
