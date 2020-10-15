using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.ServicesTests.StyleServcieTests
{
    [TestClass]
    public class Delete_Should
    {
        [TestMethod]
        public void DeleteStyleWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var style = new Style()
            {
                Id = Guid.NewGuid(),
                Name = "Pale Ale",
                Description = "Pale ale is a kind of ale, atop-fermented beer made with predominantly pale malt."
            };

            using(var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Styles.Add(style);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using(var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(actContext);
                var actual = sut.Delete(style.Id);

                Assert.IsTrue(actual);
            }
        }

        [TestMethod]
        public void ReturnFalseWhen_NoSuchStyle()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(actContext);
                var actual = sut.Delete(Guid.NewGuid());

                Assert.IsFalse(actual);
            }
        }
    }
}
