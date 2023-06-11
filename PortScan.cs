using DnsClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SSPT_SC
{
    internal class PortScan
    {

        public static async void Portscan()
        {
            Console.WriteLine("PortScanner v1.1");
            Console.WriteLine("------------------");
            Console.WriteLine();


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Eingabe Host oder IP: >");
                Console.ResetColor();
                string hostVariable = Console.ReadLine() ?? "";

                if (hostVariable.Trim().ToLower() == "quit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    string testhost = hostVariable.Split(".")[1];
                }
                catch
                {
                    Console.WriteLine("Bitte geben Sie eine gültige Seite ein!");
                    continue;
                }



                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Eingabe der Ports (entweder mit Komma getrennt, oder einen Bereich xxx-xxx) >");
                Console.ResetColor();

                string portVariable = Console.ReadLine();
                Console.WriteLine();

                if (portVariable.Contains("-"))
                {
                    for (int i = Convert.ToInt32(portVariable.Split("-")[0]); i <= Convert.ToInt32(portVariable.Split("-")[1]); i++)
                    {
                        bool isPortOpen = new TcpClient().ConnectAsync(hostVariable, i).Wait(500);

                        if (!isPortOpen)
                        {
                            Console.Write(hostVariable + ":" + i);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" False");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(hostVariable + ":" + i);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine(" True");
                            Console.ResetColor();
                        }
                    }
                }
                else if (portVariable.Contains(","))
                {
                    string[] ports = portVariable.Split(",");

                    foreach (string port in ports)
                    {
                        bool isPortOpen = new TcpClient().ConnectAsync(hostVariable, Convert.ToInt32(port)).Wait(500);

                        if (!isPortOpen)
                        {
                            Console.Write(hostVariable + ":" + Convert.ToInt32(port));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" False");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(hostVariable + ":" + Convert.ToInt32(port));
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine(" True");
                            Console.ResetColor();
                        }
                    }
                }
                Console.WriteLine("Fertig!");
                Console.WriteLine();
            }
        }
    }
}
