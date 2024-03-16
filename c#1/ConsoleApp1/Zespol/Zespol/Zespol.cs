using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zespol
{
    interface IZapisywalna
    {
        void ZapiszXML(string nazwa);
    }
    public class Zespol : ICloneable, IZapisywalna
    {
        string nazwa;
        KierownikZespolu kierownik;
        List<CzlonekZespolu> czlonkowie;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public KierownikZespolu Kierownik { get => kierownik; set => kierownik = value; }
        public List<CzlonekZespolu> Czlonkowie { get => czlonkowie; set => czlonkowie = value; }

        public Zespol()
        {
            Nazwa = "???";
            Czlonkowie = new();
        }
        public Zespol(string nazwa) : this()
        {
            Nazwa = nazwa;
        }

        public Zespol(string nazwa, KierownikZespolu kierownik) : this(nazwa)
        {
            Kierownik = kierownik;
        }

        public object Clone()
        {
            Zespol zespol = new Zespol();
            zespol = (Zespol)this.MemberwiseClone();
            zespol.Czlonkowie = new List<CzlonekZespolu>();
            foreach (CzlonekZespolu czlonek in this.Czlonkowie)
                zespol.DodajCzlonkaZespolu((CzlonekZespolu)czlonek.Clone());

            zespol.Kierownik = (KierownikZespolu)this.Kierownik.Clone();
            return zespol;
        }

        public void DodajCzlonkaZespolu(CzlonekZespolu cz)
        {
            if (cz is not null)
            {
                Czlonkowie.Add(cz);
            }
        }
        public void UsunCzlonkaZespolu(CzlonekZespolu cz)
        {
            if (cz is not null)
            {
                Czlonkowie.Remove(cz);
            }
        }

        public List<CzlonekZespolu> NieaktywniCzlonkowieZespolu()
        {
            return Czlonkowie.FindAll(cz => !cz.Aktywny);
        }
        public void SortujNazwiskoImie()
        {
            Czlonkowie.Sort();
        }
        public void SortujWiek()
        {
            Czlonkowie.Sort((c1, c2) => c1.Wiek().CompareTo(c2.Wiek()));
        }
        public void SortujPESEL()
        {
            Comparison<CzlonekZespolu> cmp =
                (CzlonekZespolu c1, CzlonekZespolu c2) =>
                c1.Pesel.CompareTo(c2.Pesel);
            Czlonkowie.Sort(cmp);
        }
        public bool JestCzlonkiemZespolu(CzlonekZespolu cz)
        {
            CzlonekZespolu? czz = Czlonkowie
                .FirstOrDefault(c => c.Equals(cz));
            return czz != null;
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Zespół: {Nazwa}");
            if (Kierownik is not null)
            {
                sb.AppendLine($"Kierownik: {Kierownik}");
            }
            if (Czlonkowie.Any())
            {
                sb.AppendLine("Członkowie:");
                foreach (CzlonekZespolu cz in Czlonkowie)
                {
                    sb.AppendLine(cz.ToString());
                }
            }
            return sb.ToString();
        }

        public void ZapiszXML(string nazwa)
        {
            using StreamWriter sw = new(nazwa);
            XmlSerializer xs = new(typeof(Zespol));
            xs.Serialize(sw, this);
        }
        public static Zespol? OdczytajXML(string nazwa)
        {
            if (!File.Exists(nazwa))
            {
                return null;
            }
            using StreamReader sw = new(nazwa);
            XmlSerializer xs = new(typeof(Zespol));
            return xs.Deserialize(sw) as Zespol;
        }
    }
}
