using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.DTOMappers
{
    internal static class RatingDTOMapper
    {
        internal static RatingDTO GetDTO(this Rating item)
            => item == null ? null : new RatingDTO
            {
                Id = item.Id,
                BeerId = item.BeerId,
                BeerName = item.Beer?.Name,
                UserId = item.UserId,
                UserName = item.User?.UserName,
                RatingGiven = item.RatingGiven
            };

        internal static Rating GetModel(this RatingDTO item)
            => item == null ? null : new Rating
            {
                Id = item.Id,
                BeerId = item.BeerId,
                UserId = item.UserId,
                RatingGiven = item.RatingGiven
            };
    }
}
