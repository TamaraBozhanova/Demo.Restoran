using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.EF.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public virtual Dish Dish { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Order()
        {
            CreatedAt = DateTime.Now;
        }
    }
}