using System.ComponentModel.DataAnnotations;

namespace IdentityAdvancedDemo.Data
{
    public class Furnitures
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;


        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public ICollection<FurnitureBuier> FurnitureBuier
          = new HashSet<FurnitureBuier>();
    }
}