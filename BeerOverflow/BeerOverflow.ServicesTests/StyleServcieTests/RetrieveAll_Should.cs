using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.ServicesTests.StyleServcieTests
{
    [TestClass]
    public class RetrieveAll_Should
    {
        [TestMethod]
        public void ReturnAllStylesWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var style1 = new Style()
            {
                Id = Guid.NewGuid(),
                Name = "Pale Ale",
                Description = "Pale ale is a kind of ale, atop-fermented beer made with predominantly pale malt."
            };
            var style2 = new Style()
            {
                Id = Guid.NewGuid(),
                Name = "IPA - BRUT",
                Description = "The style was originally brewed in San Francisco’s Social Kitchen & Brewing, and was named ‘brut’ for its extreme dryness, as a reference to brut champagne. In fact, brut champagne contains up to 12g/l of sugar and isn’t the driest sparkling wine out there, but we’ll let that go."
            };
            var style3 = new Style()
            {
                Id = Guid.NewGuid(),
                Name = "Unknown",
                Description = "Unknown"
            };

            using(var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Styles.Add(style1);
                arrangeContext.Styles.Add(style2);
                arrangeContext.Styles.Add(style3);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using(var assertContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(assertContext);
                var actual = sut.RetrieveAll().ToList();

                Assert.AreEqual(style1.Id, actual[0].Id);
                Assert.AreEqual(style1.Name, actual[0].Name);
                Assert.AreEqual(style1.Description, actual[0].Description);

                Assert.AreEqual(style2.Id, actual[1].Id);
                Assert.AreEqual(style2.Name, actual[1].Name);
                Assert.AreEqual(style2.Description, actual[1].Description);

                Assert.AreEqual(3, actual.Count);
            }
        }

        [TestMethod]
        public void ReturnNullWhen_NoCountries()
        {
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(actContext);
                var actual = sut.RetrieveAll().ToList();

                Assert.AreEqual(0, actual.Count);
            }
        }
    }
}
