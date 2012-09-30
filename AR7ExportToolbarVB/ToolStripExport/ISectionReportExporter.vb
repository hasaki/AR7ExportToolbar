Imports GrapeCity.ActiveReports.Document
Imports GrapeCity.ActiveReports.Export

Public Interface ISectionReportExporter
	Function IsAvailable() As Boolean

	Function GetExporter() As IDocumentExportEx

	ReadOnly Property DefaultExtension As String
	ReadOnly Property FileDialogFilter As String
End Interface
