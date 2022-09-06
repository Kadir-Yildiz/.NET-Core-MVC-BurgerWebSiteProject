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
            return View();
        }
        [HttpPost]
        public IActionResult SiparisEkle(Siparis siparis)
        {
            
            return View();
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