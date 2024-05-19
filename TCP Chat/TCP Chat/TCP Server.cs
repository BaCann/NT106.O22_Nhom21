using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Chat
{
    public partial class TCP_Server : Form
    {
        public TCP_Server()
        {
            InitializeComponent();
        }
        private void Receive(Socket clientSocket)
        {
            while (clientSocket.Connected)
            {
                string text = "";
                do
                {
                    byte[] buffer = new byte[1];
                    clientSocket.Receive(buffer);
                    text += Encoding.UTF8.GetString(buffer);
                } while (text[text.Length - 1] != ';');

                if (listView1.InvokeRequired)
                {
                    listView1.Invoke((MethodInvoker)delegate
                    {
                        listView1.Items.Add(text);
                    });
                }
            }
        }
        private void StartServer()
        {
            Socket listener = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listener.Bind(iPEndPoint);
            listener.Listen(5);
            
            while (true)
            {
                Socket clientSocket = listener.Accept();
                Thread thread = new Thread(() => Receive(clientSocket));
                thread.Start();
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Thread thread = new Thread(StartServer);
            thread.Start();
        }
    }
}
