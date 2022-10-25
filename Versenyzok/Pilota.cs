using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versenyzok
{
    class Pilota
    {
        private string nev;

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        private DateTime szulDatum;

        public DateTime SzulDatum
        {
            get { return szulDatum; }
            set { szulDatum = value; }
        }

        private string nemzetiseg;

        public string Nemzetiseg
        {
            get { return nemzetiseg; }
            set { nemzetiseg = value; }
        }

        private int rajtszam;

        public int Rajtszam
        {
            get { return rajtszam; }
            set { rajtszam = value; }
        }

        public Pilota(string nev, DateTime szulDatum, string nemzetiseg)
        {
            Nev = nev;
            SzulDatum = szulDatum;
            Nemzetiseg = nemzetiseg;
        }

        public Pilota(string nev, DateTime szulDatum, string nemzetiseg, int rajtszam) : this(nev, szulDatum, nemzetiseg)
        {
            Rajtszam = rajtszam;
        }
    }
}
