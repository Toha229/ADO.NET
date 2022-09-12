using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFbyDBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Country country = new Country { NameCountry = "Ukraine" };
            Console.WriteLine("Before add: ");
            CountryManagement.GetAllCountry();
            CountryManagement.AddCountry(country);
            Console.WriteLine("After add: ");
            CountryManagement.GetAllCountry();
            Console.WriteLine("=================INFO BY TEA================");
            TeaManagement.GetAllTea();
            //реалізувати додавання чаю з перевіркою на існування значень в підпорядкованих таблицях
            var tea = new Tea
            {
                NameSort = "Три слони",
                Country = new Country { NameCountry = "USA" },
                TypesTea = new TypesTea { TypeTea = "Grya" },
                DescriptionInfo = "Info add.. ",
                NumberGrams = Convert.ToDecimal(237.45),
                Price =Convert.ToDecimal( 125.50)
            };
            TeaManagement.AddTea(tea);
            Console.WriteLine("=================After add tea================");
            TeaManagement.GetAllTea();
            Console.ReadKey();
        }
    }
}
