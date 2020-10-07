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
    public class StyleController : ControllerBase
    {
        private readonly IStyleService service;

        public StyleController(IStyleService service)
        {
            this.service = service;
        }

        [HttpGet("")] //Add sort?
        public IActionResult Get()
        {
            var styles = this.service.RetrieveAll()
                         .ToList();

            if (styles.Count == 0) // null validation as well?
            {
                return NoContent();
            }

            return Ok(styles);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            //TODO: Remove Exception handling for nulls in the layers below
            var style = this.service.RetrieveById(id);

            if (style == null)
                return NotFound();

            return Ok(style);
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
