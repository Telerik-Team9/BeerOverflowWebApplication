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
    public class RetrieveBiIdAsynnc_Should
    {
        [TestMethod]
        public async Task ReturnCorrectBeerDTOWhen_ValidParams()
        {
            // Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beer = Utils.GetBeers().First();

            beer.Brewery = Mock.Of<Brewery>(x => x.Name == "Beer Bastards");
            beer.Style = Mock.Of<Style>(x => x.Name == "IPA - Brut");
            var dto = beer.GetDTO();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.Beers.AddAsync(beer);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using(var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                var result = await sut.RetrieveByIdAsync(beer.Id);

                Assert.AreEqual(beer.Id, result.Id);
                Assert.AreEqual(beer.Name, result.Name);
                Assert.AreEqual(beer.Brewery.Name, result.BreweryName);
                Assert.AreEqual(beer.Style.Name, result.StyleName);
            }
        }

        [TestMethod]
        public async Task ReturnNullWhen_InvalidParams()
        {
            // Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beer = Utils.GetBeers().First();

            beer.Brewery = Mock.Of<Brewery>(x => x.Name == "Beer Bastards");
            beer.Style = Mock.Of<Style>(x => x.Name == "IPA - Brut");
            var dto = beer.GetDTO();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.Beers.AddAsync(beer);
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
