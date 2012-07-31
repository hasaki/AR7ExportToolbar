namespace AR7ExportToolbar
{
	/// <summary>
	/// Summary description for SectionReport1.
	/// </summary>
	partial class SectionReport1
	{
		private GrapeCity.ActiveReports.SectionReportModel.PageHeader pageHeader;
		private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
		private GrapeCity.ActiveReports.SectionReportModel.PageFooter pageFooter;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
			base.Dispose(disposing);
		}

		#region ActiveReport Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SectionReport1));
			this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
			this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
			this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
			this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
			this.reportInfo1 = new GrapeCity.ActiveReports.SectionReportModel.ReportInfo();
			((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// pageHeader
			// 
			this.pageHeader.Height = 0.25F;
			this.pageHeader.Name = "pageHeader";
			// 
			// detail
			// 
			this.detail.ColumnSpacing = 0F;
			this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label1,
            this.reportInfo1});
			this.detail.Height = 2F;
			this.detail.Name = "detail";
			// 
			// pageFooter
			// 
			this.pageFooter.Height = 0.25F;
			this.pageFooter.Name = "pageFooter";
			// 
			// label1
			// 
			this.label1.Height = 0.2F;
			this.label1.HyperLink = null;
			this.label1.Left = 2.417F;
			this.label1.Name = "label1";
			this.label1.Style = "";
			this.label1.Text = "Hello!";
			this.label1.Top = 0.365F;
			this.label1.Width = 1F;
			// 
			// reportInfo1
			// 
			this.reportInfo1.FormatString = "{RunDateTime:M/d/yyyy h:mm tt}";
			this.reportInfo1.Height = 0.2F;
			this.reportInfo1.Left = 2.5F;
			this.reportInfo1.Name = "reportInfo1";
			this.reportInfo1.Style = "";
			this.reportInfo1.Top = 0.8650001F;
			this.reportInfo1.Width = 2.615F;
			// 
			// SectionReport1
			// 
			this.MasterReport = false;
			this.PageSettings.PaperHeight = 11F;
			this.PageSettings.PaperWidth = 8.5F;
			this.Sections.Add(this.pageHeader);
			this.Sections.Add(this.detail);
			this.Sections.Add(this.pageFooter);
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
			((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private GrapeCity.ActiveReports.SectionReportModel.Label label1;
		private GrapeCity.ActiveReports.SectionReportModel.ReportInfo reportInfo1;
	}
}
