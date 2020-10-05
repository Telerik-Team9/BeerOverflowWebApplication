using System;
using System.Collections.Generic;
using System.Linq;
using BeerOverflow.Database.FakeDatabase;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.Services
{
    public class BreweryService : IBreweryService
    {
        public BreweryDTO Create(BreweryDTO DTO)
        {
            //    var breweryToAdd = new Brewery
            //    {
            //        Id = Guid.NewGuid(),    // TODO: Should the Id be generated here or in .Web ?
            //        Name = DTO.Name,
            //        CreatedOn = DateTime.Now,
            //        IsDeleted = false,
            //    };

            //    Seeder.Breweries.Add(breweryToAdd);

            //    return DTO;
            throw new NotImplementedException();
        }

        public IEnumerable<BreweryDTO> RetrieveAll()
        {
            var allCountries = Seeder.Breweries
               .Where(b => !b.IsDeleted)
               .Select(b => new BreweryDTO
               {
                   Id = b.Id,
                   Name = b.Name
               });

            return allCountries;
        }

        public BreweryDTO RetrieveById(Guid id)
        {
            var brewery = Seeder.Breweries
                 .Where(c => c.IsDeleted == false)
                 .FirstOrDefault(c => c.Id == id);

            if (brewery == null)
                throw new ArgumentException();      //TODO: ex

            // if (brewery.IsDeleted)
            //     throw new ArgumentException();

            var breweryDTO = new BreweryDTO
            {
                Id = brewery.Id,
                Name = brewery.Name
            };

            return breweryDTO;
        }

        public BreweryDTO Update(Guid Id, BreweryDTO DTO)
        {
            var brewery = Seeder.Breweries
                .FirstOrDefault(c => c.Id == Id);

            if (brewery == null)
                throw new ArgumentException();      //TODO: ex

            brewery.Name = DTO.Name; // Extension method for country = countryDTo
            brewery.ModifiedOn = DateTime.Now;

            return DTO;
        }

        public bool Delete(Guid id)
        {
            try
            {
                var breweryToDelete = Seeder.Breweries
                    .FirstOrDefault(c => c.Id == id);

                breweryToDelete.IsDeleted = true;
                breweryToDelete.DeletedOn = DateTime.Now; // TODO: Should we use provider here?

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
