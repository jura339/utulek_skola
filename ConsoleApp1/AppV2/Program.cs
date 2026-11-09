using System.ComponentModel.DataAnnotations;
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
                Console.WriteLine("2 - Odebrat zvíře");
                Console.WriteLine("3 - Vypsat všechna zvířata");
                Console.WriteLine("4 - Vyhledat/ filtrovat");
                Console.WriteLine("5 - Označit adopci");
                Console.WriteLine("6 - Statistiky (volitelné)");
                Console.WriteLine("0 - Konec");
                Console.Write("Zadejte volbu: ");
                int volba = int.Parse(Console.ReadLine());
                switch (volba)
                {
                    case 1:
                        Console.WriteLine("//------------------------------");
                        pridat_zvire();
                        Console.WriteLine("//==============================");
                        break;
                    case 2:
                        Console.WriteLine("//------------------------------");
                        delete();
                        Console.WriteLine("//==============================");
                        break;
                    case 3:               
                        Console.WriteLine("//------------------------------");
                        vypis_zvirat();
                        Console.WriteLine("//==============================");
                        break;
                    case 4:
                        Console.WriteLine("//------------------------------");
                        search();
                        Console.WriteLine("//==============================");
                        break;
                    case 5:
                        Console.WriteLine("//------------------------------");                        
                        Adopce();
                        Console.WriteLine("//==============================");
                        break;
                    case 6:
                        Console.WriteLine("//------------------------------");

                        Console.WriteLine("//==============================");
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

void pridat_zvire()
{
    Start:
    Console.Write("Zadejte jmeno: ");
    string jmeno = Console.ReadLine();
    if (jmeno == "") {Console.WriteLine("Zadejte platne jmeno"); goto Start;}

    Console.Write("Zadejte vek: ");
    string vek = Console.ReadLine();
    
    if (int.TryParse(vek, out int Vek)) {};
    if (vek == "" || Vek < 0 || Vek == null)
    {
        Console.WriteLine("Zadejte platny vek");
        goto Start;
    }

    Console.Write("Zadejte druh: ");
    string druh = Console.ReadLine();

    Console.Write("Zadejte pohlavi: ");
    string pohlavi = Console.ReadLine();

    Console.Write("Zadejte datum prijeti ve formatu YY/MM/DD (20221030) ");
    string datum = Console.ReadLine();
    if (int.TryParse(datum, out int Datum)) {};

    Console.Write("Zadejte zdravotni stav: ");
    string stav = Console.ReadLine();

    Console.Write("Zadejte poznamku: ");
    string pozn = Console.ReadLine();

    zvire Zvire = new zvire(IDs, jmeno, Vek, druh, pohlavi, Datum, stav, pozn);
    list.Add(Zvire);
    Console.WriteLine("Zvire uspesne vytvoreno");
    IDs += 1;
}

void delete()
        {
            vypis_zvirat();
            Console.Write("Zadejte název zvířete jenž chcete smazat: ");
            string nazev = Console.ReadLine();
            bool odstranen = false;
            foreach (zvire z in list)
            {
                if(nazev == z.Jmeno){
                    list.remove(z.Jmeno)
                    odstranen = true;
                }

            }
            if(odstranen==false){
                Console.WriteLine("Toto zvíře v útulku nevedeme");
            }
        

        }

void vypis_zvirat()
        {
            foreach (zvire z in list)
            {
                z.Vypis();
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
void Adopce()
{
    vypis_zvirat();
    Console.Write("Zadejte ID zvirete jenz chcete adoptovat: ");
    string vstupId = Console.ReadLine();

    if (int.TryParse(vstupId, out int hledaneId))
    {
        // 4. Najdeme zvíře v seznamu podle zadaného ID
        // Zápis z => z.Id == hledaneId znamená: "Najdi zvíře z, jehož Id se rovná hledaneId"
        zvire nalezenéZvire = list.Find(z => z.id == hledaneId);

        if (nalezenéZvire != null)
        {
            nalezenéZvire.Adoptuj();
        }
        else
        {
            Console.WriteLine($"Neplatne ID");
        }
    }
    else
    {
        Console.WriteLine("Zadané ID není platné číslo.");
    }
}

Main();