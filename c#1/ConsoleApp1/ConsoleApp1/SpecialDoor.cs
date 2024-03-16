using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum EnumExtraFeature
    {
        alarm=100,peephole=90,mute=150,reinforcment=200
    }
    public class SpecialDoor:Door
    {
        EnumExtraFeature extraFeature;

        public SpecialDoor(EnumExtraFeature extraFeature,string producer,decimal doorPrice) : base(producer,doorPrice)
        {
            this.extraFeature = extraFeature;
        }
        public SpecialDoor(EnumExtraFeature extraFeature, string producer) : base(producer)
        {
            this.extraFeature = extraFeature;
        }


        public override decimal CalculateDoorPrice()
        {
            return base.DoorPrice + (decimal)extraFeature;
        }

        public override string ToString()
        {
            return base.ToString() +","+CalculateDoorPrice()+ "zl ["+extraFeature.ToString()+"]";
        }


    }
}
