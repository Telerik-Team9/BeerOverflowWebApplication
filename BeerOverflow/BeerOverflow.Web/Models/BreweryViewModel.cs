using System;
using System.Collections.Generic;

namespace BeerOverflow.Web.Models
{
    public class BreweryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        //public ICollection<BeerViewModel> Beers{ get; set; }
        public ICollection<CountryViewModel> Countries { get; set; } // 1 brewery - many countries?

    }
}
