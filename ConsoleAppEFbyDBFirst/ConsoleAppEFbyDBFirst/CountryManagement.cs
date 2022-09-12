using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFbyDBFirst
{
    static class CountryManagement
    {
        //add country into table Country
        public static void AddCountry(Country country)
        {
            using (ShopTeaEntities db = new ShopTeaEntities())
            {
                if (GetCountryByName(country.NameCountry) == null)
                {
                    db.Country.Add(country);
                    db.SaveChanges();
                    Console.WriteLine("New country added: " + country.NameCountry);
                }
                else
                {
                    Console.WriteLine("Country is exist!!!");
                }
            }

        }


        //read country
        public static void GetAllCountry()
        {
            using (ShopTeaEntities db = new ShopTeaEntities())
            {
                var countries = db.Country.ToList();
                foreach (var c in countries)
                {
                    Console.WriteLine(c.NameCountry);
                }
            }
        }

        public static Country GetCountryByName(string cname)
        {

            using (ShopTeaEntities db = new ShopTeaEntities())
            {
                //First  або знаходить або викидає виключенння
                //FirstOrDefault або знаходить або null
                var country = db.Country.Where(c => c.NameCountry == cname).FirstOrDefault();
                return country;
            }

        }

        //Single() SingleOrDefault()
        //Повернути країну за вказаним id використовуючи синтаксис запитів
        public static Country GetCountryById(int id)
        {

            using (ShopTeaEntities db = new ShopTeaEntities())
            {

                //var country = (from c in db.Country
                //               where c.Id==id
                //               select c).SingleOrDefault();

                var country = db.Country.Find(id); //if not find => null
                return country;
            }

        }

        //deleting from country
        public static void DeleteCountry(Country country)
        {
            using (ShopTeaEntities db = new ShopTeaEntities())
            {
                if (GetCountryByName(country.NameCountry) != null)
                {
                    db.Country.Remove(country);
                    db.SaveChanges();
                    Console.WriteLine("deleted: " + country.NameCountry);
                }
                else
                {
                    Console.WriteLine("Country is not exist!!!");
                }
            }
        }
    }
}
