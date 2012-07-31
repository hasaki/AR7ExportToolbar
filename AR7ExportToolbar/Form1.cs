using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AR7ExportToolbar
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void viewer1_Load(object sender, EventArgs e)
		{
			viewer1.LoadDocument(new SectionReport1());
		}
	}
}
