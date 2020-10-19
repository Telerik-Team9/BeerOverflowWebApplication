using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

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
        }   //DONE!

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
        }   //DONE!

        [HttpGet("getwishlist/{userId}")]   // Get Wishlist beers
        public async Task<ActionResult> GetUser(Guid userId, [FromQuery] string wishListName)
        {
            var result = await this.service.GetWishListAsync(userId, wishListName);

            if (!result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }   //DONE!

        [HttpGet("getdranklist/{userId}")]   // Get Dranklist beers
        public async Task<ActionResult> GetUserDrankList(Guid userId)
        {
            var result = await this.service.GetDrankListAsync(userId);

            if (!result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }   //DONE!

        [HttpPut("{userId:Guid}")]  // Add beer to DrankList    //DONE!
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

        [HttpPut("addtowishlist/{userId}")]     // Add beer to Wishlist    DONE!
        public async Task<IActionResult> PutUser(JsonElement wishListInfo, string userId) // Хвърлям се през джама, честно
        {
            var id = Guid.Parse(userId);
            var wishListName = wishListInfo.GetProperty("wishlistname").GetString();

            var asd = wishListInfo.GetProperty("beerid").GetString();

            var beerId = Guid.Parse(asd);
            var result = await this.service.AddBeerToWishList(beerId, id, wishListName);

            if (result == null)
            {
                return BadRequest();
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

        [HttpPut("banuser/{userId:Guid}")]  // Ban user
        public async Task<IActionResult> BanUser(Guid userId)
        {
            var result = await this.service
                        .UpdateAsync(userId, new UserDTO
                        {
                            IsBanned = true
                        });

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var user = await service.DeleteAsync(id);
            if (user)
            {
                return Ok();
            }
            return BadRequest();
        }   //DONE
        //
        // private bool UserExists(Guid id)
        // {
        //     return service.Users.Any(e => e.Id == id);
        // }
    }
}
