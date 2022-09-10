using Microsoft.AspNetCore.Mvc;
using MVCHamburgerProjesi.Models;

namespace MVCHamburgerProjesi.Controllers
{
	public class MenuEkstraController : Controller
	{
        private readonly ApplicationDbContext _db;

        public MenuEkstraController(ApplicationDbContext db)
        {
            _db = db;
        }
		public IActionResult Index()
		{
            ViewBag.Menuler = _db.Menuler.ToList();
            ViewBag.Ekstralar = _db.Ekstralar.ToList();
			return View();
		}
        

        [HttpPost]
        public IActionResult MenuEkle(MenuEkstraViewModel vm)
        {
            Menu menu = new Menu();
            menu.MenuAd = vm.MenuAd;
            menu.Fiyat = vm.Fiyat;
            _db.Menuler.Add(menu);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EkstraEkle(MenuEkstraViewModel vm)
        {
            Ekstra ekstra = new Ekstra();
            ekstra.EkstraAd = vm.EkstraAd;
            ekstra.Fiyat = vm.Fiyat;
            _db.Ekstralar.Add(ekstra);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        
        
        public IActionResult MenuDuzenle(int id)
        {
            Menu menu = _db.Menuler.Where(x => x.Id == id).FirstOrDefault();
            return View(menu);
        }
        public IActionResult MenuSil(int id)
        {
            var menu = _db.Menuler.Where(x=>x.Id == id).FirstOrDefault();
            _db.Menuler.Remove(menu);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult EkstraSil(int id)
        {
            var ekstra = _db.Ekstralar.Where(x => x.Id == id).FirstOrDefault();
            _db.Ekstralar.Remove(ekstra);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

