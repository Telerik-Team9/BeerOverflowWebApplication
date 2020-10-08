using BeerOverflow.Database;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly BeerOverflowDbContext context;

        public CountryService(BeerOverflowDbContext context)
        {
            this.context = context;
        }

        public CountryDTO Create(CountryDTO countryDTO)
        {
            var countryToAdd = countryDTO.GetModel();

            this.context.Countries.Add(countryToAdd);
            this.context.SaveChanges();
            return countryDTO;
        }

        public IEnumerable<CountryDTO> RetrieveAll()
            => this.context.Countries
                     .Where(c => !c.IsDeleted)
                     .Select(c => c.GetDTO());

        public CountryDTO RetrieveById(Guid Id)
             => this.context.Countries
                      .Where(c => !c.IsDeleted)
                      .FirstOrDefault(c => c.Id == Id)
                      .GetDTO();

        /*        public CountryDTO RetrieveByName(string name)
                {
                    var country = Seeder.Countries
                        .Where(c => !c.IsDeleted)
                        .FirstOrDefault(c => c.Name == name);

                    if (country == null)
                        throw new ArgumentException();      //TODO: ex

                    var countryDTO = new CountryDTO
                    {
                        Id = country.Id,
                        Name = country.Name
                    };

                    return countryDTO;
                }*/

        public CountryDTO Update(Guid Id, CountryDTO countryDTO)
        {
            var country = this.context.Countries
                .FirstOrDefault(c => c.Id == Id);

            if (country == null)
                throw new ArgumentException();      //TODO: ex

            country.Name = countryDTO.Name; // Extension method for country = countryDTo
            country.ModifiedOn = DateTime.Now;

            this.context.SaveChanges();
            return countryDTO;
        }

        public bool Delete(Guid Id)
        {
            try
            {
                var countryToDelete = this.context.Countries
                    .FirstOrDefault(c => c.Id == Id);

                countryToDelete.IsDeleted = true;
                countryToDelete.DeletedOn = DateTime.Now; // TODO: Should we use provider here?
                this.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
