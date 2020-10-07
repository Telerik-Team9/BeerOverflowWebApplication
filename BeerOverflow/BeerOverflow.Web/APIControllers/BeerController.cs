using BeerOverflow.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var beers = this.service.RetrieveAll()
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
    }
}
