using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class Brewery : IEntity, IModifiable // + IReviewable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Beer> Beers { get; set; } = new List<Beer>();
    }
}
