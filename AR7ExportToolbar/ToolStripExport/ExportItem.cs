using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AR7ExportToolbar.ToolStripExport
{
	public class ExportItem
	{
		/// <summary>
		/// Gets or sets the name of the export
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the name to use in the UI
		/// </summary>
		public string LocalizedName { get; set; }

		/// <summary>
		/// Gets or sets the IPageReportExporter to use to handle page reports
		/// </summary>
		public IPageReportExporter PageReportExport { get; set; }

		/// <summary>
		/// Gets or sets the ISectionReportExporter to handle section reports
		/// </summary>
		public ISectionReportExporter SectionReportExport { get; set; }
	}
}
