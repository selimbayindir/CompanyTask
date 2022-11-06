using Entity.Dtos;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.userName);
            if (user==null)
                 user =await _userManager.FindByNameAsync(loginDto.userName);
            if (user == null)
            {
                TempData["errors"] = "User not found";
                return RedirectToAction("Index","Auth");
            }
                bool result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (result)
            {
                var roles = await _userManager.GetRolesAsync(user);
                TempData["roles"]=roles;
                return RedirectToAction("index", "Home");

               
            }


            TempData["errors"] = "password is wrong";
            return RedirectToAction("Index", "Auth");


        }
    }
}
