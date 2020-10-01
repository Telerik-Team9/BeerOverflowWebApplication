using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService service;
        public CountryController(ICountryService  service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            this.service.CreateCountry(country);
            return View("Index", "Home");
        }
    }
}
