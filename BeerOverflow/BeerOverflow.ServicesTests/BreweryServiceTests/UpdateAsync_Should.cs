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
        public async Task UpdateBreweryWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var brewery = Utils.GetBreweries().First();
            var country = Utils.GetCountries().First();

            var breweryDTO = new BreweryDTO()
            {
                Id = Guid.NewGuid(),
                Name = "BeerBox",
                CountryName = "Bulgaria",
                CountryId = country.Id
            };

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BreweryService(actContext);
                var actual = await sut.UpdateAsync(brewery.Id, breweryDTO);

                Assert.AreEqual(breweryDTO.Id, actual.Id);
                Assert.AreEqual(breweryDTO.Name, actual.Name);
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
