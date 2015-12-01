Enter file contents hereusing System;
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
namespace bingo
{
    public partial class Form1 : Form
    {
        public delegate void IntStringEventHandler(UserType type, String buff);       // 델리게이트 선언
        public static UserType Iam, You;
        Server mSocketComm = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                   // S_RX.AppendText("Server : " + buff);

                }
                else if (type == UserType.Client)
                {
                    //tb_chat.AppendText("Client : ");
                }
            }

        }

        private void server_connect_btn_Click_1(object sender, EventArgs e)
        {
            Iam = UserType.Server;
            You = UserType.Client;

            if (Iam == UserType.Server)
            {
                String IP_adress = "127.0.0.1";
                int port_num = 8888;
                try
                {
                    IP_adress = server_ip_tb.Text;
                    port_num = int.Parse(server_port_tb.Text);
                }
                catch { }
                server_port_tb.Text = "" + port_num;

                mSocketComm = new Server(IP_adress, port_num);
                server_connect_btn.Enabled = false;
                mSocketComm.Chatting += new intStringEventHandler(Proxy_Chatting);
            }
        }

        private void start_bingo_Click(object sender, EventArgs e)
        {
             int maxnumbers = 90;  

             bool iscalling = true;  

             int curnum = 1;  

             int nownum = 1;  

    

             List<Int32> Numbers = new List<Int32>();  

    

             while (curnum <= maxnumbers)  

             {  

                 this.Text = curnum.ToString();  

                 Numbers.Add(curnum);  

                 curnum += 1;  

             }  

    

             this.Text = "Numbers added";  

    

             while (iscalling == true)  

             {  

                 if (nownum == maxnumbers)  

                 {  

                     iscalling = false;  

                 }  

                 else 

                 {  

                     this.Text = "Is Calling";  

                     Random rand = new Random();  

                     int randomnum = rand.Next(50);  

    

                     if (Numbers.Contains(randomnum))  
                     {  

                         System.Windows.Forms.Label[] Labels = new System.Windows.Forms.Label[90];  

                         Labels[randomnum].Text = Convert.ToString(randomnum);  

                         //label1.Text = randomnum.ToString();  

                         Numbers.Remove(randomnum);  

                         nownum += 1;  

                     }  

                 }  

             }  

    
          

        }


    }
    public enum UserType
    {
        None = 0x00,

        Server = 0xAA,
        Client = 0x55
    }
}
