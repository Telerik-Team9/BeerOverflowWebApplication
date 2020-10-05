using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeerOverflow.Services.Contracts;

namespace BeerOverflow.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryAPIController : ControllerBase
    {
        private readonly ICountryService service;

        public CountryAPIController(ICountryService service)
        {
            this.service = service;
        }

        [HttpGet("")]
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

        /*
                CountryDTO Create(CountryDTO countryDTO);
                CountryDTO RetrieveById(Guid Id);
                CountryDTO Update(Guid Id, CountryDTO countryDTO);
                bool Delete(Guid Id);*/
    }
}
