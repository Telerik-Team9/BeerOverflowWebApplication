using BeerOverflow.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        [HttpGet("")]
        public IActionResult GetAllCountries()
        {
            var countries = this.service.GetAllCountries().ToList();

            if (countries.Count == 0)
            {
                return NoContent();
            }

            return Ok(countries);
        }

        /*
                CountryDTO Create(CountryDTO countryDTO);
                CountryDTO RetrieveById(Guid Id);
                CountryDTO Update(Guid Id, CountryDTO countryDTO);
                bool Delete(Guid Id);*/
    }
}
