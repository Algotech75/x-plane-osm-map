namespace X_Plane_OSM_Map
{
	partial class SetupForm
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
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxIP = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(115, 219);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(97, 34);
			this.button1.TabIndex = 0;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(155, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "X-Plane output port :";
			// 
			// textBoxPort
			// 
			this.textBoxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPort.Location = new System.Drawing.Point(173, 46);
			this.textBoxPort.MaxLength = 20;
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.Size = new System.Drawing.Size(143, 26);
			this.textBoxPort.TabIndex = 2;
			this.textBoxPort.Text = "49003";
			this.textBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(55, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(194, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Set the same IP/port in X-Plane.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(55, 116);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(222, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Do not use the range [49000-49002] !";
			// 
			// textBoxIP
			// 
			this.textBoxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxIP.Location = new System.Drawing.Point(172, 12);
			this.textBoxIP.MaxLength = 20;
			this.textBoxIP.Name = "textBoxIP";
			this.textBoxIP.ReadOnly = true;
			this.textBoxIP.Size = new System.Drawing.Size(144, 26);
			this.textBoxIP.TabIndex = 6;
			this.textBoxIP.Text = "127.0.0.1";
			this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(129, 20);
			this.label4.TabIndex = 5;
			this.label4.Text = "This machine IP :";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label5.Location = new System.Drawing.Point(16, 161);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(300, 41);
			this.label5.TabIndex = 7;
			this.label5.Text = "On the same port, you have a basic support for NMEA sentences (RMC, GGA, GLL).";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SetupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(328, 273);
			this.ControlBox = false;
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxIP);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxPort);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SetupForm";
			this.Text = "Setup";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxIP;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.Label label5;
	}
}