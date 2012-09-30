Imports GrapeCity.ActiveReports.Document
Imports System.Collections.Specialized

Public Class RtfSectionReportExporter
	Inherits SectionReportExporter
	Private Const TypeName As String = "GrapeCity.ActiveReports.Export.Word.Section.RtfExport"
	Private Const AssemblyName As String = "GrapeCity.ActiveReports.Export.Word.v7"

	Public Sub New()
		MyBase.New(TypeName, AssemblyName)
	End Sub

	Public Overrides Sub Export(document As SectionDocument, filename As String, settings As NameValueCollection)
		Throw New NotImplementedException()
	End Sub

	Public Overrides ReadOnly Property DefaultExtension() As String
		Get
			Return "rtf"
		End Get
	End Property

	Public Overrides ReadOnly Property FileDialogFilter() As String
		Get
			Return "Rich-Text Files (*.rtf)|*.rtf|All Files (*.*)|*.*"
		End Get
	End Property
End Class
