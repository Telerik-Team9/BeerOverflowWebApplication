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
    public class OrderByRatingAsync_Should
    {
        [TestMethod]
        public async Task CorrectlyOrderBeersAsc()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beers = Utils.GetBeers();
            var brewery = Mock.Of<Brewery>(x => x.Name == "Beer Bastards");
            var style = Mock.Of<Style>(x => x.Name == "IPA - Brut");
            var rnd = new Random();

            foreach (var item in beers)
            {
                item.Brewery = brewery;
                item.Style = style;
                item.Ratings.Add(Mock.Of<Rating>(x => x.RatingGiven == rnd.Next(0, 5)));
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
                var result = await sut.OrderByRatingAsync('a');
                var actual = result.ToList();
                var expected = beers.OrderBy(x => x.Ratings.Average(x => x.RatingGiven)).ToList();

                Assert.AreEqual(expected[0].Ratings.Average(x => x.RatingGiven), actual[0].AvgRating);
                Assert.AreEqual(expected[1].Ratings.Average(x => x.RatingGiven), actual[1].AvgRating);
                Assert.AreEqual(expected[2].Ratings.Average(x => x.RatingGiven), actual[2].AvgRating);
                Assert.AreEqual(expected[3].Ratings.Average(x => x.RatingGiven), actual[3].AvgRating);
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

            var rnd = new Random();

            foreach (var item in beers)
            {
                item.Brewery = brewery;
                item.Style = style;
                item.Ratings.Add(Mock.Of<Rating>(x => x.RatingGiven == rnd.Next(0, 5)));
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
                var result = await sut.OrderByRatingAsync('d');
                var actual = result.ToList();
                var expected = beers.OrderByDescending(x => x.Ratings.Average(x => x.RatingGiven)).ToList();

                Assert.AreEqual(expected[0].Ratings.Average(x => x.RatingGiven), actual[0].AvgRating);
                Assert.AreEqual(expected[1].Ratings.Average(x => x.RatingGiven), actual[1].AvgRating);
                Assert.AreEqual(expected[2].Ratings.Average(x => x.RatingGiven), actual[2].AvgRating);
                Assert.AreEqual(expected[3].Ratings.Average(x => x.RatingGiven), actual[3].AvgRating);
            }
        }
    }
}
