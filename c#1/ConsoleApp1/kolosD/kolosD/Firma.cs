using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace kolosD
{
    public class Firma
    {
        string nazwaFirmy;
        List<Telefon> telefonyFirmowe;

        public Firma(string nazwaFirmy)
        {
            this.NazwaFirmy = nazwaFirmy;
            telefonyFirmowe = new List<Telefon>();
        }

        public string NazwaFirmy
        {
            get => nazwaFirmy;
            set
            {
                string format = @"^[A-Z][a-zA-Z]*$";
                if(Regex.IsMatch(value, format))
                {
                    nazwaFirmy = value;
                }
                else
                {
                   
                    throw new FormatException("nazwa firmy musi byc z duzej");
                }
            }
        }

        public void DodajTelefon(Telefon telefon)
        {
            telefonyFirmowe.Add(telefon);
        }

        public Telefon UsunTelefon(string numer)
        {
            if (telefonyFirmowe.Any(n => n.NumerTelefonu == numer)){
                Telefon telefon1 = (Telefon)telefonyFirmowe.Where(n => n.NumerTelefonu == numer);
                telefonyFirmowe.Remove(telefon1);
                return telefon1;
            }
            else
            {
                return null;
            }
        }
        public List<TelefonKomorkowy> Wyszukaj(EnumOperatorSieci operatorSieci)
        {
            List<TelefonKomorkowy> telefony= new List<TelefonKomorkowy> ();
            telefony= telefonyFirmowe.OfType<TelefonKomorkowy>().ToList();
            return telefony.Where(n=>n.Equals(operatorSieci)).ToList();
        }

        public decimal SumaBillingow()
        {
            return telefonyFirmowe.Sum(n => n.Billing.Sum());
        }

        public void Sortuj()
        {
            
        }

        public override string ToString()
        {
            string napis=NazwaFirmy.ToString()+"\n";
            foreach(Telefon telefon in telefonyFirmowe)
            {
                napis+=telefon.ToString()+"\n";
            }
            return napis;
        }
    }
}
