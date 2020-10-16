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
    public class RetrieveAll_Should
    {
        [TestMethod]
        public async Task ReturnAllCountriesWhen_ValidParams()
        {
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var countries = Utils.GetCountries().ToList();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Countries.AddRange(countries);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);

                var result = await sut.RetrieveAllAsync();
                var actual = result.ToList();

                Assert.AreEqual(countries[0].Id, actual[0].Id);
                Assert.AreEqual(countries[0].Name, actual[0].Name);
                Assert.AreEqual(countries[0].ISO, actual[0].ISO);

                Assert.AreEqual(countries[1].Id, actual[1].Id);
                Assert.AreEqual(countries[1].Name, actual[1].Name);
                Assert.AreEqual(countries[1].ISO, actual[1].ISO);

                Assert.AreEqual(countries[2].Id, actual[2].Id);
                Assert.AreEqual(countries[2].Name, actual[2].Name);
                Assert.AreEqual(countries[2].ISO, actual[2].ISO);

                Assert.AreEqual(3, actual.Count);
            }
        }

        [TestMethod]
        public async Task ReturnNullWhen_NoCountries()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);
                var actual = await sut.RetrieveAllAsync();

                Assert.IsFalse(actual.Any());
            }
        }
    }
}
