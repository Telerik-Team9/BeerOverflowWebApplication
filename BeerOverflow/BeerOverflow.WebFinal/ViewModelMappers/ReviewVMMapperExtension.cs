using BeerOverflow.Services.DTOs;
using BeerOverflow.Web.Models;
namespace BeerOverflow.Web.ViewModelMappers
{
    public static class ReviewVMMapperExtension
    {
        public static ReviewDTO GetDTO(this ReviewViewModel item)
            => item == null ? null : new ReviewDTO
            {
                Id = item.Id,
                Content = item.Content,
                //Rating = item.Rating,
                Likes = item.Likes,
                BeerId = item.BeerId,
                BeerName = item.BeerName,
                UserId = item.UserId,
                UserName = item.UserName,
            };
    }
}
