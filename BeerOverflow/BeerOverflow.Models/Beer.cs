using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    class Beer
    {
        public Guid BeerID { get; set; }

        public string Name { get; set; } // Validations?  

        public string Type { get; set; } // Porter, Ale, Lager etc.      Should it be a class?

        public string ImageURL { get; set; }

        public float AlcoholPercent { get; set; }

        public decimal Price { get; set; } // should it be loat/double?

        public Country Country { get; set; }

        public Guid CountryId { get; set; } // same

        public Brewery Brewery { get; set; }

        public Guid BreweryId { get; set; } // Yo put both Brewery and BreweryID ?

        public DateTime CreatedOn { get; set; }

        public int Mililiters { get; set; }

        public bool IsUnlisted { get; set; }

        public bool IsBeerOfTheMonth { get; set; }

        // public ICollection<Review> Reviews { get; set; } = new List<Review>(); --> or hashset?

        // Yo added a collecion of Wishlist ?
    }
}
