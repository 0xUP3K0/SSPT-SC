﻿using DnsClient;
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


            ConsoleColor color = ConsoleColor.Yellow;
            Console.WriteLine("Eingabe Host oder IP: >");
            string hostVariable = Console.ReadLine() ?? "";

            try
            {
                string testhost = hostVariable.Split(".")[0];
            }
            catch
            {
                Console.WriteLine("Bitte geben Sie eine gültige Seite ein!");
            }

            Console.WriteLine();
            color = ConsoleColor.Yellow;
            Console.WriteLine("Eingabe der Ports (entweder mit Komma getrennt, oder einen Bereich xxx-xxx) >", color);

            string portVariable = Console.ReadLine();
            Console.WriteLine();

            if (portVariable.Contains("-"))
            {
                for (int i = Convert.ToInt32(portVariable.Split("-")[0]); i <= Convert.ToInt32(portVariable.Split("-")[1]); i++)
                {
                    bool isPortOpen = new TcpClient().ConnectAsync(hostVariable, i).Wait(500);

                    if (isPortOpen)
                    {
                        Console.Write(hostVariable + ":" + i);
                        color = ConsoleColor.Red;
                        Console.WriteLine(" False");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(hostVariable + ":" + i);
                        color = ConsoleColor.Green;
                        Console.WriteLine(" True");
                        Console.ResetColor();
                    }
                }
            }
            else if (portVariable.Contains(","))
            {
                string[] ports = portVariable.Split(",");
                Array.Sort(ports);

                foreach (string port in ports)
                {
                    bool isPortOpen = new TcpClient().ConnectAsync(hostVariable, Convert.ToInt32(port)).Wait(500);

                    if (isPortOpen)
                    {
                        Console.Write(hostVariable + ":" + Convert.ToInt32(port));
                        color = ConsoleColor.Red;
                        Console.WriteLine(" False");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(hostVariable + ":" + Convert.ToInt32(port));
                        color = ConsoleColor.Green;
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
