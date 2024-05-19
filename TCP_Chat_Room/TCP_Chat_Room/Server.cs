using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace TCP_Chat_Room
{
    public partial class Server : Form
    {
        private delegate void UpdateStatus(string Msg);
        public Server()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(txtIP.Text);
                Main_Server main = new Main_Server(ip);
                Main_Server.StatusChanged += new StatusChangedEventHandler(main_status);
                main.StartListening();
                rtbServer.AppendText("Waiting for clients...\n");
            }
            catch { }
        }
        public void main_status(object sender, StatusChangedEventArgs e)
        {
            if (!this.IsDisposed && this.InvokeRequired)
            {
                this.Invoke(new UpdateStatus(this.Update), new object[] { e.EventMSG });
            }
            else if (!this.IsDisposed)
            {
                this.Update(e.EventMSG);
            }
        }
        private void Update(string strMessage)
        {
            rtbServer.AppendText(strMessage + "\r\n");
        }
    }
}
