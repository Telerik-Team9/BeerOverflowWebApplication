using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using System.Linq;

namespace BeerOverflow.Services.DTOMappers
{
    internal static class BeerDTOMapperExtension
    {
        internal static BeerDTO GetDTO(this Beer item)
            => item == null ? null : new BeerDTO
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
                StyleName = item.Style?.Name,
                BreweryId = item.BreweryId,
                BreweryName = item.Brewery?.Name,
                Reviews = item.Reviews
                              .Select(r => r.GetDTO())
                              .ToList()
            };

        internal static Beer GetModel(this BeerDTO item)
            => item == null ? null : new Beer
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
                BreweryId = item.BreweryId,
                Reviews = item.Reviews
                              .Select(r => r.GetModel())
                              .ToList()
            };
    }
}
