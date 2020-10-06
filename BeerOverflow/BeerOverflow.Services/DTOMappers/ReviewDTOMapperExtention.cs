using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.DTOMappers
{
    internal static class ReviewDTOMapperExtention
    {
        internal static ReviewDTO GetDTO(this Review item)
        {
            var reviewDTO = new ReviewDTO
            {
                Id = item.Id,
                Content = item.Content,
                Rating = item.Rating,
                Likes = item.Likes,
                IsFlagged = item.IsFlagged,
                CreatedOn = item.CreatedOn,
                BeerId = item.BeerId,
                BeerName = item.Beer?.Name
            };

            return reviewDTO;
        }

        internal static Review GetModel(this ReviewDTO item)
        {
            var review = new Review
            {
                Id = item.Id,
                Content = item.Content,
                Rating = item.Rating,
                Likes = item.Likes,
                IsFlagged = item.IsFlagged,
                CreatedOn = item.CreatedOn,
                BeerId = item.BeerId
            };

            return review;
        }
    }
}
