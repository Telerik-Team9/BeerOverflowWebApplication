using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeerOverflow.Services.Contracts;

namespace BeerOverflow.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleWRONGContoller : ControllerBase
    {
        private readonly IStyleService service;

        public StyleWRONGContoller(IStyleService service)
        {
            this.service = service;
        }

        [HttpGet("")] //Add sort?
        public IActionResult RetrieveAll()
        {
            var styles = this.service.RetrieveAll()
                         .ToList();

            if (styles.Count == 0)
            {
                return NoContent();
            }

            return Ok(styles);
        }

        [HttpGet("{id}")]
        public IActionResult RetrieveById(Guid id)
        {
            //TODO: Remove Exception handling for nulls in the layers below
            var style = this.service.RetrieveById(id);

            if (style == null)
                return NotFound();

            return Ok(style);
        }

        //[HttpPost("")]
        //public IActionResult Post([FromBody] StyleViewModel model)
        //{

        //}

        //[HttpPut("(id)")]
        //public IActionResult Put(Guid id, [FromBody] StyleViewModel model)

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
