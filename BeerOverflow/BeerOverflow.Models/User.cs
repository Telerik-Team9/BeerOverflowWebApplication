using BeerOverflow.Models.Abstracts;
using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class User : Entity, IModifiable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsBanned { get; set; }
        public bool IsAdmin { get; set; }

        public DateTime? ModifiedOn { get; set; }
        
        public ICollection<Review> Reviews { get; set; } = new List<Review>(); 
        //public ICollection<Wishlist> Wishlist { get; set; } = new List<Wishlist>();
    }
}
