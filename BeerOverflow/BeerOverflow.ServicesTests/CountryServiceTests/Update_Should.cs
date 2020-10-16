using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.CountryServiceTests
{
    [TestClass]
    public class Update_Should
    {
        [TestMethod]
        public async Task UpdateCountryWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var country = Utils.GetCountries().First();

            var countryDTO = new CountryDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Bulgaria",
                ISO = "BG"
            };

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);
                var actual = await sut.UpdateAsync(country.Id, countryDTO);

                Assert.AreEqual(country.Id, actual.Id);
                Assert.AreEqual(countryDTO.Name, actual.Name);
                Assert.AreEqual(countryDTO.ISO, actual.ISO);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_NoSuchCountry()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.UpdateAsync(Guid.NewGuid(), null));
            }
        }
    }
}
