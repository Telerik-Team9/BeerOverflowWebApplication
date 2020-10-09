using System;
using System.Collections.Generic;

namespace BeerOverflow.Services.DTOs
{
    public class CountryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ISO { get; set; }
        public ICollection<BreweryDTO> Breweries { get; set; } = new List<BreweryDTO>();
    }
}
