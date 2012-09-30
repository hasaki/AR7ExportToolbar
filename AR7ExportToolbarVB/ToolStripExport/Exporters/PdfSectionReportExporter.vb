Public Class PdfSectionReportExporter
	Inherits SectionReportExporter

	Private Const TypeName As String = "GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport"
	Private Const AssemblyName As String = "GrapeCity.ActiveReports.Export.Pdf.v7"

	Public Sub New()
		MyBase.New(TypeName, AssemblyName)
	End Sub

	Public Overrides ReadOnly Property DefaultExtension As String
		Get
			Return "pdf"
		End Get
	End Property

	Public Overrides Sub Export(document As GrapeCity.ActiveReports.Document.SectionDocument, filename As String, settings As Specialized.NameValueCollection)

	End Sub

	Public Overrides ReadOnly Property FileDialogFilter As String
		Get
			Return "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
		End Get
	End Property
End Class
