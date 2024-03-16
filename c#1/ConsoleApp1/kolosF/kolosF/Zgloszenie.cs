using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolosF
{
    public class Zgloszenie
    {
        string imie;
        string nazwisko;
        string opisSprawy;
        int czasRealizacji;
        bool przyjeto;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string OpisSprawy { get => opisSprawy; set => opisSprawy = value; }
        public int CzasRealizacji { get => czasRealizacji; set => czasRealizacji = value; }
        public bool Przyjeto { get => przyjeto; set => przyjeto = value; }

        public Zgloszenie() {
            imie= string.Empty;
            nazwisko= string.Empty;
            opisSprawy= string.Empty;
            czasRealizacji= 0;
            przyjeto= true;
        }

        public Zgloszenie(string imie, string nazwisko, string opisSprawy, int czasRealizacji, bool przyjeto)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            OpisSprawy = opisSprawy;
            CzasRealizacji = czasRealizacji;
            Przyjeto = przyjeto;
           
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}, przyjęto {Przyjeto.ToString()}, przewidywany czas realizacji: {czasRealizacji} min.";    
        }
    }
}
