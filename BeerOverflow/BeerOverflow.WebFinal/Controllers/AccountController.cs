using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        public async Task<IActionResult> DrankList()
        {
            var user = await this.userManager.GetUserAsync(User);
            var drankList = await this.userService.GetDrankListAsync(user.Id);

            return View(drankList);
        }

        public async Task<IActionResult> AddToDrankList(Guid id) // TODO: Why doesnt work wth POST?
        {
            try
            {
                var user = await this.userManager.GetUserAsync(User);

                var dranklist = await this.userService.GetDrankListAsync(user.Id);
                
                if(!dranklist.Any(dl => dl.Id == id))
                {
                    var beer = await this.userService.AddBeerToDrankList(id, user.Id);
                }

                return RedirectToAction("DrankList", "Account");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> WishLists()
        {
            /*            var user = await this.userManager.GetUserAsync(User);

                        var wishListNames = await this.userService.GetWishListNamesAsync(user.Id);

                        ViewBag.WishListNames = wishListNames;

                        if (!wishListNames.Any())
                        {
                            return View(new WishListSearchViewModel());
                        }

                        var result = await this.userService.GetWishListAsync(user.Id, wishListNames.First());
                        var wishList = result.Select(b => new BeerViewModel(b));

                        var wlSearchViewModel = new WishListSearchViewModel();
                        wlSearchViewModel.Name = wishListNames.First();
                        wlSearchViewModel.WishList = wishList.ToList();

                        return View(wlSearchViewModel);*/

            return View(new WishListSearchViewModel()); //TODO!

        }
    }
}
