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
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(Guid id)
        {
            var user = await this.service.RetrieveByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
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
