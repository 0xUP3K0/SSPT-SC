using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSPT_SC
{
    internal class Uebungen
    {
        // 1. Beispiel RechnenUndString
        // Zwei Ganzahl-Variablen: x = 10 und y = 3
        // Ausgabe des Inhalts der beiden Variablen auf Konsole
        // Summe von x und y berechnen und auf Konsole ausgeben
        // Dividieren von x durch y und ausgeben auf Konsole
        // Beide Variablen als String konvertieren, "zusammenhängen" und ausgeben(es sollte "103" angezeigt werden)

        public static void RechnenUndString()
        {
            Console.WriteLine("Please input your first number: >");
            int zahl1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please input your second number: >");
            int zahl2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Sum of x & y: >");
            Console.WriteLine(zahl1 + zahl2);
            Console.WriteLine();

            Console.WriteLine("Divide x through y: >");
            Console.WriteLine(zahl1 / zahl2);
            Console.WriteLine();

            Console.WriteLine("Combine both variables: >");
            Console.WriteLine(zahl1.ToString() + zahl2.ToString());
        }

        // 2. Beispiel BMI
        // Eingabe von Gewicht in kg und der Größe in Meter
        // Errechnen und anzeigen des BMI(bmi = gewicht / (groesse * groesse))
        // Achten Sie auf die korrekten Datentypen!
        // Danach erweitern mit if um die Bereiche Untergewicht, Normal, Übergewicht auszugeben(Normal = 18.5 bis 25)

        public static void BMI()
        {
            Console.WriteLine("Please input your weight [kg]: >");
            int weight = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please input your height [m]: >");
            double height = Convert.ToDouble(Console.ReadLine());

            double bmi = weight / Math.Pow(height, 2);

            Console.WriteLine();
            switch (bmi)
            {
                case < 18.5:
                    Console.WriteLine("Untergewicht: " + Math.Round(bmi, 1));
                    break;
                case > 25:
                    Console.WriteLine("Übergewicht: " + Math.Round(bmi, 1));
                    break;
                default:
                    Console.WriteLine("Normal: " + Math.Round(bmi, 1));
                    break;
            }
        }

        // 3. Beispiel Koerperoberflaeche
        // Eingabe von Größe in cm und Gewicht in kg
        // Achten Sie auf die korrekten Datentypen!
        // Berechnung nach Mosteller: Körperoberfläche in qm = Wurzel(Größe in cm* Gewicht in kg/3600)
        // Tipp: Math

        public static void Koerperoberflaeche()
        {
            Console.WriteLine("Please input the height [cm]: >");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please input the weight [kg]: >");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Quadratmeter: " + Math.Round(Convert.ToDouble(Math.Sqrt(height * (weight / 3600))), 2) + " m²");
        }

        // 4. Beispiel Schaltjahr
        // Berechnen, ob das eingebenen Jahr ein Schaltjahrs ist
        // Eingabe eines beliebigen Jahres(zB. 2012) über Konsole oder bei keiner Eingabe das aktuelle Jahr nehmen(DateTime.Now.Year)
        // Info: Ist die Jahreszahl durch vier teilbar, aber nicht durch 100, ist es ein Schaltjahr
        // Ist die Jahreszahl durch 400 teilbar, dann ist es ein Schaltjahr

        public static void Schaltjahr()
        {
            Console.WriteLine("Please input a year or leave it blank for the current year: >");
            string input = Console.ReadLine();

            if (input == "")
            {
                string schaltjahr = DateTime.IsLeapYear(DateTime.Now.Year) ? " ist ein Schaltjahr." : " ist kein Schaltjahr.";
                Console.WriteLine("Das Jahr " + DateTime.Now.Year + schaltjahr);
            }
            else
            {
                int year = Convert.ToInt32(input);

                if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                {
                    Console.WriteLine("Das Jahr " + year + " ist ein Schaltjahr.");
                }
                else
                {
                    Console.WriteLine("Das Jahr " + year + " ist kein Schaltjahr.");
                }
            }
        }

        // 5. Beispiel CheckName
        // Eingabe eines Namens über die Konsole
        // Ausgabe: Länge des Textes, ob ein Leerzeichen enthalten ist, und wenn ja, an welcher Position
        // Ausgabe: Name ohne Leerzeichen in Großbuchstaben
        // Ausgabe: letztes Zeichens des Namens

        public static void CheckName()
        {
            Console.WriteLine("Please input a name: >");
            string name = Console.ReadLine();

            Console.WriteLine("Länge des Textes: " + name.Replace(" ", "").Length);

            string space = name.Contains(" ") ? "Ja, an der Stelle " + (Convert.ToInt32(name.IndexOf(" ")) + 1) : "Nein";
            Console.WriteLine("Leerzeichen enthalten? " + space);

            Console.WriteLine("Name ohne Leerzeichen in Großbuchstaben: " + name.Replace(" ", "").ToUpper());

            Console.WriteLine("Letztes Zeichen des Namens: " + name[name.Length - 1]);
        }

        // 6. Beispiel CheckNameFunction
        // Übung 5 (CheckName) erweitern: Diverse Ausgaben(Länge des Namens, etc.) in eine Funktion auslagern wobei der eingegebene Name der Funktion als Argument übergeben wird)

        public static void CheckNameParam(string name)
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Länge des Textes: " + name.Length);

            string space = name.Contains(" ") ? "Ja, an der Stelle " + name.IndexOf(" ") + 1 : "Nein";
            Console.WriteLine("Leerzeichen enthalten? " + space);

            Console.WriteLine("Name ohne Leerzeichen in Großbuchstaben: " + name.Replace(" ", "").ToUpper());

            Console.WriteLine("Letztes Zeichen des Namens: " + name[name.Length - 1]);
        }

        // 7. Beispiel inputInt
        // Eingabe-FUNKTION welche mit Exception-Handling eine ZWINGENDE nummerische Eingabe zwischen einem minimalen und einem maximalen Wert zurückliefert.
        // Beispielaufruf: int x = inputInt("Geben Sie eine Zahl zwischen 5 und 10 ein", 5, 10);
        // Die Eingabe soll sich so lange wiederholen, bis eine Zahl im entsprechenden Bereich eingegeben wurde

        public static void InputInt(string text, int min, int max)
        {

            while (true)
            {
                Console.WriteLine(text + min + ", " + max);

                try
                {
                    int erg = Convert.ToInt32(Console.ReadLine());

                    if (min < erg && max > erg)
                    {
                        Console.WriteLine("Passt.");
                        break;
                    }
                    else if (min > erg)
                    {
                        Console.WriteLine("Die Zahl muss größer als " + min + " sein.");
                        continue;
                    }
                    else if (max < erg)
                    {
                        Console.WriteLine("Die Zahl muss kleiner als " + max + " sein.");
                    }
                }
                catch
                {
                    Console.WriteLine("Bitte geben Sie eine Zahl ein!");
                    continue;
                }
            }
        }

        // 8. Beispiel ToDoVerwaltung
        // Wiederholte Eingabe eines ToDos als Text
        // Eingabe von "quit" beendet das Programm
        // Danach speichern des eingegebenen ToDos in einer Textdatei.Achtung! Anhängen, nicht überschreiben! (Tipp: Neue Zeile = Environment.NewLine)
        // Danach anzeigen aller bereits vorhandenen ToDos
        // Eingabe von "delete" löscht die Datendatei
        // Der Dateiname der Textdatei soll als Konstante definiert sein
        // Beim Erneuten Start des Programms:
        // Kopieren der "Datendatei" (falls vorhanden) in eine "Backup-Datei"
        // Alle vorhandenen ToDos aus der Datei anzeigen

        public static void ToDoVerwaltung()
        {
            const string FILENAME = "todos.txt";
            string bak = FILENAME.Split(".")[0] + "_backup." + FILENAME.Split(".")[1];

            if (File.Exists(FILENAME))
            {
                if (File.Exists(bak))
                {
                    File.Delete(bak);
                }
                File.Copy(FILENAME, bak);
            }

            while (true)
            {
                Console.WriteLine("Bitte geben Sie ihr ToDo ein: >");

                string input = Console.ReadLine();

                if (input.Trim().ToLower().Equals("quit"))
                {
                    Environment.Exit(0);
                    break;
                }
                else if (input.Trim().ToLower().Equals("delete"))
                {
                    if (File.Exists(FILENAME))
                    {
                        File.Delete(FILENAME);
                    }
                    break;
                }

                File.AppendAllText(FILENAME, input + Environment.NewLine);

                Console.WriteLine();
                Console.WriteLine("Bisherige ToDos:");
                string[] lines = File.ReadAllLines(FILENAME);

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();
            }
        }
    }
}