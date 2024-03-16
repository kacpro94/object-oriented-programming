using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolosC
{
    public class ProduktPromocyjny:Produkt
    {
        DateTime dataPromocji;
        static decimal promocja;

        static ProduktPromocyjny()
        {
            promocja = 0.2m;
        }

        public ProduktPromocyjny(string kodProduktu, Dostawca producent, decimal cena, DateTime dataPromocji) : base(kodProduktu, producent, cena)
        {
            this.dataPromocji = dataPromocji;
        }
        public override decimal WartoscFaktury(float ilosc)
        {
            return base.WartoscFaktury(ilosc) - promocja * base.WartoscFaktury(ilosc);
        }
        public override string ToString()
        {
            return base.ToString()+", "+dataPromocji.ToString("dd-MMM-yyyy");
        }

    }
}
