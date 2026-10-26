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
        public bool? adopce {  get; set; }
        public int? datum_adopce{ get; set; }

        public zvire(string jmeno, int vek, string druh, char pohlavi, int datum_prijeti, string zdravotni_stav, string poznamka, bool? adopce = false, int? datum_adopce = null)
        {
            this.jmeno = jmeno;
            this.vek = vek;
            this.druh = druh;
            this.pohlavi = pohlavi;
            this.datum_prijeti = datum_prijeti;
            this.zdravotni_stav = zdravotni_stav;
            this.poznamka = poznamka;
            this.adopce = adopce;
            this.datum_adopce = datum_adopce;
        }

        public void search()
        {
            string jmeno;
            string druh;
            string[] casti;

            Console.WriteLine("Vyhledavani:");
            Console.Write("Zadejte jmeno (nechte volne pro nevybrani): ");
            jmeno = Console.ReadLine();

            Console.Write("Zadejte druh (nechte volne pro nevybrani): ");
            druh = Console.ReadLine();

            Console.Write("Zadejte vekove rozmezi (např. 2-9, nechte volne pro nevybrani rozmezi): ");
            string vstup = Console.ReadLine();

            casti = vstup.Split('-');
            if (casti.Length == 2 && int.TryParse(casti[0], out int min) && int.TryParse(casti[1], out int max))
            {
                Console.WriteLine($"Vybráno rozmezí: Od {min} do {max} let.");
            }
            else if (vstup == "") { Console.WriteLine("Rozmezi nevybrano"); }

            else
            {
                Console.WriteLine("Neplatný formát! Zadejte prosím čísla ve formátu 'X-Y'.");
            }

        }
        public void Adoptuj()
        {
            this.adopce = true;
            Console.WriteLine("Zvíře bylo adoptováno.");
            Console.Write("Zadej datum adopce: ");
            string Datum = Console.ReadLine();
            if (int.TryParse(Datum, out int datum_adopce))
            {
                Console.WriteLine("Adopce Uspesna!");
            }
            Console.WriteLine(this.datum_adopce);
        }
    }
}
    