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
    public class DeleteAsync_Should
    {
        [TestMethod]
        public async Task DeleteBreweryWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var brewery = Utils.GetBreweries().First();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.Breweries.AddAsync(brewery);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BreweryService(actContext);
                var actual = await sut.DeleteAsync(brewery.Id);

                Assert.IsTrue(actual);
                Assert.IsTrue(actContext.Breweries.Any());
            }
        }

        [TestMethod]
        public async Task ReturnFalseWhen_NoSuchBrewery()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BreweryService(actContext);
                var actual = await sut.DeleteAsync(Guid.NewGuid());

                Assert.IsFalse(actual);
            }
        }
    }
}
