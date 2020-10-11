using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerService : ICRUDSupportive<BeerDTO>
    {
        BeerDTO RetrieveByName(string name);
        BeerDTO Rate(string name, RatingDTO model);
        IEnumerable<BeerDTO> OrderByName(string order);
        IEnumerable<BeerDTO> FilterByCriteria(string criteria, string name);
    }
}
