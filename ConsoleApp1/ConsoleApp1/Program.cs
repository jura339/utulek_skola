using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public void Main(string[] args)
        {
            List<zvire> list = new List<zvire>();

            zvire pepa = new zvire("Pepa", 5, "pes", 'M', 20220101, "zdravý", "bez poznámky");
            list.Add(pepa);
            pepa.Vypis();
<<<<<<< Updated upstream
=======
        }
        public void search()
        {
            //parametry
            string jmeno;
            string druh;
            string[] casti;
            int minVek = 0;
            int maxVek = 100;
            bool filtrovatVek = false;

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
                Console.WriteLine($"Vybrano rozmezi: od {min} do {max} let.");
            }
            else if (vstup == "") { Console.WriteLine("Rozmezi nevybrano"); }

            else
            {
                Console.WriteLine("Neplatný formát! Zadejte prosím čísla ve formátu 'X-Y'.");
            }


            //vyhledavani
            var filtrovanySeznam = list.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(jmeno))
            {
                filtrovanySeznam = filtrovanySeznam.Where(z => z.jmeno.ToLower().Contains(jmeno.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(druh))
            {
                filtrovanySeznam = filtrovanySeznam.Where(z => z.druh.Equals(druh, StringComparison.OrdinalIgnoreCase));
            }

            if (filtrovatVek)
            {
                filtrovanySeznam = filtrovanySeznam.Where(z => z.vek >= minVek && z.vek <= maxVek);
            }
>>>>>>> Stashed changes
        }
    }
}
