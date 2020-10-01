using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Models
{
    public class Beer
    {
        [Key]
        public Guid Id { get; set; }
        //[Required]
        //[StringLength(40, MinimumLength = 2)]
        public string Name { get; set; } // Validations?  
        public string ImageURL { get; set; }
        public float ABV { get; set; }
        public int Mililiters { get; set; }
        public decimal Price { get; set; } // should it be loat/double?
        public DateTime CreatedOn { get; set; }
        public bool IsUnlisted { get; set; }
        public bool IsBeerOfTheMonth { get; set; }

        public Style Style { get; set; } // Porter, Ale, Lager etc.      Should it be a class?
        public Guid StyleId { get; set; }
        public Brewery Brewery { get; set; }
        public Guid BreweryId { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        // Yo added a collecion of Wishlist ?
    }
}
