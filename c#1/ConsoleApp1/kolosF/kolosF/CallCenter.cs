using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace kolosF
{
    public class PustaKolejkaException() : Exception
    {
        public PustaKolejkaException(string message):this()
        {
            
        }
    }
    public class CallCenter
    {
        string nazwa;
        ZgloszenieRealizowane zgloszenieRealizowane;
        ZgloszenieOczekujace zgloszenieOczekujace;

        public CallCenter(string nazwa, ZgloszenieRealizowane zgloszenieRealizowane, ZgloszenieOczekujace zgloszenieOczekujace)
        {
            this.nazwa = nazwa;
            this.zgloszenieRealizowane = zgloszenieRealizowane;
            this.zgloszenieOczekujace = zgloszenieOczekujace;
        }

        public void PrzyjmijZgloszenie(Zgloszenie zgloszenie)
        {
            if (zgloszenieRealizowane.MoznaPrzyjac())
            {
                zgloszenieRealizowane.PrzyjmijZgloszenie(zgloszenie);
            }
            else
            {
                zgloszenieOczekujace.PrzyjmijZgloszenie(zgloszenie);
            }
        }

        public void RealizujZgloszenie()
        {
            if (zgloszenieRealizowane.KolejkaZgloszen.Count == 0 && zgloszenieOczekujace.KolejkaZgloszen.Count == 0)
            {
                throw new PustaKolejkaException("brak zgloszen");
            }
            else
            {
                if (zgloszenieOczekujace.KolejkaZgloszen.Count > 0)
                {
                    zgloszenieRealizowane.RealizujZgloszenie();
                    zgloszenieRealizowane.PrzyjmijZgloszenie(zgloszenieOczekujace.KolejkaZgloszen.Dequeue());
                }
                else
                {
                    zgloszenieRealizowane.RealizujZgloszenie();
                }
            }
        }
        public override string ToString()
        {
            string napis = "\n";
            napis += "Kolejka zgloszen w realizacji: \n\n";
            foreach(Zgloszenie zgloszenie in zgloszenieRealizowane.KolejkaZgloszen)
            {
                napis += zgloszenie.ToString() + "\n";
            }
            napis += "\n\nkolejka zgloszen oczekujących:\n\n ";
            foreach(Zgloszenie zgloszenie in zgloszenieOczekujace.KolejkaZgloszen)
            {
                napis += zgloszenie.ToString() + "\n";
            }

            return napis;   
        }

        public void ZapisJSON(string nazwaPliku)
        {
            string jsonstr=JsonSerializer.Serialize(this,typeof(CallCenter));
            File.WriteAllText(nazwaPliku,jsonstr);
        }
        public static CallCenter? OdczytJson(string nazwaPliku)
        {
            if(!File.Exists(nazwaPliku)) return null;
            string jsonstr=File.ReadAllText(nazwaPliku);
            return (CallCenter)JsonSerializer.Deserialize(jsonstr,typeof(CallCenter));
        }
    }
}
