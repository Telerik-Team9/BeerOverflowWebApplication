using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Database.DataConfigurations
{
    internal class StyleConfig : IEntityTypeConfiguration<Style>
    {
        public void Configure(EntityTypeBuilder<Style> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(b => b.Name)
                   .IsRequired(true)
                   .HasMaxLength(40);

            builder.Property(s => s.Description)
                   .HasMaxLength(1000);
        }
    }
}
