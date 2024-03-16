using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolosF
{
    public class ZgloszenieRealizowane:ZgloszenieOczekujace
    {
        static int limitZgloszen = 5;

        public ZgloszenieRealizowane():base()
        {

        }
        public ZgloszenieRealizowane(Queue<Zgloszenie> zgloszenies) : base(zgloszenies) {

        }

        public bool MoznaPrzyjac()
        {
            if (base.KolejkaZgloszen.Count < 5)
            {
                return true;
            }
            else { return false; }
        }
    }
}
