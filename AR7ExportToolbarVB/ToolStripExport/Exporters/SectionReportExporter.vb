Imports GrapeCity.ActiveReports.Document
Imports System.Collections.Specialized
Imports GrapeCity.ActiveReports.Export

Public MustInherit Class SectionReportExporter
	Implements ISectionReportExporter

	Private Shared Function GetAssemblyVersion() As String
		Return GetType(SectionDocument).Assembly.GetName().Version.ToString()
	End Function

	Private ReadOnly FullTypeName As String

	Protected Sub New(ByVal type As String, ByVal assembly As String)
		Me.New(type, assembly, GetAssemblyVersion())
	End Sub

	Protected Sub New(ByVal type As String, ByVal assembly As String, ByVal version As String)
		Const FullTypeNameFormat As String = "{0}, {1}, Version={2}, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"

		FullTypeName = String.Format(FullTypeNameFormat, type, assembly, version)
	End Sub

	Protected Function CreateType() As Type
		Return Type.GetType(FullTypeName, False, False)
	End Function

	Public Function IsAvailable() As Boolean _
		Implements ISectionReportExporter.IsAvailable
		Dim exportType = CreateType()

		Return Not (exportType Is Nothing)
	End Function

	Public MustOverride Sub Export(ByVal document As SectionDocument, filename As String, settings As NameValueCollection)

	Public Overridable Function GetExporter() As IDocumentExportEx _
		Implements ISectionReportExporter.GetExporter

		Dim type = CreateType()
		Dim exp = CType(Activator.CreateInstance(type), IDocumentExportEx)

		Return exp
	End Function

	Public MustOverride ReadOnly Property DefaultExtension As String Implements ISectionReportExporter.DefaultExtension
	Public MustOverride ReadOnly Property FileDialogFilter As String Implements ISectionReportExporter.FileDialogFilter

End Class
