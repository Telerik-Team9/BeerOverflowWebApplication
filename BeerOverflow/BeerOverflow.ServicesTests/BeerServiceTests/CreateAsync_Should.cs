using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.BeerServiceTests
{
    [TestClass]
    public class CreateAsync_Should
    {
        [TestMethod]
        public async Task CreateBeerWhen_ValidParams()
        {
            // Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beer = Utils.GetBeers().First();

            beer.Brewery = Mock.Of<Brewery>(x => x.Name == "Beer Bastards");
            beer.Style = Mock.Of<Style>(x => x.Name == "IPA - Brut");
            var dto = beer.GetDTO();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                await arrangeContext.Breweries.AddAsync(beer.Brewery);
                await arrangeContext.Styles.AddAsync(beer.Style);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                var result = await sut.CreateAsync(dto);

                Assert.AreEqual(dto.Name, result.Name);
                Assert.AreEqual(dto.Id, result.Id);
                Assert.AreEqual(actContext.Beers.Count(), 1);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_BreweryIsNull()
        {
            // Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beer = Utils.GetBeers().First();

            beer.Style = Mock.Of<Style>(x => x.Name == "IPA - Brut");
            var dto = beer.GetDTO();

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                      (async () => await sut.CreateAsync(dto));
            }
        }

        [TestMethod]
        public async Task ThrowWhen_StyleIsNull()
        {
            // Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var beer = Utils.GetBeers().First();

            beer.Brewery = Mock.Of<Brewery>(x => x.Name == "Beer Bastards");
            var dto = beer.GetDTO();

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BeerService(actContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                      (async () => await sut.CreateAsync(dto));
            }
        }
    }
}