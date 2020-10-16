using BeerOverflow.Services.DTOs;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface ICountryService :
        ICRUDSupportive<CountryDTO>
    {
        Task<CountryDTO> RetrieveByNameAsync(string name);
    }
}