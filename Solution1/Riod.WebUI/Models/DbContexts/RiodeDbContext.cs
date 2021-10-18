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
        public RiodeDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<NBrand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductSize> Sizes { get; set; }

    }
}
