using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using BeerOverflow.Web.ViewModelMappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating.Compilation;

namespace BeerOverflow.Web.Controllers
{
    public class BeersController : Controller
    {
        private readonly IBeerService beerService;
        private readonly IStyleService styleService;
        private readonly IBreweryService breweryService;

        public BeersController(IBeerService beerService, IStyleService styleService, IBreweryService breweryService)
        {
            this.beerService = beerService ?? throw new ArgumentNullException(nameof(beerService));
            this.styleService = styleService ?? throw new ArgumentNullException(nameof(styleService));
            this.breweryService = breweryService ?? throw new ArgumentNullException(nameof(breweryService));
        }

        // GET: BeersController
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> ListUnlisted()
        {
            // Get all beers
            var beers = new List<BeerViewModel>();

            var allBeers = await this.beerService.RetrieveAllAsync();
            beers = allBeers
                .Where(b => b.IsUnlisted)
                .Select(b => new BeerViewModel(b))
                .OrderBy(b => b.Name)
                .ToList();

            var beerSearchModel = await LoadBeersInViewModel(beers);

            return View(beerSearchModel);
        }


        [HttpGet]
        public async Task<ActionResult> Search()
        {
            // Get all beers
            var beers = new List<BeerViewModel>();

            var allBeers = await this.beerService.RetrieveAllAsync();
            beers = allBeers
                .Where(b => !b.IsUnlisted)
                .Select(b => new BeerViewModel(b))
                .OrderBy(b => b.Name)
                .ToList();

            var beerSearchModel = await LoadBeersInViewModel(beers);

            return View(beerSearchModel);
        }

        [HttpPost]
        public async Task<ActionResult> Search(BeerSearchViewModel model)
        {
            // Get all beers
            var beers = new List<BeerViewModel>();
            var filteredBeers = await this.beerService.SearchAsync(model.Name, model.StyleName, model.SortBy);
            beers = filteredBeers
                .Where(b => !b.IsUnlisted)
                .Select(b => new BeerViewModel(b))
                .ToList();

            var beerSearchModel = await LoadBeersInViewModel(beers);

            return View(beerSearchModel);
        }

        // GET: BeersController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var beer = await this.beerService.RetrieveByIdAsync(id);

            var bdvm = new BeerDetailsViewModel
            {
                Beer = new BeerViewModel(beer)
            };

            return View(bdvm);
        }

        // GET: BeersController/Create
        [Authorize]
        public async Task<ActionResult> Create()
        {
            var breweries = await this.breweryService.RetrieveAllAsync();
            ViewBag.Breweries = breweries
                .Select(br => new BreweryViewModel(br));

            var styles = await this.styleService.RetrieveAllAsync();
            ViewBag.Styles = styles
                .Select(s => new StyleViewModel(s));

            return View();
        }

        // POST: BeersController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BeerViewModel item)
        {
            try
            {
                var beer = await this.beerService.CreateAsync(item.GetDTO());
                return RedirectToAction(nameof(Search));
            }
            catch
            {
                return View();
            }
        }

        // GET: BeersController/Edit/5
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var breweries = await this.breweryService.RetrieveAllAsync();
            ViewBag.Breweries = breweries
                .Select(br => new BreweryViewModel(br));

            var styles = await this.styleService.RetrieveAllAsync();
            ViewBag.Styles = styles
                .Select(s => new StyleViewModel(s));

            var dto = await this.beerService.RetrieveByIdAsync(id);
            var vm = new BeerViewModel(dto);

            return View(vm);
        }

        // POST: BeersController/Edit/5
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, BeerViewModel model)
        {
            try
            {
                var result = await this.beerService.UpdateAsync(id, model.GetDTO());
                return RedirectToAction(nameof(Search));
            }
            catch
            {
                return View();
            }
        }

        // GET: BeersController/Delete/5
        // [Authorize]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await this.beerService.DeleteAsync(id);
                return RedirectToAction(nameof(Search));
            }
            catch
            {
                return View();
            }
        }

        // POST: BeersController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(Guid id, BeerViewModel model)
        //{
        //    try
        //    {
        //        var result = await this.beerService.DeleteAsync(id);
        //        return RedirectToAction(nameof(Search));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        private async Task<BeerSearchViewModel> LoadBeersInViewModel(IEnumerable<BeerViewModel> beers)
        {
            // Load data into Search Form
            var beerSearchModel = new BeerSearchViewModel()
            {
                Beers = beers.ToList()
            };

            var styles = await this.styleService.RetrieveAllAsync();
            var styleNames = styles
                .Select(s => s.Name)
                .ToHashSet();

            ViewBag.message = styleNames;

            return beerSearchModel;
        }
    }
}
