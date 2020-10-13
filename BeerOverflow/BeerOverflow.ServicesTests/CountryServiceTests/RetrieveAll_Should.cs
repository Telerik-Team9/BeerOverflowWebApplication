using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BeerOverflow.ServicesTests.CountryServiceTests
{
    [TestClass]
    public class RetrieveAll_Should
    {
        [TestMethod]
        public void ReturnAllCountriesWhen_ValidParams()
        {
            var options = Utils.GetOptions(Guid.NewGuid().ToString()); // Can also use Utils.GetOptions(nameof(ReturnAllCountriesWhen_ValidParams));

            var country = new Country()
            {
                Id = Guid.NewGuid(),
                Name = "Bulgaria",
                ISO = "BG"
            };
            var country2 = new Country()
            {
                Id = Guid.NewGuid(),
                Name = "Germany",
                ISO = "BG"
            };

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.Countries.Add(country2);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);

                var actual = sut.RetrieveAll().ToList();

                Assert.AreEqual(country.Id, actual[0].Id);
                Assert.AreEqual(country.Name, actual[0].Name);
                Assert.AreEqual(country.ISO, actual[0].ISO);

                Assert.AreEqual(country2.Id, actual[1].Id);
                Assert.AreEqual(country2.Name, actual[1].Name);
                Assert.AreEqual(country2.ISO, actual[1].ISO);
            }
        }

        [TestMethod]
        public void ReturnNullWhen_NoCountries()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);
                var actual = sut.RetrieveAll().ToList();

                Assert.IsFalse(actual.Any());
            }
        }
    }
}
