using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Demo.Restoran
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProductContext db = new ProductContext())
            {
                var products = db.Products;
                foreach(Product p in products)
                {
                    Console.WriteLine("{0}.{1}", p.Id, p.Name);
                }
            }
        }
    }
}
