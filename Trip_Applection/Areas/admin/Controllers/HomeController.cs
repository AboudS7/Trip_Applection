using Microsoft.AspNetCore.Mvc;

namespace Trip_Applection.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
