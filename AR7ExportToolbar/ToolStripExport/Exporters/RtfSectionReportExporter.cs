using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GrapeCity.ActiveReports.Document;
using GrapeCity.ActiveReports.Export;

namespace AR7ExportToolbar.ToolStripExport.Exporters
{
	public class RtfSectionReportExporter : SectionReportExporter
	{
		private const string TypeName = "GrapeCity.ActiveReports.Export.Word.Section.RtfExport";
		private const string AssemblyName = "GrapeCity.ActiveReports.Export.Word.v7";

		public RtfSectionReportExporter()
			: base(TypeName, AssemblyName)
		{
		}

		public override void Export(SectionDocument document, string filename, NameValueCollection settings)
		{
			throw new NotImplementedException();
		}

		public override string DefaultExtension
		{
			get { return "rtf"; }
		}

		public override string FileDialogFilter
		{
			get { return "Rich-Text Files (*.rtf)|*.rtf|All Files (*.*)|*.*"; }
		}
	}
}
