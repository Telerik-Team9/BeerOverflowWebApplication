using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Controllers
{
    public class AdminController : Controller
    {
        public IUserService userService;
        public IBeerService beerService;

        public AdminController(IUserService userService, IBeerService beerService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.beerService = beerService ?? throw new ArgumentNullException(nameof(beerService));
        }

        // GET: AdminController/Details/5
        public async Task<ActionResult> ListUsers()
        {
            var users = await this.userService.RetrieveAllByRolesAsync();
            return View(new ListUsersViewModel(users));
        }

        // GET: AdminController/useriId
        [HttpGet]
        public async Task<ActionResult> BanUser(Guid userId)
        {
            try
            {
                var banned = await this.userService.BanAsync(userId);
                return RedirectToAction(nameof(ListUsers));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            try
            {
                var isDeleted = await this.userService.DeleteAsync(userId);
                return RedirectToAction(nameof(ListUsers));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<ActionResult> UnlistBeer(Guid beerId)
        {
            try
            {
                if (User.IsInRole("Admin")){
                    var isUnlisted = await this.beerService.UnlistBeer(beerId);
                    return RedirectToAction("Search", "Beers");
                }

                return RedirectToAction("Error", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
