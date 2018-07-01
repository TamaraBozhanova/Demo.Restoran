using System.Data.Entity;

namespace Restaurant.EF
{
    public class RestaurantDbInitializer : DropCreateDatabaseAlways<RestaurantDbContext>
    {
        protected override void Seed(RestaurantDbContext context)
        {
        }
    }
}