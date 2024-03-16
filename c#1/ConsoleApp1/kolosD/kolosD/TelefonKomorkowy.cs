using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolosD
{
    public enum EnumOperatorSieci
    {
        TMobile, PlusGSM, Virgin, Orange
    }
    public class TelefonKomorkowy:Telefon
    {
        EnumOperatorSieci operatorSieci;
        static decimal oplataDodatkowa;

        static TelefonKomorkowy()
        {
            oplataDodatkowa = 0.05m;
        }
        public TelefonKomorkowy(string numerTelefonu,Abonent abonent,EnumOperatorSieci operatorSieci):base(numerTelefonu,abonent)
        {
            this.operatorSieci = operatorSieci;
        }

        public override decimal OplataZaRozmowe(float minuty)
        {
            return base.OplataZaRozmowe(minuty) + (decimal)minuty * oplataDodatkowa;
        }

        public override string ToString()
        {
            return base.ToString()+", "+operatorSieci.ToString();
        }
    }
}
