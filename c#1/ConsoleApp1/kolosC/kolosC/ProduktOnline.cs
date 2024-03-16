using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolosC
{
    public class ProduktOnline:Produkt
    {
        public bool dostepOnline;

        public ProduktOnline(string kodProduktu,Dostawca producent,decimal cena,bool dostepOnline) : base(kodProduktu, producent, cena)
        {
            this.dostepOnline = dostepOnline;
        }
        public override string ToString()
        {
            if (dostepOnline)
            {
                return base.ToString() + ", [+on-line]";
            }
            else { return base.ToString(); }
        }

    }
}
