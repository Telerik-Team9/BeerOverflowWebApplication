using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Web.Models
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {
        }

        public CountryViewModel(CountryDTO item)
        {
            Id = item.Id;
            Name = item.Name;
            ISO = item.ISO;
            Breweries = item.Breweries.Select(br => new BreweryViewModel(br)).ToList();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ISO { get; set; }
        public ICollection<BreweryViewModel> Breweries { get; set; }
    }
}
