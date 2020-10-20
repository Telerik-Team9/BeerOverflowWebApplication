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
    public class RetrieveById_Should
    {
        [TestMethod]
        public void ReturnCorrectReviewDTOWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var reviews = Utils.GetReviews();
            var reviewDTO = reviews.Last();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.AddRange(reviews);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new ReviewService(actContext);
                var actual = sut.RetrieveById(reviewDTO.Id);

                Assert.AreEqual(reviewDTO.Id, actual.Id);
                Assert.AreEqual(reviewDTO.Content, actual.Content);
            }
        }

        [TestMethod]
        public void ReturnNullWhen_NoSuchReview()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new ReviewService(actContext);
                var actual = sut.RetrieveById(Guid.NewGuid());

                Assert.IsNull(actual);
            }
        }
    }
}
