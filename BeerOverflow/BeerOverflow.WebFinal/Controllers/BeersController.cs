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
    public class BeersController : Controller
    {
        private readonly IBeerService beerService;

        public BeersController(IBeerService beerService)
        {
            this.beerService = beerService ?? throw new ArgumentNullException(nameof(beerService));
        }

        // GET: BeersController
        public async Task<ActionResult> Index()
        {
            var result = await this.beerService.RetrieveAllAsync();

            var beers = result.Select(b => new BeerViewModel(b));
            var beerSearchModel = new BeerSearchViewModel()
            {
                Beers = beers.ToList()
            };

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
            Console.WriteLine("VLEZNA");
            return View();
        }
    }
}
