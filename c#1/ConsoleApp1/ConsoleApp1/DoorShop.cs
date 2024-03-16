using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IDoorPromotion
    {
        public void CommunicateDoorPromotion();
    }
    public class DoorShop:IDoorPromotion
    {
        string shopName;
        DateTime openingDate;
        List<Door> assortment;

        public DoorShop(string shopName)
        {
            this.shopName = shopName;
            assortment = new List<Door>();
        }

        public bool FindDoor(string catalogueCode)
        {
            bool found = false;
            foreach (Door door in assortment)
            {
                if (door.CatalogueNumber == catalogueCode)
                {
                    found = true; break;
                }
                
            }
            return found;
               //return assortment.Any(n=>n.catalogueNumber==catalogueNumber)
        }
        public void RegisterDoor(Door door)
        {
            if(FindDoor(door.CatalogueNumber)==false) 
            {
                assortment.Add(door);
            
            }
        }

        public void RemoveDoor(string catalogueCode)
        {
            assortment.Remove(assortment.Where(n => n.CatalogueNumber == catalogueCode).ToList()[0]);

        }
        public decimal TotalDoorPrice()
        {
            return assortment.OfType<ArtdecoDoor>().Sum(n=>n.CalculateDoorPrice())+assortment.OfType<SpecialDoor>().Sum(n=>n.CalculateDoorPrice());
        }
        public List<string> FindSpecialDoors()
        {
            List<string> list = new List<string>();
            list=assortment.OfType<SpecialDoor>().Select(n=>n.CatalogueNumber).ToList();
            return list;
        }

        public List<ArtdecoDoor> FindDoorWithColor(EnumColor color)
        {
            List<ArtdecoDoor> list = new List<ArtdecoDoor>();
            list=assortment.OfType<ArtdecoDoor>().Where(n=>n.Colors.Contains(color)).ToList();
            return list;
        }

        public void CommunicateDoorPromotion()
        {
            foreach (Door door in assortment)
            {
                Random random = new Random();
                int liczba = random.Next(1, 7);
                DateTime promotionEndDate = DateTime.Now.AddDays(liczba);
                Console.WriteLine(door.ToString() + "promotion until " + promotionEndDate.ToString());
            }

        }

        public void SortAssortment()
        {
            assortment.Sort();
        }

        public override string ToString()
        {
            int liczbaART = 0;
            int liczbaSpecial = 0;
            string napis = "";
            foreach (Door door in assortment)
            {
                if (door.GetType() == typeof(ArtdecoDoor))
                    liczbaART++;
                else
                {
                    liczbaSpecial++;
                }
            }
            napis = shopName.ToString() + ": artdeco doors " + liczbaART + ", special doors " + liczbaSpecial;
            napis = napis + "\nTotal price of doors: " + TotalDoorPrice()+"\n";
            foreach(Door door in assortment)
            {
                napis= napis + "\n"+door.ToString();
            }
            return napis;
        }

    }
}

