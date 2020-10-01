using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeerOverflow.Models
{
    public class Style
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Beer> Beers { get; set; } = new List<Beer>();
    }
}
