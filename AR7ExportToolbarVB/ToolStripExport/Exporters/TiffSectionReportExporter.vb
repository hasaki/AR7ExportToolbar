Imports GrapeCity.ActiveReports.Document
Imports System.Collections.Specialized

Public Class TiffSectionReportExporter
	Inherits SectionReportExporter
	Private Const TypeName As String = "GrapeCity.ActiveReports.Export.Image.Tiff.Section.TiffExport"
	Private Const AssemblyName As String = "GrapeCity.ActiveReports.Export.Image.v7"

	Public Sub New()
		MyBase.New(TypeName, AssemblyName)
	End Sub

	Public Overrides Sub Export(document As SectionDocument, filename As String, settings As NameValueCollection)
		Throw New NotImplementedException()
	End Sub

	Public Overrides ReadOnly Property DefaultExtension() As String
		Get
			Return "tiff"
		End Get
	End Property

	Public Overrides ReadOnly Property FileDialogFilter() As String
		Get
			Return "TIFF Files (*.tiff)|*.tiff|All Files (*.*)|*.*"
		End Get
	End Property
End Class