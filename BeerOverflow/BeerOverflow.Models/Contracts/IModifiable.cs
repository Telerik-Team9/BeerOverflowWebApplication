using System;

namespace BeerOverflow.Models.Contracts
{
    public interface IModifiable
    {
        public DateTime? ModifiedOn { get; }
    }
}
