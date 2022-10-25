using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Versenyzok
{
    class Program
    {
        static List<Pilota> pilotak = new List<Pilota>();
        static void Main(string[] args)
        {
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();
            HetedikFeladat();

            Console.ReadKey();
        }

        private static void HetedikFeladat()
        {
            Console.Write("7. feladat: ");

            Dictionary<int, int> tmp = new Dictionary<int, int>();
            string sor = "";
            foreach (var pilota in pilotak)
            {
                if (pilota.Rajtszam != 0)
                {
                    if (tmp.ContainsKey(pilota.Rajtszam))
                    {
                        sor += pilota.Rajtszam + ", ";
                    }
                    else
                    {
                        tmp.Add(pilota.Rajtszam, 1);
                    }
                }
            }
            Console.WriteLine(sor.Substring(0, sor.Length - 2));
        }

        private static void HatodikFeladat()
        {
            //Console.WriteLine("6. feladat: " + pilotak.First(o => o.Rajtszam == pilotak.Where(i => i.Rajtszam != 0).Min(i => i.Rajtszam)).Nemzetiseg);
            Console.WriteLine("6 feladat: " + pilotak.Where(i => i.Rajtszam != 0).OrderBy(o => o.Rajtszam).First().Nemzetiseg);
        }

        private static void OtodikFeladat()
        {
            //Console.WriteLine("5. feladat:");
            //foreach (var pilota in pilotak)
            //{
            //    if (pilota.SzulDatum < Convert.ToDateTime("1901. 01. 01."))
            //    {
            //        Console.WriteLine($"\t{pilota.Nev} ({pilota.SzulDatum.ToShortDateString()})");
            //    }
            //}

            var lekeres = (from pilota in pilotak
                          where pilota.SzulDatum < Convert.ToDateTime("1901. 01. 01.")
                          select pilota).ToList();

            foreach (var item in lekeres)
            {
                Console.WriteLine($"\t{item.Nev} ({item.SzulDatum.ToShortDateString()})");
            }
        }

        private static void NegyedikFeladat()
        {
            Console.WriteLine("4. feladat: " + pilotak.Last().Nev);
        }

        private static void HarmadikFeladat()
        {
            Console.WriteLine("3. feladat: " + pilotak.Count);
        }

        private static void MasodikFeladat()
        {
            using (StreamReader sr = new StreamReader("Adatfajl\\pilotak.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] adat = sr.ReadLine().Split(';');
                    int szam;
                    if (!int.TryParse(adat[3], out szam))
                    {
                        szam = 0;
                    }
                    pilotak.Add(new Pilota(adat[0], Convert.ToDateTime(adat[1]), adat[2], szam));
                    //if (adat[3] == String.Empty)
                    //{
                    //    pilotak.Add(new Pilota(adat[0], Convert.ToDateTime(adat[1]), adat[2]));
                    //}
                    //else
                    //{
                    //    pilotak.Add(new Pilota(adat[0], Convert.ToDateTime(adat[1]), adat[2], Convert.ToInt32(adat[3])));
                    //}
                }
            }
        }
    }
}
