using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using System.Linq;

namespace BeerOverflow.Web.ViewModelMappers
{
    public static class CountryVMMapperExtension
    {
        public static CountryDTO GetDTO(this CountryViewModel item)
            => item == null ? null : new CountryDTO
            {
                Id = item.Id,
                Name = item.Name,
                ISO = item.ISO,
                Breweries = item.Breweries
                                .Select(b => b.GetDTO())
                                .ToList()
            };
    }
}
