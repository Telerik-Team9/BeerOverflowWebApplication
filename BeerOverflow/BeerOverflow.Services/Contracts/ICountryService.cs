using System;
using System.Collections.Generic;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.Contracts
{
    public interface ICountryService
    {
        //CRUD operations
        IEnumerable<CountryDTO> GetAllCountries();
        CountryDTO Create(CountryDTO countryDTO);
        CountryDTO RetrieveById(Guid Id);
        CountryDTO Update(Guid Id, CountryDTO countryDTO);
        bool Delete(Guid Id);
    }
}