using System.Linq;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.DTOMappers
{
    internal static class CountryDTOMapperExtention
    {
        internal static CountryDTO GetDTO(this Country item)
             => item == null ? null : new CountryDTO
             {
                 Id = item.Id,
                 Name = item.Name,
                 Breweries = item.Breweries
                             .Select(b => b.GetDTO())
                             .ToList()
             };

        internal static Country GetModel(this CountryDTO item)
             => item == null ? null : new Country
             {
                 Id = item.Id,
                 Name = item.Name,
                 Breweries = item.Breweries
                                      .Select(b => b.GetModel())
                                      .ToList()
             };
    }
}
