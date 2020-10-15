﻿using BeerOverflow.Database;
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
    public class CountryService : ICountryService
    {
        private readonly BeerOverflowDbContext context;

        public CountryService(BeerOverflowDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public CountryDTO Create(CountryDTO countryDTO)
        {
            var countryToAdd = countryDTO.GetModel();

            this.context.Countries.Add(countryToAdd);
            this.context.SaveChanges();
            return countryDTO;
        } // DONE

        public IEnumerable<CountryDTO> RetrieveAll()
            => this.context.Countries
                     .Include(c => c.Breweries)
                     .Where(c => !c.IsDeleted)
                     .Select(c => c.GetDTO()); // DONE

        public CountryDTO RetrieveById(Guid Id)
             => this.context.Countries
                      .Include(c => c.Breweries)
                      .Where(c => !c.IsDeleted)
                      .FirstOrDefault(c => c.Id == Id)
                      .GetDTO(); // DONE

        public CountryDTO Update(Guid Id, CountryDTO countryDTO)
        {
            var country = this.context.Countries
                .FirstOrDefault(c => c.Id == Id);

            if (country == null)
            {
                throw new ArgumentException();      //TODO: ex
            }

            country.Name = countryDTO.Name;
            country.ISO = countryDTO.ISO;// Extension method for country = countryDTo
            country.ModifiedOn = DateTime.Now;

            this.context.SaveChanges();
            return country.GetDTO();
        } // DONE

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
        } //DONE



        // Async methods
        public async Task<CountryDTO> RetrieveByIdAsync(Guid id)
        {
            var country = await this.context.Countries
                      .Include(c => c.Breweries)
                      .Where(c => !c.IsDeleted)
                      .FirstOrDefaultAsync(c => c.Id == id);

            return country.GetDTO();
        }

        public async Task<CountryDTO> RetrieveByNameAsync(string name)
        {
            var country = await this.context.Countries
                .Include(c => c.Breweries)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Name == name);

            if (country == null)
            {
                throw new ArgumentException();      //TODO: ex
            }

            return country.GetDTO();
        }

        public async Task<CountryDTO> CreateAsync(CountryDTO countryDTO)
        {
            var countryToAdd = countryDTO.GetModel();

            await this.context.Countries.AddAsync(countryToAdd);
            await this.context.SaveChangesAsync();
            return countryDTO;
        }

        public async Task<CountryDTO> UpdateAsync(Guid Id, CountryDTO countryDTO)
        {
            var country = await this.context.Countries
                .FirstOrDefaultAsync(c => c.Id == Id);

            if (country == null)
            {
                throw new ArgumentException();      //TODO: ex
            }

            country.Name = countryDTO.Name;
            country.ISO = countryDTO.ISO;// Extension method for country = countryDTo
            country.ModifiedOn = DateTime.Now;

            await this.context.SaveChangesAsync();
            return country.GetDTO();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var countryToDelete = await this.context.Countries
                    .FirstOrDefaultAsync(c => c.Id == id);

                countryToDelete.IsDeleted = true;
                countryToDelete.DeletedOn = DateTime.Now; // TODO: Should we use provider here?
                await this.context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<CountryDTO>> RetrieveAllAsync()
            => await this.context.Countries
                     .Include(c => c.Breweries)
                     .Where(c => !c.IsDeleted)
                     .Select(c => c.GetDTO())
                     .ToListAsync();
    }
}
