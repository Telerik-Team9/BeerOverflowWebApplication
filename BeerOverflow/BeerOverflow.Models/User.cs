using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsBanned { get; set; }
        public bool IsAdmin { get; set; } 

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        // wishlist?
    }
}
