using System;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface ICRUDSupportive<T> where T : class
    {
        T Create(T DTO);
        IEnumerable<T> RetrieveAll();
        T RetrieveById(Guid id);
        T Update(Guid Id, T DTO);
        bool Delete(Guid id);
    }
}
