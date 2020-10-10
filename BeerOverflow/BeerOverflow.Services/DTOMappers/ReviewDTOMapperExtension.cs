using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.DTOMappers
{
    internal static class ReviewDTOMapperExtension
    {
        internal static ReviewDTO GetDTO(this Review item)
             => item == null ? null : new ReviewDTO
             {
                 Id = item.Id,
                 Content = item.Content,
                 Likes = item.Likes,
                 IsFlagged = item.IsFlagged,
                 CreatedOn = item.CreatedOn,
                 BeerId = item.BeerId,
                 BeerName = item.Beer?.Name
             };

        internal static Review GetModel(this ReviewDTO item)
             => item == null ? null : new Review
             {
                 Id = item.Id,
                 Content = item.Content,
                 Likes = item.Likes,
                 IsFlagged = item.IsFlagged,
                 CreatedOn = item.CreatedOn,
                 BeerId = item.BeerId
             };
    }
}
