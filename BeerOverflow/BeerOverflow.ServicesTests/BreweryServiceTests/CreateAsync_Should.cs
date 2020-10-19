using BeerOverflow.Database;
using BeerOverflow.Models;
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
    public class CreateAsync_Should
    {
        [TestMethod]
        public async Task CreateBreweryWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            var country = new Country()
            {
                Id = Guid.NewGuid(),
                Name = "Bulgaria",
                ISO = "BG"
            };

            var breweryDTO = new BreweryDTO
            {
                Id = Guid.NewGuid(),
                Name = "BeerBox",
                CountryName = "Bulgaria"
            };

            using(var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.Countries.AddAsync(country);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using(var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BreweryService(actContext);
                var actual = await sut.CreateAsync(breweryDTO);


                await actContext.SaveChangesAsync();
                Assert.AreEqual(breweryDTO.Id, actual.Id);
                Assert.AreEqual(breweryDTO.Name, actual.Name);
                Assert.AreEqual(1, actContext.Breweries.Count());
            }
        }

        [TestMethod]
        public async Task ThrowWhen_CountryIsNull()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            var breweryDTO = new BreweryDTO
            {
                Id = Guid.NewGuid(),
                Name = "BeerBox",
                CountryName = "Bulgaria"
            };

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BreweryService(actContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.CreateAsync(breweryDTO));
            }
        }
    }
}
