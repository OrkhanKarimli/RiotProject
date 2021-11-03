using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class Categories : Controller
    {
        readonly RiodeDbContext db;
        public Categories(RiodeDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            
            
           var vdt = await db.Pcategories
                .Include(c=>c.Children)
                .Where(b => b.DeletedByUserId == null).ToListAsync();
            return View(vdt);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var entity = await db.Pcategories.FirstOrDefaultAsync(b => b.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        public IActionResult  Create()
        {
            var categories =  db.Pcategories.Where(c=>c.DeletedByUserId==null).ToList();
            var selectList = new SelectList(categories, "Id", "Name");
            ViewBag.Category = selectList;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category bd)
        {
            if (ModelState.IsValid)
            {
            db.Pcategories.Add(bd);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var categories = db.Pcategories.Where(c => c.DeletedByUserId == null).ToList();
            var selectList = new SelectList(categories, "Id", "Name",bd.ParentId);
            ViewBag.Category = selectList;
            return View(bd);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var entity = await db.Pcategories.FirstOrDefaultAsync(b => b.Id == id);
            if (entity ==null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute]int id,Category bd)
        {
            if (!ModelState.IsValid)
            {
              return View(bd);
            }
            if(id!= bd.Id || id<1)
            {
                return BadRequest();
            }
            var entity = await db.Pcategories.FirstOrDefaultAsync(b => b.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = bd.Name;
            entity.Description = bd.Description;
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
            var entity = await db.Pcategories.FirstOrDefaultAsync(b => b.Id == id);
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
            db.Pcategories.Remove(entity);
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

