using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeerOverflow.Web.Models;
using BeerOverflow.Services.Contracts;

namespace BeerOverflow.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBeerService beerService;

        public HomeController(IBeerService beerService)
        {
            this.beerService = beerService ?? throw new ArgumentNullException(nameof(beerService));
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Home Page";
            var beers = await this.beerService.RetrieveAllAsync();
            var result = beers.Where(b => b.IsBeerOfTheMonth && !b.IsUnlisted)
                              .OrderByDescending(x => x.AvgRating)
                              .Take(3);

            var model = new HomeIndexViewModel()
            {
                TopRatedBeers = result.Select(b => new BeerViewModel(b))
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
