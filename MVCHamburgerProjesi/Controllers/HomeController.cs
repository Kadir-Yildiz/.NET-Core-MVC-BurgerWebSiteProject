using Microsoft.AspNetCore.Mvc;
using MVCHamburgerProjesi.Models;
using System.Diagnostics;

namespace MVCHamburgerProjesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Menuler = _db.Menuler.ToList();
            ViewBag.Ekstralar = _db.Ekstralar.ToList();
            ViewBag.Siparisler = _db.Siparisler.Where(x=>x.AktifMi).ToList();
            ViewBag.Toplam = _db.Siparisler.Where(x => x.AktifMi).Sum(x=>x.ToplamTutar);


            return View();
        }
        [HttpPost]
        public IActionResult SiparisEkle(Siparis siparis, string[] ekstralar)
        {
            decimal ekstraToplam = 0;
            string ekstraT = "";
            foreach (var item in ekstralar)
            {
                var ekstra = _db.Ekstralar.Where(x=>x.EkstraAd==item).FirstOrDefault();
                ekstraToplam += ekstra.Fiyat;
                if (ekstraT=="")
                {
                ekstraT = ekstra.EkstraAd;
                }
                else
                {
                ekstraT = (ekstraT + "," + ekstra.EkstraAd);
                }
                siparis.Ekstralar = ekstraT;
            }
            
            var menu = _db.Menuler.Where(x => x.Id == siparis.MenuId).FirstOrDefault();
            siparis.SeciliMenu = menu;
            if (siparis.Boyut==null)
            {
                siparis.ToplamTutar = siparis.SeciliMenu.Fiyat + ekstraToplam;
                siparis.Boyut = "Küçük";
            }
            else
            {
            siparis.ToplamTutar = siparis.ToplamTutarHesapla(siparis.Boyut)+ekstraToplam;
            }
            _db.Siparisler.Add(siparis);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SiparisTamamla()
        {
            var list = _db.Siparisler.Where(x => x.AktifMi).ToList();
            foreach (var item in list)
            {
                item.AktifMi = false;
                _db.Siparisler.Update(item);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}