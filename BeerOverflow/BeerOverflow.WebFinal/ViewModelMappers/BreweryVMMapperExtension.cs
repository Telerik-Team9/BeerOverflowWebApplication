using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using System.Linq;

namespace BeerOverflow.Web.ViewModelMappers
{
    public static class BreweryVMMapperExtension
    {
        public static BreweryDTO GetDTO(this BreweryViewModel item)
            => item == null ? null : new BreweryDTO
            {
                Id = item.Id,
                Name = item.Name,
                CountryId = item.CountryId,
                CountryName = item.CountryName,
                Beers = item.Beers
                   .Select(b => b.GetDTO())
                   .ToList()
            };
    }
}
