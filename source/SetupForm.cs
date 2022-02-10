using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_Plane_RT_map
{
	public partial class SetupForm : Form
	{
		public SetupForm()
		{
			InitializeComponent();
			textBoxIP.Text = getLocalIp();
		}
		
		private string getLocalIp()
		{
			string localIP;
			using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
			{
				socket.Connect("8.8.8.8", 65530);	// Google DNS
				System.Net.IPEndPoint endPoint = socket.LocalEndPoint as System.Net.IPEndPoint;
				localIP = endPoint.Address.ToString();
			}
			return localIP;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
