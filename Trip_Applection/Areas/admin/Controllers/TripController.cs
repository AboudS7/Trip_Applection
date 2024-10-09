using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trip_Applection.BL;
using Trip_Applection.Models;

namespace Trip_Applection.Areas.admin.Controllers
{
    [Area("admin")]
    public class TripController : Controller
    {
        private readonly IRepostry<Trip> repostry;
        private readonly TravelsContext context;

        public TripController(IRepostry<Trip> repostry,TravelsContext context)
        {
            this.repostry = repostry;
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Trips.ToList();
            
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = repostry.Create(trip);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = repostry.Delete(id);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            var resulr = repostry.GetById(id);
            return View(resulr);
        }
        [HttpPost]
        public IActionResult Update(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return View(trip);
            }
            else
            {
                var res = repostry.Update(trip); 
                    TempData["msg"] = "تم التعديل بنجاح";
                    return RedirectToAction("Index");

            }
            return View(trip);
        }
    }
}
