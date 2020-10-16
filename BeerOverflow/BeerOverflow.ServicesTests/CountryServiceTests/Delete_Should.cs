using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.CountryServiceTests
{
    [TestClass]
    public class Delete_Should
    {
        [TestMethod]
        public async Task DeleteCountryWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var country = Utils.GetCountries().First();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);
                var actual = await sut.DeleteAsync(country.Id);

                Assert.IsTrue(actual);
                Assert.IsTrue(actContext.Countries.Any());
            }
        }

        [TestMethod]
        public async Task ReturnFalseWhen_NoSuchCountry()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);
                var actual = await sut.DeleteAsync(Guid.NewGuid());

                Assert.IsFalse(actual);
            }
        }
    }
}
