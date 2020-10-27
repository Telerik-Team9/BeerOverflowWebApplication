using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using BeerOverflow.Web.ViewModelMappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }
        // GET: CountriesController
        public async Task<ActionResult> List()
        {
            var result = await this.countryService.RetrieveAllAsync();
            var countries = result.Select(c => new CountryViewModel(c));

            return View(countries);
        }

        // GET: CountriesController/Create
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Create()
        {
            var countries = await this.countryService.RetrieveAllAsync();
            ViewBag.Countries = countries
                .Select(c => new CountryViewModel(c));

            return View();
        }

        // POST: CountriesController/Create
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(CountryViewModel item)
        {
            try
            {
                var country = await this.countryService.CreateAsync(item.GetDTO());
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
