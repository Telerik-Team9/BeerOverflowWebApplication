using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.BreweryServiceTests
{
    [TestClass]
    public class RetrieveByIdAsync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectBreweryDTOWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            var brewery = Utils.GetBreweries().First();

            using (var arrangeContext = new BeerOverflowDbContext(options))
            {
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.SaveChanges();
            }

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BreweryService(actContext);

                var actual = await sut.RetrieveByIdAsync(brewery.Id);

                Assert.AreEqual(brewery.Id, actual.Id);
                Assert.AreEqual(brewery.Name, actual.Name);
            }
        }
        [TestMethod]
        public async Task ReturnNullWhen_NoSuchCountry()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new BreweryService(actContext);
                var actual = await sut.RetrieveByIdAsync(Guid.NewGuid());

                Assert.IsNull(actual);
            }
        }
    }
}
