using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Database.Configurations
{
    public class BeerConfig : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.HasOne(b => b.Brewery).WithMany(br => br.Beers).HasForeignKey(b => b.BreweryId);
            builder.HasOne(b => b.Style).WithMany(s => s.Beers).HasForeignKey(b => b.StyleId);
        }
    }
}
