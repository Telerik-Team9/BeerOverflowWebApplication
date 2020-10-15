using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.StyleServcieTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public async Task CreateStyleWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var styleDTO = new StyleDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Pale Ale",
                Description = "Pale ale is a kind of ale, atop-fermented beer made with predominantly pale malt.",
                Beers = new List<BeerDTO>()
            };

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(actContext);
                var actual = await sut.CreateAsync(styleDTO);

                Assert.AreEqual(styleDTO.Id, actual.Id);
                Assert.AreEqual(styleDTO.Name, actual.Name);
                Assert.AreEqual(styleDTO.Description, actual.Description);
            }
        }

        [TestMethod]
        public void ThrowWhen_StyleIsNull()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new StyleService(actContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.Create(null));
            }
        }
    }
}
