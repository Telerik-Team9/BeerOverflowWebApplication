using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly BeerOverflowDbContext _context;
        public CountryService(BeerOverflowDbContext context)
        {
            this._context = context;
        }

        public Country CreateCountry(Country country)
        {
            this._context.Countries.Add(country);
            this._context.SaveChanges();

            return country;
        }
    }
}
