using CoreIdentityAuthAndAthorize.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentityAuthAndAthorize.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TestAction()
        {
            AppUser curUser = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.UserName = curUser.UserName;
            return View();
        }
    }
}
