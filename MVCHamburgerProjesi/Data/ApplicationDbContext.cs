using Microsoft.EntityFrameworkCore;

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
	}
}
