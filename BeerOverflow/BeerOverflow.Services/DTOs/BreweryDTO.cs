using System;

namespace BeerOverflow.Services.DTOs
{
    public class BreweryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public DateTime CreatedOn { get; set; }
        //public Guid CountryId { get; set; }
        //public Country Country { get; set; } - DTO
        //public ICollection<Beer> Beers { get; set; } = new List<Beer>(); List<BeerDTO>();
    }
}
