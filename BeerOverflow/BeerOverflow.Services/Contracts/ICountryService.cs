using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.Contracts
{
    public interface ICountryService : ICRUDSupportive<CountryDTO>
    {
        //CRUD 
        //CountryDTO RetrieveByName(string name);
    }
}