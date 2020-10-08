using System;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Models;
using BeerOverflow.Database.DataConfigurations;

namespace BeerOverflow.Database
{
    public class BeerOverflowDbContext : DbContext
    {
        public BeerOverflowDbContext(DbContextOptions options)
             : base(options) { }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Style> Styles { get; set; }
        //TODO: Add User/Role DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Reflection here
            modelBuilder.ApplyConfiguration(new BeerConfig());
            modelBuilder.ApplyConfiguration(new BreweryConfig());
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            modelBuilder.ApplyConfiguration(new StyleConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}