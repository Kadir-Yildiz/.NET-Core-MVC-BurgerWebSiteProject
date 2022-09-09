using Microsoft.AspNetCore.Mvc;

namespace MVCHamburgerProjesi.Controllers
{
    public class IstatistikController : Controller
    {
        private readonly ApplicationDbContext _db;

        public IstatistikController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewBag.Ciro = _db.Siparisler.Sum(x=>x.ToplamTutar).ToString("C");
            ViewBag.SiparişAdedi = _db.Siparisler.Count();
            ViewBag.MenuAdedi = _db.Siparisler.Sum(x=>x.Adet);
            var list = _db.Siparisler.ToList();
            int toplam = 0;
            foreach (var item in list)
            {
                if (item.Ekstralar!=null)
                {
                toplam += item.Ekstralar.Split(',').Count();
                }
            }
            ViewBag.Ekstralar = toplam;
            return View(_db.Siparisler.Include(x=>x.SeciliMenu).ToList());
        }
    }
}
