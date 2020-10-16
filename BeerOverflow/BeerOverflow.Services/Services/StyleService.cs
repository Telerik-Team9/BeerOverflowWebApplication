using BeerOverflow.Database;
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
    public class StyleService : IStyleService
    {
        private readonly BeerOverflowDbContext context;

        public StyleService(BeerOverflowDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<StyleDTO> CreateAsync(StyleDTO DTO)
        {
            var styleToAdd = DTO.GetModel();

            await this.context.Styles.AddAsync(styleToAdd);
            await this.context.SaveChangesAsync();
            return DTO;
        }

        public async Task<StyleDTO> RetrieveByIdAsync(Guid id)
        {
            var style = await this.context.Styles
                     .Include(s => s.Beers)
                     .Where(c => !c.IsDeleted)
                     .FirstOrDefaultAsync(c => c.Id == id);

            return style.GetDTO();
        }

        public async Task<StyleDTO> UpdateAsync(Guid Id, StyleDTO DTO)
        {
            var style = await this.context.Styles.FirstOrDefaultAsync(c => c.Id == Id);

            if (style == null)
            {
                throw new ArgumentNullException();
            }

            style.Name = DTO.Name; // Extension method for country = countryDTo
            style.Description = DTO.Description;
            style.ModifiedOn = DateTime.Now;
            
            await this.context.SaveChangesAsync();

            return style.GetDTO();
            //Update what?
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var styleToDelete = await this.context.Styles.FirstOrDefaultAsync(s => s.Id == id);

                styleToDelete.IsDeleted = true;
                styleToDelete.DeletedOn = DateTime.Now;
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<StyleDTO>> RetrieveAllAsync()
            => await this.context.Styles
                     .Include(s => s.Beers)
                     .Where(s => !s.IsDeleted)
                     .Select(s => s.GetDTO())
                     .ToListAsync();
    }
}
