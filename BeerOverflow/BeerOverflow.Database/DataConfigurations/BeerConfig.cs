using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BeerOverflow.Models;

namespace BeerOverflow.Database.DataConfigurations
{
    internal class BeerConfig : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder
                .HasOne(b => b.Style)
                .WithMany(s => s.Beers)
                .HasForeignKey(b => b.StyleId);

            builder
               .HasOne(b => b.Brewery)
               .WithMany(br => br.Beers)
               .HasForeignKey(b => b.BreweryId);
            
            //Fluent API description:
            //builder.HasKey(b => b.Id);
            //builder.Property(b => b.Name)
            //       .HasMaxLength(60);
        }
    }
}
