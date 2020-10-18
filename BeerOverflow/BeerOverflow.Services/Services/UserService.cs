using BeerOverflow.Database;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Services
{
    public class UserService : IUserService
    {
        private readonly BeerOverflowDbContext context;

        public UserService(BeerOverflowDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //Ali
        public Task<BeerDTO> AddBeerToDrankList(Guid beerId, Guid userId, Guid drankListId)
        {
            throw new NotImplementedException();
        }
        //Maggie
        public Task<WishListDTO> AddBeerToWishList(Guid beerId, Guid userId, string wishListName)
        {
            throw new NotImplementedException();
        }
        //Maggie
        public Task<UserDTO> CreateAsync(UserDTO DTO)
        {
            throw new NotImplementedException();
        }
        //Ali
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        //Maggie
        public Task<IEnumerable<BeerDTO>> GetDrankListBeers(Guid userId, Guid drankListId)
        {
            throw new NotImplementedException();
        }
        //Ali
        public Task<IEnumerable<BeerDTO>> GetWishListBeers(Guid userId, string wishListName)
        {
            throw new NotImplementedException();
        }
        //Redy
        public async Task<IEnumerable<UserDTO>> RetrieveAllAsync()
        {
            var users = await this.context.Users
                            .Include(u => u.Wishlists)
                            .Include(u => u.DrankList)
                            .Include(u => u.Ratings)
                            .Include(u => u.Reviews)
                            .ToListAsync();

            if (!users.Any())
            {
                throw new ArgumentNullException();
            }

            var result = users.Select(u => u.GetDTO());
            return result;
        }
        //Ali
        public Task<UserDTO> RetrieveByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        //Maggie
        public Task<UserDTO> UpdateAsync(Guid Id, UserDTO DTO)
        {
            throw new NotImplementedException();
        }
    }
}