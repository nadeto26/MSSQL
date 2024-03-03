using System.ComponentModel.DataAnnotations;

namespace IdentityAdvancedDemo.Data
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Furnitures> Furnitures { get; set; } = new List<Furnitures>();
    }
}