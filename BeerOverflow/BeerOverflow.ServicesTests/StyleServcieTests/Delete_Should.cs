using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.StyleServcieTests
{
    [TestClass]
    public class Delete_Should
    {
        [TestMethod]
        public async Task DeleteStyleWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var style = Utils.GetStyles().First();

            using(var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Styles.Add(style);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using(var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(actContext);
                var actual = await sut.DeleteAsync(style.Id);

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
                var actual = sut.DeleteAsync(Guid.NewGuid());

                Assert.IsFalse(actual.Result);
            }
        }
    }
}
