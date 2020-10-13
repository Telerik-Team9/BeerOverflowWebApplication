using BeerOverflow.Database;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.ServicesTests.CountryServiceTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public void CreateCountryWhen_ValidParams()
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
                var actual = sut.Create(countryDTO);

                Assert.AreEqual(countryDTO.Id, actual.Id);
                Assert.AreEqual(countryDTO.Name, actual.Name);
                Assert.AreEqual(countryDTO.ISO, actual.ISO);
            }
        }

        [TestMethod]
        public void ThrowWhen_CountryIsNull()
        {
            //Arrange
            var options = Utils.GetOptions(Guid.NewGuid().ToString());

            //Act & Assert
            using (var actContext = new BeerOverflowDbContext(options))
            {
                var sut = new CountryService(actContext);

                Assert.ThrowsException<ArgumentNullException>(() => sut.Create(null));
            }
        }
    }
}
