using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using System.Diagnostics;

namespace Projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Artist()
        {
            return View();
        }
        public IActionResult Event()
        {
            return View();
        }
        public IActionResult Ticket()
        {
            return View();
        }
        public IActionResult Place()
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