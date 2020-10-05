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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService service;

        public ReviewController(IReviewService service)
        {
            this.service = service;
        }

        [HttpGet("")] //Add sort?
        public IActionResult RetrieveAll()
        {
            var reviews = this.service.RetrieveAll()
                         .ToList();

            if (reviews.Count == 0)
            {
                return NoContent();
            }

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public IActionResult RetrieveById(Guid id)
        {
            //TODO: Remove Exception handling for nulls in the layers below
            var review = this.service.RetrieveById(id);

            if (review == null)
                return NotFound();

            return Ok(review);
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
