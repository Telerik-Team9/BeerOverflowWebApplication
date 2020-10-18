using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTOMappers
{
    public static class DrankListDTOMapperExtension
    {   
        public static DrankListDTO GetDTO(this DrankList item)
            => item == null ? null : new DrankListDTO
            {
                Id = item.Id,
                BeerId = item.BeerId,
                BeerName = item.Beer?.Name,
                UserId = item.UserId,
                UserName = item.User?.UserName,
            };
    }
}
