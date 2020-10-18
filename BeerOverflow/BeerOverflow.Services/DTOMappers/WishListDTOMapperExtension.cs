using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.DTOMappers
{
    public static class WishListDTOMapperExtension
    {
        public static WishListDTO GetDTO(this WishList item)
           => item == null ? null : new WishListDTO
           {
               Id = item.Id,
               Name = item.Name,
               BeerId = item.BeerId,
               BeerName = item.Beer?.Name,
               UserId = item.UserId,
               UserName = item.User?.UserName,
           };
    }
}
