using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolosD
{
    public class TelefonStacjonarny:Telefon
    {
        bool sekretarka;

        public TelefonStacjonarny(string numerTelefonu,Abonent abonent,bool sekretarka) : base(numerTelefonu, abonent)
        {
            this.sekretarka = sekretarka;
        }

        public override string ToString()
        {
            if (this.sekretarka) {
                return base.ToString() + ", [sekretarka+]";
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
