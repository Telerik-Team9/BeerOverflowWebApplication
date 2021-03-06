﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BeerOverflow.Models;

namespace BeerOverflow.Database.DataConfigurations
{
    internal class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder) 
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .HasMaxLength(40);

            builder.HasIndex(c => c.Name)
                   .IsUnique(true); //TODO: ask later
        }
    }
}
