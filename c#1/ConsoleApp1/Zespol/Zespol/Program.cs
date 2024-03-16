using Zespol;
using System;

namespace Zespol// Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            CzlonekZespolu cz1 = new("Jan",
                "Pryl", "1420/10/22", "92102201347", EnumPlec.K,
                DateTime.Today, EnumRolaWZespole.programista, true);
            CzlonekZespolu cz2 = new("Kacper",
                "Gdss", "2002/09/11", "02091141348", EnumPlec.M,
                DateTime.Today, EnumRolaWZespole.sekretarz, true);
            CzlonekZespolu cz3 = new("Teresa",
                "Lipowska", "1999/12/30", "99123089034", EnumPlec.K,
                DateTime.Today, EnumRolaWZespole.trener, false);
            CzlonekZespolu cz4 = new("Agata",
                "Zegarek", "2001/07/10", "01071062182", EnumPlec.K,
                DateTime.Today, EnumRolaWZespole.programista, true);
            CzlonekZespolu cz5 = new("Konrad",
                "Piasecki", "1995/04/24", "95042433793", EnumPlec.M,
                DateTime.Today, EnumRolaWZespole.menedżer, true);
            KierownikZespolu kier = new("Jan", "Nowak", EnumPlec.M, 10, 567098677);
            //Zespol zespol = new("Zespół IT", kier);
            //zespol.DodajCzlonkaZespolu(cz1);
            //zespol.DodajCzlonkaZespolu(cz2);
            //zespol.DodajCzlonkaZespolu(cz3);
            //zespol.DodajCzlonkaZespolu(cz4);
           // zespol.DodajCzlonkaZespolu(cz5);
            //Console.WriteLine(zespol);
            //Console.WriteLine("Nieaktywni członkowie zespołu");
            //List<CzlonekZespolu> nieaktywni = zespol.NieaktywniCzlonkowieZespolu();
           // nieaktywni.ForEach(cz => Console.WriteLine(cz));
           // zespol.ZapiszXML("C:\\Users\\kacpr\\source\\repos\\kolosc\\ZespolDowna\\zespoll.xml");

            KierownikZespolu kier1= new("szymon", "pupkiewicz", EnumPlec.M, 10, 567098677);
            Zespol zespol2 = new("zespol downa", kier1);
            zespol2.DodajCzlonkaZespolu(cz1);
            zespol2.DodajCzlonkaZespolu(cz2);
            zespol2.DodajCzlonkaZespolu(cz3);
            zespol2.DodajCzlonkaZespolu(cz4);
            zespol2.DodajCzlonkaZespolu(cz5);
            Console.WriteLine(zespol2);
            zespol2.ZapiszXML("C:\\Users\\kacpr\\source\\repos\\kolosc\\ZespolDowna\\zespoll.xml");
        }
    }
}