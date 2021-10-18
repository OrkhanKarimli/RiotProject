using Riod.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riod.WebUI.Views.ViewModels
{
    public class ShowViewModel
    {
        public List<NBrand> Brands { get; set; }
        public List<Color> Colors { get; set; }
        public List<ProductSize> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
