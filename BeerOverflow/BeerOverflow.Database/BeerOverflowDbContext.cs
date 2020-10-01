using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Database.Configurations;

namespace BeerOverflow.Database
{
    public class BeerOverflowDbContext : IdentityDbContext<User, Role, Guid>
    {
        public BeerOverflowDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries{ get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Style> Styles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BeerConfig());
            builder.ApplyConfiguration(new BreweryConfig());
            builder.ApplyConfiguration(new ReviewConfig());

            base.OnModelCreating(builder);
        }
    }
}