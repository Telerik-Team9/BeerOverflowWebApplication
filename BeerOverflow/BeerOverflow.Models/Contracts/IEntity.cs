using System;

namespace BeerOverflow.Models.Contracts
{
    public interface IEntity
    {
        public DateTime CreatedOn { get; }
        public bool IsDeleted { get; }
        public DateTime? DeletedOn { get; }
    }
}
