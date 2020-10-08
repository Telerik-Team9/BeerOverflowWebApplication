using BeerOverflow.Models.Abstracts;
using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class Country : Entity, IModifiable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ISO { get; set; } // Add flag URL?
        public DateTime? ModifiedOn { get; set; }

        public ICollection<Brewery> Breweries { get; set; } = new List<Brewery>();
    }
}
