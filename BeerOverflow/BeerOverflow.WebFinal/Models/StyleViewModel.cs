using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BeerOverflow.Web.Models
{
    public class StyleViewModel
    {
        public StyleViewModel() { }
        public StyleViewModel(StyleDTO item)
        {
            this.Id = item.Id;
            this.Name = item.Name;
            this.Description = item.Description;
            this.Beers = item.Beers
                    .Select(b => new BeerViewModel(b))
                    .ToList();
        }

        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public ICollection<BeerViewModel> Beers { get; set; }
    }
}
