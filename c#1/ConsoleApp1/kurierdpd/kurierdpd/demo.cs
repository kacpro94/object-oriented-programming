using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurierdpd
{
    public class demo
    {
        public static void Main(string[] args)
        {

            MagazynLIFO mStos= new MagazynLIFO("mStos",50);
            Paczka paczka1 = new Paczka("nadawcaA",7);
            Paczka paczka2 = new Paczka("nadawcab", 72);
            Paczka paczka3 = new Paczka("nadawcac", 71);
            Paczka paczka4 = new Paczka("nadawcad", 17);
            mStos.Umiesc(paczka1);
            mStos.Umiesc(paczka2);
            mStos.Umiesc(paczka3);
            mStos.Umiesc(paczka4);
            Console.WriteLine(mStos.PodajBiezacy());
            Console.WriteLine(mStos.ToString());
            Console.WriteLine(mStos.Pobierz());
            Console.WriteLine(mStos.ToString());

        }
    }
}
