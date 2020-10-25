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
    public class RateAsync_Should
    {
        [TestMethod]
        public async Task RateBeerWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beer = Utils.GetBeers().Last();
            var rating = Utils.GetRatings().First().GetDTO();
            
            var brewery = Mock.Of<Brewery>(x => x.Id == Guid.Parse("2a281f97-d2d4-4cde-93d3-92f8aac15b9a"));
            var style = Mock.Of<Style>(x => x.Id == Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c"));
            var user = Mock.Of<User>(x => x.Id == Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"));
            beer.BreweryId = Guid.Parse("2a281f97-d2d4-4cde-93d3-92f8aac15b9a");
            beer.StyleId = Guid.Parse("77f9496e-0475-4165-ac5e-ee57039f108c");

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.Breweries.AddRangeAsync(brewery);
                await arrangeContext.Styles.AddRangeAsync(style);
                await arrangeContext.Beers.AddAsync(beer);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using(var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                var result = await sut.RateAsync(beer.Name, rating);

                Assert.AreEqual(1, result.Ratings.Count);
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
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.RateAsync("", null));
            }
        }
    }
}
