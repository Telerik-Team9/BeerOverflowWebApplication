using System;
using System.Collections.Generic;
using System.Linq;
using BeerOverflow.Database.FakeDatabase;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.Services
{
    public class CountryService : ICountryService
    {
        public CountryDTO Create(CountryDTO countryDTO)
        {
            //var countryToAdd = new Country
            //{
            //    Id = Guid.NewGuid(),    // TODO: Should the Id be generated here or in .Web ?
            //    Name = countryDTO.Name,
            //    IsDeleted = false
            //};

            //Seeder.Countries.Add(countryToAdd);

            //return countryDTO;
            throw new NotImplementedException();
        }

        public IEnumerable<CountryDTO> RetrieveAll()
        {
            var allCountries = Seeder.Countries
                .Where(c => !c.IsDeleted)
                .Select(c => new CountryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                });

            if (!allCountries.Any())
            {
                throw new Exception();
            }

            return allCountries;
        }

        public CountryDTO RetrieveById(Guid Id)
        {
            var country = Seeder.Countries
                .Where(c => !c.IsDeleted)
                .FirstOrDefault(c => c.Id == Id);

            if (country == null)
                throw new ArgumentException();      //TODO: ex

            var countryDTO = country.GetDTO();

            return countryDTO;
        }

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
            var country = Seeder.Countries
                .FirstOrDefault(c => c.Id == Id);

            if (country == null)
                throw new ArgumentException();      //TODO: ex

            country.Name = countryDTO.Name; // Extension method for country = countryDTo
            country.ModifiedOn = DateTime.Now;

            return countryDTO;
        }

        public bool Delete(Guid Id)
        {
            try
            {
                var countryToDelete = Seeder.Countries
                    .FirstOrDefault(c => c.Id == Id);

                countryToDelete.IsDeleted = true;
                countryToDelete.DeletedOn = DateTime.Now; // TODO: Should we use provider here?

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
