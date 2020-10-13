using BeerOverflow.Database;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Services.Services
{
    public class BeerService : IBeerService
    {
        private readonly BeerOverflowDbContext context;

        public BeerService(BeerOverflowDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public BeerDTO Create(BeerDTO DTO)
        {
            var brewery = this.context.Breweries
                            .Where(br => br.Name == DTO.BreweryName)
                            .FirstOrDefault(br => !br.IsDeleted);

            var style = this.context.Styles
                         .Where(s => s.Name == DTO.StyleName)
                         .FirstOrDefault(s => !s.IsDeleted);

            if (brewery == null || style == null)
            {
                throw new ArgumentNullException();
            }

            DTO.BreweryId = this.context
                .Breweries
                .FirstOrDefault(br => br.Name == DTO.BreweryName).Id;
            DTO.StyleId = this.context
                .Styles
                .FirstOrDefault(s => s.Name == DTO.StyleName).Id;

            this.context.Beers.Add(DTO.GetModel());
            this.context.SaveChanges();
            return DTO;
        }

        public bool Delete(Guid id)
        {
            try
            {
                var beerToDelete = this.context.Beers
                    .FirstOrDefault(b => b.Id == id);

                beerToDelete.IsDeleted = true;
                beerToDelete.DeletedOn = DateTime.Now; // TODO: Should we use provider here?
                this.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<BeerDTO> RetrieveAll()
            => this.context.Beers
                     .Include(b => b.Brewery)
                     .Include(b => b.Style)
                     .Include(b => b.Reviews)
                     .Include(b => b.Ratings)
                     .Where(b => !b.IsDeleted)
                     .Select(b => b.GetDTO());

        public IEnumerable<BeerDTO> OrderByName(string order)
            => order == "desc" ? this.RetrieveAll().OrderByDescending(b => b.Name)
                               : this.RetrieveAll().OrderBy(b => b.Name);

        public BeerDTO RetrieveById(Guid id)
            => this.context.Beers
                     .Include(b => b.Brewery)
                     .Include(b => b.Style)
                     .Include(b => b.Reviews)
                     .Include(b => b.Ratings)
                     .Where(b => !b.IsDeleted)
                     .FirstOrDefault(b => b.Id == id)
                     .GetDTO();

        public BeerDTO Update(Guid id, BeerDTO DTO)
        {
            var beer = this.context.Beers
                             .Include(b => b.Brewery)
                             .Include(b => b.Style)
                             .FirstOrDefault(beer => beer.Id == id);

            if (beer == null)
            {
                throw new ArgumentException();      //TODO: ex
            }

            beer.ModifiedOn = DateTime.Now;
            beer.Name = DTO.Name;
            beer.Description = DTO.Description;
            beer.Mililiters = DTO.Mililiters;
            beer.Price = DTO.Price;
            beer.ABV = DTO.ABV;
            beer.IsBeerOfTheMonth = DTO.IsBeerOfTheMonth;
            beer.BreweryId = this.context
                .Breweries
                .FirstOrDefault(br => br.Name == DTO.BreweryName).Id;
            beer.StyleId = this.context
                .Styles
                .FirstOrDefault(s => s.Name == DTO.StyleName).Id;


            //   Id = Guid.NewGuid(),
            //  Name = model.Name,
            //  ImageURL = model.ImageURL,
            //  IsUnlisted = model.IsUnlisted,
            //  IsDeleted = model.IsDeleted,
            //  StyleName = model.StyleName,
            //  BreweryName = model.BreweryName,
            //      Reviews = new List<ReviewDTO>()


            this.context.SaveChanges();
            return DTO;
        }

        public IEnumerable<BeerDTO> FilterByCriteria(string criteria, string name)
        {
            if (criteria.Contains("country"))
            {
                return this.context.Beers
                            .Include(b => b.Reviews)
                            .Include(b => b.Ratings)
                            .Include(b => b.Brewery)
                            .Include(b => b.Style)
                            .Where(b => !b.IsDeleted && b.Brewery.Country.Name == name)
                            .Select(b => b.GetDTO());

            }
            else if (criteria.Contains("style"))
            {
                return this.context.Beers
                           .Include(b => b.Reviews)
                           .Include(b => b.Ratings)
                           .Include(b => b.Brewery)
                           .Include(b => b.Style)
                           .Where(b => !b.IsDeleted && b.Style.Name == name)
                           .Select(b => b.GetDTO());
            }

            throw new ArgumentException();
        }

        public BeerDTO RetrieveByName(string name)
          => this.context.Beers
                   .Include(b => b.Brewery)
                   .Include(b => b.Style)
                   .Where(b => !b.IsDeleted)
                   .FirstOrDefault(b => b.Name == name)
                   .GetDTO();

        public BeerDTO Rate(string name, RatingDTO ratingDTO)
        {
            var beer = this.context.Beers
                   .Include(b => b.Brewery)
                   .Include(b => b.Style)
                   .Include(b => b.Ratings)
                   .ThenInclude(r => r.User)
                   .Where(b => !b.IsDeleted)
                   .FirstOrDefault(b => b.Name == name);

            if (beer == null)
            {
                throw new ArgumentException();
            }

            ratingDTO.BeerId = this.context
                .Beers
                .FirstOrDefault(b => b.Name == beer.Name).Id;
            ratingDTO.UserId = this.context
                .Users
                .FirstOrDefault(u => u.Username == ratingDTO.UserName).Id;

            this.context.Ratings.Add(ratingDTO.GetModel());
            this.context.SaveChanges();

            return beer.GetDTO();
        }
    }
}
