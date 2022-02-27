namespace X_Plane_OSM_Map
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
			this.components = new System.ComponentModel.Container();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoCenteringModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toggleTitleBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reloadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.transparencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// webBrowser1
			// 
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.Location = new System.Drawing.Point(0, 24);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(858, 490);
			this.webBrowser1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.transparencyToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(858, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.stayOnTopToolStripMenuItem,
            this.autoCenteringModeToolStripMenuItem,
            this.toggleTitleBarToolStripMenuItem,
            this.reloadMapToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.saveRouteToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.testToolStripMenuItem.Text = "Setup";
			this.testToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
			// 
			// stayOnTopToolStripMenuItem
			// 
			this.stayOnTopToolStripMenuItem.Name = "stayOnTopToolStripMenuItem";
			this.stayOnTopToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.stayOnTopToolStripMenuItem.Text = "Stay on top";
			this.stayOnTopToolStripMenuItem.Click += new System.EventHandler(this.stayOnTopToolStripMenuItem_Click);
			// 
			// autoCenteringModeToolStripMenuItem
			// 
			this.autoCenteringModeToolStripMenuItem.Name = "autoCenteringModeToolStripMenuItem";
			this.autoCenteringModeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.autoCenteringModeToolStripMenuItem.Text = "Auto centering mode";
			this.autoCenteringModeToolStripMenuItem.Click += new System.EventHandler(this.autoCenteringModeToolStripMenuItem_Click);
			// 
			// toggleTitleBarToolStripMenuItem
			// 
			this.toggleTitleBarToolStripMenuItem.Name = "toggleTitleBarToolStripMenuItem";
			this.toggleTitleBarToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.toggleTitleBarToolStripMenuItem.Text = "Toggle Title bar";
			this.toggleTitleBarToolStripMenuItem.Click += new System.EventHandler(this.toggleTitleBarToolStripMenuItem_Click);
			// 
			// reloadMapToolStripMenuItem
			// 
			this.reloadMapToolStripMenuItem.Name = "reloadMapToolStripMenuItem";
			this.reloadMapToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.reloadMapToolStripMenuItem.Text = "Reload map";
			this.reloadMapToolStripMenuItem.Click += new System.EventHandler(this.reloadMapToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.aboutToolStripMenuItem.Text = "About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// saveRouteToolStripMenuItem
			// 
			this.saveRouteToolStripMenuItem.Name = "saveRouteToolStripMenuItem";
			this.saveRouteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.saveRouteToolStripMenuItem.Text = "Save route...";
			this.saveRouteToolStripMenuItem.Click += new System.EventHandler(this.saveRouteToolStripMenuItem_Click);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// transparencyToolStripMenuItem
			// 
			this.transparencyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
			this.transparencyToolStripMenuItem.Name = "transparencyToolStripMenuItem";
			this.transparencyToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
			this.transparencyToolStripMenuItem.Text = "Transparency";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.CheckOnClick = true;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
			this.toolStripMenuItem2.Text = "25%";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click_1);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.CheckOnClick = true;
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(102, 22);
			this.toolStripMenuItem3.Text = "50%";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click_1);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.CheckOnClick = true;
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(102, 22);
			this.toolStripMenuItem4.Text = "75%";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click_1);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.CheckOnClick = true;
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(102, 22);
			this.toolStripMenuItem5.Text = "100%";
			this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click_1);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 250;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(858, 514);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "X-Plane map";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolStripMenuItem reloadMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toggleTitleBarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem transparencyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem stayOnTopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoCenteringModeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveRouteToolStripMenuItem;
	}
}

