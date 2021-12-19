using Microsoft.EntityFrameworkCore;

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
        public DbSet<Phone> Phone { get; set; }
        public DbSet<USBConnector> USBConnector { get; set; }
        public DbSet<PhoneUSBCompatibility> PhoneUSBCompatibility { get; set; }
    }
}
