using System;
using System.Collections.Generic;

namespace BeerOverflow.Services.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public bool IsBanned { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public int Age
        {
            get
            {
                // Save today's date.
                var today = DateTime.Today;

                // Calculate the age.
                var age = today.Year - this.BirthDate.Year;

                // Go back to the year in which the person was born in case of a leap year
                if (this.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public ICollection<RatingDTO> Ratings { get; set; } = new List<RatingDTO>();
        public ICollection<ReviewDTO> Reviews { get; set; } = new List<ReviewDTO>();

        public ICollection<WishListDTO> Wishlists { get; set; } = new List<WishListDTO>();
        public ICollection<DrankListDTO> DrankList { get; set; } = new List<DrankListDTO>();
    }
}
