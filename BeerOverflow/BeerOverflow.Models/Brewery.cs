using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class Brewery
    {
        public Guid BreweryId { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<Beer> Beers { get; set; } = new HashSet<Beer>();
        //TODO: Creatable?
    }
}
