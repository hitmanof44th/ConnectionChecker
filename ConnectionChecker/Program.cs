using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionChecker
{
    class Program
    {
        static void Main(string[] args)
        {

        IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
        TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation xcon in connections) 
            {

                if (xcon.RemoteEndPoint.Address.ToString() != "127.0.0.1") 
                {
                   
                    if (xcon.State.ToString() == "Established")
                    {
                      Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                            Console.ForegroundColor = ConsoleColor.Red;
                    }

                       Console.WriteLine(xcon.RemoteEndPoint.Address + ":" + xcon.RemoteEndPoint.Port + " \t\t\t" + xcon.State);
                }

            }


            Console.WriteLine("Done Running Press Any Key To Exit");
            Console.ReadLine();
        }
    }
}
