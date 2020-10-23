using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IUserService userService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userService = userService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel item)
        {
            if (ModelState.IsValid)
            {
                var result = await this.signInManager
                    .PasswordSignInAsync(item.Email, item.Password, isPersistent: true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DrankList(string id)
        {
            var user = await this.userManager.GetUserAsync(User);
            var drankList = await this.userService.GetDrankListAsync(user.Id);

            return View(drankList);
        }
    }
}
