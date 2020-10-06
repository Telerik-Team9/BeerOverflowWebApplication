using System.Linq;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.DTOMappers
{
    internal static class BreweryDTOMapperExtension
    {
        internal static BreweryDTO GetDTO(this Brewery item)
           => item == null ? null : new BreweryDTO
             {
                 Id = item.Id,
                 Name = item.Name,
                 CountryId = item.CountryId,
                 CountryName = item.Country?.Name,
                 Beers = item.Beers
                     .Select(b => b.GetDTO())
                     .ToList()
             };

        internal static Brewery GetModel(this BreweryDTO item)
           => item == null ? null : new Brewery
        {
            Id = item.Id,
            Name = item.Name,
            CountryId = item.CountryId,
            Beers = item.Beers
                   .Select(b => b.GetModel())
                   .ToList()
        };
    }
}
