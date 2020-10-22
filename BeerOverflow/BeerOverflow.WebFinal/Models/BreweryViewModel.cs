using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Web.Models
{
    public class BreweryViewModel
    {
        public BreweryViewModel()
        {

        }

        public BreweryViewModel(BreweryDTO item)
        {
            this.Id = item.Id;
            this.Name = item.Name;
            this.CountryId = item.CountryId;
            this.CountryName = item.CountryName;
            this.Beers = item.Beers
                   .Select(b => new BeerViewModel(b))
                   .ToList();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public ICollection<BeerViewModel> Beers{ get; set; } = new List<BeerViewModel>();
    }
}
