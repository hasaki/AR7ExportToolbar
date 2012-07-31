using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using GrapeCity.ActiveReports.Document;
using GrapeCity.ActiveReports.Extensibility.Rendering;
using GrapeCity.ActiveReports.Rendering.IO;

namespace AR7ExportToolbar.ToolStripExport.Exporters
{
	public class PageReportExporter : IPageReportExporter
	{
		private readonly string FullTypeName;

		// Gets the version of ActiveReports 7 used in the project
		// so our reflection calls try to load the right assembly
		private static string GetAssemblyVersion()
		{
			return typeof(PageDocument).Assembly.GetName().Version.ToString();
		}

		public PageReportExporter(string type, string assembly) : this(type, assembly, GetAssemblyVersion())
		{
		}

		private PageReportExporter(string type, string assembly, string version)
		{
			const string FullTypeNameFormat = "{0}, {1}, Version={2}, Culture=neutral, PublicKeyToken=cc4967777c49a3ff";

			FullTypeName = string.Format(FullTypeNameFormat, type, assembly, version);
		}

		private Type CreateType()
		{
			return Type.GetType(FullTypeName, false, true);
		}

		public bool IsAvailable()
		{
			var exportType = CreateType();

			return (exportType != null);
		}

		public void Export(PageDocument document, string filename, NameValueCollection settings)
		{
			if (document == null)
				throw new ArgumentNullException("document");

			var file = new FileInfo(filename);

			var exportType = CreateType();
			Debug.Assert(exportType != null, "Attempted to export a type that isn't available");

			IRenderingExtension re = Activator.CreateInstance(exportType) as IRenderingExtension;
			Debug.Assert(re != null, "Could not load the appropriate rendering extension");
			
			var outputFileNamePrefix = Path.GetFileNameWithoutExtension(filename);
			var streamProvider = new FileStreamProvider(file.Directory, outputFileNamePrefix);

			if (settings == null)
				document.Render(re, streamProvider);
			else
				document.Render(re, streamProvider, settings);
		}
	}
}
