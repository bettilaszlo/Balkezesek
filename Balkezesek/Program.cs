using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    class Program
    {
        static List<balkezesek> balkez = new List<balkezesek>();
        static void Beolvasás()
        {
            StreamReader file = new StreamReader("balkezesek.csv");
            file.ReadLine();

            while (!file.EndOfStream)
            {
                string[] a = file.ReadLine().Split(';');
                balkez.Add(new balkezesek(a[0], a[1], a[2], Convert.ToInt32(a[3]), Convert.ToInt32(a[4])));
            }
            file.Close();

        }
        static void HarmadikFeladat()
        {
            Console.WriteLine("3. feladat: {0}", balkez.Count);
        }
        static void NegyedikFeladat()
        {
            //    var negyedik = from b in balkez
            //                   where b.Utolso.Contains("1999-10-")
            //                   select new { Name = b.Nev, Mag = b.Magassag};

            //    Console.WriteLine($"4. feladat:");
            Console.WriteLine("4. feladat: ");

            foreach (var b in balkez)
            {
                if (b.Utolso.Contains("1999-10"))
                {
                    Console.WriteLine($"\t{b.Nev}  {Math.Round(b.Magassag * 2.54, 1)} cm");
                }
            }

        }
        static void OtHat()
        {
            int evszam = 0;
            bool hibas;
            do
            {
                hibas = false;
                Console.WriteLine("Kérek egy 1990 és 1999 közötti évszámot: ");
                evszam = Convert.ToInt32(Console.ReadLine());
                if (evszam < 1990 || evszam > 1999)
                {
                    hibas = true;
                    Console.WriteLine("Hibás adat");
                }
            } while (hibas);
            var eves = from b in balkez
                       where Convert.ToInt32(b.Elso.Substring(0, 4)) <= evszam
                       &&
                       Convert.ToInt32(b.Utolso.Substring(0, 4)) >= evszam
                       select new { b.Suly };

            var evesList = eves.ToList();
            double szum = 0;
            foreach (var e in evesList)
            {
                szum += e.Suly;
            }
            double atlag = Math.Round(szum / evesList.Count(), 2);
            Console.WriteLine("6. feladat: {0:N2} font", atlag);
        }
        static void Hetedik()
        {
            var nevek = from b in balkez
                        select b.Nev;

            var nevLista = nevek.ToList();

            var kezdoBetu = from n in nevLista
                            orderby n
                            group n by n[0] into Nevek
                            select Nevek;

            foreach (var csoport in kezdoBetu)
            {
                Console.WriteLine(" {0}", csoport.Key);
                foreach (var csoportTag in csoport)
                {
                    Console.WriteLine($"\t{csoportTag}");
                }
            }
        }
        static void Main(string[] args)
        {
            Beolvasás();
            HarmadikFeladat();
            NegyedikFeladat();
            OtHat();
            Hetedik();
            Console.ReadKey();
        }
    }
}
