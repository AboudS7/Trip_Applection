using Microsoft.AspNetCore.Mvc;
using Trip_Applection.BL;
using Trip_Applection.Models;

namespace Trip_Applection.Areas.admin.Controllers
{
    [Area("admin")]
    public class CatogeryController : Controller
    {
        private readonly IRepostry<Catogery> repostry;

        public CatogeryController(IRepostry<Catogery> repostry)
        {
            this.repostry = repostry;
        }
        public IActionResult Index()
        {
            var result =repostry.GetAll();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catogery catogery)
        {
            if (ModelState.IsValid)
            {
                var result=repostry.Create(catogery);
                return RedirectToAction("index");
            }
            return View();
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
    }
}
