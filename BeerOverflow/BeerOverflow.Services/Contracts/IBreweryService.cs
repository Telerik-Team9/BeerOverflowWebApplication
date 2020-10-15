using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IBreweryService : ICRUDSupportive<BreweryDTO>
    {
        public Task<BreweryDTO> CreateAsync(BreweryDTO DTO);

        public Task<BreweryDTO> RetrieveByIdAsync(Guid id);

        public Task<BreweryDTO> UpdateAsync(Guid Id, BreweryDTO DTO);

        public Task<bool> DeleteAsync(Guid id);

        public Task<IEnumerable<BreweryDTO>> RetrieveAllAsync();

    }
}
