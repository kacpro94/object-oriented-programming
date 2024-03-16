using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace kolosD
{
    public class BlednyNumerTefelonuException() : Exception
    {
        public BlednyNumerTefelonuException(string message):this()
        {

        }

    }
    public interface IWydarzenieTygodniowe
    {
        public void Przypomnienie(DateTime data, string komunikat);
    }
    public abstract class Telefon:IWydarzenieTygodniowe,IComparable<Telefon> 
    {
        string numerTelefonu;
        Abonent wlasciciel;
        List<decimal> billing;
        static decimal oplataPodstawowa;

        public string NumerTelefonu
        {
            get => numerTelefonu;
            set
            {
                string format = @"^\d{9}$";
                if (Regex.IsMatch(value, format))
                {
                    numerTelefonu = value;
                }
                else
                {
                    throw new BlednyNumerTefelonuException("bledny numer");
                }
            }
        }

        public List<decimal> Billing { get => billing; set => billing = value; }

        static Telefon()
        {
            oplataPodstawowa = 0.1m;
        }
        public Telefon(string numerTelefonu, Abonent wlasciciel)
        {
            this.NumerTelefonu = numerTelefonu;
            this.wlasciciel = wlasciciel;
            Billing = new List<decimal>();
        }

        public virtual decimal OplataZaRozmowe(float minuty)
        {
            return (decimal)minuty * oplataPodstawowa;
        }
        public void RejstracjaRozmowy(float minuty)
        {
            Billing.Add(OplataZaRozmowe(minuty));
        }
        public void Przypomnienie(DateTime data,string komunikat)
        {
            if(data.DayOfWeek==DateTime.Now.DayOfWeek) {
                Console.WriteLine(data.ToString()+": "+komunikat);
            }
        }

        public int CompareTo(Telefon? other)
        {
            if (this.Billing.Sum(n => n) > other.Billing.Sum(n => n))
            {
                return -1;
            }
            else if(this.Billing.Sum(n => n) == other.Billing.Sum(n => n))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public override string ToString()
        {
           
            return wlasciciel.ToString()+", tel.:" + numerTelefonu.ToString() +"("+Billing.Sum(n => n) +"zł )";
            // numerTelefonu.ToString("000-000-000")

        }
    }
}
