using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum EnumColor
    {
        white,black,mahogany,ivory,ebony,pine
    }
    public class ArtdecoDoor:Door
    {
        List<EnumColor> colors;
        static decimal colorPrice;

        public List<EnumColor> Colors { get => colors; private set => colors = value; }
        public static decimal ColorPrice { get => colorPrice; set => colorPrice = value; }

        static ArtdecoDoor()
        {
            ColorPrice = 59.99m;
        }
        public ArtdecoDoor(string producer) : base(producer)
        {
            base.Producer = producer;
            Colors = new List<EnumColor>() { EnumColor.pine };
        }
        public ArtdecoDoor(string producer,decimal doorPrice,EnumColor color) : base(producer, doorPrice)
        {
            Colors = new List<EnumColor>() { color };
        }
        public override decimal CalculateDoorPrice()
        {
            return DoorPrice + ColorPrice;

        }
        public void AddColor(EnumColor color)
        {
            if (colors.Count < 3 && !colors.Contains(color))
            {
                colors.Add(color);
            }
        }
        public override string ToString()
        {
            string string1 = "";
            foreach(var color in colors)
            {
                string1=string1+ ","+color.ToString();
            }
            return base.ToString() + CalculateDoorPrice() + "zl - (" + string1 + ")";
        }

    }
}
