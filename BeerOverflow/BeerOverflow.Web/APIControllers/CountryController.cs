using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeerOverflow.Services.Contracts;
using System;

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
        public IActionResult RetrieveAll()
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
        public IActionResult RetrieveById(Guid id)
        {
            var country = this.service.RetrieveById(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

/*        //[HttpGet("api/[controller]/GetCountry/{name}")]
        [HttpGet("country/{name}")]
        public IActionResult RetrieveByName( string name)
        {
            var country = this.service.RetrieveByName(name);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }*/

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

        /*
                CountryDTO Create(CountryDTO countryDTO);
                CountryDTO RetrieveById(Guid Id);
                CountryDTO Update(Guid Id, CountryDTO countryDTO);
                bool Delete(Guid Id);*/
    }
}
