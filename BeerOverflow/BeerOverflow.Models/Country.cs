using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class Country : IEntity, IModifiable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public ICollection<Brewery> Breweries { get; set; } = new List<Brewery>();
    }
}
