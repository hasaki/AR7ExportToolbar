using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AR7ExportToolbar.ToolStripExport.Exporters;

namespace AR7ExportToolbar
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var exp = new PageReportExporter("GrapeCity.ActiveReports.Export.Pdf.Page.PdfRenderingExtension", "GrapeCity.ActiveReports.Export.Pdf.v7");
			//var exp = new PdfSectionReportExporter();
			exp.IsAvailable();
			exp.Export(null, "C:\\test\\out.pdf", null);


			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
