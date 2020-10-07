using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTOs
{
    public class BeerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float ABV { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Mililiters { get; set; }
        public bool IsUnlisted { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsBeerOfTheMonth { get; set; }

        public Guid StyleId { get; set; }
        public string StyleName { get; set; } // Porter, Ale, Lager etc.
        public Guid BreweryId { get; set; }
        public string BreweryName { get; set; }
        public ICollection<ReviewDTO> Reviews { get; set; } = new List<ReviewDTO>();
        //user
    }
}
