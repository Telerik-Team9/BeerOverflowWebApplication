using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTOMappers
{
    internal static class BeerDTOMapperExtention
    {
        internal static BeerDTO GetDTO(this Beer item)
        {
            var beerDTO = new BeerDTO
            {
                Id = item.Id,
                Name = item.Name,
                ABV = item.ABV,
                Price = item.Price,
                Description = item.Description,
                ImageURL = item.ImageURL,
                Mililiters = item.Mililiters,
                IsUnlisted = item.IsUnlisted,
                IsDeleted = item.IsDeleted,
                IsBeerOfTheMonth = item.IsBeerOfTheMonth,
                StyleId = item.StyleId,
                StyleName = item.Style.Name,
                BreweryId = item.BreweryId,
                BreweryName = item.Brewery.Name
                //Reviews = b.Reviews?.Select(ReviewDTO).ToList()
            };

            return beerDTO;
        }

        internal static Beer GetModel(this BeerDTO item)
        {
            var beerModel = new Beer
            {
                Id = item.Id,
                Name = item.Name,
                ABV = item.ABV,
                Price = item.Price,
                Description = item.Description,
                ImageURL = item.ImageURL,
                Mililiters = item.Mililiters,
                IsUnlisted = item.IsUnlisted,
                IsDeleted = item.IsDeleted,
                IsBeerOfTheMonth = item.IsBeerOfTheMonth,
                StyleId = item.StyleId,
                BreweryId = item.BreweryId
                //reviews
            };

            return beerModel;
        }
    }
}
