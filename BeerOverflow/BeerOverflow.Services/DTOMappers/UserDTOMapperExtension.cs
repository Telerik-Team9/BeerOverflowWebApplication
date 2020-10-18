using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services.DTOMappers
{
    public static class UserDTOMapperExtension
    {
        public static UserDTO GetDTO(this User item)
            => item == null ? null : new UserDTO
            {
                Id = item.Id,
                UserName = item.UserName,
                IsBanned = item.IsBanned,
                BirthDate = item.BirthDate,
                CreatedOn = item.CreatedOn,
                IsDeleted = item.IsDeleted,
                Ratings = item.Ratings
                              .Select(r => r.GetDTO())
                              .ToList(),
                Reviews = item.Reviews
                              .Select(r => r.GetDTO())
                              .ToList(),
                Wishlist = item.Wishlist
                              .Select(w => w.GetDTO())
                              .ToList(),
                DrankList = item.DrankList
                              .Select(d => d.GetDTO())
                              .ToList()
            };
    }
}
