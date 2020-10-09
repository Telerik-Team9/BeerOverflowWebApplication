using System;
using System.Collections.Generic;

namespace BeerOverflow.Web.Models
{
    public class BeerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float ABV { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Mililiters { get; set; }
        public bool IsUnlisted { get; set; }
        public bool IsDeleted { get; set; } // TODO: da se mahne li tva
        public bool IsBeerOfTheMonth { get; set; }

        public Guid StyleId { get; set; }
        public string StyleName { get; set; } // Porter, Ale, Lager etc.
        public Guid BreweryId { get; set; }
        public string BreweryName { get; set; }
        public ICollection<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();
    }
}
