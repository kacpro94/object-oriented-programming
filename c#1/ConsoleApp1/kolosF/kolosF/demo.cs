using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolosF
{
    public class demo
    {
        public static void Main(string[] args)
        {
            try
            {
                Zgloszenie zgloszenie1 = new Zgloszenie("QQQ", "cccc", "oooo", 9, true);
                Zgloszenie zgloszenie3 = new Zgloszenie("szym", "pun", "mmmm", 10, false);
                Zgloszenie zgloszenie5 = new Zgloszenie("szydsdm", "pusdan", "PPPPP", 85, true);
                Zgloszenie zgloszenie6 = new Zgloszenie("szymsdsd", "pxxxxxun", "LLLLLLLL", 90, false);
                Zgloszenie zgloszenie7 = new Zgloszenie("szssym", "punss", "KKKKKK", 170, true);
                //Console.WriteLine(zgloszenie1.ToString());
                ZgloszenieOczekujace zgloszenie2 = new ZgloszenieOczekujace();
                zgloszenie2.PrzyjmijZgloszenie(zgloszenie1);
                zgloszenie2.PrzyjmijZgloszenie(zgloszenie3);
                ZgloszenieRealizowane zgloszenie4 = new ZgloszenieRealizowane();
                zgloszenie4.PrzyjmijZgloszenie(zgloszenie1);
                zgloszenie4.PrzyjmijZgloszenie(zgloszenie3);
                zgloszenie4.PrzyjmijZgloszenie(zgloszenie5);
                zgloszenie4.PrzyjmijZgloszenie(zgloszenie6);
                zgloszenie4.PrzyjmijZgloszenie(zgloszenie7);
                //Console.WriteLine(zgloszenie4.MoznaPrzyjac().ToString());
                //Console.WriteLine(zgloszenie2.ToString());
                CallCenter call = new CallCenter("kkk", zgloszenie4, zgloszenie2);
                Console.WriteLine(call.ToString());
                call.ZapisJSON("kkk");
                call.RealizujZgloszenie();
                call.RealizujZgloszenie();
                call.RealizujZgloszenie();
                call.RealizujZgloszenie();
                call.RealizujZgloszenie();
                call.RealizujZgloszenie();


                CallCenter call1 = CallCenter.OdczytJson("kkk");
                Console.WriteLine(call1.ToString());
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
