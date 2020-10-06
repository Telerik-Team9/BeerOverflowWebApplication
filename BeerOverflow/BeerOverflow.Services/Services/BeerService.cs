using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using BeerOverflow.Database.FakeDatabase;
using System.Linq;

namespace BeerOverflow.Services.Services
{
    public class BeerService : IBeerService
    {
        public BeerDTO Create(BeerDTO DTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            try
            {
                var beerToDelete = Seeder.Beers
                    .FirstOrDefault(b => b.Id == id);

                beerToDelete.IsDeleted = true;
                beerToDelete.DeletedOn = DateTime.Now; // TODO: Should we use provider here?

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<BeerDTO> RetrieveAll()
        {
            var allBeers = Seeder.Beers
                .Where(b => !b.IsDeleted)
                .Select(b => new BeerDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    ABV = b.ABV,
                    Price = b.Price,
                    Description = b.Description,
                    ImageURL = b.ImageURL,
                    Mililiters = b.Mililiters,
                    IsUnlisted = b.IsUnlisted,
                    IsBeerOfTheMonth = b.IsBeerOfTheMonth,
                    StyleId = b.StyleId,
                    StyleName = b.Style.Name,
                    BreweryId = b.BreweryId,
                    BreweryName = b.Brewery.Name
                    //Reviews = b.Reviews?.Select(ReviewDTO).ToList()
                });

            return allBeers;
        }

        public BeerDTO RetrieveById(Guid id)
        {
            var beer = Seeder.Beers
                .Where(b => !b.IsDeleted)
                .FirstOrDefault(b => b.Id == id);

            if (beer == null)
            {
                throw new ArgumentException();      //TODO: ex
            }

            var beerDTO = new BeerDTO
            {
                Id = beer.Id,
                Name = beer.Name,
                ABV = beer.ABV,
                Price = beer.Price,
                Description = beer.Description,
                ImageURL = beer.ImageURL,
                Mililiters = beer.Mililiters,
                IsUnlisted = beer.IsUnlisted,
                IsBeerOfTheMonth = beer.IsBeerOfTheMonth,
                StyleId = beer.StyleId,
                StyleName = beer.Style.Name,
                BreweryId = beer.BreweryId,
                BreweryName = beer.Brewery.Name
                //Reviews = b.Reviews?.Select(ReviewDTO).ToList()
            };

            return beerDTO;
        }

        public BeerDTO Update(Guid id, BeerDTO beerDTO)
        {
            var beer = Seeder.Beers
                .FirstOrDefault(b => b.Id == id);

            if (beer == null)
            {
                throw new ArgumentException();      //TODO: ex
            }

            beer.Name = beerDTO.Name; 
            beer.ModifiedOn = DateTime.Now;

            return beerDTO;
        }
    }
}
