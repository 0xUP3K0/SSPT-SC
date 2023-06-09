﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SSPT_SC
{
    internal class WikiCheck
    {
        public static void WikipediaCheck()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Geben Sie einen zu suchenden Namen ein. ACHTUNG: Bitte Großbuchstaben! >");
                    string name = Console.ReadLine();

                    if (name.Trim() == "")
                    {
                        Environment.Exit(0);
                    }

                    string content = "";

                    if (name.Contains(" "))
                    {
                        content = new WebClient().DownloadString("https://de.wikipedia.org/wiki/" + name.Split(" ")[0] + "_" + name.Split(" ")[1]);
                    }
                    else
                    {
                        content = new WebClient().DownloadString("https://de.wikipedia.org/wiki/" + name);
                    }

                    foreach (string line in content.Split("\n"))
                    {
                        if (line.Contains("footer-info-lastmod"))
                        {
                            Console.WriteLine(line.Split(">")[1].Split("<")[0].Trim());
                            Console.WriteLine();
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Bitte einen echten Namen mit großen Anfangsbuchstaben eingeben!");
                    Console.WriteLine();
                    continue;
                }
            }
        }
    }
}
