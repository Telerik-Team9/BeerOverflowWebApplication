using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.Controllers
{
    public class AdminController : Controller
    {
        public IUserService userService;

        public AdminController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
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
                var deleted = await this.userService.DeleteAsync(userId);
                return RedirectToAction(nameof(ListUsers));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
