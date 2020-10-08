using System;
using System.Collections.Generic;
using System.Linq;
using BeerOverflow.Database;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly BeerOverflowDbContext context;

        public BreweryService(BeerOverflowDbContext context)
        {
            this.context = context;
        }

        public BreweryDTO Create(BreweryDTO DTO)
        {
            var breweryToAdd = DTO.GetModel();

            this.context.Breweries.Add(breweryToAdd);
            this.context.SaveChanges();
            return DTO;
        }

        public IEnumerable<BreweryDTO> RetrieveAll()
            => this.context.Breweries
                   .Where(b => !b.IsDeleted)
                   .Select(b => b.GetDTO());

        public BreweryDTO RetrieveById(Guid id)
            => this.context.Breweries
                      .Where(c => !c.IsDeleted)
                      .FirstOrDefault(c => c.Id == id)
                      .GetDTO();

        public BreweryDTO Update(Guid Id, BreweryDTO DTO)
        {
            var brewery = this.context.Breweries
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
                var breweryToDelete = this.context.Breweries
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
