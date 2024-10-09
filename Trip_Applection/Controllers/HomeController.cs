using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Trip_Applection.Models;

namespace Trip_Applection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly TravelsContext context;

        public HomeController(ILogger<HomeController> logger, TravelsContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var result = context.Trips.ToList();
            return View(result);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = context.Trips
                .Include(t => t.Catogry)
                .Include(t => t.Imags).Include(a => a.Contry.City).Include(a => a.Contry)
                .FirstOrDefault(t => t.TripId == id);

            return View(trip);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}