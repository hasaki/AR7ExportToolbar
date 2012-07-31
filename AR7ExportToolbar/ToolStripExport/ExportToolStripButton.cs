using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
		private static readonly Bitmap ToolStripButtonImage = new Bitmap(typeof(ExportToolStripButton), "ReportViewer.bmp");

		private readonly Viewer host;

		public IDictionary<string, ExportItem> AvailableExports { get; private set; }
		public IDictionary<string, ExportItem> VerifiedAvailableExports { get; private set; }

		private Dictionary<string, ToolStripMenuItem> dropDownItems = null;

		private bool dropDownItemsCreated = false;

		public ExportToolStripButton(Viewer host)
			: base("Export")
		{
			this.host = host;

			Enabled = false;
			AttachHostEvents();

			AvailableExports = new Dictionary<string, ExportItem>();

			Image = ToolStripButtonImage;
			ImageTransparentColor = ToolStripButtonImage.GetPixel(0, 0);

			AddAllExports();

			this.DropDownOpening += OnDropDownOpening;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				DetachHostEvents();
			}

			base.Dispose(disposing);
		}

		private void AttachHostEvents()
		{
			host.LoadCompleted += OnHostLoadCompleted;
		}

		private void DetachHostEvents()
		{
			host.LoadCompleted -= OnHostLoadCompleted;
		}

		private void OnHostLoadCompleted(object sender, EventArgs e)
		{
			Enabled = true;
		}

		private void AddAllExports()
		{
			AddAvailableExport("PDF", "PDF", new PdfSectionReportExporter());
			AddAvailableExport("HTML", "HTML", new HtmlSectionReportExporter());
			AddAvailableExport("Excel", "Excel", new ExcelSectionReportExporter());
			AddAvailableExport("RTF", "RTF", new RtfSectionReportExporter());
			AddAvailableExport("Text", "Text", new TextSectionReportExporter());
			AddAvailableExport("TIFF", "TIFF", new TiffSectionReportExporter());
		}

		private void AddAvailableExport(string name, string localizedName, ISectionReportExporter exporter)
		{
			var item = new ExportItem();
			item.Name = name;
			item.LocalizedName = localizedName;
			item.SectionReportExport = exporter;

			AvailableExports.Add(item.Name, item);
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

			VerifiedAvailableExports = verifiedExports;
		}

		private void CreateDropDownItems()
		{
			VerifyExports();

			dropDownItems = new Dictionary<string, ToolStripMenuItem>();

			foreach (var export in VerifiedAvailableExports)
			{
				var menuItem = new ToolStripMenuItem(export.Value.LocalizedName, ToolStripButtonImage, OnExportItemClicked);
				menuItem.Tag = export.Value;
				menuItem.ImageTransparentColor = ToolStripButtonImage.GetPixel(0, 0);
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

			// TODO: Implement visibility toggle when support for PageDocument is exposed
			//ToggleDropDownItemVisibility(host.Document);
		}
		/*
		private void ToggleDropDownItemVisibility(SectionDocument doc)
		{
			foreach (var dropDownItemKV in dropDownItems)
			{
				var exportItem = VerifiedAvailableExports[dropDownItemKV.Key];

				dropDownItemKV.Value.Visible = exportItem.SectionReportExport.IsAvailable();
			}
		}
		*/
		private void OnExportItemClicked(object sender, EventArgs e)
		{
			var item = sender as ToolStripItem;

			if (item == null)
				return;

			var exportItem = item.Tag as ExportItem;

			if (exportItem == null)
				return;

			var export = exportItem.SectionReportExport;
			if(export == null)
				return;

			var exporter = exportItem.SectionReportExport.GetExporter();
			if (exporter == null)
				return;

			using (var saveAsDlg = new SaveFileDialog())
			{
				saveAsDlg.DefaultExt = export.DefaultExtension;
				saveAsDlg.Filter = export.FileDialogFilter;

				if (saveAsDlg.ShowDialog(host) != DialogResult.OK)
					return;

				host.Export(exporter, new FileInfo(saveAsDlg.FileName));
			}
		}
	}
}
