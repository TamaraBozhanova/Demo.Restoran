using System.Data.Entity;
using Restaurant.EF.Entities;

namespace Restaurant.EF
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public RestaurantDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer(new RestaurantDbInitializer());
        }
    }
}