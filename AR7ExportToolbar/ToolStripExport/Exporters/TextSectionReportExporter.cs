using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GrapeCity.ActiveReports.Document;
using GrapeCity.ActiveReports.Export;

namespace AR7ExportToolbar.ToolStripExport.Exporters
{
	public class TextSectionReportExporter : SectionReportExporter
	{
		private const string TypeName = "GrapeCity.ActiveReports.Export.Xml.Section.TextExport";
		private const string AssemblyName = "GrapeCity.ActiveReports.Export.Xml.v7";

		public TextSectionReportExporter()
			: base(TypeName, AssemblyName)
		{
		}

		public override void Export(SectionDocument document, string filename, NameValueCollection settings)
		{
			throw new NotImplementedException();
		}

		public override string DefaultExtension
		{
			get { return "txt"; }
		}

		public override string FileDialogFilter
		{
			get { return "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"; }
		}
	}
}
