using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace kolosD
{
    public class Abonent
    {
        string imie;
        string nazwisko;
        string pesel;

        public string Pesel { get => pesel;
            set
            {
                string format = @"^\d{11}$";
                if (Regex.IsMatch(value, format)){
                    pesel = value;
                }
                else
                {
                    throw new FormatException("zly format peselu");
                }
            } 
        }

        public Abonent(string imie, string nazwisko, string pesel)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            Pesel = pesel;
           
        }

        public override string ToString()
        {
            return imie+" "+nazwisko+"[Pesel:"+Pesel+"]";
        }
    }
}
