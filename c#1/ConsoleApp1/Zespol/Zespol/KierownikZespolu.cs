using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zespol
{
    public class KierownikZespolu : Osoba, ICloneable
    {
        int doswiadczenieKierownicze;
        long telefonKontaktowy;

        public int DoswiadczenieKierownicze { get => doswiadczenieKierownicze; set => doswiadczenieKierownicze = value; }
        public long TelefonKontaktowy { get => telefonKontaktowy; set => telefonKontaktowy = value; }

        public KierownikZespolu() : base() { }

        public KierownikZespolu(string imie, string nazwisko, EnumPlec plec,
            int doswiadczenieKierownicze, long telefonKontaktowy)
            : base(imie, nazwisko, plec)
        {
            DoswiadczenieKierownicze = doswiadczenieKierownicze;
            TelefonKontaktowy = telefonKontaktowy;
        }

        public KierownikZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec,
            int doswiadczenieKierownicze, long telefonKontaktowy)
            : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            DoswiadczenieKierownicze = doswiadczenieKierownicze;
            TelefonKontaktowy = telefonKontaktowy;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{base.ToString()}, dośw. {DoswiadczenieKierownicze}, {TelefonKontaktowy:000-000-000}";
        }
    }
}
