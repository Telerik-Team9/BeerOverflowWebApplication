using BeerOverflow.Database.FakeDatabase;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Services.Services
{
    public class StyleService : IStyleService
    {
        public IEnumerable<StyleDTO> RetrieveAll()
        {
            var allStyles = Seeder.Styles
                .Select(s => new StyleDTO
                {
                    Id = s.Id,
                    Name = s.Name
                });

            return allStyles;
        }
        public StyleDTO RetrieveById(Guid id)
        {
            var style = Seeder.Styles
                .Where(c => !c.IsDeleted)
                .FirstOrDefault(c => c.Id == id);

            if (style == null)
                throw new ArgumentException();      //TODO: null

            var styleDTO = new StyleDTO
            {
                Id = style.Id,
                Name = style.Name
            };

            return styleDTO;
        }
        public bool Delete(Guid id)
        {
            try
            {
                var styleToDelete = Seeder.Styles
                    .FirstOrDefault(s => s.Id == id);

                styleToDelete.IsDeleted = true;
                styleToDelete.DeletedOn = DateTime.Now;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public StyleDTO Create(StyleDTO DTO)
        {
            //NULL check?
            var styleToAdd = new Style
            {
                Id = DTO.Id,
                Name = DTO.Name,
                Description = DTO.Description,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            Seeder.Styles.Add(styleToAdd);
            return DTO;
        }
        public StyleDTO Update(Guid Id, StyleDTO DTO)
        {
            var style = Seeder.Styles
                .FirstOrDefault(c => c.Id == Id);

            if (style == null)
                throw new ArgumentException();      //TODO: ex

            style.Name = DTO.Name; // Extension method for country = countryDTo
            style.ModifiedOn = DateTime.Now;

            return DTO;
            //Update what?
        }
    }
}
