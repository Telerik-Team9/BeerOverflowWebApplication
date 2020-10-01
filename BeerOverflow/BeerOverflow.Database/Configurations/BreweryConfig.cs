using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Database.Configurations
{
    public class BreweryConfig : IEntityTypeConfiguration<Brewery>
    {
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            builder.HasOne(br => br.Country).WithMany(c => c.Breweries).HasForeignKey(br => br.CountryId);
            //builder.Property(b => b.ABV).HasMaxLength(50);
        }
    }
}
