using System;
using System.Collections.Generic;

namespace BeerOverflow.Services.DTOs
{
    public class BreweryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public ICollection<BeerDTO> Beers { get; set; } = new List<BeerDTO>();

        //public DateTime CreatedOn { get; set; }
        //public Guid CountryId { get; set; }
    }
}
