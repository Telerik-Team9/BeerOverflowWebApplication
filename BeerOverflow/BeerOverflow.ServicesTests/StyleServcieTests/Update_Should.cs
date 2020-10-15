using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.StyleServcieTests
{
    [TestClass]
    public class Update_Should
    {
        [TestMethod]
        public async Task UpdateStyleWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var style = Utils.GetStyles().First();

            var styleDTO = new StyleDTO()
            {
                Name = "Lager",
                Description = "Lager is a type of beer conditioned at low temperature. Lagers can be pale, amber, or dark.",
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
                var actual = await sut.UpdateAsync(style.Id, styleDTO);

                Assert.AreEqual(style.Id, actual.Id);
                Assert.AreEqual(styleDTO.Name, actual.Name);
                Assert.AreEqual(styleDTO.Description, actual.Description);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_NoSuchStyle()
        {
            // Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(actContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.UpdateAsync(Guid.NewGuid(), null));
            }
        }
    }
}
