using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using BeerOverflow.Web.ViewModelMappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.Controllers
{
    public class BreweriesController : Controller
    {
        private IBreweryService breweryService;
        private readonly ICountryService countryService;

        public BreweriesController(IBreweryService breweryService, ICountryService countryService)
        {
            this.breweryService = breweryService ?? throw new ArgumentNullException(nameof(breweryService));
            this.countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }

        // GET: BreweriesController
        public async Task<ActionResult> List()
        {
            var result = await this.breweryService.RetrieveAllAsync();
            var breweries = result.Select(br => new BreweryViewModel(br));

            return View(breweries);
        }

/*        // GET: BreweriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }*/

        // GET: BreweriesController/Create
        public async Task<ActionResult> Create()
        {
            var countries = await this.countryService.RetrieveAllAsync();
            ViewBag.Countries = countries
                .Select(c => new CountryViewModel(c));

            return View();
        }

        // POST: BreweriesController/Create
        [HttpPost]
        /*[Authorize]*/
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BreweryViewModel item)
        {
            try
            {
                var brewery = await this.breweryService.CreateAsync(item.GetDTO());
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

/*        // GET: BreweriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BreweriesController/Edit/5
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

        // GET: BreweriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BreweriesController/Delete/5
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
        }*/
    }
}