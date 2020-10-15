using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IStyleService
                   : ICRUDSupportive<StyleDTO>
    {
        //CRUD Operations

        public Task<StyleDTO> CreateAsync(StyleDTO DTO);

        public Task<StyleDTO> RetrieveByIdAsync(Guid id);

        public Task<IEnumerable<StyleDTO>> RetrieveAllAsync();

        public Task<StyleDTO> UpdateAsync(Guid Id, StyleDTO DTO);

        public Task<bool> DeleteAsync(Guid id);


    }
}
