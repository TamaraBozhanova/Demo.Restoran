using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Demo.Restoran

{
    public class ProductContext: DbContext 
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

     public ProductContext():
            base("ProductDB")
        { }

       


    }
}
