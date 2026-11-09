using AppV2;

List<zvire> list = new List<zvire>();
int IDs = 0;

void Main()
        {
            

            zvire pepa = new zvire(IDs, "Pepa", 5, "pes", "Male", 20220101, "zdravý", "bez poznámky");
            list.Add(pepa);
            IDs += 1;
            pepa.Vypis();
            bool konec = false;

            while (!konec)
            {
                
                Console.WriteLine("===== ÚTULEK PRO ZVÍŘATA =====");
                Console.WriteLine("1 - Přidat zvíře");
                Console.WriteLine("2 - Vypsat všechna zvířata");
                Console.WriteLine("3 - Vyhledat/ filtrovat");
                Console.WriteLine("4 - Označit adopci");
                Console.WriteLine("5 - Statistiky (volitelné)");
                Console.WriteLine("0 - Konec");
                Console.Write("Zadejte volbu: ");
                int volba = int.Parse(Console.ReadLine());
                switch (volba)
                {
                    case 1:
                       
                        break;
                    case 2:
                        
                        break;
                    case 3:               
                        search();
                        break;
                    case 4:
                        
                        break;
                    case 5:
                        
                        break;
                    case 0:
                        konec = true;
                        break;
                    default:
                        Console.WriteLine("Neplatná volba. Zkuste to znovu.");
                        break;
                }
            }
                    
        }

void delete()
        {
            vypis_zvirat();
            Console.Write("Zadejte ID zvirete jenz chcete smazat: ");

        }

void vypis_zvirat()
        {
            foreach (zvire z in list)
            {
                z.Vypis();
                Console.WriteLine("//------------------------------");
            }
        }

void search()
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
        }

Main();