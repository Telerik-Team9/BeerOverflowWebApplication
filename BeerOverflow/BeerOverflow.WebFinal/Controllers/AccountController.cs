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
                (bool isBanned, bool isDeleted) = await this.userService.IsLegitAsync(item.Email);

                if(isBanned)
                {
                    return RedirectToAction(nameof(BannedUser));
                }

                if (isDeleted)
                {
                    return RedirectToAction(nameof(DeletedUser));
                }

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
        public IActionResult BannedUser()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeletedUser()
        {
            return View();
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

                if (!dranklist.Any(dl => dl.Id == id))
                {
                    var beer = await this.userService.AddBeerToDrankList(id, user.Id);
                }

                return RedirectToAction("DrankList", "Account");
            }
            catch
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public async Task<IActionResult> WishLists()
        {
            var user = await this.userManager.GetUserAsync(User);
            var wishList = await this.userService.GetWishListAsync(user.Id, "default");

            return View(wishList); //TODO!

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
        }

        [HttpGet]
        public async Task<IActionResult> AddToWishList(Guid id) // TODO: Why doesnt work wth POST?
        {
            try
            {
                var user = await this.userManager.GetUserAsync(User);

                var wishList = await this.userService.GetWishListAsync(user.Id, "default");

                if (!wishList.Any(w => w.Id == id))
                {
                    var beer = await this.userService.AddBeerToWishList(id, user.Id, "default");
                }

                return RedirectToAction("WishLists", "Account");
            }
            catch
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(Guid beerId, BeerDetailsViewModel model)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(User);
                await this.userService.AddReviewToBeer(beerId, user.Id, model.Review.Content);

                return RedirectToAction("Details", "Beers", new { id = beerId });
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
