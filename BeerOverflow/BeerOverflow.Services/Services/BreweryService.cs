using System;
using System.Collections.Generic;
using System.Linq;
using BeerOverflow.Database.FakeDatabase;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
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
            => Seeder.Breweries
                   .Where(b => !b.IsDeleted)
                   .Select(b => b.GetDTO());

        public BreweryDTO RetrieveById(Guid id)
            => Seeder.Breweries
                      .Where(c => !c.IsDeleted)
                      .FirstOrDefault(c => c.Id == id)
                      .GetDTO();

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
