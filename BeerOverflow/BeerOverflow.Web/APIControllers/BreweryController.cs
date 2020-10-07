using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("")] //Add sort?
        public IActionResult Get()
        {
            var breweries = this.service.RetrieveAll()
                         .ToList();

            if (breweries.Count == 0)
            {
                return NoContent();
            }

            return Ok(breweries);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            //TODO: Remove Exception handling for nulls in the layers below
            var brewery = this.service.RetrieveById(id);

            if (brewery == null)
                return NotFound();

            return Ok(brewery);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = this.service.Delete(id);

            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
