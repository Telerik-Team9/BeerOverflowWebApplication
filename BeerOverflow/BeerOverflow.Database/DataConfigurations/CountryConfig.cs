﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BeerOverflow.Models;

namespace BeerOverflow.Database.DataConfigurations
{
    internal class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder) 
        {
        }
    }
}
