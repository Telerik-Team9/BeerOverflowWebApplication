using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> user;

        public UsersController(UserManager<User> user)
        {
            this.user = user;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
