using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.ServicesTests.CountryServiceTests
{
    [TestClass]
    public class Delete_Should
    {
        [TestMethod]
        public void DeleteCountryWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            var country = new Country()
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
                var actual = sut.Delete(country.Id);

                Assert.IsTrue(actual);
                Assert.IsTrue(actContext.Countries.Any());
            }
        }

        [TestMethod]
        public void ReturnFalseWhen_NoSuchCountry()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);
                var actual = sut.Delete(Guid.NewGuid());

                Assert.IsFalse(actual);
            }
        }
    }
}
