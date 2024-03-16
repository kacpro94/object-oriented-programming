using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class WrongDoorException : Exception
    {
        public WrongDoorException(string message) : base(message) { } 
    }


    public abstract class Door: IComparable<Door>
    {
        string producer;
        decimal doorPrice;
        string catalogueNumber;
        static int counter;

        public string Producer
        {
            get => producer;
            set
            {
                Regex regex = new Regex(@"^[A-Z][a-zA-Z]{5,}$");
                if (!regex.IsMatch(value))
                {
                    throw new WrongDoorException("Wrong format!");
                }
                producer = value;
            }
        }

        public decimal DoorPrice {
            get => doorPrice;
            set
            {
                if (value < 500.99m || value > 2000.99m)
                {
                    throw new WrongDoorException("Wrong price");
                }
                doorPrice = value;
            }
        }

        public string CatalogueNumber { get => catalogueNumber; private set => catalogueNumber = value; }

        static Door()
        {
            counter = 100;
        }

        public Door(string producer)
        {
            
            this.Producer = producer;
            this.DoorPrice = (decimal)500.99;
            this.CatalogueNumber = producer.ToUpper() + "-" + counter.ToString("000000000");
            counter++;


        }

        public Door(string producer,decimal doorPrice) : this(producer)
        {
            
            this.DoorPrice = doorPrice;
            
            
        }
        public abstract decimal CalculateDoorPrice();
       
        public int CompareTo(Door other)
        {
            if(other == null) { return 0; }
            return producer.CompareTo(other.producer);
        }
        public override string ToString()
        {
            return CatalogueNumber + ",";
        }


    }

    class Progeram
    {
        public static void Main(string[] args)
        {
            ArtdecoDoor drzwi1 = new ArtdecoDoor("Drzwix", 600.00m, EnumColor.black);
            ArtdecoDoor drzwi2 = new ArtdecoDoor("POPPOx");
            ArtdecoDoor drzwi3 = new ArtdecoDoor("YUYUYz", 602.00m, EnumColor.black);
            drzwi2.AddColor(EnumColor.ivory);
            drzwi2.AddColor(EnumColor.ebony);
            drzwi2.AddColor(EnumColor.white);
            Console.WriteLine(drzwi2.ToString());

            SpecialDoor drzwi4 = new SpecialDoor(EnumExtraFeature.peephole, "POTOPP",822.99m);
            SpecialDoor drzwi5 = new SpecialDoor(EnumExtraFeature.alarm, "POTOPL");
            Console.WriteLine(drzwi5.ToString());

            SpecialDoor drzwi6 = new SpecialDoor(EnumExtraFeature.reinforcment, "TTTTzz");
              

            DoorShop sklep = new DoorShop("GOWNOO");
            sklep.RegisterDoor(drzwi1);
            sklep.RegisterDoor(drzwi2);
            sklep.RegisterDoor(drzwi3);
            sklep.RegisterDoor(drzwi4);
            sklep.RegisterDoor(drzwi5);
            sklep.RegisterDoor(drzwi6);
            Console.WriteLine(sklep.ToString());
            sklep.SortAssortment();
            Console.WriteLine(sklep.ToString());

            //sklep.CommunicateDoorPromotion();

        }
      
    }
}
