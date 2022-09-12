using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFbyDBFirst
{
    static class TeaTypesManagement
    {
        public static TypesTea GetTypeByName(string tname)
        {
            using (ShopTeaEntities db = new ShopTeaEntities())
            {
                var type = db.TypesTea.Where(t => t.TypeTea == tname).SingleOrDefault();
                return type;
            }
        }

        public static void AddType(TypesTea type)
        {
            using (ShopTeaEntities db = new ShopTeaEntities())
            {
                if (GetTypeByName(type.TypeTea) == null)
                {
                    db.TypesTea.Add(type);
                    db.SaveChanges();
                }
            }

        }
    }
}
