using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFbyDBFirst
{
    static class TeaManagement
    {
        //all info tea

        public static void GetAllTea()
        {
            using (ShopTeaEntities db = new ShopTeaEntities())
            {
                var tea = db.Tea.ToList();
                foreach (var t in tea)
                {
                    Console.WriteLine($"Tea: {t.NameSort} (тип: {t.TypesTea.TypeTea}, {t.NumberGrams} г. Ціна: {t.Price} грн. Країна втробника: {t.Country.NameCountry} : ");
                }
            }
        }


        public static void AddTea(Tea tea)
        {
            using (ShopTeaEntities db = new ShopTeaEntities())
            {

                Tea teaIs = db.Tea.Where(t => t.NameSort == tea.NameSort && t.TypesTea.TypeTea == tea.TypesTea.TypeTea).FirstOrDefault();
                if (teaIs == null)
                {
                    db.Tea.Add(tea);
                    db.SaveChanges();
                    Console.WriteLine($"New tea added: {tea.NameSort}");
                }
                else
                {
                    Console.WriteLine("This tea is already exist!");
                }
                //if (GetTeaByName(tea.NameSort) == null)
                //{
                //    db.Tea.Add(tea);
                //    db.SaveChanges();
                //    Console.WriteLine($"New tea added: {tea.NameSort}");
                //}
                //else
                //{
                //    Console.WriteLine("This tea is already exist!");
                //}
            }
        }


        public static Tea GetTeaByName(string name)
        {
            using (ShopTeaEntities db = new ShopTeaEntities())
            {
                var tea = (from t in db.Tea
                           where t.NameSort == name
                           select t).FirstOrDefault();
                return tea;
            }
        }

        public static Tea CreateTea(Tea tea)
        {

            if (CountryManagement.GetCountryByName(tea.Country.NameCountry) == null)
            {
                CountryManagement.AddCountry(tea.Country);
            }
            if (TeaTypesManagement.GetTypeByName(tea.TypesTea.TypeTea) == null)
            {
                Console.WriteLine("Describe type tea " + tea.TypesTea.TypeTea);
                string descriptionType = Console.ReadLine();
                TeaTypesManagement.AddType(new TypesTea { TypeTea = tea.TypesTea.TypeTea, DescriptionInfo = descriptionType });

            }
            return null;
        }
    }
}
