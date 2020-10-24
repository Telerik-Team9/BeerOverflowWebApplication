using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
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
    public class UpdateAsync_Should
    {
        [TestMethod]
        public async Task UpdateBeerWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beers = Utils.GetBeers();
            var beer = beers.First();

            var brewery = Mock.Of<Brewery>(x => x.Id == Guid.Parse("2a281f97-d2d4-4cde-93d3-92f8aac15b9a"));
            var style = Mock.Of<Style>(x => x.Id == Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c"));
            beer.BreweryId = Guid.Parse("2a281f97-d2d4-4cde-93d3-92f8aac15b9a");
            beer.StyleId = Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c");

            var beerDTO = Mock.Of<BeerDTO>(x => x.Name == "Corona"
                                             && x.Price == 1.5
                                             && x.Mililiters == 500
                                             && x.BreweryId == Guid.Parse("2a281f97-d2d4-4cde-93d3-92f8aac15b9a")
                                             && x.StyleId == Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c"));

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.Breweries.AddRangeAsync(brewery);
                await arrangeContext.Styles.AddRangeAsync(style);
                await arrangeContext.Beers.AddRangeAsync(beers);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                var result = await sut.UpdateAsync(beer.Id, beerDTO);

                Assert.AreEqual(beerDTO.Name, result.Name);
                Assert.AreEqual(beerDTO.Price, result.Price);
                Assert.AreEqual(beerDTO.Mililiters, result.Mililiters);
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
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.UpdateAsync(Guid.Empty, null));
            }
        }
    }
}
