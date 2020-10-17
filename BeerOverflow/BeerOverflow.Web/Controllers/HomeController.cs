using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.Services;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;

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
            var result = beers.OrderBy(b => b.AvgRating).Take(3);

            var model = new HomeIndexViewModel()
            {
                TopRatedBeers = result.Select(b => new BeerViewModel(b))
            };
            return View(model);
        }
    }
}
