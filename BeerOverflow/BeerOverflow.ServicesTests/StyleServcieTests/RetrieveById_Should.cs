using BeerOverflow.Database;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.StyleServcieTests
{
    [TestClass]
    public class RetrieveById_Should
    {
        [TestMethod]
        public async Task ReturnCorrectStyleDTOWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var style = Utils.GetStyles().First();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Add(style);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var assertContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(assertContext);
                var actual = await sut.RetrieveByIdAsync(style.Id);

                Assert.AreEqual(style.Id, actual.Id);
                Assert.AreEqual(style.Name, actual.Name);
                Assert.AreEqual(style.Description, actual.Description);
            }
        }

        [TestMethod]
        public async Task ReturnNullWhen_NoSuchStyle()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(actContext);
                var actual = await sut.RetrieveByIdAsync(Guid.NewGuid());

                Assert.IsNull(actual);
            }
        }
    }
}
