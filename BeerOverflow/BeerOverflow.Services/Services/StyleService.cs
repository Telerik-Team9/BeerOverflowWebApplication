using System;
using System.Collections.Generic;
using System.Linq;
using BeerOverflow.Database.FakeDatabase;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.Services
{
    public class StyleService : IStyleService
    {
        public IEnumerable<StyleDTO> RetrieveAll()
            => Seeder.Styles
                     .Where(s => !s.IsDeleted)
                     .Select(s => s.GetDTO());

        public StyleDTO RetrieveById(Guid id)
            => Seeder.Styles
                     .Where(c => !c.IsDeleted)
                     .FirstOrDefault(c => c.Id == id)
                     .GetDTO();

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
            /*            //NULL check?
                        var styleToAdd = new Style
                        {
                            Id = DTO.Id,
                            Name = DTO.Name,
                            Description = DTO.Description,
                            CreatedOn = DateTime.Now,
                            IsDeleted = false
                        };

                        Seeder.Styles.Add(styleToAdd);
                        return DTO;*/
            throw new NotImplementedException();
        }

        public StyleDTO Update(Guid Id, StyleDTO DTO)
        {
            var style = Seeder.Styles
                .FirstOrDefault(c => c.Id == Id);

            if (style == null)
            {
                return null;
            }

            style.Name = DTO.Name; // Extension method for country = countryDTo
            style.ModifiedOn = DateTime.Now;

            return DTO;
            //Update what?
        }
    }
}
