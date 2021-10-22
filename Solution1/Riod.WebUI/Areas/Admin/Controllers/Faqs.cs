using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riod.WebUI.Models.DbContexts;
using Riod.WebUI.Models.Entities;
using Riod.WebUI.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riod.WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class Faqs : Controller
    {
        readonly RiodeDbContext db;
        public  Faqs(RiodeDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var vdt = new ShowViewModel();
            
            vdt.Faqss= await db.Faqs.Where(b => b.DeletedByUserId == null).ToListAsync();
            return View(vdt);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var entity = await db.Faqs.FirstOrDefaultAsync(b => b.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Faq bd)
        {
            if (ModelState.IsValid)
            {
            db.Faqs.Add(bd);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           return View(bd);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var entity = await db.Faqs.FirstOrDefaultAsync(b => b.Id == id);
            if (entity ==null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute]int id,Faq bd)
        {
            if (!ModelState.IsValid)
            {
              return View(bd);
            }
            if(id!= bd.Id || id<1)
            {
                return BadRequest();
            }
            var entity = await db.Faqs.FirstOrDefaultAsync(b => b.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Question = bd.Question;
            entity.Answer = bd.Answer;
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return Json(
                    new
                    {
                        error=true,
                        message="Melumat tapilmadi",

                    }

                    );
            }
            var entity = await db.Faqs.FirstOrDefaultAsync(b => b.Id == id);
            if (entity == null)
            {
                return Json(
                    new
                    {
                        error = true,
                        message = "Melumat tapilmadi",

                    }

                    );
            }
            entity.DeletedDate = DateTime.UtcNow.AddHours(4);
            db.Faqs.Remove(entity);
            await db.SaveChangesAsync();
            return Json(
                  new
                  {
                      error = false,
                      message = "Melumat silindi",

                  }

                  );
        }
    }

}

