using System;

namespace BeerOverflow.Web.Models
{
    public class CountryViewModel
    {
        // []
        public Guid Id { get; set; }        
        public string Name { get; set; }
    }

    // Country - Id, Name, ISO, CreateOn, ModifiedOn.... 
    // Service  - Name, ISO
    // REST - Name
    // Web - Name, ISO
}
