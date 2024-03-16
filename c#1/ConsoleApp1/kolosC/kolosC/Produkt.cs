using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace kolosC
{
    public class Produkt:IComparable<Produkt>
    {
        string kodProduktu;
        public Dostawca producent;
        public decimal cena;
        List<decimal> faktury;
        static decimal podatekVAT;

        public string KodProduktu
        {
            get => kodProduktu;
            set
            {
                string format = @"^\d{8}$";
                if(Regex.IsMatch(value,format))
                {
                    kodProduktu = value;
                }
                else
                {
                    throw new FormatException("zly format kodu produktu");
                }

            }
        }
        public List<decimal> Faktury { get => faktury; set => faktury = value; }

        static Produkt()
        {
            podatekVAT = 0.07m;
        }
        public Produkt(string kodProduktu, Dostawca producent, decimal cena)
        {
            this.KodProduktu = kodProduktu;
            this.producent = producent;
            this.cena = cena;
            Faktury = new List<decimal>();
        }

        public virtual decimal WartoscFaktury(float ilosc)
        {
            return cena * (decimal)ilosc * (1 + podatekVAT);
        }
        public void SprzedazDetaliczna(float ilosc)
        {
            faktury.Add(WartoscFaktury(ilosc));
        }

        public int CompareTo(Produkt? other)
        {
            if (this.faktury.Sum(n => n) > other.faktury.Sum(n => n))
            {
                return -1;
            }
            else if (this.faktury.Sum(n => n) == other.faktury.Sum(n => n))
            {
                if (this.kodProduktu.CompareTo(other.kodProduktu) > 0)
                {
                    return 1;
                }
                else if (this.kodProduktu.CompareTo(other.kodProduktu) == 0)
                {


                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 1;
            }
        }
        public override string ToString()
        {
           // return producent.ToString()+", [KOD:"+kodProduktu.ToString()+"] ("+faktury.Sum().ToString("0.00")+" zł)";
            return $"{producent.ToString()}, [KOD:{kodProduktu.ToString()}] ( {faktury.Sum().ToString("0.00")} zł)";
        }


    }
}
