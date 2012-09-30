Imports GrapeCity.ActiveReports.Document
Imports System.Collections.Specialized

Public Class ExcelSectionReportExporter
	Inherits SectionReportExporter
	Private Const TypeName As String = "GrapeCity.ActiveReports.Export.Excel.Section.XlsExport"
	Private Const AssemblyName As String = "GrapeCity.ActiveReports.Export.Excel.v7"

	Public Sub New()
		MyBase.New(TypeName, AssemblyName)
	End Sub

	Public Overrides Sub Export(document As SectionDocument, filename As String, settings As NameValueCollection)
		Throw New NotImplementedException()
	End Sub

	Public Overrides ReadOnly Property DefaultExtension() As String
		Get
			Return "xls"
		End Get
	End Property

	Public Overrides ReadOnly Property FileDialogFilter() As String
		Get
			Return "Excel Files (*.xls)|*.xls|All Files (*.*)|*.*"
		End Get
	End Property
End Class
