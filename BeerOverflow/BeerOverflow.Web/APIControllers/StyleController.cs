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

        [HttpGet] //Add sort?
        public async Task<IActionResult> Get()
        {
            var styles = await this.service.RetrieveAllAsync();

            if (!styles.Any()) // null validation as well?
            {
                return NoContent();
            }

            return Ok(styles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            //TODO: Remove Exception handling for nulls in the layers below
            var style = await this.service.RetrieveByIdAsync(id);

            if (style == null)
            {
                return NotFound();
            }

            return Ok(style);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await this.service.DeleteAsync(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StyleViewModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }

            var styleDTO = new StyleDTO
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                Beers = new List<BeerDTO>()
            };

            var style = await this.service.CreateAsync(styleDTO);

            return Created("post", style);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] StyleViewModel model)
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

            var updatedStyleDTO = await this.service.UpdateAsync(id, style);

            return Ok(updatedStyleDTO);
        }
    }
}
