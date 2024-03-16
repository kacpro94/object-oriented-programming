using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zespol
{
    //Klasa Osoba czyli "schemat" do tworzenia konkretnych osób (instancji klasy osoba).
    public enum EnumPlec { K, M }
    public abstract class Osoba : IEquatable<Osoba>
    {
        string imie;
        string nazwisko;
        string miasto;
        DateTime dataUrodzenia;
        string pesel;
        EnumPlec plec;

        #region Properties
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Miasto { get => miasto; set => miasto = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public string Pesel
        {
            get => pesel;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{11}$"))
                {
                    throw new ArgumentException("Niepoprawny numer PESEL!");
                }
                pesel = value;
            }
        }

        public EnumPlec Plec { get => plec; set => plec = value; }
        #endregion Properties
        #region Konstruktory
        public Osoba() // konstruktor domyślny
        {
            Imie = string.Empty;
            Nazwisko = string.Empty;
            DataUrodzenia = DateTime.Today;
            Pesel = new('0', 11);
        }
        public Osoba(string imie, string nazwisko, EnumPlec plec)
            : this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
            this.Plec = plec;
        }

        public Osoba(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec)
           : this(imie, nazwisko, plec)
        {
            if (DateTime.TryParseExact(dataUrodzenia, new[] { "dd-MM-yyyy", "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy",
                "dd-MMM-yy"}, null, DateTimeStyles.None, out DateTime date))
            { DataUrodzenia = date; }
            Pesel = pesel;
        }
        #endregion
        public int Wiek()
        {
            return (int)(DateTime.Now - DataUrodzenia).TotalDays / 365;
        }
        public override string ToString()
        {
            return $"{Imie} {Nazwisko.ToUpper()} ({Plec}), ur. {DataUrodzenia:yyyy/MM/dd} (PESEL: {Pesel})";
        }

        public bool Equals(Osoba? other)
        {
            if (other == null) { return false; }
            return Pesel.Equals(other.Pesel);
        }
    }

}
