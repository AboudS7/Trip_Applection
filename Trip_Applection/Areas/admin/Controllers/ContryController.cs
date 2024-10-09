using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trip_Applection.BL;
using Trip_Applection.Models;

namespace Trip_Applection.Areas.admin.Controllers
{
    [Area("admin")]
    public class ContryController : Controller
    {
        private readonly IRepostry<Contry> repostry;
        private readonly TravelsContext context;

        public ContryController(IRepostry<Contry> repostry,TravelsContext context)
        {
            
            this.repostry = repostry;
            this.context = context;
        }
        public IActionResult Index()
        {
            var list_Contry = context.Contries.Include(a => a.City).ToList();
            return View(list_Contry);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contry contry)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = repostry.Create(contry);
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
    }
}
