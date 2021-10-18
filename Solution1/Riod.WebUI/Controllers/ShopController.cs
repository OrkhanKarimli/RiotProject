using Microsoft.AspNetCore.Mvc;
using Riod.WebUI.Models.DbContexts;
using Riod.WebUI.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Riod.WebUI.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            RiodeDbContext db = new RiodeDbContext();
            List<NBrand> nbrands = db.Brands.ToList();
                  
            return View(nbrands);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
