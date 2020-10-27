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
    public class StylesController : Controller
    {
        private readonly IStyleService styleService;

        public StylesController(IStyleService styleService)
        {
            this.styleService = styleService ?? throw new ArgumentNullException(nameof(styleService));
        }

        // GET: StylesController
        [HttpGet]
        public async Task<ActionResult> List()
        {
            var stlyleDTOs = await this.styleService.RetrieveAllAsync();

            var styles = stlyleDTOs
                .Select(s => new StyleViewModel(s))
                .ToList();

            return View(styles);
        }

        // GET: StylesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StylesController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var styles = await this.styleService.RetrieveAllAsync();
            ViewBag.Styles = styles
                .Select(s => new StyleViewModel(s));

            return View();
        }

        // POST: StylesController/Create
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(StyleViewModel item)
        {
            try
            {
                var style = await this.styleService.CreateAsync(item.GetDTO());
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: StylesController/Edit/id
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StylesController/Edit/id
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: StylesController/Delete/id
        [Authorize]
        public ActionResult Delete(int id) // TODO: Not in assignment so not added as functionality
        {
            return View();
        }

        // POST: StylesController/Delete/id
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
