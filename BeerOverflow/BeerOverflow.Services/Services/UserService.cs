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

            if (user.DrankList.FirstOrDefault(d => d.UserId == userId && d.BeerId == beerId) != null)
            {
                return beer.GetDTO();
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

        public async Task<BeerDTO> AddReviewToBeer(Guid beerId, Guid userId, string content)
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

            var review = new Review
            {
                Id = Guid.NewGuid(),
                Content = content,
                BeerId = beerId,
                UserId = userId,
                CreatedOn = DateTime.UtcNow
            };

            await this.context.Reviews.AddAsync(review);
            //await this.context.Update(beer);
            await this.context.SaveChangesAsync();

            return beer.GetDTO();
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
        public async Task<IEnumerable<BeerDTO>> GetDrankListAsync(Guid userId)
        {
            var user = await this.context.Users
               .Include(u => u.DrankList)
               .FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            /* var dranklist = user.DrankList
                 .Where(x => x.Name.ToLower() == dranklist.ToLower());*/

            if (user.DrankList == null)
            {
                throw new ArgumentNullException();
            }

            var dranklist = user.DrankList.Select(d => d.Beer = this.context.Beers.First(b => b.Id == d.BeerId));

            return dranklist.Select(d => d.GetDTO());
        }
        //Ali - Redy
        public async Task<IEnumerable<BeerDTO>> GetWishListAsync(Guid userId, string wishListName = "default")
        {
            var user = await this.context.Users
               .Include(u => u.Wishlist).ThenInclude(wl => wl.Beer)
               .FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var wishList = user.Wishlist
                .Where(x => x.Name.ToLower() == wishListName.ToLower());

            if (wishList == null)
            {
                throw new ArgumentNullException();
            }

            return wishList.Select(w => w.Beer.GetDTO());
        }

        public async Task<IEnumerable<string>> GetWishListNamesAsync(Guid userId)   // TODO: Added functionality for later updates
        {
            var user = await this.context.Users
              .Include(u => u.Wishlist).ThenInclude(wl => wl.Beer)
              .FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var wishList = user.Wishlist.Select(wl => wl.Name).ToHashSet<string>();

            if (wishList == null)
            {
                throw new ArgumentNullException();
            }

            return wishList;
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
        public async Task<UserDTO> UpdateAsync(Guid id, UserDTO DTO)
        {
            var user = await this.context.Users
                                         .Include(b => b.Ratings)
                                         .Include(b => b.Reviews)
                                         .Include(b => b.Wishlist)
                                         .Include(b => b.DrankList)
                                         .FirstOrDefaultAsync(beer => beer.Id == id);

            if (user == null)
            {
                throw new ArgumentException();      //TODO: ex
            }

            user.IsBanned = DTO.IsBanned;

            await this.context.SaveChangesAsync();

            return DTO;
        }

        public async Task<Dictionary<string, List<UserDTO>>> RetrieveAllByRolesAsync()
        {
            var roles = await this.context.Roles.ToListAsync();

            var users = await this.context.Users
                            .Include(u => u.DrankList)
                            .Include(u => u.Wishlist)
                            .Include(u => u.Ratings)
                            .Include(u => u.Reviews)
                            .Where(u => !u.IsDeleted)
                            .ToListAsync();

            var userRoles = await this.context.UserRoles.ToListAsync();

            var dict = new Dictionary<string, List<UserDTO>>();

            foreach (var currUserRole in userRoles)
            {
                var user = users.FirstOrDefault(u => u.Id == currUserRole.UserId);
                var role = roles.FirstOrDefault(r => r.Id == currUserRole.RoleId);

                if (user == null || role == null)
                {
                    throw new ArgumentException();
                }

                if (!dict.ContainsKey(role.Name))
                {
                    dict.Add(role.Name, new List<UserDTO>() { user.GetDTO() });
                    continue;
                }

                dict[role.Name].Add(user.GetDTO());
            }

            return dict;
        }
    }
}


