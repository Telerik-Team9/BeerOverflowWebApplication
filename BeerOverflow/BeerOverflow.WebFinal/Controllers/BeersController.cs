using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.Controllers
{
    public class BeersController : Controller
    {
        private readonly IBeerService beerService;
        private readonly IStyleService styleService;

        public BeersController(IBeerService beerService, IStyleService styleService)
        {
            this.beerService = beerService ?? throw new ArgumentNullException(nameof(beerService));
            this.styleService = styleService ?? throw new ArgumentNullException(nameof(styleService));
        }

        // GET: BeersController
        public async Task<ActionResult> Index(BeerSearchViewModel model)
        {
            // Get all beers
            var beers = new List<BeerViewModel>();

            if(model.Name == null && model.SortBy == null && model.StyleName == null)
            {
                var allBeers = await this.beerService.RetrieveAllAsync();
                beers = allBeers.Select(b => new BeerViewModel(b)).ToList();
            }
            else
            {
                var filteredBeers = await this.beerService.SearchAsync(model.Name, model.StyleName, model.SortBy);
                beers = filteredBeers.Select(b => new BeerViewModel(b)).ToList();
            }

            // Load data into Search Form
            var beerSearchModel = new BeerSearchViewModel()
            {
                Beers = beers.ToList()
            };

            var styles = await this.styleService.RetrieveAllAsync();
            var styleNames = styles.Select(s => s.Name).ToHashSet();

            ViewBag.message = styleNames;

            return View(beerSearchModel);
        }

        // GET: BeersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BeersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BeersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BeersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BeersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BeersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Search(BeerSearchViewModel model)
        {
            var beers = await this.beerService.SearchAsync(model.Name, model.StyleName, model.SortBy);
            
            return View(beers);
        }
    }
}
