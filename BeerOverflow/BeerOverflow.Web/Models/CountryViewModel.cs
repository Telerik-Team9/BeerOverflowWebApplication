using System;
using System.Collections.Generic;

namespace BeerOverflow.Web.Models
{
    public class CountryViewModel
    {
        // []
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ISO { get; set; }
        public ICollection<BreweryViewModel> Breweries { get; set; }
    }

    // Country - Id, Name, ISO, CreateOn, ModifiedOn.... 
    // Service  - Name, ISO
    // REST - Name
    // Web - Name, ISO
}
