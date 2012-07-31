using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GrapeCity.ActiveReports.Document;
using GrapeCity.ActiveReports.Export;

namespace AR7ExportToolbar.ToolStripExport.Exporters
{
	public class TiffSectionReportExporter : SectionReportExporter
	{
		private const string TypeName = "GrapeCity.ActiveReports.Export.Image.Tiff.Section.TiffExport";
		private const string AssemblyName = "GrapeCity.ActiveReports.Export.Image.v7";

		public TiffSectionReportExporter() : base(TypeName, AssemblyName)
		{
		}

		public override void Export(SectionDocument document, string filename, NameValueCollection settings)
		{
			throw new NotImplementedException();
		}

		public override string DefaultExtension
		{
			get { return "tiff"; }
		}

		public override string FileDialogFilter
		{
			get { return "TIFF Files (*.tiff)|*.tiff|All Files (*.*)|*.*"; }
		}
	}
}
