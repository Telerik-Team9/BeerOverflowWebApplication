using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("")] //Add sort?
        public IActionResult Get()
        {
            var beers = this.service
                        .RetrieveAll()
                        .ToList();

            if (beers.Count == 0)
            {
                return NoContent();
            }

            return Ok(beers);
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

            return Ok(beer);
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

        [HttpPost("")]
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
                IsUnlisted = model.IsUnlisted,
                IsDeleted = model.IsDeleted,
                IsBeerOfTheMonth = model.IsBeerOfTheMonth,
                StyleId = model.StyleId,
                StyleName = model.StyleName,
                BreweryId = model.BreweryId,
                BreweryName = model.BreweryName,
                Reviews = new List<ReviewDTO>()
            };
            var beer = this.service.Create(beerDTO);

            return Created("post", beer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] BeerViewModel model)
        {
            if(model == null)
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
                Reviews = new List<ReviewDTO>()
            };

            var updatedBeer = this.service.Update(id, beerDTO);
            return Ok(updatedBeer);
        }
    }
}
