using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;


namespace X_Plane_RT_map
{
	public partial class Form1 : Form
	{
		public Thread		m_ListenThread;
		public bool			m_IsRunning;
		public UdpClient	m_ReceivingUdpClient = null;
		public string		m_Lat  = "43.1802304";
		public string		m_Lon  = "5.59345229";
		public int			m_Port = 49003;
		public bool			m_StayOnTop    = false;
		public bool			m_ShowTitleBar = true;

		public void ThreadReceiver()
		{
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, m_Port);
			m_ReceivingUdpClient = new UdpClient(endPoint);

			while (m_IsRunning)
			{
				try
				{
					Byte[] data = m_ReceivingUdpClient.Receive(ref endPoint);
					if (data.Length == 41)
					{
						int index = data[5] + data[6] * 256 + data[7] * 65536 + data[8] * 16777216;
						if (index == 20)
						{
							float lat = BitConverter.ToSingle(data, 9);
							float lon = BitConverter.ToSingle(data, 13);
							m_Lat = lat.ToString(System.Globalization.CultureInfo.InvariantCulture);
							m_Lon = lon.ToString(System.Globalization.CultureInfo.InvariantCulture);
						}
					}
				}
				catch (SocketException ex)
				{
				}
				Thread.Sleep(100);
			}
		}

		public Form1()
		{
			InitializeComponent();
			string curDir = Directory.GetCurrentDirectory();
			this.webBrowser1.Url = new Uri(String.Format("file:///{0}/index.html", curDir));
			toolStripMenuItem5.Checked = true;
			StartMap();
		}

		private void StartMap()
		{
			m_IsRunning = true;
			m_ListenThread = new Thread(new ThreadStart(ThreadReceiver));
			m_ListenThread.Start();
		}

		private void StopMap()
		{
			m_IsRunning = false;
			m_ReceivingUdpClient.Close();
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			StopMap();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			string[] param = new string[] { m_Lat, m_Lon };
			this.webBrowser1.Document.InvokeScript("setPosition", param);
		}

		private void setupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StopMap();
			SetupForm form = new SetupForm();
			form.ShowDialog(this);
			m_Port = Int32.Parse(form.textBoxPort.Text);
			StartMap();
		}

		private void reloadMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StopMap();
			this.webBrowser1.Refresh();
			StartMap();
		}

		private void toggleTitleBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_ShowTitleBar = !m_ShowTitleBar;
			this.FormBorderStyle = m_ShowTitleBar ? FormBorderStyle.FixedDialog : FormBorderStyle.None;
		}

		private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
		{
			toolStripMenuItem2.Checked = true;
			toolStripMenuItem3.Checked = false;
			toolStripMenuItem4.Checked = false;
			toolStripMenuItem5.Checked = false;
			this.Opacity = 0.25;
		}

		private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
		{
			toolStripMenuItem2.Checked = false;
			toolStripMenuItem3.Checked = true;
			toolStripMenuItem4.Checked = false;
			toolStripMenuItem5.Checked = false;
			this.Opacity = 0.50;
		}

		private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
		{
			toolStripMenuItem2.Checked = false;
			toolStripMenuItem3.Checked = false;
			toolStripMenuItem4.Checked = true;
			toolStripMenuItem5.Checked = false;
			this.Opacity = 0.75;
		}

		private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
		{
			toolStripMenuItem2.Checked = false;
			toolStripMenuItem3.Checked = false;
			toolStripMenuItem4.Checked = false;
			toolStripMenuItem5.Checked = true;
			this.Opacity = 1.0;
		}

		private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_StayOnTop = !m_StayOnTop;
			stayOnTopToolStripMenuItem.Checked = m_StayOnTop;
			this.TopMost = m_StayOnTop;
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Code : Thomas Laquet\nLicence : public domain\nMap : © OpenStreetMap contributors", "About X-Plane RealTime Map", MessageBoxButtons.OK);
		}
	}
}
