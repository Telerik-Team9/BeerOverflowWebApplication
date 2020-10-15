using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface ICountryService : ICRUDSupportive<CountryDTO>
    {
        //CRUD 
        //CountryDTO RetrieveByName(string name);

        public Task<CountryDTO> RetrieveByIdAsync(Guid id); // MOVE TO CRUD SUPPORTIVE

        public Task<IEnumerable<CountryDTO>> RetrieveAllAsync();

        public Task<CountryDTO> UpdateAsync(Guid Id, CountryDTO countryDTO);

        public Task<bool> DeleteAsync(Guid id);

        public Task<CountryDTO> CreateAsync(CountryDTO countryDTO);

        public Task<CountryDTO> RetrieveByNameAsync(string name);




    }
}