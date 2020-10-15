using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryService service;

        public BreweryController(IBreweryService service)
        {
            this.service = service;
        }

        [HttpGet] //Add sort?
        public async Task<IActionResult> Get()
        {
            var breweries = await this.service.RetrieveAllAsync();

            if (!breweries.Any())
            {
                return NoContent();
            }

            var result = breweries
                .Select(brewery => brewery.GetModelAsObject());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            //TODO: Remove Exception handling for nulls in the layers below
            var brewery = await this.service.RetrieveByIdAsync(id);

            if (brewery == null)
            {
                return NotFound();
            }

            return Ok(brewery.GetModelAsObject());
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BreweryViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var breweryDTO = new BreweryDTO //TODO: MAP from model to dto!
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                CountryName = model.CountryName
            };

            var brewery = await this.service.CreateAsync(breweryDTO);

            return Created("post", brewery);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] BreweryViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var breweryDTO = new BreweryDTO
            {
                Id = model.Id, // TODO: Tva go nqmashe i bez nego ne raboti
                Name = model.Name,
                CountryName = model.CountryName,
            };

            var updatedBrewery = await this.service.UpdateAsync(id, breweryDTO); // Should we validate / where

            var result = new
            {
                Name = updatedBrewery.Name,
                Country = updatedBrewery.CountryName
            };

            return Ok(result);
        }
    }
}
