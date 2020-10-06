using System;
using System.Collections.Generic;

namespace BeerOverflow.Services.DTOs
{
    public class StyleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<BeerDTO> Beers { get; set; }
    }
}
