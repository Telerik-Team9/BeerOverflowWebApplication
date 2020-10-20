using BeerOverflow.Database;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Services
{
    public class BeerService : IBeerService
    {
        private readonly BeerOverflowDbContext context;

        public BeerService(BeerOverflowDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<BeerDTO> CreateAsync(BeerDTO DTO)
        {
            var brewery = await this.context.Breweries
                           .Where(br => br.Name == DTO.BreweryName)
                           .FirstOrDefaultAsync(br => !br.IsDeleted);

            var style = await this.context.Styles
                         .Where(s => s.Name == DTO.StyleName)
                         .FirstOrDefaultAsync(s => !s.IsDeleted);

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

            await this.context.Beers.AddAsync(DTO.GetModel());
            await this.context.SaveChangesAsync();
            return DTO;
        }

        public async Task<BeerDTO> RetrieveByIdAsync(Guid id)
        {
            var beer = await this.context.Beers
                     .Include(b => b.Brewery)
                     .Include(b => b.Style)
                     .Include(b => b.Reviews)
                     .Include(b => b.Ratings)
                     .Where(b => !b.IsDeleted)
                     .FirstOrDefaultAsync(b => b.Id == id);

            return beer.GetDTO();
        }

        public async Task<BeerDTO> RetrieveByNameAsync(string name)
        {
            var result = await this.context.Beers
                  .Include(b => b.Brewery)
                  .Include(b => b.Style)
                  .Include(b => b.Reviews)
                  .Include(b => b.Ratings)
                  .Where(b => !b.IsDeleted)
                  .FirstOrDefaultAsync(b => b.Name.Contains(name));

            return result.GetDTO();
        }

        public async Task<BeerDTO> UpdateAsync(Guid id, BeerDTO DTO)
        {
            var beer = await this.context.Beers
                             .Include(b => b.Brewery)
                             .Include(b => b.Style)
                             .FirstOrDefaultAsync(beer => beer.Id == id);

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

            await this.context.SaveChangesAsync();
            return DTO;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            try
            {
                var beerToDelete = await this.context.Beers
                    .FirstOrDefaultAsync(b => b.Id == id);

                beerToDelete.IsDeleted = true;
                beerToDelete.DeletedOn = DateTime.Now; // TODO: Should we use provider here?
                await this.context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<BeerDTO> RateAsync(string name, RatingDTO ratingDTO)
        {
            var beer = await this.context.Beers
                   .Include(b => b.Brewery)
                   .Include(b => b.Style)
                   .Include(b => b.Ratings)
                   .ThenInclude(r => r.User)
                   .Where(b => !b.IsDeleted)
                   .FirstOrDefaultAsync(b => b.Name == name);

            if (beer == null)
            {
                throw new ArgumentException();
            }

            ratingDTO.BeerId = this.context
                .Beers
                .FirstOrDefault(b => b.Name == beer.Name).Id;
            ratingDTO.UserId = this.context
                .Users
                .FirstOrDefault(u => u.UserName == ratingDTO.UserName).Id;

            await this.context.Ratings.AddAsync(ratingDTO.GetModel());
            await this.context.SaveChangesAsync();

            return beer.GetDTO();
        }

        public async Task<IEnumerable<BeerDTO>> RetrieveAllAsync()
            => await this.context.Beers
                     .Include(b => b.Brewery)
                     .Include(b => b.Style)
                     .Include(b => b.Reviews)
                     .Include(b => b.Ratings)
                     .Where(b => !b.IsDeleted)
                     .Select(b => b.GetDTO())
                     .ToListAsync();

        public async Task<IEnumerable<BeerDTO>> OrderByABVAsync(char order)
        {
            IEnumerable<BeerDTO> result = null;
            if (order == 'd')
            {
                result = await this.RetrieveAllAsync();
                return result.OrderByDescending(x => x.ABV);
            }

            result = await this.RetrieveAllAsync();
            return result.OrderBy(x => x.ABV);
        }

        public async Task<IEnumerable<BeerDTO>> OrderByNameAsync(char order)
        {
            IEnumerable<BeerDTO> result = null;
            if (order == 'd')
            {
                result = await this.RetrieveAllAsync();
                return result.OrderByDescending(x => x.Name);
            }

            result = await this.RetrieveAllAsync();
            return result.OrderBy(x => x.Name);
        }

        public async Task<IEnumerable<BeerDTO>> OrderByRatingAsync(char order)
        {
            IEnumerable<BeerDTO> result = null;
            if (order == 'd')
            {
                result = await this.RetrieveAllAsync();
                return result.OrderByDescending(x => x.AvgRating);
            }

            result = await this.RetrieveAllAsync();
            return result.OrderBy(x => x.AvgRating);
        }

        public async Task<IEnumerable<BeerDTO>> FilterByCriteriaAsync(string criteria, string name)
        {
            if (criteria.Contains("country"))
            {
                return await this.context.Beers
                            .Include(b => b.Reviews)
                            .Include(b => b.Ratings)
                            .Include(b => b.Brewery)
                            .Include(b => b.Style)
                            .Where(b => !b.IsDeleted && b.Brewery.Country.Name == name)
                            .Select(b => b.GetDTO())
                            .ToListAsync();

            }
            else if (criteria.Contains("style"))
            {
                return await this.context.Beers
                           .Include(b => b.Reviews)
                           .Include(b => b.Ratings)
                           .Include(b => b.Brewery)
                           .Include(b => b.Style)
                           .Where(b => !b.IsDeleted && b.Style.Name == name)
                           .Select(b => b.GetDTO())
                           .ToListAsync();
            }

            throw new ArgumentException();
        }
    }
}
