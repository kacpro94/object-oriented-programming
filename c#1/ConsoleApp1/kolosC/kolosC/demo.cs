using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolosC
{
    public  class demo
    {
        public static void Main(string[] args)
        {
            Dostawca dostawca1 = new Dostawca(EnumDostawcy.Samsung, "polska", "12345678911");
            Dostawca dostawca2 = new Dostawca(EnumDostawcy.Sony, "zimbwabwe", "12345678922");
            ProduktOnline produkt1 = new ProduktOnline("12345678", dostawca1, 25.25m, true);
            ProduktOnline produkt2 = new ProduktOnline("12345677", dostawca2, 1235m, false);

            ProduktPromocyjny produkt3 = new ProduktPromocyjny("12345699", dostawca2, 666.45m, DateTime.Now);
            ProduktPromocyjny produkt4 = new ProduktPromocyjny("12345622", dostawca1, 4751m, DateTime.Now);

            Sprzedawca sprzedawca = new Sprzedawca("Sprzedawca");
            sprzedawca.DodajProdukt(produkt1);
            sprzedawca.DodajProdukt(produkt2);
            sprzedawca.DodajProdukt(produkt3);
            sprzedawca.DodajProdukt(produkt4);

            produkt1.SprzedazDetaliczna(3);
            produkt2.SprzedazDetaliczna(1);
            produkt3.SprzedazDetaliczna(1);
            produkt4.SprzedazDetaliczna(10);
            sprzedawca.Sortuj();
            Console.WriteLine(sprzedawca.ToString());
            Console.WriteLine(produkt1.CompareTo(produkt2));



        }
    }
}
