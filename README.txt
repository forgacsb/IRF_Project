Az eatSUMthing szoftver egy város gyermekétkeztetési adminisztrációját megkönnyítő alkalmazás, melynek célja hogy egyszerűen és átláthatóan tudjuk adminisztrálni a gyermekétkeztetési adatokat, menedzselni és riportolni tudjuk az étkezési adagszámokat.

Funkciók:

-Személyek beolvasása az adatbázisból és típusonként való szétválasztása (tanár, diák).
-Beolvasott listában való szűrési lehetőség intézményre és osztályra, adatok listázása.
-Tanár esetén az osztály inputmező elrejtése és megfelelő kezelése.
-Adatbázis újra betöltése.
-Védelmi mechanizmus: Árkalkuláció és Excel riport generálás előtt egy biztonsági feladatot kell megoldani a felhasználónak. Nagy mennyiségű adat esetén minkét művelet időigényes, ezért ez a biztosági kérdés meggátolja a véletlen futtatást. A felhasználónak 5 véletlenszerűen generált szám közül kell kiválasztania a megfelelőt.
-Árkalkuláló modul: a felhasználó megadhat egy összeget, melyet validálást követően a díjszámításhoz használjuk fel. A belső logikának megfelelően a rendszer kikalkulálj az egyéni fogyasztói árat a különféle paratémeter figyelembevételével, melyet a felhasználóhoz hozzá is rendel.
-Unit test: A beadott árat vizsgáljuk meg, hogy az valóban egész tipusú szám-e.
-Étkezési napló generálás: A rendelkezésre álló és kalkulált adatokból a program készít egy adminisztrátorok által kezelhető excel táblázatot, melyben nyomon lehet követni, ki mikor étkezett és ebből fakadóan milyen díjakat kell fizetnie.

A programban ügyfeleket tárolunk viszont nem minden ügyfélnek vannak azonos paraméterei, amelyet tárolni szeretnénk róla. Így az ügyfél osztály egy asztrakció lesz, melyben a közös, főparaméterek kerülnek tárolásra.
Létrejövő, ebből származtatott két osztály pedig a Pedagógus és a Tanuló lesz.

Mindemellett a program része egy PricingEngine árazómodul készítése, mely kiszámolja a többkülönféle bemeneti paraméter alapján a kiszámlázandó étkezési díjakat.