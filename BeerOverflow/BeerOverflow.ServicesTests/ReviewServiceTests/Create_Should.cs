using BeerOverflow.Database;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.ServicesTests.ReviewServiceTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public void CreateReviewWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var review = Utils.GetReviews().First();

            var reviewDTO = review.GetDTO();

            //Act & Assert
            using(var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new ReviewService(actContext);
                var actual = sut.Create(reviewDTO);

                Assert.AreEqual(reviewDTO.Content, actual.Content);
                Assert.AreEqual(reviewDTO.Likes, actual.Likes);
                Assert.AreEqual(reviewDTO.Rating, actual.Rating);
            }            
        }

        [TestMethod]
        public void ThrowWhen_ReviewIsNull()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new ReviewService(actContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.Create(null));
            }
        }
    }
}
