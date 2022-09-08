using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace MVCHamburgerProjesi.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Ekstra> Ekstralar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Entity<Menu>().HasData(
                new Menu() { Id = 1, MenuAd = "Whopper", Fiyat = 45 },
                new Menu() { Id = 2, MenuAd = "Double Whopper", Fiyat = 60 },
                new Menu() { Id = 3, MenuAd = "Double Köfteburger", Fiyat = 65 },
                new Menu() { Id = 4, MenuAd = "Cheeseburger", Fiyat = 55 }
                );
            modelBuilder.Entity<Ekstra>().HasData(
                new Ekstra() { Id = 1, EkstraAd = "Ketçap", Fiyat = 1 },
                new Ekstra() { Id = 2, EkstraAd = "Mayonez", Fiyat = 1 },
                new Ekstra() { Id = 3, EkstraAd = "Acı Sos", Fiyat = 2 }
                );

        }
    }
}
