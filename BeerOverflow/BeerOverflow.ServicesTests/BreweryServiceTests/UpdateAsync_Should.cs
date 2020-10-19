using BeerOverflow.Database;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.BreweryServiceTests
{
    [TestClass]
    public class UpdateAsync_Should
    {
        [TestMethod]
        public async Task UpdateCountryWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var brewery = Utils.GetBreweries().First();

            var brewweryDTO = new BreweryDTO()
            {
                Id = Guid.NewGuid(),
                Name = "BeerBox",
                CountryName = "Bulgaria",
                CountryId = Guid.Parse("eee1a9ab-c409-42c4-ae07-f622a959bb0b")
            };

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BreweryService(actContext);
                var actual = await sut.UpdateAsync(brewery.Id, brewweryDTO);

                Assert.AreEqual(brewery.Id, actual.Id);
                Assert.AreEqual(brewweryDTO.Name, actual.Name);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_NoSuchBrewery()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BreweryService(actContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.UpdateAsync(Guid.NewGuid(), null));
            }
        }
    }
}
