using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riod.WebUI.Models.DbContexts;
using Riod.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riod.WebUI.Controllers
{
    public class HomeController : Controller
    {
        readonly RiodeDbContext db;
        public HomeController(RiodeDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(Contact contact)
        {
            if (ModelState.IsValid)
            {
            db.Contacts.Add(contact);
            db.SaveChanges();
                ModelState.Clear();
                //ViewBag.Message = "Mesaj qebul edilmisdir size geri donus edilecek!";
                //return View();
                return Json(new {
                    error = false,
                    message = "Mesaj qebul edilmisdir size geri donus edilecek!"

                }) ;

            }

            //return View(contact);
            return Json(new
            {
                error = true,
                message = "Melumatlari duzgun daxil edin!"

            });
        }
        public IActionResult Faqs()
        {
            return View();
        }
        public IActionResult ComingSoon()
        {
            return View();
        }
    }
}
