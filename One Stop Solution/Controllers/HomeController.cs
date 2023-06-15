using Microsoft.AspNetCore.Mvc;
using One_Stop_Solution.Data;
using One_Stop_Solution.Models;
using System.Diagnostics;

namespace One_Stop_Solution.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDBContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext context)
        {
            _context = context;
            _logger = logger;
        }
        
        
        public IActionResult Main()
        {
            ViewBag.img = _context.Categories.ToList();

            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Index()
        {
            ViewBag.img = _context.Categories.ToList();

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