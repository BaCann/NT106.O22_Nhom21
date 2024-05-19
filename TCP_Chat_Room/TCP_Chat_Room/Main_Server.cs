using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace TCP_Chat_Room
{
    internal class Main_Server
    {
        public List<string> GetConnectedClients()
        {
            List<string> connectedClients = new List<string>();
            foreach (TcpClient client in limitedUser.Values)
            {
                connectedClients.Add(limitedConnection[client].ToString());
            }
            return connectedClients;
        }
        public static Hashtable limitedUser = new Hashtable(20);
        public static Hashtable limitedConnection = new Hashtable(20);
        private IPAddress iPAddress;
        private TcpClient tcpClient;
        public static event StatusChangedEventHandler StatusChanged;
        private static StatusChangedEventArgs e;
        public Main_Server(IPAddress iPAddress)
        {
            this.iPAddress = iPAddress;
        }
        private Thread Listener;
        private TcpListener ConnectedClient;
        bool ServerIsRunning = false;

        public static void OnStatusChanged(StatusChangedEventArgs e)
        {
            StatusChangedEventHandler status = StatusChanged;
            if (status != null)
            {
                // Invoke delegate
                status(null, e);
            }
        }
        // Send my message
        public static void SendMyMessage(string Msg)
        {
            StreamWriter swSender;
            e = new StatusChangedEventArgs(Msg);
            OnStatusChanged(e);
            TcpClient[] Clients = new TcpClient[Main_Server.limitedUser.Count];
            Main_Server.limitedUser.Values.CopyTo(Clients, 0);
            for (int i = 0; i < Clients.Length; i++)
            {
                try
                {
                    if (Msg.Trim() == "" || Clients[i] == null) continue;
                    swSender = new StreamWriter(Clients[i].GetStream());
                    swSender.Write(Msg);
                    swSender.Flush();
                    swSender = null;
                }
                catch
                {
                    RemoveUser(Clients[i]);
                }
            }
        }
        public static void SendMessage(string sender, string recipient, string message)
        {
            if (limitedUser.ContainsKey(recipient))
            {
                TcpClient recipientClient = (TcpClient)limitedUser[recipient];
                StreamWriter swSender = new StreamWriter(recipientClient.GetStream());
                swSender.WriteLine(sender + ": " + message);
                swSender.Flush();
            }
        }
        public static void AddUser(TcpClient tcpUser, string username)
        {
            Main_Server.limitedUser.Add(username, tcpUser);
            Main_Server.limitedConnection.Add(tcpUser, username);
            SendMyMessage(limitedConnection[tcpUser] + " đã tham gia.\n");
        }
        private static Dictionary<TcpClient, bool> connectionStates = new Dictionary<TcpClient, bool>();

        public static void SetConnectionState(TcpClient tcpClient, bool isConnected)
        {
            if (connectionStates.ContainsKey(tcpClient))
            {
                connectionStates[tcpClient] = isConnected;
            }
            else
            {
                connectionStates.Add(tcpClient, isConnected);
            }
        }
        public static void RemoveUser(TcpClient tcp)
        {
            try
            {
                if (limitedConnection.ContainsKey(tcp))
                {
                    string userName = limitedConnection[tcp].ToString();
                    Main_Server.limitedUser.Remove(userName);
                    Main_Server.limitedConnection.Remove(tcp);
                    SetConnectionState(tcp, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void SendMessage(string From, string Message)
        {
            StreamWriter swSenderSender;
            e = new StatusChangedEventArgs(From + " sent: " + Message);
            OnStatusChanged(e);
            TcpClient[] tcpClients = new TcpClient[Main_Server.limitedUser.Count];
            Main_Server.limitedUser.Values.CopyTo(tcpClients, 0);
            for (int i = 0; i < tcpClients.Length; i++)
            {
                try
                {
                    if (Message.Trim() == "" || tcpClients[i] == null)
                    {
                        continue;
                    }
                    swSenderSender = new StreamWriter(tcpClients[i].GetStream());
                    swSenderSender.WriteLine(From + " sent: " + Message);
                    swSenderSender.Flush();
                    swSenderSender = null;
                }
                catch
                {
                    RemoveUser(tcpClients[i]);
                }
            }
        }
        public static void SendPrivateMessage(string sender, string recipient, string message)
        {
            if (limitedUser.ContainsKey(recipient))
            {
                TcpClient recipientClient = (TcpClient)limitedUser[recipient];
                StreamWriter swSender = new StreamWriter(recipientClient.GetStream());
                swSender.WriteLine($"{sender} sent privately to you : {message}");
                swSender.Flush();
            }
        }
        public void StartListening()
        {
            try
            {
                IPAddress ipaLocal = iPAddress;
                ConnectedClient = new TcpListener(ipaLocal, 8080);
                ConnectedClient.Start();
                ServerIsRunning = true;
                Listener = new Thread(KeepListening);
                Listener.Start();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void KeepListening()
        {
            while (ServerIsRunning == true)
            {
                tcpClient = ConnectedClient.AcceptTcpClient();
                Connection newConnection = new Connection(tcpClient);
            }
        }
    }
    public class StatusChangedEventArgs : EventArgs
    {
        private string EventMsg;
        public string EventMSG
        {
            get { return EventMsg; }
            set { EventMsg = value; }
        }
        public StatusChangedEventArgs(string EventMsg)
        {
            this.EventMsg = EventMsg;
        }
    }
    public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);
    class Connection
    {
        TcpClient tcpClient;
        private Thread thrSender;
        private StreamReader srReceiver;
        public StreamWriter swSender;
        private string currUser;
        private string strResponse;
        public Connection(TcpClient tcpCon)
        {
            tcpClient = tcpCon;
            thrSender = new Thread(AcceptClient);
            thrSender.Start();
        }

        private void CloseConnection()
        {
            try
            {
                if (tcpClient != null && tcpClient.Connected)
                {
                    tcpClient.Close();
                }
                if (srReceiver != null)
                {
                    srReceiver.Close();
                }
                if (swSender != null)
                {
                    swSender.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while closing connection: " + ex.Message);
            }
        }
        private void AcceptClient()
        {
            try
            {
                using (srReceiver = new StreamReader(tcpClient.GetStream()))
                using (swSender = new StreamWriter(tcpClient.GetStream()))
                {
                    currUser = srReceiver.ReadLine();
                    if (string.IsNullOrEmpty(currUser))
                    {
                        swSender.WriteLine("0|This username is empty.");
                        swSender.Flush();
                        return; // Return instead of calling CloseConnection() here
                    }
                    else if (Main_Server.limitedUser.Contains(currUser))
                    {
                        swSender.WriteLine("0|This username already exists.");
                        swSender.Flush();
                        return; // Return instead of calling CloseConnection() here
                    }
                    else
                    {
                        swSender.WriteLine("1");
                        swSender.Flush();
                        Main_Server.AddUser(tcpClient, currUser);
                    }
                    while ((strResponse = srReceiver.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(strResponse))
                        {
                            Main_Server.RemoveUser(tcpClient);
                            Main_Server.SetConnectionState(tcpClient, false); // Đặt trạng thái kết nối thành false
                            break;
                        }
                        else
                        {
                            // Use strResponse here if necessary
                            Main_Server.SendMessage(currUser, strResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in AcceptClient: " + ex.Message);
                Main_Server.RemoveUser(tcpClient);
                Main_Server.SetConnectionState(tcpClient, false); // Đặt trạng thái kết nối thành false nếu có lỗi xảy ra
                CloseConnection();
            }
        }

    }
}
