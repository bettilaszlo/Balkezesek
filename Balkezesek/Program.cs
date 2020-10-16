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
            Console.WriteLine("3. feladat: ", balkez.Count);
        }
        static void Main(string[] args)
        {
            Beolvasás();
            HarmadikFeladat();
            Console.ReadKey();
        }
    }
}
