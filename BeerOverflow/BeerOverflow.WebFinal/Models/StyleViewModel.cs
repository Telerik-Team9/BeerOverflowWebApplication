using System;

namespace BeerOverflow.Web.Models
{
    public class StyleViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public ICollection<BeerVM> Beers { get; set; } = new List<BeerVM>();

    }
}
