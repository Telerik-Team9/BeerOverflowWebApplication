using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.ServicesTests.StyleServcieTests
{
    [TestClass]
    public class Update_Should
    {
        [TestMethod]
        public void UpdateStyleWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var style = new Style()
            {
                Id = Guid.NewGuid(),
                Name = "Pale Ale",
                Description = "Pale ale is a kind of ale, atop-fermented beer made with predominantly pale malt."
                
            };
            var styleDTO = new StyleDTO()
            {
                Name = "Pale Ale",
                Description = "Pale ale is a kind of ale, atop-fermented beer made with predominantly pale malt.",
                Beers = new List<BeerDTO>()
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
                var actual = sut.Update(style.Id, styleDTO);

                Assert.AreEqual(style.Id, actual.Id);
                Assert.AreEqual(styleDTO.Name, actual.Name);
                Assert.AreEqual(styleDTO.Description, actual.Description);
            }
        }

        [TestMethod]
        public void ThrowWhen_NoSuchStyle()
        {
            // Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(actContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.Update(Guid.NewGuid(), null));
            }
        }
    }
}
