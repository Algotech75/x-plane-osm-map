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
		public Mutex		m_Mutex			= new Mutex();
		public bool			m_IsRunning		= false;
		public UdpClient	m_RecvUdpClient	= null;
		public string		m_Lat			= "43.1802304";
		public string		m_Lon			=  "5.5934522";
		public string		m_Hdg			= "-1.0";
		public string		m_LastLat		= "43.1802304";
		public string		m_LastLon		=  "5.5934522";
		public string		m_LastHdg		= "-1.0";
		public int			m_Port			= 49003;
		public bool			m_StayOnTop		= false;
		public bool			m_ShowTitleBar	= true;
		public bool			m_AutoCentering	= true;
		public string		m_GpxContent	= "";

		public void ThreadReceiver()
		{
			char[] separators = new char[] { '\r', '\n' };
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, m_Port);
			try
			{
				m_RecvUdpClient = new UdpClient(endPoint);
			}
			catch (SocketException ex)
			{
				m_IsRunning = false;
				MessageBox.Show("Connection error. Maybe the port is already used ? Use the menu 'Reload map' to try again.\nError : "+ ex.Message, "Error", MessageBoxButtons.OK);
				return;
			}


			while (m_IsRunning)
			{
				try
				{
					Byte[] data = m_RecvUdpClient.Receive(ref endPoint);
					if (data.Length >= 9)
					{
						if ((char)data[0] == 'D' && 
							(char)data[1] == 'A' && 
							(char)data[2] == 'T' && 
							(char)data[3] == 'A')
						{
							// Skip "DATA" header
							Byte[] array = new Byte[data.Length - 5];
							Buffer.BlockCopy(data, 5, array, 0, data.Length - 5);
							data = array;

							while (data.Length > 0)
							{
								int index = data[0] + data[1] * 256 + data[2] * 65536 + data[3] * 16777216;
								switch (index)
								{
									case 20:
									{
										float lat = BitConverter.ToSingle(data, 4);
										float lon = BitConverter.ToSingle(data, 8);
										float deg = BitConverter.ToSingle(data, 12);
										float abc = BitConverter.ToSingle(data, 16);
										float def = BitConverter.ToSingle(data, 20);
										m_Lat = lat.ToString(System.Globalization.CultureInfo.InvariantCulture);
										m_Lon = lon.ToString(System.Globalization.CultureInfo.InvariantCulture);
										break;
									}
									case 17:
									{

//										float pitch = BitConverter.ToSingle(data, 4);
//										float roll  = BitConverter.ToSingle(data, 8);
										float head  = BitConverter.ToSingle(data, 12);
//										float north = BitConverter.ToSingle(data, 16);
										m_Hdg = head.ToString(System.Globalization.CultureInfo.InvariantCulture);
										break;
									}
								}
								int toSkip = 36;
								Byte[] array2 = new Byte[data.Length - toSkip];
								Buffer.BlockCopy(data, toSkip, array2, 0, data.Length - toSkip);
								data = array2;
							}
							continue;
						}
					}
					else if (data.Length > 6 && data[0] == '$')
					{
						string[] sentences   = System.Text.Encoding.Default.GetString(data).Split(separators, StringSplitOptions.RemoveEmptyEntries);
						string   nmeaLatVal  = "0.0";
						string   nmeaLonVal  = "0.0";
						string   nmeaLatOri  = "N";
						string   nmeaLonOri  = "E";
						string   nmeaHdgVal  = "0.0";
						bool     bHasCoord   = false;
						bool     bHasHeading = false;

						for (int i=0; i<sentences.Length; i++)
						{
							string trameType = sentences[i].Substring(3, 3);

							if (bHasHeading == false)
							{
								if (trameType == "HDT")
								{
									string[] tokens = sentences[i].Substring(0, sentences[i].Length-3).Split(',');
									nmeaHdgVal = tokens[1];
									bHasHeading = true;
									continue;
								}
							}

							if (bHasCoord == false)
							{
								if (trameType == "GLL")
								{
									string[] tokens = sentences[i].Split(',');
									nmeaLatVal = tokens[1];
									nmeaLonVal = tokens[3];
									nmeaLatOri = tokens[2];
									nmeaLonOri = tokens[4];
									bHasCoord  = true;
									continue;
								}
								else if (trameType == "RMC")
								{
									string[] tokens = sentences[i].Split(',');
									nmeaLatVal = tokens[3];
									nmeaLonVal = tokens[5];
									nmeaLatOri = tokens[4];
									nmeaLonOri = tokens[6];
									bHasCoord = true;
									continue;
								}
								else if (trameType == "GGA")
								{
									string[] tokens = sentences[i].Split(',');
									nmeaLatVal = tokens[2];
									nmeaLonVal = tokens[4];
									nmeaLatOri = tokens[3];
									nmeaLonOri = tokens[5];
									bHasCoord = true;
									continue;
								}
							}
						}
						if (bHasHeading)
						{
							double trueHeading = Double.Parse(nmeaHdgVal, System.Globalization.CultureInfo.InvariantCulture);
							m_Hdg = trueHeading.ToString(System.Globalization.CultureInfo.InvariantCulture);
						}
						if (bHasCoord)
						{
							double sLat = Double.Parse(nmeaLatVal, System.Globalization.CultureInfo.InvariantCulture);
							double sLon = Double.Parse(nmeaLonVal, System.Globalization.CultureInfo.InvariantCulture);
							double degLat = (double)((int)(sLat / 100));
							double degLon = (double)((int)(sLon / 100));
							double minLat = (sLat - degLat * 100) / 60.0;
							double minLon = (sLon - degLon * 100) / 60.0;
							degLat += minLat;
							degLon += minLon;
							if (nmeaLatOri[0] == 'S' || nmeaLatOri[0] == 's') degLat *= -1.0;
							if (nmeaLonOri[0] == 'W' || nmeaLonOri[0] == 'w') degLon *= -1.0;
							m_Lat = degLat.ToString(System.Globalization.CultureInfo.InvariantCulture);
							m_Lon = degLon.ToString(System.Globalization.CultureInfo.InvariantCulture);
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
			if (m_RecvUdpClient != null)
			{
				m_RecvUdpClient.Close();
			}
			m_ListenThread.Join();
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			timer1.Stop();
			StopMap();
			Application.Exit();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (m_Lat != m_LastLat || m_Lon != m_LastLon || m_Hdg != m_LastHdg)
			{
				string[] param = new string[] { m_Lat, m_Lon, m_Hdg };
				this.webBrowser1.Document.InvokeScript("setPosition", param);
			}
			if (m_Lat != m_LastLat || m_Lon != m_LastLon)
			{
				m_Mutex.WaitOne();
				m_GpxContent += "<trkpt lat=\""+ m_Lat + "\" lon=\"" + m_Lon + "\"></trkpt>\n";
				m_Mutex.ReleaseMutex();
			}
			m_LastLat = m_Lat;
			m_LastLon = m_Lon;
			m_LastHdg = m_Hdg;
		}

		private void setupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StopMap();
			SetupForm form = new SetupForm();
			form.textBoxPort.Text = m_Port.ToString();
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
			toolStripMenuItem6.Checked = false;
			toolStripMenuItem5.Checked = false;
			this.Opacity = 0.25;
		}

		private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
		{
			toolStripMenuItem2.Checked = false;
			toolStripMenuItem3.Checked = true;
			toolStripMenuItem4.Checked = false;
			toolStripMenuItem6.Checked = false;
			toolStripMenuItem5.Checked = false;
			this.Opacity = 0.50;
		}

		private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
		{
			toolStripMenuItem2.Checked = false;
			toolStripMenuItem3.Checked = false;
			toolStripMenuItem4.Checked = true;
			toolStripMenuItem6.Checked = false;
			toolStripMenuItem5.Checked = false;
			this.Opacity = 0.75;
		}

		private void toolStripMenuItem6_Click(object sender, EventArgs e)
		{
			toolStripMenuItem2.Checked = false;
			toolStripMenuItem3.Checked = false;
			toolStripMenuItem4.Checked = false;
			toolStripMenuItem6.Checked = true;
			toolStripMenuItem5.Checked = false;
			this.Opacity = 0.85;
		}

		private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
		{
			toolStripMenuItem2.Checked = false;
			toolStripMenuItem3.Checked = false;
			toolStripMenuItem4.Checked = false;
			toolStripMenuItem6.Checked = false;
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
