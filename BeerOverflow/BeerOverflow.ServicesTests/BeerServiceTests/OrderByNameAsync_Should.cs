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
    public class OrderByNameAsync_Should
    {
        [TestMethod]
        public async Task CorrectlyOrderBeersAsc()
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
            using(var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                var result = await sut.OrderByNameAsync('a');
                var actual = result.ToList();
                var expected = beers.OrderBy(x => x.Name).ToList();

                Assert.AreEqual(expected[0].Name, actual[0].Name);
                Assert.AreEqual(expected[1].Name, actual[1].Name);
            }
        }
        [TestMethod]
        public async Task CorrectlyOrderBeersDesc()
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
                var result = await sut.OrderByNameAsync('d');
                var actual = result.ToList();
                var expected = beers.OrderByDescending(x => x.Name).ToList();

                Assert.AreEqual(expected[0].Name, actual[0].Name);
                Assert.AreEqual(expected[1].Name, actual[1].Name);
            }
        }
    }
}
