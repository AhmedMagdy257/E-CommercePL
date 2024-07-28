using BusinessLayer;
using DataAccess.Model;
using E_CommercePL.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommercePL.Controllers
{
    public class AccountController : Controller
    {
        /// Dependency Injection (For Create instance of SignInManager) for once
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserVM user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var theuser = await _userManager.FindByNameAsync(user.UserName);
                HttpContext.Session.SetString("userId", theuser.Id);

                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "UserName or Password Was Wrong");

                return View();

            }
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserVM user)
        {
            // create object of Identityuser to create new user 
            var identityUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email,
            };
            var useridentity = await _userManager.CreateAsync(identityUser, user.Password);

            if (useridentity.Succeeded)
            {
                HttpContext.Session.SetString("userId", identityUser.Id);

                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User Register Faild");
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");

        }
    }
}
