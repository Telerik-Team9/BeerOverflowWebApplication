using BeerOverflow.Models.Abstracts;
using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class Style : Entity, IModifiable
    {
        // [Key]
        public Guid Id { get; set; }

        // [Required]
        // [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        // [MaxLength(StyleDescriptionMaxLength)]
        public string Description { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public ICollection<Beer> Beers { get; set; } = new List<Beer>();
    }
}
