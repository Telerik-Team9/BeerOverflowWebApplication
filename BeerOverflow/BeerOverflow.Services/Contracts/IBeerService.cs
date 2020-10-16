using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerService : ICRUDSupportive<BeerDTO>
    {
        BeerDTO RetrieveByName(string name);
        BeerDTO Rate(string name, RatingDTO model);
        IEnumerable<BeerDTO> OrderByABV(char order);
        IEnumerable<BeerDTO> OrderByName(char order);
        IEnumerable<BeerDTO> OrderByRating(char order);
        IEnumerable<BeerDTO> FilterByCriteria(string criteria, string name);


        Task<BeerDTO> CreateAsync(BeerDTO DTO);
        Task<BeerDTO> RetrieveByIdAsync(Guid id);
        Task<IEnumerable<BeerDTO>> RetrieveAllAsync();
        Task<BeerDTO> UpdateAsync(Guid Id, BeerDTO DTO);
        Task<bool> DeleteAsync(Guid id);
        Task<BeerDTO> RetrieveByNameAsync(string name);


        Task<BeerDTO> RateAsync(string name, RatingDTO model);
        Task<IEnumerable<BeerDTO>> OrderByABVAsync(char order);
        Task<IEnumerable<BeerDTO>> OrderByNameAsync(char order);
        Task<IEnumerable<BeerDTO>> OrderByRatingAsync(char order);
        Task<IEnumerable<BeerDTO>> FilterByCriteriaAsync(string criteria, string name);
    }
}
