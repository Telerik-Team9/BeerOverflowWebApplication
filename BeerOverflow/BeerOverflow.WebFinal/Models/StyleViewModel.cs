using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Web.Models
{
    public class StyleViewModel
    {
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
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<BeerViewModel> Beers { get; set; }

    }
}
