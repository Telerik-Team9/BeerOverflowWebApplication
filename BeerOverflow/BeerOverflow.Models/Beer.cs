using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeerOverflow.Models.Contracts;
using static BeerOverflow.Models.Common.ModelsConstants;

namespace BeerOverflow.Models
{
    public class Beer : IEntity, IModifiable, IReviewable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Range(ABVMinPercent, ABVMaxPercent)]
        public float ABV { get; set; }
        [Range(PriceMin, PriceMax)]
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Mililiters { get; set; }
        public bool IsUnlisted { get; set; }
        public bool IsBeerOfTheMonth { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Guid StyleId { get; set; }
        public Style Style { get; set; } // Porter, Ale, Lager etc.
        public Guid BreweryId { get; set; }
        public Brewery Brewery { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        // Yo added a collecion of Wishlist ?

    }
}