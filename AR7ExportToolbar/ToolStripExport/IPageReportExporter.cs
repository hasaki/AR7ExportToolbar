using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GrapeCity.ActiveReports.Document;

namespace AR7ExportToolbar.ToolStripExport
{
	/// <summary>
	/// Wraps the export process for PageReports
	/// </summary>
	public interface IPageReportExporter
	{
		bool IsAvailable();

		void Export(PageDocument document, string filename, NameValueCollection settings);
	}
}
