using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerService : ICRUDSupportive<BeerDTO>
    {
        Task<BeerDTO> RetrieveByNameAsync(string name);
        Task<BeerDTO> RateAsync(string name, RatingDTO model);
        Task<IEnumerable<BeerDTO>> OrderByABVAsync(char order);
        Task<IEnumerable<BeerDTO>> OrderByNameAsync(char order);
        Task<IEnumerable<BeerDTO>> OrderByRatingAsync(char order);
        Task<IEnumerable<BeerDTO>> FilterByCriteriaAsync(string criteria, string name);
        Task<IEnumerable<BeerDTO>> SearchAsync(string name, string styleFilter, string sortBy);

    }
}
