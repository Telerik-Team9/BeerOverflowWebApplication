using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services.DTOMappers
{
    internal static class CountryDTOMapperExtention
    {
        internal static CountryDTO GetDTO(this Country item)
        {
            var breweries = item.Breweries.Select();

            var countryDTO = new CountryDTO
            {
                Id = item.Id,
                Name = item.Name,
                Breweries = breweries
            };

            return countryDTO;
        }

        internal static Country GetModel(this CountryDTO item)
        {
            var breweries = item.Breweries.Select();

            var countryModel = new Country
            {
                Id = item.Id,
                Name = item.Name,
                Breweries = breweries
            };

            return countryModel;
        }
    }
}
