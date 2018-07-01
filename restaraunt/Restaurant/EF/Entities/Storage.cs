using System.ComponentModel.DataAnnotations;

namespace Restaurant.EF.Entities
{
    public class Storage
    {
        public int Id { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        [Required]
        public float Quantity { get; set; }
    }
}
