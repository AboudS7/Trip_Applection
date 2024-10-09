 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trip_Applection.BL;
using Trip_Applection.Models;

namespace Trip_Applection.Areas.admin.Controllers
{
    [Area("admin")]
    public class ImagController : Controller
    {
        private readonly IRepostry<Imag> repostry;
        private readonly TravelsContext context;

        public ImagController(IRepostry<Imag> repostry,TravelsContext context)
        {
            this.repostry = repostry;
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Imags
                    .Include(i => i.Trip)
                    .ThenInclude(t => t.Contry)
                    .ToList();

            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Imag imag, List<IFormFile> Files)
        {

            imag.ImagName = await UploudImg(Files);
            var res = repostry.Create(imag);
            return RedirectToAction("Index");
        }




        public async Task<string> UploudImg(List<IFormFile> Files)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string imagName = Guid.NewGuid().ToString() + ".jpg";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploud/Imag", imagName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                        return imagName;
                    }

                }
            }
            return String.Empty;
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
