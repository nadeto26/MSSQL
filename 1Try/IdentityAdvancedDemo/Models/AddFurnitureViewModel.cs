using IdentityAdvancedDemo.Data;
using System.ComponentModel.DataAnnotations;

namespace IdentityAdvancedDemo.Models
{
    public class AddFurnitureViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        public int CategoryId { get; set; }

        [Required]
        public string Category { get; set; } = null!;

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
