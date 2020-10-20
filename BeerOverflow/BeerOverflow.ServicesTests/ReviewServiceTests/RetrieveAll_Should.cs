using BeerOverflow.Database;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.ServicesTests.ReviewServiceTests
{
    [TestClass]
    public class RetrieveAll_Should
    {
        [TestMethod]
        public void ReturnAllReviewsWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var reviews = Utils.GetReviews();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Reviews.AddRange(reviews);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new ReviewService(actContext);
                var actual = sut.RetrieveAll().ToList();

                Assert.AreEqual(reviews.First().Content, actual[0].Content);
                Assert.AreEqual(reviews.Last().Id, actual[2].Id);
                Assert.AreEqual(reviews.Count(), actual.Count);
            }
        }

        [TestMethod]
        public void ReturnNullWhen_NoReviews()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new ReviewService(actContext);
                var actual = sut.RetrieveAll();

                Assert.IsFalse(actual.Any());
            }
        }
    }
}
