using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;

namespace BeerOverflow.Web.ViewModelMappers
{
    public static class RatingVMMapperExtension
    {
        public static RatingDTO GetDTO(this RatingViewModel item)
            => item == null ? null : new RatingDTO
            {

                Id = item.Id,
                BeerId = item.BeerId,
                BeerName = item.BeerName,
                UserId = item.UserId,
                UserName = item.UserName,
                RatingGiven = item.RatingGiven
            };
    }
}
