using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GrapeCity.ActiveReports.Document;
using GrapeCity.ActiveReports.Export;

namespace AR7ExportToolbar.ToolStripExport
{
	/// <summary>
	/// Wraps a particular export for Section reports in a generic manner
	/// Similar to how RenderingExtensions work for Page reports
	/// </summary>
	public interface ISectionReportExporter
	{
		/// <summary>
		///		Determines whether this export is available at runtime
		/// </summary>
		/// <returns>true if the export type is available at runtime, false if its not available</returns>
		bool IsAvailable();

		/*
		/// <summary>
		///		Exports the report using the export filter using the provided settings
		/// </summary>
		/// <param name="document">The report to export</param>
		/// <param name="filename">The file to export the report to</param>
		/// <param name="settings">The settings to use for the export</param>
		void Export(SectionDocument document, string filename, NameValueCollection settings);
		*/
		
		IDocumentExportEx GetExporter();

		string DefaultExtension { get; }
		string FileDialogFilter { get; }
	}
}
