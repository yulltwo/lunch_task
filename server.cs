using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Diagnostics;
namespace jimin_heartbeat
{
    public class Server
    {
        public Socket mServer = null;
        public Socket mClient = null;
        public Thread threadListen = null;
        public Thread threadServ = null;
        byte[] byte_data = new byte[1024];
        String string_data = null;



        static Boolean listening_flag = true;
        public event IntStringEventHandler Chatting;
        /*
        public Server(int port_num) //server
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            string strIP = "192.168.0.57";



            foreach (IPAddress item in host.AddressList)
            {
                string[] tempHosts = item.ToString().Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (tempHosts == null || tempHosts.Length != 4) continue;
                int tempValue = 0;
                if (int.TryParse(tempHosts[0], out tempValue))
                {
                    strIP = item.ToString();
                    break;
                }
            }
            IPAddress hostIP = IPAddress.Parse(strIP);
            IPEndPoint ep = new IPEndPoint(hostIP, port_num);

            mServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            mServer.Bind(ep);
            mServer.Blocking = true;

            threadServ = new Thread(new ThreadStart(ServerProc));
            threadServ.Start();

        }
        */
        public Server(String IP_addr, int Port_num)  //client
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP_addr), Port_num);

            mServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                mServer.Connect(ep);
            }
            catch (SocketException e)
            {
                Debug.WriteLine("{0}, {1}", "SocketComm_Clnt :", e);
                return;
            }
            mClient = mServer;

            threadListen = new Thread(new ThreadStart(ListenProc));
            threadListen.Start();
        }

        public void ServerProc()
        {
            while (true)
            {
                mServer.Listen(5);

                try
                {
                    mClient = mServer.Accept();
                }
                catch (SocketException)
                {
                    return;
                }

                threadListen = new Thread(new ThreadStart(ListenProc));
                threadListen.Start();
            }
        }
        public void SendData(byte[] buff)
        {
            if (mClient != null && mClient.Connected == true)
            {
                Chatting(Form1.Iam, Encoding.UTF8.GetString(buff));
                mClient.Send(buff);
            }
            return;
        }
        public void ListenProc()
        {
            while (listening_flag)
            {
                int recv;
                try
                {
                    recv = mClient.Receive(byte_data);
                }
                catch (Exception)
                {
                    return;
                }
                if (recv > 1)
                {
                    //string_data = Encoding.ASCII.GetString(byte_data, 0, recv);
                    string_data = Encoding.UTF8.GetString(byte_data, 0, recv);
                    Chatting(Form1.You, string_data);
                }
            }
            return;
        }
    }
}
