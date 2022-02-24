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


namespace X_Plane_OSM_Map
{
	public partial class Form1 : Form
	{
		public Thread		m_ListenThread;
		public Mutex		m_Mutex = new Mutex();
		public bool			m_IsRunning;
		public UdpClient	m_ReceivingUdpClient = null;
		public string		m_Lat  = "43.1802304";
		public string		m_Lon     =  "5.5934522";
		public string		m_LastLat = "43.1802304";
		public string		m_LastLon =  "5.5934522";
		public int			m_Port = 49003;
		public bool			m_StayOnTop    = false;
		public bool			m_ShowTitleBar = true;
		public bool			m_AutoCentering = true;
		public string		m_GpxContent    = "";

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
					else if (data.Length > 6 && data[0]=='$' && data[data.Length-3] == '*')
					{
						string sentence = System.Text.Encoding.Default.GetString(data);
						string[] tokens = sentence.Substring(3, sentence.IndexOf("*")).Split(',');
						if (tokens.Length > 5)
						{
							// NMEA ?
							if (tokens[0] == "GLL" && tokens.Length > 5)
							{
								double sLat   = Double.Parse(tokens[1], System.Globalization.CultureInfo.InvariantCulture);
								double sLon   = Double.Parse(tokens[3], System.Globalization.CultureInfo.InvariantCulture);
								double degLat = (double)((int)(sLat / 100));
								double degLon = (double)((int)(sLon / 100));
								double minLat = (sLat - degLat*100)/60.0;
								double minLon = (sLon - degLon*100)/60.0;
								degLat += minLat;
								degLon += minLon;
								if (tokens[2][0] == 'S' || tokens[2][0] == 's') degLat *= -1.0;
								if (tokens[4][0] == 'W' || tokens[4][0] == 'w') degLon *= -1.0;
								m_Lat = degLat.ToString(System.Globalization.CultureInfo.InvariantCulture);
								m_Lon = degLon.ToString(System.Globalization.CultureInfo.InvariantCulture);
							}
							else if (tokens[0] == "RMC" && tokens.Length > 7)
							{
								double sLat = Double.Parse(tokens[3], System.Globalization.CultureInfo.InvariantCulture);
								double sLon = Double.Parse(tokens[5], System.Globalization.CultureInfo.InvariantCulture);
								double degLat = (double)((int)(sLat / 100));
								double degLon = (double)((int)(sLon / 100));
								double minLat = (sLat - degLat * 100) / 60.0;
								double minLon = (sLon - degLon * 100) / 60.0;
								degLat += minLat;
								degLon += minLon;
								if (tokens[4][0] == 'S' || tokens[4][0] == 's') degLat *= -1.0;
								if (tokens[6][0] == 'W' || tokens[6][0] == 'w') degLon *= -1.0;
								m_Lat = degLat.ToString(System.Globalization.CultureInfo.InvariantCulture);
								m_Lon = degLon.ToString(System.Globalization.CultureInfo.InvariantCulture);
							}
							else if (tokens[0] == "GGA" && tokens.Length > 6)
							{
								double sLat = Double.Parse(tokens[2], System.Globalization.CultureInfo.InvariantCulture);
								double sLon = Double.Parse(tokens[4], System.Globalization.CultureInfo.InvariantCulture);
								double degLat = (double)((int)(sLat / 100));
								double degLon = (double)((int)(sLon / 100));
								double minLat = (sLat - degLat * 100) / 60.0;
								double minLon = (sLon - degLon * 100) / 60.0;
								degLat += minLat;
								degLon += minLon;
								if (tokens[3][0] == 'S' || tokens[3][0] == 's') degLat *= -1.0;
								if (tokens[5][0] == 'W' || tokens[5][0] == 'w') degLon *= -1.0;
								m_Lat = degLat.ToString(System.Globalization.CultureInfo.InvariantCulture);
								m_Lon = degLon.ToString(System.Globalization.CultureInfo.InvariantCulture);
							}
						}
					}
				}
				catch (SocketException ex)
				{
					//ex.Message
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
			autoCenteringModeToolStripMenuItem.Checked = m_AutoCentering;
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
			if (m_Lat != m_LastLat || m_Lon != m_LastLon)
			{
			string[] param = new string[] { m_Lat, m_Lon };
			this.webBrowser1.Document.InvokeScript("setPosition", param);
				m_Mutex.WaitOne();
				m_GpxContent += "<trkpt lat=\""+ m_Lat + "\" lon=\"" + m_Lon + "\"></trkpt>\n";
				m_Mutex.ReleaseMutex();
				m_LastLat = m_Lat;
				m_LastLon = m_Lon;
			}
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
			m_Mutex.WaitOne();
			m_GpxContent = "";
			m_Mutex.ReleaseMutex();
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

		private void autoCenteringModeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_AutoCentering = !m_AutoCentering;
			autoCenteringModeToolStripMenuItem.Checked = m_AutoCentering;

			string[] param = new string[] { m_AutoCentering ? "true" : "false" };
			this.webBrowser1.Document.InvokeScript("setAutoCentering", param);
		}

		private void saveRouteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();

			saveFileDialog1.Filter			= "gpx files (*.gpx)|*.txt|All files (*.*)|*.*";
			saveFileDialog1.FilterIndex		= 1;
			saveFileDialog1.FileName		= "route.gpx";
			saveFileDialog1.RestoreDirectory= true;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				writeGPX(saveFileDialog1.FileName);
			}
		}

		private void writeGPX(string filename)
		{
			string header,content,footer;
			header = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
			header += "<gpx version=\"1.1\" creator=\"X-Plane-OSM-Map\" xmlns=\"http://www.topografix.com/GPX/1/1\"\n";
			header += "		xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"\n";
			header += "		xsi:schemaLocation=\"http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd\">\n";
			header += "<trk>\n";
			header += "<trkseg>\n";

			m_Mutex.WaitOne();
			content = m_GpxContent;
			m_Mutex.ReleaseMutex();

			footer  = "</trkseg>\n";
			footer += "</trk>\n";

			StreamWriter outputFile = new StreamWriter(filename);
			outputFile.Write(header);
			outputFile.Write(content);
			outputFile.Write(footer);
			outputFile.Flush();
			outputFile.Close();
		}
	}
}
