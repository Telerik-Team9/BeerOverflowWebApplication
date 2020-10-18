using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeerOverflow.Services.Contracts;
using System;
using BeerOverflow.Services.DTOs;
using System.Collections.Generic;
using BeerOverflow.Services.DTOMappers;
using System.Threading.Tasks;
using BeerOverflow.Web.Models;

namespace BeerOverflow.Web2.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService service;

        public CountryController(ICountryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var countries = await this.service.RetrieveAllAsync();

            if (!countries.Any())
            {
                return NoContent();
            }

            var result = countries.Select(c => c.GetModelAsObject());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var country = await this.service.RetrieveByIdAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country.GetModelAsObject()); //TODO 
        }

        [HttpGet("{name:alpha}")]
        public async Task<IActionResult> Get(string name)
        {
            var country = await this.service.RetrieveByNameAsync(name);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country.GetModelAsObject()); //TODO 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var country = await this.service.DeleteAsync(id);

            if (country)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CountryViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var countryDTO = new CountryDTO
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                ISO = model.ISO,
                Breweries = new List<BreweryDTO>()
            };

            var country = await this.service.CreateAsync(countryDTO);

            return Created("post", country);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CountryViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var country = new CountryDTO
            {
                Id = id,
                Name = model.Name,
                ISO = model.ISO,
                Breweries = new List<BreweryDTO>()
               // Breweries = model.Breweries // map to viewmodel
            };

            var updatedCountryDTO = await this.service.UpdateAsync(id, country);

            var result = new
            {
                Id = updatedCountryDTO.Id,
                Name = updatedCountryDTO.Name,
                ISO = updatedCountryDTO.ISO,
            };

            return Ok(result);
        }
    }
}
