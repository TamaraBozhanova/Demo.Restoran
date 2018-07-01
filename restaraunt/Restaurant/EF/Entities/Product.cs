using System.ComponentModel.DataAnnotations;

namespace Restaurant.EF.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required, MaxLength(10)]
        public string Unit { get; set; }
    }
}