using BeerOverflow.Database;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.BeerServiceTests
{
    [TestClass]
    public class DeleteAsync_Should
    {
        [TestMethod]
        public async Task DeleteBeerWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beers = Utils.GetBeers();

            using(var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.AddRangeAsync(beers);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using(var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                var result = await sut.DeleteAsync(beers.First().Id);

                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public async Task ReturnFalseWhen_NoSuchBeer()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                var actual = await sut.DeleteAsync(Guid.NewGuid());

                Assert.IsFalse(actual);
            }
        }
    }
}
