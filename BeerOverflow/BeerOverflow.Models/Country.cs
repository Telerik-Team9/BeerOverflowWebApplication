using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Models
{
    public class Country
    {
        [Key]
        public Guid CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Brewery> Breweries { get; set; } = new List<Brewery>();
    }
}
