using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BeerOverflow.Services.DTOMappers;

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

        [HttpGet]
        public IActionResult Get([FromQuery] string order = "asc")
        {
            var orderedBeers = this.service.OrderByName(order);

            if (orderedBeers == null)
            {
                return BadRequest();
            }

            return Ok(orderedBeers.Select(beer => beer.GetModelAsObject()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            //TODO: Remove Exception handling for nulls in the layers below
            var beer = this.service.RetrieveById(id);

            if (beer == null)
            {
                return NotFound();
            }

            return Ok(beer.GetModelAsObject());
        }

        [HttpGet("filter")]
        public IActionResult Get([FromQuery] string criteria, [FromQuery] string name)
        {
            IEnumerable<BeerDTO> filteredCollection = null;

            if (criteria.Equals("country") || criteria.Equals("style"))
            {
                filteredCollection = this.service.FilterByCriteria(criteria, name);
            }

            if (filteredCollection == null)
            {
                return NotFound();
            }

            var result = filteredCollection
                        .Select(x => x.GetModelAsObject());

            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = this.service.Delete(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post([FromBody] BeerViewModel model)
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
            var beer = this.service.Create(beerDTO);

            return Created("post", beer.GetModelAsObject());
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, [FromBody] BeerViewModel model)
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

            var beer = this.service.Update(id, beerDTO);
            return Ok(beer.GetModelAsObject());
        }

        [HttpPut("{name}")] // Put it in a separate controller?
        public IActionResult Put(string name, [FromBody] RatingViewModel model)
        {
            var ratingDTO = new RatingDTO
            {
                Id = Guid.NewGuid(),
                BeerName = name,
                UserName = model.UserName, //FIX WHEN IDENTITY IS ADDED
                RatingGiven = model.RatingGiven
            };

            var beer = this.service.Rate(name, ratingDTO);
            if (beer == null)
            {
                return NotFound();
            }

            return Ok(beer.GetModelAsObject());
        }
    }
}
