using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
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
                Console.WriteLine("7 - Exportovat data do souboru");
                Console.WriteLine("8 - Importovat data ze souboru");
                Console.WriteLine("9 - Editovat zvire");
                Console.WriteLine("0 - Konec");
                Console.Write("Zadejte volbu: ");
                string Volba = Console.ReadLine();
                if (int.TryParse(Volba, out int volba)) {};
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
                        Statistiky();
                        Console.WriteLine("//==============================");
                        break;
                    case 7:
                        Console.WriteLine("//------------------------------");
                        ExportovatData();
                        Console.WriteLine("//==============================");
                        break;
                    case 8:
                        Console.WriteLine("//------------------------------");
                        ImportovatData();
                        Console.WriteLine("//==============================");
                        break;
                    case 9:
                        Console.WriteLine("//------------------------------");
                        Edit();
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
            zvire Z = null;
            foreach (zvire z in list)
            {
                if(nazev == z.jmeno){
                    Z = z;
                    odstranen = true;
                    break;
                }

            }

            if (Z != null)
            {
                list.Remove(Z);
                settonull(Z);
                Console.WriteLine("Zvire uspesne odstraneno");
            }

            if(odstranen==false){
                Console.WriteLine("Toto zvíře v útulku nevedeme");
            }
        }

void settonull(zvire z)
{
    z = null;
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
                filtrovatVek = true;
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


            var vysledky = filtrovanySeznam.ToList();

            //vypis
            Console.WriteLine($"\n--- Výsledky vyhledávání (Nalezeno: {vysledky.Count}) ---");
            if (vysledky.Count > 0)
            {
                foreach (var z in vysledky)
                {
                    z.Vypis();
                }
            }
            else
            {
                Console.WriteLine("Žádná zvířata neodpovídají zadaným kritériím.");
            }
        }

void Adopce()
{
    vypis_zvirat();
    Console.Write("Zadejte ID zvirete jenz chcete adoptovat: ");
    string vstupId = Console.ReadLine();

    if (int.TryParse(vstupId, out int hledaneId))
    {
        //najit zvire v seznamu
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



void Edit()
{
    vypis_zvirat();
    Console.Write("Zadejte ID zvirete jenz chcete editovat: ");
    string vstupId = Console.ReadLine();

    if (int.TryParse(vstupId, out int hledaneId))
    {
        //najit zvire v seznamu
        zvire nalezenéZvire = list.Find((zvire z) => z.id == hledaneId);

        if (nalezenéZvire != null)
        {
            nalezenéZvire.Edit();
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




void Statistiky()
{
    if (list.Count == 0)
    {
        Console.WriteLine("Útulek je prázdný, nejsou k dispozici žádné statistiky.");
        return;
    }

    Console.WriteLine("===== STATISTIKY ÚTULKU =====");
    Console.WriteLine($"Celkový počet zvířat v útulku: {list.Count}");

    //prumerny vek
    double prumernyVek = list.Average((zvire z) => z.vek);
    Console.WriteLine($"Průměrný věk zvířat: {prumernyVek:F1} let");

    //pocet adoptovanych
    int pocetAdoptovanych = list.Count((zvire z) => z.adopce.GetValueOrDefault(false)); //kdyby se nekomu povedlo udelat null v zvire.adoptuj *facepalm*
    int pocetNeadoptovanych = list.Count - pocetAdoptovanych;
    Console.WriteLine($"Počet adoptovaných zvířat: {pocetAdoptovanych}");
    Console.WriteLine($"Počet zvířat čekajících na domov: {pocetNeadoptovanych}");

    //podle druhu
    Console.WriteLine("\n--- Počet zvířat podle druhu ---");
    var zvirataPodleDruhu = list.GroupBy(z => z.druh.Trim().ToLower())
                                .Select(g => new { 
                                    Druh = g.Key,
                                    Pocet = g.Count() 
                                }); //ja vim ze tohle neni moc pekny, ale lepsi nez to vypisovat jednotlive, delat hromadu temp apod T.T

    foreach (var skupina in zvirataPodleDruhu)
    {
        Console.WriteLine($"- {skupina.Druh}: {skupina.Pocet}");
    }
}

//--------------------
//Import Export
//--------------------

void ExportovatData()
{
    Console.Write("Zadejte název souboru pro export (např. zvirata.json): ");
    string cesta = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(cesta))
    {
        cesta = "zvirata.json"; //kdyby uzivatel byl jelito
    }

    try
    {
        //format json
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(list, options);
        
        File.WriteAllText(cesta, jsonString);
        Console.WriteLine($"Data byla úspěšně exportována do souboru: {Path.GetFullPath(cesta)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Chyba při exportu: {ex.Message}");
    }
}

void ImportovatData()
{
    Console.Write("Zadejte název souboru pro import (např. zvirata.json): ");
    string cesta = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(cesta))
    {
        cesta = "zvirata.json";
    }

    if (!File.Exists(cesta))
    {
        Console.WriteLine($"Soubor '{cesta}' nebyl nalezen.");
        return;
    }

    try
    {
        string jsonString = File.ReadAllText(cesta);
        List<zvire> nactenaZvirata = JsonSerializer.Deserialize<List<zvire>>(jsonString);

        if (nactenaZvirata != null)
        {
            list = nactenaZvirata;
            
            //zvetsit Id, at nedojde ke kolizi pri importu
            if (list.Count > 0)
            {
                IDs = list.Max(z => z.id) + 1;
            }
            else
            {
                IDs = 0;
            }

            Console.WriteLine($"Úspěšně importováno {list.Count} zvířat.");
        }
        else
        {
            Console.WriteLine("Soubor je prázdný nebo se data nepodařilo načíst.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Chyba při importu: {ex.Message}");
    }
}


Main();