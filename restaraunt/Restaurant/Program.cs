using Restaurant.EF;
using Restaurant.EF.Entities;
using Restaurant.DAL;
using System;
using System.Linq;

namespace Restaurant
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            RestaurantDataStore ctx = new RestaurantDataStore("DBConnection");

            Product product = new Product { Name = "Ogurec", Price = 40.0M, Unit = "kg" };
            ctx.Products.Create(product);

            Console.ReadKey();
        }
    }
}