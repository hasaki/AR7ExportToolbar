<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.Viewer1 = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
		Me.SuspendLayout()
		'
		'Viewer1
		'
		Me.Viewer1.AnnotationToolbarVisible = False
		Me.Viewer1.CurrentPage = 0
		Me.Viewer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Viewer1.HyperlinkBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.Viewer1.HyperlinkForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.Viewer1.Location = New System.Drawing.Point(0, 0)
		Me.Viewer1.Name = "Viewer1"
		Me.Viewer1.PagesBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.Viewer1.PreviewPages = 0
		Me.Viewer1.SearchResultsBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.Viewer1.SearchResultsForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(139, Byte), Integer))
		'
		'
		'
		'
		'
		'
		Me.Viewer1.Sidebar.ParametersPanel.ContextMenu = Nothing
		Me.Viewer1.Sidebar.ParametersPanel.Width = 180
		'
		'
		'
		Me.Viewer1.Sidebar.SearchPanel.ContextMenu = Nothing
		Me.Viewer1.Sidebar.SearchPanel.Width = 180
		Me.Viewer1.Sidebar.SelectedIndex = 0
		'
		'
		'
		Me.Viewer1.Sidebar.ThumbnailsPanel.ContextMenu = Nothing
		Me.Viewer1.Sidebar.ThumbnailsPanel.Width = 180
		'
		'
		'
		Me.Viewer1.Sidebar.TocPanel.ContextMenu = Nothing
		Me.Viewer1.Sidebar.TocPanel.Width = 180
		Me.Viewer1.Sidebar.Width = 180
		Me.Viewer1.Size = New System.Drawing.Size(821, 578)
		Me.Viewer1.SplitView = False
		Me.Viewer1.TabIndex = 0
		Me.Viewer1.ViewType = GrapeCity.Viewer.Common.Model.ViewType.SinglePage
		Me.Viewer1.Zoom = 1.0!
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(821, 578)
		Me.Controls.Add(Me.Viewer1)
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents Viewer1 As GrapeCity.ActiveReports.Viewer.Win.Viewer

End Class
