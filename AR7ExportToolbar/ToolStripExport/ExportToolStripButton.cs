using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AR7ExportToolbar.ToolStripExport.Exporters;
using GrapeCity.ActiveReports.Document;
using GrapeCity.ActiveReports.Viewer.Win;

namespace AR7ExportToolbar.ToolStripExport
{
	public class ExportToolStripButton : ToolStripDropDownButton
	{
		private static readonly Image ToolStripButtonImage = new Bitmap(typeof(ExportToolStripButton), "ReportViewer.bmp");

		private readonly Viewer host;

		public IDictionary<string, ExportItem> AvailableExports { get; private set; }
		public IDictionary<string, ExportItem> VerifiedAvailableExports { get; private set; }

		private Dictionary<string, ToolStripMenuItem> dropDownItems = null;

		private bool dropDownItemsCreated = false;

		public ExportToolStripButton(Viewer host)
			: base("Export")
		{
			this.host = host;

			AvailableExports = new Dictionary<string, ExportItem>();

			AddAllExports();

			this.DropDownOpening += OnDropDownOpening;
		}

		private void AddAllExports()
		{
			var item = new ExportItem();
			item.Name = "PDF";
			item.LocalizedName = "PDF";
			item.PageReportExport = new PageReportExporter("GrapeCity.ActiveReports.Export.Pdf.Page.PdfRenderingExtension", "GrapeCity.ActiveReports.Export.Pdf.v7");
			item.SectionReportExport = new PdfSectionReportExporter();

			AvailableExports.Add("PDF", item);
		}

		private void VerifyExports()
		{
			var verifiedExports = new Dictionary<string, ExportItem>();

			foreach (var exportKV in AvailableExports)
			{
				var item = exportKV.Value;
				if (item != null)
				{
					bool available = false;

					if (item.PageReportExport != null && item.PageReportExport.IsAvailable())
					{
						available = true;
					}

					if (item.SectionReportExport != null && item.SectionReportExport.IsAvailable())
					{
						available = true;
					}

					if (available)
					{
						verifiedExports.Add(exportKV.Key, exportKV.Value);
					}
				}
			}
		}

		private void CreateDropDownItems()
		{
			VerifyExports();

			dropDownItems = new Dictionary<string, ToolStripMenuItem>();

			foreach (var export in VerifiedAvailableExports)
			{
				var menuItem = new ToolStripMenuItem(export.Value.LocalizedName, ToolStripButtonImage, OnExportItemClicked);
				
				dropDownItems.Add(export.Key, menuItem);
				DropDownItems.Add(menuItem);
			}

			dropDownItemsCreated = true;
		}

		private void OnDropDownOpening(object sender, EventArgs e)
		{
			if (!dropDownItemsCreated)
			{
				CreateDropDownItems();
			}

			
		}

		private void ToggleDropDownItemVisibility(SectionDocument doc)
		{
		}

		private void OnExportItemClicked(object sender, EventArgs e)
		{
			var item = sender as ToolStripItem;
		}

		protected override void OnDropDownOpened(EventArgs e)
		{
			base.OnDropDownOpened(e);
		}
	}
}
