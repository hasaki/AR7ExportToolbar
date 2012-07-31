using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GrapeCity.ActiveReports.Document;

namespace AR7ExportToolbar.ToolStripExport.Exporters
{
	public class HtmlSectionReportExporter : SectionReportExporter
	{
		private const string TypeName = "GrapeCity.ActiveReports.Export.Html.Section.HtmlExport";
		private const string AssemblyName = "GrapeCity.ActiveReports.Export.Html.v7";

		public HtmlSectionReportExporter()
			: base(TypeName, AssemblyName)
		{
		}

		public override void Export(SectionDocument document, string filename, NameValueCollection settings)
		{
			throw new NotImplementedException();
		}

		public override string DefaultExtension
		{
			get { return "html"; }
		}

		public override string FileDialogFilter
		{
			get { return "HTML Files (*.html)|*.html|All Files (*.*)|*.*"; }
		}
	}
}
