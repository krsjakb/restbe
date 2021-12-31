using Microsoft.EntityFrameworkCore;
using restbe.Models;

namespace restbe.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //pu:PhoneUsb ; p:Phone
            modelBuilder.Entity<PhoneUSBConnector>()
                        .HasOne(pu => pu.Phone)
                        .WithMany(p => p.PhoneUSBConnectors)
                        .HasForeignKey(pu => pu.Id_phone);

            //pu:PhoneUsb ; p:Phone
            modelBuilder.Entity<PhoneUSBConnector>()
                        .HasOne(pu => pu.USBConnector)
                        .WithMany(u => u.PhoneUSBConnectors)
                        .HasForeignKey(pu => pu.Id_USBConnector);

            //u:Usb ; pt:PlugType
            modelBuilder.Entity<USBConnector>()
                        .HasOne(u => u.PlugType)
                        .WithMany(pt => pt.USBConnectors)
                        .HasForeignKey(u => u.Id_PlugType);
        }

        public DbSet<CarBrands> CarBrands { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<USBConnector> USBConnectors { get; set; }
        public DbSet<PlugType> PlugTypes { get; set; }
        public DbSet<PhoneUSBConnector> PhoneUSBConnector { get; set; }
    }
}
