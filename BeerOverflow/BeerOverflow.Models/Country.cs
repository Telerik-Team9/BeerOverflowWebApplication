using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeerOverflow.Models.Contracts;
using static BeerOverflow.Models.Common.ModelsConstants;

namespace BeerOverflow.Models
{
    public class Country : IEntity, IModifiable
    {
        [Key]
        public Guid CountryId { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public ICollection<Brewery> Breweries { get; set; } = new List<Brewery>();
    }
}
