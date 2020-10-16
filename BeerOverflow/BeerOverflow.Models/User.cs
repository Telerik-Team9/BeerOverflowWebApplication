using BeerOverflow.Models.Abstracts;
using BeerOverflow.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class User : IdentityUser<Guid>, IEntity, IModifiable
    {
        public bool IsBanned { get; set; }
        public DateTime BirthDate { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<WishList> Wishlists { get; set; } = new List<WishList>();
        public ICollection<DrankList> DrankList { get; set; } = new List<DrankList>();
    }
}
