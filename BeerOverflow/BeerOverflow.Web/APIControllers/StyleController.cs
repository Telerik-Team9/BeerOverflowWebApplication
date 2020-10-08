using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
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

        [HttpPost("")]
        public IActionResult Post([FromBody] StyleViewModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }

            var styleDTO = new StyleDTO
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Beers = new List<BeerDTO>()
                // Beers = model.BeerViewModels.Select(o=>o.GetDTO/Model())
            };

            var style = this.service.Create(styleDTO);

            return Created("post", style);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] StyleViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var style = new StyleDTO
            {
                Name = model.Name,
                Description = model.Description,
            };

            var updatedStyleDTO = this.service.Update(id, style);

            return Ok(updatedStyleDTO);
        }
    }
}
