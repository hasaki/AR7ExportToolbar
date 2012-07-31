using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GrapeCity.ActiveReports.Document;
using GrapeCity.ActiveReports.Export;

namespace AR7ExportToolbar.ToolStripExport.Exporters
{
	public abstract class SectionReportExporter : ISectionReportExporter
	{
		private static string GetAssemblyVersion()
		{
			return typeof(SectionDocument).Assembly.GetName().Version.ToString();
		}

		private readonly string FullTypeName;

		protected SectionReportExporter(string type, string assembly) : this(type, assembly, GetAssemblyVersion())
		{
		}

		protected SectionReportExporter(string type, string assembly, string version)
		{
			const string FullTypeNameFormat = "{0}, {1}, Version={2}, Culture=neutral, PublicKeyToken=cc4967777c49a3ff";

			FullTypeName = string.Format(FullTypeNameFormat, type, assembly, version);
		}

		protected Type CreateType()
		{
			return Type.GetType(FullTypeName, false, true);
		}

		public bool IsAvailable()
		{
			var exportType = CreateType();

			return (exportType != null);
		}

		public abstract void Export(SectionDocument document, string filename, NameValueCollection settings);

		public virtual IDocumentExportEx GetExporter()
		{
			var type = CreateType();
			var exp = Activator.CreateInstance(type) as IDocumentExportEx;

			return exp;
		}

		public abstract string DefaultExtension
		{
			get;
		}

		public abstract string FileDialogFilter
		{
			get;
		}
	}
}
