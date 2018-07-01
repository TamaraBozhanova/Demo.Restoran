using System;
using Restaurant.EF;
using Restaurant.EF.Entities;
using Restaurant.DAL.Repositories;

namespace Restaurant.DAL
{
    public class RestaurantDataStore : IDisposable
    {
        private RestaurantDbContext _ctx;

        public Repository<Product> Products { get; set; }
        public Repository<Ingredient> Ingredients { get; set; }
        public Repository<Dish> Dishes { get; set; }
        public Repository<Order> Orders { get; set; }
        public Repository<Storage> Storage { get; set; }

        public RestaurantDataStore(string connectionString)
        {
            _ctx = new RestaurantDbContext(connectionString);

            Products = new Repository<Product>(_ctx);
            Ingredients = new Repository<Ingredient>(_ctx);
            Dishes = new Repository<Dish>(_ctx);
            Orders = new Repository<Order>(_ctx);
            Storage = new Repository<Storage>(_ctx);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
