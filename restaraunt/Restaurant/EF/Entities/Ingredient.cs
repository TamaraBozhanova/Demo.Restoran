using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.EF.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required, Index("IX_DishAndProduct", 1, IsUnique = true)]
        public virtual Dish Dish { get; set; }

        [Required, Index("IX_DishAndProduct", 2, IsUnique = true)]
        public virtual Product Product { get; set; }

        [Required]
        public float Quantity { get; set; }
    }
}