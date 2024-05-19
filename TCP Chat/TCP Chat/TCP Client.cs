using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Net.Http;

namespace TCP_Chat
{
    public partial class TCP_Client : Form
    {
        public TCP_Client()
        {
            InitializeComponent();
        }
        private TcpClient tcpClient;
        private NetworkStream ns;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                this.tcpClient = new TcpClient();
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
                this.tcpClient.Connect(ipEndPoint);
                this.ns = this.tcpClient.GetStream();
                MessageBox.Show("Connected to server !!!");
            }
            catch (SocketException ex)
            {
             
                MessageBox.Show("Unable to connect to server: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tcpClient != null && this.tcpClient.Connected)
                {
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(txtmess.Text);
                    this.ns.Write(data, 0, data.Length);
                }
                else
                {
                    MessageBox.Show("Not connected to server. Please connect first.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending data: " + ex.Message);
            }
        }

        private void btnDisCN_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tcpClient != null && this.tcpClient.Connected)
                {
                    // Đóng kết nối
                    this.ns.Close();
                    this.tcpClient.Close();
                    MessageBox.Show("Disconnected from server.");
                }
                else
                {
                    MessageBox.Show("Not connected to server.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disconnecting: " + ex.Message);
            }

        }
    }
}
