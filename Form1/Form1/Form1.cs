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
using System.Threading;

namespace Form1
{
    public partial class Form1 : Form
    {
        
        public static int port = 32742;
        public static TcpListener listener = new TcpListener(IPAddress.Any, port);
        public static Thread conn = new Thread(awaitConnection);
        public static TcpClient client;
        public static NetworkStream dataStream;//se envia y recive informacion a traves de aqui

        static void sendMessage(string msg)
        {
            char[] data = msg.ToCharArray();
            byte[] buffer = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                buffer[i] = (byte)data[i];
            }
            
            dataStream.Write(buffer, 0, buffer.Length);
            dataStream.Flush();
        }
        static void awaitConnection()
        {
            listener.Start();
            client = listener.AcceptTcpClient();
            dataStream = client.GetStream();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.Start();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exit(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void messageBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendMessage("alert msg: hola que tal");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void buildStubToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
