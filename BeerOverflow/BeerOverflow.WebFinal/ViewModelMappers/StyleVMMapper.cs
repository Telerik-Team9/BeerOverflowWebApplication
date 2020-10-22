using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
using System.Linq;

namespace BeerOverflow.Web.ViewModelMappers
{
    public static class StyleVMMapper
    {
        public static StyleDTO GetDTO(this StyleViewModel item)
            => item == null ? null : new StyleDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Beers = item.Beers
                            .Select(x => x.GetDTO())
                            .ToList()
            };
    }
}
