using BeerOverflow.Models;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Services.DTOs
{
    public class CountryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Brewery> Breweries { get; set; } = new List<Brewery>();

    }
}
