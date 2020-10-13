using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerOverflow.ServicesTests.CountryServiceTests
{
    [TestClass]
    public class RetrieveById_Should
    {
        [TestMethod]
        public void ReturnCorrectCountryDTOWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString()); // Can also use Utils.GetOptions(nameof(ReturnCorrectCountryDTOWhen_ValidParams));
            var id = Guid.NewGuid();

            var country = new Country()
            {
                Id = id,
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

                var actual = sut.RetrieveById(id);

                Assert.AreEqual(country.Id, actual.Id);
                Assert.AreEqual(country.Name, actual.Name);
                Assert.AreEqual(country.ISO, actual.ISO);
            }
        }

        [TestMethod]
        public void ReturnNullWhen_NoSuchCountry()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);
                var actual = sut.RetrieveById(Guid.NewGuid());

                Assert.IsNull(actual);
            }
        }
    }
}
