using IdentityAdvancedDemo.Data;
using IdentityAdvancedDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Data;
using System.Security.Claims;
using System.Xml.Linq;

namespace IdentityAdvancedDemo.Controllers
{
       
        public class AdminController : Controller
        {
            private readonly ApplicationDbContext dbContext;
            public AdminController(ApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }


            [HttpGet]
            public async Task<IActionResult> Add() //мебел 
            {
                AddFurnitureViewModel admodel = new AddFurnitureViewModel()
                {
                    Categories = GetCategories()
                };

                return View(admodel);
            }

        private IEnumerable<CategoryViewModel> GetCategories()
         => dbContext
                  .Categories
                  .Select(t => new CategoryViewModel()
                  {
                      Id = t.Id,
                      Name = t.Name
                  });

        public async Task<IActionResult> Add(AddFurnitureViewModel adModel) //мебел 
            {

                Guid currentUser = GetUserId();


                var adToAdd = new Furnitures()
                {
                    Name = adModel.Name,
                    Description = adModel.Description,
                    CategoryId = adModel.CategoryId,
                    Price = adModel.Price,
                    ImageUrl = adModel.ImageUrl
                };


                await dbContext.Furnitures.AddAsync(adToAdd);
                dbContext.SaveChanges();

                return RedirectToAction("All");
            }



        public async Task<IActionResult> Cart()
        {
            Guid currentUserId = GetUserId();

            var adCartDisplay = await dbContext.FurnitureBuyers
                .Where(a => a.BuyerId == currentUserId)
                .Select(a => new AddToCartViewModel()
                {
                    Id = a.Furnitures.Id,
                    Name = a.Furnitures.Name,
                    Description = a.Furnitures.Description,
                    ImageUrl = a.Furnitures.ImageUrl,
                    Price = a.Furnitures.Price,
                     
                    Category = a.Furnitures.Category.Name,
                    

                }).ToListAsync();

            return View(adCartDisplay);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var adToAdd = await dbContext.Furnitures.FindAsync(id);

            if (adToAdd == null)
            {
                return BadRequest();
            }

            Guid currentUser = GetUserId();

            var entry = new FurnitureBuier()
            {
                FurnitureId = adToAdd.Id,
                BuyerId = currentUser
            };

            if (await dbContext.FurnitureBuyers.ContainsAsync(entry))
            {
                return RedirectToAction("Cart", "Ad");
            }

            await dbContext.FurnitureBuyers.AddAsync(entry);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Cart", "Ad");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            int adId = id;
            Guid currentUser = GetUserId();

            var adToRemove = await dbContext.Furnitures.FindAsync(adId);

            if (adToRemove == null)
            {
                return BadRequest();
            }

            var adRemove = await dbContext.FurnitureBuyers.FirstOrDefaultAsync(a => a.FurnitureId == adId
            && a.BuyerId == currentUser);

            dbContext.FurnitureBuyers.Remove(adRemove);

            await dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Ad");


        }

        public async Task<IActionResult> All()
        {
            var adsToDispkay = await dbContext
                .Furnitures.Select(a => new AllFurnitureViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Price = a.Price,
                    Category = a.Category.Name,
                    ImageUrl = a.ImageUrl,

                })
                .ToListAsync();

            return View(adsToDispkay);
        }

        //добавяне на промоции - визуализация



        //Добавяне на аксесоари - визуализация 



        private Guid GetUserId()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(userIdString, out Guid userIdGuid))
            {
                return userIdGuid;
            }
            else
            {
                // Обработка на грешка или връщане на стойност по подразбиране
                // В случай на грешка може да се върне Guid.Empty или null, в зависимост от нуждите на приложението
                throw new InvalidOperationException("Invalid user id format");
            }
        }



    }
    
}
