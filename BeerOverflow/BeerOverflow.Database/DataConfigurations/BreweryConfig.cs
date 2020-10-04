using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BeerOverflow.Models;

namespace BeerOverflow.Database.DataConfigurations
{
    internal class BreweryConfig : IEntityTypeConfiguration<Brewery>
    {
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            builder
                 .HasOne(b => b.Country)
                 .WithMany(c => c.Breweries)
                 .HasForeignKey(c => c.CountryId);
        }
    }
}
