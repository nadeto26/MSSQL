using IdentityAdvancedDemo.Data.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityAdvancedDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Furnitures> Furnitures { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<FurnitureBuier> FurnitureBuyers { get; set; } = null!;





        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<FurnitureBuier>()
               .HasKey(e => new { e.BuyerId, e.FurnitureId });

            builder.Entity<FurnitureBuier>()
           .HasOne(fb => fb.Buyer)
           .WithMany()
           .HasForeignKey(fb => fb.BuyerId);


            builder
             .Entity<Category>()
             .HasData(new Category()
             {
                 Id = 1,
                 Name = "Кухня"
             },
             new Category()
             {
                 Id = 2,
                 Name = "Спалня"
             },
             new Category()
             {
                 Id = 3,
                 Name = "Детска стая"
             },
             new Category()
             {
                 Id = 4,
                 Name = "Маси"
             },
             new Category()
             {
                 Id = 5,
                 Name = "Столове"
             },
             new Category()
             {
                 Id = 6,
                 Name = "Гардероби"
             },
              new Category()
              {
                  Id = 7,
                  Name = "Офис"
              },
              new Category()
              {
                  Id = 8,
                  Name = "Други"
              });

            base.OnModelCreating(builder);
        }
    }
}