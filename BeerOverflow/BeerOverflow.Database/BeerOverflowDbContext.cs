using System;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Models;
using BeerOverflow.Database.DataConfigurations;
using System.Reflection;
using BeerOverflow.Database.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BeerOverflow.Database
{
    public class BeerOverflowDbContext : IdentityDbContext<User, Role, Guid>
    {
        public BeerOverflowDbContext(DbContextOptions options)
             : base(options)
        {
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        //TODO: Add User/Role DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Reflection here
            //Reflection that replaces this
            //modelBuilder.ApplyConfiguration(new BeerConfig());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
            modelBuilder.Seed();
        }
    }
}