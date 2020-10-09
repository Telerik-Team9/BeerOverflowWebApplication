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
            this.context = context;
        }

        public BeerDTO Create(BeerDTO DTO) //TODO: Map id's towards name
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

            DTO.BreweryId = brewery.Id;
            DTO.StyleId = style.Id;
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
                     .Where(b => !b.IsDeleted)
                     .Select(b => b.GetDTO());

        public BeerDTO RetrieveById(Guid id)
            => this.context.Beers
                     .Include(b => b.Brewery)
                     .Include(b => b.Style)
                     .Where(b => !b.IsDeleted)
                     .FirstOrDefault(b => b.Id == id)
                     .GetDTO();

        public BeerDTO Update(Guid id, BeerDTO model)
        {
            var beer = this.context.Beers
                               .Include(b => b.Brewery)
                               .Include(b => b.Style)
                               //.Where(b => b.Brewery.Name == beerDTO.BreweryName &&
                               //            b.Style.Name == beerDTO.StyleName)
                               .FirstOrDefault(beer => beer.Id == id);

            //var beer = this.context.Beers
            //          .FirstOrDefault(b => b.Id == id);

            if (beer == null)
            {
                throw new ArgumentException();      //TODO: ex
            }

            beer.ModifiedOn = DateTime.Now;
            beer.Name = model.Name;
            beer.Description = model.Description;
            beer.Mililiters = model.Mililiters;
            beer.Price = model.Price;
            beer.ABV = model.ABV;
            beer.IsBeerOfTheMonth = model.IsBeerOfTheMonth;
            beer.BreweryId = model.BreweryId;
            beer.StyleId = model.StyleId;


            //   Id = Guid.NewGuid(),
            //  Name = model.Name,
            //  ImageURL = model.ImageURL,
            //  IsUnlisted = model.IsUnlisted,
            //  IsDeleted = model.IsDeleted,
            //  StyleName = model.StyleName,
            //  BreweryName = model.BreweryName,
            //  Reviews = new List<ReviewDTO>()


            this.context.SaveChanges();
            return model;
        }//TODO: Map id's towards name
    }
}
