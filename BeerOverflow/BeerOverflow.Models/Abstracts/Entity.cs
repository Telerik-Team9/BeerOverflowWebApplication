using BeerOverflow.Models.Contracts;
using System;

namespace BeerOverflow.Models.Abstracts
{
    public abstract class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
