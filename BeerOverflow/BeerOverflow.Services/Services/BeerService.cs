/*using BeerOverflow.Database.Seed;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
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
            => Seeder.Beers
                     .Where(b => !b.IsDeleted)
                     .Select(b => b.GetDTO());

        public BeerDTO RetrieveById(Guid id)
            => Seeder.Beers
                     .Where(b => !b.IsDeleted)
                     .FirstOrDefault(b => b.Id == id)
                     .GetDTO();

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
*/