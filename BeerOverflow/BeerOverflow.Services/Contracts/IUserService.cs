using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IUserService
                   : ICRUDSupportive<UserDTO>
    {
        Task<WishListDTO> AddBeerToWishList(Guid beerId, Guid userId, string wishListName);
        Task<BeerDTO> AddBeerToDrankList(Guid beerId, Guid userId);
        Task<IEnumerable<BeerDTO>> GetWishListAsync(Guid userId, string wishListName);
        Task<IEnumerable<BeerDTO>> GetDrankListAsync(Guid userId);
        Task<IEnumerable<string>> GetWishListNamesAsync(Guid userId);
        Task<BeerDTO> AddReviewToBeer(Guid beerId, Guid userId, string content);
        Task<Dictionary<string, List<UserDTO>>> RetrieveAllByRolesAsync();
        Task<bool> BanAsync(Guid userId);
        Task<(bool, bool)> IsLegitAsync(string userEmail);
    }
}
