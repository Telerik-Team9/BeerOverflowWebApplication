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
            this.context = context;
        }

        public Task<UserDTO> CreateAsync(UserDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> RetrieveAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> RetrieveByIdAsync(Guid id)
        {
            var user = await this.context.Users
                                 .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var userDTO = new UserDTO()
            {
                Id = user.Id,
                IsBanned = user.IsBanned,
                BirthDate = user.BirthDate,
                CreatedOn = user.CreatedOn,
                IsDeleted = user.IsDeleted,
                DeletedOn = user.DeletedOn,
                ModifiedOn = user.ModifiedOn,
                Reviews = user.Reviews?.Select(r => r.GetDTO()).ToList()
            };

            return userDTO;
        }

        public Task<UserDTO> UpdateAsync(Guid Id, UserDTO DTO)
        {
            throw new NotImplementedException();
        }
    }
}
