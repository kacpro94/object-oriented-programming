using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolosF
{
    public class ZgloszenieOczekujace
    {
        private Queue<Zgloszenie> kolejkaZgloszen;

        public ZgloszenieOczekujace()
        {
            KolejkaZgloszen = new Queue<Zgloszenie>();
        }
        public ZgloszenieOczekujace(Queue<Zgloszenie> kolejkaZgloszen)
        {
            this.KolejkaZgloszen = kolejkaZgloszen;
        }

        public Queue<Zgloszenie> KolejkaZgloszen { get => kolejkaZgloszen; set => kolejkaZgloszen = value; }

        public void PrzyjmijZgloszenie(Zgloszenie zgloszenie)
        {
            kolejkaZgloszen.Enqueue(zgloszenie);
            Console.WriteLine("czas realizacji zgloszenia: " + zgloszenie.CzasRealizacji); ;
        }
        public void RealizujZgloszenie()
        {
            Console.WriteLine("Realizuje zgloszenie: "+kolejkaZgloszen.Dequeue().OpisSprawy);
        }
        public int PodajCzas()
        {
            return kolejkaZgloszen.Sum(n => n.CzasRealizacji);
        }

        public override string ToString()
        {
            string napis = "";
            foreach(Zgloszenie zgloszenie in kolejkaZgloszen)
            {
                napis+= zgloszenie.ToString() + "\n";
            }
            return napis;
        }
    }
}
