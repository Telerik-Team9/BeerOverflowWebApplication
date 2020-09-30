using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class Country
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Beer> Beers { get; set; } = new HashSet<Beer>();
        public ICollection<Brewery> Breweries { get; set; } = new HashSet<Brewery>();
    }
}
