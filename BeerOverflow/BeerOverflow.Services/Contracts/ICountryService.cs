using BeerOverflow.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface ICountryService
    {
        Country CreateCountry(Country country);
    }
}
