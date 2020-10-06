using System.Linq;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.DTOMappers
{
    internal static class CountryDTOMapperExtention
    {
        internal static CountryDTO GetDTO(this Country item)
        {
           //var breweries = item.Breweries
           //    .Select(b => new BreweryDTO
           //    {
           //        Id = 
           //    });

            var countryDTO = new CountryDTO
            {
                Id = item.Id,
                Name = item.Name,
             //   Breweries = breweries
            };

            return countryDTO;
        }

        internal static Country GetModel(this CountryDTO item)
        {
          //  var breweries = item.Breweries.Select();

            var countryModel = new Country
            {
                Id = item.Id,
                Name = item.Name,
             //   Breweries = breweries
            };

            return countryModel;
        }
    }
}
