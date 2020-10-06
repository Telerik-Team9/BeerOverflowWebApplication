using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using System.Linq;

namespace BeerOverflow.Services.DTOMappers
{
    internal static class StyleDTOMapperExtension
    {
        internal static StyleDTO GetDTO(this Style item)
            => item == null ? null : new StyleDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Beers = item.Beers
                    .Select(b => b.GetDTO())
                    .ToList()
            };

        internal static Style GetModel(this StyleDTO item)
            => item == null ? null : new Style
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Beers = item.Beers
                    .Select(b => b.GetModel())
                    .ToList()
            };
    }
}
