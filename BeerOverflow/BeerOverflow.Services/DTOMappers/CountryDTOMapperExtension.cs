using System.Linq;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.DTOMappers
{
    public static class CountryDTOMapperExtension
    {
        public static CountryDTO GetDTO(this Country item)
             => item == null ? null : new CountryDTO
             {
                 Id = item.Id,
                 Name = item.Name,
                 ISO = item.ISO,
                 Breweries = item.Breweries
                             .Select(b => b.GetDTO())
                             .ToList()
             };

        public static Country GetModel(this CountryDTO item)
             => item == null ? null : new Country
             {
                 Id = item.Id,
                 Name = item.Name,
                 ISO = item.ISO,
                 Breweries = item.Breweries
                                      .Select(b => b.GetModel())
                                      .ToList()
             };

        public static object GetModelAsObject(this CountryDTO item)
            => item == null ? null : new
            {
                Id = item.Id,
                Name = item.Name,
                ISO = item.ISO,
                Breweries = item.Breweries.Select(b => new
                {
                    BreweryId = b.Id,
                    BreweryName = b.Name
                })
            };
    }
}
