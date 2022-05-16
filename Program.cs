using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Eingabeprüfung_T11_SS2
{
    class Program
    {
        static void Main(string[] args)
        {
            //int z;
            //double d;
            //bool erfolgreich;
            //string eingabe;
            //while (true)
            //{
            // do
            // {
            //ganze zahlen
            //Console.WriteLine("Eine ganze Zahl eingeben:");
            //Console.Write("z=");
            //eingabe = Console.ReadLine();
            //erfolgreich = int.TryParse(eingabe, out z);
            //if (!erfolgreich) Console.WriteLine("Ungültige Eingabe!");

            //Dezimalzahlen
            //Console.WriteLine("Eine Dezimalzahl eingeben:");
            //Console.Write("d=");
            //eingabe = Console.ReadLine();
            //erfolgreich = double.TryParse(eingabe, out d);
            //if (!erfolgreich) Console.WriteLine("Ungültige Eingabe!");

            // analog für char, bool, short, float usw.

            // } while (!erfolgreich);// !erfolgreich <-> Umkehrung (Negation)
            //}

            //Passwortüberprüfung
            while (true)
            {
                string password;
                bool korrekt;
                int zähler = 0;
                Console.WriteLine("Passwort erstellen:");
                Console.Write("Das Passwort soll \n" +
                    "-mindestens acht Zeichen\n" +
                    "-mindestens eine Ziffer\n" +
                    "-mindestens einen Groß- und einen Kleinbuchstaben\n" +
                    "-mindestens ein Sonderzeichen enthalten.\n");
                do
                {
                    Console.Write("Passwort eingeben:");
                    password = Console.ReadLine();
                    if (password.Length >= 8) zähler++;
                    if (EnthältZiffern(password)) zähler++;
                    if (EnthältGroßbuchstaben(password)) zähler++;
                    if (EnthältKleinbuchstaben(password)) zähler++;
                    if (EnthältSonderzeichen(password)) zähler++;

                    if (zähler == 5)
                    {
                        korrekt = true;
                        Console.WriteLine("Gültige Eingabe.");
                    }
                    else
                    {
                        korrekt = false;
                        Console.WriteLine("Ungültige Eingabe!");
                    }
                } while (korrekt == false);
                Console.WriteLine("Gutes Passwort.");
            }
        }

        private static bool EnthältSonderzeichen(string testString)
        {
            bool ergebnis = false;
            for (int i = 0; i < testString.Length; i++)
            {
                if (!Char.IsLetterOrDigit(testString[i])) ergebnis = true;
            }
            return ergebnis;
        }

        static bool EnthältZiffern(string testString)
        {
            //bool ergebnis = false;
            //for (int i = 0; i < testString.Length; i++)
            //{
            //    if (Char.IsDigit(testString[i])) ergebnis = true;
            //}
            //Regex reg = new Regex("^[0-9]+$");
            //ergebnis = reg.IsMatch(testString);
            //return ergebnis;

            return Regex.IsMatch(testString, "^[0-9]+$");
        }

        static bool EnthältGroßbuchstaben(string testString)
        {
            bool ergebnis = false;
            for (int i = 0; i < testString.Length; i++)
            {
                if (Char.IsUpper(testString[i]) && Char.IsLetter(testString[i])) ergebnis = true;
            }
            return ergebnis;
        }

        static bool EnthältKleinbuchstaben(string testString)
        {
            bool ergebnis = false;
            for (int i = 0; i < testString.Length; i++)
            {
                if (Char.IsLower(testString[i]) && Char.IsLetter(testString[i])) ergebnis = true;
            }
            return ergebnis;
        }
    }
}
