using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zespol
{
    public enum EnumRolaWZespole
    {
        programista, sekretarz, menedżer, trener
    }
    public class CzlonekZespolu : Osoba, IComparable<CzlonekZespolu>,
        ICloneable
    {
        DateTime dataWstapienia;
        EnumRolaWZespole rolaWZespole;
        bool aktywny;

        public bool Aktywny { get => aktywny; set => aktywny = value; }
        public DateTime DataWstapienia { get => dataWstapienia; set => dataWstapienia = value; }
        public EnumRolaWZespole RolaWZespole { get => rolaWZespole; set => rolaWZespole = value; }

        public CzlonekZespolu() : base() { }

        public CzlonekZespolu(string imie, string nazwisko, EnumPlec plec,
            DateTime dataWstapienia, EnumRolaWZespole rolaWZespole, bool aktywny)
            : base(imie, nazwisko, plec)
        {
            DataWstapienia = dataWstapienia;
            RolaWZespole = rolaWZespole;
            Aktywny = aktywny;
        }

        public CzlonekZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec,
            DateTime dataWstapienia, EnumRolaWZespole rolaWZespole, bool aktywny)
            : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            DataWstapienia = dataWstapienia;
            RolaWZespole = rolaWZespole;
            Aktywny = aktywny;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {RolaWZespole} {(aktywny ? ", (A)" : "")}";
        }

        public int CompareTo(CzlonekZespolu? other)
        {
            if (other == null) { return -1; }
            int cmp = Nazwisko.CompareTo(other.Nazwisko);
            if (cmp != 0) { return cmp; }
            return Imie.CompareTo(other.Imie);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
