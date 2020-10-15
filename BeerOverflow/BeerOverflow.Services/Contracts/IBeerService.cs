using BeerOverflow.Services.DTOs;
using System.Collections.Generic;

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
    }
}
