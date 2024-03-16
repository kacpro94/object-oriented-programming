using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace kolosC
{
    public interface ISprzedajacy
    {
        public void DodajProdukt(Produkt produkt);
        public void UsunProdukt(EnumDostawcy dostawca);
        public decimal SumaSprzedazy();
        public List<ProduktOnline> WyszukajProduty();

    }
    public class Sprzedawca:ISprzedajacy
    {
        string nazwaSprzedawcy;
        List<Produkt> listaProduktow;

        public Sprzedawca(string nazwaSprzedawcy) {
            this.NazwaSprzedawcy = nazwaSprzedawcy;
            listaProduktow = new List<Produkt>();
        }

        public string NazwaSprzedawcy
        {
            get => nazwaSprzedawcy;
            set
            {
                string format = @"^[A-Z]*$";
                if (Regex.IsMatch(value, format))
                {
                    nazwaSprzedawcy = value;
                }
                else
                {
                    throw new FormatException("nazwa sprzedawcy z duzych");

                }
            }
        }
        public void DodajProdukt(Produkt produkt)
        {
            listaProduktow.Add(produkt);
        }
        public void UsunProdukt(EnumDostawcy dostawca)
        {
            
            List<Produkt> listaProduktowUsun=listaProduktow.Where(n => n.producent.Equals(dostawca)).ToList();
            foreach(Produkt produkt in listaProduktowUsun)
            {
                listaProduktow.Remove(produkt);
            }
        }
        public decimal SumaSprzedazy()
        {
            return listaProduktow.Sum(n=>n.cena);
        }
        public List<ProduktOnline> WyszukajProduty()
        {
            return listaProduktow.OfType<ProduktOnline>().ToList().Where(n => n.dostepOnline).ToList();
        }
        public void Sortuj()
        {
            listaProduktow.Sort((x,y)=>x.cena.CompareTo(y.cena));
        }

        public override string ToString()
        {
            decimal suma = 0;
            
            string napis = "";
            napis = nazwaSprzedawcy+"\n";
            foreach(Produkt produkt in listaProduktow)
            {
                suma += produkt.Faktury.Sum();
                napis += produkt.ToString()+"\n";
            }
            return napis+"\n"+suma;
        }

        public void ZapiszXML(string nazwa)
        {
            using StreamWriter sw= new StreamWriter(nazwa);
            XmlSerializer xs= new XmlSerializer(typeof(Sprzedawca));
            xs.Serialize(sw, this);
        }

        public static Sprzedawca? OdczytXml(string nazwa)
        {
            if (!File.Exists(nazwa))
            {
                return null;
            }
            using StreamReader sw = new(nazwa);
            XmlSerializer xs = new(typeof(Sprzedawca));
            return xs.Deserialize(sw) as Sprzedawca;
        }

    }

    
}
