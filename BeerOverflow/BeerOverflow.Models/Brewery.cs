﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Models
{
    public class Brewery
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public Guid CountryId { get; set; }
        public ICollection<Beer> Beers { get; set; } = new List<Beer>();
        //TODO: Creatable?
    }
}
