using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.ViewModelMappers
{
    public static class BeerVMMapperExtension
    {
        public static BeerDTO GetDTO(this BeerViewModel item)
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
                StyleName = item.StyleName,
                BreweryId = item.BreweryId,
                BreweryName = item.BreweryName,
                Reviews = item.Reviews
                              .Select(r => r.GetDTO())
                              .ToList(),
                Ratings = item.Ratings
                              .Select(r => r.GetDTO())
                              .ToList()
            };
    }
}
