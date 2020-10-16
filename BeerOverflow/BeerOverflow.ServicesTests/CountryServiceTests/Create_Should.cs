using BeerOverflow.Database;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.ServicesTests.CountryServiceTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public async Task CreateCountryWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            var countryDTO = new CountryDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Bulgaria",
                ISO = "BG"
            };

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);
                var actual = await sut.CreateAsync(countryDTO);

                Assert.AreEqual(countryDTO.Id, actual.Id);
                Assert.AreEqual(countryDTO.Name, actual.Name);
                Assert.AreEqual(countryDTO.ISO, actual.ISO);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_CountryIsNull()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.CreateAsync(null));
            }
        }
    }
}
