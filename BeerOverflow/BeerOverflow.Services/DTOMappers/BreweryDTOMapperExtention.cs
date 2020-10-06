using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services.DTOMappers
{
    internal static class BreweryDTOMapperExtention
    {
        internal static BreweryDTO GetDTO(this Brewery item)
        {
            //var beers = item.Beers.Select();

            var breweryDTO = new BreweryDTO
            {
                Id = item.Id,
                Name = item.Name,
                CountryId = item.CountryId,
                CountryName = item.Country.Name
                //Beers = beers
            };

            return breweryDTO;
        }

        internal static Brewery GetModel(this BreweryDTO item)
        {
            //var beers = item.Beers.Select();

            var brewery = new Brewery
            {
                Id = item.Id,
                Name = item.Name,
                CountryId = item.CountryId
                //Beers = beers
            };

            return brewery;
        }
    }
}
