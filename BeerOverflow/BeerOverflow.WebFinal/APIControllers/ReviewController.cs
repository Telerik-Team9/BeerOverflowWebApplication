using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web2.APIControllers
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
        public IActionResult Get()
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
        public IActionResult Get(Guid id)
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

        [HttpPost("")]
        public IActionResult Post([FromBody] ReviewViewModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }

            var reviewDTO = new ReviewDTO
            {
                Id = model.Id,
                Content = model.Content,
                Likes = model.Likes,
                //Rating = model.Rating,
                BeerId = model.BeerId,
                BeerName = model.BeerName
            };

            var review = this.service.Create(reviewDTO);
            return Created("post", review);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ReviewViewModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }

            var reviewDTO = new ReviewDTO
            {
                Id = model.Id,
                Content = model.Content,
                Likes = model.Likes,
                //Rating = model.Rating,
                BeerId = model.BeerId,
                BeerName = model.BeerName
            };

            var updatedReviewDTO = this.service.Update(id, reviewDTO);

            return Ok(updatedReviewDTO);
        }

    }
}
