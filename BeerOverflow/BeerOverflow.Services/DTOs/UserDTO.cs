using System;
using System.Collections.Generic;

namespace BeerOverflow.Services.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public bool IsBanned { get; set; }
        public DateTime BirthDate { get; set; }
        //age
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

       public ICollection<ReviewDTO> Reviews { get; set; } = new List<ReviewDTO>();
      // public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
      // public ICollection<WishList> Wishlists { get; set; } = new List<WishList>();
      // public ICollection<DrankList> DrankList { get; set; } = new List<DrankList>();
    }
}
