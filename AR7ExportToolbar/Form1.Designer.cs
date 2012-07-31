namespace AR7ExportToolbar
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.viewer1 = new GrapeCity.ActiveReports.Viewer.Win.Viewer();
			this.SuspendLayout();
			// 
			// viewer1
			// 
			this.viewer1.AnnotationToolbarVisible = false;
			this.viewer1.CurrentPage = 0;
			this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewer1.HyperlinkBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.viewer1.HyperlinkForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.viewer1.Location = new System.Drawing.Point(0, 0);
			this.viewer1.Name = "viewer1";
			this.viewer1.PagesBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.viewer1.PreviewPages = 0;
			this.viewer1.SearchResultsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.viewer1.SearchResultsForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(139)))));
			// 
			// 
			// 
			// 
			// 
			// 
			this.viewer1.Sidebar.ParametersPanel.ContextMenu = null;
			this.viewer1.Sidebar.ParametersPanel.Width = 180;
			// 
			// 
			// 
			this.viewer1.Sidebar.SearchPanel.ContextMenu = null;
			this.viewer1.Sidebar.SearchPanel.Width = 180;
			this.viewer1.Sidebar.SelectedIndex = 0;
			// 
			// 
			// 
			this.viewer1.Sidebar.ThumbnailsPanel.ContextMenu = null;
			this.viewer1.Sidebar.ThumbnailsPanel.Width = 180;
			// 
			// 
			// 
			this.viewer1.Sidebar.TocPanel.ContextMenu = null;
			this.viewer1.Sidebar.TocPanel.Width = 180;
			this.viewer1.Sidebar.Width = 180;
			this.viewer1.Size = new System.Drawing.Size(644, 398);
			this.viewer1.SplitView = false;
			this.viewer1.TabIndex = 0;
			this.viewer1.ViewType = GrapeCity.Viewer.Common.Model.ViewType.SinglePage;
			this.viewer1.Zoom = 1F;
			this.viewer1.Load += new System.EventHandler(this.viewer1_Load);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 398);
			this.Controls.Add(this.viewer1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private GrapeCity.ActiveReports.Viewer.Win.Viewer viewer1;
	}
}

