﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface ICRUDSupportive<T> where T : class
    {
        Task<T> CreateAsync(T DTO);
        Task<IEnumerable<T>> RetrieveAllAsync();
        Task<T> RetrieveByIdAsync(Guid id);
        Task<T> UpdateAsync(Guid Id, T DTO);
        Task<bool> DeleteAsync(Guid id);
    }
}
