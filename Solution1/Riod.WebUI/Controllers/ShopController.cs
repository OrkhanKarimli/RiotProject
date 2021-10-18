using Microsoft.AspNetCore.Mvc;
using Riod.WebUI.Models.DbContexts;
using Riod.WebUI.Models.Entities;
using Riod.WebUI.Views.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Riod.WebUI.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            RiodeDbContext db = new RiodeDbContext();

            ShowViewModel vm = new ShowViewModel();
            vm.Brands = db.Brands
                .Where(b=>b.DeletedByUserId==null)
                .ToList();
            vm.Colors = db.Colors
                .Where(b => b.DeletedByUserId == null)
                .ToList();

            vm.Products = db.Sizes
                .Where(b => b.DeletedByUserId == null)
                .ToList();

            vm.Categories = db.Pcategories
                .Where(b => b.DeletedByUserId == null)
                .ToList();
            return View(vm);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
