using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.EF.Entities
{
    public class Dish
    {
        public int Id { get; set; }

        [Required, MaxLength(30), Index(IsUnique = true)]
        public string Name { get; set; }

        [Required, MaxLength(1000)]
        public string Recipe { get; set; }
        
        public virtual List<Ingredient> Ingredients { get; set; }

        public Dish()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}