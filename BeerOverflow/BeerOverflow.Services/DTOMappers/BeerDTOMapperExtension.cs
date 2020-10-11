using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using System;
using System.Linq;

namespace BeerOverflow.Services.DTOMappers
{
    public static class BeerDTOMapperExtension
    {
        public static BeerDTO GetDTO(this Beer item)
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
                              .ToList(),
                Ratings = item.Ratings
                              .Select(r => r.GetDTO())
                              .ToList()
            };

        public static Beer GetModel(this BeerDTO item)
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
                              .ToList(),
                Ratings = item.Ratings
                              .Select(r => r.GetModel())
                              .ToList()
            };

        public static object GetModelAsObject(this BeerDTO item)
            => item == null ? null :
                new
                {
                    Id = item.Id,
                    Name = item.Name,
                    ABV = item.ABV,
                    Price = Math.Round(item.Price, 2),
                    Description = item.Description,
                    ImageURL = item.ImageURL,
                    Mililiters = item.Mililiters,
                    IsBeerOfTheMonth = item.IsBeerOfTheMonth,
                    StyleName = item.StyleName,
                    BreweryName = item.BreweryName,
                    Reviews = item.Reviews.Select(r => new
                    {
                        Content = r.Content,
                        Likes = r.Likes,
                        CreatedOn = r.CreatedOn
                    }),
                    Ratings = item.Ratings.Select(r => new
                    {
                        UserId = r.UserId, //TODO: Maybe UserName?
                        RatingGiven = r.RatingGiven
                    })
                };
    }
}
