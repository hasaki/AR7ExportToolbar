using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GrapeCity.ActiveReports.Document;
using GrapeCity.ActiveReports.Export;

namespace AR7ExportToolbar.ToolStripExport.Exporters
{
	public class ExcelSectionReportExporter : SectionReportExporter
	{
		private const string TypeName = "GrapeCity.ActiveReports.Export.Excel.Section.XlsExport";
		private const string AssemblyName = "GrapeCity.ActiveReports.Export.Excel.v7";

		public ExcelSectionReportExporter()
			: base(TypeName, AssemblyName)
		{
		}

		public override void Export(SectionDocument document, string filename, NameValueCollection settings)
		{
			throw new NotImplementedException();
		}

		public override string DefaultExtension
		{
			get { return "xls"; }
		}

		public override string FileDialogFilter
		{
			get { return "Excel Files (*.xls)|*.xls|All Files (*.*)|*.*"; }
		}
	}
}
