using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurierdpd
{
    public interface IMagazynuje
    {
        public void Umiesc(Paczka t);
        public Paczka Pobierz();
        public void Wyczysc();
            public int PodajIlosc();
        public Paczka PodajBiezacy();
    }
    public class PaczkaPolecona:Paczka
    {
        static double oplataDodatkowa;

        static PaczkaPolecona()
        {
            oplataDodatkowa = 10.0;
        }

        public PaczkaPolecona() : base() { }

        public PaczkaPolecona(string nadawca, int rozmiar):base(nadawca, rozmiar)
        {

        }

        public override decimal KosztWysylki()
        {
            return base.KosztWysylki() + (decimal)oplataDodatkowa; ;
        }

        public override string ToString()
        {
            return base.ToString() + " Oplata dodatkkowa: " + oplataDodatkowa; 
        }
    }
}
