namespace AppV2;

internal class zvire
    {
        public int id {  get; set; }
        public string jmeno { get; set; }
        public int vek { get; set; }
        public string druh { get; set; }
        public string pohlavi { get; set; }
        public int datum_prijeti { get; set; }
        public string zdravotni_stav { get; set; }
        public string poznamka { get; set; }
        public bool? adopce { get; set; }
        public int? datum_adopce { get; set; }

        public zvire(int id, string jmeno, int vek, string druh, string pohlavi, int datum_prijeti, string zdravotni_stav, string poznamka, bool? adopce = false, int? datum_adopce = null)
        {
            this.id = id;
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
            if (int.TryParse(Datum, out int datum))
            {
                this.datum_adopce = datum;
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
            Console.WriteLine("Zadavejte nove udaje, pro zanechani jednotlivych udaju nic nevyplnujte.");
            Console.Write("Zadejte nove jmeno: ");
            string Jmeno = Console.ReadLine();
            this.jmeno = Jmeno;

            Console.Write("Zadejte novy vek: ");
            string Vek = Console.ReadLine();
            if (int.TryParse(Vek, out int vek)) ;

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
            Console.WriteLine($"ID: {id}, Jméno: {jmeno}, Věk: {vek}, Druh: {druh}, Pohlaví: {pohlavi}, Datum přijetí: {datum_prijeti}, Zdravotní stav: {zdravotni_stav}, Poznámka: {poznamka}, Adopce: {adopce}, Datum adopce: {datum_adopce}");
        }

        public void pepega(){}
    }
