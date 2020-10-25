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
        public async Task<ActionResult> Users()
        {
            var users = await this.userService.RetrieveAllByRolesAsync();
            return View(new ListUsersViewModel(users));
        }

        // GET: AdminController/Create
        public ActionResult BanUser()
        {
            return RedirectToAction("Users");
        }

        public ActionResult DeleteUser()
        {
            return RedirectToAction("Users");
        }
    }
}
