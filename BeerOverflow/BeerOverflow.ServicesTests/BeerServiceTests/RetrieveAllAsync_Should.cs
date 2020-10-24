using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.BeerServiceTests
{
    [TestClass]
    public class RetrieveAllAsync_Should
    {
        [TestMethod]
        public async Task CorrectlyReturnAlllBeers()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beers = Utils.GetBeers();
            var brewery = Mock.Of<Brewery>(x => x.Name == "Beer Bastards");
            var style = Mock.Of<Style>(x => x.Name == "IPA - Brut");
            foreach (var item in beers)
            {
                item.Brewery = brewery;
                item.Style = style;
            }

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.AddRangeAsync(beers);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {

                var sut = new BeerService(actContext);
                var result = await sut.RetrieveAllAsync();

                Assert.AreEqual(actContext.Beers.Count(), result.Count());
                Assert.AreEqual(actContext.Beers.First().Id, result.First().Id);
                Assert.AreEqual(actContext.Beers.Last().Id, result.Last().Id);
            }
        }

        [TestMethod]
        public async Task ReturnZeroWhen_NoBeers()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Acct & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                var result = await sut.RetrieveAllAsync();
                Assert.AreEqual(0, result.Count());
            }
        }
    }
}
