using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface IReviewService // No specified in Project Requirements => not async
    {
        ReviewDTO Create(ReviewDTO DTO);
        IEnumerable<ReviewDTO> RetrieveAll();
        ReviewDTO RetrieveById(Guid id);
        ReviewDTO Update(Guid Id, ReviewDTO DTO);
        bool Delete(Guid id);
    }
}
