using IdentityAdvancedDemo.Data.IdentityModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityAdvancedDemo.Data
{
    public class FurnitureBuier
    {
       
            public Guid BuyerId { get; set; } // Променете типа на BuyerId на Guid

            [ForeignKey(nameof(BuyerId))]
            public ApplicationUser Buyer { get; set; } = null!;

            public int FurnitureId { get; set; }

            [ForeignKey(nameof(FurnitureId))]
            public Furnitures Furnitures { get; set; } = null!;
        }
    
}
