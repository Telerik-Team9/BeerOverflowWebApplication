﻿using BeerOverflow.Database;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Services.Services
{
    public class StyleService : IStyleService
    {
        private readonly BeerOverflowDbContext context;

        public StyleService(BeerOverflowDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<StyleDTO> RetrieveAll()
            => this.context.Styles
                     .Include(s => s.Beers)
                     .Where(s => !s.IsDeleted)
                     .Select(s => s.GetDTO());

        public StyleDTO RetrieveById(Guid id)
            => this.context.Styles
                     .Include(s => s.Beers)
                     .Where(c => !c.IsDeleted)
                     .FirstOrDefault(c => c.Id == id)
                     .GetDTO();

        public bool Delete(Guid id)
        {
            try
            {
                var styleToDelete = this.context.Styles.FirstOrDefault(s => s.Id == id);

                styleToDelete.IsDeleted = true;
                styleToDelete.DeletedOn = DateTime.Now;
                this.context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public StyleDTO Create(StyleDTO DTO)
        {
            var styleToAdd = DTO.GetModel();

            this.context.Styles.Add(styleToAdd);
            this.context.SaveChanges();
            return DTO;
        }

        public StyleDTO Update(Guid Id, StyleDTO DTO)
        {
            var style = this.context.Styles.FirstOrDefault(c => c.Id == Id);

            if (style == null)
            {
                throw new ArgumentNullException();
            }

            style.Name = DTO.Name; // Extension method for country = countryDTo
            style.Description = DTO.Description;
            style.ModifiedOn = DateTime.Now;
            this.context.SaveChanges();
            return style.GetDTO();
            //Update what?
        }
    }
}
