using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            if (Beers.Count == 0)
            {
                return NoContent();
            }

            return Ok(Beers.OrderBy(b => b.Name));
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            if (Beers.Count == 0)
            {
                return NoContent();
            }

            var beer = Beers.FirstOrDefault(b => b.Name == name);

            if (beer == null)
            {
                return NotFound();
            }

            return Ok(beer);
        }

        [HttpPost("")]
        public IActionResult Post(Beer model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var newBeer = new Beer()
            {
                Name = model.Name,
                ABV = model.ABV,
                Price = model.Price
            };

            Beers.Add(newBeer);
            return Created("post", newBeer);
        }

        /*      [HttpPut("name")]
                public IActionResult Put(string name, [FromBody] Beer model)
                {
                    if (model == null)
                    {
                        return BadRequest();
                    }

                    var beerToChange = Beers.FirstOrDefault(b => b.Name == name);
                    beerToChange.Name = model.Name;
                    beerToChange.ABV = model.ABV;
                    beerToChange.Price = model.Price;



                    beerToChange = new Beer()
                    {
                        Name = model.Name,
                        ABV = model.ABV,
                        Price = model.Price
                    };

                    Beers.Add(newBeer);

                    return Created("post", newBeer);
                }*/




        public static List<Beer> Beers { get; set; } = new List<Beer>
        {
            new Beer
            {
                Name = "London",
                ABV = 4.1f
            },
            new Beer
            {
                Name = "Frontier",
                ABV = 5.2f
            },
            new Beer
            {
                Name = "Honey Dew",
                BreweryId = Guid.NewGuid(),
                ABV = 0.0f
            }
        };
    }
}
