using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Database;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BeerOverflow.Services.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly BeerOverflowDbContext context;

        public BreweryService(BeerOverflowDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<BreweryDTO> CreateAsync(BreweryDTO DTO)
        {
            var country = await this.context.Countries
                .Where(c => c.Name == DTO.CountryName)
                .FirstOrDefaultAsync();

            if (country == null)
            {
                throw new ArgumentException();
            }

            DTO.CountryId = country.Id;
            await this.context.Breweries.AddAsync(DTO.GetModel());
            await this.context.SaveChangesAsync();
            return DTO;
        }

        public async Task<BreweryDTO> RetrieveByIdAsync(Guid id)
        {
            var brewery = await this.context.Breweries
                      .Include(br => br.Beers)
                      .Include(br => br.Country)
                      .Where(c => !c.IsDeleted)
                      .FirstOrDefaultAsync(c => c.Id == id);
            
            return brewery.GetDTO();
        }

        public async Task<BreweryDTO> UpdateAsync(Guid Id, BreweryDTO DTO)
        {
            var brewery = await this.context.Breweries
                .Include(br => br.Beers)
                .Include(br => br.Country)
                .FirstOrDefaultAsync(br => br.Id == Id);

            if (brewery == null)
            {
                throw new ArgumentNullException();      //TODO: ex
            }

            brewery.Id = Id;
            brewery.Name = DTO.Name;
            var country = await this.context
                .Countries
                .FirstOrDefaultAsync(c => c.Name == DTO.CountryName); // Extension method for country = countryDTo
            brewery.CountryId = country.Id;
            brewery.ModifiedOn = DateTime.Now;
            await this.context.SaveChangesAsync();

            return DTO;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var breweryToDelete = await this.context.Breweries
                    .FirstOrDefaultAsync(c => c.Id == id);

                breweryToDelete.IsDeleted = true;
                breweryToDelete.DeletedOn = DateTime.Now; // TODO: Should we use provider here?
                await this.context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public async Task<IEnumerable<BreweryDTO>> RetrieveAllAsync()
            => await this.context.Breweries
                   .Include(br => br.Beers)
                   .Include(br => br.Country)
                   .Where(br => !br.IsDeleted)
                   .Select(br => br.GetDTO())
                   .ToListAsync();
    }
}
