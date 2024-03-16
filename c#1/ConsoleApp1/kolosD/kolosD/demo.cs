using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolosD
{
    public class demo
    {
        public static void Main(string[] args)
        {
            Abonent abonent = new Abonent("ppp","vvvv","00000000000");
            Abonent abonent1 = new Abonent("szyms", "eqeq", "11111111111");

            Abonent abonent2 = new Abonent("michal", "krzesla", "45454698745");

            Abonent abonent3 = new Abonent("szef", "oooo", "47454698745");

            TelefonKomorkowy telefon1 = new TelefonKomorkowy("505505505",abonent,EnumOperatorSieci.Orange);
            TelefonKomorkowy telefon2 =new TelefonKomorkowy("603603603",abonent1 ,EnumOperatorSieci.TMobile);

            TelefonStacjonarny telefon3 = new TelefonStacjonarny("898656232", abonent2,true);
            TelefonStacjonarny telefon4 = new TelefonStacjonarny("111156232", abonent3, false);

            Firma firma1 = new Firma("Firma");
            telefon1.RejstracjaRozmowy(2.58f);
            telefon2.RejstracjaRozmowy(2.59f);

            telefon3.RejstracjaRozmowy(2.18f);
            telefon4.RejstracjaRozmowy(2.68f);

            firma1.DodajTelefon(telefon1);
            firma1.DodajTelefon(telefon2);
            firma1.DodajTelefon(telefon3);
            firma1.DodajTelefon(telefon4);

            Console.WriteLine(firma1.ToString());


        }
    }
}
