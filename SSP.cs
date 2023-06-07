using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSPT_SC
{
    internal class SSP
    {
        public static void Schere_Stein_Papier()
        {

            Console.WriteLine("Schere Stein Papier");
            Console.WriteLine("------------------");

            int counterPC = 0;
            int counterH = 0;

            while (true)
            {
                Console.WriteLine("Wählen Sie aus: >");
                Console.WriteLine(" 1 | Schere");
                Console.WriteLine(" 2 | Stein");
                Console.WriteLine(" 3 | Papier ");
                Console.WriteLine(" 0 | Beenden");
                Console.WriteLine("------------------");

                string choiceS = Console.ReadLine().Trim();

                try
                {
                    int temp = Convert.ToInt32(choiceS);
                }
                catch
                {
                    Console.WriteLine("Bite geben Sie eine Zahl zwischen 0 und 3 ein!");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine("------------------");

                switch (choiceS)
                {
                    case "1":
                        Console.WriteLine("Spieler  : Schere");
                        break;
                    case "2":
                        Console.WriteLine("Spieler  : Stein");
                        break;
                    case "3":
                        Console.WriteLine("Spieler  : Papier");
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Bitte geben Sie eine Zahl zwischen 0 und 3 ein!");
                        Console.WriteLine();
                        //throw new IndexOutOfRangeException("Der Wert muss zwischen 0 und 3 sein!");
                        continue;
                }

                Random rnd = new Random();
                List<string> list = new List<string> { "Schere", "Stein", "Papier" };

                int choicePC = rnd.Next(list.Count);

                Console.WriteLine("Computer : " + list[choicePC]);
                Console.WriteLine("------------------");
                Console.WriteLine("SPIELSTAND:");

                switch (list[choicePC])
                {
                    case "Schere":
                        if (choiceS == "1")
                        {
                            Console.WriteLine("Spieler: " + counterH + " Computer: " + counterPC);
                        }
                        else if (choiceS == "2")
                        {
                            counterH++;
                            Console.WriteLine("Spieler: " + counterH + " Computer: " + counterPC);
                        }
                        else if (choiceS == "3")
                        {
                            counterPC++;
                            Console.WriteLine("Spieler: " + counterH + " Computer: " + counterPC);
                        }
                        break;
                    case "Stein":
                        if (choiceS == "1")
                        {
                            counterPC++;
                            Console.WriteLine("Spieler: " + counterH + " Computer: " + counterPC);
                        }
                        else if (choiceS == "2")
                        {
                            Console.WriteLine("Spieler: " + counterH + " Computer: " + counterPC);
                        }
                        else if (choiceS == "3")
                        {
                            counterH++;
                            Console.WriteLine("Spieler: " + counterH + " Computer: " + counterPC);
                        }
                        break;
                    case "Papier":
                        if (choiceS == "1")
                        {
                            counterH++;
                            Console.WriteLine("Spieler: " + counterH + " Computer: " + counterPC);
                        }
                        else if (choiceS == "2")
                        {
                            counterPC++;
                            Console.WriteLine("Spieler: " + counterH + " Computer: " + counterPC);
                        }
                        else if (choiceS == "3")
                        {
                            Console.WriteLine("Spieler: " + counterH + " Computer: " + counterPC);
                        }
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}