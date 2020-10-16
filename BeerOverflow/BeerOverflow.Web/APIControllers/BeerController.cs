using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BeerOverflow.Services.DTOMappers;
using System.Threading.Tasks;

namespace BeerOverflow.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService service;

        public BeerController(IBeerService service)
        {
            this.service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BeerViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var beerDTO = new BeerDTO
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                ABV = model.ABV,
                Price = model.Price,
                Description = model.Description,
                ImageURL = model.ImageURL,
                Mililiters = model.Mililiters,
                IsUnlisted = model.IsUnlisted,//is this necessary
                IsDeleted = model.IsDeleted,  //is this necessary
                IsBeerOfTheMonth = model.IsBeerOfTheMonth,
                StyleId = model.StyleId, // is this necessary
                StyleName = model.StyleName,
                BreweryId = model.BreweryId, // is this necessary
                BreweryName = model.BreweryName,
                Reviews = new List<ReviewDTO>() // add rating 
            };
            var beer = await this.service.CreateAsync(beerDTO);

            return Created("post", beer.GetModelAsObject());
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string criteria = "", [FromQuery] char order = 'a')
        {
            //  var orderedBeers = this.service.OrderByName(order);
            IEnumerable<BeerDTO> orderedBeers = null;

            if (criteria.Contains("abv"))
            {
                orderedBeers = await this.service.OrderByABVAsync(order);
            }
            else if (criteria.Contains("name"))
            {
                orderedBeers = await this.service.OrderByNameAsync(order);
            }
            else
            {
                orderedBeers = await this.service.OrderByRatingAsync(order);
            }

            if (orderedBeers == null)
            {
                return BadRequest();
            }

            return Ok(orderedBeers.Select(beer => beer.GetModelAsObject()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            //TODO: Remove Exception handling for nulls in the layers below
            var beer = await this.service.RetrieveByIdAsync(id);

            if (beer == null)
            {
                return NotFound();
            }

            return Ok(beer.GetModelAsObject());
        }

        [HttpGet("{name:alpha}")]
        public async Task<IActionResult> Get(string name)
        {
            var beer = await this.service.RetrieveByNameAsync(name);

            if (beer == null)
            {
                return NotFound();
            }

            return Ok(beer.GetModelAsObject());
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Get([FromQuery] string criteria, [FromQuery] string name)
        {
            IEnumerable<BeerDTO> filteredCollection = null;

            if (criteria.Equals("country") || criteria.Equals("style"))
            {
                filteredCollection = await this.service.FilterByCriteriaAsync(criteria, name);
            }

            if (filteredCollection == null)
            {
                return NotFound();
            }

            var result = filteredCollection
                        .Select(x => x.GetModelAsObject());

            return Ok(result);
        }

        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] RatingViewModel model)
        {
            var ratingDTO = new RatingDTO
            {
                Id = Guid.NewGuid(),
                BeerName = name,
                UserName = model.UserName, //FIX WHEN IDENTITY IS ADDED
                RatingGiven = model.RatingGiven
            };

            var beer = await this.service.RateAsync(name, ratingDTO);
            if (beer == null)
            {
                return NotFound();
            }

            return Ok(beer.GetModelAsObject());
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] BeerViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var beerDTO = new BeerDTO
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                ABV = model.ABV,
                Price = model.Price,
                Description = model.Description,
                ImageURL = model.ImageURL,
                Mililiters = model.Mililiters,
                IsUnlisted = model.IsUnlisted,
                IsDeleted = model.IsDeleted,
                IsBeerOfTheMonth = model.IsBeerOfTheMonth,
                StyleId = model.StyleId,
                StyleName = model.StyleName,
                BreweryId = model.BreweryId,
                BreweryName = model.BreweryName,
                Reviews = new List<ReviewDTO>() // is this necessary here
            };

            var beer = await this.service.UpdateAsync(id, beerDTO);
            return Ok(beer.GetModelAsObject());
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await this.service.DeleteAsync(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
