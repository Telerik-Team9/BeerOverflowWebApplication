using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerService : ICRUDSupportive<BeerDTO>
    {
        IEnumerable<BeerDTO> OrderByName(string order);
        IEnumerable<BeerDTO> FilterByCriteria(string criteria, string obj);
    }
}
