using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GrapeCity.ActiveReports.Document;

namespace AR7ExportToolbar.ToolStripExport.Exporters
{
	internal class PdfSectionReportExporter : SectionReportExporter
	{
		private const string TypeName = "GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport";
		private const string AssemblyName = "GrapeCity.ActiveReports.Export.Pdf.v7";

		public PdfSectionReportExporter() : base(TypeName, AssemblyName)
		{
		}

		public override void Export(SectionDocument document, string filename, NameValueCollection settings)
		{
			
		}
	}
}
