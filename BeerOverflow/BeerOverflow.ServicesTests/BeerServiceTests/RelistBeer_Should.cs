using BeerOverflow.Database;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.BeerServiceTests
{
    [TestClass]
    public class RelistBeer_Should
    {
        [TestMethod]
        public async Task RelistBeerWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beers = Utils.GetBeers();
            var toRelist = beers.Last();
            toRelist.IsUnlisted = true;

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.Beers.AddRangeAsync(beers);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(assertContext);
                var result = await sut.RelistBeer(toRelist.Id);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_BeerNotFound()
        {
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.RelistBeer(Guid.Empty));
            }
        }
    }
}
