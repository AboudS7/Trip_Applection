using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trip_Applection.Areas.admin.Models;
using Trip_Applection.Areas.admin.UserModel;

namespace Trip_Applection.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManger;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManger,SignInManager<User> signInManager)
        {
            this.userManger = userManger;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await signInManager.PasswordSignInAsync(login.Username, login.Password, true, true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "اسم المستخدم او كلمة المرور غير صحيحة");
                        return View();
                    }
                }
                catch(Exception ex)
                {

                }
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserVM userVM)
        {
            User user = new User()
            {
                Email=userVM.Email,
                FirestName=userVM.FirestName,
                LastName=userVM.LastName,
                PhoneNumber=userVM.PhoneNumber,
                UserName=userVM.Username,

            };
            var result = await userManger.CreateAsync(user, userVM.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
             await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
