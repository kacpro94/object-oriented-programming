using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurierdpd
{
    public class Paczka
    {
        static int _aktualnyNumer;
        static float _oplataZaKg;

        string _nadawca;
        int _rozmiar;
        string _numerPaczki = "P/" + _aktualnyNumer + "/" + DateTime.Now.ToString("yyyy");

        public string Nadawca { get => _nadawca; set => _nadawca = value; }
        public int Rozmiar { get => _rozmiar; set => _rozmiar = value; }
        public string NumerPaczki { get => _numerPaczki; private set => _numerPaczki = value; }

        static Paczka()
        {
            _aktualnyNumer = 100;
            _oplataZaKg = 5.0f;
        }

        public Paczka()
        {
            _aktualnyNumer++;
        }
        public Paczka(string nadawca, int rozmiar):this() 
        {
            Nadawca = nadawca;
            Rozmiar = rozmiar;
           
            
        }

        public override string ToString()
        {
            return $"{NumerPaczki}  {Nadawca} {Rozmiar}";
        }

        public virtual decimal KosztWysylki()
        {
            return (decimal)Rozmiar * (decimal)_oplataZaKg;
        }


    }
}
