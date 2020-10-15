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
    public class RetrieveAll_Should
    {
        [TestMethod]
        public async Task ReturnAllStylesWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var styles = Utils.GetStyles().ToList();

            using(var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Styles.AddRange(styles);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using(var assertContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(assertContext);
                var result = await sut.RetrieveAllAsync();
                var actual = result.ToList();

                Assert.AreEqual(styles[0].Id, actual[0].Id);
                Assert.AreEqual(styles[0].Name, actual[0].Name);
                Assert.AreEqual(styles[0].Description, actual[0].Description);

                Assert.AreEqual(styles[1].Id, actual[1].Id);
                Assert.AreEqual(styles[1].Name, actual[1].Name);
                Assert.AreEqual(styles[1].Description, actual[1].Description);

                Assert.AreEqual(styles[2].Id, actual[2].Id);
                Assert.AreEqual(styles[2].Name, actual[2].Name);
                Assert.AreEqual(styles[2].Description, actual[2].Description);

                Assert.AreEqual(styles[3].Id, actual[3].Id);
                Assert.AreEqual(styles[3].Name, actual[3].Name);
                Assert.AreEqual(styles[3].Description, actual[3].Description);

                Assert.AreEqual(4, actual.Count);
            }
        }

        [TestMethod]
        public async Task ReturnNullWhen_NoCountries()
        {
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(actContext);
                var actual = await sut.RetrieveAllAsync();

                Assert.AreEqual(0, actual.Count());
            }
        }
    }
}
