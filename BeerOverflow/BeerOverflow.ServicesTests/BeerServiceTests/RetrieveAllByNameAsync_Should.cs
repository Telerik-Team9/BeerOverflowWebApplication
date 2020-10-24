using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.BeerServiceTests
{
    [TestClass]
    public class RetrieveAllByNameAsync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectBeerDTOWhen_ValidParams()
        {
            // Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beers = Utils.GetBeers();
            var beer1 = beers.First();
            var beer2 = beers.Last();
            beer2.Name = beer1.Name;

            beer1.Brewery = Mock.Of<Brewery>(x => x.Name == "Beer Bastards");
            beer1.Style = Mock.Of<Style>(x => x.Name == "IPA - Brut");

            beer2.Brewery = Mock.Of<Brewery>(x => x.Name == "Beer Bastards");
            beer2.Style = Mock.Of<Style>(x => x.Name == "IPA - Brut");

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.Beers.AddRangeAsync(beer1, beer2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                var result = await sut.RetrieveAllByNameAsync(beer1.Name);

                Assert.AreEqual(2, result.Count());
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
                var result = await sut.RetrieveAllByNameAsync("");
                Assert.AreEqual(0, result.Count());
            }
        }

    }
}
