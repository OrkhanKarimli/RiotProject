using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riod.WebUI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult MainPage()
        {
            return View();
        }
    }
}
