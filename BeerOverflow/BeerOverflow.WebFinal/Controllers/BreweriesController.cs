using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using BeerOverflow.Web.ViewModelMappers;
using Microsoft.AspNetCore.Authorization;
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

        // GET: BreweriesController/Create
        [Authorize]
        public async Task<ActionResult> Create()
        {
            var countries = await this.countryService.RetrieveAllAsync();
            ViewBag.Countries = countries
                .Select(c => new CountryViewModel(c));

            return View();
        }

        // POST: BreweriesController/Create
        [HttpPost]
        [Authorize]
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

        // GET: BreweriesController/Delete/id
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await this.breweryService.DeleteAsync(id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}