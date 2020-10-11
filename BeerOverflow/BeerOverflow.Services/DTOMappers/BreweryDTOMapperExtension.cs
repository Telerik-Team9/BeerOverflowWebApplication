using System.Linq;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.DTOMappers
{
    public static class BreweryDTOMapperExtension
    {
        public static BreweryDTO GetDTO(this Brewery item)
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

        public static Brewery GetModel(this BreweryDTO item)
           => item == null ? null : new Brewery
           {
               Id = item.Id,
               Name = item.Name,
               CountryId = item.CountryId,
               Beers = item.Beers
                      .Select(b => b.GetModel())
                      .ToList()
           };

        public static object GetModelAsObject(this BreweryDTO item)
            => item == null ? null : new
            {
                Id = item.Id,
                Name = item.Name,
                Country = item.CountryName,
                Beers = item.Beers.Select(b => new
                {
                    Beer = b.Name
                })
            };
    }
}
