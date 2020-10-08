using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeerOverflow.Services.Contracts;
using System;
using BeerOverflow.Web.Models;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Web.APIControllers
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
        public IActionResult Get()
        {
            var countries = this.service.RetrieveAll()
                            .ToList();

            if (countries.Count == 0)
            {
                return NoContent();
            }

            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var country = this.service.RetrieveById(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var country = this.service.Delete(id);

            if (country)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] CountryViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var countryDTO = new CountryDTO
            {
                Id = model.Id,
                Name = model.Name
            };

            var country = this.service.Create(countryDTO);

            return Created("post", country);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromQuery] CountryViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var country = new CountryDTO
            {
                Name = model.Name
            };

            var updatedCountryDTO = this.service.Update(id, country);

            return Ok(updatedCountryDTO);
        }
    }
}
