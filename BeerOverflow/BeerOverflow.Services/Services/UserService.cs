using BeerOverflow.Database;
using BeerOverflow.Models;
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
        public async Task<BeerDTO> AddBeerToDrankList(Guid beerId, Guid userId)
        {
            var user = await this.context.Users
                        .FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var beer = await this.context.Beers
                        .FirstOrDefaultAsync(b => b.Id == beerId && !b.IsDeleted);

            if (beer == null)
            {
                throw new ArgumentNullException();
            }

            var dl = new DrankList
            {
                Id = Guid.NewGuid(),
                BeerId = beerId,
                UserId = userId,
            };

            await this.context.DrankList.AddAsync(dl);
            await this.context.SaveChangesAsync();

            return beer.GetDTO();
        }
        //Maggie - 
        public async Task<WishListDTO> AddBeerToWishList(Guid beerId, Guid userId, string wishListName)
        {
            var user = await this.context.Users
                        .FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var beer = await this.context.Beers
                        .FirstOrDefaultAsync(b => b.Id == beerId && !b.IsDeleted);

            if (beer == null)
            {
                throw new ArgumentNullException();
            }

            var wl = new WishList
            {
                Id = Guid.NewGuid(),
                Name = wishListName,
                BeerId = beerId,
                UserId = userId
            };

            await this.context.WishList.AddAsync(wl);
            await this.context.SaveChangesAsync();
            return wl.GetDTO();
        }
        //Maggie 
        public Task<UserDTO> CreateAsync(UserDTO DTO)
        {
            throw new NotImplementedException();
        }
        //Redy
        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await this.context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
            try
            {
                user.IsDeleted = true;
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Maggie
        public Task<IEnumerable<BeerDTO>> GetDrankListBeers(Guid userId)
        {
            throw new NotImplementedException();
        }
        //Ali - Redy
        public async Task<IEnumerable<BeerDTO>> GetWishListBeers(Guid userId, string wishListName)
        {
            var user = await this.context.Users
               .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var wishList = user.Wishlist
                .Where(x => x.Name == wishListName);

            if (wishList == null)
            {
                throw new ArgumentNullException();
            }

            return wishList.Select(w => w.Beer.GetDTO());
        }
        //Redy
        public async Task<IEnumerable<UserDTO>> RetrieveAllAsync()
        {
            var users = await this.context.Users
                            .Include(u => u.DrankList)
                            .Include(u => u.Wishlist)
                            .Include(u => u.Ratings)
                            .Include(u => u.Reviews)
                            .Where(u => !u.IsDeleted)
                            .ToListAsync();

            if (!users.Any())
            {
                throw new ArgumentNullException();
            }

            var result = users.Select(u => u.GetDTO());
            return result;
        }
        //Redy
        public async Task<UserDTO> RetrieveByIdAsync(Guid id)
        {
            var user = await this.context.Users
                            .Include(u => u.Wishlist)
                            .Include(u => u.DrankList)
                            .Include(u => u.Ratings)
                            .Include(u => u.Reviews)
                            .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            return user.GetDTO();
        }
        //Maggie
        public Task<UserDTO> UpdateAsync(Guid Id, UserDTO DTO)
        {
            throw new NotImplementedException();
        }
    }
}