using Microsoft.EntityFrameworkCore;
using Riod.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riod.WebUI.Models.DbContexts
{
    public class RiodeDbContext:DbContext
    {
        public RiodeDbContext()
        {
        }

        public RiodeDbContext(DbContextOptions options)
            :base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBulider)
        {
            if (!optionsBulider.IsConfigured)
            {
                optionsBulider.UseSqlServer("data source=.\\SQLEXPRESS;initial catalog=Riode;user id=sa;password=query;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<NBrand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductSize> Sizes { get; set; }
        public DbSet<Category> Pcategories { get; set; }
        public DbSet<Faq> Faqs { get; set; }

    }
}
