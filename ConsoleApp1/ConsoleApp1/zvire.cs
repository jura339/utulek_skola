using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class zvire
    {
        public string jmeno { get; set; }
        public int vek { get; set; }
        public string druh { get; set; }
        public char pohlavi { get; set; }
        public int datum_prijeti { get; set; }
        public string zdravotni_stav { get; set; }
        public string poznamka { get; set; }

        public zvire(string jmeno, int vek, string druh, char pohlavi, int datum_prijeti, string zdravotni_stav, string poznamka)
        {
            this.jmeno = jmeno;
            this.vek = vek;
            this.druh = druh;
            this.pohlavi = pohlavi;
            this.datum_prijeti = datum_prijeti;
            this.zdravotni_stav = zdravotni_stav;
            this.poznamka = poznamka;
        }
    }
}
    