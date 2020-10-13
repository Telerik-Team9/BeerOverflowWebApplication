using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerOverflow.ServicesTests.CountryServiceTests
{
    [TestClass]
    public class Update_Should
    {
        [TestMethod]
        public void UpdateCountryWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            var country = new Country()
            {
                Id = Guid.NewGuid(),
                Name = "Bulgaria",
                ISO = "BG"
            };
            var countryDTO = new CountryDTO()
            {
                Name = "Germany",
                ISO = "DE"
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
                var actual = sut.Update(country.Id, countryDTO);

                Assert.AreEqual(country.Id, actual.Id);
                Assert.AreEqual(countryDTO.Name, actual.Name);
                Assert.AreEqual(countryDTO.ISO, actual.ISO);
            }
        }

        [TestMethod]
        public void ThrowWhen_NoSuchCountry()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);

                Assert.ThrowsException<ArgumentException>(() => sut.Update(Guid.NewGuid(), null));
            }
        }
    }
}
