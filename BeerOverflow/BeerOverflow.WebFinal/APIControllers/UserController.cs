using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace BeerOverflow.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await this.service.RetrieveAllAsync();
            if (!users.Any())
            {
                return NoContent();
            }

            return Ok(users);
        }

        // GET: api/User/id
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetUser(Guid id)
        {
            var user = await this.service.RetrieveByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{userId:Guid}")]
        public async Task<IActionResult> PutUser(JsonElement beerIdAsJSONObj, Guid userId)
        {
            var beerId = Guid.Parse(beerIdAsJSONObj.GetProperty("beerid").GetString());
            var result = await this.service
                        .AddBeerToDrankList(beerId, userId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("userId:alpha")] // TODO: Ne vliza v tozi metod, a samo v gorniq/ FIX parameter TYPES
        public async Task<IActionResult> PutUser(JsonElement wishListInfo, string userId) // Хвърлям се през джама, честно
        {
            var id = Guid.Parse(userId);
            var wishListName = wishListInfo.GetProperty("wishlistname").GetString();
            var beerId = Guid.Parse(wishListInfo.GetProperty("beerid").GetString());
            var result = await this.service.AddBeerToWishList(beerId, id, wishListName);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }


        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUser(string userId, JsonElement wishListInfo)
        {
            var id = Guid.Parse(userId);
            var wishListName = wishListInfo.GetProperty("wishlistname").GetString();
            var result = await this.service.GetWishListBeers(id, wishListName);

            if (!result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }

        // // PUT: api/User/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutUser(Guid id, [FromBody] User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }
        //
        //    service.Entry(user).State = EntityState.Modified;
        //
        //    try
        //    {
        //        await service.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //
        //    return NoContent();
        //}
        //
        // // POST: api/User
        // // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPost]
        // public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    service.Users.Add(user);
        //    await service.SaveChangesAsync();
        //
        //    return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //}
        //
        // DELETE: api/User/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var user = await service.DeleteAsync(id);
            if (user)
            {
                return Ok();
            }
            return BadRequest();
        }
        //
        // private bool UserExists(Guid id)
        // {
        //     return service.Users.Any(e => e.Id == id);
        // }
    }
}
