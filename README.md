# **Projekt útulek škola (Papachristos, Žák, Mikulášek)**



## *Jak fungují jednotlivé funkce:*

* **pridat\_zvire():**

  1. Uživatel zadá jméno zvířete
  2. Kontrola platnosti jména
  3. Uživatel zadá věk
  4. Kontrola platnosti věku
  5. Zadání druhu
  6. Zadání pohlaví
  7. Zadaní datumu přijetí
  8. Zadaní zdravotního stavu
  9. Zadání poznámky
  10. Přidání zvířete do listu
  11. IDs se zvěčí o 1



* **vypis\_zvirat():**

  1. foreach loop -> vypíše všechny zvířata v listu



* **search():**

  1. Uživatel zadá jméno zvířete (není povinné pokud uživatel nechce vyhledávat podle jména)
  2. Uživatel zadá druh zvířete (není povinné pokud uživatel nechce vyhledávat podle druhu)
  3. Uživatel zadá věkové rozmezí (není povinné pokud uživatel nechce vyhledávat podle věku)
  4. Kontrola správného zadání rozmezí věku
  5. zkouška najití shody v listu pomoci filtrovaného seznamu



* **Adopce():**

  1. Vypíše se aktuální list zvířat
  2. Uživatel zadá ID zvířete
  3. Provede se kontrola zda zvíře vůbec existuje
  4. Zkouška najití shodného ID v listu zvířat
  5. pokud h.ID != z.ID -> Uživateli se vypíše "Neplatné ID"
  6. Pokud h.ID == z.ID -> Provede se funkce Adoptuj()

&#x09;

* **Adoptuj():**

  1. Uživateli se vypíše, že zvíře bylo adoptováno
  2. Uživatel zadá datum adopce
  3. Zvíře se označí jako adoptované



* **Edit():**

  1. Vypíše se aktuální list zvířat
  2. Uživatel zadá ID zvířete
  3. Provede se kontrola zda zvíře vůbec existuje
  4. Zkouška najití shodného ID v listu zvířat
  5. pokud h.ID != z.ID -> Uživateli se vypíše "Neplatné ID"
  6. Pokud h.ID == z.ID -> Provede se funkce Edit()



* **Edit():**

  1. Uživateli se vypíší jednoduché instrukce
  2. Uživateli se vypíše možnost zadat nové jméno
  3. Uživateli se vypíše možnost zadat nový věk
  4. Uživateli se vypíše možnost zadat nové pohlaví??? rok 2026 I guess
  5. Uživateli se vypíše možnost zadat nový zdravotní stav
  6. Uživateli se vypíše možnost zadat novou poznámku





## *Rozdělení rolí:*

Andreas Papachristos -> Přiložil obě ruce k dílu | kód a převážně README.md

Jiří Žák -> též přiložil obě ruce k dílu | převážně kód, debbuging a README.md

Patrik Mikulášek -> také přiložil obě ruce k dílu | I kód i README.md



## *Jak spustit:*

1. Stáhnu .zip soubor
2. Extrahuji vše do libovolné složky
3. Otevřu program "Program.cs" -> ConsoleApp1/AppV2/Program.cs
4. Spustím program

