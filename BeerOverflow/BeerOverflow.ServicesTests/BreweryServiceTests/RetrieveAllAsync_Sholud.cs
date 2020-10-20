using BeerOverflow.Database;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.BreweryServiceTests
{
    [TestClass]
    public class RetrieveAllAsync_Sholud
    {
        [TestMethod]
        public async Task ReturnAllBreweriesWhen_ValidParams()
        {
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var breweries = Utils.GetBreweries().ToList();
            var countries = Utils.GetCountries().ToList();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
              await arrangeContext.Breweries.AddRangeAsync(breweries);
              await arrangeContext.Countries.AddRangeAsync(countries);
              await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BreweryService(actContext);

                var result = await sut.RetrieveAllAsync();
                var actual = result.ToList();

                Assert.AreEqual(breweries[0].Id, actual[0].Id);
                Assert.AreEqual(breweries[0].Name, actual[0].Name);

                Assert.AreEqual(breweries[1].Id, actual[1].Id);
                Assert.AreEqual(breweries[1].Name, actual[1].Name);

                Assert.AreEqual(breweries[2].Id, actual[2].Id);
                Assert.AreEqual(breweries[2].Name, actual[2].Name);

                Assert.AreEqual(3, actual.Count);
            }
        }

        [TestMethod]
        public async Task ReturnNullWhen_NoBreweries()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BreweryService(actContext);
                var actual = await sut.RetrieveAllAsync();

                Assert.IsFalse(actual.Any());
            }
        }
    }
}
