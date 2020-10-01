using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Models
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        // wishlist?
    }
}
