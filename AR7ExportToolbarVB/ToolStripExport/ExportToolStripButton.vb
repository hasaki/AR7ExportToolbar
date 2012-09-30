Imports GrapeCity.ActiveReports.Viewer.Win

Public Class ExportToolStripButton
	Inherits ToolStripDropDownButton

	Private Shared ReadOnly ToolStripButtonImage As Bitmap = New Bitmap(GetType(ExportToolStripButton), "ReportViewer.bmp")

	Private ReadOnly _host As Viewer

	Private _availableExports As IDictionary(Of String, ExportItem)
	Public Property AvailableExports As IDictionary(Of String, ExportItem)
		Get
			Return _availableExports
		End Get
		Private Set(value As IDictionary(Of String, ExportItem))
			_availableExports = value
		End Set
	End Property

	Private _verifiedAvailableExports As IDictionary(Of String, ExportItem)
	Public Property VerifiedAvailableExports As IDictionary(Of String, ExportItem)
		Get
			Return _verifiedAvailableExports
		End Get
		Private Set(value As IDictionary(Of String, ExportItem))
			_verifiedAvailableExports = value
		End Set
	End Property

	Private _dropDownItems As Dictionary(Of String, ToolStripMenuItem) = Nothing

	Private _dropDownItemsCreated As Boolean = False

	Public Sub New(host As Viewer)
		MyBase.New("Export")

		_host = host

		Enabled = False
		AttachHostEvents()

		AvailableExports = New Dictionary(Of String, ExportItem)()
		AddAllExports()

		Image = ToolStripButtonImage
		ImageTransparentColor = ToolStripButtonImage.GetPixel(0, 0)

		AddHandler Me.DropDownOpening, AddressOf OnDropDownOpening

	End Sub

	Protected Overrides Sub Dispose(disposing As Boolean)
		If disposing Then
			DetachHostEvents()
		End If

		MyBase.Dispose(disposing)
	End Sub

	Private Sub AttachHostEvents()
		AddHandler _host.LoadCompleted, AddressOf OnHostLoadCompleted
	End Sub

	Private Sub DetachHostEvents()
		RemoveHandler _host.LoadCompleted, AddressOf OnHostLoadCompleted
	End Sub

	Private Sub OnHostLoadCompleted(sender As Object, e As EventArgs)
		Enabled = True
	End Sub

	Private Sub AddAllExports()
		AddAvailableExport("PDF", "PDF", New PdfSectionReportExporter())
	End Sub

	Private Sub AddAvailableExport(name As String, localizedName As String, exporter As ISectionReportExporter)
		Dim item = New ExportItem()
		With item
			.Name = name
			.LocalizedName = localizedName
			.SectionReportExport = exporter
		End With

		AvailableExports.Add(name, item)
	End Sub

	Private Sub VerifyExports()
		Dim verifiedExports = New Dictionary(Of String, ExportItem)()

		For Each exportKV In AvailableExports
			Dim item = exportKV.Value

			If Not (item Is Nothing) Then
				Dim available = False

				If (Not (item.SectionReportExport Is Nothing)) AndAlso (item.SectionReportExport.IsAvailable()) Then
					available = True
				End If

				If available Then
					verifiedExports.Add(exportKV.Key, exportKV.Value)
				End If
			End If
		Next

		VerifiedAvailableExports = verifiedExports
	End Sub

	Private Sub CreateDropDownItems()
		VerifyExports()

		_dropDownItems = New Dictionary(Of String, ToolStripMenuItem)()

		For Each export In VerifiedAvailableExports
			Dim menuItem As ToolStripMenuItem = New ToolStripMenuItem(export.Value.LocalizedName, ToolStripButtonImage, AddressOf OnExportItemClicked)
			menuItem.Tag = export.Value
			menuItem.ImageTransparentColor = ToolStripButtonImage.GetPixel(0, 0)

			_dropDownItems.Add(export.Key, menuItem)
			DropDownItems.Add(menuItem)
		Next

		_dropDownItemsCreated = True
	End Sub

	Private Sub OnDropDownOpening(sender As Object, e As EventArgs)
		If Not _dropDownItemsCreated Then
			CreateDropDownItems()
		End If
	End Sub

	Private Sub OnExportItemClicked(sender As Object, e As EventArgs)
		Dim item As ToolStripItem = TryCast(sender, ToolStripItem)

		If item Is Nothing Then Return

		Dim exportItem As ExportItem = TryCast(item.Tag, ExportItem)

		If exportItem Is Nothing Then Return

		Dim export As ISectionReportExporter = exportItem.SectionReportExport
		If export Is Nothing Then Return

		Dim exporter As GrapeCity.ActiveReports.Export.IDocumentExportEx = export.GetExporter()
		If exporter Is Nothing Then Return

		Using saveAsDlg As SaveFileDialog = New SaveFileDialog()
			saveAsDlg.DefaultExt = export.DefaultExtension
			saveAsDlg.Filter = export.FileDialogFilter

			If Not saveAsDlg.ShowDialog(_host) = DialogResult.OK Then Return

			_host.Export(exporter, New IO.FileInfo(saveAsDlg.FileName))
		End Using

	End Sub

End Class
