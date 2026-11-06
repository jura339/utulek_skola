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
        public int id {get; set; }
        public string jmeno { get; set; }
        public int vek { get; set; }
        public string druh { get; set; }
        public char pohlavi { get; set; }
        public int datum_prijeti { get; set; }
        public string zdravotni_stav { get; set; }
        public string poznamka { get; set; }
        public bool? adopce { get; set; }
        public int? datum_adopce { get; set; }

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

        public void Adoptuj()
        {
            this.adopce = true;
            Console.WriteLine("Zvíře bylo adoptováno.");
            Console.Write("Zadej datum adopce: ");
            string Datum = Console.ReadLine();
            if (int.TryParse(Datum, out int datum_adopce))
            {
                Console.WriteLine("Adopce úspesná!");
            }
            Console.WriteLine(this.datum_adopce);
        }

        public void Vypis()
        {
            Console.WriteLine($"Id: {id}, Jméno: {jmeno}, Věk: {vek}, Druh: {druh}, Pohlaví: {pohlavi}, Datum přijetí: {datum_prijeti}, Zdravotní stav: {zdravotni_stav}, Poznámka: {poznamka}, Adopce: {adopce}, Datum adopce: {datum_adopce}");
        }

        public void Edit()
        {
            Console.Writeline("Zadavejte nove udaje, pro zanechani jednotlivych udaju nic nevyplnujte.");
            Console.Write("Zadejte nove jmeno: ");
            string Jmeno = Console.ReadLine();
            this.jmeno = Jmeno;

            Console.Write("Zadejte novy vek: ");
            string Vek = Console.ReadLine();
            if (int.TryParse(Datum, out int vek)) ;

            Console.Write("Zadejte nove pohlavi (w8, what? Wdym novy pohlavi ???): ");
            string Pohlavi = Console.ReadLine();
            this.pohlavi = Pohlavi;

            Console.Write("Zadejte novy zdrav. stav: ");
            string Stav = Console.ReadLine();
            this.zdravotni_stav = Stav;

            Console.Write("Zadejte novou poznamku: ");
            string Pozn = Console.ReadLine();
            this.poznamka = Pozn;
        }

        public void remove()
        {
            
        }
    }
}
    