using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Diagnostics;

namespace jimin_heartbeat
{
    public delegate void IntStringEventHandler(UserType type, String buff);
    public partial class Form1 : Form
    {

        public int Heart_range_up = 65;
        public int Heart_range_down = 62;
        public static UserType Iam, You;
        Server mSocketComm = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void heart_up_Click(object sender, EventArgs e)
        {
            String msg = "up";
            mSocketComm.SendData(System.Text.Encoding.UTF8.GetBytes(msg));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mSocketComm != null)
            {
                if (mSocketComm.mServer.Connected == true)
                {
                    mSocketComm.mServer.Shutdown(SocketShutdown.Both);
                }
                mSocketComm.mServer.Close();

                if (mSocketComm.threadServ != null && mSocketComm.threadServ.IsAlive)
                    mSocketComm.threadServ.Abort();

            }
            try
            {
                ((IDisposable)this).Dispose();
            }
            catch
            {
            }
            Thread.ResetAbort();
            GC.SuppressFinalize(this);
        }



        private void server_connect_btn_Click(object sender, EventArgs e)
        {
            Iam = UserType.Server;
            You = UserType.Client;

            if (Iam == UserType.Server)
            {
                String IP_adress = "192.168.0.12";
                int port_num = 8888;
                try
                {
                    IP_adress = IP_box.Text;
                    port_num = int.Parse(PORT_BOX.Text);
                }
                catch { }
                PORT_BOX.Text = "" + port_num;

                mSocketComm = new Server(IP_adress, port_num);
                server_connect_btn.Enabled = false;
                mSocketComm.Chatting += new IntStringEventHandler(Proxy_Chatting);
            }
        }

        void Proxy_Chatting(UserType type, String buff)
        {
            this.Invoke(new IntStringEventHandler(Chatting), type, buff);
        }
        void Chatting(UserType type, String buff)
        {
            if (type == UserType.None)
            {

            }
            else
            {
                if (type == UserType.Server)
                {

                }
                else if (type == UserType.Client)
                {
                    rx_box.AppendText(buff);
                }
            }

        }

        private void heart_down_Click(object sender, EventArgs e)
        {
            String msg = "down";
            mSocketComm.SendData(System.Text.Encoding.UTF8.GetBytes(msg));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String msg = "image";
            mSocketComm.SendData(System.Text.Encoding.UTF8.GetBytes(msg));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String msg = "mail";
            mSocketComm.SendData(System.Text.Encoding.UTF8.GetBytes(msg));
        }

        private void tx_send_btn_Click(object sender, EventArgs e)
        {
            mSocketComm.SendData(System.Text.Encoding.UTF8.GetBytes(name.Text+" : "+tx_send_box.Text+". \n"));
            tx_box.AppendText("I said : "+tx_send_box.Text+" \n");
            tx_send_box.Text = "";
        }

        private void bingo_btn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process ps = new System.Diagnostics.Process();
            ps.StartInfo.FileName = "bingo.c.exe";
            ps.StartInfo.WorkingDirectory = "/obj/Debug";
            ps.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            ps.Start();
        }
    }
    public enum UserType
    {
        None = 0x00,

        Server = 0xAA,
        Client = 0x55
    }
}
