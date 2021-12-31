using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restbe.Models;

namespace restbe.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        public DbSet<CarBrands> CarBrands { get; set; }

        public DbSet<CarModel> CarModel { get; set; }
    }
}
