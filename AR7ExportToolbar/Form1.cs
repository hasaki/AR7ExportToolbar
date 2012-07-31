using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AR7ExportToolbar.ToolStripExport;

namespace AR7ExportToolbar
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			ExportToolStripButton button = new ExportToolStripButton(viewer1);
			viewer1.Toolbar.MainBar.Items.Insert(3, button);
		}

		private void viewer1_Load(object sender, EventArgs e)
		{
			viewer1.LoadDocument("PageReport1.rdlx");
		}
	}
}
