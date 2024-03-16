using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurierdpd
{
    public class MagazynLIFO:IMagazynuje
    {
        string nazwa;
        int iloscPaczek;
        Stack<Paczka> stosPaczek;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int IloscPaczek { get => iloscPaczek; set => iloscPaczek = value; }
        public Stack<Paczka> StosPaczek { get => stosPaczek; set => stosPaczek = value; }

        public MagazynLIFO() { }

        public MagazynLIFO(string nazwa, int iloscPaczek)
        {
            Nazwa = nazwa;
            IloscPaczek = iloscPaczek;
            StosPaczek= new Stack<Paczka>();
            
        }

        public void Umiesc(Paczka t)
        {
            StosPaczek.Push(t);
        }
        public Paczka Pobierz()
        {
            return StosPaczek.Pop();
        }
        public void Wyczysc()
        {
            StosPaczek.Clear();
        }
        public int PodajIlosc()
        {
            return StosPaczek.Count();
        }
        public Paczka PodajBiezacy()
        {
            return StosPaczek.Peek();
        }

        public override string ToString()
        {
            string napis = "";
            napis += Nazwa + " Ilosc paczek max: " + iloscPaczek+"\n";
            foreach(Paczka paczka in StosPaczek)
            {
                napis += paczka.ToString()+"\n";
            }
            return napis;

        }
    }
}
