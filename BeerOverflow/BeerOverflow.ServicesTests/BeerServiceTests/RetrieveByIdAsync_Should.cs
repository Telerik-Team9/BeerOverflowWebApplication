using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.BeerServiceTests
{
    [TestClass]
    public class RetrieveByIdAsync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectBeerDTOWhen_ValidParams()
        {
            // Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beers = Utils.GetBeers();
            var beer = beers.First();
            beer.Brewery = Mock.Of<Brewery>(x => x.Name == "Beer Bastards");
            beer.Style = Mock.Of<Style>(x => x.Name == "IPA - Brut");

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.Beers.AddRangeAsync(beers);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using(var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                var result = await sut.RetrieveByIdAsync(beers.First().Id);
                
                Assert.AreEqual(beer.Id, result.Id);
                Assert.AreEqual(beer.Name, result.Name);
            }
        }

        [TestMethod]
        public async Task ReturnNullWhen_InvalidParams()
        {
            // Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beers = Utils.GetBeers();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.Beers.AddRangeAsync(beers);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                var result = await sut.RetrieveByIdAsync(Guid.Empty);
                Assert.IsNull(result);
            }
        }
    }
}
