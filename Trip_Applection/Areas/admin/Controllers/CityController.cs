using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trip_Applection.BL;
using Trip_Applection.Models;

namespace Trip_Applection.Areas.admin.Controllers
{
    [Area("admin")]
    public class CityController : Controller
    {
        private readonly IRepostry<City> repostry;
       

        public CityController(IRepostry<City> repostry)
        {
            this.repostry = repostry;
           
        }
        public IActionResult Index()
        {
            var result = repostry.GetAll();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(City city)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = repostry.Create(city);
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
        public IActionResult Update(City city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }
            else
            {
                var res = repostry.Update(city);
                TempData["msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return View(city);
        }
    }
}
