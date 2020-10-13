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
    public class RetrieveById_Should
    {
        [TestMethod]
        public void ReturnCorrectStyleDTOWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var id = Guid.NewGuid();

            var style1 = new Style()
            {
                Id = Guid.Empty,
                Name = "Pale Ale",
                Description = "Pale ale is a kind of ale, atop-fermented beer made with predominantly pale malt."
            };
            var style2 = new Style()
            {
                Id = id,
                Name = "IPA - BRUT",
                Description = "The style was originally brewed in San Francisco’s Social Kitchen & Brewing, and was named ‘brut’ for its extreme dryness, as a reference to brut champagne. In fact, brut champagne contains up to 12g/l of sugar and isn’t the driest sparkling wine out there, but we’ll let that go."
            };

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Styles.Add(style1);
                arrangeContext.Styles.Add(style2);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using(var assertContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(assertContext);
                var actual = sut.RetrieveById(id);

                Assert.AreEqual(style2.Id, actual.Id);
                Assert.AreEqual(style2.Name, actual.Name);
                Assert.AreEqual(style2.Description, actual.Description);
            }
        }

        [TestMethod]
        public void ReturnNullWhen_NoSuchStyle()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(actContext);
                var actual = sut.RetrieveById(Guid.NewGuid());

                Assert.IsNull(actual);
            }
        }

    }
}
